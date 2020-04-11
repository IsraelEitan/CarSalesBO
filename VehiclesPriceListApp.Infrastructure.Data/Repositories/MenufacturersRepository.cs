
using System.Linq;
using VehiclesPriceListApp.Core.DomainService;
using VehiclesPriceListApp.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace VehiclesPriceListApp.Infrastructure.Data.Repositories
{
    public class MenufacturersRepository : Repository<VehicleMenufacturer> , IMenufacturersRepository
    {
    
        public MenufacturersRepository(VehiclesPriceListAppContext ctx) : base(ctx)
        {
           
        }

        public VehiclesPriceListAppContext VehiclesPriceListAppContext
        {
            get { return Context as VehiclesPriceListAppContext; }
        }

        public override async Task<IEnumerable<VehicleMenufacturer>> GetAll()
        {
            return await VehiclesPriceListAppContext
                .VehicleMenufacturer
                .AsNoTracking()
                .ToListAsync();
        }  

        public override async Task<VehicleMenufacturer> GetById(int id)
        {
            return await VehiclesPriceListAppContext
                .VehicleMenufacturer
                .AsNoTracking()
                .FirstOrDefaultAsync(vpli => vpli.Id == id);
        }

        public override void Add(VehicleMenufacturer entity)
        {
            VehiclesPriceListAppContext.Attach(entity);      
        }


        public override void Update(VehicleMenufacturer entity)
        {
            VehiclesPriceListAppContext.VehicleMenufacturer.Attach(entity);
            VehiclesPriceListAppContext.Entry<VehicleMenufacturer>(entity).State = EntityState.Modified;
        }

        public int Count()
        {
            return VehiclesPriceListAppContext.VehiclePriceListItem.Count();
        }

        public async Task<VehicleMenufacturer> Remove(int id)
        {
            var removableVehicleMenufacturerItem = await Find(v => v.Id == id);
            var removableVehicleMenufacturerActualItem = removableVehicleMenufacturerItem.FirstOrDefault();

            base.Remove(removableVehicleMenufacturerActualItem);

            return removableVehicleMenufacturerActualItem;
        }

   
    }
}