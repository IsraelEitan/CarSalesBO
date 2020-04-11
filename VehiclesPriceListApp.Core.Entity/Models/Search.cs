using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesPriceListApp.Core.Entity
{
    public class Search
    {
        [JsonProperty(PropertyName = "value")]
        public string Value
        {
            get;
            set;
        }
        [JsonProperty(PropertyName = "regex")]
        public bool Regex
        {
            get;
            set;
        }
    }
}
