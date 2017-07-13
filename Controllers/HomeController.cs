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
        private DatabaseConfiguration configuration { get; set; }
        private IHostingEnvironment hostingEnv;

        public HomeController(IOptions<DatabaseConfiguration> configuration, IHostingEnvironment env)
        {
            this.configuration = configuration.Value;
            this.hostingEnv = env;
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
    }
}
