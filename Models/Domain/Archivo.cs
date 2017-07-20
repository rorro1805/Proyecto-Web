using System;
using System.Collections.Generic;

namespace Proyecto Web
{
    public partial class Archivo
    {
        public int Id { get; set; }
        public int? IdEstado { get; set; }
        public int? IdProyecto { get; set; }
        public string Nombre { get; set; }
        public string Ruta { get; set; }
        public string Tipo { get; set; }

        public virtual Estado IdEstadoNavigation { get; set; }
        public virtual Proyecto IdProyectoNavigation { get; set; }
    }
}
