using System.Collections.Generic;
using System.Threading.Tasks;
using VehiclesPriceListApp.Core.Entity;

namespace VehiclesPriceListApp.Core.DomainService
{
    public interface IVehiclesPriceListRepository : IRepository<VehiclePriceListItem>
    {
        int Count();

        Task<PagingResponse<VehiclePriceListItem>> GetAllPaging(PagingRequest paging);

        Task<VehiclePriceListItem> Remove(int id);

        Task<PriceRange> GetPriceBounds();
    }
}
