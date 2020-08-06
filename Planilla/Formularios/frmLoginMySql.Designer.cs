namespace Planilla
{
    partial class frmLoginMySql
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbLoginMySql = new System.Windows.Forms.GroupBox();
            this.txtPuertoDeConexion = new System.Windows.Forms.TextBox();
            this.txtBaseDeDatos = new System.Windows.Forms.TextBox();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtServidor = new System.Windows.Forms.TextBox();
            this.lbPuertoDeConexion = new System.Windows.Forms.Label();
            this.lbBaseDeDatos = new System.Windows.Forms.Label();
            this.lbContrasena = new System.Windows.Forms.Label();
            this.lbUsuario = new System.Windows.Forms.Label();
            this.lbServidor = new System.Windows.Forms.Label();
            this.btnTestDeConexion = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.gbLoginMySql.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbLoginMySql
            // 
            this.gbLoginMySql.Controls.Add(this.txtPuertoDeConexion);
            this.gbLoginMySql.Controls.Add(this.txtBaseDeDatos);
            this.gbLoginMySql.Controls.Add(this.txtContrasena);
            this.gbLoginMySql.Controls.Add(this.txtUsuario);
            this.gbLoginMySql.Controls.Add(this.txtServidor);
            this.gbLoginMySql.Controls.Add(this.lbPuertoDeConexion);
            this.gbLoginMySql.Controls.Add(this.lbBaseDeDatos);
            this.gbLoginMySql.Controls.Add(this.lbContrasena);
            this.gbLoginMySql.Controls.Add(this.lbUsuario);
            this.gbLoginMySql.Controls.Add(this.lbServidor);
            this.gbLoginMySql.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbLoginMySql.Location = new System.Drawing.Point(15, 14);
            this.gbLoginMySql.Margin = new System.Windows.Forms.Padding(2);
            this.gbLoginMySql.Name = "gbLoginMySql";
            this.gbLoginMySql.Padding = new System.Windows.Forms.Padding(2);
            this.gbLoginMySql.Size = new System.Drawing.Size(387, 290);
            this.gbLoginMySql.TabIndex = 0;
            this.gbLoginMySql.TabStop = false;
            this.gbLoginMySql.Text = "Informacion De La Conexion Con MySql";
            // 
            // txtPuertoDeConexion
            // 
            this.txtPuertoDeConexion.Location = new System.Drawing.Point(203, 250);
            this.txtPuertoDeConexion.Margin = new System.Windows.Forms.Padding(2);
            this.txtPuertoDeConexion.Name = "txtPuertoDeConexion";
            this.txtPuertoDeConexion.Size = new System.Drawing.Size(159, 26);
            this.txtPuertoDeConexion.TabIndex = 5;
            // 
            // txtBaseDeDatos
            // 
            this.txtBaseDeDatos.Location = new System.Drawing.Point(203, 200);
            this.txtBaseDeDatos.Margin = new System.Windows.Forms.Padding(2);
            this.txtBaseDeDatos.Name = "txtBaseDeDatos";
            this.txtBaseDeDatos.Size = new System.Drawing.Size(159, 26);
            this.txtBaseDeDatos.TabIndex = 4;
            // 
            // txtContrasena
            // 
            this.txtContrasena.Location = new System.Drawing.Point(203, 144);
            this.txtContrasena.Margin = new System.Windows.Forms.Padding(2);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.PasswordChar = '*';
            this.txtContrasena.Size = new System.Drawing.Size(159, 26);
            this.txtContrasena.TabIndex = 3;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(203, 93);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(159, 26);
            this.txtUsuario.TabIndex = 2;
            // 
            // txtServidor
            // 
            this.txtServidor.Location = new System.Drawing.Point(203, 47);
            this.txtServidor.Margin = new System.Windows.Forms.Padding(2);
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.Size = new System.Drawing.Size(159, 26);
            this.txtServidor.TabIndex = 1;
            // 
            // lbPuertoDeConexion
            // 
            this.lbPuertoDeConexion.AutoSize = true;
            this.lbPuertoDeConexion.Location = new System.Drawing.Point(13, 252);
            this.lbPuertoDeConexion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbPuertoDeConexion.Name = "lbPuertoDeConexion";
            this.lbPuertoDeConexion.Size = new System.Drawing.Size(179, 20);
            this.lbPuertoDeConexion.TabIndex = 4;
            this.lbPuertoDeConexion.Text = "Puerto De Conexion :";
            // 
            // lbBaseDeDatos
            // 
            this.lbBaseDeDatos.AutoSize = true;
            this.lbBaseDeDatos.Location = new System.Drawing.Point(13, 201);
            this.lbBaseDeDatos.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbBaseDeDatos.Name = "lbBaseDeDatos";
            this.lbBaseDeDatos.Size = new System.Drawing.Size(141, 20);
            this.lbBaseDeDatos.TabIndex = 3;
            this.lbBaseDeDatos.Text = "Base De Datos :";
            // 
            // lbContrasena
            // 
            this.lbContrasena.AutoSize = true;
            this.lbContrasena.Location = new System.Drawing.Point(13, 146);
            this.lbContrasena.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbContrasena.Name = "lbContrasena";
            this.lbContrasena.Size = new System.Drawing.Size(112, 20);
            this.lbContrasena.TabIndex = 2;
            this.lbContrasena.Text = "Contraseña :";
            // 
            // lbUsuario
            // 
            this.lbUsuario.AutoSize = true;
            this.lbUsuario.Location = new System.Drawing.Point(13, 95);
            this.lbUsuario.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbUsuario.Name = "lbUsuario";
            this.lbUsuario.Size = new System.Drawing.Size(81, 20);
            this.lbUsuario.TabIndex = 1;
            this.lbUsuario.Text = "Usuario :";
            // 
            // lbServidor
            // 
            this.lbServidor.AutoSize = true;
            this.lbServidor.Location = new System.Drawing.Point(13, 49);
            this.lbServidor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbServidor.Name = "lbServidor";
            this.lbServidor.Size = new System.Drawing.Size(85, 20);
            this.lbServidor.TabIndex = 0;
            this.lbServidor.Text = "Servidor :";
            // 
            // btnTestDeConexion
            // 
            this.btnTestDeConexion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestDeConexion.Location = new System.Drawing.Point(31, 353);
            this.btnTestDeConexion.Margin = new System.Windows.Forms.Padding(2);
            this.btnTestDeConexion.Name = "btnTestDeConexion";
            this.btnTestDeConexion.Size = new System.Drawing.Size(165, 30);
            this.btnTestDeConexion.TabIndex = 6;
            this.btnTestDeConexion.Text = "Test De Conexion";
            this.btnTestDeConexion.UseVisualStyleBackColor = true;
            this.btnTestDeConexion.Click += new System.EventHandler(this.btnTestDeConexion_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(273, 353);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(103, 30);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmLoginMySql
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 415);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnTestDeConexion);
            this.Controls.Add(this.gbLoginMySql);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmLoginMySql";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmLoginMySql_Load);
            this.gbLoginMySql.ResumeLayout(false);
            this.gbLoginMySql.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbLoginMySql;
        private System.Windows.Forms.TextBox txtPuertoDeConexion;
        private System.Windows.Forms.TextBox txtBaseDeDatos;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtServidor;
        private System.Windows.Forms.Label lbPuertoDeConexion;
        private System.Windows.Forms.Label lbBaseDeDatos;
        private System.Windows.Forms.Label lbContrasena;
        private System.Windows.Forms.Label lbUsuario;
        private System.Windows.Forms.Label lbServidor;
        private System.Windows.Forms.Button btnTestDeConexion;
        private System.Windows.Forms.Button btnCancelar;
    }
}

