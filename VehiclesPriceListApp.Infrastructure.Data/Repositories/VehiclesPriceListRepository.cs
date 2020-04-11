
using System.Linq;
using VehiclesPriceListApp.Core.DomainService;
using VehiclesPriceListApp.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using VehiclesPriceListApp.Infrastructure.Data.Helper;
using System;

namespace VehiclesPriceListApp.Infrastructure.Data.Repositories
{
    public class VehiclesPriceListRepository : Repository<VehiclePriceListItem> , IVehiclesPriceListRepository
    {
    
        public VehiclesPriceListRepository(VehiclesPriceListAppContext ctx) : base(ctx)
        {
           
        }

        public VehiclesPriceListAppContext VehiclesPriceListAppContext
        {
            get { return Context as VehiclesPriceListAppContext; }
        }


        public override async Task<IEnumerable<VehiclePriceListItem>> GetAll()
        {
            return await VehiclesPriceListAppContext.VehiclePriceListItem
                .BuildVehiclePriceListItem()
                .AsNoTracking().ToListAsync();
        }
 
        public async Task<PagingResponse<VehiclePriceListItem>> GetAllPaging(PagingRequest paging)
        {
            var pagingResponse = new PagingResponse<VehiclePriceListItem>();
           

            IQueryable<VehiclePriceListItem> query = null;

            query = VehiclesPriceListAppContext.VehiclePriceListItem.BuildVehiclePriceListItem();



            if (paging.Filter != null)
            {
                query = query.BuildFilteredOptions(paging.Filter as FilterVehiclesPriceList);
            }

            var totalItems = query.Count();

            //for sorting on server side 
            //var colOrder = paging.sortOrder;
            //query = colOrder == "asc" ? query.OrderBy(vpli => vpli.AskingPrice) : query.OrderByDescending(emp => emp.AskingPrice);

            //See sql statement from entity query
            //var sql = query.ToSql();


            var vehiclePriceList  = await query.Skip((paging.pageNumber) * paging.pageSize).Take(paging.pageSize).ToArrayAsync();

            pagingResponse.Items = vehiclePriceList;
            pagingResponse.TotalItems = totalItems;
            pagingResponse.PageSize = paging.pageSize;
            pagingResponse.Page = paging.pageNumber;

            return pagingResponse; 
        }

        public async Task<PriceRange> GetPriceBounds()
        {
            var topPrice = await VehiclesPriceListAppContext.VehiclePriceListItem.MaxAsync(vpli => vpli.AskingPrice);
            var lowPrice = await VehiclesPriceListAppContext.VehiclePriceListItem.MinAsync(vpli => vpli.AskingPrice);

            return new PriceRange() { LowPrice = Convert.ToInt32(lowPrice), TopPrice = Convert.ToInt32(topPrice) };
        }


        public override async Task<VehiclePriceListItem> GetById(int id)
        {
            return await VehiclesPriceListAppContext.VehiclePriceListItem
                .BuildVehiclePriceListItem()
                .AsNoTracking()
                .FirstOrDefaultAsync(vpli => vpli.Id == id);
        }

        public override void Add(VehiclePriceListItem entity)
        {
            VehiclesPriceListAppContext.Attach(entity.VehicleMenufacturer);
            VehiclesPriceListAppContext.Attach(entity.VehicleMenufacturingOrigin);
            VehiclesPriceListAppContext.Attach(entity.VehicleOwner);
            VehiclesPriceListAppContext.Attach(entity.VehicleStatus);
            VehiclesPriceListAppContext.Attach(entity.VehicleType);

            entity.VehicleMenufacturer.VehiclePriceListItem.Add(entity);
            entity.VehicleMenufacturingOrigin.VehiclePriceListItem.Add(entity);
            entity.VehicleOwner.VehiclePriceListItem.Add(entity);
            entity.VehicleStatus.VehiclePriceListItem.Add(entity);
            entity.VehicleType.VehiclePriceListItem.Add(entity);       
        }


        public override void Update(VehiclePriceListItem entity)
        {
            VehiclesPriceListAppContext.VehiclePriceListItem.Attach(entity);
            VehiclesPriceListAppContext.Entry<VehiclePriceListItem>(entity).State = EntityState.Modified;
        }


        public int Count()
        {
            return VehiclesPriceListAppContext.VehiclePriceListItem.Count();
        }

        public async Task<VehiclePriceListItem> Remove(int id)
        {
            var removableVehiclePriceListItem = await Find(v => v.Id == id);
            var removableVehiclePriceListActualItem = removableVehiclePriceListItem.FirstOrDefault();

            base.Remove(removableVehiclePriceListActualItem);

            return removableVehiclePriceListActualItem;
        }

   
    }
}