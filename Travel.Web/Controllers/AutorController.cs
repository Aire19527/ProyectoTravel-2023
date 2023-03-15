using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Infraestructure.Core.Data;
using Infraestructure.Entity.Model;
using Travel.Domain.Services.Interface;
using Travel.Domain.DTO;
using Travel.Domain.DTO.Library;
using Commnon.Utils.Resources;
using Travel.Domain.DTO.Library.Autor;
using Travel.Web.Handlers;

namespace Travel.Web.Controllers
{
    [TypeFilter(typeof(CustomExceptionHandler))]
    public class AutorController : Controller
    {
        private readonly IAutorServices _autoresServices;

        public AutorController(IAutorServices autoresServices)
        {
            _autoresServices = autoresServices;
        }

        // GET: Autor
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult GetAllAutores()
        {
            var result = _autoresServices.GetAllAutores();
            return Ok(new ResponseDto()
            {
                IsSuccess = true,
                Message = string.Empty,
                Result = result
            });
        }

        [HttpPost]
        public async Task<IActionResult> InsertAutor(Autor_DTO autor)
        {
            IActionResult response;

            bool result = await _autoresServices.InsertAutor(autor);
            if (result)
            {
                response = Ok(new ResponseDto()
                {
                    IsSuccess = result,
                    Message = GeneralMessages.ItemInserted,
                    Result = result
                });
            }
            else
            {
                response = BadRequest(new ResponseDto()
                {
                    IsSuccess = result,
                    Message = GeneralMessages.ItemNoInserted,
                    Result = result
                });
            }

            return response;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAutor(ConsultAutor_DTO autor)
        {
            IActionResult action;

            bool result = await _autoresServices.UpdateAutor(autor);
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
        public async Task<IActionResult> DeleteAutor(int idAutor)
        {
            IActionResult action;

            bool result = await _autoresServices.DeleteAutor(idAutor);
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

    }
}
