using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Infraestructure.Core.Data;
using Infraestructure.Entity.Model;
using Travel.Domain.DTO;
using Travel.Domain.Services;
using Commnon.Utils.Resources;
using Travel.Domain.DTO.Library.Autor;
using Travel.Domain.DTO.Library;
using Travel.Domain.DTO.Library.Editorial;
using Travel.Web.Handlers;
using Travel.Domain.Services.Travel.Interface;
using Microsoft.AspNetCore.Authorization;

namespace Travel.Web.Controllers
{
    [Authorize]
    [TypeFilter(typeof(CustomExceptionHandler))]
    public class EditorialController : Controller
    {
        #region Attributes
        private readonly IEditorialServices _editorialServices;
        #endregion

        #region Builder
        public EditorialController(IEditorialServices editorialServices)
        {
            _editorialServices = editorialServices;
        }
        #endregion

        #region View
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        #endregion

        #region Services

        [HttpGet]
        public IActionResult GetAllEditorial()
        {
            List<Editorial_Dto> result = _editorialServices.GetAllEditorial();
            return Ok(new ResponseDto()
            {
                IsSuccess = true,
                Message = string.Empty,
                Result = result
            });
        }

        [HttpPost]
        public async Task<IActionResult> InsertEditorial(AddEditorial_Dto editorial)
        {
            IActionResult action;

            bool result = await _editorialServices.InsertEditorial(editorial);
            ResponseDto response = new ResponseDto()
            {
                IsSuccess = result,
                Message = result ? GeneralMessages.ItemInserted : GeneralMessages.ItemNoInserted,
                Result = result
            };

            if (result)
                action = Ok(response);
            else
                action = BadRequest(response);

            return action;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEditorial(Editorial_Dto edit)
        {
            IActionResult action;

            bool result = await _editorialServices.UpdateEditorial(edit);
            ResponseDto response = new ResponseDto()
            {
                IsSuccess = result,
                Message = result ? GeneralMessages.ItemUpdated : GeneralMessages.ItemNoUpdated,
                Result = result
            };

            if (result)
                action = Ok(response);
            else
                action = BadRequest(response);

            return action;
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteEditorial(int idEditorial)
        {
            IActionResult action;

            bool result = await _editorialServices.DeleteEditorial(idEditorial);
            ResponseDto response = new ResponseDto()
            {
                IsSuccess = result,
                Message = result ? GeneralMessages.ItemDeleted : GeneralMessages.ItemNoDeleted,
                Result = result
            };

            if (result)
                action = Ok(response);
            else
                action = BadRequest(response);

            return action;
        }


        #endregion



    }
}
