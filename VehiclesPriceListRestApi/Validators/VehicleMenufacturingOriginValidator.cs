using VehiclesPriceListRestApi.Dtos;
using FluentValidation;

namespace VehiclesPriceListRestApi.Validators
{
    public class VehicleMenufacturingOriginValidator : AbstractValidator<VehicleMenufacturingOriginDto>
	{
		public VehicleMenufacturingOriginValidator()
		{
			RuleFor(x => x.Id).NotNull();
		}
	}
}
