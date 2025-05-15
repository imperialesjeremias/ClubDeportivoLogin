using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ClubDeportivoApp;

namespace ClubDeportivoLogin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); // Inicializa todos los componentes visuales del formulario
        }

        // Evento que se ejecuta cuando se hace clic en el botón "Login"
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Captura los valores ingresados por el usuario y los limpia de espacios en blanco
            string usuario = txtUsuario.Text.Trim();
            string clave = txtPassword.Text.Trim();

            // Crea una nueva conexión a la base de datos
            Conexion conexion = new Conexion();
            MySqlConnection conn = conexion.Conectar();

            // Consulta SQL para verificar que el usuario y la contraseña coincidan
            string query = "SELECT * FROM Usuarios WHERE usuario = @usuario AND clave = @clave";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@usuario", usuario);
            cmd.Parameters.AddWithValue("@clave", clave);

            // Ejecuta la consulta y obtiene los resultados
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read()) // Si se encontró un usuario válido
            {
                MessageBox.Show("Login exitoso !!");

                // Oculta el formulario de login
                this.Hide();

                // Crea y muestra el formulario principal de la aplicación
                FormPrincipal principal = new FormPrincipal();

                // Se asegura de cerrar el login si el formulario principal se cierra
                principal.FormClosed += (s, args) => this.Close();
                principal.Show();
            }
            else
            {
                // Si el usuario o contraseña son incorrectos, muestra un mensaje de error
                MessageBox.Show("Usuario o contraseña incorrectos ?");
            }

            // Cierra la conexión con la base de datos
            conn.Close();
        }
    }
}