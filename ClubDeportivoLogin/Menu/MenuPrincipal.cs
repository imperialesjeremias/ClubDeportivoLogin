using ClubDeportivoLogin;
using ClubDeportivoLogin.clientes;
using ClubDeportivoLogin.pagos;


namespace ClubDeportivoLogin
{
    public partial class MenuPrincipal : Form
    {
        private string usuario;
        public MenuPrincipal(string usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            usuarioActivo.Text = "USUARIO ACTIVO: [ " + usuario.ToUpper() + " ]";
            try
            {
                Conexion conn = new Conexion();
                using (var conexion = conn.Conectar())
                using (var cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT rol FROM usuarios WHERE usuario = @usuario", conexion))
                {
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    var rol = cmd.ExecuteScalar()?.ToString();
                    btnUsers.Visible = (rol != null && rol.ToUpper() == "ADMINISTRADOR");
                }
            }
            catch
            {
                btnUsers.Visible = false;
            }
            btnModPass.Click += btnModPass_Click;
            btnUsers.Click += btnUsers_Click;
        }

        private void btnModPass_Click(object sender, EventArgs e)
        {
            var form = new ClubDeportivoLogin.Menu.Usuarios.FormCambiarContraseña(usuario);
            form.ShowDialog();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            var form = new ClubDeportivoLogin.Menu.Usuarios.FormUsuarios();
            form.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {

            Login loginForm = new Login(usuario);
            this.Close();
            loginForm.Show();

        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPago_Click(object sender, EventArgs e)
        {
            var config = ABMPagosConfig.ObtenerConfig(usuario);
            FormABMBase form = new FormABMBase(usuario, config);
            form.ShowDialog();
        }

        private void btnABMClientes_Click(object sender, EventArgs e)
        {
            var config = ABMClientesConfig.ObtenerConfig(usuario);
            FormABMBase form = new FormABMBase(usuario, config);
            form.ShowDialog();
        }

        private void btnABMActividad_Click(object sender, EventArgs e)
        {
            var config = ABMActividadesConfig.ObtenerConfig(usuario);
            FormABMBase form = new FormABMBase(usuario, config);
            form.ShowDialog();
        }

        private void btnLisMorosos_Click(object sender, EventArgs e)
        {
            FormListarMorosos form = new FormListarMorosos();
            form.ShowDialog();
        }
        private void btnLisClientes_Click(object sender, EventArgs e)
        {
            FormListarClientes form = new FormListarClientes();
            form.ShowDialog();
        }

        private void btnLisPagos_Click(object sender, EventArgs e)
        {
            FormListarPagos form = new FormListarPagos();
            form.ShowDialog();
        }
    }
}
