using Datos;
using Entidades;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Vista
{
    public partial class UsuariosForm : Syncfusion.Windows.Forms.Office2010Form
    {
        public UsuariosForm()
        {
            InitializeComponent();
        }
        string TipodeOperacion;

        DataTable dt = new DataTable();
        UsuarioDB UsuarioDB = new UsuarioDB();
        Usuario user = new Usuario();

        private void AdjuntarButton_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult resultado = dialog.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                FotoPictureBox.Image = Image.FromFile(dialog.FileName);
            }

        }

        private void NuevoButton_Click(object sender, System.EventArgs e)
        {
            CodigoTextBox.Focus();
            HabilitarControl();
            TipodeOperacion = "Nuevo";
        }

        private void CancelarButton_Click(object sender, System.EventArgs e)
        {
            DeshabilitarControl();
            LimpiarControles();
        }

        private void HabilitarControl()
        {
            CodigoTextBox.Enabled = true;
            NombreTextBox.Enabled = true;
            ContraseñaTextBox.Enabled = true;
            CorreoTextBox.Enabled = true;
            RolComboBox.Enabled = true;
            EstadoActivoCheckBox.Enabled = true;
            AdjuntarFotoButton.Enabled = true;
            GuardarButton.Enabled = true;
            CancelarButton.Enabled = true;
            ModificarButton.Enabled = false;
        }

        private void DeshabilitarControl()
        {
            CodigoTextBox.Enabled = false;
            NombreTextBox.Enabled = false;
            ContraseñaTextBox.Enabled = false;
            CorreoTextBox.Enabled = false;
            RolComboBox.Enabled = false;
            EstadoActivoCheckBox.Enabled = false;
            AdjuntarFotoButton.Enabled = false;
            GuardarButton.Enabled = false;
            CancelarButton.Enabled = false;
            ModificarButton.Enabled = true;

        }

        private void LimpiarControles()
        {
            CodigoTextBox.Clear();
            NombreTextBox.Clear();
            ContraseñaTextBox.Clear();
            CorreoTextBox.Clear();
            RolComboBox.Items.Clear();
            EstadoActivoCheckBox.Checked = false;
            FotoPictureBox.Image = null;
        }

        private void ModificarButton_Click(object sender, EventArgs e)
        {
            TipodeOperacion = "Modificar";
            if (UsuariosDataGridView.SelectedRows.Count > 0)
            {
                CodigoTextBox.Text = UsuariosDataGridView.CurrentRow.Cells["CodigoUsuario"].Value.ToString();
                NombreTextBox.Text = UsuariosDataGridView.CurrentRow.Cells["Nombre"].Value.ToString();
                ContraseñaTextBox.Text = UsuariosDataGridView.CurrentRow.Cells["Contrasena"].Value.ToString();
                CorreoTextBox.Text = UsuariosDataGridView.CurrentRow.Cells["Correo"].Value.ToString();
                RolComboBox.Text = UsuariosDataGridView.CurrentRow.Cells["Rol"].Value.ToString();
                EstadoActivoCheckBox.Checked = Convert.ToBoolean(UsuariosDataGridView.CurrentRow.Cells["EstadoActivo"].Value);

                byte[] miFoto = UsuarioDB.DevolverFoto(UsuariosDataGridView.CurrentRow.Cells["CodigoUsuario"].Value.ToString());

                if (miFoto.Length > 0)
                {
                    MemoryStream ms = new MemoryStream(miFoto);
                    FotoPictureBox.Image = System.Drawing.Bitmap.FromStream(ms);
                }


                HabilitarControl();
                CodigoTextBox.Enabled = false;
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
                if (string.IsNullOrEmpty(CodigoTextBox.Text))
                {
                    errorProvider1.SetError(CodigoTextBox, "Ingrese un código");
                    CodigoTextBox.Focus();
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
                if (string.IsNullOrEmpty(ContraseñaTextBox.Text))
                {
                    errorProvider1.SetError(ContraseñaTextBox, "Ingrese una contraseña");
                    ContraseñaTextBox.Focus();
                    return;
                }
                errorProvider1.Clear();
                if (string.IsNullOrEmpty(RolComboBox.Text))
                {
                    errorProvider1.SetError(RolComboBox, "Seleccione un Rol");
                    RolComboBox.Focus();
                    return;
                }
                errorProvider1.Clear();

                user.CodigoUsuario = CodigoTextBox.Text;
                user.Nombre = NombreTextBox.Text;
                user.Contraseña = ContraseñaTextBox.Text;
                user.Rol = RolComboBox.Text;
                user.Correo = CorreoTextBox.Text;
                user.EstadoActivo = EstadoActivoCheckBox.Checked;

                if (FotoPictureBox.Image != null)
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();

                    FotoPictureBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    user.Foto = ms.GetBuffer();
                }

                //Insertar en la base de datos

                bool inserto = UsuarioDB.Insertar(user);

                if (inserto)
                {
                    LimpiarControles();
                    DeshabilitarControl();
                    TraerUsuarios();
                    MessageBox.Show("Registro Guardado");
                }
                else
                {
                    MessageBox.Show("No se pudo gardar el registro");

                }

            }


            else if (TipodeOperacion == "Modificar")
            {
                user.CodigoUsuario = CodigoTextBox.Text;
                user.Nombre = NombreTextBox.Text;
                user.Contraseña = ContraseñaTextBox.Text;
                user.Rol = RolComboBox.Text;
                user.Correo = CorreoTextBox.Text;
                user.EstadoActivo = EstadoActivoCheckBox.Checked;

                if (FotoPictureBox.Image != null)
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();

                    FotoPictureBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    user.Foto = ms.GetBuffer();
                }
                bool modifico = UsuarioDB.Editar(user);
                if (modifico)
                {
                    LimpiarControles();
                    DeshabilitarControl();
                    TraerUsuarios();
                    MessageBox.Show("Registro actualizado correctamente");
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el Registro");

                }

            }

        }

        private void UsuariosForm_Load(object sender, EventArgs e)
        {
            TraerUsuarios();
        }

        private void TraerUsuarios()
        {
            dt = UsuarioDB.DevolverUsuarios();
            UsuariosDataGridView.DataSource = dt;

        }

        private void RegresarButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            if (UsuariosDataGridView.SelectedRows.Count > 0)
            {
                DialogResult resultado = MessageBox.Show("¿Esta seguro de eliminar el registro?", "Advertencia", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    bool elimino = UsuarioDB.Eliminar(UsuariosDataGridView.CurrentRow.Cells["CodigoUsuario"].Value.ToString());
                    if (elimino)
                    {
                        LimpiarControles();
                        DeshabilitarControl();
                        TraerUsuarios();
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
    }
}
