using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehiclesPriceListRestApi.Dtos;

namespace VehiclesPriceListRestApi.Validators
{
    public class VehicleTypeValidator : AbstractValidator<VehicleTypeDTO>
	{
		public VehicleTypeValidator()
		{
			RuleFor(x => x.Id).NotNull();
		}
	}
}
