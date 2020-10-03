using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Planilla.Formularios;  //obtener el acceso a los formularios..
using Entidad; //activo la referencia de la entidad
using Logica;

namespace Planilla.Formularios
{
    public partial class Principal : Form
    {
        
        //creamos el objeto pero no lo inicializamos.
        frmConfiguracion ofrmConfiguracion = null;
        frmUsuario ofrmUsuario = null;
        frmCargo ofrmCargo = null;

        public Principal()
        {
            InitializeComponent();
        }

        

        /*private void AplicarColorAFormularios()
        {
            try
            {
                this.BackColor = Properties.Settings.Default.MyColorSetting;

                foreach (Form Items in Application.OpenForms.Cast<Form>())
                {
                    Items.BackColor = Properties.Settings.Default.MyColorSetting;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aplicar color a la ventanas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }*/

        

        private void smConfiguracion_Click(object sender, EventArgs e)
        {
            //PONER EL CURSO EN ESPERA
            this.Cursor = Cursors.WaitCursor;
            //PREGUNTAMOS SI EL OBJETO ESTA BASIO O NO A SIDO ENFOCADO
            if (ofrmConfiguracion == null || ofrmConfiguracion.IsDisposed)
            {//1. INICIALIZAR EL OBJETO...
                ofrmConfiguracion = new frmConfiguracion();
                //2. SE AGREGA COMO PARTE DEL MDI-PRINCIPAL
                ofrmConfiguracion.MdiParent = this;
                //3. MADAMOS A MOSTRAR EL EL FORMULARIO
                ofrmConfiguracion.Show();
                //4. NOS PERMITE COLOCAR EL FORMULARIO DE MANERA CENTRADA EN LA PANTALLA.
                ofrmConfiguracion.StartPosition = FormStartPosition.CenterScreen;
                //5. PERMITE MAXIMIZAR O MINIMIZAR O DEJAR DE MANERA NORMAL AL VENTANA
                ofrmConfiguracion.WindowState = FormWindowState.Maximized;

            }//EN CASO CONTRATRIO SIGNIFICA QUE EL FORMULARIO ESTA REFERENCIADO
            //Y SOLO LO MANDAMOS A LLAMAR.
            else
                ofrmConfiguracion.BringToFront();  //si el encuntra el objeto creado solo regresa el enfoque
            //y lo trae al frente
            //SACAMOS EL CURSOR DEL ESTADO DE ESPERA.
            this.Cursor = Cursors.Default;
        }

        #region "Funciones"

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (ofrmUsuario == null || ofrmUsuario.IsDisposed)
            {
                ofrmUsuario = new frmUsuario();
                ofrmUsuario.MdiParent = this;
                ofrmUsuario.Show();
                ofrmUsuario.StartPosition = FormStartPosition.CenterScreen;
                ofrmUsuario.WindowState = FormWindowState.Maximized;

            }
            else
                ofrmUsuario.BringToFront();

            this.Cursor = Cursors.Default;
        }

