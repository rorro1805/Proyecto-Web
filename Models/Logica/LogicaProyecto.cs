using System.Collections.Generic;
using Microsoft.Extensions.Options;
using Proyecto_Web.Configuration;
using Proyecto_Web.Models.Domain;
using Proyecto_Web.Models.Persistencia;

namespace Proyecto_Web.Models
{

    public class LogicaProyecto{

        private DatabaseConfiguration configuration { get; set; }

        public LogicaProyecto(DatabaseConfiguration configuration){
            this.configuration = configuration;
        }

        public List<Proyecto> FindProyectoRutDirector(int Rut)
        {
            PersistenciaProyecto PerProyecto = new PersistenciaProyecto(this.configuration);
            List<Proyecto> ListaProyectos = PerProyecto.FindProyectoRutDirector(Rut);

            return ListaProyectos;
        }

        public List<Proyecto> FindProyectoRutColaborador(int Rut)
        {
            PersistenciaProyecto PerProyecto = new PersistenciaProyecto(this.configuration);
            List<Proyecto> ListaProyectos = PerProyecto.FindProyectoRutColaborador(Rut);

            return ListaProyectos;
        }   

    }
}