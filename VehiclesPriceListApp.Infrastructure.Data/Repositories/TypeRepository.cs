
using System.Linq;
using VehiclesPriceListApp.Core.DomainService;
using VehiclesPriceListApp.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace VehiclesPriceListApp.Infrastructure.Data.Repositories
{
    public class TypeRepository : Repository<VehicleType> , ITypeRepository
    {
    
        public TypeRepository(VehiclesPriceListAppContext ctx) : base(ctx)
        {
           
        }

        public VehiclesPriceListAppContext VehiclesPriceListAppContext
        {
            get { return Context as VehiclesPriceListAppContext; }
        }

        public override async Task<IEnumerable<VehicleType>> GetAll()
        {
            return await VehiclesPriceListAppContext
                .VehicleType
                .AsNoTracking()
                .ToListAsync();
        }  

        public override async Task<VehicleType> GetById(int id)
        {
            return await VehiclesPriceListAppContext
                .VehicleType
                .AsNoTracking()
                .FirstOrDefaultAsync(vpli => vpli.Id == id);
        }

        public override void Add(VehicleType entity)
        {
            VehiclesPriceListAppContext.Attach(entity);      
        }


        public override void Update(VehicleType entity)
        {
            VehiclesPriceListAppContext.VehicleType.Attach(entity);
            VehiclesPriceListAppContext.Entry<VehicleType>(entity).State = EntityState.Modified;
        }

        public int Count()
        {
            return VehiclesPriceListAppContext.VehiclePriceListItem.Count();
        }

        public async Task<VehicleType> Remove(int id)
        {
            var removableVehicleTypeItem = await Find(v => v.Id == id);
            var removableVehicleTypeActualItem = removableVehicleTypeItem.FirstOrDefault();

            base.Remove(removableVehicleTypeActualItem);

            return removableVehicleTypeActualItem;
        }

   
    }
}