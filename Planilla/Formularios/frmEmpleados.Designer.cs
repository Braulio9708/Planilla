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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.txttipoDeDocumento = new System.Windows.Forms.TextBox();
            this.txtDepartamento = new System.Windows.Forms.TextBox();
            this.txtCiudad = new System.Windows.Forms.TextBox();
            this.txtCargoDelEmpleado = new System.Windows.Forms.TextBox();
            this.txtEstructuraOrganizacional = new System.Windows.Forms.TextBox();
            this.chkEstado = new System.Windows.Forms.CheckBox();
            this.chkTipoDeDocumento = new System.Windows.Forms.CheckBox();
            this.chkDepartamento = new System.Windows.Forms.CheckBox();
            this.chkCuidad = new System.Windows.Forms.CheckBox();
            this.chkCargoDelEmpleado = new System.Windows.Forms.CheckBox();
            this.chkEstrucutraOrganizacional = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtINSS = new System.Windows.Forms.TextBox();
            this.txtNoINSS = new System.Windows.Forms.TextBox();
            this.txtGradoAcademico = new System.Windows.Forms.TextBox();
            this.txtIdentificador = new System.Windows.Forms.TextBox();
            this.txtEmpleado = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.chkINSS = new System.Windows.Forms.CheckBox();
            this.chkNoINSS = new System.Windows.Forms.CheckBox();
            this.chkGradoAcademico = new System.Windows.Forms.CheckBox();
            this.chkIdentificador = new System.Windows.Forms.CheckBox();
            this.chkEmpleado = new System.Windows.Forms.CheckBox();
            this.chkCodigo = new System.Windows.Forms.CheckBox();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsFiltrar = new System.Windows.Forms.ToolStripButton();
            this.tsImprimir = new System.Windows.Forms.ToolStripButton();
            this.tsNuevoRegistro = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsMarcarTodo = new System.Windows.Forms.ToolStripButton();
            this.tsSeleccionar = new System.Windows.Forms.ToolStripButton();
            this.tsFiltroAutomatico = new System.Windows.Forms.ToolStripButton();
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsbNoRegistros = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tsMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            this.statusStrip1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.statusStrip1);
            this.splitContainer1.Panel2.Controls.Add(this.dgvLista);
            this.splitContainer1.Panel2.Controls.Add(this.tsMenu);
            this.splitContainer1.Size = new System.Drawing.Size(1115, 500);
            this.splitContainer1.SplitterDistance = 233;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1091, 286);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de Informacion de Empleados";
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
            this.groupBox3.Controls.Add(this.chkTipoDeDocumento);
            this.groupBox3.Controls.Add(this.chkDepartamento);
            this.groupBox3.Controls.Add(this.chkCuidad);
            this.groupBox3.Controls.Add(this.chkCargoDelEmpleado);
            this.groupBox3.Controls.Add(this.chkEstrucutraOrganizacional);
            this.groupBox3.Location = new System.Drawing.Point(548, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(537, 185);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(162, 138);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(367, 20);
            this.txtEstado.TabIndex = 11;
            // 
            // txttipoDeDocumento
            // 
            this.txttipoDeDocumento.Location = new System.Drawing.Point(162, 114);
            this.txttipoDeDocumento.Name = "txttipoDeDocumento";
            this.txttipoDeDocumento.Size = new System.Drawing.Size(367, 20);
            this.txttipoDeDocumento.TabIndex = 10;
            // 
            // txtDepartamento
            // 
            this.txtDepartamento.Location = new System.Drawing.Point(162, 90);
            this.txtDepartamento.Name = "txtDepartamento";
            this.txtDepartamento.Size = new System.Drawing.Size(367, 20);
            this.txtDepartamento.TabIndex = 9;
            // 
            // txtCiudad
            // 
            this.txtCiudad.Location = new System.Drawing.Point(161, 66);
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.Size = new System.Drawing.Size(368, 20);
            this.txtCiudad.TabIndex = 8;
            // 
            // txtCargoDelEmpleado
            // 
            this.txtCargoDelEmpleado.Location = new System.Drawing.Point(162, 43);
            this.txtCargoDelEmpleado.Name = "txtCargoDelEmpleado";
            this.txtCargoDelEmpleado.Size = new System.Drawing.Size(367, 20);
            this.txtCargoDelEmpleado.TabIndex = 7;
            // 
            // txtEstructuraOrganizacional
            // 
            this.txtEstructuraOrganizacional.Location = new System.Drawing.Point(162, 19);
            this.txtEstructuraOrganizacional.Name = "txtEstructuraOrganizacional";
            this.txtEstructuraOrganizacional.Size = new System.Drawing.Size(367, 20);
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
            // chkTipoDeDocumento
            // 
            this.chkTipoDeDocumento.AutoSize = true;
            this.chkTipoDeDocumento.Location = new System.Drawing.Point(6, 116);
            this.chkTipoDeDocumento.Name = "chkTipoDeDocumento";
            this.chkTipoDeDocumento.Size = new System.Drawing.Size(123, 17);
            this.chkTipoDeDocumento.TabIndex = 4;
            this.chkTipoDeDocumento.Tag = "Tipo De Documento";
            this.chkTipoDeDocumento.Text = "Tipo de Documento:";
            this.chkTipoDeDocumento.UseVisualStyleBackColor = true;
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
            // chkCuidad
            // 
            this.chkCuidad.AutoSize = true;
            this.chkCuidad.Location = new System.Drawing.Point(6, 68);
            this.chkCuidad.Name = "chkCuidad";
            this.chkCuidad.Size = new System.Drawing.Size(62, 17);
            this.chkCuidad.TabIndex = 2;
            this.chkCuidad.Tag = "Ciudad";
            this.chkCuidad.Text = "Ciudad:";
            this.chkCuidad.UseVisualStyleBackColor = true;
            // 
            // chkCargoDelEmpleado
            // 
            this.chkCargoDelEmpleado.AutoSize = true;
            this.chkCargoDelEmpleado.Location = new System.Drawing.Point(6, 44);
            this.chkCargoDelEmpleado.Name = "chkCargoDelEmpleado";
            this.chkCargoDelEmpleado.Size = new System.Drawing.Size(126, 17);
            this.chkCargoDelEmpleado.TabIndex = 1;
            this.chkCargoDelEmpleado.Tag = "Cargo Del Empleado";
            this.chkCargoDelEmpleado.Text = "Cargo Del Empleado:";
            this.chkCargoDelEmpleado.UseVisualStyleBackColor = true;
            // 
            // chkEstrucutraOrganizacional
            // 
            this.chkEstrucutraOrganizacional.AutoSize = true;
            this.chkEstrucutraOrganizacional.Location = new System.Drawing.Point(6, 21);
            this.chkEstrucutraOrganizacional.Name = "chkEstrucutraOrganizacional";
            this.chkEstrucutraOrganizacional.Size = new System.Drawing.Size(150, 17);
            this.chkEstrucutraOrganizacional.TabIndex = 0;
            this.chkEstrucutraOrganizacional.Tag = "Estructura Organizacional";
            this.chkEstrucutraOrganizacional.Text = "Estructura Organizacional:";
            this.chkEstrucutraOrganizacional.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtINSS);
            this.groupBox2.Controls.Add(this.txtNoINSS);
            this.groupBox2.Controls.Add(this.txtGradoAcademico);
            this.groupBox2.Controls.Add(this.txtIdentificador);
            this.groupBox2.Controls.Add(this.txtEmpleado);
            this.groupBox2.Controls.Add(this.txtCodigo);
            this.groupBox2.Controls.Add(this.chkINSS);
            this.groupBox2.Controls.Add(this.chkNoINSS);
            this.groupBox2.Controls.Add(this.chkGradoAcademico);
            this.groupBox2.Controls.Add(this.chkIdentificador);
            this.groupBox2.Controls.Add(this.chkEmpleado);
            this.groupBox2.Controls.Add(this.chkCodigo);
            this.groupBox2.Location = new System.Drawing.Point(6, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(536, 185);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // txtINSS
            // 
            this.txtINSS.Location = new System.Drawing.Point(134, 139);
            this.txtINSS.Name = "txtINSS";
            this.txtINSS.Size = new System.Drawing.Size(396, 20);
            this.txtINSS.TabIndex = 11;
            // 
            // txtNoINSS
            // 
            this.txtNoINSS.Location = new System.Drawing.Point(134, 115);
            this.txtNoINSS.Name = "txtNoINSS";
            this.txtNoINSS.Size = new System.Drawing.Size(396, 20);
            this.txtNoINSS.TabIndex = 10;
            // 
            // txtGradoAcademico
            // 
            this.txtGradoAcademico.Location = new System.Drawing.Point(134, 91);
            this.txtGradoAcademico.Name = "txtGradoAcademico";
            this.txtGradoAcademico.Size = new System.Drawing.Size(396, 20);
            this.txtGradoAcademico.TabIndex = 9;
            // 
            // txtIdentificador
            // 
            this.txtIdentificador.Location = new System.Drawing.Point(134, 67);
            this.txtIdentificador.Name = "txtIdentificador";
            this.txtIdentificador.Size = new System.Drawing.Size(396, 20);
            this.txtIdentificador.TabIndex = 8;
            // 
            // txtEmpleado
            // 
            this.txtEmpleado.Location = new System.Drawing.Point(134, 43);
            this.txtEmpleado.Name = "txtEmpleado";
            this.txtEmpleado.Size = new System.Drawing.Size(396, 20);
            this.txtEmpleado.TabIndex = 7;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(134, 19);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(396, 20);
            this.txtCodigo.TabIndex = 6;
            // 
            // chkINSS
            // 
            this.chkINSS.AutoSize = true;
            this.chkINSS.Location = new System.Drawing.Point(7, 141);
            this.chkINSS.Name = "chkINSS";
            this.chkINSS.Size = new System.Drawing.Size(51, 17);
            this.chkINSS.TabIndex = 5;
            this.chkINSS.Tag = "INSS";
            this.chkINSS.Text = "INSS";
            this.chkINSS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkINSS.UseVisualStyleBackColor = true;
            // 
            // chkNoINSS
            // 
            this.chkNoINSS.AutoSize = true;
            this.chkNoINSS.Location = new System.Drawing.Point(7, 117);
            this.chkNoINSS.Name = "chkNoINSS";
            this.chkNoINSS.Size = new System.Drawing.Size(74, 17);
            this.chkNoINSS.TabIndex = 4;
            this.chkNoINSS.Tag = "No. INSS";
            this.chkNoINSS.Text = "No. INSS:";
            this.chkNoINSS.UseVisualStyleBackColor = true;
            // 
            // chkGradoAcademico
            // 
            this.chkGradoAcademico.AutoSize = true;
            this.chkGradoAcademico.Location = new System.Drawing.Point(7, 93);
            this.chkGradoAcademico.Name = "chkGradoAcademico";
            this.chkGradoAcademico.Size = new System.Drawing.Size(114, 17);
            this.chkGradoAcademico.TabIndex = 3;
            this.chkGradoAcademico.Tag = "Grado Academinco";
            this.chkGradoAcademico.Text = "Grado Academico:";
            this.chkGradoAcademico.UseVisualStyleBackColor = true;
            // 
            // chkIdentificador
            // 
            this.chkIdentificador.AutoSize = true;
            this.chkIdentificador.Location = new System.Drawing.Point(7, 69);
            this.chkIdentificador.Name = "chkIdentificador";
            this.chkIdentificador.Size = new System.Drawing.Size(107, 17);
            this.chkIdentificador.TabIndex = 2;
            this.chkIdentificador.Tag = "Identificador";
            this.chkIdentificador.Text = "No. Identificador:";
            this.chkIdentificador.UseVisualStyleBackColor = true;
            // 
            // chkEmpleado
            // 
            this.chkEmpleado.AutoSize = true;
            this.chkEmpleado.Location = new System.Drawing.Point(7, 45);
            this.chkEmpleado.Name = "chkEmpleado";
            this.chkEmpleado.Size = new System.Drawing.Size(76, 17);
            this.chkEmpleado.TabIndex = 1;
            this.chkEmpleado.Tag = "Empleado";
            this.chkEmpleado.Text = "Empleado:";
            this.chkEmpleado.UseVisualStyleBackColor = true;
            // 
            // chkCodigo
            // 
            this.chkCodigo.AutoSize = true;
            this.chkCodigo.Location = new System.Drawing.Point(7, 21);
            this.chkCodigo.Name = "chkCodigo";
            this.chkCodigo.Size = new System.Drawing.Size(62, 17);
            this.chkCodigo.TabIndex = 0;
            this.chkCodigo.Tag = "Codigo";
            this.chkCodigo.Text = "Codigo:";
            this.chkCodigo.UseVisualStyleBackColor = true;
            // 
            // tsMenu
            // 
            this.tsMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsFiltrar,
            this.tsImprimir,
            this.tsNuevoRegistro,
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
            this.tsFiltrar.Image = global::Planilla.Properties.Resources.filtrar24x24;
            this.tsFiltrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsFiltrar.Name = "tsFiltrar";
            this.tsFiltrar.Size = new System.Drawing.Size(73, 36);
            this.tsFiltrar.Tag = "Filtrar";
            this.tsFiltrar.Text = "Filtrar";
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
            // tsNuevoRegistro
            // 
            this.tsNuevoRegistro.Image = global::Planilla.Properties.Resources.New32;
            this.tsNuevoRegistro.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsNuevoRegistro.Name = "tsNuevoRegistro";
            this.tsNuevoRegistro.Size = new System.Drawing.Size(124, 36);
            this.tsNuevoRegistro.Tag = "NUevo Rergistro";
            this.tsNuevoRegistro.Text = "Nuevo Registro";
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
            // dgvLista
            // 
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLista.Location = new System.Drawing.Point(0, 39);
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.Size = new System.Drawing.Size(1115, 224);
            this.dgvLista.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNoRegistros});
            this.statusStrip1.Location = new System.Drawing.Point(0, 241);
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
            // frmEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 500);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmEmpleados";
            this.Text = "frmEmpleados";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtEmpleado;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.CheckBox chkINSS;
        private System.Windows.Forms.CheckBox chkNoINSS;
        private System.Windows.Forms.CheckBox chkGradoAcademico;
        private System.Windows.Forms.CheckBox chkIdentificador;
        private System.Windows.Forms.CheckBox chkEmpleado;
        private System.Windows.Forms.CheckBox chkCodigo;
        private System.Windows.Forms.TextBox txtINSS;
        private System.Windows.Forms.TextBox txtNoINSS;
        private System.Windows.Forms.TextBox txtGradoAcademico;
        private System.Windows.Forms.TextBox txtIdentificador;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.TextBox txttipoDeDocumento;
        private System.Windows.Forms.TextBox txtDepartamento;
        private System.Windows.Forms.TextBox txtCiudad;
        private System.Windows.Forms.TextBox txtCargoDelEmpleado;
        private System.Windows.Forms.TextBox txtEstructuraOrganizacional;
        private System.Windows.Forms.CheckBox chkEstado;
        private System.Windows.Forms.CheckBox chkTipoDeDocumento;
        private System.Windows.Forms.CheckBox chkDepartamento;
        private System.Windows.Forms.CheckBox chkCuidad;
        private System.Windows.Forms.CheckBox chkCargoDelEmpleado;
        private System.Windows.Forms.CheckBox chkEstrucutraOrganizacional;
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
    }
}