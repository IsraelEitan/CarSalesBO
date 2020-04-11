using System.Collections.Generic;


namespace VehiclesPriceListApp.Core.Entity
{
    public class VehicleStatus
    {
        public VehicleStatus()
        {
            VehiclePriceListItem = new HashSet<VehiclePriceListItem>();
        }
        public int Id { get; set; }
        public string Name { get; set; }     
        public ICollection<VehiclePriceListItem> VehiclePriceListItem { get; set; }
    }
}
