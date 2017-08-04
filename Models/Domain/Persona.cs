using System;
using System.Collections.Generic;

namespace Proyecto_Web.Models.Domain
{
    public partial class Persona
    {
        public Persona()
        {
            Proyecto = new HashSet<Proyecto>();
            Trabajadores = new HashSet<Trabajadores>();
        }

        public string Rut { get; set; }
        public bool Admin { get; set; }
        public string Email { get; set; }
        public string FechaNacimiento { get; set; }
        public string Materno { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public string Paterno { get; set; }

        public virtual ICollection<Proyecto> Proyecto { get; set; }
        public virtual ICollection<Trabajadores> Trabajadores { get; set; }

        public Persona(string Rut, string Nombre, string Paterno, string Materno, string Email,
                        string FechaNacimiento, string Password, bool Admin)
        {
            this.Rut = Rut;
            this.Nombre = Nombre;
            this.Paterno = Paterno;
            this.Materno = Materno;
            this.Email = Email;
            this.FechaNacimiento = FechaNacimiento;
            this.Admin = Admin;
        }
    }
}
