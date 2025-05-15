using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClubDeportivoApp;
using MySql.Data.MySqlClient;

namespace ClubDeportivoLogin
{
    public partial class FormRegistrarCliente : Form
    {
        public FormRegistrarCliente()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Conexion conexion = new Conexion();
                MySqlConnection conn = conexion.Conectar();

                // 1. Insertar en Cliente
                string insertCliente = @"
            INSERT INTO Cliente 
            (nombre, apellido, dni, fechaNacimiento, direccion, telefono, aptoFisico, fechaAlta)
            VALUES 
            (@nombre, @apellido, @dni, @fechaNacimiento, @direccion, @telefono, @aptoFisico, @fechaAlta)";

                MySqlCommand cmdCliente = new MySqlCommand(insertCliente, conn);
                cmdCliente.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                cmdCliente.Parameters.AddWithValue("@apellido", txtApellido.Text.Trim());
                cmdCliente.Parameters.AddWithValue("@dni", Convert.ToInt32(txtDni.Text.Trim()));
                cmdCliente.Parameters.AddWithValue("@fechaNacimiento", dtpFechaNacimiento.Value.Date);
                cmdCliente.Parameters.AddWithValue("@direccion", txtDireccion.Text.Trim());
                cmdCliente.Parameters.AddWithValue("@telefono", txtTelefono.Text.Trim());
                cmdCliente.Parameters.AddWithValue("@aptoFisico", chkAptoFisico.Checked);
                cmdCliente.Parameters.AddWithValue("@fechaAlta", DateTime.Now.Date);

                cmdCliente.ExecuteNonQuery();

                // Obtener el ID del nuevo cliente
                long idCliente = cmdCliente.LastInsertedId;

                // 2. Si es socio
                if (chkEsSocio.Checked)
                {
                    // Obtener número de carnet siguiente
                    string queryCarnet = "SELECT MAX(numeroCarnet) FROM Socio";
                    MySqlCommand cmdCarnet = new MySqlCommand(queryCarnet, conn);
                    object resultado = cmdCarnet.ExecuteScalar();

                    int nuevoCarnet = 1;
                    if (resultado != DBNull.Value)
                    {
                        nuevoCarnet = Convert.ToInt32(resultado) + 1;
                    }

                    string insertSocio = @"
                INSERT INTO Socio 
                (id, fechaInscripcion, fechaVencimientoCuota, numeroCarnet, carnetEntregado, estado, fechaBaja)
                VALUES 
                (@id, @fechaInscripcion, @fechaVencimientoCuota, @numeroCarnet, @carnetEntregado, @estado, NULL)";

                    MySqlCommand cmdSocio = new MySqlCommand(insertSocio, conn);
                    cmdSocio.Parameters.AddWithValue("@id", idCliente);
                    cmdSocio.Parameters.AddWithValue("@fechaInscripcion", dtpInscripcion.Value.Date);
                    cmdSocio.Parameters.AddWithValue("@fechaVencimientoCuota", dtpVencimiento.Value.Date);
                    cmdSocio.Parameters.AddWithValue("@numeroCarnet", nuevoCarnet);
                    cmdSocio.Parameters.AddWithValue("@carnetEntregado", chkCarnetEntregado.Checked);
                    cmdSocio.Parameters.AddWithValue("@estado", cmbEstado.SelectedItem.ToString());

                    cmdSocio.ExecuteNonQuery();
                }
                else
                {
                    // 3. Si es NoSocio
                    string insertNoSocio = "INSERT INTO NoSocio (id) VALUES (@id)";
                    MySqlCommand cmdNoSocio = new MySqlCommand(insertNoSocio, conn);
                    cmdNoSocio.Parameters.AddWithValue("@id", idCliente);
                    cmdNoSocio.ExecuteNonQuery();
                }

                conn.Close();
                MessageBox.Show("Cliente registrado correctamente.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar cliente: " + ex.Message);
            }

        }
    }
}
