namespace Proyecto_Web.Models.Domain
{
    public class Archivo
    {
        public int ID {get; set;}
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string Ruta { get;set;}
        public int IDEstado { get; set;}
        public int IDProyecto {get; set;}
        public Archivo(int ID, string Nombre, string Tipo, string Ruta, int IDEstado, int IDProyecto)
        {
            this.ID = ID;
            this.Nombre = Nombre;
            this.Tipo = Tipo;
            this.Ruta = Ruta;
            this.IDEstado = IDEstado;
            this.IDProyecto = IDProyecto;
        }
    }
}