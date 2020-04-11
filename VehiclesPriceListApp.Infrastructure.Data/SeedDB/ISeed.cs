using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesPriceListApp.Infrastructure.Data.SeedDB
{
    public interface ISeed
    {
        void SeedData(VehiclesPriceListAppContext context);
    }
}
