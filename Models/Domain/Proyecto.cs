using System;
using System.Collections.Generic;

namespace Proyecto_Web.Models.Domain
{

    public class Proyecto
    {
        public int ID {get; set; }
        public string Nombre { get; set; }
        public string FechaInicio { get; set; }
        public string FechaTermino { get; set; }
        public string RutDirector {get;set;}
        public List<Archivo> ListaArchivos {get; set; }

        //Constructor vacio
        public Proyecto(){
            
        }

        //Constructor
        public Proyecto(int ID, string Nombre, string FechaInicio, string FechaTermino, string RutDirector)
        {
            this.ID = ID;
            this.Nombre = Nombre;
            this.FechaInicio = FechaInicio;
            this.FechaTermino = FechaTermino;
            this.RutDirector = RutDirector;
            this.ListaArchivos = new List<Archivo>();
        }

        

        public bool AddArchivo(Archivo archivo){  
            int cantidad = ListaArchivos.Count;
            this.ListaArchivos.Add(archivo);
            return true;
        }

        
    }
}