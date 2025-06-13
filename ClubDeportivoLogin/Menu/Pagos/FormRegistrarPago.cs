using System.Drawing.Printing;
using MySql.Data.MySqlClient;

namespace ClubDeportivoLogin
{
    public partial class FormRegistrarPago : Form
    {
        private Conexion conexion = new Conexion();
        private int dniCliente;
        private int idCliente;
        private bool esSocio;
        private int ultimoIdPago;
        private bool esConsulta = false;
        private string consultaCentro;
        private int consultaIdComprobante;

        public FormRegistrarPago(int dni)
        {
            InitializeComponent();
            dniCliente = dni;
            esConsulta = false;
        }

        public FormRegistrarPago(string centro, int idComprobante)
        {
            InitializeComponent();
            esConsulta = true;
            consultaCentro = centro;
            consultaIdComprobante = idComprobante;
        }

        private void FormRegistrarPago_Load(object sender, EventArgs e)
        {
            if (lblTipoRegistro != null)
            {
                if (esConsulta)
                {
                    lblTipoRegistro.Text = "CONSULTAR PAGO";
                    lblTipoRegistro.ForeColor = Color.Red;
                }
                else
                {
                    lblTipoRegistro.Text = "REGISTRAR PAGO";
                    lblTipoRegistro.ForeColor = Color.Blue;
                }
            }

            btnImprimirS.Visible = false;
            btnImprimirNS.Visible = false;
            btnBorrar.Visible = false;
            txtMontoS.TextChanged += (s, e) => CalcularTotalDescuentoSocio();
            txtDescuentoS.TextChanged += (s, e) => CalcularTotalDescuentoSocio();
            txtMontoNS.TextChanged += (s, e) => CalcularTotalDescuentoNoSocio();
            txtDescuentoNS.TextChanged += (s, e) => CalcularTotalDescuentoNoSocio();

            if (esConsulta)
            {
                btnGuardar.Enabled = false;
                btnBorrar.Enabled = false;
                CargarComprobante(consultaCentro, consultaIdComprobante);
                return;
            }

            if (!BuscarClientePorDni(dniCliente, out idCliente))
            {
                var res = MessageBox.Show("El DNI no existe en la tabla Cliente. ¿Desea registrar el cliente?", "Cliente no encontrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    new FormRegistrarCliente(dniCliente).ShowDialog();
                    this.Close();
                    return;
                }
                else
                {
                    MessageBox.Show("Ingrese un DNI válido para continuar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    return;
                }
            }

            esSocio = EsSocioActivo(idCliente);

            if (esSocio)
            {
                tabControl1.SelectedTab = tabPage1;
                tabPage2.Parent = null;
                CargarDatosSocio();
            }
            else
            {
                tabControl1.SelectedTab = tabPage2;
                tabPage1.Parent = null;
                CargarDatosNoSocio();
            }
        }

        private void CargarComprobante(string centro, int idComprobante)
        {
            try
            {
                btnImprimirS.Visible = false;
                btnImprimirNS.Visible = false;
                btnGuardar.Visible = false;
                btnBorrar.Visible = true;
                btnBorrar.Enabled = true;

                if (lblTipoRegistro != null)
                {
                    lblTipoRegistro.Text = "CONSULTAR PAGO";
                    lblTipoRegistro.ForeColor = Color.Red;
                }

                if (centro == "100")
                {
                    using (var conn = conexion.Conectar())
                    using (var cmd = new MySqlCommand(
                        @"SELECT c.*, cli.nombre, cli.apellido, cli.dni
                        FROM Cuota c 
                        JOIN Cliente cli ON cli.id = c.idSocio 
                        WHERE c.id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idComprobante);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                tabControl1.SelectedTab = tabPage1;
                                tabPage2.Parent = null;
                                int idSocio = Convert.ToInt32(reader["idSocio"]);
                                lblDniS.Text = reader["dni"].ToString();
                                txtMontoS.Text = reader["monto"].ToString();
                                txtDescuentoS.Text = reader["descuento"].ToString();
                                comboMedPagoS.Items.Clear();
                                comboMedPagoS.Items.AddRange(new string[] { "Efectivo", "Credito", "Debito" });
                                comboMedPagoS.SelectedItem = reader["medioPago"].ToString();
                                dateFePagoS.Value = Convert.ToDateTime(reader["fechaPago"]);
                                ultimoIdPago = Convert.ToInt32(reader["id"]);
                                lblClienteS.Text = $"{reader["nombre"]} {reader["apellido"]}";
                                txtMontoS.Enabled = false;
                                txtDescuentoS.Enabled = false;
                                comboMedPagoS.Enabled = false;
                                dateFePagoS.Enabled = false;
                                btnImprimirS.Visible = true;
                                btnImprimirS.Enabled = true;
                            }
                            else
                            {
                                MessageBox.Show("No se encontró el comprobante.", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                                return;
                            }
                        }
                    }
                }
                else if (centro == "200")
                {
                    using (var conn = conexion.Conectar())
                    using (var cmd = new MySqlCommand(
                        @"SELECT r.*, cli.nombre, cli.apellido, cli.dni, a.id AS idActividad, a.nombre AS nombreActividad, a.costo AS costoActividad
                        FROM RegistroActividad r
                        JOIN Cliente cli ON cli.id = r.idNoSocio
                        JOIN Actividad a ON a.id = r.idActividad
                        WHERE r.id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idComprobante);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                tabControl1.SelectedTab = tabPage2;
                                tabPage1.Parent = null;
                                int idNoSocio = Convert.ToInt32(reader["idNoSocio"]);
                                lblDniNS.Text = reader["dni"].ToString();
                                txtMontoNS.Text = reader["monto"].ToString();
                                txtDescuentoNS.Text = reader["descuento"].ToString();
                                comboMedPagoNS.Items.Clear();
                                comboMedPagoNS.Items.AddRange(new string[] { "Efectivo", "Credito", "Debito" });
                                comboMedPagoNS.SelectedItem = reader["medioPago"].ToString();
                                dateFePagoNS.Value = Convert.ToDateTime(reader["fechaPago"]);
                                ultimoIdPago = Convert.ToInt32(reader["id"]);
                                lblClienteNS.Text = $"{reader["nombre"]} {reader["apellido"]}";
                                comboBox1.Text = reader["nombreActividad"].ToString();
                                txtMontoNS.Enabled = false;
                                txtDescuentoNS.Enabled = false;
                                comboMedPagoNS.Enabled = false;
                                dateFePagoNS.Enabled = false;
                                btnImprimirNS.Visible = true;
                                btnImprimirNS.Enabled = true;
                                comboBox1.Enabled = false;
                                btnAgregarActividad.Visible = false;

                                // Seleccionar la actividad en el combo
                                int idActividad = Convert.ToInt32(reader["idActividad"]);
                                foreach (var item in comboBox1.Items)
                                {
                                    if (item is ActividadCombo act && act.Id == idActividad)
                                    {
                                        comboBox1.SelectedItem = act;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("No se encontró el comprobante.", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                                return;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado al consultar el comprobante:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private bool BuscarClientePorDni(int dni, out int id)
        {
            id = 0;
            using (var conn = conexion.Conectar())
            using (var cmd = new MySqlCommand("SELECT id, nombre, apellido, dni FROM Cliente WHERE dni=@dni", conn))
            {
                cmd.Parameters.AddWithValue("@dni", dni);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        id = reader.GetInt32(0);
                        int dni2 = reader.GetInt32(3);
                        lblDniS.Text = lblDniNS.Text = dni2.ToString();
                        lblClienteS.Text = lblClienteNS.Text = $"{reader.GetString(1)} {reader.GetString(2)}";
                        return true;
                    }
                }
            }
            return false;
        }

        private bool EsSocioActivo(int idCliente)
        {
            using (var conn = conexion.Conectar())
            {
                // Verificar si es socio (tiene registro en tabla Socio sin fecha de baja)
                var cmdSocio = new MySqlCommand("SELECT COUNT(*) FROM Socio WHERE id=@id AND fechaBaja IS NULL", conn);
                cmdSocio.Parameters.AddWithValue("@id", idCliente);
                return Convert.ToInt32(cmdSocio.ExecuteScalar()) > 0;
            }
        }

        private void CargarDatosSocio()
        {
            btnAgregarActividad.Visible = false;

            // Buscar la cuota pendiente del socio (solo una)
            DateTime? fechaVencimiento = null;
            decimal? monto = null;

            using (var conn = conexion.Conectar())
            using (var cmd = new MySqlCommand(
                "SELECT fechaVencimiento, monto FROM Cuota WHERE idSocio=@idSocio AND fechaPago IS NULL ORDER BY fechaVencimiento ASC LIMIT 1", conn))
            {
                cmd.Parameters.AddWithValue("@idSocio", idCliente);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        fechaVencimiento = reader.IsDBNull(0) ? (DateTime?)null : reader.GetDateTime(0);
                        monto = reader.IsDBNull(1) ? (decimal?)null : reader.GetDecimal(1);
                    }
                }
            }

            if (fechaVencimiento.HasValue)
            {
                // Calcular diferencia de días respecto a la fecha de pago seleccionada
                int diferenciaDias = (dateFePagoS.Value.Date - fechaVencimiento.Value.Date).Days;
                string estado;
                if (diferenciaDias < 0)
                    estado = $"{fechaVencimiento:dd/MM/yy} ({Math.Abs(diferenciaDias)} días antes)";
                else if (diferenciaDias > 0)
                    estado = $"{fechaVencimiento:dd/MM/yy} ({diferenciaDias} días despues)";
                else
                    estado = $"{fechaVencimiento:dd/MM/yy} (Vence Hoy)";
                lblEstadoS.Text = estado;
                if (monto.HasValue)
                    txtMontoS.Text = monto.Value.ToString("0.00");
            }
            else
            {
                lblEstadoS.Text = "No hay cuota pendiente";
                txtMontoS.Text = "";
            }

            comboMedPagoS.Items.Clear();
            comboMedPagoS.Items.AddRange(new string[] { "Efectivo", "Credito", "Debito" });
            comboMedPagoS.SelectedIndex = 0;
            txtCuotasS.Visible = false;
            lblCuotasS.Visible = false;
            comboMedPagoS.SelectedIndexChanged += (s, e) =>
            {
                bool esCredito = comboMedPagoS.SelectedItem.ToString() == "Credito";
                txtCuotasS.Visible = lblCuotasS.Visible = esCredito;
            };

            // Actualizar el label cada vez que cambia la fecha de pago
            dateFePagoS.ValueChanged -= FechaPagoS_ValueChanged;
            dateFePagoS.ValueChanged += FechaPagoS_ValueChanged;
        }

        private void FechaPagoS_ValueChanged(object sender, EventArgs e)
        {
            CargarDatosSocio();
        }

        private void CargarDatosNoSocio()
        {
            btnAgregarActividad.Visible = true;
            comboMedPagoNS.Items.Clear();
            comboMedPagoNS.Items.AddRange(new string[] { "Efectivo", "Credito", "Debito" });
            comboMedPagoNS.SelectedIndex = 0;
            txtCuotasNS.Visible = false;
            lblCuotasNS.Visible = false;
            comboMedPagoNS.SelectedIndexChanged += (s, e) =>
            {
                bool esCredito = comboMedPagoNS.SelectedItem.ToString() == "Credito";
                txtCuotasNS.Visible = lblCuotasNS.Visible = esCredito;
            };
            using (var conn = conexion.Conectar())
            using (var cmd = new MySqlCommand("SELECT id, nombre, costo FROM Actividad", conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    comboBox1.Items.Add(new ActividadCombo
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Precio = reader.GetDecimal(2)
                    });
                }
            }
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "Id";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox1.Enabled = true;
        }

        private void CargarActividades()
        {
            comboBox1.Items.Clear();

            using (var conn = conexion.Conectar())
            using (var cmd = new MySqlCommand("SELECT id, nombre FROM Actividad", conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    comboBox1.Items.Add(new ActividadCombo
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Nombre = reader["nombre"].ToString()
                    });
                }
            }
        }

        public class ActividadCombo
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public decimal Precio { get; set; }

            public override string ToString()
            {
                return Nombre;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is not ActividadCombo actividad) return;
            using (var conn = conexion.Conectar())
            using (var cmd = new MySqlCommand("SELECT costo FROM Actividad WHERE id=@id", conn))
            {
                cmd.Parameters.AddWithValue("@id", actividad.Id);
                var result = cmd.ExecuteScalar();
                if (result != null)
                    txtMontoNS.Text = result.ToString();
            }
        }

