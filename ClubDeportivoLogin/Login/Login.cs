using ClubDeportivoApp;
using MySql.Data.MySqlClient;

namespace ClubDeportivoLogin
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent(); // Inicializa todos los componentes visuales del formulario
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
            // Placeholder Usuario
            txtUsuario.Text = "USUARIO";
            txtUsuario.ForeColor = System.Drawing.Color.Silver;

            // Placeholder Contraseña
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
                txtPassword.UseSystemPasswordChar = true;  // ahora sí oculta caracteres
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
            // Evita bucles infinitos al modificar el texto
            if (txtUsuario.Text != txtUsuario.Text.ToUpper())
            {
                int selectionStart = txtUsuario.SelectionStart;
                txtUsuario.Text = txtUsuario.Text.ToUpper();
                txtUsuario.SelectionStart = selectionStart;
            }
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
            string query = "SELECT * FROM Usuarios WHERE UPPER(usuario) = @usuario AND clave = @clave";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@usuario", usuario.ToUpper());
            cmd.Parameters.AddWithValue("@clave", clave);

            // Ejecuta la consulta y obtiene los resultados
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read()) // Si se encontró un usuario válido
            {
                MessageBox.Show("Ingreso Exitoso                   ", "MENSAJE DEL SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                camposObligatorios.Visible = false;

                // Oculta el formulario de login
                this.Visible = false;

                // Crea y muestra el formulario principal de la aplicación
                MenuPrincipal principal = new MenuPrincipal(usuario);

                // Se asegura de cerrar el login si el formulario principal se cierra
                //principal.FormClosed += (s, args) => this.Close();
                principal.Show();
            }
            else
            {
                // Si el usuario o contraseña son incorrectos, muestra un mensaje de error
                MessageBox.Show("Usuario y/o contraseña incorrectos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                camposObligatorios.Visible = true;
            }

            // Cierra la conexión con la base de datos
            conn.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void camposObligatorios_Click(object sender, EventArgs e)
        {

        }

    }
}