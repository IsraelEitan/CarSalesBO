using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehiclesPriceListApp.Core.Entity
{
    public class VehiclePriceListItem
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Color { get; set; }
        public DateTime DateReceived { get; set; }
        public string AskingPrice { get; set; }
        public DateTime TestValidExpiration { get; set; }
        public string EngineType { get; set; }
        public string EquippingDetails { get; set; }

        public int VehicleMenufacturingOriginId { get; set; }
        public  VehicleMenufacturingOrigin VehicleMenufacturingOrigin { get; set; }
        public int VehicleOwnerId { get; set; }
        public  VehicleOwner VehicleOwner { get; set; }
        public int VehicleStatusId { get; set; }
        public  VehicleStatus VehicleStatus { get; set; }
        public int VehicleMenufacturerId { get; set; }
        public  VehicleMenufacturer VehicleMenufacturer { get; set; }
        public int VehicleTypeId { get; set; }
        public  VehicleType VehicleType { get; set; }
    }
}
