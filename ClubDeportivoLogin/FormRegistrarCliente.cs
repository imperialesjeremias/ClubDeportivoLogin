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
            InitializeComponent(); // Inicializa los componentes visuales del formulario
        }

        // Evento que se ejecuta al hacer clic en el botón "Guardar"
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Crear y abrir una conexión a la base de datos
                Conexion conexion = new Conexion();
                MySqlConnection conn = conexion.Conectar();

                // 1. Crear sentencia SQL para insertar un nuevo cliente
                string insertCliente = @"
                INSERT INTO Cliente 
                (nombre, apellido, dni, fechaNacimiento, direccion, telefono, aptoFisico, fechaAlta)
                VALUES 
                (@nombre, @apellido, @dni, @fechaNacimiento, @direccion, @telefono, @aptoFisico, @fechaAlta)";

                // Configurar comando SQL con parámetros desde el formulario
                MySqlCommand cmdCliente = new MySqlCommand(insertCliente, conn);
                cmdCliente.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                cmdCliente.Parameters.AddWithValue("@apellido", txtApellido.Text.Trim());
                cmdCliente.Parameters.AddWithValue("@dni", Convert.ToInt32(txtDni.Text.Trim()));
                cmdCliente.Parameters.AddWithValue("@fechaNacimiento", dtpFechaNacimiento.Value.Date);
                cmdCliente.Parameters.AddWithValue("@direccion", txtDireccion.Text.Trim());
                cmdCliente.Parameters.AddWithValue("@telefono", txtTelefono.Text.Trim());
                cmdCliente.Parameters.AddWithValue("@aptoFisico", chkAptoFisico.Checked);
                cmdCliente.Parameters.AddWithValue("@fechaAlta", DateTime.Now.Date); // Fecha actual

                // Ejecutar inserción del cliente
                cmdCliente.ExecuteNonQuery();

                // Obtener el ID generado automáticamente para el nuevo cliente
                long idCliente = cmdCliente.LastInsertedId;

                // 2. Verificar si el cliente es un socio
                if (chkEsSocio.Checked)
                {
                    // Obtener el número de carnet más alto para generar uno nuevo consecutivo
                    string queryCarnet = "SELECT MAX(numeroCarnet) FROM Socio";
                    MySqlCommand cmdCarnet = new MySqlCommand(queryCarnet, conn);
                    object resultado = cmdCarnet.ExecuteScalar();

                    int nuevoCarnet = 1; // Valor inicial si no hay ningún socio aún
                    if (resultado != DBNull.Value)
                    {
                        nuevoCarnet = Convert.ToInt32(resultado) + 1;
                    }

                    // Crear comando SQL para insertar en la tabla Socio
                    string insertSocio = @"
                    INSERT INTO Socio 
                    (id, fechaInscripcion, fechaVencimientoCuota, numeroCarnet, carnetEntregado, estado, fechaBaja)
                    VALUES 
                    (@id, @fechaInscripcion, @fechaVencimientoCuota, @numeroCarnet, @carnetEntregado, @estado, NULL)";

                    MySqlCommand cmdSocio = new MySqlCommand(insertSocio, conn);
                    cmdSocio.Parameters.AddWithValue("@id", idCliente); // mismo ID que en Cliente
                    cmdSocio.Parameters.AddWithValue("@fechaInscripcion", dtpInscripcion.Value.Date);
                    cmdSocio.Parameters.AddWithValue("@fechaVencimientoCuota", dtpVencimiento.Value.Date);
                    cmdSocio.Parameters.AddWithValue("@numeroCarnet", nuevoCarnet);
                    cmdSocio.Parameters.AddWithValue("@carnetEntregado", chkCarnetEntregado.Checked);
                    cmdSocio.Parameters.AddWithValue("@estado", cmbEstado.SelectedItem.ToString());

                    cmdSocio.ExecuteNonQuery(); // Ejecutar la inserción en Socio
                }
                else
                {
                    // 3. Si no es socio, se inserta en la tabla NoSocio con el mismo ID
                    string insertNoSocio = "INSERT INTO NoSocio (id) VALUES (@id)";
                    MySqlCommand cmdNoSocio = new MySqlCommand(insertNoSocio, conn);
                    cmdNoSocio.Parameters.AddWithValue("@id", idCliente);
                    cmdNoSocio.ExecuteNonQuery();
                }

                // Cerrar la conexión con la base de datos
                conn.Close();

                // Mostrar mensaje de éxito y cerrar el formulario
                MessageBox.Show("Cliente registrado correctamente.");
                this.Close();
            }
            catch (Exception ex)
            {
                // Capturar errores y mostrarlos al usuario
                MessageBox.Show("Error al registrar cliente: " + ex.Message);
            }
        }
    }
}