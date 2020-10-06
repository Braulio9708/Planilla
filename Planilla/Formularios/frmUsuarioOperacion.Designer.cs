namespace Planilla.Formularios
{
    partial class frmUsuarioOperacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsuarioOperacion));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsGuardar = new System.Windows.Forms.ToolStripButton();
            this.tsActualizar = new System.Windows.Forms.ToolStripButton();
            this.tsEliminar = new System.Windows.Forms.ToolStripButton();
            this.tsNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsSalir = new System.Windows.Forms.ToolStripButton();
            this.tsRecargar = new System.Windows.Forms.ToolStripButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.cmbTipoDeCuenta = new System.Windows.Forms.ComboBox();
            this.txtCorreoElectronico = new System.Windows.Forms.TextBox();
            this.txtConfirmar = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.txtNombreSecion = new System.Windows.Forms.TextBox();
            this.txtNombreUsuario = new System.Windows.Forms.TextBox();
            this.txtIdentificador = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tstNumeroDeRegistro = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.tsAplicarFiltroAutomatio = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsFiltarPrivilegios = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsSeleccionar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBuscarPrivilegio = new System.Windows.Forms.ToolStripButton();
            this.tsbBuscarPrivilegio = new System.Windows.Forms.ToolStripTextBox();
            this.txtPrivilegio = new System.Windows.Forms.TextBox();
            this.cmbInterfaz = new System.Windows.Forms.ComboBox();
            this.cmbModulo = new System.Windows.Forms.ComboBox();
            this.chkPrivilegio = new System.Windows.Forms.CheckBox();
            this.chkInterfaz = new System.Windows.Forms.CheckBox();
            this.chkModulo = new System.Windows.Forms.CheckBox();
            this.chkCerrarVentana = new System.Windows.Forms.CheckBox();
            this.tstBarraDePrograso = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.BarraDeProgreso = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsGuardar,
            this.tsActualizar,
            this.tsEliminar,
            this.tsNuevo,
            this.tsSalir,
            this.tsRecargar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1109, 31);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsGuardar
            // 
            this.tsGuardar.Image = global::Planilla.Properties.Resources.Save32x32;
            this.tsGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsGuardar.Name = "tsGuardar";
            this.tsGuardar.Size = new System.Drawing.Size(77, 28);
            this.tsGuardar.Tag = "Guardar";
            this.tsGuardar.Text = "Guardar";
            // 
            // tsActualizar
            // 
            this.tsActualizar.Image = global::Planilla.Properties.Resources.Edit24x241;
            this.tsActualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsActualizar.Name = "tsActualizar";
            this.tsActualizar.Size = new System.Drawing.Size(87, 28);
            this.tsActualizar.Tag = "Actualizar";
            this.tsActualizar.Text = "Actualizar";
            // 
            // tsEliminar
            // 
            this.tsEliminar.Image = global::Planilla.Properties.Resources.Eliminar24x241;
            this.tsEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsEliminar.Name = "tsEliminar";
            this.tsEliminar.Size = new System.Drawing.Size(78, 28);
            this.tsEliminar.Tag = "Eliminar";
            this.tsEliminar.Text = "Eliminar";
            // 
            // tsNuevo
            // 
            this.tsNuevo.Image = global::Planilla.Properties.Resources.New32;
            this.tsNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsNuevo.Name = "tsNuevo";
            this.tsNuevo.Size = new System.Drawing.Size(70, 28);
            this.tsNuevo.Tag = "Nuevo";
            this.tsNuevo.Text = "Nuevo";
            // 
            // tsSalir
            // 
            this.tsSalir.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsSalir.Image = global::Planilla.Properties.Resources.iconfinder_Close_1891023__3_;
            this.tsSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSalir.Name = "tsSalir";
            this.tsSalir.Size = new System.Drawing.Size(56, 28);
            this.tsSalir.Tag = "salir";
            this.tsSalir.Text = "salir";
            // 
            // tsRecargar
            // 
            this.tsRecargar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsRecargar.Image = global::Planilla.Properties.Resources.Refresh132x32;
            this.tsRecargar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsRecargar.Name = "tsRecargar";
            this.tsRecargar.Size = new System.Drawing.Size(81, 28);
            this.tsRecargar.Tag = "Recargar";
            this.tsRecargar.Text = "Recargar";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Controls.Add(this.groupBox2);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 34);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1109, 448);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cmbEstado);
            this.groupBox1.Controls.Add(this.cmbTipoDeCuenta);
            this.groupBox1.Controls.Add(this.txtCorreoElectronico);
            this.groupBox1.Controls.Add(this.txtConfirmar);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtContrasena);
            this.groupBox1.Controls.Add(this.txtNombreSecion);
            this.groupBox1.Controls.Add(this.txtNombreUsuario);
            this.groupBox1.Controls.Add(this.txtIdentificador);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(548, 230);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(310, 199);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Estado:";
            // 
            // cmbEstado
            // 
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(370, 196);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(163, 21);
            this.cmbEstado.TabIndex = 14;
            // 
            // cmbTipoDeCuenta
            // 
            this.cmbTipoDeCuenta.FormattingEnabled = true;
            this.cmbTipoDeCuenta.Location = new System.Drawing.Point(136, 196);
            this.cmbTipoDeCuenta.Name = "cmbTipoDeCuenta";
            this.cmbTipoDeCuenta.Size = new System.Drawing.Size(168, 21);
            this.cmbTipoDeCuenta.TabIndex = 13;
            // 
            // txtCorreoElectronico
            // 
            this.txtCorreoElectronico.Location = new System.Drawing.Point(136, 165);
            this.txtCorreoElectronico.Name = "txtCorreoElectronico";
            this.txtCorreoElectronico.Size = new System.Drawing.Size(397, 20);
            this.txtCorreoElectronico.TabIndex = 12;
            // 
            // txtConfirmar
            // 
            this.txtConfirmar.Location = new System.Drawing.Point(370, 134);
            this.txtConfirmar.Name = "txtConfirmar";
            this.txtConfirmar.Size = new System.Drawing.Size(163, 20);
            this.txtConfirmar.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(310, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Confirmar:";
            // 
            // txtContrasena
            // 
            this.txtContrasena.Location = new System.Drawing.Point(136, 134);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.Size = new System.Drawing.Size(168, 20);
            this.txtContrasena.TabIndex = 9;
            // 
            // txtNombreSecion
            // 
            this.txtNombreSecion.Location = new System.Drawing.Point(136, 104);
            this.txtNombreSecion.Name = "txtNombreSecion";
            this.txtNombreSecion.Size = new System.Drawing.Size(397, 20);
            this.txtNombreSecion.TabIndex = 8;
            // 
            // txtNombreUsuario
            // 
            this.txtNombreUsuario.Location = new System.Drawing.Point(136, 76);
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.Size = new System.Drawing.Size(397, 20);
            this.txtNombreUsuario.TabIndex = 7;
            // 
            // txtIdentificador
            // 
            this.txtIdentificador.Location = new System.Drawing.Point(136, 47);
            this.txtIdentificador.Name = "txtIdentificador";
            this.txtIdentificador.Size = new System.Drawing.Size(168, 20);
            this.txtIdentificador.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Tipo de Cuenta:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Correo Electronico:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Contraseña:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nombre de Secion:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre del Usuario:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Identificador:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Location = new System.Drawing.Point(557, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(540, 435);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.statusStrip1);
            this.groupBox4.Controls.Add(this.dataGridView1);
            this.groupBox4.Location = new System.Drawing.Point(13, 237);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(521, 192);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Privilegios del Usuario";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tstNumeroDeRegistro,
            this.toolStripStatusLabel1,
            this.tstBarraDePrograso,
            this.BarraDeProgreso});
            this.statusStrip1.Location = new System.Drawing.Point(3, 167);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(515, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tstNumeroDeRegistro
            // 
            this.tstNumeroDeRegistro.Name = "tstNumeroDeRegistro";
            this.tstNumeroDeRegistro.Size = new System.Drawing.Size(100, 17);
            this.tstNumeroDeRegistro.Text = "No. de Registro: 0";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(515, 173);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.toolStrip3);
            this.groupBox3.Controls.Add(this.toolStrip2);
            this.groupBox3.Controls.Add(this.txtPrivilegio);
            this.groupBox3.Controls.Add(this.cmbInterfaz);
            this.groupBox3.Controls.Add(this.cmbModulo);
            this.groupBox3.Controls.Add(this.chkPrivilegio);
            this.groupBox3.Controls.Add(this.chkInterfaz);
            this.groupBox3.Controls.Add(this.chkModulo);
            this.groupBox3.Location = new System.Drawing.Point(6, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(528, 211);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filtrar Privilegios del Usuario";
            // 
            // toolStrip3
            // 
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsAplicarFiltroAutomatio});
            this.toolStrip3.Location = new System.Drawing.Point(343, 115);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip3.Size = new System.Drawing.Size(172, 25);
            this.toolStrip3.TabIndex = 7;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // tsAplicarFiltroAutomatio
            // 
            this.tsAplicarFiltroAutomatio.Image = global::Planilla.Properties.Resources.checked20x20;
            this.tsAplicarFiltroAutomatio.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsAplicarFiltroAutomatio.Name = "tsAplicarFiltroAutomatio";
            this.tsAplicarFiltroAutomatio.Size = new System.Drawing.Size(160, 22);
            this.tsAplicarFiltroAutomatio.Tag = "AplicarFiltoAutomatico";
            this.tsAplicarFiltroAutomatio.Text = "Aplicar Filtro Automatico";
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsFiltarPrivilegios,
            this.toolStripSeparator1,
            this.tsSeleccionar,
            this.toolStripSeparator2,
            this.tsBuscarPrivilegio,
            this.tsbBuscarPrivilegio});
            this.toolStrip2.Location = new System.Drawing.Point(3, 183);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(522, 25);
            this.toolStrip2.TabIndex = 6;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tsFiltarPrivilegios
            // 
            this.tsFiltarPrivilegios.Image = global::Planilla.Properties.Resources.filtrar24x24;
            this.tsFiltarPrivilegios.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsFiltarPrivilegios.Name = "tsFiltarPrivilegios";
            this.tsFiltarPrivilegios.Size = new System.Drawing.Size(114, 22);
            this.tsFiltarPrivilegios.Tag = "Filtrar Privilrgios";
            this.tsFiltarPrivilegios.Text = "Filtrar Privilegios";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsSeleccionar
            // 
            this.tsSeleccionar.Image = global::Planilla.Properties.Resources.checked16x16;
            this.tsSeleccionar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSeleccionar.Name = "tsSeleccionar";
            this.tsSeleccionar.Size = new System.Drawing.Size(87, 22);
            this.tsSeleccionar.Tag = "Seleccionar";
            this.tsSeleccionar.Text = "Seleccionar";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsBuscarPrivilegio
            // 
            this.tsBuscarPrivilegio.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBuscarPrivilegio.Image = ((System.Drawing.Image)(resources.GetObject("tsBuscarPrivilegio.Image")));
            this.tsBuscarPrivilegio.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBuscarPrivilegio.Name = "tsBuscarPrivilegio";
            this.tsBuscarPrivilegio.Size = new System.Drawing.Size(101, 22);
            this.tsBuscarPrivilegio.Tag = "BuscarPrivilegio";
            this.tsBuscarPrivilegio.Text = "Buscar Privilegio:";
            // 
            // tsbBuscarPrivilegio
            // 
            this.tsbBuscarPrivilegio.Name = "tsbBuscarPrivilegio";
            this.tsbBuscarPrivilegio.Size = new System.Drawing.Size(150, 25);
            // 
            // txtPrivilegio
            // 
            this.txtPrivilegio.Location = new System.Drawing.Point(74, 118);
            this.txtPrivilegio.Name = "txtPrivilegio";
            this.txtPrivilegio.Size = new System.Drawing.Size(258, 20);
            this.txtPrivilegio.TabIndex = 5;
            // 
            // cmbInterfaz
            // 
            this.cmbInterfaz.FormattingEnabled = true;
            this.cmbInterfaz.Location = new System.Drawing.Point(74, 85);
            this.cmbInterfaz.Name = "cmbInterfaz";
            this.cmbInterfaz.Size = new System.Drawing.Size(258, 21);
            this.cmbInterfaz.TabIndex = 4;
            // 
            // cmbModulo
            // 
            this.cmbModulo.FormattingEnabled = true;
            this.cmbModulo.Location = new System.Drawing.Point(74, 53);
            this.cmbModulo.Name = "cmbModulo";
            this.cmbModulo.Size = new System.Drawing.Size(258, 21);
            this.cmbModulo.TabIndex = 3;
            // 
            // chkPrivilegio
            // 
            this.chkPrivilegio.AutoSize = true;
            this.chkPrivilegio.Location = new System.Drawing.Point(7, 118);
            this.chkPrivilegio.Name = "chkPrivilegio";
            this.chkPrivilegio.Size = new System.Drawing.Size(68, 17);
            this.chkPrivilegio.TabIndex = 2;
            this.chkPrivilegio.Tag = "Privilegio";
            this.chkPrivilegio.Text = "Privilegio";
            this.chkPrivilegio.UseVisualStyleBackColor = true;
            // 
            // chkInterfaz
            // 
            this.chkInterfaz.AutoSize = true;
            this.chkInterfaz.Location = new System.Drawing.Point(7, 88);
            this.chkInterfaz.Name = "chkInterfaz";
            this.chkInterfaz.Size = new System.Drawing.Size(61, 17);
            this.chkInterfaz.TabIndex = 1;
            this.chkInterfaz.Tag = "Interfaz";
            this.chkInterfaz.Text = "Interfaz";
            this.chkInterfaz.UseVisualStyleBackColor = true;
            // 
            // chkModulo
            // 
            this.chkModulo.AutoSize = true;
            this.chkModulo.Location = new System.Drawing.Point(7, 55);
            this.chkModulo.Name = "chkModulo";
            this.chkModulo.Size = new System.Drawing.Size(61, 17);
            this.chkModulo.TabIndex = 0;
            this.chkModulo.Tag = "Modulo";
            this.chkModulo.Text = "Modulo";
            this.chkModulo.UseVisualStyleBackColor = true;
            // 
            // chkCerrarVentana
            // 
            this.chkCerrarVentana.AutoSize = true;
            this.chkCerrarVentana.Location = new System.Drawing.Point(12, 488);
            this.chkCerrarVentana.Name = "chkCerrarVentana";
            this.chkCerrarVentana.Size = new System.Drawing.Size(195, 17);
            this.chkCerrarVentana.TabIndex = 2;
            this.chkCerrarVentana.Tag = "Cerrar Ventana";
            this.chkCerrarVentana.Text = "Cerrar ventana de forma automatica";
            this.chkCerrarVentana.UseVisualStyleBackColor = true;
            // 
            // tstBarraDePrograso
            // 
            this.tstBarraDePrograso.Name = "tstBarraDePrograso";
            this.tstBarraDePrograso.Size = new System.Drawing.Size(38, 17);
            this.tstBarraDePrograso.Text = "0 de 0";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(244, 17);
            this.toolStripStatusLabel1.Tag = "";
            this.toolStripStatusLabel1.Text = "...............................................................................";
            // 
            // BarraDeProgreso
            // 
            this.BarraDeProgreso.Name = "BarraDeProgreso";
            this.BarraDeProgreso.Size = new System.Drawing.Size(100, 16);
            // 
            // frmUsuarioOperacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 511);
            this.Controls.Add(this.chkCerrarVentana);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmUsuarioOperacion";
            this.Text = "frmUsuarioOperacion";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsGuardar;
        private System.Windows.Forms.ToolStripButton tsActualizar;
        private System.Windows.Forms.ToolStripButton tsEliminar;
        private System.Windows.Forms.ToolStripButton tsNuevo;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ToolStripButton tsSalir;
        private System.Windows.Forms.ToolStripButton tsRecargar;
        private System.Windows.Forms.CheckBox chkCerrarVentana;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCorreoElectronico;
        private System.Windows.Forms.TextBox txtConfirmar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.TextBox txtNombreSecion;
        private System.Windows.Forms.TextBox txtNombreUsuario;
        private System.Windows.Forms.TextBox txtIdentificador;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.ComboBox cmbTipoDeCuenta;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkModulo;
        private System.Windows.Forms.CheckBox chkPrivilegio;
        private System.Windows.Forms.CheckBox chkInterfaz;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsFiltarPrivilegios;
        private System.Windows.Forms.TextBox txtPrivilegio;
        private System.Windows.Forms.ComboBox cmbInterfaz;
        private System.Windows.Forms.ComboBox cmbModulo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsSeleccionar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsBuscarPrivilegio;
        private System.Windows.Forms.ToolStripTextBox tsbBuscarPrivilegio;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton tsAplicarFiltroAutomatio;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tstNumeroDeRegistro;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tstBarraDePrograso;
        private System.Windows.Forms.ToolStripProgressBar BarraDeProgreso;
    }
}