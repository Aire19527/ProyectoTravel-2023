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

namespace Travel.Web.Controllers
{
    public class AutorController : Controller
    {
        private readonly IAutoresServices _autoresServices;

        public AutorController(IAutoresServices autoresServices)
        {
            _autoresServices = autoresServices;
        }

        // GET: Autor
        public IActionResult Index()
        {
            return View(_autoresServices.GetAllAutores());
        }

      
    }
}
