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
using System.Net.Http.Headers;
using Proyecto_Web.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

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

<<<<<<< HEAD
        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Proyectos(){

            var nombreProyecto = "Proyecto1";
            string[] archivos = {"Archivo1", "Archivo2", "Archivo3", "Archivo4", "Archivosdfxgh", "Archivosdfgh"};

            ViewData["archivos"] = archivos;
            ViewData["nombreProyecto"] = nombreProyecto;
            
            return View();
        }

        public IActionResult fileUpload(){
            System.Console.WriteLine("Entramos al fileUpload ");
            return View();
        }


        [HttpPost]
        public IActionResult Upload(){

            long size = 0;

            var files = Request.Form.Files;
            foreach (var file in files)
            {
                var filename = ContentDispositionHeaderValue
                            .Parse(file.ContentDisposition)
                            .FileName
                            .Trim('"');
                filename = hostingEnv.WebRootPath + $@"/Uploads/{filename}";
                size += file.Length;
                using (FileStream fs = System.IO.File.Create(filename))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
            }
            string message = $"{files.Count} archivo(s) / {size} bytes cargados exitosamente!";
            return Json(message);

        }
=======
>>>>>>> cee00f0bf22f1da4c55a9c4f2fb2a7e933591070
    }
}
