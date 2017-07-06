using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Proyecto_Web.Configuration;
using Dapper;
using Proyecto_Web.Models.Logica;
using Microsoft.AspNetCore.Http;
using Proyecto_Web.Models.Persistencia;

namespace Proyecto_Web.Controllers
{
    public class HomeController : Controller
    {
        private DatabaseConfiguration configuration { get; set; }

        public HomeController(IOptions<DatabaseConfiguration> configuration)
        {
            this.configuration = configuration.Value;
        }

        public IActionResult Index()
        {
            /* 
            using (var conexion = new SqlConnection(_configuration.Default))
            {
                var personas = conexion.Query<Persona>("SELECT * FROM persona");
                return View(personas);
            }*/
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {

            var usuario = Request.Form["username"];
            var password = Request.Form["password"];

            PersistenciaPersona perPersona = new PersistenciaPersona(this.configuration);
            var userEncontrado = perPersona.find(usuario, password);

            var mensaje="";
            if (userEncontrado.Count() == 0)
            {
                mensaje = "Login Incorrecto";
                ViewData["Message"] = mensaje;
                return View();
            }
            else
            {
                mensaje = "Persona:";
                ViewData["Message"] = mensaje;
                Persona personaEncontrada = userEncontrado.FirstOrDefault();
                ViewData["personaEncontrada"] = personaEncontrada;
                return View();
            }
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
