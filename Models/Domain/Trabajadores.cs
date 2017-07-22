namespace Proyecto_Web.Models.Domain
{
    public partial class Trabajadores
    {
        public string RutPersona { get; set; }
        public int IdProyecto { get; set; }
        public string Cargo { get; set; }

        public virtual Proyecto IdProyectoNavigation { get; set; }
        public virtual Persona RutPersonaNavigation { get; set; }
    }
}
