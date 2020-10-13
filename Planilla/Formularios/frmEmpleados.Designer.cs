namespace Planilla.Formularios
{
    partial class frmEmpleados
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtCelular = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.chkEmail = new System.Windows.Forms.CheckBox();
            this.chkCelular = new System.Windows.Forms.CheckBox();
            this.chkTelefono = new System.Windows.Forms.CheckBox();
            this.chkCedula = new System.Windows.Forms.CheckBox();
            this.chkNombre = new System.Windows.Forms.CheckBox();
            this.chkApellidos = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.txttipoDeDocumento = new System.Windows.Forms.TextBox();
            this.txtDepartamento = new System.Windows.Forms.TextBox();
            this.txtCiudad = new System.Windows.Forms.TextBox();
            this.txtCargoDelEmpleado = new System.Windows.Forms.TextBox();
            this.txtEstructuraOrganizacional = new System.Windows.Forms.TextBox();
            this.chkEstado = new System.Windows.Forms.CheckBox();
            this.chkTipoDeContrato = new System.Windows.Forms.CheckBox();
            this.chkDepartamento = new System.Windows.Forms.CheckBox();
            this.chkMunicipio = new System.Windows.Forms.CheckBox();
            this.chkCargo = new System.Windows.Forms.CheckBox();
            this.chkAreaLaboral = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsbNoRegistros = new System.Windows.Forms.ToolStripStatusLabel();
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsFiltrar = new System.Windows.Forms.ToolStripButton();
            this.tsNuevoRegistro = new System.Windows.Forms.ToolStripButton();
            this.tsImprimir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsMarcarTodo = new System.Windows.Forms.ToolStripButton();
            this.tsSeleccionar = new System.Windows.Forms.ToolStripButton();
            this.tsFiltroAutomatico = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            this.tsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.statusStrip1);
            this.splitContainer1.Panel2.Controls.Add(this.dgvLista);
            this.splitContainer1.Panel2.Controls.Add(this.tsMenu);
            this.splitContainer1.Size = new System.Drawing.Size(1115, 656);
            this.splitContainer1.SplitterDistance = 305;
            this.splitContainer1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.groupBox2);
            this.flowLayoutPanel1.Controls.Add(this.groupBox3);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1115, 305);
            this.flowLayoutPanel1.TabIndex = 12;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtEmail);
            this.groupBox2.Controls.Add(this.txtCelular);
            this.groupBox2.Controls.Add(this.txtTelefono);
            this.groupBox2.Controls.Add(this.txtCedula);
            this.groupBox2.Controls.Add(this.txtApellidos);
            this.groupBox2.Controls.Add(this.txtNombre);
            this.groupBox2.Controls.Add(this.chkEmail);
            this.groupBox2.Controls.Add(this.chkCelular);
            this.groupBox2.Controls.Add(this.chkTelefono);
            this.groupBox2.Controls.Add(this.chkCedula);
            this.groupBox2.Controls.Add(this.chkNombre);
            this.groupBox2.Controls.Add(this.chkApellidos);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(536, 234);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(155, 198);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(374, 20);
            this.txtEmail.TabIndex = 11;
            // 
            // txtCelular
            // 
            this.txtCelular.Location = new System.Drawing.Point(156, 162);
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.Size = new System.Drawing.Size(374, 20);
            this.txtCelular.TabIndex = 10;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(156, 125);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(374, 20);
            this.txtTelefono.TabIndex = 9;
            // 
            // txtCedula
            // 
            this.txtCedula.Location = new System.Drawing.Point(156, 88);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(374, 20);
            this.txtCedula.TabIndex = 8;
            // 
            // txtApellidos
            // 
            this.txtApellidos.Location = new System.Drawing.Point(155, 53);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(374, 20);
            this.txtApellidos.TabIndex = 7;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(156, 19);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(374, 20);
            this.txtNombre.TabIndex = 6;
            // 
            // chkEmail
            // 
            this.chkEmail.AutoSize = true;
            this.chkEmail.Location = new System.Drawing.Point(30, 200);
            this.chkEmail.Name = "chkEmail";
            this.chkEmail.Size = new System.Drawing.Size(119, 17);
            this.chkEmail.TabIndex = 5;
            this.chkEmail.Tag = "Email";
            this.chkEmail.Text = "Corrreo Electronico:";
            this.chkEmail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkEmail.UseVisualStyleBackColor = true;
            // 
            // chkCelular
            // 
            this.chkCelular.AutoSize = true;
            this.chkCelular.Location = new System.Drawing.Point(30, 164);
            this.chkCelular.Name = "chkCelular";
            this.chkCelular.Size = new System.Drawing.Size(61, 17);
            this.chkCelular.TabIndex = 4;
            this.chkCelular.Tag = "Celular";
            this.chkCelular.Text = "Celular:";
            this.chkCelular.UseVisualStyleBackColor = true;
            // 
            // chkTelefono
            // 
            this.chkTelefono.AutoSize = true;
            this.chkTelefono.Location = new System.Drawing.Point(30, 127);
            this.chkTelefono.Name = "chkTelefono";
            this.chkTelefono.Size = new System.Drawing.Size(71, 17);
            this.chkTelefono.TabIndex = 3;
            this.chkTelefono.Tag = "Telefono";
            this.chkTelefono.Text = "Telefono:";
            this.chkTelefono.UseVisualStyleBackColor = true;
            // 
            // chkCedula
            // 
            this.chkCedula.AutoSize = true;
            this.chkCedula.Location = new System.Drawing.Point(30, 90);
            this.chkCedula.Name = "chkCedula";
            this.chkCedula.Size = new System.Drawing.Size(62, 17);
            this.chkCedula.TabIndex = 2;
            this.chkCedula.Tag = "Cedula";
            this.chkCedula.Text = "Cedula:";
            this.chkCedula.UseVisualStyleBackColor = true;
            // 
            // chkNombre
            // 
            this.chkNombre.AutoSize = true;
            this.chkNombre.Location = new System.Drawing.Point(30, 21);
            this.chkNombre.Name = "chkNombre";
            this.chkNombre.Size = new System.Drawing.Size(66, 17);
            this.chkNombre.TabIndex = 1;
            this.chkNombre.Tag = "Nombre";
            this.chkNombre.Text = "Nombre:";
            this.chkNombre.UseVisualStyleBackColor = true;
            // 
            // chkApellidos
            // 
            this.chkApellidos.AutoSize = true;
            this.chkApellidos.Location = new System.Drawing.Point(30, 55);
            this.chkApellidos.Name = "chkApellidos";
            this.chkApellidos.Size = new System.Drawing.Size(71, 17);
            this.chkApellidos.TabIndex = 0;
            this.chkApellidos.Tag = "Apellidos";
            this.chkApellidos.Text = "Apellidos:";
            this.chkApellidos.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtEstado);
            this.groupBox3.Controls.Add(this.txttipoDeDocumento);
            this.groupBox3.Controls.Add(this.txtDepartamento);
            this.groupBox3.Controls.Add(this.txtCiudad);
            this.groupBox3.Controls.Add(this.txtCargoDelEmpleado);
            this.groupBox3.Controls.Add(this.txtEstructuraOrganizacional);
            this.groupBox3.Controls.Add(this.chkEstado);
            this.groupBox3.Controls.Add(this.chkTipoDeContrato);
            this.groupBox3.Controls.Add(this.chkDepartamento);
            this.groupBox3.Controls.Add(this.chkMunicipio);
            this.groupBox3.Controls.Add(this.chkCargo);
            this.groupBox3.Controls.Add(this.chkAreaLaboral);
            this.groupBox3.Location = new System.Drawing.Point(545, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(558, 234);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(162, 138);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(390, 20);
            this.txtEstado.TabIndex = 11;
            // 
            // txttipoDeDocumento
            // 
            this.txttipoDeDocumento.Location = new System.Drawing.Point(162, 114);
            this.txttipoDeDocumento.Name = "txttipoDeDocumento";
            this.txttipoDeDocumento.Size = new System.Drawing.Size(390, 20);
            this.txttipoDeDocumento.TabIndex = 10;
            // 
            // txtDepartamento
            // 
            this.txtDepartamento.Location = new System.Drawing.Point(162, 90);
            this.txtDepartamento.Name = "txtDepartamento";
            this.txtDepartamento.Size = new System.Drawing.Size(390, 20);
            this.txtDepartamento.TabIndex = 9;
            // 
            // txtCiudad
            // 
            this.txtCiudad.Location = new System.Drawing.Point(161, 66);
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.Size = new System.Drawing.Size(391, 20);
            this.txtCiudad.TabIndex = 8;
            // 
            // txtCargoDelEmpleado
            // 
            this.txtCargoDelEmpleado.Location = new System.Drawing.Point(162, 43);
            this.txtCargoDelEmpleado.Name = "txtCargoDelEmpleado";
            this.txtCargoDelEmpleado.Size = new System.Drawing.Size(390, 20);
            this.txtCargoDelEmpleado.TabIndex = 7;
            // 
            // txtEstructuraOrganizacional
            // 
            this.txtEstructuraOrganizacional.Location = new System.Drawing.Point(162, 19);
            this.txtEstructuraOrganizacional.Name = "txtEstructuraOrganizacional";
            this.txtEstructuraOrganizacional.Size = new System.Drawing.Size(390, 20);
            this.txtEstructuraOrganizacional.TabIndex = 6;
            // 
            // chkEstado
            // 
            this.chkEstado.AutoSize = true;
            this.chkEstado.Location = new System.Drawing.Point(6, 140);
            this.chkEstado.Name = "chkEstado";
            this.chkEstado.Size = new System.Drawing.Size(62, 17);
            this.chkEstado.TabIndex = 5;
            this.chkEstado.Tag = "Estado";
            this.chkEstado.Text = "Estado:";
            this.chkEstado.UseVisualStyleBackColor = true;
            // 
            // chkTipoDeContrato
            // 
            this.chkTipoDeContrato.AutoSize = true;
            this.chkTipoDeContrato.Location = new System.Drawing.Point(6, 116);
            this.chkTipoDeContrato.Name = "chkTipoDeContrato";
            this.chkTipoDeContrato.Size = new System.Drawing.Size(108, 17);
            this.chkTipoDeContrato.TabIndex = 4;
            this.chkTipoDeContrato.Tag = "Tipo De Contrato";
            this.chkTipoDeContrato.Text = "Tipo de Contrato:";
            this.chkTipoDeContrato.UseVisualStyleBackColor = true;
            // 
            // chkDepartamento
            // 
            this.chkDepartamento.AutoSize = true;
            this.chkDepartamento.Location = new System.Drawing.Point(6, 92);
            this.chkDepartamento.Name = "chkDepartamento";
            this.chkDepartamento.Size = new System.Drawing.Size(96, 17);
            this.chkDepartamento.TabIndex = 3;
            this.chkDepartamento.Tag = "Departamento";
            this.chkDepartamento.Text = "Departamento:";
            this.chkDepartamento.UseVisualStyleBackColor = true;
            // 
            // chkMunicipio
            // 
            this.chkMunicipio.AutoSize = true;
            this.chkMunicipio.Location = new System.Drawing.Point(6, 68);
            this.chkMunicipio.Name = "chkMunicipio";
            this.chkMunicipio.Size = new System.Drawing.Size(74, 17);
            this.chkMunicipio.TabIndex = 2;
            this.chkMunicipio.Tag = "Municipio";
            this.chkMunicipio.Text = "Municipio:";
            this.chkMunicipio.UseVisualStyleBackColor = true;
            // 
            // chkCargo
            // 
            this.chkCargo.AutoSize = true;
            this.chkCargo.Location = new System.Drawing.Point(6, 44);
            this.chkCargo.Name = "chkCargo";
            this.chkCargo.Size = new System.Drawing.Size(126, 17);
            this.chkCargo.TabIndex = 1;
            this.chkCargo.Tag = "Cargo Del Empleado";
            this.chkCargo.Text = "Cargo Del Empleado:";
            this.chkCargo.UseVisualStyleBackColor = true;
            // 
            // chkAreaLaboral
            // 
            this.chkAreaLaboral.AutoSize = true;
            this.chkAreaLaboral.Location = new System.Drawing.Point(6, 21);
            this.chkAreaLaboral.Name = "chkAreaLaboral";
            this.chkAreaLaboral.Size = new System.Drawing.Size(89, 17);
            this.chkAreaLaboral.TabIndex = 0;
            this.chkAreaLaboral.Tag = "AreaLaboral";
            this.chkAreaLaboral.Text = "Area Laboral:";
            this.chkAreaLaboral.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNoRegistros});
            this.statusStrip1.Location = new System.Drawing.Point(0, 325);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1115, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsbNoRegistros
            // 
            this.tsbNoRegistros.Name = "tsbNoRegistros";
            this.tsbNoRegistros.Size = new System.Drawing.Size(105, 17);
            this.tsbNoRegistros.Tag = "No Registros";
            this.tsbNoRegistros.Text = "No. de Registros: 0";
            // 
            // dgvLista
            // 
            this.dgvLista.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLista.Location = new System.Drawing.Point(0, 39);
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.Size = new System.Drawing.Size(1115, 308);
            this.dgvLista.TabIndex = 1;
            // 
            // tsMenu
            // 
            this.tsMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsFiltrar,
            this.tsNuevoRegistro,
            this.tsImprimir,
            this.toolStripSeparator1,
            this.tsMarcarTodo,
            this.tsSeleccionar,
            this.tsFiltroAutomatico});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(1115, 39);
            this.tsMenu.TabIndex = 0;
            this.tsMenu.Text = "toolStrip1";
            // 
            // tsFiltrar
            // 
            this.tsFiltrar.Image = global::Planilla.Properties.Resources.SearchFile32;
            this.tsFiltrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsFiltrar.Name = "tsFiltrar";
            this.tsFiltrar.Size = new System.Drawing.Size(73, 36);
            this.tsFiltrar.Tag = "Filtrar";
            this.tsFiltrar.Text = "Filtrar";
            // 
            // tsNuevoRegistro
            // 
            this.tsNuevoRegistro.Image = global::Planilla.Properties.Resources.New32;
            this.tsNuevoRegistro.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsNuevoRegistro.Name = "tsNuevoRegistro";
            this.tsNuevoRegistro.Size = new System.Drawing.Size(124, 36);
            this.tsNuevoRegistro.Tag = "NUevo Rergistro";
            this.tsNuevoRegistro.Text = "Nuevo Registro";
            // 
            // tsImprimir
            // 
            this.tsImprimir.Image = global::Planilla.Properties.Resources.printer24x24;
            this.tsImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsImprimir.Name = "tsImprimir";
            this.tsImprimir.Size = new System.Drawing.Size(89, 36);
            this.tsImprimir.Tag = "Imprimir";
            this.tsImprimir.Text = "Imprimir";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // tsMarcarTodo
            // 
            this.tsMarcarTodo.Image = global::Planilla.Properties.Resources.checked24x24;
            this.tsMarcarTodo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsMarcarTodo.Name = "tsMarcarTodo";
            this.tsMarcarTodo.Size = new System.Drawing.Size(109, 36);
            this.tsMarcarTodo.Tag = "Marcar Todo";
            this.tsMarcarTodo.Text = "Marcar Todo";
            // 
            // tsSeleccionar
            // 
            this.tsSeleccionar.Image = global::Planilla.Properties.Resources.checked24x24;
            this.tsSeleccionar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSeleccionar.Name = "tsSeleccionar";
            this.tsSeleccionar.Size = new System.Drawing.Size(103, 36);
            this.tsSeleccionar.Tag = "Seleccionar";
            this.tsSeleccionar.Text = "Seleccionar";
            // 
            // tsFiltroAutomatico
            // 
            this.tsFiltroAutomatico.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsFiltroAutomatico.Image = global::Planilla.Properties.Resources.checked24x24;
            this.tsFiltroAutomatico.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsFiltroAutomatico.Name = "tsFiltroAutomatico";
            this.tsFiltroAutomatico.Size = new System.Drawing.Size(136, 36);
            this.tsFiltroAutomatico.Tag = "Filtro Automatico";
            this.tsFiltroAutomatico.Text = "Filtro Automatico";
            // 
            // frmEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 656);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmEmpleados";
            this.Text = "frmEmpleados";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton tsFiltrar;
        private System.Windows.Forms.ToolStripButton tsImprimir;
        private System.Windows.Forms.ToolStripButton tsNuevoRegistro;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsMarcarTodo;
        private System.Windows.Forms.ToolStripButton tsSeleccionar;
        private System.Windows.Forms.ToolStripButton tsFiltroAutomatico;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsbNoRegistros;
        private System.Windows.Forms.DataGridView dgvLista;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.TextBox txttipoDeDocumento;
        private System.Windows.Forms.TextBox txtDepartamento;
        private System.Windows.Forms.TextBox txtCiudad;
        private System.Windows.Forms.TextBox txtCargoDelEmpleado;
        private System.Windows.Forms.TextBox txtEstructuraOrganizacional;
        private System.Windows.Forms.CheckBox chkEstado;
        private System.Windows.Forms.CheckBox chkTipoDeContrato;
        private System.Windows.Forms.CheckBox chkDepartamento;
        private System.Windows.Forms.CheckBox chkMunicipio;
        private System.Windows.Forms.CheckBox chkCargo;
        private System.Windows.Forms.CheckBox chkAreaLaboral;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtCelular;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.CheckBox chkEmail;
        private System.Windows.Forms.CheckBox chkCelular;
        private System.Windows.Forms.CheckBox chkTelefono;
        private System.Windows.Forms.CheckBox chkCedula;
        private System.Windows.Forms.CheckBox chkNombre;
        private System.Windows.Forms.CheckBox chkApellidos;
    }
}