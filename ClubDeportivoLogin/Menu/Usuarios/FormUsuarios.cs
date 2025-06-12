using MySql.Data.MySqlClient;

namespace ClubDeportivoLogin.Menu.Usuarios
{
    public partial class FormUsuarios : Form
    {
        private bool usuarioExiste = false;
        private string usuarioOriginal = "";
        private string claveOriginal = "";
        private string rolOriginal = "";

        public FormUsuarios()
        {
            InitializeComponent();
            comboRol.Items.Clear();
            comboRol.Items.Add("USUARIO");
            comboRol.Items.Add("ADMINISTRADOR");
            comboRol.DropDownStyle = ComboBoxStyle.DropDownList;
            comboRol.SelectedIndex = 0;
            lblTipoRegistro.Text = "";
            lblTipoRegistro.ForeColor = Color.Blue;
            txtContraseña.Text = "";
            comboRol.Visible = false;
            txtContraseña.Visible = false;
            lblRol.Visible = false;
            lblContraseña.Visible = false;
            btnGuardar.Visible = false;
            btnBorrar.Visible = false;

            txtUsuario.KeyDown += txtUsuario_KeyDown;
            txtUsuario.Leave += txtUsuario_Leave;
            comboRol.SelectedIndexChanged += Control_Modificado;
            txtContraseña.TextChanged += Control_Modificado;
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ConsultarUsuario();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            // Solo consulta si el campo no está vacío y no tiene el foco (evita doble consulta)
            if (!string.IsNullOrWhiteSpace(txtUsuario.Text) && !txtUsuario.Focused)
                ConsultarUsuario();
        }

        private void ConsultarUsuario()
        {
            string usuario = txtUsuario.Text.Trim();
            if (string.IsNullOrEmpty(usuario))
            {
                LimpiarCampos();
                return;
            }
            try
            {
                Conexion conn = new Conexion();
                using (var conexion = conn.Conectar())
                using (var cmd = new MySqlCommand("SELECT rol, clave FROM usuarios WHERE LOWER(usuario) = @usuario", conexion))
                {
                    cmd.Parameters.AddWithValue("@usuario", usuario.ToLower());
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Usuario existente
                            usuarioExiste = true;
                            usuarioOriginal = usuario;
                            claveOriginal = reader["clave"].ToString();
                            rolOriginal = reader["rol"].ToString().ToUpper() == "ADMINISTRADOR" ? "ADMINISTRADOR" : "USUARIO";
                            lblTipoRegistro.Text = "MODIFICAR USUARIO";
                            lblTipoRegistro.ForeColor = Color.Red;
                            comboRol.SelectedItem = rolOriginal;
                            txtContraseña.Text = claveOriginal;
                            comboRol.Visible = true;
                            txtContraseña.Visible = true;
                            lblRol.Visible = true;
                            lblContraseña.Visible = true;
                            btnBorrar.Visible = true;
                            btnGuardar.Visible = false; // Solo si se modifica algo
                        }
                        else
                        {
                            // Usuario nuevo
                            usuarioExiste = false;
                            usuarioOriginal = usuario;
                            claveOriginal = "";
                            rolOriginal = "USUARIO";
                            lblTipoRegistro.Text = "NUEVO USUARIO";
                            lblTipoRegistro.ForeColor = Color.Blue;
                            comboRol.SelectedIndex = 0;
                            txtContraseña.Text = GenerarContraseñaAleatoria();
                            comboRol.Visible = true;
                            txtContraseña.Visible = true;
                            lblRol.Visible = true;
                            lblContraseña.Visible = true;
                            btnBorrar.Visible = false;
                            btnGuardar.Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarCampos();
            }
        }

        private void LimpiarCampos()
        {
            lblTipoRegistro.Text = "";
            usuarioExiste = false;
            usuarioOriginal = "";
            claveOriginal = "";
            rolOriginal = "USUARIO";
            comboRol.Visible = false;
            txtContraseña.Visible = false;
            lblRol.Visible = false;
            lblContraseña.Visible = false;
            btnGuardar.Visible = false;
            btnBorrar.Visible = false;
            txtContraseña.Text = "";
            comboRol.SelectedIndex = 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contraseña = txtContraseña.Text.Trim();
            string rol = comboRol.SelectedItem?.ToString() ?? "USUARIO";

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Complete todos los campos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (contraseña.Length < 4)
            {
                MessageBox.Show("La contraseña debe tener al menos 4 caracteres.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Conexion conn = new Conexion();
                using (var conexion = conn.Conectar())
                {
                    if (usuarioExiste)
                    {
                        // Modificar usuario
                        using (var cmd = new MySqlCommand("UPDATE usuarios SET clave = @clave, rol = @rol WHERE LOWER(usuario) = @usuario", conexion))
                        {
                            cmd.Parameters.AddWithValue("@clave", contraseña);
                            cmd.Parameters.AddWithValue("@rol", rol.ToUpper());
                            cmd.Parameters.AddWithValue("@usuario", usuario.ToLower());
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Usuario modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Nuevo usuario
                        using (var cmd = new MySqlCommand("INSERT INTO usuarios (usuario, clave, rol) VALUES (@usuario, @clave, @rol)", conexion))
                        {
                            cmd.Parameters.AddWithValue("@usuario", usuario);
                            cmd.Parameters.AddWithValue("@clave", contraseña);
                            cmd.Parameters.AddWithValue("@rol", rol.ToUpper());
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Usuario creado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            if (!usuarioExiste)
            {
                MessageBox.Show("No hay usuario existente para borrar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var confirm = MessageBox.Show("¿Está seguro que desea eliminar este usuario? Esta acción no se puede revertir.", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes)
                return;

            try
            {
                Conexion conn = new Conexion();
                using (var conexion = conn.Conectar())
                using (var cmd = new MySqlCommand("DELETE FROM usuarios WHERE LOWER(usuario) = @usuario", conexion))
                {
                    cmd.Parameters.AddWithValue("@usuario", usuario.ToLower());
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                        MessageBox.Show("Usuario eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("No se encontró el usuario para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string GenerarContraseñaAleatoria()
        {
            var rand = new Random();
            string pass = "";
            for (int i = 0; i < 6; i++)
                pass += rand.Next(0, 10).ToString();
            return pass;
        }

        private void Control_Modificado(object sender, EventArgs e)
        {
            if (usuarioExiste)
            {
                // Solo habilita guardar si se modificó algo
                btnGuardar.Visible =
                    txtContraseña.Text != claveOriginal ||
                    (comboRol.SelectedItem?.ToString() ?? "USUARIO") != rolOriginal;
            }
        }
    }
}