using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Options;
using Proyecto_Web.Configuration;
using Dapper;
using System.Collections.Generic;
using Proyecto_Web.Models.Domain;
using MySql.Data.MySqlClient;
using System.Linq;

namespace Proyecto_Web.Models.Persistencia
{
    public class PersistenciaProyecto
    {
        //configuracion de la conexion a la BD
        private DatabaseConfiguration configuration;
        public Conexion conexionMySQL { get; set; }

        //Constructor
        public PersistenciaProyecto(DatabaseConfiguration configuration)
        {
            this.configuration = configuration;
            this.conexionMySQL = new Conexion(this.configuration.Default);
        }

        public Proyecto Find(int id)
        {
            // conexion a la base de datos
            MySqlConnection conexion = this.conexionMySQL.conectar();
            // consulta 
            IEnumerable<Proyecto> proyectos =
                conexion.Query<Proyecto>("SELECT * FROM proyecto WHERE id=@ID"
                                            , new { ID = id});

            conexion.Close();
            // retorna resultado de la consulta
            return proyectos.FirstOrDefault();
        }


        public List<Proyecto> FindProyectoRutDirector(int Rut)
        {
            // conexion a la base de datos
            MySqlConnection conexion = this.conexionMySQL.conectar();
            // consulta 
            IEnumerable<Proyecto> proyectos =
                conexion.Query<Proyecto>("SELECT * FROM proyecto WHERE rutDirector=@RUT"
                                            , new { RUT = Rut});

            conexion.Close();
            // retorna resultado de la consulta
            return proyectos.AsList();
        }

        public List<Proyecto> FindProyectoRutColaborador(int Rut)
        {
            // conexion a la base de datos
            MySqlConnection conexion = this.conexionMySQL.conectar();
            // consulta 
            IEnumerable<Proyecto> proyectos =
                conexion.Query<Proyecto>("SELECT * FROM trabajadores WHERE rutPersona=@RUT"
                                            , new { RUT = Rut});

            conexion.Close();
            // retorna resultado de la consulta
            return proyectos.AsList();

        }


    }
}