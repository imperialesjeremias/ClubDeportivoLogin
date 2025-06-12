using MySql.Data.MySqlClient;

namespace ClubDeportivoLogin
{
    public partial class FormRegistrarActividad : Form
    {
        private Conexion conexion = new Conexion();
        private int? idActividad = null; 
        private string nombreOriginal = null;
        private bool actividadExistente = false;

        public FormRegistrarActividad()
        {
            InitializeComponent();
            btnGuardar.Click += btnGuardar_Click;
            btnSalir.Click += btnSalir_Click;
            txtActividad.Leave += txtActividad_Leave;
        }

        public FormRegistrarActividad(int id) : this()
        {
            idActividad = id;
            CargarDatosActividadPorId();
        }

        private void txtActividad_Leave(object sender, EventArgs e)
        {
            string nombre = txtActividad.Text.Trim().ToUpper();
            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("El nombre de la actividad es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtActividad.Focus();
                return;
            }

            txtActividad.Text = nombre;

            using (var conn = conexion.Conectar())
            using (var cmd = new MySqlCommand("SELECT id, nombre, costo FROM actividad WHERE UPPER(nombre) = @nombre", conn))
            {
                cmd.Parameters.AddWithValue("@nombre", nombre);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        actividadExistente = true;
                        idActividad = reader.GetInt32(0);
                        nombreOriginal = reader.GetString(1);
                        txtActividad.Text = nombreOriginal;
                        txtCosto.Text = reader.GetDecimal(2).ToString("0.00");
                        txtActividad.ReadOnly = true; 
                        txtActividad.ForeColor = Color.Black; 
                        lblEstado.Text = "EDITAR ACTIVIDAD";
                        lblEstado.ForeColor = Color.Red; 
                    }
                    else
                    {
                        actividadExistente = false;
                        idActividad = null;
                        nombreOriginal = nombre;
                        txtActividad.Text = nombre;
                        txtActividad.ReadOnly = true; 
                        txtActividad.ForeColor = Color.Black; 
                        txtCosto.Text = "";
                        lblEstado.Text = "REGISTRAR NUEVA ACTIVIDAD";
                        lblEstado.ForeColor = Color.Blue; 
                    }
                }
            }
        }

        private void CargarDatosActividadPorId()
        {
            using (var conn = conexion.Conectar())
            using (var cmd = new MySqlCommand("SELECT nombre, costo FROM actividad WHERE id = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", idActividad);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        nombreOriginal = reader.GetString(0);
                        txtActividad.Text = nombreOriginal;
                        txtCosto.Text = reader.GetDecimal(1).ToString("0.00");
                        txtActividad.Enabled = false;
                        actividadExistente = true;
                        lblEstado.Text = "EDITAR ACTIVIDAD";
                        lblEstado.ForeColor = Color.Red;
                    }
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtActividad.Text.Trim().ToUpper();
            string costoStr = txtCosto.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("El nombre de la actividad es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtActividad.Focus();
                return;
            }

            if (!decimal.TryParse(costoStr, out decimal costo) || costo < 0)
            {
                MessageBox.Show("Ingrese un costo válido (número positivo).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCosto.Focus();
                return;
            }

            if (actividadExistente && !nombre.Equals(nombreOriginal, StringComparison.OrdinalIgnoreCase))
            {
                if (ExisteActividad(nombre))
                {
                    MessageBox.Show("Ya existe una actividad con ese nombre.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtActividad.Text = nombreOriginal;
                    txtActividad.Focus();
                    return;
                }
            }

            using (var conn = conexion.Conectar())
            {
                if (!actividadExistente)
                {
                    var cmd = new MySqlCommand("INSERT INTO actividad (nombre, costo) VALUES (@nombre, @costo)", conn);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@costo", costo);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Actividad registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var cmd = new MySqlCommand("UPDATE actividad SET nombre = @nombre, costo = @costo WHERE id = @id", conn);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@costo", costo);
                    cmd.Parameters.AddWithValue("@id", idActividad);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Actividad actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            this.Close();
        }

        private bool ExisteActividad(string nombre)
        {
            using (var conn = conexion.Conectar())
            using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM actividad WHERE UPPER(nombre) = @nombre" + (idActividad != null ? " AND id <> @id" : ""), conn))
            {
                cmd.Parameters.AddWithValue("@nombre", nombre);
                if (idActividad != null)
                    cmd.Parameters.AddWithValue("@id", idActividad);
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void SetNombreActividad(string nombre)
        {
            txtActividad.Text = nombre;
            txtActividad.ReadOnly = true;
            txtActividad.ForeColor = Color.Black;
            lblEstado.Text = "REGISTRAR NUEVA ACTIVIDAD";
            lblEstado.ForeColor = Color.Blue;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (idActividad == null)
            {
                MessageBox.Show("No hay una actividad seleccionada para borrar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                "¿Está seguro que desea eliminar esta actividad?\nEsta acción no se puede deshacer.",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            using (var conn = conexion.Conectar())
            {
                using (var cmdCheck = new MySqlCommand("SELECT COUNT(*) FROM RegistroActividad WHERE IdActividad = @id", conn))
                {
                    cmdCheck.Parameters.AddWithValue("@id", idActividad);
                    int usados = Convert.ToInt32(cmdCheck.ExecuteScalar());
                    if (usados > 0)
                    {
                        MessageBox.Show(
                            "No se puede eliminar la actividad porque ya fue registrada como realizada por uno o más clientes.",
                            "Eliminación no permitida",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }
                }

                using (var cmdDelete = new MySqlCommand("DELETE FROM actividad WHERE id = @id", conn))
                {
                    cmdDelete.Parameters.AddWithValue("@id", idActividad);
                    int filas = cmdDelete.ExecuteNonQuery();
                    if (filas > 0)
                    {
                        MessageBox.Show("Actividad eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar la actividad. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}