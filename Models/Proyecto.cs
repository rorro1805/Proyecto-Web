using System;

namespace Proyecto_Web.Models
{

    public class Proyecto
    {
        public string nombre { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaTermino { get; set; }

        //Constructor vacio
        public Proyecto()
        {

        }

        //Constructor
        public Proyecto(string nombre, DateTime fechaInicio, DateTime fechaTermino)
        {
            this.nombre = nombre;
            this.fechaInicio = fechaInicio;
            this.fechaTermino = fechaTermino;
        }
    }
}