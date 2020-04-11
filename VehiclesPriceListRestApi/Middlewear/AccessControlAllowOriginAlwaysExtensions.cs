using Microsoft.AspNetCore.Builder;

namespace VehiclesPriceListRestApi.Middlewear
{
    public static class AccessControlAllowOriginAlwaysExtensions
    {
        public static IApplicationBuilder UseAccessControlAllowOriginAlways(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AccessControlAllowOriginAlways>();
        }
    }
}
