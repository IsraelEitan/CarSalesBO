using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VehiclesPriceListApp.Core.Entity
{
    public class VehicleType
    {
        public VehicleType()
        {
            VehiclePriceListItem = new HashSet<VehiclePriceListItem>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<VehiclePriceListItem> VehiclePriceListItem { get; set; }
    }
}
