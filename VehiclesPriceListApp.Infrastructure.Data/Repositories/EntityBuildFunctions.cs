using Microsoft.EntityFrameworkCore;
using System.Linq;
using VehiclesPriceListApp.Core.Entity;

namespace VehiclesPriceListApp.Infrastructure.Data.Repositories
{
    internal static class EntityBuildFunctions
    {
        public static IQueryable<VehiclePriceListItem> BuildVehiclePriceListItem(this IQueryable<VehiclePriceListItem> query)
        {
            return query.Include(vm => vm.VehicleMenufacturer)
                    .Include(vmo => vmo.VehicleMenufacturingOrigin)
                    .Include(vo => vo.VehicleOwner)
                    .Include(vt => vt.VehicleType)
                    .Include(vs => vs.VehicleStatus);
        }

        public static IQueryable<VehiclePriceListItem> BuildFilteredOptions(this IQueryable<VehiclePriceListItem> query, FilterVehiclesPriceList filter)
        {
            query = filter.MenufacturerID != null ? query.Where(vpli => vpli.VehicleMenufacturerId == filter.MenufacturerID) : query;
            query = filter.MenufacturingOriginID != null ? query.Where(vpli => vpli.VehicleMenufacturingOriginId == filter.MenufacturingOriginID) : query;
            query = filter.VehicleTypeID != null ? query.Where(vpli => vpli.VehicleTypeId == filter.VehicleTypeID) : query;
            query = filter.PriceRange != null ? query.Where(vpli => (int.Parse(vpli.AskingPrice) >= filter.PriceRange.LowPrice) && (int.Parse(vpli.AskingPrice) <= filter.PriceRange.TopPrice)) : query;
          
            return query;
        }

        //public static IQueryable<VehiclePriceListItem> BuildPagingOptions(this IQueryable<VehiclePriceListItem> query, FilterVehiclesPriceList filter)
        //{     
        //    return query.Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
        //       .Take(filter.ItemsPrPage);
        //}
    }
}
