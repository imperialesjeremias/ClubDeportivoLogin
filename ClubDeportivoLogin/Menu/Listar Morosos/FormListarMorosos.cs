using MySql.Data.MySqlClient;
using System.Data;
using System.Drawing.Printing;

namespace ClubDeportivoLogin
{
    public partial class FormListarMorosos : Form
    {
        public FormListarMorosos()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += frmSociosMorosos_KeyDown;
        }

        private void frmSociosMorosos_Load(object sender, EventArgs e)
        {
            CargarMorosos();
        }

        private void frmSociosMorosos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void CargarMorosos()
        {
            try
            {
                Conexion conn = new Conexion();
                using MySqlConnection conexion = conn.Conectar();
                string query = @"
                SELECT 
                c.nombre AS Nombre, 
                c.apellido AS Apellido, 
                c.dni AS DNI, 
                s.numeroCarnet AS 'N° Carnet', 
                s.fechaVencimientoCuota AS 'Vencimiento Cuota'
                FROM Cliente c
                INNER JOIN Socio s ON c.id = s.id
                WHERE s.fechaBaja IS NULL
                AND EXISTS (
                            SELECT 1 FROM Cuota cu
                            WHERE cu.idSocio = s.id
                            AND cu.fechaVencimiento < CURDATE()
                            AND cu.fechaPago IS NULL
                            )
                ORDER BY s.fechaVencimientoCuota ASC";

                using MySqlCommand cmd = new MySqlCommand(query, conexion);
                using MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);

                // Agregar columna "Días de atraso"
                tabla.Columns.Add("Días de atraso", typeof(int));

                foreach (DataRow row in tabla.Rows)
                {
                    if (DateTime.TryParse(row["Vencimiento Cuota"]?.ToString(), out DateTime fechaVenc))
                    {
                        int dias = (DateTime.Today - fechaVenc.Date).Days;
                        row["Días de atraso"] = dias > 0 ? dias : 0;
                    }
                    else
                    {
                        row["Días de atraso"] = 0;
                    }
                }

                dgvMorosos.DataSource = tabla;
                ConfigurarGrid();
                dgvMorosos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar socios morosos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarGrid()
        {
            dgvMorosos.ReadOnly = true;
            dgvMorosos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMorosos.MultiSelect = false;
            dgvMorosos.AllowUserToAddRows = false;
            dgvMorosos.AllowUserToDeleteRows = false;
            dgvMorosos.AllowUserToResizeRows = false;
            dgvMorosos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvMorosos.RowHeadersVisible = false;
            dgvMorosos.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvMorosos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvMorosos.DefaultCellStyle.BackColor = Color.White;
            dgvMorosos.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgvMorosos.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
            dgvMorosos.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += PrintListadoMorosos;
            PrintPreviewDialog preview = new PrintPreviewDialog
            {
                Document = printDoc,
                Width = 900,
                Height = 700
            };
            preview.ShowDialog();
        }

        private void PrintListadoMorosos(object sender, PrintPageEventArgs e)
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
            string titulo = "Listado de Socios Morosos";
            SizeF sizeTitulo = e.Graphics.MeasureString(titulo, fontTitle);
            float tituloX = pageLeft + (pageWidth - sizeTitulo.Width) / 2;
            e.Graphics.DrawString(titulo, fontTitle, Brushes.Black, tituloX, y);
            y += (int)sizeTitulo.Height + 20;

            // Calcular anchos de columnas
            int[] colWidths = new int[dgvMorosos.Columns.Count];
            int totalWidth = 0;
            for (int i = 0; i < dgvMorosos.Columns.Count; i++)
            {
                // Ajusta el ancho mínimo para que no se corte el texto
                int ancho = Math.Max(100, dgvMorosos.Columns[i].Width);
                colWidths[i] = ancho;
                totalWidth += ancho + colSpacing;
            }
            totalWidth -= colSpacing; // Quitar el último espacio extra

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
            for (int i = 0; i < dgvMorosos.Columns.Count; i++)
            {
                string header = dgvMorosos.Columns[i].HeaderText;
                e.Graphics.DrawString(header, fontHeader, Brushes.Black, colX + 4, y);
                colX += colWidths[i] + colSpacing;
            }
            y += headerHeight + 2;

            // Filas
            foreach (DataGridViewRow row in dgvMorosos.Rows)
            {
                if (row.IsNewRow) continue;
                colX = x;
                for (int i = 0; i < dgvMorosos.Columns.Count; i++)
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
