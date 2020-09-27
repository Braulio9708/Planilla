using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidad;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using Planilla.Formularios;


namespace Planilla
{
    static class Program
    {
        public static DatosDeConexionEN oDatosDeConexioEN = new DatosDeConexionEN();
        //
        public static bool Inicializar = false;
        public static bool Iniciar = false;
        public static string NombreSistema = " ";//"Sistema Contable";
        public static string NombreEmpresa = "Deleit's Pizza";
        public static string EntidadIngSistemas = "Servicios tecnicos S.A";
        public static string VersionSistema = Version();
        public static string NombreVersionSistema = NombreSistema + VersionSistema;
        public static DatosDeConexionEN oDatosDeConexion = null;        
        public static LoginEN oLoginEN = null;
        public static string Errores;
        public static ConfiguracionEN oConfiguracionEN = new ConfiguracionEN();
        public static EmpresaEN oEmpresaEN = new EmpresaEN();
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmLogin());

            /*
             * aqui mandamos a llamar al formulario de bienvenida o pantalla de carga
             * frmSplash ofrmSplash = new frmSplash();
            ofrmSplash.ShowDialog();*/

            frmLogin ofrmLogin = new frmLogin();
            ofrmLogin.ShowDialog();

            if (Inicializar == true)
            {
                Application.Run(new Principal());
            }
        }

        public static void LlenarDatosDeConexion()
        {
            try
            {
                Program.oDatosDeConexion = new DatosDeConexionEN();
                Program.oDatosDeConexioEN.Servidor = Properties.Settings.Default.Servidor;
                Program.oDatosDeConexioEN.Usuario = Properties.Settings.Default.Usuario;
                Program.oDatosDeConexioEN.Contrasena = Properties.Settings.Default.Contrasena;
                Program.oDatosDeConexioEN.BaseDeDatos = Properties.Settings.Default.BaseDeDatos;
                Program.oDatosDeConexioEN.PuertoDeConeccion = Properties.Settings.Default.PuertoDeConexion;
                
            }
            catch (Exception ex)
            {
                string mensage = ex.Message;
                if(ex.InnerException != null)
                {
                    mensage += Environment.NewLine + "Inner Exception :" + ex.InnerException.Message;
                }
                MessageBox.Show(mensage, "Llenar Datos De Conexion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
         }

        #region  "Funciones del programador"    
        /// <summary>
        /// Funcion que nos permite traer la informacion de la version de sistema
        /// </summary>
        /// <returns></returns>
        public static string Version()
        {
            string sversion = "";
            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {
                sversion = string.Format("Versión: {0}.{1}.{2}.{3}",
                    System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.Major,
                    System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.Minor,
                    System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.Build,
                    System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.Revision);
            }
            else
            {
                sversion = string.Format(" Versión: {0}", Application.ProductVersion.ToString());
            }

            return sversion;

        }

        //Esta funcion nos permite obtener la impresora predeterminada
        public static string GetImpresoraDefecto()
        {
            for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                PrinterSettings a = new PrinterSettings();
                a.PrinterName = PrinterSettings.InstalledPrinters[i].ToString();
                if (a.IsDefaultPrinter)
                {
                    return PrinterSettings.InstalledPrinters[i].ToString();

                }
            }
            return "";
        }

        public static bool Exportar_Logo_Para_Excel(PictureBox pbxImagen)
        {
            try
            {
                if (!Directory.Exists(Application.StartupPath + "/Logos"))
                {
                    Directory.CreateDirectory(Application.StartupPath + "/Logos");
                }

                string Ruta;
                Ruta = Application.StartupPath + "/Logos/Logo_Empresa.png";

                Image image = pbxImagen.Image;
                image.Save(Ruta, System.Drawing.Imaging.ImageFormat.Png);
                return true;
            }
            catch (Exception ex)
            {
                Errores = ex.Message;
                return false;
            }
        }
        
        #endregion
    }
}
