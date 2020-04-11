using System.Collections.Generic;
using System.Threading.Tasks;
using VehiclesPriceListApp.Core.Entity;

namespace VehiclesPriceListApp.Core.DomainService
{
    public interface ITypeRepository : IRepository<VehicleType>
    {
        int Count();

        Task<VehicleType> Remove(int id);

    }
}
