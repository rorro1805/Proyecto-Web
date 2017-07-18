using System;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Proyecto_Web.Configuration;
using Proyecto_Web.Models.Domain;
using Proyecto_Web.Models.Persistencia;

namespace Proyecto_Web.Controllers
{
    public class HomeController : Controller
    {
        // Configuracion de la conexion a la base de datos
        private DatabaseConfiguration configuration { get; set; }
        private IHostingEnvironment hostingEnv;

        public HomeController(IOptions<DatabaseConfiguration> configuration, IHostingEnvironment env)
        {
            this.configuration = configuration.Value;
            this.hostingEnv = env;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

    }
}
