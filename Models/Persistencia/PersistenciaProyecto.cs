using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Options;
using Proyecto_Web.Configuration;
using Dapper;
using System.Collections.Generic;
using Proyecto_Web.Models.Logica;
using MySql.Data.MySqlClient;

namespace Proyecto_Web.Models.Persistencia
{
    public class PersistenciaProyecto
    {
        //configuracion de la conexion a la BD
        private DatabaseConfiguration configuration;

        //Constructor
        public PersistenciaProyecto(DatabaseConfiguration configuration)
        {
            this.configuration = configuration;
        }

    }
}