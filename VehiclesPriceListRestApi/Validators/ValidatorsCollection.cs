using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehiclesPriceListRestApi.Validators
{
    public class ValidatorsCollection
    {
        public VehicleMenufacturerValidator MenufacturerValidator { get;}
        public VehicleMenufacturingOriginValidator MenufacturingOriginValidator { get; }
        public VehicleOwnerValidator OwnerValidator { get; }
        public VehiclePriceListItemValidator PriceListItemValidator { get; }
        public VehicleStatusValidator StatusValidator { get; }
        public VehicleTypeValidator TypeValidator { get; }
    }
}
