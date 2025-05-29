using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms; 

namespace ClubDeportivoApp
{
    public class Conexion
    {
        private static string servidor = "localhost";
        private static string bd = "ClubDeportivo";
        private static string usuario = "root";
        private static string password = ""; //Clave servidor Local SQL
        private static string cadenaConexion = $"server={servidor}; database={bd}; user={usuario}; password={password};";

        public MySqlConnection Conectar()
        {
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);
            try
            {
                conexion.Open();
                //Solo se ve en consola
                Console.WriteLine("✅ Conexión exitosa a la base de datos.", "MENSAJE DEL SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Mensaje de error

                MessageBox.Show("❌ Error al conectar con la base de datos. " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return conexion;
        }
    }
}
