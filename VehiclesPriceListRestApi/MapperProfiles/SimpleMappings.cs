using AutoMapper;
using VehiclesPriceListRestApi.Dtos;
using VehiclesPriceListApp.Core.Entity;

namespace VehiclesPriceListRestApi.MapperProfiles
{
    public class SimpleMappings : Profile
    {
        public SimpleMappings()
        {
            CreateMap<VehiclePriceListItem, VehiclePriceListItemDTO>();   
            CreateMap<VehicleMenufacturingOrigin, VehicleMenufacturingOriginDto>();
            CreateMap<VehicleOwner, VehicleOwnerDTO>();
            CreateMap<VehicleStatus, VehicleStatusDTO>();
            CreateMap<VehicleMenufacturer, VehicleMenufacturerDto>();
            CreateMap<VehicleType, VehicleTypeDTO>();

            CreateMap<PagingResponse<VehiclePriceListItem>, PagingResponse<VehiclePriceListItemDTO>>();

            CreateMap<VehiclePriceListItemDTO, VehiclePriceListItem>()
             .ForMember(dest => dest.VehicleMenufacturerId, opt => opt.MapFrom(src => src.VehicleMenufacturer.Id))
             .ForMember(dest => dest.VehicleMenufacturingOriginId, opt => opt.MapFrom(src => src.VehicleMenufacturingOrigin.Id))
             .ForMember(dest => dest.VehicleStatusId, opt => opt.MapFrom(src => src.VehicleStatus.Id))
             .ForMember(dest => dest.VehicleTypeId, opt => opt.MapFrom(src => src.VehicleType.Id));

            CreateMap<VehicleMenufacturingOriginDto, VehicleMenufacturingOrigin>();
            CreateMap<VehicleOwnerDTO, VehicleOwner>();
            CreateMap<VehicleStatusDTO, VehicleStatus>();
            CreateMap<VehicleMenufacturerDto, VehicleMenufacturer>();
            CreateMap<VehicleTypeDTO, VehicleType>();
        }
    }
}
