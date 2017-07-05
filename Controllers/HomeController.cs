using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Proyecto_Web.Configuration;
using Dapper;
using Proyecto_Web.Models;
using Microsoft.AspNetCore.Http;

namespace Proyecto_Web.Controllers
{
    public class HomeController : Controller
    {
        private DatabaseConfiguration _configuration { get; set; }

        public HomeController(IOptions<DatabaseConfiguration> configuration)
        {
            _configuration = configuration.Value;
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

            var conexion = new SqlConnection(_configuration.Default);
            var userEncontrado = conexion.Query<Persona>("SELECT * FROM persona WHERE nombre='" + usuario +
                                                            "' AND password='" + password + "';");
            var mensaje = "Login Exitoso";
            if (userEncontrado.Count() == 0)
            {
                mensaje = "Login Incorrecto";
            }
            ViewData["Message"] = mensaje;

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
