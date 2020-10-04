namespace Planilla.Formularios
{
    partial class frmUsuario
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
            this.gbInformacion = new System.Windows.Forms.GroupBox();
            this.txtNombreDeSecion = new System.Windows.Forms.TextBox();
            this.chkNombreDeSecion = new System.Windows.Forms.CheckBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.chkUsuario = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbTipoDeCuenta = new System.Windows.Forms.ComboBox();
            this.chkTipoDeCuenta = new System.Windows.Forms.CheckBox();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.chkEstado = new System.Windows.Forms.CheckBox();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsbFiltrar = new System.Windows.Forms.ToolStripButton();
            this.tsbNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsbImprimir = new System.Windows.Forms.ToolStripButton();
            this.tsbMarcarTodos = new System.Windows.Forms.ToolStripButton();
            this.tsbSeleccionarTodos = new System.Windows.Forms.ToolStripButton();
            this.tsbFiltroAutomatico = new System.Windows.Forms.ToolStripButton();
            this.dgvListar = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsbNoRegistros = new System.Windows.Forms.ToolStripStatusLabel();
            this.cmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmNuevo = new System.Windows.Forms.ToolStripMenuItem();
            this.cmActualizar = new System.Windows.Forms.ToolStripMenuItem();
            this.cmEliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.cmVisualizar = new System.Windows.Forms.ToolStripMenuItem();
            this.cmImprimir = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.gbInformacion.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tsMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListar)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.cmMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer1.Panel1.Controls.Add(this.tsMenu);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvListar);
            this.splitContainer1.Panel2.Controls.Add(this.statusStrip1);
            this.splitContainer1.Size = new System.Drawing.Size(1112, 409);
            this.splitContainer1.SplitterDistance = 159;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.gbInformacion);
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1112, 120);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // gbInformacion
            // 
            this.gbInformacion.Controls.Add(this.txtNombreDeSecion);
            this.gbInformacion.Controls.Add(this.chkNombreDeSecion);
            this.gbInformacion.Controls.Add(this.txtUsuario);
            this.gbInformacion.Controls.Add(this.chkUsuario);
            this.gbInformacion.Location = new System.Drawing.Point(4, 4);
            this.gbInformacion.Margin = new System.Windows.Forms.Padding(4);
            this.gbInformacion.Name = "gbInformacion";
            this.gbInformacion.Padding = new System.Windows.Forms.Padding(4);
            this.gbInformacion.Size = new System.Drawing.Size(560, 86);
            this.gbInformacion.TabIndex = 0;
            this.gbInformacion.TabStop = false;
            this.gbInformacion.Text = "Filtrar información del usuario";
            // 
            // txtNombreDeSecion
            // 
            this.txtNombreDeSecion.Location = new System.Drawing.Point(166, 50);
            this.txtNombreDeSecion.Name = "txtNombreDeSecion";
            this.txtNombreDeSecion.Size = new System.Drawing.Size(368, 22);
            this.txtNombreDeSecion.TabIndex = 3;
            this.txtNombreDeSecion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNombreDeSesion_KeyUp);
            // 
            // chkNombreDeSecion
            // 
            this.chkNombreDeSecion.AutoSize = true;
            this.chkNombreDeSecion.Location = new System.Drawing.Point(15, 51);
            this.chkNombreDeSecion.Name = "chkNombreDeSecion";
            this.chkNombreDeSecion.Size = new System.Drawing.Size(145, 20);
            this.chkNombreDeSecion.TabIndex = 2;
            this.chkNombreDeSecion.Text = "Nombre De Secion:";
            this.chkNombreDeSecion.UseVisualStyleBackColor = true;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(166, 22);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(368, 22);
            this.txtUsuario.TabIndex = 1;
            this.txtUsuario.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtUsuario_KeyUp);
            // 
            // chkUsuario
            // 
            this.chkUsuario.AutoSize = true;
            this.chkUsuario.Location = new System.Drawing.Point(15, 23);
            this.chkUsuario.Name = "chkUsuario";
            this.chkUsuario.Size = new System.Drawing.Size(77, 20);
            this.chkUsuario.TabIndex = 0;
            this.chkUsuario.Text = "Usuario:";
            this.chkUsuario.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbTipoDeCuenta);
            this.groupBox1.Controls.Add(this.chkTipoDeCuenta);
            this.groupBox1.Controls.Add(this.cmbEstado);
            this.groupBox1.Controls.Add(this.chkEstado);
            this.groupBox1.Location = new System.Drawing.Point(571, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(529, 87);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // cmbTipoDeCuenta
            // 
            this.cmbTipoDeCuenta.FormattingEnabled = true;
            this.cmbTipoDeCuenta.Items.AddRange(new object[] {
            "ACTIVO",
            "INACTIVO"});
            this.cmbTipoDeCuenta.Location = new System.Drawing.Point(145, 49);
            this.cmbTipoDeCuenta.Name = "cmbTipoDeCuenta";
            this.cmbTipoDeCuenta.Size = new System.Drawing.Size(359, 24);
            this.cmbTipoDeCuenta.TabIndex = 5;
            this.cmbTipoDeCuenta.SelectionChangeCommitted += new System.EventHandler(this.cmbGruposDeCuentas_SelectionChangeCommitted);
            // 
            // chkTipoDeCuenta
            // 
            this.chkTipoDeCuenta.AutoSize = true;
            this.chkTipoDeCuenta.Location = new System.Drawing.Point(26, 51);
            this.chkTipoDeCuenta.Name = "chkTipoDeCuenta";
            this.chkTipoDeCuenta.Size = new System.Drawing.Size(120, 20);
            this.chkTipoDeCuenta.TabIndex = 4;
            this.chkTipoDeCuenta.Text = "Tipo de cuenta:";
            this.chkTipoDeCuenta.UseVisualStyleBackColor = true;
            // 
            // cmbEstado
            // 
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Items.AddRange(new object[] {
            "ACTIVO",
            "INACTIVO"});
            this.cmbEstado.Location = new System.Drawing.Point(145, 21);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(359, 24);
            this.cmbEstado.TabIndex = 3;
            this.cmbEstado.SelectionChangeCommitted += new System.EventHandler(this.cmbEstado_SelectionChangeCommitted);
            // 
            // chkEstado
            // 
            this.chkEstado.AutoSize = true;
            this.chkEstado.Location = new System.Drawing.Point(26, 23);
            this.chkEstado.Name = "chkEstado";
            this.chkEstado.Size = new System.Drawing.Size(73, 20);
            this.chkEstado.TabIndex = 2;
            this.chkEstado.Text = "Estado:";
            this.chkEstado.UseVisualStyleBackColor = true;
            // 
            // tsMenu
            // 
            this.tsMenu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tsMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbFiltrar,
            this.tsbNuevo,
            this.tsbImprimir,
            this.tsbMarcarTodos,
            this.tsbSeleccionarTodos,
            this.tsbFiltroAutomatico});
            this.tsMenu.Location = new System.Drawing.Point(0, 120);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(1112, 39);
            this.tsMenu.TabIndex = 0;
            this.tsMenu.Text = "Filtrar";
            // 
            // tsbFiltrar
            // 
            this.tsbFiltrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFiltrar.Image = global::Planilla.Properties.Resources.SearchFile32;
            this.tsbFiltrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFiltrar.Name = "tsbFiltrar";
            this.tsbFiltrar.Size = new System.Drawing.Size(36, 36);
            this.tsbFiltrar.Text = "Filtrar";
            this.tsbFiltrar.ToolTipText = "Filtrar información (F5)";
            this.tsbFiltrar.Click += new System.EventHandler(this.tsbFiltrar_Click);
            // 
            // tsbNuevo
            // 
            this.tsbNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNuevo.Image = global::Planilla.Properties.Resources.New32;
            this.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNuevo.Name = "tsbNuevo";
            this.tsbNuevo.Size = new System.Drawing.Size(36, 36);
            this.tsbNuevo.Tag = "Nuevo";
            this.tsbNuevo.Text = "Nuevo";
            this.tsbNuevo.ToolTipText = "Agregar nuevo registro (F2)";
            this.tsbNuevo.Click += new System.EventHandler(this.tsbNuevo_Click);
            // 
            // tsbImprimir
            // 
            this.tsbImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbImprimir.Image = global::Planilla.Properties.Resources.iconfinder_preferences_desktop_printer_8803__1_;
            this.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbImprimir.Name = "tsbImprimir";
            this.tsbImprimir.Size = new System.Drawing.Size(36, 36);
            this.tsbImprimir.Tag = "Imprimir";
            this.tsbImprimir.Text = "Imprimir";
            this.tsbImprimir.ToolTipText = "Imprimir documentos";
            // 
            // tsbMarcarTodos
            // 
            this.tsbMarcarTodos.Image = global::Planilla.Properties.Resources.checked16x16;
            this.tsbMarcarTodos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbMarcarTodos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMarcarTodos.Name = "tsbMarcarTodos";
            this.tsbMarcarTodos.Size = new System.Drawing.Size(93, 36);
            this.tsbMarcarTodos.Text = "Marca todos";
            this.tsbMarcarTodos.Click += new System.EventHandler(this.tsbMarcarTodos_Click);
            // 
            // tsbSeleccionarTodos
            // 
            this.tsbSeleccionarTodos.Image = global::Planilla.Properties.Resources.checked16x16;
            this.tsbSeleccionarTodos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSeleccionarTodos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSeleccionarTodos.Name = "tsbSeleccionarTodos";
            this.tsbSeleccionarTodos.Size = new System.Drawing.Size(87, 36);
            this.tsbSeleccionarTodos.Text = "Seleccionar";
            this.tsbSeleccionarTodos.Click += new System.EventHandler(this.tsbSeleccionarTodos_Click);
            // 
            // tsbFiltroAutomatico
            // 
            this.tsbFiltroAutomatico.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbFiltroAutomatico.Image = global::Planilla.Properties.Resources.checked16x16;
            this.tsbFiltroAutomatico.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbFiltroAutomatico.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFiltroAutomatico.Name = "tsbFiltroAutomatico";
            this.tsbFiltroAutomatico.Size = new System.Drawing.Size(120, 36);
            this.tsbFiltroAutomatico.Text = "Filtro Automatico";
            this.tsbFiltroAutomatico.Click += new System.EventHandler(this.tsbFiltroAutomatico_Click);
            // 
            // dgvListar
            // 
            this.dgvListar.BackgroundColor = System.Drawing.Color.Azure;
            this.dgvListar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListar.Location = new System.Drawing.Point(0, 0);
            this.dgvListar.Margin = new System.Windows.Forms.Padding(4);
            this.dgvListar.Name = "dgvListar";
            this.dgvListar.Size = new System.Drawing.Size(1112, 219);
            this.dgvListar.TabIndex = 1;
            this.dgvListar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListar_CellContentClick);
            this.dgvListar.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.dgvListar_CellContextMenuStripNeeded);
            this.dgvListar.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvListar_CurrentCellDirtyStateChanged_1);
            this.dgvListar.DoubleClick += new System.EventHandler(this.dgvListar_DoubleClick_1);
            this.dgvListar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvListar_MouseDown);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNoRegistros});
            this.statusStrip1.Location = new System.Drawing.Point(0, 219);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1112, 26);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsbNoRegistros
            // 
            this.tsbNoRegistros.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbNoRegistros.Name = "tsbNoRegistros";
            this.tsbNoRegistros.Size = new System.Drawing.Size(136, 21);
            this.tsbNoRegistros.Text = "No. de registros: 0";
            // 
            // cmMenu
            // 
            this.cmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmNuevo,
            this.cmActualizar,
            this.cmEliminar,
            this.cmVisualizar,
            this.cmImprimir});
            this.cmMenu.Name = "cmMenu";
            this.cmMenu.Size = new System.Drawing.Size(127, 114);
            this.cmMenu.Opening += new System.ComponentModel.CancelEventHandler(this.cmMenu_Opened);
            // 
            // cmNuevo
            // 
            this.cmNuevo.Image = global::Planilla.Properties.Resources.New16x16;
            this.cmNuevo.Name = "cmNuevo";
            this.cmNuevo.Size = new System.Drawing.Size(126, 22);
            this.cmNuevo.Tag = "Nuevo";
            this.cmNuevo.Text = "Nuevo";
            this.cmNuevo.ToolTipText = "Nuevo registro";
            this.cmNuevo.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // cmActualizar
            // 
            this.cmActualizar.Image = global::Planilla.Properties.Resources.Edit16x16;
            this.cmActualizar.Name = "cmActualizar";
            this.cmActualizar.Size = new System.Drawing.Size(126, 22);
            this.cmActualizar.Tag = "Actualizar";
            this.cmActualizar.Text = "Actualizar";
            this.cmActualizar.ToolTipText = "Actualizar la información del registro seleccionado";
            this.cmActualizar.Click += new System.EventHandler(this.actualizarToolStripMenuItem_Click);
            // 
            // cmEliminar
            // 
            this.cmEliminar.Image = global::Planilla.Properties.Resources.Eliminar16x16;
            this.cmEliminar.Name = "cmEliminar";
            this.cmEliminar.Size = new System.Drawing.Size(126, 22);
            this.cmEliminar.Tag = "Eliminar";
            this.cmEliminar.Text = "Eliminar";
            this.cmEliminar.ToolTipText = "Eliminar registro seleccionado";
            this.cmEliminar.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // cmVisualizar
            // 
            this.cmVisualizar.Image = global::Planilla.Properties.Resources.if_old_edit_find_23490__1_;
            this.cmVisualizar.Name = "cmVisualizar";
            this.cmVisualizar.Size = new System.Drawing.Size(126, 22);
            this.cmVisualizar.Tag = "Visaulizar";
            this.cmVisualizar.Text = "Visualizar";
            this.cmVisualizar.ToolTipText = "Visualizar información del registro seleccionado";
            this.cmVisualizar.Click += new System.EventHandler(this.visualizarToolStripMenuItem_Click);
            // 
            // cmImprimir
            // 
            this.cmImprimir.Image = global::Planilla.Properties.Resources.iconfinder_preferences_desktop_printer_8803;
            this.cmImprimir.Name = "cmImprimir";
            this.cmImprimir.Size = new System.Drawing.Size(126, 22);
            this.cmImprimir.Tag = "Imprimir";
            this.cmImprimir.Text = "Imprimir";
            this.cmImprimir.ToolTipText = "Imprimir información del registro";
            // 
            // frmUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 409);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmUsuario";
            this.Text = "frmUsuario";
            this.Shown += new System.EventHandler(this.frmUsuario_Shown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmUsuario_KeyUp);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.gbInformacion.ResumeLayout(false);
            this.gbInformacion.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListar)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.cmMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton tsbFiltrar;
        private System.Windows.Forms.ToolStripButton tsbNuevo;
        private System.Windows.Forms.ToolStripButton tsbImprimir;
        private System.Windows.Forms.ToolStripButton tsbMarcarTodos;
        private System.Windows.Forms.ToolStripButton tsbSeleccionarTodos;
        private System.Windows.Forms.DataGridView dgvListar;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsbNoRegistros;
        private System.Windows.Forms.ContextMenuStrip cmMenu;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox gbInformacion;
        private System.Windows.Forms.TextBox txtNombreDeSecion;
        private System.Windows.Forms.CheckBox chkNombreDeSecion;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.CheckBox chkUsuario;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbTipoDeCuenta;
        private System.Windows.Forms.CheckBox chkTipoDeCuenta;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.CheckBox chkEstado;
        private System.Windows.Forms.ToolStripMenuItem cmNuevo;
        private System.Windows.Forms.ToolStripMenuItem cmActualizar;
        private System.Windows.Forms.ToolStripMenuItem cmEliminar;
        private System.Windows.Forms.ToolStripMenuItem cmVisualizar;
        private System.Windows.Forms.ToolStripMenuItem cmImprimir;
        private System.Windows.Forms.ToolStripButton tsbFiltroAutomatico;
    }
}