using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Vista
{
    public partial class TicketsForm : Form
    {
        public TicketsForm()
        {
            InitializeComponent();
        }

        Cliente miCliente = null;
        ClienteDB clienteDB = new ClienteDB();
        List<Tickets> listaTickets = new List<Tickets>();
        TicketsDB ticketDB = new TicketsDB();

        decimal subTotal = 0;
        decimal isv = 0;
        decimal totalAPagar = 0;
        decimal descuento = 0;


        private void IdentidadTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {


            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-') // solo permite números, "-" y teclas de control (como Enter y Borrar)
            {
                e.Handled = true; // indica que el evento de tecla se ha manejado y no se debe procesar más
            }
            else if (e.KeyChar == (char)Keys.Enter && !string.IsNullOrEmpty(IdentidadTextBox.Text))
            {
                try
                {
                    miCliente = new Cliente();
                    miCliente = clienteDB.DevolverClientePorIdentidad(IdentidadTextBox.Text);
                    NombreClienteTextBox.Text = miCliente.Nombre;
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show("El número de identidad que usted ingresó no está en la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    miCliente = null;
                    NombreClienteTextBox.Clear();
                }
            }
            else
            {
                miCliente = null;
                NombreClienteTextBox.Clear();
            }

        }

        private void BuscarClienteButton_Click(object sender, System.EventArgs e)
        {
            BuscarClienteForm form = new BuscarClienteForm();
            form.ShowDialog();
            miCliente = new Cliente();
            miCliente = form.cliente;
            IdentidadTextBox.Text = miCliente.Identidad;
            NombreClienteTextBox.Text = miCliente.Nombre;

        }

        private void TicketsForm_Load(object sender, EventArgs e)
        {
            UsuarioTextBox.Text = System.Threading.Thread.CurrentPrincipal.Identity.Name;
        }


        private void GuardarButton_Click(object sender, EventArgs e)
        {

            if (IdentidadTextBox.Text == string.Empty)
            {
                errorProvider1.SetError(IdentidadTextBox, "Ingrese DNI del cliente");
                IdentidadTextBox.Focus();
                return;
            }
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(TipoSoporteComboBox.Text))
            {
                errorProvider1.SetError(TipoSoporteComboBox, "Seleccione un tipo de Servicio");
                TipoSoporteComboBox.Focus();
                return;
            }
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(DescripcionSolicitudTextBox.Text))
            {
                errorProvider1.SetError(DescripcionSolicitudTextBox, "Ingrese la descripcion de la solicitud");
                DescripcionSolicitudTextBox.Focus();
                return;
            }
            if (string.IsNullOrEmpty(PrecioTextBox.Text))
            {
                errorProvider1.SetError(PrecioTextBox, "Ingrese un precio");
                PrecioTextBox.Focus();
                return;
            }
            errorProvider1.Clear();

            if (string.IsNullOrEmpty(DescuentoTextBox.Text))
            {
                errorProvider1.SetError(DescuentoTextBox, "Si no hay descuento por favor ingresar valor: 0");
                DescuentoTextBox.Focus();
                return;
            }

            Tickets miTicket = new Tickets();
            miTicket.Fecha = FechaDateTimePicker.Value;
            miTicket.CodigoUsuario = System.Threading.Thread.CurrentPrincipal.Identity.Name;
            miTicket.IdentidadCliente = miCliente.Identidad;
            miTicket.TipoSoporte = TipoSoporteComboBox.SelectedItem.ToString();
            miTicket.DescripcionSolicitud = DescripcionSolicitudTextBox.Text;
            miTicket.DescripcionRespuesta = DescripcionRespuestaTextBox.Text;
            miTicket.Precio = Convert.ToDecimal(PrecioTextBox.Text);
            miTicket.SubTotal = subTotal;
            miTicket.ISV = isv;
            miTicket.Descuento = descuento;
            miTicket.Total = totalAPagar;

            bool inserto = ticketDB.Guardar(miTicket, listaTickets);

            if (inserto)
            {
                LimpiarControles();
                IdentidadTextBox.Focus();
                MessageBox.Show("Ticket registrado exitosamente");
            }
            else
                MessageBox.Show("No se pudo registrar el Ticket");

            this.Close();
        }

        private void LimpiarControles()
        {
            miCliente = null;
            listaTickets = null;
            FechaDateTimePicker.Value = DateTime.Now;
            IdentidadTextBox.Clear();
            NombreClienteTextBox.Clear();
            TipoSoporteComboBox.Items.Clear();
            DescripcionSolicitudTextBox.Clear();
            DescripcionRespuestaTextBox.Clear();
            DetalleDataGridView.DataSource = null;
            PrecioTextBox.Clear();
            subTotal = 0;
            SubTotalTextBox.Clear();
            isv = 0;
            ISVTextBox.Clear();
            descuento = 0;
            DescuentoTextBox.Clear();
            totalAPagar = 0;
            TotalTextBox.Clear();

        }



        private void AgregarButton_Click(object sender, EventArgs e)
        {

            if (IdentidadTextBox.Text == string.Empty)
            {
                errorProvider1.SetError(IdentidadTextBox, "Ingrese DNI del cliente");
                IdentidadTextBox.Focus();
                return;
            }
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(TipoSoporteComboBox.Text))
            {
                errorProvider1.SetError(TipoSoporteComboBox, "Seleccione un tipo de Servicio");
                TipoSoporteComboBox.Focus();
                return;
            }
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(DescripcionSolicitudTextBox.Text))
            {
                errorProvider1.SetError(DescripcionSolicitudTextBox, "Ingrese la descripcion de la solicitud");
                DescripcionSolicitudTextBox.Focus();
                return;
            }
            if (string.IsNullOrEmpty(PrecioTextBox.Text))
            {
                errorProvider1.SetError(PrecioTextBox, "Ingrese un precio");
                PrecioTextBox.Focus();
                return;
            }
            errorProvider1.Clear();

            if (string.IsNullOrEmpty(DescuentoTextBox.Text))
            {
                errorProvider1.SetError(DescuentoTextBox, "Si no hay descuento por favor ingresar valor: 0");
                DescuentoTextBox.Focus();
                return;
            }


            Tickets ticket = new Tickets();
            ticket.Fecha = FechaDateTimePicker.Value;
            ticket.IdentidadCliente = miCliente.Identidad;
            ticket.CodigoUsuario = System.Threading.Thread.CurrentPrincipal.Identity.Name;
            ticket.TipoSoporte = TipoSoporteComboBox.Text;
            ticket.DescripcionSolicitud = DescripcionSolicitudTextBox.Text;
            ticket.DescripcionRespuesta = DescripcionRespuestaTextBox.Text;
            ticket.Precio = Convert.ToDecimal(PrecioTextBox.Text);


            subTotal = ticket.Precio * 1;
            isv = subTotal * 0.15M;
            totalAPagar = subTotal + isv;
            descuento = Convert.ToDecimal(DescuentoTextBox.Text);
            totalAPagar = totalAPagar - descuento;
            TotalTextBox.Text = totalAPagar.ToString();

            ticket.ISV = isv;
            ticket.SubTotal = subTotal;
            ticket.Total = totalAPagar;
            ticket.Descuento = descuento;


            listaTickets.Add(ticket);
            DetalleDataGridView.DataSource = null;
            DetalleDataGridView.DataSource = listaTickets;

            SubTotalTextBox.Text = subTotal.ToString("N2");
            ISVTextBox.Text = isv.ToString("N2");
            TotalTextBox.Text = totalAPagar.ToString("N2");
            TipoSoporteComboBox.Text = TipoSoporteComboBox.Text;


            IdentidadTextBox.Enabled = false;
            BuscarClienteButton.Enabled = false;
            NombreClienteTextBox.Enabled = false;
            FechaDateTimePicker.Enabled = false;
            TipoSoporteComboBox.Enabled = false;
            DescripcionRespuestaTextBox.Enabled = false;
            DescripcionSolicitudTextBox.Enabled = false;
            PrecioTextBox.Enabled = false;
            DescuentoTextBox.Enabled = false;
            AgregarButton.Enabled = false;

        }


        private void PrecioTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            {

                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                    (e.KeyChar != '.'))
                {

                    e.Handled = true;
                }


                if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                }


                if ((char.IsDigit(e.KeyChar)) && ((sender as TextBox).Text.IndexOf('.') > -1 || (sender as TextBox).Text.IndexOf(',') > -1))
                {
                    int index = (sender as TextBox).Text.IndexOf('.') > -1 ? (sender as TextBox).Text.IndexOf('.') : (sender as TextBox).Text.IndexOf(',');
                    if ((sender as TextBox).Text.Substring(index).Length >= 3)
                    {
                        e.Handled = true;
                    }


                }


            }

        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void DescuentoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            {

                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                    (e.KeyChar != '.'))
                {

                    e.Handled = true;
                }


                if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                }


                if ((char.IsDigit(e.KeyChar)) && ((sender as TextBox).Text.IndexOf('.') > -1 || (sender as TextBox).Text.IndexOf(',') > -1))
                {
                    int index = (sender as TextBox).Text.IndexOf('.') > -1 ? (sender as TextBox).Text.IndexOf('.') : (sender as TextBox).Text.IndexOf(',');
                    if ((sender as TextBox).Text.Substring(index).Length >= 3)
                    {
                        e.Handled = true;
                    }


                }


            }

        }

    }
}
