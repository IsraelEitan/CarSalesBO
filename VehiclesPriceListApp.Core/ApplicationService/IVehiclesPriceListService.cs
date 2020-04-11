using System.Collections.Generic;
using System.Threading.Tasks;
using VehiclesPriceListApp.Core.Entity;

namespace VehiclesPriceListApp.Core.ApplicationService
{
    public interface IVehiclesPriceListService
    {
        Task<int> Add(VehiclePriceListItem item);
        Task<VehiclePriceListItem> Find(int id);
        Task<IEnumerable<VehiclePriceListItem>> GetAll();     
        int Count();   
        Task Update(VehiclePriceListItem customerUpdate);
        Task< PagingResponse<VehiclePriceListItem>> GetAllPaging(PagingRequest paging);
        Task<VehiclePriceListItem> Remove(int id);
        Task<IEnumerable<VehicleMenufacturer>> GetMenufacturers();
        Task<IEnumerable<VehicleMenufacturingOrigin>> GetMenufacturingOrigins();
        Task<IEnumerable<VehicleStatus>> GetVehiclesStatus();
        Task<IEnumerable<VehicleType>> GetVehicleTypes();
        Task<IEnumerable<VehicleOwner>> GetVehicleOwners();
        Task<PriceRange> GetPriceBounds();
        Task<VehicleOwner>IsItemExist(string emailAddress);
    }
}
