using AsyncInnApp.Models.DTOs;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInnApp.Models.Interfaces
{
   public interface IUser
    {
         Task<ApplicationUser> Register(RegisterDTO registerDto, ModelStateDictionary modelstate);
        public Task<UserDTO> Login(LogInDTO logInDTO, ModelStateDictionary modelState);
    }
}