        private void txtMontoNS_Leave(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null) return;
            int idActividad = ((dynamic)comboBox1.SelectedItem).Id;
            using (var conn = conexion.Conectar())
            using (var cmd = new MySqlCommand("SELECT costo FROM Actividad WHERE id=@id", conn))
            {
                cmd.Parameters.AddWithValue("@id", idActividad);
                var result = cmd.ExecuteScalar();
                if (result != null && decimal.TryParse(txtMontoNS.Text, out decimal nuevoMonto))
                {
                    decimal montoOriginal = Convert.ToDecimal(result);
                    if (nuevoMonto != montoOriginal)
                    {
                        var res = MessageBox.Show("¿Desea actualizar el monto de la actividad en la tabla?", "Actualizar monto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.Yes)
                        {
                            using (var cmdUpdate = new MySqlCommand("UPDATE Actividad SET costo=@costo WHERE id=@id", conn))
                            {
                                cmdUpdate.Parameters.AddWithValue("@costo", nuevoMonto);
                                cmdUpdate.Parameters.AddWithValue("@id", idActividad);
                                cmdUpdate.ExecuteNonQuery();
                                MessageBox.Show("Monto actualizado en la tabla Actividad.", "Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
        }

        private void btnAgregarActividad_Click(object sender, EventArgs e)
        {
            var form = new FormRegistrarActividad();
            form.ShowDialog();

            comboBox1.Items.Clear();
            using (var conn = conexion.Conectar())
            using (var cmd = new MySqlCommand("SELECT id, nombre, costo FROM Actividad", conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    comboBox1.Items.Add(new ActividadCombo
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Precio = reader.GetDecimal(2)
                    });
                }
            }
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "Id";
        }

        private decimal? CalcularTotalDescuentoSocio()
        {
            if (decimal.TryParse(txtMontoS.Text, out decimal monto))
            {
                decimal descuento = 0;
                bool descuentoValido = false;

                if (!string.IsNullOrWhiteSpace(txtDescuentoS.Text))
                    descuentoValido = decimal.TryParse(txtDescuentoS.Text, out descuento);

                // Si se ingresó un descuento válido y no está en el rango 0–100, entonces es inválido
                if (descuentoValido && (descuento < 0 || descuento > 100))
                {
                    lblTotalDescuentoNS.Text = "Descuento inválido";
                    return null;
                }

                if (!descuentoValido || descuento == 0)
                {
                    lblTotalDescuentoNS.Text = $"TOTAL A ABONAR: $ {monto:0.00}";
                    return monto;
                }
                else
                {
                    decimal total = monto - (monto * (descuento / 100));
                    lblTotalDescuentoNS.Text = $"TOTAL A ABONAR: $ {total:0.00}";
                    return total;
                }
            }
            else
            {
                lblTotalDescuentoNS.Text = "Monto inválido";
                return null;
            }
        }

        private decimal? CalcularTotalDescuentoNoSocio()
        {
            if (decimal.TryParse(txtMontoNS.Text, out decimal monto))
            {
                decimal descuento = 0;
                bool descuentoValido = false;

                if (!string.IsNullOrWhiteSpace(txtDescuentoNS.Text))
                    descuentoValido = decimal.TryParse(txtDescuentoNS.Text, out descuento);

                if (descuentoValido && (descuento < 0 || descuento > 100))
                {
                    lblTotalDescuentoNS.Text = "Descuento inválido";
                    return null;
                }

                // Si el descuento es 0 o no se ingresó nada válido, muestro el monto sin restar nada
                if (!descuentoValido || descuento == 0)
                {
                    lblTotalDescuentoNS.Text = $"TOTAL A ABONAR: $ {monto:0.00}";
                    return monto;
                }
                else
                {
                    decimal total = monto - (monto * (descuento / 100));
                    lblTotalDescuentoNS.Text = $"TOTAL A ABONAR: $ {total:0.00}";
                    return total;
                }
            }
            else
            {
                lblTotalDescuentoNS.Text = "Monto inválido";
                return null;
            }
        }

        private int ObtenerIdSocioPorIdCliente(int idCliente)
        {
            using (var conn = conexion.Conectar())
            using (var cmd = new MySqlCommand("SELECT id FROM Socio WHERE id=@idCliente AND fechaBaja IS NULL", conn))
            {
                cmd.Parameters.AddWithValue("@idCliente", idCliente);
                var result = cmd.ExecuteScalar();
                if (result != null)
                    return Convert.ToInt32(result);
                else
                    throw new Exception("No se encontró el registro de Socio activo para este cliente.");
            }
        }

        private int ObtenerIdNoSocioPorIdCliente(int idCliente)
        {
            using (var conn = conexion.Conectar())
            using (var cmd = new MySqlCommand("SELECT id FROM NoSocio WHERE id=@id", conn))
            {
                cmd.Parameters.AddWithValue("@id", idCliente);
                var result = cmd.ExecuteScalar();
                if (result != null)
                    return Convert.ToInt32(result);
                else
                    throw new Exception("No se encontró el registro de NoSocio para este cliente.");
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string resumen;
            if (esSocio)
            {
                if (!ValidarPagoSocio()) return;
                resumen = $"\nCliente: {lblClienteS.Text}\nDNI: {lblDniS.Text}\nFecha: {dateFePagoS.Value.ToShortDateString()}\nMedio: {comboMedPagoS.Text}\n\n{lblTotalDescuentoS.Text}";
            }
            else
            {
                if (!ValidarPagoNoSocio()) return;
                resumen = $"\nCliente: {lblClienteNS.Text}\nDNI: {lblDniNS.Text}\nActividad: {comboBox1.Text}\nFecha: {dateFePagoNS.Value.ToShortDateString()}\nMedio: {comboMedPagoNS.Text}\n\n{lblTotalDescuentoNS.Text}";
            }

            DialogResult dr = MessageBox.Show(
                $"¿Desea confirmar y facturar el siguiente pago?\n\n{resumen}",
                "Confirmar Facturación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dr != DialogResult.Yes)
                return;

            if (esSocio)
            {
                decimal? montoTotal = CalcularTotalDescuentoSocio();
                if (montoTotal == null)
                {
                    MessageBox.Show("No se puede guardar el pago. Monto o descuento inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int idSocio = ObtenerIdSocioPorIdCliente(idCliente);

                using (var conn = conexion.Conectar())
                {
                    var cmd = new MySqlCommand(@"INSERT INTO Cuota 
                    (idSocio, fechaPago, monto, medioPago, cantidadCuotas, descuento, montoTotal, fechaVencimiento, comprobante)
                    VALUES (@idSocio, @fechaPago, @monto, @medioPago, @cuotas, @descuento, @montoTotal, @fechaVenc, @comprobante)", conn);
                    cmd.Parameters.AddWithValue("@idSocio", idSocio);
                    cmd.Parameters.AddWithValue("@fechaPago", dateFePagoS.Value);
                    cmd.Parameters.AddWithValue("@monto", decimal.Parse(txtMontoS.Text));
                    cmd.Parameters.AddWithValue("@medioPago", comboMedPagoS.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@cuotas", comboMedPagoS.SelectedItem.ToString() == "Credito" ? int.Parse(txtCuotasS.Text) : 1);
                    cmd.Parameters.AddWithValue("@descuento", string.IsNullOrWhiteSpace(txtDescuentoS.Text) ? 0 : decimal.Parse(txtDescuentoS.Text));
                    cmd.Parameters.AddWithValue("@montoTotal", montoTotal.Value);
                    cmd.Parameters.AddWithValue("@fechaVenc", dateFePagoS.Value.AddMonths(1));
                    cmd.Parameters.AddWithValue("@comprobante", DBNull.Value);
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "SELECT LAST_INSERT_ID()";
                    int idCuota = Convert.ToInt32(cmd.ExecuteScalar());
                    string comprobante = $"100{idCuota}";
                    var cmdUpdate = new MySqlCommand("UPDATE Cuota SET comprobante=@comprobante WHERE id=@id", conn);
                    cmdUpdate.Parameters.AddWithValue("@comprobante", comprobante);
                    cmdUpdate.Parameters.AddWithValue("@id", idCuota);
                    cmdUpdate.ExecuteNonQuery();
                    ultimoIdPago = idCuota;

                    // REGISTRAR PRÓXIMA CUOTA PENDIENTE
                    var cmdProx = new MySqlCommand(
                        @"INSERT INTO Cuota 
                        (idSocio, fechaVencimiento, monto, estado)
                        VALUES (@idSocio, @fechaVenc, @monto, 'Pendiente')", conn);

                    cmdProx.Parameters.AddWithValue("@idSocio", idCliente);
                    cmdProx.Parameters.AddWithValue("@fechaVenc", dateFePagoS.Value.AddMonths(1));
                    cmdProx.Parameters.AddWithValue("@monto", decimal.Parse(txtMontoS.Text));
                    cmdProx.ExecuteNonQuery();
                }
                MessageBox.Show("Pago registrado correctamente. Se abrirá la vista previa del comprobante.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnImprimirS_Click(sender, e);
                this.Close();
            }
            else
            {
                decimal? montoTotal = CalcularTotalDescuentoNoSocio();
                if (montoTotal == null)
                {
                    MessageBox.Show("No se puede guardar el pago. Monto o descuento inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int idNoSocio = ObtenerIdNoSocioPorIdCliente(idCliente);
                using (var conn = conexion.Conectar())
                {
                    var cmd = new MySqlCommand(@"INSERT INTO RegistroActividad 
                    (idNoSocio, idActividad, fechaPago, monto, medioPago, cantidadCuotas, descuento, montoTotal, comprobante)
                    VALUES (@idNoSocio, @idActividad, @fechaPago, @monto, @medioPago, @cuotas, @descuento, @montoTotal, @comprobante)", conn);
                    cmd.Parameters.AddWithValue("@idNoSocio", idNoSocio);
                    cmd.Parameters.AddWithValue("@idActividad", ((dynamic)comboBox1.SelectedItem).Id);
                    cmd.Parameters.AddWithValue("@fechaPago", dateFePagoNS.Value);
                    cmd.Parameters.AddWithValue("@monto", decimal.Parse(txtMontoNS.Text));
                    cmd.Parameters.AddWithValue("@medioPago", comboMedPagoNS.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@cuotas", comboMedPagoNS.SelectedItem.ToString() == "Credito" ? int.Parse(txtCuotasNS.Text) : 1);
                    cmd.Parameters.AddWithValue("@descuento", string.IsNullOrWhiteSpace(txtDescuentoNS.Text) ? 0 : decimal.Parse(txtDescuentoNS.Text));
                    cmd.Parameters.AddWithValue("@montoTotal", montoTotal);
                    cmd.Parameters.AddWithValue("@comprobante", DBNull.Value);
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "SELECT LAST_INSERT_ID()";
                    int idReg = Convert.ToInt32(cmd.ExecuteScalar());
                    string comprobante = $"200{idReg}";
                    var cmdUpdate = new MySqlCommand("UPDATE RegistroActividad SET comprobante=@comprobante WHERE id=@id", conn);
                    cmdUpdate.Parameters.AddWithValue("@comprobante", comprobante);
                    cmdUpdate.Parameters.AddWithValue("@id", idReg);
                    cmdUpdate.ExecuteNonQuery();
                    ultimoIdPago = idReg;
                }
                MessageBox.Show("Pago registrado correctamente. Se abrirá la vista previa del comprobante.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnImprimirNS_Click(sender, e);
                this.Close();
            }
        }

        private bool ValidarPagoSocio()
        {
            if (!decimal.TryParse(txtMontoS.Text, out decimal monto) || monto <= 0)
            {
                MessageBox.Show("Ingrese un monto válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (comboMedPagoS.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un medio de pago.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (comboMedPagoS.SelectedItem.ToString() == "Credito" &&
                (!int.TryParse(txtCuotasS.Text, out int cuotas) || cuotas < 1))
            {
                MessageBox.Show("Ingrese la cantidad de cuotas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!string.IsNullOrWhiteSpace(txtDescuentoS.Text) &&
                 (!decimal.TryParse(txtDescuentoS.Text, out decimal descS) || descS < 0 || descS > 100))
            {
                MessageBox.Show("El descuento debe estar entre 0 y 100.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (dateFePagoS.Value.Date > DateTime.Today)
            {
                MessageBox.Show("La fecha de pago no puede ser futura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool ValidarPagoNoSocio()
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una actividad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!decimal.TryParse(txtMontoNS.Text, out decimal monto) || monto <= 0)
            {
                MessageBox.Show("Ingrese un monto válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (comboMedPagoNS.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un medio de pago.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (comboMedPagoNS.SelectedItem.ToString() == "Credito" &&
                (!int.TryParse(txtCuotasNS.Text, out int cuotas) || cuotas < 1))
            {
                MessageBox.Show("Ingrese la cantidad de cuotas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!string.IsNullOrWhiteSpace(txtDescuentoS.Text) &&
                (!decimal.TryParse(txtDescuentoS.Text, out decimal descS) || descS < 0 || descS > 100))
            {
                MessageBox.Show("El descuento debe estar entre 0 y 100.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (dateFePagoNS.Value.Date > DateTime.Today)
            {
                MessageBox.Show("La fecha de pago no puede ser futura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una actividad válida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "¿Está seguro que desea eliminar este comprobante? Esta acción no se puede revertir.",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            if (esConsulta)
            {
                if (consultaCentro == "100")
                {
                    var adv = MessageBox.Show(
                        "Al eliminar este pago, la próxima cuota pendiente (si existe) también será eliminada. ¿Desea continuar?",
                        "Advertencia para socios",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (adv != DialogResult.Yes)
                        return;

                    using (var conn = conexion.Conectar())
                    {
                        // Eliminar próxima cuota pendiente
                        var cmdDelProx = new MySqlCommand(
                            @"DELETE FROM Cuota 
                            WHERE idSocio = @idSocio 
                            AND estado = 'Pendiente'
                            AND fechaVencimiento = (SELECT DATE_ADD(MAX(fechaPago), INTERVAL 1 MONTH) 
                            FROM Cuota 
                            WHERE idSocio = @idSocio)", conn);
                        cmdDelProx.Parameters.AddWithValue("@idSocio", idCliente);
                        int proxDeleted = cmdDelProx.ExecuteNonQuery();

                        if (proxDeleted > 0)
                        {
                            MessageBox.Show($"Se eliminó {proxDeleted} cuota pendiente asociada",
                                            "Advertencia",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                        }

                        // Eliminar el pago actual
                        var cmdClean = new MySqlCommand(
                            @"DELETE FROM Cuota 
                          WHERE id = @id", conn);
                        cmdClean.Parameters.AddWithValue("@id", ultimoIdPago);
                        int rows = cmdClean.ExecuteNonQuery();

                        if (rows > 0)
                            MessageBox.Show("El pago fue eliminado correctamente.", "Borrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("No se encontró comprobante para borrar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (consultaCentro == "200")
                {
                    using (var conn = conexion.Conectar())
                    using (var cmd = new MySqlCommand("DELETE FROM RegistroActividad WHERE id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", ultimoIdPago);
                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                            MessageBox.Show("Comprobante de no socio eliminado.", "Borrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("No se encontró comprobante para borrar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                this.Close();
                return;
            }

            if (esSocio)
            {
                var adv = MessageBox.Show(
                    "Al eliminar el último pago, la próxima cuota pendiente (si existe) también será eliminada. ¿Desea continuar?",
                    "Advertencia para socios",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (adv != DialogResult.Yes)
                    return;

                using (var conn = conexion.Conectar())
                {
                    int idUltimaCuota = 0;
                    using (var cmdFind = new MySqlCommand(
                        "SELECT id FROM Cuota WHERE idSocio = @idSocio AND fechaPago IS NOT NULL ORDER BY fechaPago DESC LIMIT 1", conn))
                    {
                        cmdFind.Parameters.AddWithValue("@idSocio", idCliente);
                        var result = cmdFind.ExecuteScalar();
                        if (result != null)
                            idUltimaCuota = Convert.ToInt32(result);
                    }

                    if (idUltimaCuota == 0)
                    {
                        MessageBox.Show("No se encontró pago para borrar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Eliminar próxima cuota pendiente
                    var cmdDelProx = new MySqlCommand(
                        @"DELETE FROM Cuota 
                        WHERE idSocio = @idSocio 
                        AND fechaPago IS NULL 
                        AND id > @id", conn);
                    cmdDelProx.Parameters.AddWithValue("@idSocio", idCliente);
                    cmdDelProx.Parameters.AddWithValue("@id", idUltimaCuota);
                    cmdDelProx.ExecuteNonQuery();

                    // Eliminar el pago actual
                    var cmdClean = new MySqlCommand(
                        @"DELETE FROM Cuota 
                        WHERE id = @id", conn);
                    cmdClean.Parameters.AddWithValue("@id", idUltimaCuota);
                    int rows = cmdClean.ExecuteNonQuery();

                    if (rows > 0)
                        MessageBox.Show("El pago fue eliminado correctamente.", "Borrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("No se encontró pago para borrar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                using (var conn = conexion.Conectar())
                using (var cmd = new MySqlCommand(
                    "DELETE FROM RegistroActividad WHERE id = (SELECT id FROM (SELECT id FROM RegistroActividad WHERE idNoSocio = @idNoSocio ORDER BY fechaPago DESC LIMIT 1) AS t)", conn))
                {
                    cmd.Parameters.AddWithValue("@idNoSocio", idCliente);
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                        MessageBox.Show("Último pago de no socio eliminado.", "Borrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("No se encontró pago para borrar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            this.Close();
        }

        private void btnImprimirS_Click(object sender, EventArgs e)
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.DefaultPageSettings.PaperSize = new PaperSize("Recibo", 280, 350);
            printDoc.PrintPage += ComprobanteSocio;

            PrintPreviewDialog preview = new PrintPreviewDialog
            {
                Document = printDoc,
                WindowState = FormWindowState.Maximized,
                PrintPreviewControl = { Zoom = 1.0 }
            };

            preview.ShowDialog();
        }

        private void btnImprimirNS_Click(object sender, EventArgs e)
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.DefaultPageSettings.PaperSize = new PaperSize("Recibo", 280, 380);
            printDoc.PrintPage += ComprobanteNoSocio;

            PrintPreviewDialog preview = new PrintPreviewDialog
            {
                Document = printDoc,
                WindowState = FormWindowState.Maximized,
                PrintPreviewControl = { Zoom = 1.0 }
            };

            preview.ShowDialog();
        }

        private void ComprobanteSocio(object sender, PrintPageEventArgs e)
        {
            int y = 10;
            int left = 10;
            Font fontTitle = new Font("Consolas", 12, FontStyle.Bold);
            Font fontBody = new Font("Consolas", 10, FontStyle.Regular);
            Font fontBody2 = new Font("Consolas", 8, FontStyle.Regular);
            Font fontBold = new Font("Consolas", 10, FontStyle.Bold);
            Font fontBold2 = new Font("Consolas", 12, FontStyle.Bold);

            // Logo
            Image logo = Properties.Resources.ClubIcon;
            e.Graphics.DrawImage(logo, 210, y, 60, 60);


            // Datos del club
            e.Graphics.DrawString("CLUB DEPORTIVO", fontBold2, Brushes.Black, left, y);
            y += 22;
            e.Graphics.DrawString("Av. San Martin 1234 - Ciudad", fontBody2, Brushes.Black, left, y);
            y += 18;
            e.Graphics.DrawString("CUIT: 30-12345678-9", fontBody2, Brushes.Black, left, y);
            y += 18;
            e.Graphics.DrawString("Tel: (011) 1234-5678", fontBody2, Brushes.Black, left, y);
            y += 18;

            // Línea separadora
            e.Graphics.DrawString("----------------------------------------", fontBody, Brushes.Black, 0, y);
            y += 18;

            // Datos del comprobante
            e.Graphics.DrawString("RECIBO DE PAGO", fontBold, Brushes.Black, left, y);
            y += 20;
            e.Graphics.DrawString($"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm}", fontBody, Brushes.Black, left, y);
            y += 18;
            e.Graphics.DrawString($"Comprobante N°: 100-{ultimoIdPago}", fontBody, Brushes.Black, left, y);
            y += 18;
            e.Graphics.DrawString($"Socio: {lblClienteS.Text}", fontBody, Brushes.Black, left, y);
            y += 18;
            e.Graphics.DrawString($"DNI: {lblDniS.Text}", fontBody, Brushes.Black, left, y);
            y += 18;
            e.Graphics.DrawString($"Concepto:...........[Acceso Total]", fontBody, Brushes.Black, left, y);
            y += 18;
            e.Graphics.DrawString($"Monto original:.... $ {txtMontoS.Text}", fontBody, Brushes.Black, left, y);
            y += 18;
            e.Graphics.DrawString($"Descuento: {txtDescuentoS.Text}% ", fontBody, Brushes.Black, left, y);
            y += 18;
            decimal? total = CalcularTotalDescuentoSocio();
            // Línea separadora
            e.Graphics.DrawString("----------------------------------------", fontBody, Brushes.Black, 0, y);
            y += 18;
            e.Graphics.DrawString($"TOTAL A ABONAR: $ {total:0.00}", fontBold2, Brushes.Black, left, y);
            y += 25;
            e.Graphics.DrawString($"Medio de pago: {comboMedPagoS.Text}", fontBody, Brushes.Black, left, y);
            y += 18;
            e.Graphics.DrawString($"Estado: PAGADO", fontBold, Brushes.Black, left, y);
            y += 18;

            // Línea separadora
            e.Graphics.DrawString("----------------------------------------", fontBody, Brushes.Black, 0, y);
            y += 18;

            // Pie
            e.Graphics.DrawString("¡Gracias por su pago!", fontBold2, Brushes.Black, left + 30, y);
        }
        private void ComprobanteNoSocio(object sender, PrintPageEventArgs e)
        {
            int y = 10;
            int left = 10;
            Font fontTitle = new Font("Consolas", 12, FontStyle.Bold);
            Font fontBody = new Font("Consolas", 10, FontStyle.Regular);
            Font fontBody2 = new Font("Consolas", 8, FontStyle.Regular);
            Font fontBold = new Font("Consolas", 10, FontStyle.Bold);
            Font fontBold2 = new Font("Consolas", 12, FontStyle.Bold);

            // Logo
            Image logo = Properties.Resources.ClubIcon;
            e.Graphics.DrawImage(logo, 210, y, 60, 60);


            // Datos del club
            e.Graphics.DrawString("CLUB DEPORTIVO", fontBold2, Brushes.Black, left, y);
            y += 22;
            e.Graphics.DrawString("Av. San Martin 1234 - Ciudad", fontBody2, Brushes.Black, left, y);
            y += 18;
            e.Graphics.DrawString("CUIT: 30-12345678-9", fontBody2, Brushes.Black, left, y);
            y += 18;
            e.Graphics.DrawString("Tel: (011) 1234-5678", fontBody2, Brushes.Black, left, y);
            y += 18;

            // Línea separadora
            e.Graphics.DrawString("----------------------------------------", fontBody, Brushes.Black, 0, y);
            y += 18;

            // Datos del comprobante
            e.Graphics.DrawString("RECIBO DE PAGO", fontBold, Brushes.Black, left, y);
            y += 20;
            e.Graphics.DrawString($"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm}", fontBody, Brushes.Black, left, y);
            y += 18;
            e.Graphics.DrawString($"Comprobante N°: 200-{ultimoIdPago}", fontBody, Brushes.Black, left, y);
            y += 18;
            e.Graphics.DrawString($"No Socio: {lblClienteNS.Text}", fontBody, Brushes.Black, left, y);
            y += 18;
            e.Graphics.DrawString($"DNI: {lblDniNS.Text}", fontBody, Brushes.Black, left, y);
            y += 18;
            e.Graphics.DrawString($"Concepto:...........{comboBox1.Text}", fontBody, Brushes.Black, left, y);
            y += 18;
            e.Graphics.DrawString($"Monto original:.....$ {txtMontoNS.Text}", fontBody, Brushes.Black, left, y);
            y += 18;
            e.Graphics.DrawString($"Descuento: {txtDescuentoNS.Text}% ", fontBody, Brushes.Black, left, y);
            y += 18;
            decimal? total = CalcularTotalDescuentoNoSocio();
            // Línea separadora
            e.Graphics.DrawString("----------------------------------------", fontBody, Brushes.Black, 0, y);
            y += 18;
            e.Graphics.DrawString($"TOTAL A ABONAR: $ {total:0.00}", fontBold2, Brushes.Black, left, y);
            y += 25;
            e.Graphics.DrawString($"Medio de pago: {comboMedPagoNS.Text}", fontBody, Brushes.Black, left, y);
            y += 18;
            e.Graphics.DrawString($"Estado: PAGADO", fontBold, Brushes.Black, left, y);
            y += 18;

            // Línea separadora
            e.Graphics.DrawString("----------------------------------------", fontBody, Brushes.Black, 0, y);
            y += 18;

            // Pie
            e.Graphics.DrawString("¡Gracias por su pago!", fontBold2, Brushes.Black, left + 30, y);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
