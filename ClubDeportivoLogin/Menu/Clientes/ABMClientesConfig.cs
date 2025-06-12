namespace ClubDeportivoLogin
{
    public static class ABMClientesConfig
    {
        public static FormABMBase.ConfigABM ObtenerConfig(string usuario)
        {
            return new FormABMBase.ConfigABM
            {
                TituloVentana = "ABM de Clientes",
                Titulo = "Maestro de Clientes",
                Subtitulo = "Asistente de A.B.M.",
                Ayuda1 = "Este asistente le ayudará a consultar, agregar, modificar o borrar un código de la tabla, y realizar cambios en el \"Maestro de clientes\".",
                Ayuda2 = "Ingrese el DNI (solo números) que desea consultar, agregar, modificar o borrar y presione \"Enter\" o botón \"Siguiente\" para continuar.",
                EtiquetaCampo = "DNI: ",
                Icono = Properties.Resources.ClienteIcon,
                Validacion = dni => dni.All(char.IsDigit) && dni.Length >= 7 && dni.Length <= 10,
                AccionSiguiente = dni => {
                    int dniValor = int.Parse(dni);
                    using (var conn = new Conexion().Conectar())
                    {
                        using (var cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT COUNT(*) FROM Cliente WHERE dni=@dni", conn))
                        {
                            cmd.Parameters.AddWithValue("@dni", dniValor);
                            bool existe = Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                            if (!existe)
                            {
                                var respuesta = System.Windows.Forms.MessageBox.Show(
                                    $"El DNI {dniValor} no está registrado. ¿Desea crear un nuevo cliente?",
                                    "Nuevo cliente",
                                    System.Windows.Forms.MessageBoxButtons.YesNo,
                                    System.Windows.Forms.MessageBoxIcon.Question);

                                if (respuesta == System.Windows.Forms.DialogResult.No)
                                {
                                    // No hacer nada, vuelve al ABM
                                    return;
                                }
                            }
                        }
                    }
                    // Solo si existe o el usuario eligió "Sí", mostrar el formulario
                    FormRegistrarCliente form = new FormRegistrarCliente(dniValor);
                    form.ShowDialog();
                }
            };
        }
    }
}
