using System.Linq;
using Microsoft.EntityFrameworkCore;
using Proyecto_Web.Data;
using Proyecto_Web.Models.Domain;

namespace Proyecto_Web.Models.Logica.Controllers
{
    public class ControladorProyecto
    {
        // contexto base de datos
        private ucn_disc_twa_proyecto_webContext context;

        // constructor
        public ControladorProyecto()
        {

        }


		// GET: Proyecto
		public Proyecto Find(int id)
		{
			this.context = new ucn_disc_twa_proyecto_webContext();
			this.context.Database.OpenConnection();

			// consulta a la BD
			Proyecto proyecto = this.context.Proyecto
			.Where(p => p.Id == id)
			.Include(ar => ar.Archivo)
			.ToList()
			.FirstOrDefault();
			this.context.Dispose();

			return proyecto;

		}
    }
}