using System;
using System.Collections.Generic;

namespace Proyecto Web
{
    public partial class Estado
    {
        public Estado()
        {
            Archivo = new HashSet<Archivo>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Archivo> Archivo { get; set; }
    }
}
