using ClubDeportivoApp;

namespace ClubDeportivoLogin
{
    public partial class ABMClientes : Form
    {
        private Conexion conexion = new Conexion();
        private string usuarioActivo;
        [System.Runtime.Versioning.SupportedOSPlatform("windows")]

        public ABMClientes(string usuario)
        {
            InitializeComponent();
            usuarioActivo = usuario;
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            string dniTexto = textBox1.Text.Trim();

            if (!EsNumeroValido(dniTexto))
            {
                MessageBox.Show("❌ Error de formato: El DNI solo debe contener números.");
                return;
            }

            int dni = int.Parse(dniTexto);
            FormRegistrarCliente formRegistrar = new FormRegistrarCliente(dni); // ✅ Se pasa el DNI correctamente
            formRegistrar.ShowDialog();
            textBox1.Clear(); // Limpia el campo de texto después de abrir el formulario
        }

        private bool EsNumeroValido(string texto)
        {
            return texto.All(char.IsDigit) && texto.Length >= 7 && texto.Length <= 10; // Evita DNIs fuera de rango
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            MenuPrincipal menu = new MenuPrincipal(usuarioActivo);
            menu.Show();
            this.Hide();
        }

        private void ABMClientes_Load(object sender, EventArgs e)
        {
            textBox1.Clear(); // Limpia el campo al abrir el formulario
        }
    }
}