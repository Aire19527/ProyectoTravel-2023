﻿using Commnon.Utils.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Travel.Domain.DTO.Library.Autor;
using Travel.Domain.DTO.Library;
using Travel.Domain.DTO;
using Travel.Domain.DTO.Library.Book;
using Travel.Web.Handlers;
using Microsoft.AspNetCore.Hosting;
using Travel.Domain.Services.Travel.Interface;
using Microsoft.AspNetCore.Authorization;
using Commnon.Utils.Enums;

namespace Travel.Web.Controllers
{
    [Authorize]
    [TypeFilter(typeof(CustomExceptionHandler))]
    public class BookController : Controller
    {
        #region Attributes
        private readonly IBookServices _bookServices;
        private readonly IHostingEnvironment _environment;
        #endregion

        #region Builder
        public BookController(IBookServices bookServices, IHostingEnvironment environment)
        {
            _bookServices = bookServices;
            _environment = environment;
        }
        #endregion

        #region Views
        public IActionResult Index()
        {

            return View();
        }
        #endregion

        #region Servicios

        [HttpGet]
        [CustomPermissionFilter(Enums.Permission.ConsultarUsuarios)]
        public IActionResult GetAllBook()
        {
            var result = _bookServices.GetAllBook();
            return Ok(new ResponseDto()
            {
                IsSuccess = true,
                Message = string.Empty,
                Result = result
            });
        }

        [HttpPost]
        public async Task<IActionResult> InsertBook(AddBook_Dto book)
        {
            IActionResult response;

            bool result = await _bookServices.InsertBook(book);
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
        public async Task<IActionResult> UpdateBook(Book_Dto book)
        {
            IActionResult action;
            bool result = await _bookServices.UpdateBook(book);
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

        [HttpPut]
        public async Task<IActionResult> UpdateImageBook(Book_Dto book)
        {
            IActionResult action;
            string result = await _bookServices.UpdateImageBook(book);
            ResponseDto response = new ResponseDto()
            {
                IsSuccess = !string.IsNullOrEmpty(result),
                Message = !string.IsNullOrEmpty(result) ? "Imagen Actualizada satisfatoriamente": "Imagen Actualizada satisfatoriamente",
                Result = result
            };

            if (!string.IsNullOrEmpty(result))
                action = Ok(response);
            else
                action = BadRequest(response);

            return action;
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteBook(int idBook)
        {
            IActionResult action;

            bool result = await _bookServices.DeleteBook(idBook);
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
