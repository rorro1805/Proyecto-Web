
using System.Collections.Generic;
using System.Linq;
using Dapper;
using MySql.Data.MySqlClient;
using Proyecto_Web.Configuration;
using Proyecto_Web.Models.Domain;

namespace Proyecto_Web.Models.Persistencia
{
    public class PersistenciaArchivo
    {

        // configuracion de la conexion a la BD
        private DatabaseConfiguration configuration { get; set; }
        // conexion MySql
        public Conexion conexionMySQL { get; set; }

        // Constructor
        public PersistenciaArchivo(DatabaseConfiguration configuration)
        {
            this.configuration = configuration;
            this.conexionMySQL = new Conexion(this.configuration.Default);
        }

        // Busca los archivos a correspondientes a un Proyecto
        public List<Archivo> FindForProyect(int idProyect)
        {
            // conexion a la base de datos
            MySqlConnection conexion = this.conexionMySQL.conectar();
            // consulta 
            IEnumerable<Archivo> archivos =
                conexion.Query<Archivo>("SELECT * FROM archivo WHERE idProyecto=@IDProyecto"
                                            , new { IDProyecto = idProyect});

            // cierre de la conexion a la BD
            conexion.Close();
            // retorna resultado de la consulta
            return archivos.AsList();
        }
    }
}