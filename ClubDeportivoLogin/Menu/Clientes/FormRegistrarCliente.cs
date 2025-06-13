using MySql.Data.MySqlClient;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;

namespace ClubDeportivoLogin
{
    public partial class FormRegistrarCliente : Form
    {
        private Conexion conexion = new Conexion();
        private int dniCliente;

        public FormRegistrarCliente(int dni)
        {
            InitializeComponent();
            dniCliente = dni;
            InitializeEventHandlers();

            // Mostrar mensaje inicial sobre el DNI
            using (var conn = conexion.Conectar())
            {
                bool existe = VerificarExistenciaDNI(conn, dni);
                if (existe)
                {
                    string tipoCliente = EsSocioActivo() ? "SOCIO" : "NO SOCIO";
                    string nombreCompleto = ObtenerNombreCompletoCliente(conn);
                    MessageBox.Show($"DNI encontrado: {tipoCliente} - {nombreCompleto}",
                                  "Cliente existente",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                }
                else
                {
                    var respuesta = MessageBox.Show($"El DNI {dni} no está registrado. ¿Desea crear un nuevo cliente?",
                                                  "Nuevo cliente",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

                    if (respuesta == DialogResult.No)
                    {
                        this.Close();
                        return;
                    }
                }
            }

            comboMedPago.Items.AddRange(new string[] { "Efectivo", "Credito", "Debito" });

            comboMedPago.SelectedIndexChanged += ComboMedPago_SelectedIndexChanged;

            dtpInscripcion.Enabled = false;
            dtpVencimiento.Enabled = false;

            txtCuotas.Visible = false;
            lblCuotas.Visible = false;

            txtDescuento.TextChanged += txtDescuento_TextChanged;
            txtMonto.TextChanged += txtDescuento_TextChanged;

            dateBaja.ValueChanged += dateBaja_ValueChanged;
        }

        private bool VerificarExistenciaDNI(MySqlConnection conn, int dni)
        {
            using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM Cliente WHERE dni=@dni", conn))
            {
                cmd.Parameters.AddWithValue("@dni", dni);
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }
        private string ObtenerNombreCompletoCliente(MySqlConnection conn)
        {
            using (var cmd = new MySqlCommand("SELECT CONCAT(nombre, ' ', apellido) FROM Cliente WHERE dni=@dni", conn))
            {
                cmd.Parameters.AddWithValue("@dni", dniCliente);
                var resultado = cmd.ExecuteScalar();
                return resultado != null ? resultado.ToString() : "Nombre no disponible";
            }
        }

        private void ComboMedPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCuotas.Visible = comboMedPago.SelectedItem.ToString() == "Credito";
            lblCuotas.Visible = comboMedPago.SelectedItem.ToString() == "Credito";
        }

        private void InitializeEventHandlers()
        {
            // Validar mientras escribe
            txtNombre.KeyPress += SoloLetras_KeyPress;
            txtApellido.KeyPress += SoloLetras_KeyPress;
            txtTelefono.KeyPress += SoloNumeros_KeyPress;
            txtCuotas.KeyPress += SoloNumeros_KeyPress;
            txtDescuento.KeyPress += SoloNumerosDecimales_KeyPress;
            txtMonto.KeyPress += SoloNumerosDecimales_KeyPress;

            // Autoformato
            txtTelefono.Leave += FormatearTelefono;
        }

        private void SoloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) &&
                e.KeyChar != ' ' && e.KeyChar != '-' && e.KeyChar != '\'')
            {
                e.Handled = true;
            }
        }

        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void SoloNumerosDecimales_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            // Solo permitir una coma
            if (e.KeyChar == ',' && ((TextBox)sender).Text.Contains(','))
            {
                e.Handled = true;
            }
        }

        private void FormatearTelefono(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTelefono.Text)) return;

            string telefono = new string(txtTelefono.Text.Where(char.IsDigit).ToArray());

            if (telefono.Length == 10)
            {
                txtTelefono.Text = string.Format("{0:(####) ##-####}", double.Parse(telefono));
            }
            else
            {
                txtTelefono.Text = telefono;
            }
        }
        private void FormatearCampos()
        {
            string formato = "dd/MM/yyyy";
            dtpFechaNacimiento.Format = DateTimePickerFormat.Custom;
            dtpFechaNacimiento.CustomFormat = formato;
            dtpFechaNacimiento.Value = DateTime.Today.AddYears(-18);
            dtpInscripcion.Format = DateTimePickerFormat.Custom;
            dtpInscripcion.CustomFormat = formato;
            dtpVencimiento.Format = DateTimePickerFormat.Custom;
            dtpVencimiento.CustomFormat = formato;
            dateBaja.Format = DateTimePickerFormat.Custom;
            dateBaja.CustomFormat = formato;
            dateBaja.ShowCheckBox = true;
            dateBaja.Checked = false;
            dtpInscripcion.Enabled = false;
            dtpVencimiento.Enabled = false;
            lblDni.Text = dniCliente.ToString();
            tabPage1.Visible = true;
            dateBaja.Visible = false;
            lblFeBaja.Visible = false;
            dateBaja.Checked = false;
        }

        private void FormRegistrarCliente_Load(object sender, EventArgs e)
        {
            FormatearCampos();
            tabControl1.SelectedTab = tabPage1;

            bool clienteExiste = CargarDatosCliente();
            bool socioActivo = clienteExiste && EsSocioActivo();

            if (socioActivo)
            {
                dateBaja.Visible = true;
                lblFeBaja.Visible = true;
                chkAsociarse.Visible = false;
                lblTipoCliente.Text = "MODIFICAR - SOCIO";
                lblTipoCliente.ForeColor = Color.Blue;
                CargarDatosSocio();
                tabPage2.Parent = tabControl1;
            }
            else
            {
                chkAsociarse.Visible = true;
                chkAsociarse.Checked = false;
                lblTipoCliente.Text = clienteExiste ? "MODIFICAR - NO SOCIO" : "REGISTRAR - NO SOCIO";
                lblTipoCliente.ForeColor = Color.Red;
                tabPage2.Parent = null;
            }
        }

        private decimal CalcularTotalConDescuento(decimal monto)
        {
            decimal descuento = 0;
            decimal total = monto;

            if (!string.IsNullOrWhiteSpace(txtDescuento.Text))
            {
                if (decimal.TryParse(txtDescuento.Text, out descuento))
                {
                    if (descuento < 0 || descuento > 100)
                    {
                        MessageBox.Show("El descuento debe estar entre 0 y 100%",
                                      "Descuento inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtDescuento.Focus();
                        txtDescuento.Text = "0";
                        return monto;
                    }
                    total = monto - (monto * (descuento / 100));
                }
                else
                {
                    MessageBox.Show("Ingrese un valor numérico válido para el descuento",
                                  "Error en descuento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDescuento.Focus();
                    txtDescuento.Text = "0";
                    return monto;
                }
            }

            lblTotalDescuento.Text = $"TOTAL COBRADO: $ {total.ToString("0.00")}";
            return total;
        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtMonto.Text) &&
                    !string.IsNullOrWhiteSpace(txtDescuento.Text))
                {
                    if (decimal.TryParse(txtMonto.Text, out decimal monto) &&
                        decimal.TryParse(txtDescuento.Text, out _))
                    {
                        CalcularTotalConDescuento(monto);
                    }
                }
                else if (!string.IsNullOrWhiteSpace(txtMonto.Text))
                {
                    if (decimal.TryParse(txtMonto.Text, out decimal monto))
                    {
                        lblTotalDescuento.Text = $"TOTAL COBRADO: $ {monto.ToString("0.00")}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al calcular descuento: {ex.Message}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CargarDatosCliente()
        {
            using (var conn = conexion.Conectar())
            using (var cmd = new MySqlCommand(
                "SELECT nombre, apellido, direccion, telefono, fechaNacimiento, aptoFisico, asociarse " +
                "FROM Cliente " +
                "WHERE dni=@dni", conn))
            {
                cmd.Parameters.AddWithValue("@dni", dniCliente);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtNombre.Text = reader.IsDBNull(0) ? "" : reader.GetString(0);
                        txtApellido.Text = reader.IsDBNull(1) ? "" : reader.GetString(1);
                        txtDireccion.Text = reader.IsDBNull(2) ? "" : reader.GetString(2);
                        txtTelefono.Text = reader.IsDBNull(3) ? "" : reader.GetString(3);
                        dtpFechaNacimiento.Value = reader.IsDBNull(4) ? DateTime.Today.AddYears(-18) : reader.GetDateTime(4);
                        chkAptoFisico.Checked = !reader.IsDBNull(5) && reader.GetBoolean(5);
                        chkAsociarse.Checked = !reader.IsDBNull(6) && reader.GetBoolean(6);
                        return true;
                    }
                }
            }
            return false;
        }

        private void CargarDatosSocio()
        {
            using (var conn = conexion.Conectar())
            {
                int idCliente = GetClienteId(conn);

                // Variables para almacenar los datos leídos
                DateTime? fechaInscripcion = null, fechaVencimiento = null, fechaBaja = null;
                int? numeroCarnet = null, cantidadCuotas = null;
                bool? carnetEntregado = null;
                decimal? monto = null, descuento = null, montoTotal = null;
                string medioPago = null;

                using (var cmd = new MySqlCommand(
                    @"SELECT s.fechaInscripcion, s.fechaVencimientoCuota, s.numeroCarnet, 
                    s.carnetEntregado, s.fechaBaja,
                    c.monto, c.medioPago, c.cantidadCuotas, c.descuento, c.montoTotal
                    FROM Socio s
                    LEFT JOIN Cuota c ON s.id = c.idSocio AND c.fechaPago IS NOT NULL
                    WHERE s.id=@id
                    ORDER BY c.fechaPago DESC
                    LIMIT 1", conn))
                {
                    cmd.Parameters.AddWithValue("@id", idCliente);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            fechaInscripcion = reader.IsDBNull(0) ? null : reader.GetDateTime(0);
                            fechaVencimiento = reader.IsDBNull(1) ? null : reader.GetDateTime(1);
                            numeroCarnet = reader.IsDBNull(2) ? null : reader.GetInt32(2);
                            carnetEntregado = reader.IsDBNull(3) ? null : reader.GetBoolean(3);
                            fechaBaja = reader.IsDBNull(4) ? null : reader.GetDateTime(4);
                            monto = reader.IsDBNull(5) ? null : reader.GetDecimal(5);
                            medioPago = reader.IsDBNull(6) ? null : reader.GetString(6);
                            cantidadCuotas = reader.IsDBNull(7) ? null : reader.GetInt32(7);
                            descuento = reader.IsDBNull(8) ? null : reader.GetDecimal(8);
                            montoTotal = reader.IsDBNull(9) ? null : reader.GetDecimal(9);
                        }
                    }
                }

                // Ahora que el reader está cerrado, puedes ejecutar otros comandos
                if (fechaInscripcion.HasValue)
                    dtpInscripcion.Value = fechaInscripcion.Value;
                if (fechaVencimiento.HasValue)
                    dtpVencimiento.Value = fechaVencimiento.Value;
                if (numeroCarnet.HasValue)
                    lblNumCarnet.Text = numeroCarnet.Value.ToString();
                if (carnetEntregado.HasValue)
                    chkCarnetEntregado.Checked = carnetEntregado.Value;
                if (fechaBaja.HasValue)
                    dateBaja.Value = fechaBaja.Value;

                // Calcular estado en tiempo real
                string estado = EstadoHelper.CalcularEstadoSocio(idCliente, conn);
                lblEstado.Text = estado;
                lblEstado.ForeColor = estado == "SOCIO MOROSO" ? Color.Red :
                                      (estado == "SOCIO AL DIA" ? Color.Green : Color.Black);

                if (monto.HasValue)
                {
                    txtMonto.Text = monto.Value.ToString("0.00");
                    comboMedPago.SelectedItem = medioPago;
                    txtCuotas.Text = cantidadCuotas?.ToString() ?? "";
                    if (descuento.HasValue)
                        txtDescuento.Text = descuento.Value.ToString("0.00");
                    if (montoTotal.HasValue)
                        lblTotalDescuento.Text = $"TOTAL COBRADO: $ {montoTotal.Value.ToString("0.00")}";
                    BloquearCamposPago();
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposObligatorios() || !ValidarEdad())
                return;

            if (chkAsociarse.Checked && !ValidarDatosPagoSocio())
                return;

            if (dateBaja.Checked && dateBaja.Value < DateTime.Today)
            {
                MessageBox.Show("La fecha de baja no puede ser anterior al día actual.",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();

            string mensaje;
            if (dateBaja.Checked)
            {
                mensaje = $"¿Está seguro que desea dar de baja al socio {nombre} {apellido}?";
            }
            else
            {
                mensaje = chkAsociarse.Checked
                    ? $"¿Registrar a {nombre} {apellido} como socio con pago inicial?"
                    : $"¿Registrar a {nombre} {apellido} como no socio?";
            }

            if (MessageBox.Show(mensaje, "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            using (var conn = conexion.Conectar())
            using (var transaccion = conn.BeginTransaction())
            {
                try
                {
                    int idCliente = GuardarOActualizarCliente(conn);

                    if (dateBaja.Checked)
                    {
                        // Verificar si es socio moroso
                        string estado = EstadoHelper.CalcularEstadoSocio(idCliente, conn);
                        if (estado == "SOCIO MOROSO")
                        {
                            MessageBox.Show("No se puede dar de baja a un socio moroso. Regularice sus cuotas primero.",
                                          "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            transaccion.Rollback();
                            return;
                        }

                        ProcesarBajaSocio(conn, idCliente);
                        transaccion.Commit();
                        MessageBox.Show($"Baja registrada: {nombre} {apellido}",
                                      "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                        return;
                    }

                    if (chkAsociarse.Checked)
                    {
                        ConvertirASocio(conn, idCliente);
                    }
                    else
                    {
                        var insertarNoSocio = new MySqlCommand(
                            "INSERT IGNORE INTO NoSocio (id) VALUES (@id)", conn);
                        insertarNoSocio.Parameters.AddWithValue("@id", idCliente);
                        insertarNoSocio.ExecuteNonQuery();
                    }

                    transaccion.Commit();
                    MessageBox.Show($"Operación realizada con éxito: {nombre} {apellido}",
                                  "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ConvertirASocio(MySqlConnection conn, int id)
        {
            // Eliminar de NoSocio si existe
            var eliminarNoSocio = new MySqlCommand("DELETE FROM NoSocio WHERE id = @id", conn);
            eliminarNoSocio.Parameters.AddWithValue("@id", id);
            eliminarNoSocio.ExecuteNonQuery();

            // Verificar si ya es socio
            var comandoVerificar = new MySqlCommand("SELECT COUNT(*) FROM Socio WHERE id = @id", conn);
            comandoVerificar.Parameters.AddWithValue("@id", id);
            bool existeSocio = Convert.ToInt32(comandoVerificar.ExecuteScalar()) > 0;

            if (existeSocio)
            {
                // Reactivar socio existente
                var reactivar = new MySqlCommand(
                    "UPDATE Socio SET fechaBaja = NULL WHERE id = @id",
                    conn);
                reactivar.Parameters.AddWithValue("@id", id);
                reactivar.ExecuteNonQuery();
            }
            else
            {
                // Nuevo socio
                ObtenerNumeroCarnet(conn);
                var nuevoSocio = new MySqlCommand(
                    @"INSERT INTO Socio 
                    (id, fechaInscripcion, fechaVencimientoCuota, numeroCarnet, carnetEntregado) 
                    VALUES 
                    (@id, @fechaInsc, @fechaVenc, @numCarnet, @carnetEntregado)",
                    conn);

                nuevoSocio.Parameters.AddWithValue("@id", id);
                nuevoSocio.Parameters.AddWithValue("@fechaInsc", DateTime.Today);
                nuevoSocio.Parameters.AddWithValue("@fechaVenc", DateTime.Today.AddMonths(1));
                nuevoSocio.Parameters.AddWithValue("@numCarnet", lblNumCarnet.Text);
                nuevoSocio.Parameters.AddWithValue("@carnetEntregado", chkCarnetEntregado.Checked);
                nuevoSocio.ExecuteNonQuery();

                InsertarCuotaInicial(conn, id);
            }
        }

        private void InsertarCuotaInicial(MySqlConnection conn, int idSocio)
        {
            if (!decimal.TryParse(txtMonto.Text, out decimal monto) || monto <= 0)
            {
                throw new ArgumentException("El monto de la cuota debe ser un valor positivo.");
            }

            string medioPago = comboMedPago.SelectedItem?.ToString() ?? "Efectivo";
            int cuotas = 1;

            if (medioPago == "Credito")
            {
                if (!int.TryParse(txtCuotas.Text, out cuotas) || cuotas < 1)
                {
                    throw new ArgumentException("La cantidad de cuotas debe ser un número mayor a cero.");
                }
            }

            decimal descuento = 0;
            if (!string.IsNullOrWhiteSpace(txtDescuento.Text))
            {
                if (!decimal.TryParse(txtDescuento.Text, out descuento) || descuento < 0 || descuento > 100)
                {
                    throw new ArgumentException("El descuento debe ser un porcentaje entre 0 y 100.");
                }
            }

            decimal montoTotal = CalcularTotalConDescuento(monto);

            // Cuota actual (pagada)
            InsertarCuota(conn, idSocio, DateTime.Today, monto,
                         medioPago, cuotas, DateTime.Today.AddMonths(1),
                         descuento, montoTotal);

            // Próxima cuota (adeudada) - sin descuento
            // Solo si no es pago único
            if (medioPago != "Efectivo" || cuotas > 1)
            {
                InsertarCuota(conn, idSocio, null, monto,
                             null, 0, DateTime.Today.AddMonths(2),
                             0, monto);
            }
        }

        private void ConvertirANoSocio(MySqlConnection conn, int id)
        {
            // Eliminar cuotas futuras adeudadas (no vencidas)
            var eliminarCuotas = new MySqlCommand(
                "DELETE FROM Cuota WHERE idSocio = @id AND fechaPago IS NULL AND fechaVencimiento > CURDATE()",
                conn);
            eliminarCuotas.Parameters.AddWithValue("@id", id);
            eliminarCuotas.ExecuteNonQuery();

            // Actualizar socio (solo si existe)
            var actualizarSocio = new MySqlCommand(
                "UPDATE Socio SET fechaBaja = CURDATE() WHERE id = @id",
                conn);
            actualizarSocio.Parameters.AddWithValue("@id", id);
            actualizarSocio.ExecuteNonQuery();

            // Registrar como no socio SIEMPRE (haya sido socio o no)
            var insertarNoSocio = new MySqlCommand(
                "INSERT IGNORE INTO NoSocio (id) VALUES (@id)",
                conn);
            insertarNoSocio.Parameters.AddWithValue("@id", id);
            insertarNoSocio.ExecuteNonQuery();
        }

        private void BloquearCamposPago()
        {
            txtMonto.Enabled = false;
            comboMedPago.Enabled = false;
            txtCuotas.Enabled = false;
            txtDescuento.Enabled = false;
        }

        private bool EsSocioActivo()
        {
            using (var conn = conexion.Conectar())
            {
                int idCliente = GetClienteId(conn);

                // Verificar si es socio (tiene registro en tabla Socio)
                var cmdSocio = new MySqlCommand("SELECT COUNT(*) FROM Socio WHERE id=@id", conn);
                cmdSocio.Parameters.AddWithValue("@id", idCliente);
                bool esSocio = Convert.ToInt32(cmdSocio.ExecuteScalar()) > 0;

                if (!esSocio) return false;

                // Verificar si no tiene fecha de baja
                var cmdBaja = new MySqlCommand("SELECT fechaBaja FROM Socio WHERE id=@id", conn);
                cmdBaja.Parameters.AddWithValue("@id", idCliente);
                var fechaBaja = cmdBaja.ExecuteScalar();

                return fechaBaja == null || fechaBaja == DBNull.Value;
            }
        }

        private int GetClienteId(MySqlConnection conn)
        {
            using (var cmd = new MySqlCommand(
                "SELECT id FROM Cliente WHERE dni=@dni", conn))
            {
                cmd.Parameters.AddWithValue("@dni", dniCliente);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private bool ValidarDatosPagoSocio()
        {
            if (!decimal.TryParse(txtMonto.Text, out decimal monto) || monto <= 0)
            {
                MessageBox.Show("Ingrese un monto válido mayor a 0.", "Error en monto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (comboMedPago.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un medio de pago.", "Medio de pago requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (comboMedPago.SelectedItem.ToString() == "Credito" &&
                (!int.TryParse(txtCuotas.Text, out int cuotas) || cuotas < 1))
            {
                MessageBox.Show("Ingrese la cantidad de cuotas (mínimo 1).", "Cuotas inválidas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private int GuardarOActualizarCliente(MySqlConnection conn)
        {
            int id;
            var comando = new MySqlCommand("SELECT id FROM Cliente WHERE dni=@dni", conn);
            comando.Parameters.AddWithValue("@dni", dniCliente);
            var resultado = comando.ExecuteScalar();

            if (resultado != null)
            {
                // Actualizar cliente existente
                id = Convert.ToInt32(resultado);
                var actualizar = new MySqlCommand(
                    @"UPDATE Cliente SET 
                        nombre = @nombre, 
                        apellido = @apellido, 
                        fechaNacimiento = @fechaNac, 
                        direccion = @direccion, 
                        telefono = @telefono, 
                        aptoFisico = @aptoFisico, 
                        asociarse = @asociarse 
                    WHERE id = @id", conn);

                actualizar.Parameters.AddWithValue("@nombre", txtNombre.Text);
                actualizar.Parameters.AddWithValue("@apellido", txtApellido.Text);
                actualizar.Parameters.AddWithValue("@fechaNac", dtpFechaNacimiento.Value);
                actualizar.Parameters.AddWithValue("@direccion", txtDireccion.Text);
                actualizar.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                actualizar.Parameters.AddWithValue("@aptoFisico", chkAptoFisico.Checked);
                actualizar.Parameters.AddWithValue("@asociarse", chkAsociarse.Checked);
                actualizar.Parameters.AddWithValue("@id", id);
                actualizar.ExecuteNonQuery();
            }
            else
            {
                // Crear nuevo cliente
                var insertar = new MySqlCommand(
                    @"INSERT INTO Cliente 
                    (nombre, apellido, dni, fechaNacimiento, direccion, telefono, aptoFisico, asociarse, fechaAlta) 
                    VALUES 
                    (@nombre, @apellido, @dni, @fechaNac, @direccion, @telefono, @aptoFisico, @asociarse, @fechaAlta)", conn);

                insertar.Parameters.AddWithValue("@nombre", txtNombre.Text);
                insertar.Parameters.AddWithValue("@apellido", txtApellido.Text);
                insertar.Parameters.AddWithValue("@dni", dniCliente);
                insertar.Parameters.AddWithValue("@fechaNac", dtpFechaNacimiento.Value);
                insertar.Parameters.AddWithValue("@direccion", txtDireccion.Text);
                insertar.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                insertar.Parameters.AddWithValue("@aptoFisico", chkAptoFisico.Checked);
                insertar.Parameters.AddWithValue("@asociarse", chkAsociarse.Checked);
                insertar.Parameters.AddWithValue("@fechaAlta", DateTime.Today);
                insertar.ExecuteNonQuery();
                id = Convert.ToInt32(insertar.LastInsertedId);
            }
            return id;
        }

        private void ProcesarBajaSocio(MySqlConnection conn, int idSocio)
        {
            // Eliminar cuotas futuras
            var eliminarCuotas = new MySqlCommand(
                "DELETE FROM Cuota WHERE idSocio = @id AND fechaPago IS NULL",
                conn);
            eliminarCuotas.Parameters.AddWithValue("@id", idSocio);
            eliminarCuotas.ExecuteNonQuery();

            // Actualizar socio
            var actualizarSocio = new MySqlCommand(
                "UPDATE Socio SET fechaBaja = @fecha WHERE id = @id",
                conn);
            actualizarSocio.Parameters.AddWithValue("@fecha", dateBaja.Value);
            actualizarSocio.Parameters.AddWithValue("@id", idSocio);
            actualizarSocio.ExecuteNonQuery();

            // Registrar como no socio
            var insertarNoSocio = new MySqlCommand(
                "INSERT IGNORE INTO NoSocio (id) VALUES (@id)",
                conn);
            insertarNoSocio.Parameters.AddWithValue("@id", idSocio);
            insertarNoSocio.ExecuteNonQuery();
        }

        private void InsertarCuota(MySqlConnection conn, int idSocio, DateTime? fechaPago,
                   decimal monto, string medioPago, int cuotas, DateTime fv,
                   decimal descuento = 0, decimal montoTotal = 0)
        {
            var cmd = new MySqlCommand(
                @"INSERT INTO Cuota 
                (idSocio, fechaPago, monto, medioPago, cantidadCuotas, fechaVencimiento, descuento, montoTotal) 
                VALUES(@id, @fp, @m, @mp, @cq, @fv, @descuento, @montoTotal)", conn);

            cmd.Parameters.AddWithValue("@id", idSocio);
            cmd.Parameters.AddWithValue("@fp", (object)fechaPago ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@m", monto);
            cmd.Parameters.AddWithValue("@mp", (object)medioPago ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@cq", cuotas);
            cmd.Parameters.AddWithValue("@fv", fv);
            cmd.Parameters.AddWithValue("@descuento", descuento);
            cmd.Parameters.AddWithValue("@montoTotal", montoTotal);
            cmd.ExecuteNonQuery();
        }

        private void ObtenerNumeroCarnet(MySqlConnection conn)
        {
            var cmd = new MySqlCommand("SELECT COALESCE(MAX(numeroCarnet),0) FROM Socio", conn);
            int max = Convert.ToInt32(cmd.ExecuteScalar());
            lblNumCarnet.Text = (max + 1).ToString();
        }

        private bool ValidarCamposObligatorios()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("Complete todos los campos obligatorios.", "Campos requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!ValidarNombreApellido(txtNombre.Text))
            {
                MessageBox.Show("El nombre contiene caracteres inválidos. Solo se permiten letras y espacios.", "Nombre inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            if (!ValidarNombreApellido(txtApellido.Text))
            {
                MessageBox.Show("El apellido contiene caracteres inválidos. Solo se permiten letras y espacios.", "Apellido inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellido.Focus();
                return false;
            }

            if (!ValidarDireccion(txtDireccion.Text))
            {
                MessageBox.Show("La dirección contiene caracteres inválidos.", "Dirección inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDireccion.Focus();
                return false;
            }

            if (!ValidarTelefono(txtTelefono.Text))
            {
                MessageBox.Show("Ingrese un número de teléfono válido (solo números y caracteres permitidos).", "Teléfono inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return false;
            }

            return true;
        }

        private bool ValidarNombreApellido(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return false;

            // Permite letras, espacios, apóstrofes y guiones (nombres como María José, O'Connor, etc.)
            return System.Text.RegularExpressions.Regex.IsMatch(texto, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑüÜ\s'-]+$");
        }

        private bool ValidarTelefono(string telefono)
        {
            // Permite números, espacios, guiones y paréntesis
            return System.Text.RegularExpressions.Regex.IsMatch(telefono, @"^[\d\s\(\)-]+$");
        }

        private bool ValidarDireccion(string direccion)
        {
            // Permite letras, números, espacios y caracteres comunes en direcciones
            return System.Text.RegularExpressions.Regex.IsMatch(direccion, @"^[a-zA-Z0-9áéíóúÁÉÍÓÚñÑüÜ\s\.,#-]+$");
        }
        private bool ValidarEdad()
        {
            int edad = DateTime.Today.Year - dtpFechaNacimiento.Value.Year;
            if (dtpFechaNacimiento.Value.Date > DateTime.Today.AddYears(-edad)) edad--;

            if (edad < 17 || edad > 100)
            {
                MessageBox.Show("Edad fuera del rango permitido (18-100 años).", "Edad inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void chkAsociarse_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAsociarse.Checked)
            {
                tabPage2.Parent = tabControl1;
                dtpInscripcion.Value = DateTime.Today;
                dtpVencimiento.Value = DateTime.Today.AddMonths(1);
                lblTipoCliente.Text = "REGISTRAR - SOCIO";
                lblTipoCliente.ForeColor = Color.Blue;
                lblEstado.ForeColor = Color.Black;
                ObtenerNumeroCarnet(conexion.Conectar());
                tabControl1.SelectedTab = tabPage2;
                dtpVencimiento.Focus();
            }
            else
            {
                tabPage2.Parent = null;
                lblTipoCliente.Text = "REGISTRAR - NO SOCIO";
                lblTipoCliente.ForeColor = Color.FromArgb(192, 0, 0);
            }
        }

        private void dateBaja_ValueChanged(object sender, EventArgs e)
        {
            if (dateBaja.Checked)
            {
                if (dateBaja.Value < DateTime.Today)
                {
                    MessageBox.Show("La fecha de baja no puede ser anterior al día actual.",
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dateBaja.Value = DateTime.Today;
                    return;
                }

                string mensaje = dateBaja.Value == DateTime.Today
                    ? "¿Está seguro que desea dar de baja al socio efectiva inmediatamente?"
                    : $"¿Está seguro que desea programar la baja del socio para el {dateBaja.Value.ToShortDateString()}?";

                DialogResult result = MessageBox.Show(mensaje,
                    "Confirmar baja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    dateBaja.Checked = false;
                    return;
                }

                // Actualizar estado visual
                lblEstado.Text = dateBaja.Value > DateTime.Today ? "BAJA PROGRAMADA" : "EX SOCIO";
                lblEstado.ForeColor = Color.Red;
            }
            else
            {
                // Si se desmarca, volver a estado activo
                lblEstado.Text = "SOCIO AL DIA";
                lblEstado.ForeColor = Color.Green;
            }
        }

        private void btnImprimirCarnet_Click(object sender, EventArgs e)
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += impresionCarnet;

            // Configurar la página para que coincida con el tamaño del carnet
            printDoc.DefaultPageSettings.PaperSize = new PaperSize("Carnet", 340, 215);
            printDoc.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);

            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = printDoc;
            preview.WindowState = FormWindowState.Maximized;
            preview.PrintPreviewControl.Zoom = 1.5; // Zoom para mejor visualización
            preview.Text = "Vista previa del carnet de socio";

            // Configurar tamaño mínimo para la ventana de previsualización
            preview.Size = new Size(800, 600);

            preview.ShowDialog();
        }

        private void impresionCarnet(object sender, PrintPageEventArgs e)
        {
            // Tamaño del carnet (85.6mm x 54mm estándar ISO/IEC 7810 ID-1)
            int width = 340;  // ~85.6mm en puntos (1mm = 3.937 puntos)
            int height = 215; // ~54mm en puntos

            // Centrar el carnet en la página
            int startX = (e.PageBounds.Width - width) / 2;
            int startY = (e.PageBounds.Height - height) / 2;
            Rectangle cardRect = new Rectangle(startX, startY, width, height);

            // Fondo del carnet con gradiente
            using (var gradientBrush = new LinearGradientBrush(
                cardRect,
                Color.FromArgb(140, 135, 135),  // Azul oscuro
                Color.FromArgb(196, 190, 189), // Azul claro
                45f))
            {
                e.Graphics.FillRectangle(gradientBrush, cardRect);
            }

            // Borde del carnet con efecto 3D
            using (Pen pen = new Pen(Color.FromArgb(100, Color.White), 3))
            {
                e.Graphics.DrawRectangle(pen, cardRect);
            }

            // Logo del club 
            Image logo = Properties.Resources.ClubIcon;
            int logoSize = 80;
            int logoX = startX + 20;
            int logoY = startY + 60;

            // Dibujar el logo con fondo blanco circular
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.FillEllipse(Brushes.White, logoX - 5, logoY - 5, logoSize + 10, logoSize + 10);
            e.Graphics.DrawImage(logo, logoX, logoY, logoSize, logoSize);

            // Texto del carnet
            int textX = 20 + logoSize + 20;
            int textY = 20;

            using (Font fontTitle = new Font("Arial", 16, FontStyle.Bold),
                         fontLabel = new Font("Arial", 9, FontStyle.Regular),
                         fontValue = new Font("Arial", 10, FontStyle.Bold),
                         fontCarnet = new Font("Arial", 12, FontStyle.Bold),
                         fontClubName = new Font("Arial", 16, FontStyle.Bold | FontStyle.Italic))
            {
                // Nombre del club
                e.Graphics.DrawString("CLUB DEPORTIVO", fontClubName, Brushes.Black, textX - 30, textY);
                textY += 50;

                // Datos del socio
                string nombreCompleto = $"{txtNombre.Text} {txtApellido.Text}";
                if (nombreCompleto.Length > 25)
                {
                    nombreCompleto = nombreCompleto.Substring(0, 25) + "...";
                }

                e.Graphics.DrawString("Nombre:", fontLabel, Brushes.Black, textX, textY);
                e.Graphics.DrawString(nombreCompleto, fontValue, Brushes.DarkBlue, textX + 90, textY);
                textY += 20;

                e.Graphics.DrawString("DNI:", fontLabel, Brushes.Black, textX, textY);
                e.Graphics.DrawString(dniCliente.ToString(), fontValue, Brushes.DarkBlue, textX + 90, textY);
                textY += 20;

                e.Graphics.DrawString("Nacimiento:", fontLabel, Brushes.Black, textX, textY);
                e.Graphics.DrawString(dtpFechaNacimiento.Value.ToString("dd/MM/yyyy"), fontValue, Brushes.DarkBlue, textX + 90, textY);
                textY += 20;

                e.Graphics.DrawString("Inscripción:", fontLabel, Brushes.Black, textX, textY);
                e.Graphics.DrawString(dtpInscripcion.Value.ToString("dd/MM/yyyy"), fontValue, Brushes.DarkBlue, textX + 90, textY);
                textY += 40;

                // Número de carnet (en la parte inferior)
                string carnetText = $"Carnet N°: {lblNumCarnet.Text}";
                SizeF carnetSize = e.Graphics.MeasureString(carnetText, fontCarnet);
                e.Graphics.DrawString(carnetText, fontCarnet, Brushes.DarkBlue,
                                    startX + width - carnetSize.Width - 20,
                                    startY + height - carnetSize.Height - 15);

            }

            // Borde final del carnet
            e.Graphics.DrawRectangle(new Pen(Color.Black, 2), cardRect);
        }

        public static class EstadoHelper
        {
            public static string CalcularEstadoSocio(int idSocio, MySqlConnection conn)
            {
                // Verificar si tiene fecha de baja (ex socio)
                using (var cmd = new MySqlCommand("SELECT fechaBaja FROM Socio WHERE id=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", idSocio);
                    var fechaBaja = cmd.ExecuteScalar();

                    if (fechaBaja != null && fechaBaja != DBNull.Value)
                    {
                        DateTime fb = Convert.ToDateTime(fechaBaja);
                        if (fb > DateTime.Today)
                            return "BAJA PROGRAMADA";
                        else
                            return "EX SOCIO";
                    }
                }

                // Verificar cuotas vencidas no pagadas (moroso)
                using (var cmd = new MySqlCommand(
                    "SELECT COUNT(*) FROM Cuota WHERE idSocio=@id AND fechaVencimiento < CURDATE() AND fechaPago IS NULL", conn))
                {
                    cmd.Parameters.AddWithValue("@id", idSocio);
                    int vencidas = Convert.ToInt32(cmd.ExecuteScalar());
                    if (vencidas > 0)
                        return "SOCIO MOROSO";
                }

                // Si no cumple ninguna condición anterior, está al día
                return "SOCIO AL DIA";
            }

            public static string CalcularEstadoCuota(DateTime? fechaPago, DateTime fechaVencimiento)
            {
                if (fechaPago != null)
                    return "PAGADA";
                if (fechaVencimiento < DateTime.Today)
                    return "VENCIDA";
                return "ADEUDADA";
            }
        }
    }
}