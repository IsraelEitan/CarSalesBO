using Newtonsoft.Json;

namespace VehiclesPriceListApp.Core.Entity
{
    public class SearchCriteria
    {
        [JsonProperty(PropertyName = "filter")]
        public FilterVehiclesPriceList Filter
        {
            get;
            set;
        }
        [JsonProperty(PropertyName = "isPageLoad")]
        public bool IsPageLoad
        {
            get;
            set;
        }
    }
}
