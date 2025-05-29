using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ClubDeportivoApp;

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
        }

        private void FormRegistrarCliente_Load(object sender, EventArgs e)
        {
            // Formato de fechas
            dtpFechaNacimiento.Format = DateTimePickerFormat.Custom;
            dtpFechaNacimiento.CustomFormat = "dd/MM/yyyy";
            dtpInscripcion.Format = DateTimePickerFormat.Custom;
            dtpInscripcion.CustomFormat = "dd/MM/yyyy";
            dtpVencimiento.Format = DateTimePickerFormat.Custom;
            dtpVencimiento.CustomFormat = "dd/MM/yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker1.ShowCheckBox = true;
            dateTimePicker1.Checked = false;

            lblDni.Text = dniCliente.ToString();
            tabControl1.Visible = true;

            bool clienteExiste = CargarDatosCliente();
            bool socioActivo = clienteExiste && EsSocioActivo();

            if (socioActivo)
            {
                // Socio activo: ocultar opción de asociarse
                chkAsociarse.Visible = false;
                lblTipoCliente.Text = "MODIFICAR - SOCIO";
                lblTipoCliente.ForeColor = Color.Blue;
                CargarDatosSocio();
                tabPage2.Parent = tabControl1;
            }
            else
            {
                // No socio o nuevo
                chkAsociarse.Visible = true;
                chkAsociarse.Checked = false;
                lblTipoCliente.Text = clienteExiste ? "MODIFICAR - NO SOCIO" : "REGISTRAR - NO SOCIO";
                lblTipoCliente.ForeColor = Color.Red;
                tabPage2.Parent = null;
            }
        }

        private bool CargarDatosCliente()
        {
            using (var conn = conexion.Conectar())
            using (var cmd = new MySqlCommand(
                "SELECT nombre, apellido, direccion, telefono, fechaNacimiento, aptoFisico, asociarse " +
                "FROM Cliente WHERE dni=@dni", conn))
            {
                cmd.Parameters.AddWithValue("@dni", dniCliente);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtNombre.Text = reader.GetString(0);
                        txtApellido.Text = reader.GetString(1);
                        txtDireccion.Text = reader.GetString(2);
                        txtTelefono.Text = reader.GetString(3);
                        dtpFechaNacimiento.Value = reader.GetDateTime(4);
                        chkAptoFisico.Checked = reader.GetBoolean(5);
                        chkAsociarse.Checked = reader.GetBoolean(6);
                        return true;
                    }
                }
            }
            return false;
        }

        private void CargarDatosSocio()
        {
            using (var conn = conexion.Conectar())
            using (var cmd = new MySqlCommand(
                "SELECT fechaInscripcion, fechaVencimientoCuota, numeroCarnet, carnetEntregado, estado, fechaBaja " +
                "FROM Socio WHERE id=@id", conn))
            {
                cmd.Parameters.AddWithValue("@id", GetClienteId(conn));
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        dtpInscripcion.Value = reader.GetDateTime(0);
                        dtpVencimiento.Value = reader.GetDateTime(1);
                        lblNumCarnet.Text = reader.GetInt32(2).ToString();
                        chkCarnetEntregado.Checked = reader.GetBoolean(3);
                        lblEstado.Text = reader.GetString(4);
                        if (!reader.IsDBNull(5)) dateTimePicker1.Value = reader.GetDateTime(5);
                    }
                }
            }
        }

        private bool EsSocioActivo()
        {
            using (var conn = conexion.Conectar())
            using (var cmd = new MySqlCommand(
                "SELECT COUNT(*) FROM Socio WHERE id=@id AND fechaBaja IS NULL", conn))
            {
                cmd.Parameters.AddWithValue("@id", GetClienteId(conn));
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposObligatorios() || !ValidarEdad()) return;

            using (var conn = conexion.Conectar())
            {
                int idCliente = SaveOrUpdateCliente(conn);

                if (chkAsociarse.Checked)
                    ConvertirASocio(conn, idCliente);
                else
                    ConvertirANoSocio(conn, idCliente);

                MessageBox.Show("Operación completada.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private int SaveOrUpdateCliente(MySqlConnection conn)
        {
            int id;
            var cmdCheck = new MySqlCommand(
                "SELECT id FROM Cliente WHERE dni=@dni", conn);
            cmdCheck.Parameters.AddWithValue("@dni", dniCliente);
            var result = cmdCheck.ExecuteScalar();

            if (result != null)
            {
                id = Convert.ToInt32(result);
                var upd = new MySqlCommand(
                    @"UPDATE Cliente SET nombre=@n, apellido=@a, fechaNacimiento=@fn, " +
                      "direccion=@d, telefono=@t, aptoFisico=@af, asociarse=@asoc " +
                    "WHERE id=@id", conn);
                upd.Parameters.AddWithValue("@n", txtNombre.Text);
                upd.Parameters.AddWithValue("@a", txtApellido.Text);
                upd.Parameters.AddWithValue("@fn", dtpFechaNacimiento.Value);
                upd.Parameters.AddWithValue("@d", txtDireccion.Text);
                upd.Parameters.AddWithValue("@t", txtTelefono.Text);
                upd.Parameters.AddWithValue("@af", chkAptoFisico.Checked);
                upd.Parameters.AddWithValue("@asoc", chkAsociarse.Checked);
                upd.Parameters.AddWithValue("@id", id);
                upd.ExecuteNonQuery();
            }
            else
            {
                var ins = new MySqlCommand(
                    @"INSERT INTO Cliente (nombre, apellido, dni, fechaNacimiento, direccion, telefono, aptoFisico, asociarse, fechaAlta) " +
                    "VALUES (@n, @a, @dni, @fn, @d, @t, @af, @asoc, @fa)", conn);
                ins.Parameters.AddWithValue("@n", txtNombre.Text);
                ins.Parameters.AddWithValue("@a", txtApellido.Text);
                ins.Parameters.AddWithValue("@dni", dniCliente);
                ins.Parameters.AddWithValue("@fn", dtpFechaNacimiento.Value);
                ins.Parameters.AddWithValue("@d", txtDireccion.Text);
                ins.Parameters.AddWithValue("@t", txtTelefono.Text);
                ins.Parameters.AddWithValue("@af", chkAptoFisico.Checked);
                ins.Parameters.AddWithValue("@asoc", chkAsociarse.Checked);
                ins.Parameters.AddWithValue("@fa", DateTime.Today);
                ins.ExecuteNonQuery();
                id = Convert.ToInt32(ins.LastInsertedId);
            }
            return id;
        }

        private void ConvertirASocio(MySqlConnection conn, int id)
        {
            var del = new MySqlCommand("DELETE FROM NoSocio WHERE id=@id", conn);
            del.Parameters.AddWithValue("@id", id);
            del.ExecuteNonQuery();

            var cmdCnt = new MySqlCommand("SELECT COUNT(*) FROM Socio WHERE id=@id", conn);
            cmdCnt.Parameters.AddWithValue("@id", id);
            bool existe = Convert.ToInt32(cmdCnt.ExecuteScalar()) > 0;

            if (existe)
            {
                var upd = new MySqlCommand(
                    @"UPDATE Socio SET fechaInscripcion=@fi, fechaVencimientoCuota=@fv, estado='SOCIO AL DIA', fechaBaja=NULL " +
                      "WHERE id=@id", conn);
                upd.Parameters.AddWithValue("@fi", DateTime.Today);
                upd.Parameters.AddWithValue("@fv", DateTime.Today.AddDays(30));
                upd.Parameters.AddWithValue("@id", id);
                upd.ExecuteNonQuery();
            }
            else
            {
                ObtenerNumeroCarnet(conn);
                var ins = new MySqlCommand(
                    @"INSERT INTO Socio (id, fechaInscripcion, fechaVencimientoCuota, numeroCarnet, carnetEntregado, estado, fechaBaja) " +
                      "VALUES (@id, @fi, @fv, @nc, @ce, 'SOCIO AL DIA', NULL)", conn);
                ins.Parameters.AddWithValue("@id", id);
                ins.Parameters.AddWithValue("@fi", DateTime.Today);
                ins.Parameters.AddWithValue("@fv", DateTime.Today.AddDays(30));
                ins.Parameters.AddWithValue("@nc", lblNumCarnet.Text);
                ins.Parameters.AddWithValue("@ce", chkCarnetEntregado.Checked);
                ins.ExecuteNonQuery();
            }

            InsertarCuota(conn, id, DateTime.Today, 10000m, "Efectivo", 1, DateTime.Today.AddDays(30), "PAGADA");
            InsertarCuota(conn, id, null, 10000m, null, 1, DateTime.Today.AddDays(60), "ADEUDADA");
        }

        private void ConvertirANoSocio(MySqlConnection conn, int id)
        {
            var upd = new MySqlCommand("UPDATE Socio SET fechaBaja=@fb, estado='EX SOCIO' WHERE id=@id", conn);
            upd.Parameters.AddWithValue("@fb", DateTime.Today);
            upd.Parameters.AddWithValue("@id", id);
            upd.ExecuteNonQuery();

            var insNo = new MySqlCommand("INSERT IGNORE INTO NoSocio(id) VALUES(@id)", conn);
            insNo.Parameters.AddWithValue("@id", id);
            insNo.ExecuteNonQuery();
        }

        private void InsertarCuota(MySqlConnection conn, int idSocio, DateTime? fechaPago,
                                   decimal monto, string medioPago, int cuotas, DateTime fv, string estado)
        {
            var chk = new MySqlCommand("SELECT COUNT(*) FROM Cuota WHERE idSocio=@idSocio AND fechaVencimiento=@fv", conn);
            chk.Parameters.AddWithValue("@idSocio", idSocio);
            chk.Parameters.AddWithValue("@fv", fv);
            if (Convert.ToInt32(chk.ExecuteScalar()) > 0) return;

            var cmd = new MySqlCommand(
                @"INSERT INTO Cuota (idSocio, fechaPago, monto, medioPago, cantidadCuotas, fechaVencimiento, estado) " +
                  "VALUES(@id, @fp, @m, @mp, @cq, @fv, @est)", conn);
            cmd.Parameters.AddWithValue("@id", idSocio);
            cmd.Parameters.AddWithValue("@fp", (object)fechaPago ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@m", monto);
            cmd.Parameters.AddWithValue("@mp", (object)medioPago ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@cq", cuotas);
            cmd.Parameters.AddWithValue("@fv", fv);
            cmd.Parameters.AddWithValue("@est", estado);
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
            var faltan = new List<string>();
            if (string.IsNullOrWhiteSpace(txtNombre.Text)) faltan.Add("Nombre");
            if (string.IsNullOrWhiteSpace(txtApellido.Text)) faltan.Add("Apellido");
            if (string.IsNullOrWhiteSpace(txtDireccion.Text)) faltan.Add("Dirección");
            if (string.IsNullOrWhiteSpace(txtTelefono.Text)) faltan.Add("Teléfono");
            if (faltan.Count > 0)
            {
                MessageBox.Show("Complete:\n" + string.Join("\n", faltan), "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool ValidarEdad()
        {
            int edad = DateTime.Today.Year - dtpFechaNacimiento.Value.Year;
            if (dtpFechaNacimiento.Value > DateTime.Today.AddYears(-edad)) edad--;
            if (edad < 18)
            {
                MessageBox.Show("Menor de edad. No permitido.", "Error Edad", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}