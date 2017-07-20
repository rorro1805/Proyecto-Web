using System;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace Proyecto_Web.Controllers
{
    public class HomeController : Controller
    {
        // Configuracion de la conexion a la base de datos
        private IHostingEnvironment hostingEnv;

        public HomeController(IHostingEnvironment env)
        {
            this.hostingEnv = env;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Proyectos()
        {
            return View();
        }

        public IActionResult MisProyectos()
        {
            return View();
        }

        public IActionResult Error()
        {
            ViewData["ingreso"] = "error";
            ViewData["MensajeIngreso"] = "RUT o Contraseña incorrectos";
            return View("Index");
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult fileUpload()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Upload()
        {
            return View();
        }
    }
}
