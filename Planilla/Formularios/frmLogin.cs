using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidad;
using Logica;
using System.Net;
using System.Net.Sockets;

namespace Planilla
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            LoginUsuario();
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F4)
            {
                this.Hide();
                Planilla.frmLoginMySql ofrmLoginMySql = new frmLoginMySql();
                ofrmLoginMySql.ShowDialog();
                CargarDatosDeConexionDeMySQL();
                this.Show();
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            if (e.KeyCode == Keys.Enter)
            {
                LoginUsuario();
            }
        }

        private void frmLogin_Shown(object sender, EventArgs e)
        {
            Program.LlenarDatosDeConexion();
            CargarDatosDeConexionDeMySQL();
            ObtenerDireccionIP();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region "Funciones del programador"
        private void CargarDatosDeConexionDeMySQL()
        {
            try
            {
                txtServidor.Text = Program.oDatosDeConexioEN.Servidor;                
                txtServidor.ReadOnly = true;
            }
            catch (Exception ex)
            {
                string Mensaje = ex.Message;
                if(ex.InnerException != null)
                {
                    Mensaje += Environment.NewLine + "Inner Exception: " + ex.InnerException.Message;
                }
                MessageBox.Show(Mensaje, "Cargar Datos de conexion de MySql", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void LoginUsuario()
        {
            try
            {
                LoginEN oRegistroEN = new LoginEN();
                LoginLN oRegistroLN = new LoginLN();

                if(string.IsNullOrEmpty(txtUsuario.Text) || txtUsuario.Text.Trim().Length == 0)
                {
                    throw new ArgumentException("Escriba la contraseña del usuario");
                }
                //Se deve esperar hasta que se llenen los datos hasta usar la encriptacion
                //oRegistroEN.Contrasena = Funciones.CifrarCadenas.EncriptarCadena(txtContrasena.Text.Trim());
                Program.oLoginEN.Contrasena = txtContrasena.Text.Trim();
                Program.oLoginEN.Login = txtUsuario.Text.Trim().ToUpper();

                if (oRegistroLN.IniciarLaSesionDelUsuario(Program.oLoginEN, Program.oDatosDeConexioEN))
                {
                    Program.Inicializar = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Nombre de Usuario o Contraseña son incorrectos", "Login de usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    throw new ArgumentException(oRegistroLN.Error);
                }
            }
            catch (Exception ex)
            {
                string Mensaje = ex.Message;
                if (ex.InnerException != null)
                {
                    Mensaje += Environment.NewLine + "Inner Exception: " + ex.InnerException.Message;
                }
                MessageBox.Show(Mensaje, "Cargar Datos de conexion de MySql", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ObtenerDireccionIP()
        {
            if (Program.oLoginEN == null) { Program.oLoginEN = new LoginEN(); }

            string strHostName = string.Empty;
            strHostName = Dns.GetHostName();
            IPAddress[] hostIPs = Dns.GetHostAddresses(strHostName);

            foreach (IPAddress ip in hostIPs)
            {

                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    Program.oLoginEN.NumeroIP = ip.ToString();
                    break;
                }

            }

            Program.oLoginEN.NombreDelEquipo = Environment.MachineName.ToString();

        }

        #endregion
    }
}
