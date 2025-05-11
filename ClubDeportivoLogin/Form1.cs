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

                // Ejemplo: abrir otro formulario llamado MenuForm
                // MenuForm menu = new MenuForm();
                // menu.Show();
                // this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos ?");
            }

            conn.Close();
        }
    }
}
