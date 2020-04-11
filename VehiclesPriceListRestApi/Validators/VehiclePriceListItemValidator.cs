
using FluentValidation;
using VehiclesPriceListRestApi.Dtos;

namespace VehiclesPriceListRestApi.Validators
{
	public class VehiclePriceListItemValidator : AbstractValidator<VehiclePriceListItemDTO>
	{
		public VehiclePriceListItemValidator()
		{
			RuleFor(x => x.Id).NotNull();
			RuleFor(x => x.AskingPrice).NotEmpty().Length(0, 20);
			RuleFor(x => x.Color).Length(0, 50);
			RuleFor(x => x.EngineType).NotEmpty().Length(0, 10);
			RuleFor(x => x.DateReceived).NotEmpty();
			RuleFor(x => x.TestValidExpiration).NotEmpty();
			RuleFor(x => x.VehicleOwner).NotNull().SetValidator(new VehicleOwnerValidator());
			RuleFor(x => x.VehicleMenufacturer).NotNull().SetValidator(new VehicleMenufacturerValidator());
			RuleFor(x => x.VehicleStatus).NotNull().SetValidator(new VehicleStatusValidator());
			RuleFor(x => x.VehicleType).NotNull().SetValidator(new VehicleTypeValidator());
		}
	}
  
}
