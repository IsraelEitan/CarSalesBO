
using System.Linq;
using VehiclesPriceListApp.Core.DomainService;
using VehiclesPriceListApp.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace VehiclesPriceListApp.Infrastructure.Data.Repositories
{
    public class OwnersRepository : Repository<VehicleOwner> , IOwnersRepository
    {
    
        public OwnersRepository(VehiclesPriceListAppContext ctx) : base(ctx)
        {
           
        }

        public VehiclesPriceListAppContext VehiclesPriceListAppContext
        {
            get { return Context as VehiclesPriceListAppContext; }
        }

        public override async Task<IEnumerable<VehicleOwner>> GetAll()
        {
            return await VehiclesPriceListAppContext
                .VehicleOwner
                .AsNoTracking()
                .ToListAsync();
        }  

        public override async Task<VehicleOwner> GetById(int id)
        {
            return await VehiclesPriceListAppContext
                .VehicleOwner
                .AsNoTracking()
                .FirstOrDefaultAsync(vpli => vpli.Id == id);
        }

        public override void Add(VehicleOwner entity)
        {
            VehiclesPriceListAppContext.Attach(entity);      
        }


        public override void Update(VehicleOwner entity)
        {
            VehiclesPriceListAppContext.VehicleOwner.Attach(entity);
            VehiclesPriceListAppContext.Entry<VehicleOwner>(entity).State = EntityState.Modified;
        }

        public async Task<VehicleOwner> GetOwnersEmail(string emailAddress)
        {
            var vehicleOwnerItem = await Find(p => p.EmailAddress == emailAddress);
            return vehicleOwnerItem.FirstOrDefault();
        }

        public int Count()
        {
            return VehiclesPriceListAppContext.VehiclePriceListItem.Count();
        }

        public async Task<VehicleOwner> Remove(int id)
        {
            var removableVehicleOwnerItem = await Find(v => v.Id == id);
            var removableVehicleOwnerActualItem = removableVehicleOwnerItem.FirstOrDefault();

            base.Remove(removableVehicleOwnerActualItem);

            return removableVehicleOwnerActualItem;
        }

   
    }
}