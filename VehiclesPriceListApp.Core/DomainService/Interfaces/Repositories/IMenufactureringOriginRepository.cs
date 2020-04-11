using System.Collections.Generic;
using System.Threading.Tasks;
using VehiclesPriceListApp.Core.Entity;

namespace VehiclesPriceListApp.Core.DomainService
{
    public interface IMenufactureringOriginRepository : IRepository<VehicleMenufacturingOrigin>
    {
        int Count();

        Task<VehicleMenufacturingOrigin> Remove(int id);

    }
}
