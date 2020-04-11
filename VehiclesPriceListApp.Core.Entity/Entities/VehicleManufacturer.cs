using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehiclesPriceListApp.Core.Entity
{
    public class VehicleMenufacturer
    {
        public VehicleMenufacturer()
        {
            VehiclePriceListItem = new HashSet<VehiclePriceListItem>();
        }
        public int Id { get; set; }
        public string Name { get; set; }     
        public  ICollection<VehiclePriceListItem> VehiclePriceListItem { get; set; }
    }
}
