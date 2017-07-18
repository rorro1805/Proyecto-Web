using System;

namespace Proyecto_Web.Models.Domain
{

    public class Persona
    {

        public string Rut { get; set; }
        public string Nombre { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string FechaNacimiento { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Boolean Admin { get; set; }

        public Persona()
        {
            
        }

        //Constructor 
        public Persona(string Rut, string Nombre, string Paterno, string Materno, string FechaNacimiento,
                        string Password, string Email, Boolean Admin)
        {
            this.Rut = Rut;
            this.Nombre = Nombre;
            this.Materno = Materno;
            this.Paterno = Paterno;
            this.FechaNacimiento = FechaNacimiento;
            this.Password = Password;
            this.Email = Email;
            this.Admin = Admin;
        }

    }
}