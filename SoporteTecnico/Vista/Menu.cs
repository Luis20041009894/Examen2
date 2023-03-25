using System;
using System.Windows.Forms;

namespace Vista
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void UsuariosToolStripButton_Click(object sender, EventArgs e)
        {
            UsuariosForm userForm = new UsuariosForm();
            userForm.MdiParent = this;
            userForm.Show();
        }


        private void SalirButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ClientesToolStripButton_Click(object sender, EventArgs e)
        {
            ClienteForm clienteForm = new ClienteForm();
            clienteForm.MdiParent = this;
            clienteForm.Show();
        }

        private void NuevaFacturaToolStripButton_Click(object sender, EventArgs e)
        {
            TicketsForm facturaform = new TicketsForm();
            facturaform.MdiParent = this;
            facturaform.Show();
        }

        private void backStageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
