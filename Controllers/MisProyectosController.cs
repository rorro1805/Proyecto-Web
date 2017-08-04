using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Web.Models.Domain;
using Proyecto_Web.Models.Logica.Controllers;

namespace Proyecto_Web.Controllers
{
    public class MisProyectosController : Controller
    {

        private IHostingEnvironment hostingEnv;

        public MisProyectosController(IHostingEnvironment env)
        {
            this.hostingEnv = env;
        }

        [HttpPost]
        public IActionResult MisProyectos()
        {

            // recepcion de credenciales ingresadas en el formulario
            string rutIngresado = Request.Form["rut"];
            string passwordIngresado = Request.Form["password"];

            // controlador de la clase persona
            var controladorPersona = new ControladorPersona();
            // se busca a la persona en la base de datos a traves del DbContext
            Persona personaEncontrada = controladorPersona.Find(rutIngresado);
            string mensajeError;
            // si el rut se encontro
            if (personaEncontrada != null)
            {
                // si el password ingresado coincide con el de la BD
                if (personaEncontrada.Password.Equals(passwordIngresado))
                {
                    // controlador de la clase Proyecto
                    var controladorProyecto = new ControladorProyecto();
                    // por cada trabajo de la persona
                    foreach(Trabajadores trabajo in personaEncontrada.Trabajadores)
                    {
                        // busco un proyecto segun su id en el trabajo
                        Proyecto proyEncontrado = controladorProyecto.Find(trabajo.IdProyecto);
                        // se agrega el proyecto a la lista de proyectos de la persona
                        personaEncontrada.Proyecto.Add(proyEncontrado);
                    }
                    // se envia a la persona encontrada
                    ViewData["PersonaEncontrada"] = personaEncontrada;
                    return View();
                }
                else
                {
                    // CONTRASEÑA INCORRECTA
                    // se envia un mensaje de error
                    mensajeError = "Contraseña incorrecta";
                    ViewData["MensajeError"] = mensajeError;

                    // redirige al action Error del controlador Home con parametro
                    return RedirectToAction("ErrorLogin", "Home", new { mensaje = mensajeError });
                }
            }
            else
            {
                // NO SE ENCONTRO EL RUT
                // se envia un mensaje de error
                mensajeError = "Usuario no encontrado";
                ViewData["MensajeError"] = mensajeError;

                // redirige al action Error del controlador Home con parametro
                return RedirectToAction("ErrorLogin", "Home", new { mensaje = mensajeError });
            }
        }

		public IActionResult Proyectos(int id)
		{
            //Buscamos el proyecto correspondiente.
            var controladorProyecto = new ControladorProyecto();
            Proyecto proyecto = controladorProyecto.Find(id);


            ViewData["proyecto"] = proyecto;
			return View();
		}

    }
}
