namespace Proyecto_Web.Models
{
    public class Archivo
    {
        public string nombre { get; set; }
        public string tipo { get; set; }
        public Estado estado { get; set; }

        //Constructor vacio
        public Archivo()
        {

        }

        public Archivo(string nombre, string tipo, Estado estado)
        {
            this.nombre = nombre;
            this.tipo = tipo;
            this.estado = estado;
        }
    }
}