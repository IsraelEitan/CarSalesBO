using System;
using VehiclesPriceListApp.Core.DomainService;
using VehiclesPriceListApp.Core.Entity;


namespace VehiclesPriceListApp.Core.ApplicationService.Services
{
    public class UserService: IUserService
    {
        readonly IUserRepository _userRepo;

        public UserService(IUserRepository userRepository)
        {
            _userRepo = userRepository;
        }

        public FilteredData<User> GetAllUsers(FilterVehiclesPriceList filter = null)
        {
            return _userRepo.ReadAll(filter);
        }


        public User CreateUser(User user, string readablePassword)
        {
            if (user == null)
                throw new ArgumentNullException(nameof (user));
            if (readablePassword == null)
                throw new ArgumentNullException(nameof (readablePassword));
            
            //Add minimum password length!!


            return _userRepo.CreateUser(user, readablePassword);
        }
        
        public User SignIn(User user, string readablePassword)
        {
            
            //Add minimum password length!!


            return _userRepo.SignIn(user, readablePassword);
        }

    }
}
