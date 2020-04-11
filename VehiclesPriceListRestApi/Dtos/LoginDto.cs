using System.ComponentModel.DataAnnotations;

namespace VehiclesPriceListRestApi.Dtos
{
    public class LoginDto
    {
        public string UserName { get; set; }
        
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}