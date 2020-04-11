using System;
using System.Collections.Generic;
using VehiclesPriceListApp.Core.ApplicationService;
using VehiclesPriceListApp.Core.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CustomerRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        
        // GET api/orders -- READ All
        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get([FromQuery] FilterVehiclesPriceList filter)
        {
            try
            {
                return Ok(_userService.GetAllUsers(filter));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}