using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KoohTajrobe.Business.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KoohTajrobe.Business;
using KoohTajrobe.Business.Interfaces;
using KoohTajrobe.Model.User;
using Microsoft.AspNetCore.Identity;

namespace KoohTajrobe.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        public RegisterDto RegisterDto { get; set; }

         

        private IAuthenticationBusiness _authenticationBusiness;
        public AuthenticationController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _authenticationBusiness = new AuthenticationBusiness(userManager, signInManager);
        }
        [Route("Register")]
        [HttpPut]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            try
            {
                await _authenticationBusiness.Register(registerDto);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            try
            {
                await _authenticationBusiness.Login(loginDto);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        [Route("logout")]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _authenticationBusiness.Logout();
            return Ok();
        }
    }
}