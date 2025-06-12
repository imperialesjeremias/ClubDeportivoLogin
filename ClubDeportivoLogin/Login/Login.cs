using ClubDeportivoApp;
using MySql.Data.MySqlClient;

namespace ClubDeportivoLogin
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        public Login(string usuarioCerroSesion) : this()
        {
            if (!string.IsNullOrEmpty(usuarioCerroSesion))
            {
                lblUsuarioCerroSesion.Text = $"{usuarioCerroSesion} acaba de cerrar la sesión";
            }
        }
        private void Login_Load(object sender, EventArgs e)
        {
            txtUsuario.Text = "USUARIO";
            txtUsuario.ForeColor = System.Drawing.Color.Silver;

            txtPassword.Text = "CONTRASEÑA";
            txtPassword.ForeColor = System.Drawing.Color.Silver;
            txtPassword.UseSystemPasswordChar = false;
        }
        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "USUARIO")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                txtUsuario.Text = "USUARIO";
                txtUsuario.ForeColor = System.Drawing.Color.Silver;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "CONTRASEÑA")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = System.Drawing.Color.Black;
                txtPassword.UseSystemPasswordChar = true;  
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.UseSystemPasswordChar = false;
                txtPassword.Text = "CONTRASEÑA";
                txtPassword.ForeColor = System.Drawing.Color.Silver;
            }
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            if (txtUsuario.Text != txtUsuario.Text.ToUpper())
            {
                int selectionStart = txtUsuario.SelectionStart;
                txtUsuario.Text = txtUsuario.Text.ToUpper();
                txtUsuario.SelectionStart = selectionStart;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string clave = txtPassword.Text.Trim();

            Conexion conexion = new Conexion();
            MySqlConnection conn = conexion.Conectar();

            string query = "SELECT * FROM Usuarios WHERE UPPER(usuario) = @usuario AND clave = @clave";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@usuario", usuario.ToUpper());
            cmd.Parameters.AddWithValue("@clave", clave);

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read()) 
            {
                MessageBox.Show("Ingreso Exitoso                   ", "MENSAJE DEL SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                camposObligatorios.Visible = false;

                this.Visible = false;

                MenuPrincipal principal = new MenuPrincipal(usuario);

                principal.Show();
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña incorrectos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                camposObligatorios.Visible = true;
                txtUsuario.Text = "";
                txtPassword.Text = "";
            }

            conn.Close();
        }

        private void btnConfigurar_Click(object sender, EventArgs e)
        {
            frmConfigConexion configForm = new frmConfigConexion();
            configForm.ShowDialog();
        }

    }
}