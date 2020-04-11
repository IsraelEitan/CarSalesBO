using VehiclesPriceListRestApi.Dtos;
using FluentValidation;

namespace VehiclesPriceListRestApi.Validators
{
    public class VehicleMenufacturerValidator : AbstractValidator<VehicleMenufacturerDto>
	{
		public VehicleMenufacturerValidator()
		{
			RuleFor(x => x.Id).NotNull();
		}
	}
}
