﻿namespace Planilla.Formularios
{
    partial class frmContratoOperacion
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.InformacionEntidadOperacion = new System.Windows.Forms.Label();
            this.chkCerrarVentana = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbEmpleado = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNumeroDeContrato = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpFechaDeFin = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaDeInicio = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTipoDeContrato = new System.Windows.Forms.TextBox();
            this.txtIdentificador = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbGuardar = new System.Windows.Forms.ToolStripButton();
            this.tsbActualizar = new System.Windows.Forms.ToolStripButton();
            this.tsbEliminar = new System.Windows.Forms.ToolStripButton();
            this.tsbLimpiarCampos = new System.Windows.Forms.ToolStripButton();
            this.tsbCerrarVentana = new System.Windows.Forms.ToolStripButton();
            this.tsbRecarRegistro = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbImprimir = new System.Windows.Forms.ToolStripButton();
            this.tsbAplicarCambio = new System.Windows.Forms.ToolStripButton();
            this.EP = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EP)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.InformacionEntidadOperacion);
            this.panel1.Controls.Add(this.chkCerrarVentana);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(746, 401);
            this.panel1.TabIndex = 2;
            // 
            // InformacionEntidadOperacion
            // 
            this.InformacionEntidadOperacion.AutoSize = true;
            this.InformacionEntidadOperacion.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InformacionEntidadOperacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.InformacionEntidadOperacion.Location = new System.Drawing.Point(47, 9);
            this.InformacionEntidadOperacion.Name = "InformacionEntidadOperacion";
            this.InformacionEntidadOperacion.Size = new System.Drawing.Size(0, 16);
            this.InformacionEntidadOperacion.TabIndex = 9;
            // 
            // chkCerrarVentana
            // 
            this.chkCerrarVentana.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkCerrarVentana.AutoSize = true;
            this.chkCerrarVentana.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCerrarVentana.Location = new System.Drawing.Point(13, 304);
            this.chkCerrarVentana.Margin = new System.Windows.Forms.Padding(4);
            this.chkCerrarVentana.Name = "chkCerrarVentana";
            this.chkCerrarVentana.Size = new System.Drawing.Size(275, 22);
            this.chkCerrarVentana.TabIndex = 2;
            this.chkCerrarVentana.Text = "Cerrar ventana de manera automatica";
            this.chkCerrarVentana.UseVisualStyleBackColor = true;
            this.chkCerrarVentana.CheckedChanged += new System.EventHandler(this.chkCerrarVentana_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.cmbEmpleado);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtNumeroDeContrato);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.dtpFechaDeFin);
            this.panel2.Controls.Add(this.dtpFechaDeInicio);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtTipoDeContrato);
            this.panel2.Controls.Add(this.txtIdentificador);
            this.panel2.Location = new System.Drawing.Point(20, 54);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(700, 244);
            this.panel2.TabIndex = 1;
            // 
            // cmbEmpleado
            // 
            this.cmbEmpleado.FormattingEnabled = true;
            this.cmbEmpleado.Location = new System.Drawing.Point(185, 192);
            this.cmbEmpleado.Name = "cmbEmpleado";
            this.cmbEmpleado.Size = new System.Drawing.Size(477, 21);
            this.cmbEmpleado.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(27, 196);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 18);
            this.label6.TabIndex = 15;
            this.label6.Text = "Empleado";
            // 
            // txtNumeroDeContrato
            // 
            this.txtNumeroDeContrato.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumeroDeContrato.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroDeContrato.Location = new System.Drawing.Point(185, 146);
            this.txtNumeroDeContrato.Margin = new System.Windows.Forms.Padding(4);
            this.txtNumeroDeContrato.Name = "txtNumeroDeContrato";
            this.txtNumeroDeContrato.Size = new System.Drawing.Size(477, 24);
            this.txtNumeroDeContrato.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(27, 152);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 18);
            this.label5.TabIndex = 13;
            this.label5.Text = "Numero De Contrato:";
            // 
            // dtpFechaDeFin
            // 
            this.dtpFechaDeFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDeFin.Location = new System.Drawing.Point(549, 108);
            this.dtpFechaDeFin.Name = "dtpFechaDeFin";
            this.dtpFechaDeFin.Size = new System.Drawing.Size(113, 20);
            this.dtpFechaDeFin.TabIndex = 12;
            // 
            // dtpFechaDeInicio
            // 
            this.dtpFechaDeInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDeInicio.Location = new System.Drawing.Point(185, 108);
            this.dtpFechaDeInicio.Name = "dtpFechaDeInicio";
            this.dtpFechaDeInicio.Size = new System.Drawing.Size(113, 20);
            this.dtpFechaDeInicio.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(395, 110);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 18);
            this.label4.TabIndex = 10;
            this.label4.Text = "Fecha De Fin:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 111);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 18);
            this.label2.TabIndex = 9;
            this.label2.Text = "Fecha DeInicio:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 71);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tipo de contrato:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "Identificador";
            // 
            // txtTipoDeContrato
            // 
            this.txtTipoDeContrato.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTipoDeContrato.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoDeContrato.Location = new System.Drawing.Point(185, 68);
            this.txtTipoDeContrato.Margin = new System.Windows.Forms.Padding(4);
            this.txtTipoDeContrato.Name = "txtTipoDeContrato";
            this.txtTipoDeContrato.Size = new System.Drawing.Size(477, 24);
            this.txtTipoDeContrato.TabIndex = 3;
            // 
            // txtIdentificador
            // 
            this.txtIdentificador.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdentificador.Location = new System.Drawing.Point(185, 21);
            this.txtIdentificador.Margin = new System.Windows.Forms.Padding(4);
            this.txtIdentificador.Name = "txtIdentificador";
            this.txtIdentificador.Size = new System.Drawing.Size(406, 24);
            this.txtIdentificador.TabIndex = 4;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbGuardar,
            this.tsbActualizar,
            this.tsbEliminar,
            this.tsbLimpiarCampos,
            this.tsbCerrarVentana,
            this.tsbRecarRegistro,
            this.toolStripSeparator1,
            this.tsbImprimir,
            this.tsbAplicarCambio});
            this.toolStrip1.Location = new System.Drawing.Point(0, 330);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(746, 71);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbGuardar
            // 
            this.tsbGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbGuardar.Image = global::Planilla.Properties.Resources.if_floppy_285657;
            this.tsbGuardar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGuardar.Name = "tsbGuardar";
            this.tsbGuardar.Size = new System.Drawing.Size(68, 68);
            this.tsbGuardar.Text = "Guardar";
            this.tsbGuardar.ToolTipText = "Guardar registro";
            this.tsbGuardar.Click += new System.EventHandler(this.tsbGuardar_Click);
            // 
            // tsbActualizar
            // 
            this.tsbActualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbActualizar.Image = global::Planilla.Properties.Resources.if_edit_173002__2_;
            this.tsbActualizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbActualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbActualizar.Name = "tsbActualizar";
            this.tsbActualizar.Size = new System.Drawing.Size(68, 68);
            this.tsbActualizar.Text = "Actualizar";
            this.tsbActualizar.ToolTipText = "Actualizar registro";
            this.tsbActualizar.Click += new System.EventHandler(this.tsbActualizar_Click);
            // 
            // tsbEliminar
            // 
            this.tsbEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEliminar.Image = global::Planilla.Properties.Resources.if_edit_delete_118920__2_;
            this.tsbEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEliminar.Name = "tsbEliminar";
            this.tsbEliminar.Size = new System.Drawing.Size(68, 68);
            this.tsbEliminar.Text = "Eliminar";
            this.tsbEliminar.ToolTipText = "Eliminar registro";
            this.tsbEliminar.Click += new System.EventHandler(this.tsbEliminar_Click);
            // 
            // tsbLimpiarCampos
            // 
            this.tsbLimpiarCampos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbLimpiarCampos.Image = global::Planilla.Properties.Resources.if_Plus_1891033__1_;
            this.tsbLimpiarCampos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbLimpiarCampos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLimpiarCampos.Name = "tsbLimpiarCampos";
            this.tsbLimpiarCampos.Size = new System.Drawing.Size(52, 68);
            this.tsbLimpiarCampos.Text = "Nuevo";
            this.tsbLimpiarCampos.ToolTipText = "Nuevo registro";
            this.tsbLimpiarCampos.Click += new System.EventHandler(this.tsbLimpiarCampos_Click);
            // 
            // tsbCerrarVentana
            // 
            this.tsbCerrarVentana.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbCerrarVentana.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCerrarVentana.Image = global::Planilla.Properties.Resources.if_Log_Out_27856;
            this.tsbCerrarVentana.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbCerrarVentana.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCerrarVentana.Name = "tsbCerrarVentana";
            this.tsbCerrarVentana.Size = new System.Drawing.Size(52, 68);
            this.tsbCerrarVentana.Text = "Salir";
            this.tsbCerrarVentana.ToolTipText = "Cerrar la ventana y retornar";
            this.tsbCerrarVentana.Click += new System.EventHandler(this.tsbCerrarVentana_Click);
            // 
            // tsbRecarRegistro
            // 
            this.tsbRecarRegistro.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbRecarRegistro.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRecarRegistro.Image = global::Planilla.Properties.Resources.if_Synchronize_27883__1_;
            this.tsbRecarRegistro.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbRecarRegistro.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRecarRegistro.Name = "tsbRecarRegistro";
            this.tsbRecarRegistro.Size = new System.Drawing.Size(52, 68);
            this.tsbRecarRegistro.Text = "Recargar ";
            this.tsbRecarRegistro.ToolTipText = "Recargar  registro";
            this.tsbRecarRegistro.Click += new System.EventHandler(this.tsbRecarRegistro_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 71);
            // 
            // tsbImprimir
            // 
            this.tsbImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbImprimir.Image = global::Planilla.Properties.Resources.if_printer_39263__3_;
            this.tsbImprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbImprimir.Name = "tsbImprimir";
            this.tsbImprimir.Size = new System.Drawing.Size(68, 68);
            this.tsbImprimir.Text = "Imprimir";
            this.tsbImprimir.Visible = false;
            // 
            // tsbAplicarCambio
            // 
            this.tsbAplicarCambio.Image = global::Planilla.Properties.Resources.checked24x24;
            this.tsbAplicarCambio.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAplicarCambio.Name = "tsbAplicarCambio";
            this.tsbAplicarCambio.Size = new System.Drawing.Size(130, 68);
            this.tsbAplicarCambio.Text = "Aplicar cambio";
            this.tsbAplicarCambio.Click += new System.EventHandler(this.tsbAplicarCambio_Click);
            // 
            // EP
            // 
            this.EP.ContainerControl = this;
            // 
            // frmContratoOperacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 401);
            this.Controls.Add(this.panel1);
            this.Name = "frmContratoOperacion";
            this.Text = "frmContratoOperacion";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmContratoOperacion_FormClosing);
            this.Shown += new System.EventHandler(this.frmContratoOperacion_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label InformacionEntidadOperacion;
        private System.Windows.Forms.CheckBox chkCerrarVentana;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtNumeroDeContrato;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpFechaDeFin;
        private System.Windows.Forms.DateTimePicker dtpFechaDeInicio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTipoDeContrato;
        private System.Windows.Forms.TextBox txtIdentificador;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbGuardar;
        private System.Windows.Forms.ToolStripButton tsbActualizar;
        private System.Windows.Forms.ToolStripButton tsbEliminar;
        private System.Windows.Forms.ToolStripButton tsbLimpiarCampos;
        private System.Windows.Forms.ToolStripButton tsbCerrarVentana;
        private System.Windows.Forms.ToolStripButton tsbRecarRegistro;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbImprimir;
        private System.Windows.Forms.ToolStripButton tsbAplicarCambio;
        private System.Windows.Forms.ComboBox cmbEmpleado;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ErrorProvider EP;
    }
}