using VehiclesPriceListApp.Core.Entity;

namespace VehiclesPriceListApp.Infrastructure.Data.SeedDB.Seeders
{

    class VehicleMenufacturingOriginSeed : ISeed
    {
        public void SeedData(VehiclesPriceListAppContext context)
        {
            context.VehicleMenufacturingOrigin.Add(new VehicleMenufacturingOrigin()
            {
               Name = "Asia"
            });

            context.VehicleMenufacturingOrigin.Add(new VehicleMenufacturingOrigin()
            {
                Name = "USA"
            });

            context.VehicleMenufacturingOrigin.Add(new VehicleMenufacturingOrigin()
            {
                Name = "China"
            });

            context.VehicleMenufacturingOrigin.Add(new VehicleMenufacturingOrigin()
            {
                Name = "Germany"
            });
        }
    }
}
