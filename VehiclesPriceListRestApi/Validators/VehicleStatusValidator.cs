using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehiclesPriceListRestApi.Dtos;

namespace VehiclesPriceListRestApi.Validators
{
    public class VehicleStatusValidator : AbstractValidator<VehicleStatusDTO>
	{
		public VehicleStatusValidator()
		{
			RuleFor(x => x.Id).NotNull();
		}
	}
}
