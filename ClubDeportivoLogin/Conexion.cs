using MySql.Data.MySqlClient;

namespace ClubDeportivoLogin
{
    public class Conexion
    {
        public static string Servidor { get; set; } = "localhost";
        public static string BaseDatos { get; set; } = "ClubDeportivo";
        public static string Usuario { get; set; } = "root";
        public static string Password { get; set; } = "";

        // Propiedad para la cadena de conexión
        public static string CadenaConexion =>
            $"server={Servidor};database={BaseDatos};user={Usuario};password={Password};";

        public MySqlConnection Conectar()
        {
            var conexion = new MySqlConnection(CadenaConexion);
            try
            {
                conexion.Open();
                Console.WriteLine("Conexión exitosa a la base de datos");
                return conexion;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar: {ex.Message}", "Error de conexión",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}