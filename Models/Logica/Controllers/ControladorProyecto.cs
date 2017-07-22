
using Proyecto_Web.Data;

namespace Proyecto_Web.Models.Logica.Controllers
{
    public class ControladorProyecto
    {
        // contexto base de datos
        private ucn_disc_twa_proyecto_webContext context;

        // constructor
        public ControladorProyecto()
        {
            this.context = new ucn_disc_twa_proyecto_webContext();
        }
    }
}