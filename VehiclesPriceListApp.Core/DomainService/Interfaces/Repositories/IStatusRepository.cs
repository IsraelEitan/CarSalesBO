using System.Collections.Generic;
using System.Threading.Tasks;
using VehiclesPriceListApp.Core.Entity;

namespace VehiclesPriceListApp.Core.DomainService
{
    public interface IStatusRepository : IRepository<VehicleStatus>
    {
        int Count();

        Task<VehicleStatus> Remove(int id);

    }
}
