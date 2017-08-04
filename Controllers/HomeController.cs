using System;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using MySqlX.XDevAPI;
using Proyecto_Web.Models.Logica.Controllers;
using Proyecto_Web.Models.Domain;

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

        public IActionResult Registro()
        {
            // se obtienen las contraseñas ingresadas
            string passRegistro = Request.Form["contraseña"];
            string passRegistroConf = Request.Form["confirmarContraseña"];

            // si las contraseñas no coinciden
            if (passRegistro != passRegistroConf)
            {
                // verifica error
                ViewData["registro"] = "error";
                ViewData["mensajeRegistro"] = "Contraseñas no coinciden";
                return View("Register");
            }
            // se obtiene el rut ingresado
            string rutRegistro = Request.Form["rut"];
            // se crea una nuevo contralador de la persona
            ControladorPersona contrPersona = new ControladorPersona();
            // se busca el rut ingresado
            Persona personaBuscada = contrPersona.Find(rutRegistro);
            // si la persona ya existe
            if(personaBuscada != null)
            {
                // verifica error
                ViewData["registro"] = "error";
                ViewData["mensajeRegistro"] = "El RUT ya existe";
                return View("Register");
            }
            // se obtienen los datos restantes
            string nombreRegistro = Request.Form["nombre"];
            string emailRegistro = Request.Form["email"];
            string adminRegistro = Request.Form["admin"];
            string paternoRegistro = Request.Form["paterno"];
            string maternoRegistro = Request.Form["materno"];

            // se crea una nueva persona
            Persona nuevoUser = new Persona(rutRegistro, nombreRegistro, paternoRegistro, maternoRegistro,
                                            emailRegistro, "2000-06-04", passRegistro, false);
            // se almacena la persona en la BD
            contrPersona.Save(nuevoUser);

            return View("Index");
        }
    }
}
