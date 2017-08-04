using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Web.Models.Domain;
using Proyecto_Web.Models.Logica.Controllers;

namespace Proyecto_Web.Controllers
{
    public class ProyectoController : Controller
    {

        private IHostingEnvironment hostingEnv;

        public ProyectoController(IHostingEnvironment env)
        {
            this.hostingEnv = env;
        }

        public IActionResult Index(){

            return Proyectos();
        }


        public IActionResult Proyectos()
        {
            return View();
        }

        public IActionResult FileUpload(Proyecto proyecto){

            System.Console.WriteLine("Entramos al fileUpload ");

            ViewData["proyecto"] = proyecto;
            return View();
        }


        public IActionResult Upload()
        {

            long size = 0;

            var files = Request.Form.Files;
            string idProyectoString = Request.Form["idProyecto"];
            int idProyecto = int.Parse(idProyectoString);

            foreach (var file in files)
            {
                //Creamos un nombre para el archivo
                string result = Path.GetRandomFileName() + Path.GetRandomFileName();
                 
                /* 
                var filename = ContentDispositionHeaderValue
                            .Parse(file.ContentDisposition)
                            .FileName
                            .Trim('"');
                */
                
                var extension = Path.GetExtension(file.FileName);
                var filename = result;

                filename = hostingEnv.WebRootPath + $@"/Uploads/{filename}";
                size += file.Length;
                
                using (FileStream fs = System.IO.File.Create(filename))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }

                //enviamos los datos a la base de datos
                ControladorArchivo cArchivo = new ControladorArchivo();
                Archivo archivo = new Archivo();
                archivo.IdEstado = 1001;
                archivo.Nombre = file.FileName;
                archivo.Ruta = filename;
                archivo.Tipo = extension;
                archivo.IdProyecto = idProyecto;

                cArchivo.Add(archivo);


            }
            string message = $"{files.Count} archivo(s) / {size} bytes cargados exitosamente!";
            return Json(message);

        }

    }
}