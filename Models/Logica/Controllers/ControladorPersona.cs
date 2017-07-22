using System.Linq;
using Microsoft.EntityFrameworkCore;
using Proyecto_Web.Data;
using Proyecto_Web.Models.Domain;

namespace Proyecto_Web.Models.Logica.Controllers
{
    public class ControladorPersona
    {
        // contexto base de datos
        private ucn_disc_twa_proyecto_webContext context;

        // Constructor
        public ControladorPersona()
        {
            this.context = new ucn_disc_twa_proyecto_webContext();
        }

        // GET: Persona
        public Persona Find(string rut)
        {
            // consulta a la BD
            return context.Persona.
                    Where(p => p.Rut == rut)
                    .Include(pr => pr.Proyecto)
                    .FirstOrDefault();
        }
    }
}