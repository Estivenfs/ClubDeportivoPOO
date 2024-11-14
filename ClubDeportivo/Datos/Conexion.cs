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
            bool correcto = false;
            int mensaje;

            string T_servidor = "localhost";
            string T_puerto = "3306";
            string T_usuario = "root";
            string T_clave = "";

            while (!correcto) {
                T_servidor = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el servidor", "DATOS DE INSTALACION MySQL");
                T_puerto = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el puerto", "DATOS DE INSTALACION MySQL");
                T_usuario = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el usuario", "DATOS DE INSTALACION MySQL");
                T_clave = Microsoft.VisualBasic.Interaction.InputBox("Ingrese la clave", "DATOS DE INSTALACION MySQL");

                mensaje = (int)MessageBox.Show("Su ingreso: Servidor: " + T_servidor + "\nPuerto: " + T_puerto + "\nUsuario: " + T_usuario + "\nClave: " + T_clave, "AVISO DEL SISTEMA", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if ( mensaje != 6)
                {
                    MessageBox.Show("Por favor, ingrese nuevamente los datos", "AVISO DEL SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    correcto = false;
                }
                else
                {
                    correcto = true;
                }

            }


            this.baseDatos = "Proyecto";
            this.servidor = T_servidor;
            this.puerto = T_puerto;
            this.usuario = T_usuario;
            this.clave = T_clave;
            
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
