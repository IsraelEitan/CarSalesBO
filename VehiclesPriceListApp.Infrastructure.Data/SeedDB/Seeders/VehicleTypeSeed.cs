using VehiclesPriceListApp.Core.Entity;

namespace VehiclesPriceListApp.Infrastructure.Data.SeedDB.Seeders
{

    class VehicleTypeSeed : ISeed
    {
        public void SeedData(VehiclesPriceListAppContext context)
        {
            context.VehicleType.Add(new VehicleType()
            {
               Name = "פרטי"
            });

            context.VehicleType.Add(new VehicleType()
            {
                Name = "מסחרי"
            });

            context.VehicleType.Add(new VehicleType()
            {
                Name = "גיפים"
            });
           
        }
    }
}
