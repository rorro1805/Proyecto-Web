using System.Collections.Generic;
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
    public class ProyectoController : Controller
    {

        // Configuracion de la conexion a la base de datos
        private DatabaseConfiguration configuration { get; set; }
        private IHostingEnvironment hostingEnv;

        public ProyectoController(IOptions<DatabaseConfiguration> configuration, IHostingEnvironment env)
        {
            this.configuration = configuration.Value;
            this.hostingEnv = env;
        }

        public IActionResult Index(){

            return Proyectos();
        }


        public IActionResult Proyectos()
        {
            int idProyecto = 3001;

            //creamos la persistencia para ir a consultar por los proyectos
            PersistenciaProyecto perProyecto = new PersistenciaProyecto(this.configuration);

            Proyecto proyecto = perProyecto.Find(idProyecto);

            // si no se encontro el proyecto
            if (proyecto == null)
            {
            
                ViewData["MensajeIngreso"] = "No existe el proyecto indicado";
                return View("MisProyectos");
            }
            else
            {
                //existe el proyecto. Cargamos su lista de archivos y la enviamos.
                //creamos la persistencia para consultar por los archivos
                PersistenciaArchivo perArchivo = new PersistenciaArchivo(this.configuration);
                List<Archivo> listaArchivos = perArchivo.FindForProyect(idProyecto);

                proyecto.ListaArchivos = listaArchivos;

                ViewData["proyecto"] = proyecto;
                return View("Proyectos");
            }

        }

        public IActionResult FileUpload(){
            System.Console.WriteLine("Entramos al fileUpload ");

            ViewData["idProyect"] = 3001;
            return View();
        }


        public IActionResult Upload()
        {

            long size = 0;

            var files = Request.Form.Files;
            string idProyect = Request.Form["idProyect"];
            foreach (var file in files)
            {
                //Creamos un nombre para el archivo
                string result = Path.GetRandomFileName();
                var filename = ContentDispositionHeaderValue
                            .Parse(file.ContentDisposition)
                            .FileName
                            .Trim('"');
                
                var extension = filename.Substring((filename.Length - 5),5);
                
                filename = result + "." + extension;

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