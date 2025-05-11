using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms; // Agregá esto para mostrar errores con MessageBox

namespace ClubDeportivoApp
{
    public class Conexion
    {
        private static string servidor = "localhost";
        private static string bd = "ClubDeportivo";
        private static string usuario = "root";
        private static string password = "Claromeco2025"; // ← CAMBIALO
        private static string cadenaConexion = $"server={servidor}; database={bd}; user={usuario}; password={password};";

        public MySqlConnection Conectar()
        {
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);
            try
            {
                conexion.Open();
                // Opcional: solo útil si estás en consola
                Console.WriteLine("✅ Conexión exitosa a la base de datos.");
            }
            catch (Exception ex)
            {
                // En Forms, es mejor usar esto:
                MessageBox.Show("❌ Error al conectar: " + ex.Message);
            }
            return conexion;
        }
    }
}
