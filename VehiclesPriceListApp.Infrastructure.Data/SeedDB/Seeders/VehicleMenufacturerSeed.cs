using VehiclesPriceListApp.Core.Entity;

namespace VehiclesPriceListApp.Infrastructure.Data.SeedDB.Seeders
{
   
    class VehicleMenufacturerSeed : ISeed
    {
        public void SeedData(VehiclesPriceListAppContext context)
        {
            context.VehicleMenufacturer.Add(new VehicleMenufacturer()
            {
              Name = "Honda"  
            });

            context.VehicleMenufacturer.Add(new VehicleMenufacturer()
            {
                Name = "Ford"
            });

            context.VehicleMenufacturer.Add(new VehicleMenufacturer()
            {
                Name = "Jeep"
            });
            context.VehicleMenufacturer.Add(new VehicleMenufacturer()
            {
                Name = "Kia"
            });
            context.VehicleMenufacturer.Add(new VehicleMenufacturer()
            {
                Name = "Alpha Romeo"
            });
        }
    }
}
