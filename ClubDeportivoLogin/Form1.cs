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
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string clave = txtPassword.Text.Trim();

            Conexion conexion = new Conexion();
            MySqlConnection conn = conexion.Conectar();

            string query = "SELECT * FROM Usuarios WHERE usuario = @usuario AND clave = @clave";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@usuario", usuario);
            cmd.Parameters.AddWithValue("@clave", clave);

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                MessageBox.Show("Login exitoso !!");

                this.Hide(); // Oculta el formulario de login
                FormPrincipal principal = new FormPrincipal();
                principal.FormClosed += (s, args) => this.Close(); // Cierra el login si se cierra el principal
                principal.Show();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos ?");
            }

            conn.Close();
        }
    }
}
