using System.ComponentModel.DataAnnotations;

namespace VehiclesPriceListRestApi.Dtos
{
    public class VehicleOwnerDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string EmailAddress { get; set; }
    }
}