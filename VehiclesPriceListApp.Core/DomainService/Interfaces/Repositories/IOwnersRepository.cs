using System.Collections.Generic;
using System.Threading.Tasks;
using VehiclesPriceListApp.Core.Entity;

namespace VehiclesPriceListApp.Core.DomainService
{
    public interface IOwnersRepository : IRepository<VehicleOwner>
    {
        int Count();

        Task<VehicleOwner> Remove(int id);

        Task<VehicleOwner> GetOwnersEmail(string emailAddress);
    }
}
