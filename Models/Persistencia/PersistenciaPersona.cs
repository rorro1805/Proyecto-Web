using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Options;
using Proyecto_Web.Configuration;
using Dapper;
using System.Collections.Generic;
using Proyecto_Web.Models.Logica;
using MySql.Data.MySqlClient;
using System.Linq;

namespace Proyecto_Web.Models.Persistencia
{
    public class PersistenciaPersona
    {
        // configuracion de la conexion a la BD
        private DatabaseConfiguration configuration { get; set; }
        // conexion MySql
        public Conexion conexionMySQL { get; set; }

        // Constructor
        public PersistenciaPersona(DatabaseConfiguration configuration)
        {
            this.configuration = configuration;
            this.conexionMySQL = new Conexion(this.configuration.Default);
        }

        // Busca a una persona en la base de datos, segun rut y password ingresados
        public Persona find(int rut, string password)
        {
            // conexion a la base de datos
            MySqlConnection conexion = this.conexionMySQL.conectar();
            // consulta 
            IEnumerable<Persona> personas =
                conexion.Query<Persona>("SELECT * FROM persona WHERE rut=@Rut AND _password=@Password"
                                            , new { Rut = rut, Password = password });

            //vulnerable a inyeccion SQL basica --> 'OR '1'='1
            /*IEnumerable<Persona> personas =
                conexion.Query<Persona>("SELECT * FROM persona WHERE rut='" 
                + rut + "' AND _password='" + password + "';");*/

            // cierre de la conexion a la BD
            conexion.Close();
            // retorna resultado de la consulta
            return personas.FirstOrDefault();
        }
    }
}