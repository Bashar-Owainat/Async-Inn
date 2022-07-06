using AsyncInnApp.Models.DTOs;
using AsyncInnApp.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInnApp.Models.Services
{
    public class UserServices : IUser
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private RoleManager<IdentityRole> _roleManager;

        public UserServices(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<UserDTO> Login(LogInDTO logInDTO, ModelStateDictionary modelState)
        {
            var user = await _userManager.FindByNameAsync(logInDTO.UserName);

            if (user == null)
            {
                return null;
            }

            var result = await _signInManager.PasswordSignInAsync(user, logInDTO.Password, false, false);

            if (result.Succeeded)
            {
                return new UserDTO
                {
                    Id = user.Id,
                    Username = user.UserName
                };
            }

            modelState.AddModelError(string.Empty, "Invalid Login");
            return null;
        }

        public async Task<ApplicationUser> Register(RegisterDTO registerDto, ModelStateDictionary modelstate)
        {
            var user = new ApplicationUser
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (result.Succeeded)
            {
                return user;
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    var errorKey =
                        error.Code.Contains("Password") ? nameof(registerDto.Password) :
                        error.Code.Contains("Email") ? nameof(registerDto.Email) :
                        error.Code.Contains("UserName") ? nameof(registerDto.UserName) :
                        "";
                    modelstate.AddModelError(errorKey, error.Description);
                }
                return null;
            }
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
