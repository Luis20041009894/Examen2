namespace Vista
{
    partial class UsuariosForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.CodigoTextBox = new System.Windows.Forms.TextBox();
            this.NombreTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ContraseñaTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CorreoTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.RolComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.EstadoActivoCheckBox = new System.Windows.Forms.CheckBox();
            this.NuevoButton = new System.Windows.Forms.Button();
            this.AdjuntarFotoButton = new System.Windows.Forms.Button();
            this.FotoPictureBox = new System.Windows.Forms.PictureBox();
            this.CancelarButton = new System.Windows.Forms.Button();
            this.ModificarButton = new System.Windows.Forms.Button();
            this.GuardarButton = new System.Windows.Forms.Button();
            this.EliminarButton = new System.Windows.Forms.Button();
            this.UsuariosDataGridView = new System.Windows.Forms.DataGridView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.RegresarButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.FotoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsuariosDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código:";
            // 
            // CodigoTextBox
            // 
            this.CodigoTextBox.Enabled = false;
            this.CodigoTextBox.Location = new System.Drawing.Point(92, 19);
            this.CodigoTextBox.Name = "CodigoTextBox";
            this.CodigoTextBox.Size = new System.Drawing.Size(279, 22);
            this.CodigoTextBox.TabIndex = 1;
            // 
            // NombreTextBox
            // 
            this.NombreTextBox.Enabled = false;
            this.NombreTextBox.Location = new System.Drawing.Point(92, 71);
            this.NombreTextBox.Name = "NombreTextBox";
            this.NombreTextBox.Size = new System.Drawing.Size(279, 22);
            this.NombreTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre:";
            // 
            // ContraseñaTextBox
            // 
            this.ContraseñaTextBox.Enabled = false;
            this.ContraseñaTextBox.Location = new System.Drawing.Point(92, 123);
            this.ContraseñaTextBox.Name = "ContraseñaTextBox";
            this.ContraseñaTextBox.PasswordChar = '*';
            this.ContraseñaTextBox.Size = new System.Drawing.Size(279, 22);
            this.ContraseñaTextBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Contraseña:";
            // 
            // CorreoTextBox
            // 
            this.CorreoTextBox.Enabled = false;
            this.CorreoTextBox.Location = new System.Drawing.Point(92, 175);
            this.CorreoTextBox.Name = "CorreoTextBox";
            this.CorreoTextBox.Size = new System.Drawing.Size(279, 22);
            this.CorreoTextBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Correo:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Rol:";
            // 
            // RolComboBox
            // 
            this.RolComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RolComboBox.Enabled = false;
            this.RolComboBox.FormattingEnabled = true;
            this.RolComboBox.Items.AddRange(new object[] {
            "Administrador",
            "Usuario"});
            this.RolComboBox.Location = new System.Drawing.Point(92, 227);
            this.RolComboBox.Name = "RolComboBox";
            this.RolComboBox.Size = new System.Drawing.Size(279, 24);
            this.RolComboBox.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 280);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Esta Activo:";
            // 
            // EstadoActivoCheckBox
            // 
            this.EstadoActivoCheckBox.AutoSize = true;
            this.EstadoActivoCheckBox.Enabled = false;
            this.EstadoActivoCheckBox.Location = new System.Drawing.Point(92, 281);
            this.EstadoActivoCheckBox.Name = "EstadoActivoCheckBox";
            this.EstadoActivoCheckBox.Size = new System.Drawing.Size(18, 17);
            this.EstadoActivoCheckBox.TabIndex = 11;
            this.EstadoActivoCheckBox.UseVisualStyleBackColor = true;
            // 
            // NuevoButton
            // 
            this.NuevoButton.Location = new System.Drawing.Point(338, 264);
            this.NuevoButton.Name = "NuevoButton";
            this.NuevoButton.Size = new System.Drawing.Size(84, 49);
            this.NuevoButton.TabIndex = 14;
            this.NuevoButton.Text = "Nuevo";
            this.NuevoButton.UseVisualStyleBackColor = true;
            this.NuevoButton.Click += new System.EventHandler(this.NuevoButton_Click);
            // 
            // AdjuntarFotoButton
            // 
            this.AdjuntarFotoButton.Enabled = false;
            this.AdjuntarFotoButton.Image = global::Vista.Properties.Resources.imagen;
            this.AdjuntarFotoButton.Location = new System.Drawing.Point(726, 206);
            this.AdjuntarFotoButton.Name = "AdjuntarFotoButton";
            this.AdjuntarFotoButton.Size = new System.Drawing.Size(54, 43);
            this.AdjuntarFotoButton.TabIndex = 13;
            this.AdjuntarFotoButton.UseVisualStyleBackColor = true;
            this.AdjuntarFotoButton.Click += new System.EventHandler(this.AdjuntarButton_Click);
            // 
            // FotoPictureBox
            // 
            this.FotoPictureBox.BackColor = System.Drawing.Color.White;
            this.FotoPictureBox.Location = new System.Drawing.Point(421, 19);
            this.FotoPictureBox.Name = "FotoPictureBox";
            this.FotoPictureBox.Size = new System.Drawing.Size(271, 224);
            this.FotoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FotoPictureBox.TabIndex = 12;
            this.FotoPictureBox.TabStop = false;
            // 
            // CancelarButton
            // 
            this.CancelarButton.Enabled = false;
            this.CancelarButton.Location = new System.Drawing.Point(701, 264);
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(84, 49);
            this.CancelarButton.TabIndex = 15;
            this.CancelarButton.Text = "Cancelar";
            this.CancelarButton.UseVisualStyleBackColor = true;
            this.CancelarButton.Click += new System.EventHandler(this.CancelarButton_Click);
            // 
            // ModificarButton
            // 
            this.ModificarButton.Location = new System.Drawing.Point(428, 264);
            this.ModificarButton.Name = "ModificarButton";
            this.ModificarButton.Size = new System.Drawing.Size(84, 49);
            this.ModificarButton.TabIndex = 16;
            this.ModificarButton.Text = "Modificar";
            this.ModificarButton.UseVisualStyleBackColor = true;
            this.ModificarButton.Click += new System.EventHandler(this.ModificarButton_Click);
            // 
            // GuardarButton
            // 
            this.GuardarButton.Enabled = false;
            this.GuardarButton.Location = new System.Drawing.Point(518, 264);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(84, 49);
            this.GuardarButton.TabIndex = 17;
            this.GuardarButton.Text = "Guardar";
            this.GuardarButton.UseVisualStyleBackColor = true;
            this.GuardarButton.Click += new System.EventHandler(this.GuardarButton_Click);
            // 
            // EliminarButton
            // 
            this.EliminarButton.Location = new System.Drawing.Point(608, 264);
            this.EliminarButton.Name = "EliminarButton";
            this.EliminarButton.Size = new System.Drawing.Size(84, 49);
            this.EliminarButton.TabIndex = 18;
            this.EliminarButton.Text = "Eliminar";
            this.EliminarButton.UseVisualStyleBackColor = true;
            this.EliminarButton.Click += new System.EventHandler(this.EliminarButton_Click);
            // 
            // UsuariosDataGridView
            // 
            this.UsuariosDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.UsuariosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UsuariosDataGridView.Location = new System.Drawing.Point(2, 319);
            this.UsuariosDataGridView.Name = "UsuariosDataGridView";
            this.UsuariosDataGridView.RowHeadersWidth = 51;
            this.UsuariosDataGridView.RowTemplate.Height = 24;
            this.UsuariosDataGridView.Size = new System.Drawing.Size(1129, 221);
            this.UsuariosDataGridView.TabIndex = 19;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // RegresarButton
            // 
            this.RegresarButton.Location = new System.Drawing.Point(1038, 9);
            this.RegresarButton.Name = "RegresarButton";
            this.RegresarButton.Size = new System.Drawing.Size(84, 49);
            this.RegresarButton.TabIndex = 20;
            this.RegresarButton.Text = "Regresar";
            this.RegresarButton.UseVisualStyleBackColor = true;
            this.RegresarButton.Click += new System.EventHandler(this.RegresarButton_Click);
            // 
            // UsuariosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1134, 537);
            this.Controls.Add(this.RegresarButton);
            this.Controls.Add(this.UsuariosDataGridView);
            this.Controls.Add(this.EliminarButton);
            this.Controls.Add(this.GuardarButton);
            this.Controls.Add(this.ModificarButton);
            this.Controls.Add(this.CancelarButton);
            this.Controls.Add(this.NuevoButton);
            this.Controls.Add(this.AdjuntarFotoButton);
            this.Controls.Add(this.FotoPictureBox);
            this.Controls.Add(this.EstadoActivoCheckBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.RolComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CorreoTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ContraseñaTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NombreTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CodigoTextBox);
            this.Controls.Add(this.label1);
            this.Name = "UsuariosForm";
            this.Text = "Usuarios";
            this.Load += new System.EventHandler(this.UsuariosForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FotoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsuariosDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CodigoTextBox;
        private System.Windows.Forms.TextBox NombreTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ContraseñaTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox CorreoTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox RolComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox EstadoActivoCheckBox;
        private System.Windows.Forms.PictureBox FotoPictureBox;
        private System.Windows.Forms.Button AdjuntarFotoButton;
        private System.Windows.Forms.Button NuevoButton;
        private System.Windows.Forms.Button CancelarButton;
        private System.Windows.Forms.Button ModificarButton;
        private System.Windows.Forms.Button GuardarButton;
        private System.Windows.Forms.Button EliminarButton;
        private System.Windows.Forms.DataGridView UsuariosDataGridView;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button RegresarButton;
    }
}