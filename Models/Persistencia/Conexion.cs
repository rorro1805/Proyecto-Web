using MySql.Data.MySqlClient;

namespace Proyecto_Web.Configuration
{
    public class Conexion
    {
        private string stringConexion { get; set; }

        public Conexion(string stringConexion)
        {
            this.stringConexion = stringConexion;
        }

        public MySqlConnection conectar()
        {
            return new MySqlConnection(this.stringConexion);
        }
    }

}