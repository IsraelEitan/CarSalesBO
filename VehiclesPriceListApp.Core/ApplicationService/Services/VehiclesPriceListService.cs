
using System.Collections.Generic;
using System.Threading.Tasks;
using VehiclesPriceListApp.Core.DomainService;
using VehiclesPriceListApp.Core.Entity;


namespace VehiclesPriceListApp.Core.ApplicationService.Services
{
    public class VehiclesPriceListService : AbstractUnitOfWorkService, IVehiclesPriceListService
    {
       
        public VehiclesPriceListService(IUnitOfWork uow) : base(uow)
        {
            
        }
    
        public async Task<int> Add(VehiclePriceListItem item)
        {                
            _unitOfWork.VehiclesPriceList.Add(item);
            await _unitOfWork.Complete();
            return item.Id;
        }

        public async Task<VehiclePriceListItem> Find(int id)
        {
            return await _unitOfWork.VehiclesPriceList.GetById(id);
        }

        public async Task<IEnumerable<VehiclePriceListItem>> GetAll()
        {
            return await _unitOfWork.VehiclesPriceList.GetAll();
        }
    
        public async Task<PagingResponse<VehiclePriceListItem>> GetAllPaging(PagingRequest paging)
        {
            return await _unitOfWork.VehiclesPriceList.GetAllPaging(paging);
        }

        public async Task Update(VehiclePriceListItem vehiclesPriceListItemUpdate)
        {
            _unitOfWork.VehiclesPriceList.Update(vehiclesPriceListItemUpdate);
            await _unitOfWork.Complete();
        }

        public async Task<VehiclePriceListItem> Remove(int id)
        {
           var removedPriceListItem = await _unitOfWork.VehiclesPriceList.Remove(id);
           await _unitOfWork.Complete();

           return removedPriceListItem;
        }

        public int Count()
        {
           return _unitOfWork.VehiclesPriceList.Count();
        }

        public async Task<PriceRange> GetPriceBounds()
        {
            return await _unitOfWork.VehiclesPriceList.GetPriceBounds();
        }
        public async Task<IEnumerable<VehicleMenufacturer>> GetMenufacturers()
        {
            return await _unitOfWork.Menufacturers.GetAll();
        }
        public async Task<IEnumerable<VehicleMenufacturingOrigin>> GetMenufacturingOrigins()
        {
            return await _unitOfWork.MenufactureringOrigin.GetAll();
        }
        public async Task<IEnumerable<VehicleStatus>> GetVehiclesStatus()
        {
            return await _unitOfWork.VehicleStatus.GetAll();
        }
        public async Task<IEnumerable<VehicleType>> GetVehicleTypes()
        {
            return await _unitOfWork.VehicleType.GetAll();
        }
        public async Task<IEnumerable<VehicleOwner>> GetVehicleOwners()
        {
            return await _unitOfWork.VehicleOwners.GetAll();
        }
        public async Task<VehicleOwner> IsItemExist(string emailAddress)
        {
            return await _unitOfWork.VehicleOwners.GetOwnersEmail(emailAddress);
        
        }

    }
}
