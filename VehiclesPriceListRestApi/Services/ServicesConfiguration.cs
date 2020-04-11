using LoggerService;
using Microsoft.Extensions.DependencyInjection;
using VehiclesPriceListApp.Core.ApplicationService;
using VehiclesPriceListApp.Core.ApplicationService.Services;
using VehiclesPriceListApp.Core.DomainService;
using VehiclesPriceListApp.Core.DomainService.Interfaces.Logger;
using VehiclesPriceListApp.Infrastructure.Data;
using VehiclesPriceListApp.Infrastructure.Data.Repositories;

namespace VehiclesPriceListRestApi.Services
{
    public static class ServicesConfiguration
    {
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        public static void ConfigureDomainService(this IServiceCollection services)
        {
            services.AddScoped<IVehiclesPriceListRepository, VehiclesPriceListRepository>();
            services.AddScoped<IVehiclesPriceListService, VehiclesPriceListService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

    }

}
