using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Proyecto_Web.Models;
using Proyecto_Web.Models.Domain;

namespace Proyecto_Web.Controllers
{
    public class MisProyectosController : Controller
    {

        private IHostingEnvironment hostingEnv;

        public MisProyectosController(IHostingEnvironment env)
        {
            this.hostingEnv = env;
        }


        public IActionResult Index()
        {
            return MisProyectos();
        }

        public IActionResult MisProyectos()
        {
            return View("MisProyectos");
        }
    }

}