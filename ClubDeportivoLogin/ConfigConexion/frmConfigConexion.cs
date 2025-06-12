using ClubDeportivoLogin;
using MySql.Data.MySqlClient;

namespace ClubDeportivoApp
{
    public partial class frmConfigConexion : Form
    {
        public frmConfigConexion()
        {
            InitializeComponent();
            CargarConfiguracion();
        }

        private void CargarConfiguracion()
        {
            txtServidor.Text = Conexion.Servidor;
            txtBaseDatos.Text = Conexion.BaseDatos;
            txtUsuario.Text = Conexion.Usuario;
            txtContrasena.Text = Conexion.Password;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Conexion.Servidor = txtServidor.Text;
            Conexion.BaseDatos = txtBaseDatos.Text;
            Conexion.Usuario = txtUsuario.Text;
            Conexion.Password = txtContrasena.Text;

            MessageBox.Show("Configuración guardada correctamente", "Éxito",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnProbar_Click(object sender, EventArgs e)
        {
            try
            {
                string connStr = $"server={txtServidor.Text};database={txtBaseDatos.Text};" +
                               $"user={txtUsuario.Text};password={txtContrasena.Text};";

                using (var conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    MessageBox.Show("¡Conexión exitosa!", "Prueba de conexión",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error de conexión: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmConfigConexion_Load(object sender, EventArgs e)
        {

        }
    }
}
