﻿using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace VehiclesPriceListRestApi.Middlewear
{
    public class AccessControlAllowOriginAlways
    {
        private readonly RequestDelegate _next;
        private const string AccessControlAllowOrigin = "Access-Control-Allow-Origin";
        public AccessControlAllowOriginAlways(RequestDelegate next)
        {
            _next = next;
        }
        public Task InvokeAsync(HttpContext context)
        {
            context.Response.OnStarting(() =>
            {
                if (!context.Response.Headers.ContainsKey(AccessControlAllowOrigin))
                {
                    context.Response.Headers.Add(AccessControlAllowOrigin, "http://localhost:4200");
                }
                return Task.CompletedTask;
            });
            return _next(context);
        }
    }
}
