using VehiclesPriceListApp.Core.DomainService;

namespace VehiclesPriceListApp.Core.ApplicationService.Services
{
    public abstract class AbstractUnitOfWorkService
    {
        protected IUnitOfWork _unitOfWork;

        public AbstractUnitOfWorkService(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }
    }
}
