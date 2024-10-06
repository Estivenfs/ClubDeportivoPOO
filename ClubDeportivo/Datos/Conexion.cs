using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ClubDeportivo.Datos
{
    public class Conexion
    {
        // declaramos las variables
        private string baseDatos;
        private string servidor;
        private string puerto;
        private string usuario;
        private string clave;
        private static Conexion? con = null;

        private Conexion() // asignamos valores a las variables de la conexion
        {
            this.baseDatos = "Proyecto";
            this.servidor = "localhost";
            this.puerto = "3306";
            this.usuario = "root";
            this.clave = "";
        }

        public MySqlConnection getConexion() // creamos la conexion
        {
            MySqlConnection? conexion = new MySqlConnection();
            try {
                conexion.ConnectionString = "datasource=" + this.servidor +
                "; port=" + this.puerto +
                "; database=" + this.baseDatos +
                "; username=" + this.usuario +
                "; password=" + this.clave + ";";
                return conexion;
            }
            catch (MySqlException ex)
            {
                conexion = null;
                throw ex;
            }

        }

        public static Conexion getInstancia() // creamos una instancia de la conexion
        {
            if (con == null)
            {
                con = new Conexion();
            }
            return con;
        }
    }
}
