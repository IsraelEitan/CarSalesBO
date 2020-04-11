using VehiclesPriceListApp.Core.Entity;


namespace VehiclesPriceListApp.Core.DomainService
{
    public interface IUserRepository
    {
        FilteredData<User> ReadAll(FilterVehiclesPriceList filter);
        User CreateUser(User user, string readablePassword);
        User SignIn(User user, string readablePassword);
    }
   
}