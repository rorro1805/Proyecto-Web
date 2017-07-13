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
        // Configuracion de la conexion a la base de datos
        private DatabaseConfiguration configuration { get; set; }

        public HomeController(IOptions<DatabaseConfiguration> configuration)
        {
            this.configuration = configuration.Value;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Proyectos()
        {

            var nombreProyecto = "Proyecto1";
            string[] archivos = { "Archivo1", "Archivo2", "Archivo3", "Archivo4", "Archivosdfxgh", "Archivosdfgh" };

            ViewData["archivos"] = archivos;
            ViewData["nombreProyecto"] = nombreProyecto;

            return View();
        }

        public IActionResult Upload()
        {


            return View();
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
            Persona userEncontrado = perPersona.find(rut, password);

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
                return View();
            }
        }

    }
}
