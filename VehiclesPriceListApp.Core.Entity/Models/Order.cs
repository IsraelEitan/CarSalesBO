using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesPriceListApp.Core.Entity
{
    public class Order
    {
        [JsonProperty(PropertyName = "column")]
        public int Column
        {
            get;
            set;
        }
        [JsonProperty(PropertyName = "dir")]
        public string Dir
        {
            get;
            set;
        }
    }
}
