using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehiclesPriceListApp.Core.Entity
{
    public class VehicleOwner
    {
        public VehicleOwner()
        {
            VehiclePriceListItem = new HashSet<VehiclePriceListItem>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string EmailAddress { get; set; }
        public  ICollection<VehiclePriceListItem> VehiclePriceListItem { get; set; }
    }
}
