using ClubDeportivoApp;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubDeportivoLogin.Menu.Pagos
{
    public partial class frmComprobanteClub : Form
    {
        private int clienteId;
        private bool esSocio;

        public frmComprobanteClub()
        {
            InitializeComponent();
            this.Load += frmComprobanteClub_Load;
            cmbActividad.SelectedIndexChanged += cmbActividad_SelectedIndexChanged;
        }

        private void frmComprobanteClub_Load(object sender, EventArgs e)
        {
            CargarActividades();
            CargarMediosDePago();
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            clienteId = 0;
            esSocio = false;
            lblNombreCliente.Text = "";
            lblTipoCliente.Text = "";
            lblUltimoPago.Text = "";
            txtBuscarCliente.Text = "";
            txtMonto.Text = "";
            cmbActividad.SelectedIndex = -1;
            cmbMedioPago.SelectedIndex = 0;
            dtpFechaPago.Value = DateTime.Today;
            pnlComprobante.Visible = false;
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            string dniTexto = txtBuscarCliente.Text.Trim();

            if (!int.TryParse(dniTexto, out int dni))
            {
                MessageBox.Show("Ingrese un DNI válido.");
                return;
            }

            Conexion conn = new Conexion();
            using (MySqlConnection conexion = conn.Conectar())
            {
                try
                {
                    int clienteIdLocal = -1;
                    string nombre = "", apellido = "";

                    string queryCliente = "SELECT id, nombre, apellido FROM Cliente WHERE dni = @dni";
                    using (MySqlCommand cmdCliente = new MySqlCommand(queryCliente, conexion))
                    {
                        cmdCliente.Parameters.AddWithValue("@dni", dni);
                        using (MySqlDataReader reader = cmdCliente.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                clienteIdLocal = reader.GetInt32("id");
                                nombre = reader.GetString("nombre");
                                apellido = reader.GetString("apellido");
                            }
                            else
                            {
                                MessageBox.Show("Cliente no encontrado.");
                                LimpiarCampos();
                                return;
                            }
                        }
                    }

                    clienteId = clienteIdLocal;
                    lblNombreCliente.Text = $"{apellido}, {nombre}";

                    // Buscar si es Socio
                    string querySocio = "SELECT id FROM Socio WHERE id = @id";
                    using (MySqlCommand cmdSocio = new MySqlCommand(querySocio, conexion))
                    {
                        cmdSocio.Parameters.AddWithValue("@id", clienteId);
                        object resultadoSocio = cmdSocio.ExecuteScalar();

                        if (resultadoSocio != null)
                        {
                            esSocio = true;
                            lblTipoCliente.Text = "Socio";

                            string queryUltimoPago = "SELECT MAX(fechaPago) FROM Cuota WHERE idSocio = @idSocio";
                            using (MySqlCommand cmdUltimoPago = new MySqlCommand(queryUltimoPago, conexion))
                            {
                                cmdUltimoPago.Parameters.AddWithValue("@idSocio", clienteId);
                                object resultadoFecha = cmdUltimoPago.ExecuteScalar();

                                if (resultadoFecha != DBNull.Value)
                                {
                                    DateTime fecha = Convert.ToDateTime(resultadoFecha);
                                    lblUltimoPago.Text = fecha.ToString("dd/MM/yyyy");
                                }
                                else
                                {
                                    lblUltimoPago.Text = "Sin pagos";
                                }
                            }
                        }
                        else
                        {
                            esSocio = false;
                            lblTipoCliente.Text = "No Socio";
                            lblUltimoPago.Text = "-";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar el cliente: " + ex.Message);
                }
            }
        }

        private void CargarActividades()
        {
            Conexion conn = new Conexion();
            using (MySqlConnection conexion = conn.Conectar())
            {
                string query = "SELECT id, nombre FROM Actividad";
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                MySqlDataReader reader = cmd.ExecuteReader();
                Dictionary<int, string> actividades = new Dictionary<int, string>();

                while (reader.Read())
                {
                    actividades.Add(reader.GetInt32("id"), reader.GetString("nombre"));
                }

                cmbActividad.SelectedIndexChanged -= cmbActividad_SelectedIndexChanged;
                cmbActividad.DataSource = new BindingSource(actividades, null);
                cmbActividad.DisplayMember = "Value";
                cmbActividad.ValueMember = "Key";
                cmbActividad.SelectedIndex = -1;
                cmbActividad.SelectedIndexChanged += cmbActividad_SelectedIndexChanged;
            }
        }

        private void cmbActividad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbActividad.SelectedValue != null && int.TryParse(cmbActividad.SelectedValue.ToString(), out int idActividad))
            {
                Conexion conn = new Conexion();
                using (MySqlConnection conexion = conn.Conectar())
                {
                    string query = "SELECT costo FROM Actividad WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@id", idActividad);
                    object result = cmd.ExecuteScalar();

                    txtMonto.Text = result != null ? Convert.ToDecimal(result).ToString("0.00") : "";
                }
            }
            else
            {
                txtMonto.Text = "";
            }
        }

        private void CargarMediosDePago()
        {
            cmbMedioPago.Items.Clear();
            cmbMedioPago.Items.Add("Efectivo");
            cmbMedioPago.Items.Add("Tarjeta Crédito 1 pago");
            cmbMedioPago.Items.Add("Tarjeta Crédito 3 cuotas");
            cmbMedioPago.Items.Add("Tarjeta Crédito 6 cuotas");
            cmbMedioPago.SelectedIndex = 0;
        }

        private void btnRegistrarPago_Click(object sender, EventArgs e)
        {
            if (clienteId == 0 || string.IsNullOrEmpty(txtMonto.Text) || !decimal.TryParse(txtMonto.Text, out decimal monto))
            {
                MessageBox.Show("Datos inválidos para registrar el pago.");
                return;
            }

            string medioPago = cmbMedioPago.SelectedItem?.ToString() ?? "";
            DateTime fechaPago = dtpFechaPago.Value;
            Conexion conn = new Conexion();

            using (MySqlConnection conexion = conn.Conectar())
            {
                try
                {
                    int idInsertado = 0;

                    if (esSocio)
                    {
                        int cuotas = medioPago.Contains("3 cuotas") ? 3 : medioPago.Contains("6 cuotas") ? 6 : 1;
                        DateTime vencimiento = fechaPago.AddMonths(cuotas);

                        string insert = "INSERT INTO Cuota (idSocio, fechaPago, monto, medioPago, cantidadCuotas, fechaVencimiento) " +
                                        "VALUES (@idSocio, @fecha, @monto, @medio, @cuotas, @vencimiento)";

                        MySqlCommand cmd = new MySqlCommand(insert, conexion);
                        cmd.Parameters.AddWithValue("@idSocio", clienteId);
                        cmd.Parameters.AddWithValue("@fecha", fechaPago);
                        cmd.Parameters.AddWithValue("@monto", monto);
                        cmd.Parameters.AddWithValue("@medio", medioPago);
                        cmd.Parameters.AddWithValue("@cuotas", cuotas);
                        cmd.Parameters.AddWithValue("@vencimiento", vencimiento);

                        cmd.ExecuteNonQuery();
                        idInsertado = (int)cmd.LastInsertedId;

                        MessageBox.Show("✅ Cuota registrada correctamente.");
                    }
                    else
                    {
                        if (cmbActividad.SelectedValue == null)
                        {
                            MessageBox.Show("Debe seleccionar una actividad.");
                            return;
                        }

                        int idActividad = Convert.ToInt32(cmbActividad.SelectedValue);

                        string insert = "INSERT INTO RegistroActividad (idNoSocio, idActividad, fechaPago, montoCobrado, medioPago) " +
                                        "VALUES (@idNoSocio, @idActividad, @fecha, @monto, @medio)";

                        MySqlCommand cmd = new MySqlCommand(insert, conexion);
                        cmd.Parameters.AddWithValue("@idNoSocio", clienteId);
                        cmd.Parameters.AddWithValue("@idActividad", idActividad);
                        cmd.Parameters.AddWithValue("@fecha", fechaPago);
                        cmd.Parameters.AddWithValue("@monto", monto);
                        cmd.Parameters.AddWithValue("@medio", medioPago);

                        cmd.ExecuteNonQuery();
                        idInsertado = (int)cmd.LastInsertedId;

                        MessageBox.Show("✅ Actividad registrada correctamente.");
                    }

                    MostrarComprobante(esSocio, idInsertado);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("❌ Error al registrar el pago: " + ex.Message);
                }
            }
        }

        private void MostrarComprobante(bool esSocio, int idComprobante)
        {
            pnlComprobante.Visible = true;

            lblNumeroComprobante.Text = $"Comprobante N° {idComprobante}";
            lblCliente.Text = lblNombreCliente.Text;
            lblTipo.Text = esSocio ? "Socio" : "No Socio";
            lblFechaPago.Text = dtpFechaPago.Value.ToString("dd/MM/yyyy");
            lblMedioPago.Text = cmbMedioPago.SelectedItem.ToString();

            if (esSocio)
            {
                lblAbono.Visible = true;
                lblMontoO.Visible = true;
                lblActividad.Visible = false;
                lblMontoA.Visible = false;

                lblAbono.Text = "Abono mensual";
                lblMontoO.Text = $"${txtMonto.Text}";
                lblFechaVto.Visible = true;
                lblFechaVto.Text = $"Válido hasta: {dtpFechaPago.Value.AddMonths(1):dd/MM/yyyy}";
                lblDetallesPago.Text = "Pago de cuota mensual como socio del club.";
            }
            else
            {
                lblAbono.Visible = false;
                lblMontoO.Visible = false;
                lblActividad.Visible = true;
                lblMontoA.Visible = true;

                lblActividad.Text = $"Actividad: {((KeyValuePair<int, string>)cmbActividad.SelectedItem).Value}";
                lblMontoA.Text = $"${txtMonto.Text}";
                lblFechaVto.Visible = false;
                lblDetallesPago.Text = "Acceso diario a la actividad seleccionada como no socio.";
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            pnlComprobante.Visible = false;
            LimpiarCampos();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Función no implementada.");
        }

    }
}
