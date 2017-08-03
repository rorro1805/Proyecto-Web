using System;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using MySqlX.XDevAPI;

namespace Proyecto_Web.Controllers
{
    public class HomeController : Controller
    {
        // Configuracion de la conexion a la base de datos
        private IHostingEnvironment hostingEnv;

        public HomeController()
        {
            
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

        public IActionResult ErrorLogin(string mensaje)
        {
            // se definen variables que avisan que hubo un error
            ViewData["Ingreso"] = "error";
            ViewData["MensajeIngreso"] = mensaje;
            // redirige a la pagina de inicio de sesion
            return View("Index");
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

        public IActionResult Error()
        {
            return new StatusCodeResult(401);
        }

        public IActionResult Register()
        {
            return View();
        }
    }
}
