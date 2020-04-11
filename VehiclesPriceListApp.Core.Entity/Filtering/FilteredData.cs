using System;
using System.Collections.Generic;

namespace VehiclesPriceListApp.Core.Entity
{
    public class FilteredData <T>
    {
        public IEnumerable<T> Items { get; set; }   
        public int TotalCount { get; set; }
 
    }
}