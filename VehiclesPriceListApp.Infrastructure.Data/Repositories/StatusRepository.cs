
using System.Linq;
using VehiclesPriceListApp.Core.DomainService;
using VehiclesPriceListApp.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace VehiclesPriceListApp.Infrastructure.Data.Repositories
{
    public class StatusRepository : Repository<VehicleStatus> , IStatusRepository
    {
    
        public StatusRepository(VehiclesPriceListAppContext ctx) : base(ctx)
        {
           
        }

        public VehiclesPriceListAppContext VehiclesPriceListAppContext
        {
            get { return Context as VehiclesPriceListAppContext; }
        }

        public override async Task<IEnumerable<VehicleStatus>> GetAll()
        {
            return await VehiclesPriceListAppContext
                .VehicleStatus
                .AsNoTracking()
                .ToListAsync();
        }  

        public override async Task<VehicleStatus> GetById(int id)
        {
            return await VehiclesPriceListAppContext
                .VehicleStatus
                .AsNoTracking()
                .FirstOrDefaultAsync(vpli => vpli.Id == id);
        }

        public override void Add(VehicleStatus entity)
        {
            VehiclesPriceListAppContext.Attach(entity);      
        }


        public override void Update(VehicleStatus entity)
        {
            VehiclesPriceListAppContext.VehicleStatus.Attach(entity);
            VehiclesPriceListAppContext.Entry<VehicleStatus>(entity).State = EntityState.Modified;
        }

        public int Count()
        {
            return VehiclesPriceListAppContext.VehiclePriceListItem.Count();
        }

        public async Task<VehicleStatus> Remove(int id)
        {
            var removableVehicleStatusItem = await Find(v => v.Id == id);
            var removableVehicleStatusActualItem = removableVehicleStatusItem.FirstOrDefault();

            base.Remove(removableVehicleStatusActualItem);

            return removableVehicleStatusActualItem;
        }

   
    }
}