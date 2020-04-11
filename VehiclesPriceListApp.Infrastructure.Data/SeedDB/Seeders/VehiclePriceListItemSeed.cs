using System;
using System.Drawing;
using System.Linq;
using VehiclesPriceListApp.Core.Entity;

namespace VehiclesPriceListApp.Infrastructure.Data.SeedDB.Seeders
{
    [DependsOn(typeof(VehicleMenufacturerSeed))]
    [DependsOn(typeof(VehicleMenufacturingOriginSeed))]
    [DependsOn(typeof(VehicleOwnerSeed))]
    [DependsOn(typeof(VehicleStatusSeed))]
    [DependsOn(typeof(VehicleTypeSeed))]
    class VehiclePriceListItemSeed : ISeed
    {
        public void SeedData(VehiclesPriceListAppContext context)
        {
           
            var randomNumber = new Random();
          
            KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));

            for (int i = 0; i < 100 ; i++)
            {
                context.VehiclePriceListItem.Add(new VehiclePriceListItem()
                {
                    AskingPrice = (randomNumber.Next(40, 100) * 1000).ToString(),
                    DateReceived = DateTime.Now.ToLocalTime(),
                    EquippingDetails = "Comfrontline",
                    Color = names[randomNumber.Next(names.Length)].ToString(),
                    EngineType = "regular",
                    TestValidExpiration = DateTime.Now.ToLocalTime().AddMonths(1),
                    VehicleMenufacturer = context.VehicleMenufacturer.Local.Skip(randomNumber.Next(context.VehicleMenufacturer.Local.Count())).Take(1).FirstOrDefault(),
                    VehicleMenufacturingOrigin = context.VehicleMenufacturingOrigin.Local.Skip(randomNumber.Next(context.VehicleMenufacturingOrigin.Local.Count())).Take(1).FirstOrDefault(),
                    VehicleType = context.VehicleType.Local.Skip(randomNumber.Next(context.VehicleType.Local.Count())).Take(1).FirstOrDefault(),
                    VehicleOwner = context.VehicleOwner.Local.Skip(randomNumber.Next(context.VehicleOwner.Local.Count())).Take(1).FirstOrDefault(),
                    VehicleStatus = context.VehicleStatus.Local.Skip(randomNumber.Next(context.VehicleStatus.Local.Count())).Take(1).FirstOrDefault(),
                });
            }
        }
    }
}
