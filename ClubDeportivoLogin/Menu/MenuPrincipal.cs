using ClubDeportivoLogin.Menu.ListadoMorosos;
using ClubDeportivoLogin.Menu.Pagos;

namespace ClubDeportivoLogin
{
    public partial class MenuPrincipal : Form
    {
        private string usuario; // Variable para almacenar el usuario activo
        public MenuPrincipal(string usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private void btnABMCliente_Click(object sender, EventArgs e)
        {
            ABMClientes formularioABMClientes = new ABMClientes(usuario); // Pasamos el usuario
            formularioABMClientes.ShowDialog(); //Abre como ventana modal
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            usuarioActivo.Text = "USUARIO ACTIVO: [ " + usuario.ToUpper() + " ]"; // Mostrar usuario activo
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            // Mostrar el formulario de login antes de cerrar el principal
            Login loginForm = new Login(usuario);
            this.Close();
            loginForm.Show(); // Muestra el formulario de login 

        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Cierra toda la aplicación
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            frmComprobanteClub ventanaPago = new frmComprobanteClub();
            ventanaPago.ShowDialog(); // abre como ventana moda
        }

        private void btnLisMorosos_Click(object sender, EventArgs e)
        {
            frmSociosMorosos formMorosos = new frmSociosMorosos();
            formMorosos.ShowDialog();
        }
    }
}
