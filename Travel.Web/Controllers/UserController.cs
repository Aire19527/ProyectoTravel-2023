using Commnon.Utils.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Travel.Domain.DTO.User;
using Travel.Domain.DTO;
using Travel.Domain.Services.Security.Interfaces;

namespace Travel.Web.Controllers
{
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
        public IActionResult Index()
        {
            return View();
        }
        #endregion

        #region Services
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginDto login)
        {
            bool result = _userServices.Login(login);
            ResponseDto response = new ResponseDto()
            {
                IsSuccess = result,
                Result = result,
                Message = string.Empty
            };

            return Ok(response);
        }

        [HttpPost]
        [Route("RegisterUser")]
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

        #endregion
    }
}
