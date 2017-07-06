using System;
using System.Collections.Generic;

namespace Proyecto_Web.Models
{

    public class Proyecto
    {
        public string nombre { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaTermino { get; set; }
        public Persona director {get;set;}
        public Persona responsable {get;set;}
        public List<Persona> colaboradores {get;set;}

        public List<Archivo> listaArchivos {get;set;}

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
            this.director = new Persona();
            this.responsable = new Persona();
            this.colaboradores = new List<Persona>();
            this.listaArchivos = new List<Archivo>();
        }
    }
}