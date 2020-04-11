using System.Threading.Tasks;
using VehiclesPriceListApp.Core.DomainService;
using VehiclesPriceListApp.Infrastructure.Data.Repositories;

namespace VehiclesPriceListApp.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VehiclesPriceListAppContext _context;
        public IVehiclesPriceListRepository VehiclesPriceList { get; private set; }
        public IMenufacturersRepository Menufacturers { get; private set; }
        public IMenufactureringOriginRepository MenufactureringOrigin { get; private set; }
        public IOwnersRepository VehicleOwners { get; private set; }
        public IStatusRepository VehicleStatus { get; private set; }
        public ITypeRepository VehicleType { get; private set; }

        public UnitOfWork(VehiclesPriceListAppContext context)
        {
            _context = context;
            VehiclesPriceList = new VehiclesPriceListRepository(_context);
            Menufacturers = new MenufacturersRepository(_context);
            MenufactureringOrigin = new MenufactureringOriginRepository(_context);
            VehicleOwners = new OwnersRepository(_context);
            VehicleStatus = new StatusRepository(_context);
            VehicleType = new TypeRepository(_context);
        }
   
        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {   
            _context.Dispose();
        }
    }
}
