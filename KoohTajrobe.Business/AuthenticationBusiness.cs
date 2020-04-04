using System;
using System.Threading.Tasks;
using KoohTajrobe.Business.Dto;
using KoohTajrobe.Business.Interfaces;
using KoohTajrobe.Model.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KoohTajrobe.Business
{
    public class AuthenticationBusiness : IAuthenticationBusiness
    {

        private SignInManager<User> _signInManager;
        private UserManager<User> _userManager;



        public AuthenticationBusiness(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }


        public async Task Register(RegisterDto registerDto)
        {
            
                var user = new User{UserName = registerDto.UserName,PhoneNumber = registerDto.PhoneNumber};
                var result = await _userManager.CreateAsync(user, registerDto.Password);

            
        }

        public async Task Login(LoginDto loginDto)
        {
            await _signInManager.PasswordSignInAsync(loginDto.UserName, loginDto.Password, false, false);
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();

        }
    }
}