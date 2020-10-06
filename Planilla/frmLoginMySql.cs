using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planilla
{
    public partial class frmLoginMySql : Form
    {
        public frmLoginMySql()
        {
            InitializeComponent();
        }

        #region "Funciones Del Programador"

        private void TraerVariableDeConexion()
        {
            try
            {
                txtServidor.Text = Properties.Settings.Default.Servidor;
                txtUsuario.Text = Properties.Settings.Default.Usuario;
                txtContrasena.Text = Properties.Settings.Default.Contrasena;
                txtBaseDeDatos.Text = Properties.Settings.Default.BaseDeDatos;
                txtPuertoDeConexion.Text = Properties.Settings.Default.PuertoDeConexion;
            }
            catch(Exception ex)
            {
                string Mensaje = ex.Message;
                if(ex.InnerException != null)
                {
                    Mensaje += Environment.NewLine + "Inner Exception:" + ex.InnerException.Message;
                }
                MessageBox.Show(Mensaje, "Traer Variable De Conexion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private string TraerCadenaDeConexion()
        {
            //trae la cadena de conexion =  data source: Servidor, Initial Catlog: BaseDeDatos, User Id: Usuario, Password: Contrasena; tienen que ir en orden;
            string Cadena = string.Format(@"Data source = '{0}'; Initial catalog = '{1}'; Persist security Info = true; User Id = '{2}'; Password = '{3}'", txtServidor.Text.Trim(), txtBaseDeDatos.Text.Trim(), txtUsuario.Text.Trim(), txtContrasena.Text.Trim());
            return Cadena;
        }
        private bool TestDeConexion()
        {
            MySql.Data.MySqlClient.MySqlConnection Conexion = new MySql.Data.MySqlClient.MySqlConnection(TraerCadenaDeConexion());
            try
            {
                Conexion.Open();
                MessageBox.Show("Conexion realizada correctamente");
                return true;
            }
            catch (Exception ex)
            {
                string Mensaje = ex.Message;
                if (ex.InnerException != null)
                {
                    Mensaje += Environment.NewLine + "Inner Exception:" + ex.InnerException.Message;
                }
                MessageBox.Show(Mensaje, "Test De Conexion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            finally
            {
                if (Conexion.State == ConnectionState.Open)
                {
                    Conexion.Close();
                }
                Conexion = null;
            }
        }
        private void GuardarVariablesDeConexion()
        {
            try
            {
                Properties.Settings.Default.Servidor = txtServidor.Text.Trim();
                Properties.Settings.Default.Usuario = txtUsuario.Text.Trim();
                Properties.Settings.Default.Contrasena = txtContrasena.Text.Trim();
                Properties.Settings.Default.BaseDeDatos = txtBaseDeDatos.Text.Trim();
                Properties.Settings.Default.PuertoDeConexion = txtPuertoDeConexion.Text.Trim();
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                string Mensaje = ex.Message;
                if (ex.InnerException != null)
                {
                    Mensaje += Environment.NewLine + "Inner Exception:" + ex.InnerException.Message;
                }
                MessageBox.Show(Mensaje, "Guardar Variable De Conexion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        private void frmLoginMySql_Load(object sender, EventArgs e)
        {
            TraerVariableDeConexion();
        }

        private void btnTestDeConexion_Click(object sender, EventArgs e)
        {
            try
            {
                if (TestDeConexion())
                {
                    GuardarVariablesDeConexion();
                    Program.LlenarDatosDeConexion();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                string Mensaje = ex.Message;
                if (ex.InnerException != null)
                {
                    Mensaje += Environment.NewLine + "Inner Exception:" + ex.InnerException.Message;
                }
                MessageBox.Show(Mensaje, "Test De Conexion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
