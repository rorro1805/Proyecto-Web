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

            string rutIngresado = Request.Form["rut"];
            string password = Request.Form["password"];
            var mensaje="";

            if(rutIngresado.Equals("") || password.Equals(""))
            {
                mensaje = "Campos vacios";
                ViewData["Message"] = mensaje;
                return View();
            }

            int rut = Convert.ToInt32(rutIngresado);
            PersistenciaPersona perPersona = new PersistenciaPersona(this.configuration);
            var userEncontrado = perPersona.find(rut, password);

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