        private void CargarPrivilegiosDelUsuario()
        {

            try
            {

                this.Cursor = Cursors.WaitCursor;

                ModuloInterfazUsuarioEN oRegistroEN = new ModuloInterfazUsuarioEN();
                ModuloInterfazUsuarioLN oRegistroLN = new ModuloInterfazUsuarioLN();

                oRegistroEN.oUsuarioEN.IdUsuario = Program.oLoginEN.IdUsuario;

                if (oRegistroLN.ListadoPrivilegiosDelUsuariosPorModulo(oRegistroEN, Program.oDatosDeConexioEN))
                {

                    //PRIVILEGIOS A BARRA DE MENÚS
                    foreach (ToolStripMenuItem item in this.menuStrip.Items)
                    {
                        if (item.Tag != null)
                        {

                            if (item.Tag.ToString().Trim().Length > 0)
                            {

                                //item.Enabled = oRegistroLN.VerificarSiTengoAcceso(item.Tag.ToString());
                                if (item.DropDownItems.Count > 0)
                                {
                                    foreach (ToolStripItem Subitem in item.DropDownItems)
                                    {
                                        if (Subitem.GetType() == typeof(ToolStripMenuItem))
                                        {
                                            if (Subitem.Tag != null)
                                            {
                                                if (Subitem.Tag.ToString().Length > 0)
                                                {
                                                    Subitem.Enabled = oRegistroLN.VerificarSiTengoAccesoDeInterfaz(Subitem.Tag.ToString());
                                                }
                                            }
                                            else
                                            {
                                                Subitem.Enabled = false;
                                            }
                                        }
                                    }
                                }
                            }

                        }

                    }

                    /*foreach (ToolStripItem item in tsMenu.Items)
                    {
                        if (item.Tag != null)
                        {
                            if (item.GetType() == typeof(ToolStripButton))
                            {
                                item.Enabled = oRegistroLN.VerificarSiTengoAccesoDeInterfaz(item.Tag.ToString());
                            }
                        }
                        else {
                            item.Enabled = false;
                        }
                    }*/

                    foreach (Control item in splitContainer1.Panel2.Controls)
                    {
                        if (item.GetType() == typeof(System.Windows.Forms.Button))
                        {
                            Button btn = (Button)item;
                            if (btn.Tag != null)
                            {

                                if (btn.Tag.ToString() == "Débitos" || btn.Tag.ToString() == "Créditos")
                                {
                                    btn.Enabled = oRegistroLN.VerificarSiTengoAccesoDeInterfaz("Movimientos");
                                }
                                else
                                {
                                    if (btn.Tag.ToString() == "Reportes del Historico")
                                    {
                                        btn.Enabled = oRegistroLN.VerificarSiTengoAccesoDeInterfaz("Reportes");
                                    }
                                    else
                                    {
                                        btn.Enabled = oRegistroLN.VerificarSiTengoAccesoDeInterfaz(btn.Tag.ToString().Trim());
                                    }
                                }
                            }
                            else
                            {
                                btn.Enabled = false;
                            }
                        }
                    }


                }
                else
                {
                    throw new ArgumentException(oRegistroLN.Error);
                }


                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Verificacion de Privilegios del Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void OcultarControlesDentroDelPanel()
        {
            try
            {

                foreach (Control item in splitContainer1.Panel2.Controls)
                {
                    if (item.GetType() == typeof(System.Windows.Forms.Button))
                    {
                        Button btn = (Button)item;
                        btn.Visible = false;
                    }
                }

                msMenu.Visible = true;
                msMenu.TabIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ocultar controles que se encuentra en el panel", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void VisualizarControlesDentroDelPanel(string SControles)
        {
            try
            {
                if (SControles.Trim().Length > 0)
                {

                    foreach (Control item in splitContainer1.Panel2.Controls)
                    {
                        if (item.GetType() == typeof(System.Windows.Forms.Button))
                        {
                            Button btn = (Button)item;
                            if (SControles.Contains(btn.Name.Trim()) && btn.Enabled == true)
                            {
                                btn.Visible = true;
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ocultar controles que se encuentra en el panel", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

        private void MenuHerramientas_Click(object sender, EventArgs e)
        {
            OcultarControlesDentroDelPanel();
            string MostrarControles = "smRespaldar,smRestaurar";
            VisualizarControlesDentroDelPanel(MostrarControles);
        }

        private void Principal_Shown(object sender, EventArgs e)
        {
            CargarPrivilegiosDelUsuario();
            OcultarControlesDentroDelPanel();

            string MostrarControles = "smRespaldar,smRestaurar";
            VisualizarControlesDentroDelPanel(MostrarControles);

        }

        private void smRespaldar_Click(object sender, EventArgs e)
        {

        }

        private void msMenu_Click(object sender, EventArgs e)
        {
            if (msMenu.Tag.ToString().Trim().ToUpper() == "MOSTRAR")
            {
                splitContainer1.Width = 37;
                foreach (Control item in splitContainer1.Panel2.Controls)
                {
                    if (item.GetType() == typeof(System.Windows.Forms.Button))
                    {
                        Button btn = (Button)item;
                        item.Text = string.Empty;
                    }
                }

                foreach (Control item in splitContainer1.Panel1.Controls)
                {
                    if (item.GetType() == typeof(System.Windows.Forms.Button))
                    {
                        Button btn = (Button)item;
                        item.Text = string.Empty;
                    }
                }

                msMenu.Tag = "OCULTAR";
                msMenu.Text = string.Empty;
                msMenu.ImageAlign = ContentAlignment.MiddleCenter;

            }
            else if (msMenu.Tag.ToString().Trim().ToUpper() == "OCULTAR")
            {
                splitContainer1.Width = 223;
                foreach (Control item in splitContainer1.Panel2.Controls)
                {
                    if (item.GetType() == typeof(System.Windows.Forms.Button))
                    {
                        Button btn = (Button)item;
                        item.Text = item.Tag.ToString();
                    }
                }

                foreach (Control item in splitContainer1.Panel1.Controls)
                {
                    if (item.GetType() == typeof(System.Windows.Forms.Button))
                    {
                        Button btn = (Button)item;
                        item.Text = item.Tag.ToString();
                    }
                }

                msMenu.Tag = "MOSTRAR";
                msMenu.Text = "Menu";
                msMenu.ImageAlign = ContentAlignment.MiddleRight;
            }

        }

        private void btmGenerales_Click(object sender, EventArgs e)
        {
            OcultarControlesDentroDelPanel();
            string MostrarControles = "btnUsuario";
            VisualizarControlesDentroDelPanel(MostrarControles);
        }
               
        private void btnUsuario_Click_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (ofrmUsuario == null || ofrmUsuario.IsDisposed)
            {
                ofrmUsuario = new frmUsuario();
                ofrmUsuario.MdiParent = this;
                ofrmUsuario.Show();
                ofrmUsuario.StartPosition = FormStartPosition.CenterScreen;
                ofrmUsuario.WindowState = FormWindowState.Maximized;

            }
            else
                ofrmUsuario.BringToFront();

            this.Cursor = Cursors.Default;
        }

        private void btnEmpleado_Click(object sender, EventArgs e)
        {
            OcultarControlesDentroDelPanel();
            string MostrarControles = "btnCargo";
            VisualizarControlesDentroDelPanel(MostrarControles);
        }

        private void btnCargo_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if(ofrmCargo == null || ofrmCargo.IsDisposed)
            {
                ofrmCargo = new frmCargo();
                ofrmCargo.MdiParent = this;
                ofrmConfiguracion.StartPosition = FormStartPosition.CenterScreen;
                ofrmConfiguracion.WindowState = FormWindowState.Maximized;
                ofrmCargo.Show();
            }
            else
            {
                ofrmCargo.BringToFront();
            }
            this.Cursor = Cursors.Default;
        }

        
    }
}
