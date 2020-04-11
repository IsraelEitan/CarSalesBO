using VehiclesPriceListApp.Core.Entity;

namespace VehiclesPriceListApp.Infrastructure.Data.SeedDB.Seeders
{
    class VehicleStatusSeed : ISeed
    {
        public void SeedData(VehiclesPriceListAppContext context)
        {
            context.VehicleStatus.Add(new VehicleStatus()
            {
               Name = "יד ראשונה"
            });

            context.VehicleStatus.Add(new VehicleStatus()
            {
                Name = "יד שנייה"
            });
        }
    }
}
