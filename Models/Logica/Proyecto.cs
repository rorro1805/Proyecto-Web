using System;
using System.Collections.Generic;

namespace Proyecto_Web.Models.Logica
{

    public class Proyecto
    {
        public string nombre { get; set; }
        public string fechaInicio { get; set; }
        public string fechaTermino { get; set; }
        public string rutDirector {get;set;}
        public List<Archivo> listaArchivos {get; set; }

        //Constructor vacio
        public Proyecto(){
            
        }

        //Constructor
        public Proyecto(string nombre, string fechaInicio, string fechaTermino, string rutDirector)
        {
            this.nombre = nombre;
            this.fechaInicio = fechaInicio;
            this.fechaTermino = fechaTermino;
            this.rutDirector = rutDirector;
            this.listaArchivos = new List<Archivo>();
        }

        public bool subirArchivo(Archivo archivo){  
            int cantidad = listaArchivos.Count;
            this.listaArchivos.Add(archivo);
            return true;
        }

        public bool descargarArchivo(){
            
            
            return true;
        }
        
    }
}