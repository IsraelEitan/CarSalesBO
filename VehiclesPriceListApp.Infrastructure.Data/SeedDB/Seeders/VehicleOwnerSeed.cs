using System;
using System.Collections.Generic;
using System.Linq;
using VehiclesPriceListApp.Core.Entity;

namespace VehiclesPriceListApp.Infrastructure.Data.SeedDB.Seeders
{
    class VehicleOwnerSeed : ISeed
    {
   

        public void SeedData(VehiclesPriceListAppContext context)
        {

            var ownersList = new[] { 
                                     new { fname = "Avi", lname = "Pro" , address = "Jabotinski 14 Givatime" },
                                     new { fname = "Guy", lname = "Bochveld" , address = "Tzahal 32 Hod Hasharon" },
                                     new { fname = "Yosi", lname = "Mizrahi" , address = "Hovevei Zion 2 Petach Tikva" },
                                     new { fname = "David", lname = "Hamelech" , address = "Waizman 4 Ramat Gan" },
                                     new { fname = "Moshe", lname = "Rabeno" , address = "Rakefet 87 Tel Aviv" },
                                     new { fname = "Gil", lname = "Cohen" , address = "Almog 7 Oranit" },
                                     new { fname = "Ziv", lname = "Barsheshet" , address = "Shoshan 18 Ramat Efal" },
                                     new { fname = "Nati", lname = "Simantov" , address = "Haroee 23 Herzlia" },
                                     new { fname = "Ofer", lname = "Wiess" , address = "Nirit 31 Kfar Saba" },
                                   }.ToList();

            for (var i = 0 ; i < 100 ; i++)
            {
                context.VehicleOwner.Add(new VehicleOwner()
                {
                    FirstName = ownersList[i%9].fname,
                    LastName =  ownersList[i % 9].lname,
                    Telephone = string.Format("05{0}-{1}{2}{3}{4}{5}{6}{7}", i % 4, i % 10, i % 6, i % 9, i % 10, i % 5, i % 7, i % 8),
                    Address =  ownersList[i % 9].address,
                    EmailAddress = string.Format("{0}.{1}.{2}@CarSales.com", ownersList[i % 9].fname , ownersList[i % 9].lname,i),                
                });
            }     
        }
    }
}
