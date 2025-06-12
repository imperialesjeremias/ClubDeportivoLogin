namespace ClubDeportivoLogin
{
    public static class ABMPagosConfig
    {
        public static FormABMBase.ConfigABM ObtenerConfig(string usuario)
        {
            return new FormABMBase.ConfigABM
            {
                TituloVentana = "ABM de Pagos",
                Titulo = "Gestor de Pagos",
                Subtitulo = "Asistente de A.B.M.",
                Ayuda1 = "Este asistente le ayudará a consultar, agregar, modificar o borrar un código de la tabla, y realizar cambios en el \"Gestor de pagos\".",
                Ayuda2 = "\"Seleccione el modo y complete los datos requeridos y presione \"Enter\" o botón \"Siguiente\" para continuar.",
                EtiquetaCampo = "DNI: ",
                Icono = Properties.Resources.PagoIcon,
                UsarModoPagos = true,
                Validacion = dni => dni.All(char.IsDigit) && dni.Length >= 7 && dni.Length <= 10,
                AccionSiguiente = datos =>
                {
                    if (datos.Contains("|"))
                    {
                        var partes = datos.Split('|');
                        string centro = partes[0];
                        if (int.TryParse(partes[1], out int idComprobante))
                            new FormRegistrarPago(centro, idComprobante).ShowDialog();
                    }
                    else
                    {
                        int dniValor = int.Parse(datos);
                        new FormRegistrarPago(dniValor).ShowDialog();
                    }
                }
            };
        }
    }
}