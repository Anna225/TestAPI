using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAPI.Model;
using TestAPI.Service;

namespace TestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(
            IUserService userService
        )
        {
            _userService = userService;
        }
        [HttpGet("all")]
        public async Task<ActionResult< List<User>>> GetAllUser()
        {
            return await _userService.GetAllUser();
        }

        [HttpGet("female/inactive")]
        public async Task<ActionResult<List<User>>> GetInactiveFemaleUser()
        {
            return await _userService.GetInactiveFemaleUser();
        }

        [HttpPost("search-by-email")]
        public async Task<ActionResult<User>> SearchUserByEmail(SearchUserDto dto)
        {
            var user = await _userService.SearchUserByEmail(dto);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return user;
            }
        }
    }
}
