using Commnon.Utils.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Travel.Domain.DTO.User;
using Travel.Domain.DTO;
using Travel.Domain.Services.Security.Interfaces;
using Travel.Web.Handlers;
using Infraestructure.Entity.Model.Security;
using System.Collections.Generic;
using System.Security.Claims;
using static Commnon.Utils.Constant.Const;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System;
using Microsoft.AspNetCore.Authorization;

namespace Travel.Web.Controllers
{
    [TypeFilter(typeof(CustomExceptionHandler))]
    public class UserController : Controller
    {
        #region Attributes
        private readonly IUserServices _userServices; 
        #endregion

        #region Builder
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }
        #endregion

        #region Views

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        #endregion

        #region Services
        [HttpPost]
        [Route("LoginUser")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginUser(LoginDto login)
        {
            UserEntity user = _userServices.Login(login);

            var claims = new List<Claim>
            {
                new Claim(TypeClaims.IdRol,user.IdRol.ToString()),
                new Claim(TypeClaims.UserName,user.UserName),
                new Claim(TypeClaims.IdUser,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.FullName)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                //AllowRefresh = <bool>,
                // Refreshing the authentication session should be allowed.

                //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes((token.Expiration / 60) - 10),

                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                // The time at which the authentication ticket expires. A 
                // value set here overrides the ExpireTimeSpan option of 
                // CookieAuthenticationOptions set with AddCookie.

                IsPersistent = false,
                // Whether the authentication session is persisted across 
                // multiple requests. When used with cookies, controls
                // whether the cookie's lifetime is absolute (matching the
                // lifetime of the authentication ticket) or session-based.

                //IssuedUtc = <DateTimeOffset>,
                // The time at which the authentication ticket was issued.

                //RedirectUri = <string>
                // The full path or absolute URI to be used as an http 
                // redirect response value.
            };
           
            await HttpContext.SignInAsync(
                  CookieAuthenticationDefaults.AuthenticationScheme,
                                            new ClaimsPrincipal(claimsIdentity),
                                            authProperties);


            ResponseDto response = new ResponseDto()
            {
                IsSuccess = true,
                Result = true,
                Message = string.Empty
            };
            return Ok(response);
        }

        [HttpPost]
        [Route("RegisterUser")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterUser(AddUserDto register)
        {
            IActionResult action;
            bool result = await _userServices.RegisterUser(register);
            ResponseDto response = new ResponseDto()
            {
                IsSuccess = result,
                Result = result,
                Message = result? GeneralMessages.ItemInserted : GeneralMessages.ItemNoInserted
            };

            if (response.IsSuccess)
                action = Ok(response);
            else
                action = BadRequest(response);

            return action;
        }



        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }

        #endregion
    }
}
