using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesPriceListApp.Core.Entity
{
    public class PagingResponse<T>
    {   
        [JsonProperty(PropertyName = "pageSize")]
        public int PageSize
        {
            get;
            set;
        }
        [JsonProperty(PropertyName = "totalItems")]
        public int TotalItems
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "page")]
        public int Page
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "items")]
        public IEnumerable<T> Items
        {
            get;
            set;
        }
       
    }
}
