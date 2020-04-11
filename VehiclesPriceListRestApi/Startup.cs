using VehiclesPriceListApp.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using AutoMapper;
using VehiclesPriceListRestApi.MapperProfiles;
using Newtonsoft.Json.Serialization;
using VehiclesPriceListRestApi.Middlewear;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Hosting;
using FluentValidation.AspNetCore;
using VehiclesPriceListRestApi.Validators;
using NLog;
using System;
using System.IO;
using VehiclesPriceListRestApi.Services;

namespace EASV.CustomerRestApi
{
    public class Startup
    {
        private IConfiguration _conf { get; }
        private IWebHostEnvironment _env { get; }

        public Startup(IWebHostEnvironment env)
        {
            _env = env;
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            _conf = builder.Build();

            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddResponseCompression();
            if (_env.IsDevelopment())
            {
                services.AddDbContext<VehiclesPriceListAppContext>(
                    opt => opt   // .UseLazyLoadingProxies()
                    .UseSqlite(_conf.GetConnectionString("SqliteConnection"), b => b.MigrationsAssembly("VehiclesPriceListRestApi")));

            }
            else if (_env.IsProduction())
            {
                services.AddDbContext<VehiclesPriceListAppContext>(
                    opt => opt   // .UseLazyLoadingProxies()               
                        .UseSqlServer(_conf.GetConnectionString("DefaultConnection")));

            }
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new SimpleMappings());
            });

            IMapper mapper = mappingConfig.CreateMapper();

            services.AddSingleton(mapper);

            #region toremove
            // ===== Add Jwt Authentication ========

            //services
            //    .AddAuthentication(options =>
            //    {
            //        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            //        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            //    })
            //    .AddJwtBearer(cfg =>
            //    {
            //        cfg.RequireHttpsMetadata = false;
            //        cfg.SaveToken = true;
            //        cfg.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidIssuer = _conf["JwtIssuer"],
            //            ValidAudience = _conf["JwtIssuer"],
            //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_conf["JwtKey"])),
            //            ClockSkew = TimeSpan.Zero // remove delay of token when expire
            //        };
            //    });
            #endregion 

            ServicesConfiguration.ConfigureDomainService(services);

            ServicesConfiguration.ConfigureLoggerService(services);

            //side and the client side projects will run on different domains 
            //enable CORS on the server side project
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder =>
                    builder.WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                var resolver = options.SerializerSettings.ContractResolver;
                if (resolver != null)
                    (resolver as DefaultContractResolver).NamingStrategy = null;
            });

            services
                .AddControllersWithViews()
                .AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<ValidatorsCollection>())
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Awesome API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Shows UseCors with named policy.
            app.UseCors("CorsPolicy");

            app.UseAccessControlAllowOriginAlways();

            app.UseAuthentication();
            app.UseResponseCompression();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<VehiclesPriceListAppContext>();
                    DBInitializer.SeedDB(ctx);
                }
            }
            else
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<VehiclesPriceListAppContext>();
                    ctx.Database.EnsureCreated();
                }
                app.UseHsts();
                app.UseHttpsRedirection();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }


    }
}
