using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace VehiclesPriceListRestApi.Dtos
{  
    public class VehicleTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}