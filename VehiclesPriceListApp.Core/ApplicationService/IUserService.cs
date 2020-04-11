using VehiclesPriceListApp.Core.Entity;

namespace VehiclesPriceListApp.Core.ApplicationService
{
    public interface IUserService
    {
        FilteredData<User> GetAllUsers(FilterVehiclesPriceList filter);
        
        User CreateUser(User user, string readablePassword);

        User SignIn(User user, string readablePassword);
    }
}