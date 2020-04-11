using Newtonsoft.Json;
using System;

namespace VehiclesPriceListApp.Core.Entity
{
    public class FilterVehiclesPriceList : ICloneable
    {
        public int? MenufacturerID { get; set; }
        public int? MenufacturingOriginID { get; set; }
        public int? VehicleTypeID { get; set; }
        public PriceRange PriceRange { get; set; }

        public FilterVehiclesPriceList() : base()
        {
           
        }
   
        public object Clone()
        {
            var jsonString = JsonConvert.SerializeObject(this);
            return JsonConvert.DeserializeObject(jsonString, this.GetType());
        }
    }
}