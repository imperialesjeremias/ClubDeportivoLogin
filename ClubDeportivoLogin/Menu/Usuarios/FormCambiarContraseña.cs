using MySql.Data.MySqlClient;

namespace ClubDeportivoLogin.Menu.Usuarios
{
    public partial class FormCambiarContraseña : Form
    {
        private readonly string usuario;

        public FormCambiarContraseña(string usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string passActual = txtPassActual.Text.Trim();
            string passNueva = txtPassNueva.Text.Trim();
            string passRepetir = txtRepetirNueva.Text.Trim();

            if (string.IsNullOrEmpty(passActual) || string.IsNullOrEmpty(passNueva) || string.IsNullOrEmpty(passRepetir))
            {
                MessageBox.Show("Complete todos los campos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (passNueva.Length < 4)
            {
                MessageBox.Show("La nueva contraseña debe tener al menos 4 caracteres.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (passNueva != passRepetir)
            {
                MessageBox.Show("Las contraseñas nuevas no coinciden.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Conexion conn = new Conexion();
                string passBD = null;
                using (var conexion = conn.Conectar())
                using (var cmd = new MySqlCommand("SELECT clave FROM usuarios WHERE usuario = @usuario", conexion))
                {
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    passBD = cmd.ExecuteScalar()?.ToString();
                    if (passBD == null || passBD != passActual)
                    {
                        MessageBox.Show("La contraseña actual es incorrecta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (passNueva == passActual)
                {
                    MessageBox.Show("La nueva contraseña no puede ser igual a la actual.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                using (var conexion = conn.Conectar())
                using (var cmd = new MySqlCommand("UPDATE usuarios SET clave = @nueva WHERE usuario = @usuario", conexion))
                {
                    cmd.Parameters.AddWithValue("@nueva", passNueva);
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Contraseña cambiada correctamente. Debe volver a iniciar sesión.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

                foreach (Form frm in Application.OpenForms)
                {
                    if (frm is ClubDeportivoLogin.MenuPrincipal menu)
                    {
                        // Busca y ejecuta el método del botón cerrar sesión
                        var cerrarSesionBtn = menu.Controls.Find("cerrarSesion", true).FirstOrDefault() as Button;
                        if (cerrarSesionBtn != null)
                        {
                            cerrarSesionBtn.PerformClick();
                        }
                        else
                        {
                            // Si no encuentra el botón, cierra el menú principal y abre el login manualmente
                            string usuarioActual = usuario;
                            menu.Close();
                            new Login(usuarioActual).Show();
                        }
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cambiar la contraseña: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
