using System;

namespace Proyecto_Web.Models
{

    public class Persona
    {

        public string rut { get; set; }
        public string nombre { get; set; }
        public string paterno { get; set; }
        public string materno { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public bool admin { get; set; }
        public Proyecto[] proyectos;

        //Constructor vacio
        public Persona()
        {

        }

        //Constructor 
        public Persona(string rut, string nombre, string materno, DateTime fechaNacimiento,
                        string password, string email, bool admin)
        {
            this.rut = rut;
            this.nombre = nombre;
            this.materno = materno;
            this.fechaNacimiento = fechaNacimiento;
            this.password = password;
            this.email = email;
            this.admin = admin;
            this.proyectos = new Proyecto[3];
        }

        public Boolean agregarProyecto(Proyecto newProyecto){

            //verificamos la cantidad de proyectos
            int i = 0;
            while(i < 3 && this.proyectos[i] != null){
                i++;
            }

            if( i == 3)
            {
                //tiene todos los proyectos
                return false;
            }else{
                //agregamos el proyecto
                this.proyectos[i] = newProyecto;
                return true;
            }
        }

    }
}