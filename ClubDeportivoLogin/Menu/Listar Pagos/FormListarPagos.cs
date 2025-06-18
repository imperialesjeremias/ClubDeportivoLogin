using MySql.Data.MySqlClient;
using System.Data;
using System.Drawing.Printing;

namespace ClubDeportivoLogin.pagos
{
    public partial class FormListarPagos : Form
    {
        public FormListarPagos()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += FormListarPagos_KeyDown;
        }

        private void FormListarPagos_Load(object sender, EventArgs e)
        {
            CargarPagos();
        }

        private void FormListarPagos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.DefaultPageSettings.Landscape = true;
            printDoc.PrintPage += PrintListadoPagos;
            PrintPreviewDialog preview = new PrintPreviewDialog
            {
                Document = printDoc,
                Width = 900,
                Height = 700
            };
            preview.ShowDialog();
        }

        private void CargarPagos()
        {
            try
            {
                Conexion conn = new Conexion();
                using MySqlConnection conexion = conn.Conectar();
                string query = @"
                SELECT 
                DATE_FORMAT(c.fechaPago, '%d/%m/%Y') AS 'Fecha de Pago',
                CONCAT(cli.nombre, ' ', cli.apellido) AS 'Nombre y Apellido',
                c.medioPago AS 'Medio de Pago',
                CONCAT('$ ', FORMAT(c.montoTotal, 2, 'es_AR')) AS 'Monto Total',
                'ABONO MENSUAL' AS Concepto,
                'Acceso a todas' AS Actividad
                FROM Cuota c
                INNER JOIN Cliente cli ON cli.id = c.idSocio
                WHERE c.fechaPago IS NOT NULL

                UNION ALL

                SELECT 
                DATE_FORMAT(r.fechaPago, '%d/%m/%Y') AS 'Fecha de Pago',
                CONCAT(cli.nombre, ' ', cli.apellido) AS 'Nombre y Apellido',
                r.medioPago AS 'Medio de Pago',
                CONCAT('$ ', FORMAT(r.montoCobrado, 2, 'es_AR')) AS 'Monto Total',
                'PASE DIARIO' AS Concepto,
                a.nombre AS Actividad
                FROM RegistroActividad r
                INNER JOIN Cliente cli ON cli.id = r.idNoSocio
                INNER JOIN Actividad a ON a.id = r.idActividad
                WHERE r.fechaPago IS NOT NULL

                ORDER BY `Fecha de Pago` DESC
                ";

                using MySqlCommand cmd = new MySqlCommand(query, conexion);
                using MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);

                dgvPagos.DataSource = tabla;
                ConfigurarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar pagos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarGrid()
        {
            dgvPagos.ReadOnly = true;
            dgvPagos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPagos.MultiSelect = false;
            dgvPagos.AllowUserToAddRows = false;
            dgvPagos.AllowUserToDeleteRows = false;
            dgvPagos.AllowUserToResizeRows = false;
            dgvPagos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvPagos.RowHeadersVisible = false;
            dgvPagos.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvPagos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvPagos.DefaultCellStyle.BackColor = Color.White;
            dgvPagos.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgvPagos.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
            dgvPagos.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void PrintListadoPagos(object sender, PrintPageEventArgs e)
        {
            int left = 40;
            int top = 40;
            int y = top;
            int colSpacing = 20;
            int pageWidth = e.MarginBounds.Width;
            int pageLeft = e.MarginBounds.Left;

            // Fuentes
            Font fontTitle = new Font("Segoe UI", 20, FontStyle.Bold);
            Font fontHeader = new Font("Segoe UI", 11, FontStyle.Bold);
            Font fontBody = new Font("Segoe UI", 10);

            // Título centrado
            string titulo = "Listado de Pagos";
            SizeF sizeTitulo = e.Graphics.MeasureString(titulo, fontTitle);
            float tituloX = pageLeft + (pageWidth - sizeTitulo.Width) / 2;
            e.Graphics.DrawString(titulo, fontTitle, Brushes.Black, tituloX, y);
            y += (int)sizeTitulo.Height + 20;

            // Calcular anchos de columnas
            int[] colWidths = new int[dgvPagos.Columns.Count];
            int totalWidth = 0;
            for (int i = 0; i < dgvPagos.Columns.Count; i++)
            {
                int ancho = Math.Max(100, dgvPagos.Columns[i].Width);
                colWidths[i] = ancho;
                totalWidth += ancho + colSpacing;
            }
            totalWidth -= colSpacing;

            // Encabezados con fondo sombreado y recuadro
            int x = pageLeft + (pageWidth - totalWidth) / 2;
            int headerHeight = (int)e.Graphics.MeasureString("Ay", fontHeader).Height + 10;
            Rectangle headerRect = new Rectangle(x - 4, y - 2, totalWidth + 8, headerHeight + 4);
            using (SolidBrush brush = new SolidBrush(Color.LightSteelBlue))
            {
                e.Graphics.FillRectangle(brush, headerRect);
            }
            using (Pen pen = new Pen(Color.SteelBlue, 2))
            {
                e.Graphics.DrawRectangle(pen, headerRect);
            }

            // Dibujar los textos de los encabezados
            int colX = x;
            for (int i = 0; i < dgvPagos.Columns.Count; i++)
            {
                string header = dgvPagos.Columns[i].HeaderText;
                e.Graphics.DrawString(header, fontHeader, Brushes.Black, colX + 4, y);
                colX += colWidths[i] + colSpacing;
            }
            y += headerHeight + 2;

            // Filas
            foreach (DataGridViewRow row in dgvPagos.Rows)
            {
                if (row.IsNewRow) continue;
                colX = x;
                for (int i = 0; i < dgvPagos.Columns.Count; i++)
                {
                    string text = row.Cells[i].Value?.ToString() ?? "";
                    e.Graphics.DrawString(text, fontBody, Brushes.Black, colX + 4, y);
                    colX += colWidths[i] + colSpacing;
                }
                y += 25;
                if (y > e.MarginBounds.Bottom - 40)
                {
                    e.HasMorePages = true;
                    return;
                }
            }
        }
    }
}