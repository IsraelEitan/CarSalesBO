using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehiclesPriceListRestApi.Dtos;

namespace VehiclesPriceListRestApi.Validators
{
	public class VehicleOwnerValidator : AbstractValidator<VehicleOwnerDTO>
	{
		public VehicleOwnerValidator()
		{
			RuleFor(x => x.Id).NotNull();
			RuleFor(x => x.FirstName).NotEmpty().Length(0, 50);
			RuleFor(x => x.LastName).Length(0, 50);
			RuleFor(x => x.Telephone).NotEmpty().Length(0, 50);
			RuleFor(x => x.EmailAddress).EmailAddress();
		}
	}
}