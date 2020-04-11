using System;
using VehiclesPriceListApp.Core.ApplicationService;
using VehiclesPriceListApp.Core.Entity;
using VehiclesPriceListRestApi.Dtos;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VehiclesPriceListRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesPriceListController : ControllerBase
    {
        private readonly IVehiclesPriceListService _vehiclesPriceListService;
        private readonly IMapper _mapper;

        public VehiclesPriceListController(IVehiclesPriceListService vehiclesPriceListService, IMapper mapper)
        {
            _vehiclesPriceListService = vehiclesPriceListService;

            _mapper = mapper;
        }
      
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<VehiclePriceListItemDTO>>> GetAll()
        {
            try
            {             
                var vehiclePriceList = await _vehiclesPriceListService.GetAll();

                var vehiclePriceListDto = _mapper.Map<IEnumerable<VehiclePriceListItem>, IEnumerable<VehiclePriceListItemDTO>>(vehiclePriceList);

                return Ok(vehiclePriceListDto);              
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
     
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<VehiclePriceListItemDTO>> GetByID(int id)
        {
            if (id < 1) return BadRequest("Id must be greater then 0");

            try
            {
                var vehiclesPriceListItem = await _vehiclesPriceListService.Find(id);

                return Ok(_mapper.Map<VehiclePriceListItem, VehiclePriceListItemDTO>(vehiclesPriceListItem));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<object>> GetMiscellaneousData()
        {
            try
            {
                var menufacturers = await _vehiclesPriceListService.GetMenufacturers();
                var menufactureringOrigin = await _vehiclesPriceListService.GetMenufacturingOrigins();
                var vehicleStatus = await _vehiclesPriceListService.GetVehiclesStatus();
                var vehicleTypes = await _vehiclesPriceListService.GetVehicleTypes();
                var priceBounds = await _vehiclesPriceListService.GetPriceBounds();

                return Ok(new
                {
                    menufacturers = _mapper.Map<IEnumerable<VehicleMenufacturer>, IEnumerable<VehicleMenufacturerDto>>(menufacturers),
                    menufacturingOrigin = _mapper.Map<IEnumerable<VehicleMenufacturingOrigin>, IEnumerable<VehicleMenufacturingOriginDto>>(menufactureringOrigin),
                    vehicleTypes = _mapper.Map<IEnumerable<VehicleType>, IEnumerable<VehicleTypeDTO>>(vehicleTypes),
                    vehicleStatus = _mapper.Map<IEnumerable<VehicleStatus>, IEnumerable<VehicleStatusDTO>>(vehicleStatus),
                    priceBounds
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<int>> AddVehiclePriceListItem([FromBody] VehiclePriceListItemDTO item)
        {         
       
            var existingPerson = await _vehiclesPriceListService.IsItemExist(item.VehicleOwner.EmailAddress);

            if (existingPerson != null)
            {
                ModelState.AddModelError("emailAddress", "This email already exists");
                return BadRequest(ModelState);
            }

            try
            {
                var newItemId = await _vehiclesPriceListService.Add(_mapper.Map<VehiclePriceListItemDTO, VehiclePriceListItem>(item));
                return Ok(newItemId);
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }          

        }

        [HttpGet("[action]")]
        public async Task<ActionResult<PagingResponse<VehiclePriceListItemDTO>>> GetPaging([FromQuery] PagingRequest req )
        {
            PagingResponse<VehiclePriceListItem> pagingResponse = null;
            
            try
            {
                pagingResponse = await _vehiclesPriceListService.GetAllPaging(req);
                var pagingResponseDto = _mapper.Map<PagingResponse<VehiclePriceListItem>, PagingResponse<VehiclePriceListItemDTO>>(pagingResponse);
                return Ok(pagingResponseDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }      
        }

        [HttpPut("[action]")]
        public async Task<ActionResult> UpdateVehiclePriceListItem([FromBody] VehiclePriceListItemDTO item)
        { 
            try
            {
                await _vehiclesPriceListService.Update(_mapper.Map<VehiclePriceListItemDTO, VehiclePriceListItem>(item));
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            } 
        }
      
        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult<VehiclePriceListItem>> DeleteVehiclePriceListItem(int id)
        {
            VehiclePriceListItem vehiclePriceListItem = null;

            try
            {
                vehiclePriceListItem = await _vehiclesPriceListService.Remove(id);

                if (vehiclePriceListItem == null)
                {
                    return StatusCode(404, new { message = "Did not find Vehicle with ID " + id, obj = vehiclePriceListItem }) ;
                }

                return Ok(vehiclePriceListItem);
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { message = ex.Message, obj = vehiclePriceListItem });
            }
        }
    }
}
