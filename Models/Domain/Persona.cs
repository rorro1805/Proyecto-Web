using System;
using System.Collections.Generic;

namespace Proyecto Web
{
    public partial class Persona
    {
        public Persona()
        {
            Proyecto = new HashSet<Proyecto>();
        }

        public string Rut { get; set; }
        public sbyte? Admin { get; set; }
        public string Email { get; set; }
        public string FechaNacimiento { get; set; }
        public string Materno { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public string Paterno { get; set; }

        public virtual ICollection<Proyecto> Proyecto { get; set; }
    }
}
