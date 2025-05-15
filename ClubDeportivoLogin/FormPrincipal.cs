using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubDeportivoLogin
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void btnRegistrarCliente_Click(object sender, EventArgs e)
        {
            FormRegistrarCliente registroCliente = new FormRegistrarCliente();
            registroCliente.ShowDialog(); // ShowDialog abre como ventana modal
        }
    }
}
