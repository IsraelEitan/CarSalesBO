using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VehiclesPriceListApp.Core.DomainService
{
    //Also For Testability
    public interface IUnitOfWork : IDisposable
    {
        IVehiclesPriceListRepository VehiclesPriceList { get; }
        IMenufacturersRepository Menufacturers { get; }
        IMenufactureringOriginRepository MenufactureringOrigin { get; }
        IOwnersRepository VehicleOwners { get; }
        IStatusRepository VehicleStatus { get; }
        ITypeRepository VehicleType { get; }

        Task<int> Complete();
    }
}
