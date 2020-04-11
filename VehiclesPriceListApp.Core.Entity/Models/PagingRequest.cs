using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesPriceListApp.Core.Entity
{
    public class PagingRequest
    {
        [JsonProperty(PropertyName = "filter")]
        public FilterVehiclesPriceList Filter
        {
            get;
            set;
        }
    
        [JsonProperty(PropertyName = "pageNumber")]
        public int pageNumber
        {
            get;
            set;
        }
        [JsonProperty(PropertyName = "pageSize")]
        public int pageSize
        {
            get;
            set;
        }   
    }
}
