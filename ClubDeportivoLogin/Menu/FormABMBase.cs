namespace ClubDeportivoLogin
{
    public partial class FormABMBase : Form
    {
        // Configuración de la entidad
        public class ConfigABM
        {
            public string TituloVentana { get; set; }
            public string Titulo { get; set; }
            public string Subtitulo { get; set; }
            public string Ayuda1 { get; set; }
            public string Ayuda2 { get; set; }
            public string EtiquetaCampo { get; set; }
            public Image Icono { get; set; }
            public Func<string, bool> Validacion { get; set; }
            public Action<string> AccionSiguiente { get; set; }
            public bool UsarModoPagos { get; set; } = false;
        }

        private ConfigABM config;
        private string usuario;

        public FormABMBase(string usuario, ConfigABM config)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.config = config;
            ConfigurarInterfaz();
            btnSiguiente.Click += btnSiguiente_Click;
            btnSalir.Click += btnSalir_Click;

            // Configuración especial para ABM de Pagos
            if (config.UsarModoPagos)
            {
                cmbModo.Visible = true;
                lblmodo.Visible = true;
                lblFondo.Size = new Size(313, 90);
                cmbModo.Items.Clear();
                cmbModo.Items.Add("NUEVO PAGO");
                cmbModo.Items.Add("CONSULTAR PAGO");
                cmbModo.SelectedIndex = 0;
                cmbModo.SelectedIndexChanged += cmbModo_SelectedIndexChanged;

                txtCampoID.Visible = true;
                txtCentroID.Visible = false;
                txtComprobanteID.Visible = false;
            }
            else
            {
                cmbModo.Visible = false;
                txtCampoID.Visible = true;
                txtCentroID.Visible = false;
                txtComprobanteID.Visible = false;
                lblmodo.Visible = false;
                lblFondo.Size = new Size(313, 50);
            }
        }

        private void ConfigurarInterfaz()
        {
            this.Text = config.TituloVentana;
            lblTitulo.Text = config.Titulo;
            lblSubtitulo.Text = config.Subtitulo;
            lblAyuda1.Text = config.Ayuda1;
            lblAyuda2.Text = config.Ayuda2;
            lblCampoID.Text = config.EtiquetaCampo;
            pictureIcono.Image = config.Icono;
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (config.UsarModoPagos && cmbModo.Visible && cmbModo.SelectedIndex == 1)
            {
                // CONSULTAR COMPROBANTE
                string centro = txtCentroID.Text.Trim();
                string comprobante = txtComprobanteID.Text.Trim();
                if (string.IsNullOrWhiteSpace(centro) || string.IsNullOrWhiteSpace(comprobante))
                {
                    MessageBox.Show("Ingrese centro y número de comprobante válidos.","Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }
                config.AccionSiguiente($"{centro}|{comprobante}");
                txtCentroID.Clear();
                txtComprobanteID.Clear();
            }
            else
            {
                // NUEVO REGISTRO o modo clásico
                string input = txtCampoID.Text.Trim();
                if (!config.Validacion(input))
                {
                    MessageBox.Show($"Ingrese un {config.EtiquetaCampo} válido","Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }
                config.AccionSiguiente(input);
                txtCampoID.Clear();
            }
        }

        private void cmbModo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbModo.SelectedIndex == 0) // NUEVO REGISTRO
            {
                lblCampoID.Text = "DNI: ";
                txtCampoID.Visible = true;
                txtCentroID.Visible = false;
                txtComprobanteID.Visible = false;
                lblmodo.Visible = true;
                lblFondo.Size = new Size(313, 90); 
            }
            else // CONSULTAR COMPROBANTE
            {
                lblCampoID.Text = "CENTRO Y N°: ";
                txtCampoID.Visible = false;
                txtCentroID.Visible = true;
                txtComprobanteID.Visible = true;
                lblmodo.Visible = true;
                lblFondo.Size = new Size(313, 90);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}