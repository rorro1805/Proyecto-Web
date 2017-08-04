using System.Linq;
using Microsoft.EntityFrameworkCore;
using Proyecto_Web.Data;
using Proyecto_Web.Models.Domain;

namespace Proyecto_Web.Models.Logica.Controllers
{
    public class ControladorArchivo
    {
        // contexto base de datos
        private ucn_disc_twa_proyecto_webContext context;

        // Constructor
        public ControladorArchivo()
        {
            
        }


        public void Add(Archivo archivo)
        {
            this.context = new ucn_disc_twa_proyecto_webContext();

            this.context.Database.OpenConnection();

            // consulta a la BD
            try{
                this.context.Archivo.Add(archivo);  
                this.context.Dispose();
            }catch{

            }
                    
        }
    }
}