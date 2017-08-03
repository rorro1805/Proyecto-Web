using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult FileUpload(){
            System.Console.WriteLine("Entramos al fileUpload ");

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