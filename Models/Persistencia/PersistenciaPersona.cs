using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Options;
using Proyecto_Web.Configuration;
using Dapper;
using System.Collections.Generic;
using Proyecto_Web.Models.Logica;

namespace Proyecto_Web.Models.Persistencia
{
    public class PersistenciaPersona
    {
        //configuracion de la conexion a la BD
        private DatabaseConfiguration configuration;

        //Constructor
        public PersistenciaPersona(DatabaseConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IEnumerable<Persona> find(string rut, string password)
        {
            //conexion a la base de datos
            var conexion = new SqlConnection(this.configuration.Default);
            //consulta 
            return conexion.Query<Persona>("SELECT * FROM persona WHERE rut=@Rut", new { Rut = rut});
            //cerrar conexion
        }
    }
}