using System.ComponentModel.DataAnnotations;

namespace VehiclesPriceListApp.Core.Entity
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public  Role Role { get; set; }
    }
}