using Proyecto_Web.Data;

namespace Proyecto_Web.Models.Logica.Controllers
{
    public class ControladorTrabajadores
    {
        // contexto database
        private ucn_disc_twa_proyecto_webContext context;

        // constructor
        public ControladorTrabajadores()
        {
            this.context = new ucn_disc_twa_proyecto_webContext();
        }

    }
}