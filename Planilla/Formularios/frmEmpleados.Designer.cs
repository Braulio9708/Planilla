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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.chkEmail = new System.Windows.Forms.CheckBox();
            this.chkCedula = new System.Windows.Forms.CheckBox();
            this.chkNombre = new System.Windows.Forms.CheckBox();
            this.chkApellidos = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.chkNoInss = new System.Windows.Forms.CheckBox();
            this.chkMunicipio = new System.Windows.Forms.CheckBox();
            this.chkCargo = new System.Windows.Forms.CheckBox();
            this.chkAreaLaboral = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.NoRegistros = new System.Windows.Forms.ToolStripStatusLabel();
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsbFiltrar = new System.Windows.Forms.ToolStripButton();
            this.tsbNuevoRegistro = new System.Windows.Forms.ToolStripButton();
            this.tsbImprimir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbMarcarTodo = new System.Windows.Forms.ToolStripButton();
            this.tsbSeleccionar = new System.Windows.Forms.ToolStripButton();
            this.tsbFiltroAutomatico = new System.Windows.Forms.ToolStripButton();
            this.mcsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actualizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imprimirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
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
            this.mcsMenu.SuspendLayout();
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
            this.splitContainer1.SplitterDistance = 208;
            this.splitContainer1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.groupBox2);
            this.flowLayoutPanel1.Controls.Add(this.groupBox3);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1115, 208);
            this.flowLayoutPanel1.TabIndex = 12;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtEmail);
            this.groupBox2.Controls.Add(this.txtCedula);
            this.groupBox2.Controls.Add(this.txtApellidos);
            this.groupBox2.Controls.Add(this.txtNombre);
            this.groupBox2.Controls.Add(this.chkEmail);
            this.groupBox2.Controls.Add(this.chkCedula);
            this.groupBox2.Controls.Add(this.chkNombre);
            this.groupBox2.Controls.Add(this.chkApellidos);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(536, 179);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(156, 124);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(374, 21);
            this.txtEmail.TabIndex = 11;
            // 
            // txtCedula
            // 
            this.txtCedula.Location = new System.Drawing.Point(156, 88);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(374, 21);
            this.txtCedula.TabIndex = 8;
            // 
            // txtApellidos
            // 
            this.txtApellidos.Location = new System.Drawing.Point(155, 53);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(374, 21);
            this.txtApellidos.TabIndex = 7;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(156, 19);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(374, 21);
            this.txtNombre.TabIndex = 6;
            // 
            // chkEmail
            // 
            this.chkEmail.AutoSize = true;
            this.chkEmail.Location = new System.Drawing.Point(16, 126);
            this.chkEmail.Name = "chkEmail";
            this.chkEmail.Size = new System.Drawing.Size(134, 19);
            this.chkEmail.TabIndex = 5;
            this.chkEmail.Tag = "Email";
            this.chkEmail.Text = "Corrreo Electronico:";
            this.chkEmail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkEmail.UseVisualStyleBackColor = true;
            // 
            // chkCedula
            // 
            this.chkCedula.AutoSize = true;
            this.chkCedula.Location = new System.Drawing.Point(15, 90);
            this.chkCedula.Name = "chkCedula";
            this.chkCedula.Size = new System.Drawing.Size(68, 19);
            this.chkCedula.TabIndex = 2;
            this.chkCedula.Tag = "Cedula";
            this.chkCedula.Text = "Cedula:";
            this.chkCedula.UseVisualStyleBackColor = true;
            // 
            // chkNombre
            // 
            this.chkNombre.AutoSize = true;
            this.chkNombre.Location = new System.Drawing.Point(15, 21);
            this.chkNombre.Name = "chkNombre";
            this.chkNombre.Size = new System.Drawing.Size(74, 19);
            this.chkNombre.TabIndex = 1;
            this.chkNombre.Tag = "Nombre";
            this.chkNombre.Text = "Nombre:";
            this.chkNombre.UseVisualStyleBackColor = true;
            // 
            // chkApellidos
            // 
            this.chkApellidos.AutoSize = true;
            this.chkApellidos.Location = new System.Drawing.Point(15, 55);
            this.chkApellidos.Name = "chkApellidos";
            this.chkApellidos.Size = new System.Drawing.Size(79, 19);
            this.chkApellidos.TabIndex = 0;
            this.chkApellidos.Tag = "Apellidos";
            this.chkApellidos.Text = "Apellidos:";
            this.chkApellidos.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBox3);
            this.groupBox3.Controls.Add(this.comboBox2);
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Controls.Add(this.txtEstado);
            this.groupBox3.Controls.Add(this.chkNoInss);
            this.groupBox3.Controls.Add(this.chkMunicipio);
            this.groupBox3.Controls.Add(this.chkCargo);
            this.groupBox3.Controls.Add(this.chkAreaLaboral);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(545, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(558, 179);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(161, 124);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(390, 21);
            this.txtEstado.TabIndex = 11;
            // 
            // chkNoInss
            // 
            this.chkNoInss.AutoSize = true;
            this.chkNoInss.Location = new System.Drawing.Point(18, 126);
            this.chkNoInss.Name = "chkNoInss";
            this.chkNoInss.Size = new System.Drawing.Size(70, 19);
            this.chkNoInss.TabIndex = 5;
            this.chkNoInss.Tag = "NoInss";
            this.chkNoInss.Text = "No Inss:";
            this.chkNoInss.UseVisualStyleBackColor = true;
            // 
            // chkMunicipio
            // 
            this.chkMunicipio.AutoSize = true;
            this.chkMunicipio.Location = new System.Drawing.Point(18, 90);
            this.chkMunicipio.Name = "chkMunicipio";
            this.chkMunicipio.Size = new System.Drawing.Size(83, 19);
            this.chkMunicipio.TabIndex = 2;
            this.chkMunicipio.Tag = "Municipio";
            this.chkMunicipio.Text = "Municipio:";
            this.chkMunicipio.UseVisualStyleBackColor = true;
            // 
            // chkCargo
            // 
            this.chkCargo.AutoSize = true;
            this.chkCargo.Location = new System.Drawing.Point(18, 55);
            this.chkCargo.Name = "chkCargo";
            this.chkCargo.Size = new System.Drawing.Size(144, 19);
            this.chkCargo.TabIndex = 1;
            this.chkCargo.Tag = "Cargo Del Empleado";
            this.chkCargo.Text = "Cargo Del Empleado:";
            this.chkCargo.UseVisualStyleBackColor = true;
            // 
            // chkAreaLaboral
            // 
            this.chkAreaLaboral.AutoSize = true;
            this.chkAreaLaboral.Location = new System.Drawing.Point(18, 21);
            this.chkAreaLaboral.Name = "chkAreaLaboral";
            this.chkAreaLaboral.Size = new System.Drawing.Size(99, 19);
            this.chkAreaLaboral.TabIndex = 0;
            this.chkAreaLaboral.Tag = "AreaLaboral";
            this.chkAreaLaboral.Text = "Area Laboral:";
            this.chkAreaLaboral.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NoRegistros});
            this.statusStrip1.Location = new System.Drawing.Point(0, 422);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1115, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // NoRegistros
            // 
            this.NoRegistros.Name = "NoRegistros";
            this.NoRegistros.Size = new System.Drawing.Size(105, 17);
            this.NoRegistros.Tag = "No Registros";
            this.NoRegistros.Text = "No. de Registros: 0";
            // 
            // dgvLista
            // 
            this.dgvLista.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLista.Location = new System.Drawing.Point(0, 39);
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.Size = new System.Drawing.Size(1115, 405);
            this.dgvLista.TabIndex = 1;
            // 
            // tsMenu
            // 
            this.tsMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbFiltrar,
            this.tsbNuevoRegistro,
            this.tsbImprimir,
            this.toolStripSeparator1,
            this.tsbMarcarTodo,
            this.tsbSeleccionar,
            this.tsbFiltroAutomatico});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(1115, 39);
            this.tsMenu.TabIndex = 0;
            this.tsMenu.Text = "toolStrip1";
            // 
            // tsbFiltrar
            // 
            this.tsbFiltrar.Image = global::Planilla.Properties.Resources.SearchFile32;
            this.tsbFiltrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFiltrar.Name = "tsbFiltrar";
            this.tsbFiltrar.Size = new System.Drawing.Size(73, 36);
            this.tsbFiltrar.Tag = "Filtrar";
            this.tsbFiltrar.Text = "Filtrar";
            // 
            // tsbNuevoRegistro
            // 
            this.tsbNuevoRegistro.Image = global::Planilla.Properties.Resources.New32;
            this.tsbNuevoRegistro.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNuevoRegistro.Name = "tsbNuevoRegistro";
            this.tsbNuevoRegistro.Size = new System.Drawing.Size(124, 36);
            this.tsbNuevoRegistro.Tag = "NUevo Rergistro";
            this.tsbNuevoRegistro.Text = "Nuevo Registro";
            // 
            // tsbImprimir
            // 
            this.tsbImprimir.Image = global::Planilla.Properties.Resources.printer24x24;
            this.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbImprimir.Name = "tsbImprimir";
            this.tsbImprimir.Size = new System.Drawing.Size(89, 36);
            this.tsbImprimir.Tag = "Imprimir";
            this.tsbImprimir.Text = "Imprimir";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbMarcarTodo
            // 
            this.tsbMarcarTodo.Image = global::Planilla.Properties.Resources.checked24x24;
            this.tsbMarcarTodo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMarcarTodo.Name = "tsbMarcarTodo";
            this.tsbMarcarTodo.Size = new System.Drawing.Size(109, 36);
            this.tsbMarcarTodo.Tag = "Marcar Todo";
            this.tsbMarcarTodo.Text = "Marcar Todo";
            // 
            // tsbSeleccionar
            // 
            this.tsbSeleccionar.Image = global::Planilla.Properties.Resources.checked24x24;
            this.tsbSeleccionar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSeleccionar.Name = "tsbSeleccionar";
            this.tsbSeleccionar.Size = new System.Drawing.Size(103, 36);
            this.tsbSeleccionar.Tag = "Seleccionar";
            this.tsbSeleccionar.Text = "Seleccionar";
            // 
            // tsbFiltroAutomatico
            // 
            this.tsbFiltroAutomatico.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbFiltroAutomatico.Image = global::Planilla.Properties.Resources.checked24x24;
            this.tsbFiltroAutomatico.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFiltroAutomatico.Name = "tsbFiltroAutomatico";
            this.tsbFiltroAutomatico.Size = new System.Drawing.Size(136, 36);
            this.tsbFiltroAutomatico.Tag = "Filtro Automatico";
            this.tsbFiltroAutomatico.Text = "Filtro Automatico";
            this.tsbFiltroAutomatico.Click += new System.EventHandler(this.tsbFiltroAutomatico_Click);
            // 
            // mcsMenu
            // 
            this.mcsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.actualizarToolStripMenuItem,
            this.eliminarToolStripMenuItem,
            this.visualizarToolStripMenuItem,
            this.imprimirToolStripMenuItem});
            this.mcsMenu.Name = "mcsMenu";
            this.mcsMenu.Size = new System.Drawing.Size(127, 114);
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Image = global::Planilla.Properties.Resources.New16x16;
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            // 
            // actualizarToolStripMenuItem
            // 
            this.actualizarToolStripMenuItem.Image = global::Planilla.Properties.Resources.Edit16x16;
            this.actualizarToolStripMenuItem.Name = "actualizarToolStripMenuItem";
            this.actualizarToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.actualizarToolStripMenuItem.Text = "Actualizar";
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Image = global::Planilla.Properties.Resources.Eliminar16x16;
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            // 
            // visualizarToolStripMenuItem
            // 
            this.visualizarToolStripMenuItem.Image = global::Planilla.Properties.Resources.if_old_edit_find_23490__1_;
            this.visualizarToolStripMenuItem.Name = "visualizarToolStripMenuItem";
            this.visualizarToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.visualizarToolStripMenuItem.Text = "Visualizar";
            // 
            // imprimirToolStripMenuItem
            // 
            this.imprimirToolStripMenuItem.Image = global::Planilla.Properties.Resources.printer16x16;
            this.imprimirToolStripMenuItem.Name = "imprimirToolStripMenuItem";
            this.imprimirToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.imprimirToolStripMenuItem.Text = "Imprimir";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(162, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(390, 23);
            this.comboBox1.TabIndex = 12;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(161, 53);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(390, 23);
            this.comboBox2.TabIndex = 13;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(161, 88);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(390, 23);
            this.comboBox3.TabIndex = 14;
            // 
            // frmEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 656);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmEmpleados";
            this.Text = "frmEmpleados";
            this.Shown += new System.EventHandler(this.frmEmpleados_Shown);
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
            this.mcsMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton tsbFiltrar;
        private System.Windows.Forms.ToolStripButton tsbImprimir;
        private System.Windows.Forms.ToolStripButton tsbNuevoRegistro;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbMarcarTodo;
        private System.Windows.Forms.ToolStripButton tsbSeleccionar;
        private System.Windows.Forms.ToolStripButton tsbFiltroAutomatico;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel NoRegistros;
        private System.Windows.Forms.DataGridView dgvLista;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.CheckBox chkNoInss;
        private System.Windows.Forms.CheckBox chkMunicipio;
        private System.Windows.Forms.CheckBox chkCargo;
        private System.Windows.Forms.CheckBox chkAreaLaboral;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.CheckBox chkEmail;
        private System.Windows.Forms.CheckBox chkCedula;
        private System.Windows.Forms.CheckBox chkNombre;
        private System.Windows.Forms.CheckBox chkApellidos;
        private System.Windows.Forms.ContextMenuStrip mcsMenu;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actualizarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visualizarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imprimirToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}