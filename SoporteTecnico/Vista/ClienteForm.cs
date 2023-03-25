using Datos;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace Vista
{
    public partial class ClienteForm : Form
    {
        public ClienteForm()
        {
            InitializeComponent();
        }

        string TipodeOperacion;

        DataTable dt = new DataTable();
        ClienteDB clienteDB = new ClienteDB();
        Cliente cliente = new Cliente();


        private void NuevoButton_Click(object sender, EventArgs e)
        {
            IdTextBox.Focus();
            HabilitarControl();
            LimpiarControles();
            TipodeOperacion = "Nuevo";
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DeshabilitarControl();
            LimpiarControles();
        }
        private void HabilitarControl(Boolean modificando = false)
        {
            IdTextBox.Enabled = !modificando;
            NombreTextBox.Enabled = true;
            TelefonoTextBox.Enabled = true;
            CorreoTextBox.Enabled = true;
            DireccionTextBox.Enabled = true;
            FechaNacimientoDateTimePicker.Enabled = true;
            EstadoActivoCheckBox.Enabled = true;
            GuardarButton.Enabled = true;
            CancelarButton.Enabled = true;
            ModificarButton.Enabled = false;
        }

        private void DeshabilitarControl()
        {
            IdTextBox.Enabled = false;
            NombreTextBox.Enabled = false;
            TelefonoTextBox.Enabled = false;
            CorreoTextBox.Enabled = false;
            DireccionTextBox.Enabled = false;
            FechaNacimientoDateTimePicker.Enabled = false;
            EstadoActivoCheckBox.Enabled = false;
            GuardarButton.Enabled = false;
            CancelarButton.Enabled = false;
            ModificarButton.Enabled = true;

        }
        private void LimpiarControles()
        {
            IdTextBox.Clear();
            NombreTextBox.Clear();
            TelefonoTextBox.Clear();
            CorreoTextBox.Clear();
            DireccionTextBox.Clear();
            FechaNacimientoDateTimePicker.Value = new DateTime(1950, 1, 01);
            EstadoActivoCheckBox.Checked = false;
        }

        private void ModificarButton_Click(object sender, EventArgs e)
        {
            TipodeOperacion = "Modificar";
            if (ClienteDataGridView.SelectedRows.Count > 0)
            {
                IdTextBox.Text = ClienteDataGridView.CurrentRow.Cells["Identidad"].Value.ToString();
                NombreTextBox.Text = ClienteDataGridView.CurrentRow.Cells["Nombre"].Value.ToString();
                TelefonoTextBox.Text = ClienteDataGridView.CurrentRow.Cells["Telefono"].Value.ToString();
                CorreoTextBox.Text = ClienteDataGridView.CurrentRow.Cells["Correo"].Value.ToString();
                DireccionTextBox.Text = ClienteDataGridView.CurrentRow.Cells["Direccion"].Value.ToString();
                EstadoActivoCheckBox.Checked = Convert.ToBoolean(ClienteDataGridView.CurrentRow.Cells["EstadoActivo"].Value);

                HabilitarControl(true);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro");
            }
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if (TipodeOperacion == "Nuevo")
            {
                if (string.IsNullOrEmpty(IdTextBox.Text))
                {
                    errorProvider1.SetError(IdTextBox, "Ingrese un código");
                    IdTextBox.Focus();
                    return;
                }
                errorProvider1.Clear();
                if (string.IsNullOrEmpty(NombreTextBox.Text))
                {
                    errorProvider1.SetError(NombreTextBox, "Ingrese un nombre");
                    NombreTextBox.Focus();
                    return;
                }
                errorProvider1.Clear();
                if (string.IsNullOrEmpty(TelefonoTextBox.Text))
                {
                    errorProvider1.SetError(TelefonoTextBox, "Ingrese un número de telefono");
                    TelefonoTextBox.Focus();
                    return;
                }
                errorProvider1.Clear();
                if (string.IsNullOrEmpty(CorreoTextBox.Text))
                {
                    errorProvider1.SetError(CorreoTextBox, "Ingrese un correo");
                    CorreoTextBox.Focus();
                    return;
                }
                errorProvider1.Clear();
                if (string.IsNullOrEmpty(DireccionTextBox.Text))
                {
                    errorProvider1.SetError(DireccionTextBox, "Ingrese una direccion");
                    DireccionTextBox.Focus();
                    return;
                }
                errorProvider1.Clear();

                cliente.Identidad = IdTextBox.Text;
                cliente.Nombre = NombreTextBox.Text;
                cliente.Telefono = TelefonoTextBox.Text;
                cliente.Correo = CorreoTextBox.Text;
                cliente.Direccion = DireccionTextBox.Text;
                cliente.FechaNacimiento = Convert.ToDateTime(FechaNacimientoDateTimePicker.Value);
                cliente.EstadoActivo = EstadoActivoCheckBox.Checked;


                //Insertar en la base de datos ** * * ** * * ** * * **

                bool inserto = clienteDB.Insertar(cliente);

                if (inserto)
                {
                    LimpiarControles();
                    DeshabilitarControl();
                    TraerClientes();
                    MessageBox.Show("Registro Guardado");
                }
                else
                {
                    MessageBox.Show("No se pudo gardar el registro");

                }

            }


            else if (TipodeOperacion == "Modificar")
            {
                cliente.Identidad = IdTextBox.Text;
                cliente.Nombre = NombreTextBox.Text;
                cliente.Telefono = TelefonoTextBox.Text;
                cliente.Correo = CorreoTextBox.Text;
                cliente.Direccion = DireccionTextBox.Text;
                cliente.FechaNacimiento = Convert.ToDateTime(FechaNacimientoDateTimePicker.Value);
                cliente.EstadoActivo = EstadoActivoCheckBox.Checked;


                bool modifico = clienteDB.Editar(cliente);
                if (modifico)
                {
                    LimpiarControles();
                    DeshabilitarControl();
                    TraerClientes();
                    MessageBox.Show("Registro actualizado correctamente");
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el Registro");

                }

            }
        }

        private void ClienteForm_Load(object sender, EventArgs e)
        {
            TraerClientes();
        }


        private void TraerClientes()
        {
            ClienteDataGridView.DataSource = clienteDB.DevolverClientes();

        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            if (ClienteDataGridView.SelectedRows.Count > 0)
            {
                DialogResult resultado = MessageBox.Show("¿Esta seguro de eliminar el registro?", "Advertencia", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    bool elimino = clienteDB.Eliminar(ClienteDataGridView.CurrentRow.Cells["Identidad"].Value.ToString());
                    if (elimino)
                    {
                        LimpiarControles();
                        DeshabilitarControl();
                        TraerClientes();
                        MessageBox.Show("Registro Eliminado");

                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el registro");
                    }
                }


            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro");
            }
        }

        private void RegresarButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
