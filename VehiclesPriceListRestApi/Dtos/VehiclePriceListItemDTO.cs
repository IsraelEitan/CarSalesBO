using System;
using System.ComponentModel.DataAnnotations;

namespace VehiclesPriceListRestApi.Dtos
{
    public class VehiclePriceListItemDTO
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public DateTime DateReceived { get; set; }
        public string AskingPrice { get; set; }
        public DateTime TestValidExpiration { get; set; }
        public string EngineType { get; set; }
        public string EquippingDetails { get; set; }
        public VehicleMenufacturingOriginDto VehicleMenufacturingOrigin { get; set; }
        public VehicleOwnerDTO VehicleOwner { get; set; }
        public VehicleStatusDTO VehicleStatus { get; set; }
        public VehicleMenufacturerDto VehicleMenufacturer { get; set; }
        public VehicleTypeDTO VehicleType { get; set; }
    }
}