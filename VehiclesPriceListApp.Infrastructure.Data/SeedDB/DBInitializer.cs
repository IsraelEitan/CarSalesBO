using System;
using System.Drawing;
using VehiclesPriceListApp.Core.Entity;
using VehiclesPriceListApp.Infrastructure.Data.SeedDB;

namespace VehiclesPriceListApp.Infrastructure.Data
{
    public class DBInitializer 
    {
        public static void SeedDB(VehiclesPriceListAppContext context)
        {
          
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            GlobalSeeder seeder = new GlobalSeeder();
            seeder.SeedDatabase(context);         
        }
    }      
}