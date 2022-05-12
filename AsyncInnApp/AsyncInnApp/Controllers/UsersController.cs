using AsyncInnApp.Models.DTOs;
using AsyncInnApp.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInnApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUser _user;

        public UsersController(IUser user)
        {
            _user = user;
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(LogInDTO data)
        {
            try
            {
                var result = await _user.Login(data, this.ModelState);
                if (result == null)
                {
                    return BadRequest("Username or password is wrong!");
                }

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(data);

        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterDTO data)
        {
            try
            {
                await _user.Register(data, this.ModelState);
                if (ModelState.IsValid)
                {
                    return Ok("Registered done");

                }
                return BadRequest(new ValidationProblemDetails(ModelState));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpGet("Login")]
        public async Task<ActionResult> Login()
        {
            return Ok("Login Page");
        }
    }
}
