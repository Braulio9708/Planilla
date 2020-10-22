namespace Planilla.Formularios
{
    partial class frmCiudad
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsbFiltrar = new System.Windows.Forms.ToolStripButton();
            this.tsbNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsbImprimir = new System.Windows.Forms.ToolStripButton();
            this.tsbMarcarTodos = new System.Windows.Forms.ToolStripButton();
            this.tsbSeleccionarTodos = new System.Windows.Forms.ToolStripButton();
            this.tsbFiltroAutomatico = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMunicipio = new System.Windows.Forms.TextBox();
            this.txtIdentificador = new System.Windows.Forms.TextBox();
            this.chkMunicipio = new System.Windows.Forms.CheckBox();
            this.chkIdentificador = new System.Windows.Forms.CheckBox();
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsbNoRegistros = new System.Windows.Forms.ToolStripStatusLabel();
            this.mcsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmNuevo = new System.Windows.Forms.ToolStripMenuItem();
            this.cmActualizar = new System.Windows.Forms.ToolStripMenuItem();
            this.cmEliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.cmVisualizar = new System.Windows.Forms.ToolStripMenuItem();
            this.cmImprimir = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tsMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            this.statusStrip1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.tsMenu);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvLista);
            this.splitContainer1.Panel2.Controls.Add(this.statusStrip1);
            this.splitContainer1.Size = new System.Drawing.Size(613, 378);
            this.splitContainer1.SplitterDistance = 168;
            this.splitContainer1.TabIndex = 0;
            // 
            // tsMenu
            // 
            this.tsMenu.AutoSize = false;
            this.tsMenu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tsMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbFiltrar,
            this.tsbNuevo,
            this.tsbImprimir,
            this.tsbMarcarTodos,
            this.tsbSeleccionarTodos,
            this.tsbFiltroAutomatico});
            this.tsMenu.Location = new System.Drawing.Point(0, 129);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(613, 39);
            this.tsMenu.TabIndex = 2;
            this.tsMenu.Text = "toolStrip1";
            // 
            // tsbFiltrar
            // 
            this.tsbFiltrar.Image = global::Planilla.Properties.Resources.SearchFile32;
            this.tsbFiltrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFiltrar.Name = "tsbFiltrar";
            this.tsbFiltrar.Size = new System.Drawing.Size(73, 36);
            this.tsbFiltrar.Text = "Filtrar";
            this.tsbFiltrar.ToolTipText = "Filtrar (F5)";
            this.tsbFiltrar.Click += new System.EventHandler(this.tsbFiltrar_Click);
            // 
            // tsbNuevo
            // 
            this.tsbNuevo.Image = global::Planilla.Properties.Resources.new24x24;
            this.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNuevo.Name = "tsbNuevo";
            this.tsbNuevo.Size = new System.Drawing.Size(78, 36);
            this.tsbNuevo.Text = "Nuevo";
            this.tsbNuevo.ToolTipText = "Nuevo (F2)";
            this.tsbNuevo.Click += new System.EventHandler(this.tsbNuevo_Click);
            // 
            // tsbImprimir
            // 
            this.tsbImprimir.Image = global::Planilla.Properties.Resources.iconfinder_preferences_desktop_printer_8803__1_;
            this.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbImprimir.Name = "tsbImprimir";
            this.tsbImprimir.Size = new System.Drawing.Size(89, 36);
            this.tsbImprimir.Text = "Imprimir";
            this.tsbImprimir.ToolTipText = "Imprimir (F4)";
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
            this.tsbSeleccionarTodos.Size = new System.Drawing.Size(116, 36);
            this.tsbSeleccionarTodos.Text = "Seleccionar Todo";
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMunicipio);
            this.groupBox1.Controls.Add(this.txtIdentificador);
            this.groupBox1.Controls.Add(this.chkMunicipio);
            this.groupBox1.Controls.Add(this.chkIdentificador);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(589, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informacion de Ciudades";
            // 
            // txtMunicipio
            // 
            this.txtMunicipio.Location = new System.Drawing.Point(233, 71);
            this.txtMunicipio.Name = "txtMunicipio";
            this.txtMunicipio.Size = new System.Drawing.Size(323, 20);
            this.txtMunicipio.TabIndex = 3;
            this.txtMunicipio.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtMunicipio_KeyUp);
            // 
            // txtIdentificador
            // 
            this.txtIdentificador.Location = new System.Drawing.Point(233, 29);
            this.txtIdentificador.Name = "txtIdentificador";
            this.txtIdentificador.Size = new System.Drawing.Size(323, 20);
            this.txtIdentificador.TabIndex = 2;
            this.txtIdentificador.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtIdentificador_KeyUp);
            // 
            // chkMunicipio
            // 
            this.chkMunicipio.AutoSize = true;
            this.chkMunicipio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMunicipio.Location = new System.Drawing.Point(21, 71);
            this.chkMunicipio.Name = "chkMunicipio";
            this.chkMunicipio.Size = new System.Drawing.Size(73, 20);
            this.chkMunicipio.TabIndex = 1;
            this.chkMunicipio.Text = "Ciudad:";
            this.chkMunicipio.UseVisualStyleBackColor = true;
            // 
            // chkIdentificador
            // 
            this.chkIdentificador.AutoSize = true;
            this.chkIdentificador.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIdentificador.Location = new System.Drawing.Point(21, 29);
            this.chkIdentificador.Name = "chkIdentificador";
            this.chkIdentificador.Size = new System.Drawing.Size(103, 20);
            this.chkIdentificador.TabIndex = 0;
            this.chkIdentificador.Text = "Identificador:";
            this.chkIdentificador.UseVisualStyleBackColor = true;
            // 
            // dgvLista
            // 
            this.dgvLista.BackgroundColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLista.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLista.Location = new System.Drawing.Point(0, 0);
            this.dgvLista.Name = "dgvLista";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLista.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvLista.Size = new System.Drawing.Size(613, 180);
            this.dgvLista.TabIndex = 4;
            this.dgvLista.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLista_CellContentClick);
            this.dgvLista.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.dgvLista_CellContextMenuStripNeeded);
            this.dgvLista.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvLista_CurrentCellDirtyStateChanged);
            this.dgvLista.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvLista_MouseDown);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNoRegistros});
            this.statusStrip1.Location = new System.Drawing.Point(0, 180);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(613, 26);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsbNoRegistros
            // 
            this.tsbNoRegistros.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbNoRegistros.Name = "tsbNoRegistros";
            this.tsbNoRegistros.Size = new System.Drawing.Size(136, 21);
            this.tsbNoRegistros.Text = "No. de registros: 0";
            // 
            // mcsMenu
            // 
            this.mcsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmNuevo,
            this.cmActualizar,
            this.cmEliminar,
            this.cmVisualizar,
            this.cmImprimir});
            this.mcsMenu.Name = "mcsMenu";
            this.mcsMenu.Size = new System.Drawing.Size(127, 114);
            this.mcsMenu.Opened += new System.EventHandler(this.mcsMenu_Opened);
            // 
            // cmNuevo
            // 
            this.cmNuevo.Image = global::Planilla.Properties.Resources.New16x16;
            this.cmNuevo.Name = "cmNuevo";
            this.cmNuevo.Size = new System.Drawing.Size(126, 22);
            this.cmNuevo.Text = "Nuevo";
            this.cmNuevo.Click += new System.EventHandler(this.cmNuevo_Click);
            // 
            // cmActualizar
            // 
            this.cmActualizar.Image = global::Planilla.Properties.Resources.Edit16x16;
            this.cmActualizar.Name = "cmActualizar";
            this.cmActualizar.Size = new System.Drawing.Size(126, 22);
            this.cmActualizar.Text = "Actualizar";
            this.cmActualizar.Click += new System.EventHandler(this.cmActualizar_Click);
            // 
            // cmEliminar
            // 
            this.cmEliminar.Image = global::Planilla.Properties.Resources.Eliminar16x16;
            this.cmEliminar.Name = "cmEliminar";
            this.cmEliminar.Size = new System.Drawing.Size(126, 22);
            this.cmEliminar.Text = "Eliminar";
            this.cmEliminar.Click += new System.EventHandler(this.cmEliminar_Click);
            // 
            // cmVisualizar
            // 
            this.cmVisualizar.Image = global::Planilla.Properties.Resources.if_old_edit_find_23490__1_;
            this.cmVisualizar.Name = "cmVisualizar";
            this.cmVisualizar.Size = new System.Drawing.Size(126, 22);
            this.cmVisualizar.Text = "Visualizar";
            this.cmVisualizar.Click += new System.EventHandler(this.cmVisualizar_Click);
            // 
            // cmImprimir
            // 
            this.cmImprimir.Image = global::Planilla.Properties.Resources.iconfinder_preferences_desktop_printer_8803;
            this.cmImprimir.Name = "cmImprimir";
            this.cmImprimir.Size = new System.Drawing.Size(126, 22);
            this.cmImprimir.Text = "Imprimir";
            // 
            // frmCiudad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 378);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmCiudad";
            this.Text = "frmMunicipio";
            this.Shown += new System.EventHandler(this.frmMunicipio_Shown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmMunicipio_KeyUp);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.mcsMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMunicipio;
        private System.Windows.Forms.TextBox txtIdentificador;
        private System.Windows.Forms.CheckBox chkMunicipio;
        private System.Windows.Forms.CheckBox chkIdentificador;
        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton tsbFiltrar;
        private System.Windows.Forms.ToolStripButton tsbNuevo;
        private System.Windows.Forms.ToolStripButton tsbImprimir;
        private System.Windows.Forms.ToolStripButton tsbMarcarTodos;
        private System.Windows.Forms.ToolStripButton tsbSeleccionarTodos;
        private System.Windows.Forms.ToolStripButton tsbFiltroAutomatico;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsbNoRegistros;
        private System.Windows.Forms.DataGridView dgvLista;
        private System.Windows.Forms.ContextMenuStrip mcsMenu;
        private System.Windows.Forms.ToolStripMenuItem cmNuevo;
        private System.Windows.Forms.ToolStripMenuItem cmActualizar;
        private System.Windows.Forms.ToolStripMenuItem cmEliminar;
        private System.Windows.Forms.ToolStripMenuItem cmVisualizar;
        private System.Windows.Forms.ToolStripMenuItem cmImprimir;
    }
}