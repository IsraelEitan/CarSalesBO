
using System.Linq;
using VehiclesPriceListApp.Core.DomainService;
using VehiclesPriceListApp.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace VehiclesPriceListApp.Infrastructure.Data.Repositories
{
    public class MenufactureringOriginRepository : Repository<VehicleMenufacturingOrigin> , IMenufactureringOriginRepository
    {
    
        public MenufactureringOriginRepository(VehiclesPriceListAppContext ctx) : base(ctx)
        {
           
        }

        public VehiclesPriceListAppContext VehiclesPriceListAppContext
        {
            get { return Context as VehiclesPriceListAppContext; }
        }

        public override async Task<IEnumerable<VehicleMenufacturingOrigin>> GetAll()
        {
            return await VehiclesPriceListAppContext
                .VehicleMenufacturingOrigin
                .AsNoTracking()
                .ToListAsync();
        }  

        public override async Task<VehicleMenufacturingOrigin> GetById(int id)
        {
            return await VehiclesPriceListAppContext
                .VehicleMenufacturingOrigin
                .AsNoTracking()
                .FirstOrDefaultAsync(vpli => vpli.Id == id);
        }

        public override void Add(VehicleMenufacturingOrigin entity)
        {
            VehiclesPriceListAppContext.Attach(entity);      
        }


        public override void Update(VehicleMenufacturingOrigin entity)
        {
            VehiclesPriceListAppContext.VehicleMenufacturingOrigin.Attach(entity);
            VehiclesPriceListAppContext.Entry<VehicleMenufacturingOrigin>(entity).State = EntityState.Modified;
        }

        public int Count()
        {
            return VehiclesPriceListAppContext.VehiclePriceListItem.Count();
        }

        public async Task<VehicleMenufacturingOrigin> Remove(int id)
        {
            var removableVehicleMenufacturingOriginItem = await Find(v => v.Id == id);
            var removableVehicleMenufacturingOriginActualItem = removableVehicleMenufacturingOriginItem.FirstOrDefault();

            base.Remove(removableVehicleMenufacturingOriginActualItem);

            return removableVehicleMenufacturingOriginActualItem;
        }

   
    }
}