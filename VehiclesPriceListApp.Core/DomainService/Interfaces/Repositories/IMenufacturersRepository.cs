using System.Collections.Generic;
using System.Threading.Tasks;
using VehiclesPriceListApp.Core.Entity;

namespace VehiclesPriceListApp.Core.DomainService
{
    public interface IMenufacturersRepository : IRepository<VehicleMenufacturer>
    {
        int Count();

        Task<VehicleMenufacturer> Remove(int id);

    }
}
