using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Proyecto_Web.Configuration;
using Proyecto_Web.Models.Domain;
using Proyecto_Web.Models.Persistencia;

namespace Proyecto_Web.Controllers
{
    public class MisProyectosController : Controller
    {
        // Configuracion de la conexion a la base de datos
        private DatabaseConfiguration configuration { get; set; }
        private IHostingEnvironment hostingEnv;

        public MisProyectosController(IOptions<DatabaseConfiguration> configuration, IHostingEnvironment env)
        {
            this.configuration = configuration.Value;
            this.hostingEnv = env;
        }
    

        public IActionResult Index()
        {
            return MisProyectos();
        }

        public IActionResult MisProyectos()
        {

            // recepcion de datos desde el formulario
            string rutIngresado = Request.Form["rut"];
            string password = Request.Form["password"];

            int rut;
            // conversion del rut ingresado
            try
            {
                rut = Convert.ToInt32(rutIngresado);
            }
            catch (Exception ex)
            {
                
                ViewData["ingreso"] = "error";
                ViewData["MensajeIngreso"] = "Formato de RUT inválido";
                return View("Index");
            }
            // se instancia la persistencia persona
            PersistenciaPersona perPersona = new PersistenciaPersona(this.configuration);
            // se busca al usuario en la base de datos segun credenciales ingresadas
            Persona userEncontrado = perPersona.Find(rut, password);

            // si no se encontro el usuario
            if (userEncontrado == null)
            {
                ViewData["ingreso"] = "error";
                ViewData["MensajeIngreso"] = "RUT o Contraseña incorrectos";
                return View("Index");
            }
            else
            {
                ViewData["personaEncontrada"] = userEncontrado;
                return View("MisProyectos");
            }
        }

    }
}