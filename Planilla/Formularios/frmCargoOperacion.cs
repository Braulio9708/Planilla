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
using Funciones;

namespace Planilla.Formularios
{
    public partial class frmCargoOperacion : Form
    {
        public frmCargoOperacion()
        {
            InitializeComponent();
        }

        public string OperacionARealizar { set; get; }
        public string Nombre_Entidad_Privilegio { set; get; }
        public string Nombre_Entidad { set; get; }
        public int ValorLlavePrimariaEntidad { set; get; }

        private bool CerrarVentana = false;

        private bool PermitirCambiarRegistroAunqueEstenVinculados = false;
        private bool AplicarCambio = false;

        private void frmCargoOperacion_Shown(object sender, EventArgs e)
        {
            ObtenerValoresDeConfiguracion();
            LlamarMetodoSegunOperacion();
            EstablecerTituloDeVentana();
            DeshabilitarControlesSegunOperacionesARealizar();
            CargarPrivilegiosDelUsuario();

            tsbGuardar.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            tsbEliminar.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            tsbActualizar.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            tsbLimpiarCampos.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            tsbRecarRegistro.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            tsbCerrarVentana.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            CargarPrivilegiosDelUsuarioPermitirCambiar();
        }

        #region "Funciones"

        private void EvaluarErrorParaMensajeAPantalla(String Error, string TipoOperacion)
        {
            if (string.IsNullOrEmpty(Error) || Error.Trim().Length == 0)
            {
                Error = string.Empty;
                MessageBox.Show(string.Format("Operación '{0}' realizada correctamente", TipoOperacion), string.Format("{0} Registro", TipoOperacion), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string cadena = "";
                switch (TipoOperacion.ToUpper())
                {
                    case "GUARDAR":
                        cadena = "Registro Guardado correctamente pero con errores: ";
                        break;
                    case "ACTUALIZAR":
                        cadena = "Registros Actualizado correctamente pero con errores: ";
                        break;
                    case "ELIMINAR":
                        cadena = "Registro Eliminado Correctamente pero con errores: ";
                        break;
                }

                cadena = string.Format("{0} {1} {1} {2}", cadena, Environment.NewLine, Error);

                MessageBox.Show(cadena, string.Format("{0} Registro", TipoOperacion), MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void CargarPrivilegiosDelUsuarioPermitirCambiar()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                ModuloInterfazUsuarioEN oRegistroEN = new ModuloInterfazUsuarioEN();
                ModuloInterfazUsuarioLN oRegistroLN = new ModuloInterfazUsuarioLN();
                                
                oRegistroEN.oUsuarioEN.IdUsuario = Program.oLoginEN.IdUsuario;
                oRegistroEN.oPrivilegioEN.oModuloInterfazEN.oInterfazEN.Nombre = Nombre_Entidad_Privilegio;

                

                if (oRegistroLN.ListadoPrivilegiosDelUsuariosPorModulo(oRegistroEN, Program.oDatosDeConexioEN))
                {
                    PermitirCambiarRegistroAunqueEstenVinculados = oRegistroLN.VerificarSiTengoAcceso("Acceso");
                }
                else
                {
                    throw new ArgumentException(oRegistroLN.Error);
                }

                oRegistroEN = null;
                oRegistroLN = null;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Privilegios de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void CargarPrivilegiosDelUsuario()
        {

            try
            {
                this.Cursor = Cursors.WaitCursor;

                ModuloInterfazUsuarioEN oRegistroEN = new ModuloInterfazUsuarioEN();
                ModuloInterfazUsuarioLN oRegistroLN = new ModuloInterfazUsuarioLN();

                oRegistroEN.oUsuarioEN.IdUsuario = Program.oLoginEN.IdUsuario;
                oRegistroEN.oPrivilegioEN.oModuloInterfazEN.oInterfazEN.Nombre = Nombre_Entidad_Privilegio;

                if (oRegistroLN.ListadoPrivilegiosDelUsuariosPorIntefaz(oRegistroEN, Program.oDatosDeConexioEN))
                {

                    tsbActualizar.Enabled = oRegistroLN.VerificarSiTengoAcceso("Actualizar");

                    if (tsbActualizar.Enabled == true)
                    {

                        DeshabilitarControlesSegunOperacionesARealizar();

                    }
                    else
                    {
                        MessageBox.Show("No tiene privilegio para modificar el registro, la ventana se cerrara", "Privilegios de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Close();
                    }


                }
                else
                {

                    throw new ArgumentException(oRegistroLN.Error);

                }

                oRegistroEN = null;
                oRegistroLN = null;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Privilegios de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void ObtenerValoresDeConfiguracion()
        {
            chkCerrarVentana.CheckState = (Properties.Settings.Default.CargoVentanaDespuesDeOperacion == true ? CheckState.Checked : CheckState.Unchecked);
            this.CerrarVentana = (Properties.Settings.Default.CargoVentanaDespuesDeOperacion == true ? true : false);
        }

        private void LlamarMetodoSegunOperacion()
        {
            switch (this.OperacionARealizar.ToUpper())
            {
                case "NUEVO":
                    Nuevo();
                    break;

                case "MODIFICAR":
                    Modificar();
                    break;

                case "ELIMINAR":
                    Eliminar();
                    break;

                case "CONSULTAR":
                    Consultar();
                    break;

                case "NUEVO A PARTIR DE REGISTRO SELECCIONADO":
                    NuevoAPartirDeRegistroSeleccionado();
                    break;

                default:
                    MessageBox.Show("La operación solicitada no está disponible.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;

            }
        }

        private void DeshabilitarControlesSegunOperacionesARealizar()
        {
            switch (this.OperacionARealizar.ToUpper())
            {
                case "NUEVO":
                    tsbGuardar.Visible = true;
                    tsbLimpiarCampos.Visible = true;
                    tsbActualizar.Visible = false;
                    tsbEliminar.Visible = false;
                    tsbRecarRegistro.Visible = false;
                    tsbAplicarCambio.Enabled = false;
                    tsbAplicarCambio.Visible = false;
                    txtIdentificador.ReadOnly = true;

                    break;

                case "MODIFICAR":
                    tsbGuardar.Visible = false;
                    tsbLimpiarCampos.Visible = true;
                    tsbActualizar.Visible = true;
                    tsbEliminar.Visible = false;
                    tsbRecarRegistro.Visible = true;
                    tsbAplicarCambio.Enabled = true;
                    tsbAplicarCambio.Visible = true;
                    txtIdentificador.ReadOnly = true;

                    break;

                case "ELIMINAR":
                    tsbGuardar.Visible = false;
                    tsbLimpiarCampos.Visible = false;
                    tsbActualizar.Visible = false;
                    tsbEliminar.Enabled = true;
                    tsbRecarRegistro.Visible = true;

                    chkCerrarVentana.CheckState = CheckState.Checked;
                    chkCerrarVentana.Enabled = false;
                    txtIdentificador.ReadOnly = true;
                    tsbAplicarCambio.Enabled = false;
                    tsbAplicarCambio.Visible = false;

                    break;

                case "CONSULTAR":
                    tsbGuardar.Visible = false;
                    tsbLimpiarCampos.Visible = false;
                    tsbActualizar.Visible = false;
                    tsbEliminar.Visible = false;
                    tsbRecarRegistro.Visible = true;
                    txtIdentificador.ReadOnly = true;
                    tsbAplicarCambio.Enabled = false;
                    tsbAplicarCambio.Visible = false;
                    chkCerrarVentana.CheckState = CheckState.Checked;
                    chkCerrarVentana.Enabled = false;

                    break;

                default:
                    MessageBox.Show("La operación solicitada no está disponible.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;

            }
        }

        private void Nuevo()
        {

        }

        private void Modificar()
        {
            txtIdentificador.Text = ValorLlavePrimariaEntidad.ToString();
            LlenarCamposDesdeBaseDatosSegunID();
        }

        private void Eliminar()
        {
            txtIdentificador.Text = ValorLlavePrimariaEntidad.ToString();
            LlenarCamposDesdeBaseDatosSegunID();
        }

        private void Consultar()
        {
            txtIdentificador.Text = ValorLlavePrimariaEntidad.ToString();
            LlenarCamposDesdeBaseDatosSegunID();
        }

        private void NuevoAPartirDeRegistroSeleccionado()
        {
            LlenarCamposDesdeBaseDatosSegunID();
        }

        private void LlenarCamposDesdeBaseDatosSegunID()
        {
            this.Cursor = Cursors.WaitCursor;

            CargoEN oRegistrosEN = new CargoEN();
            CargoLN oRegistrosLN = new CargoLN();

            oRegistrosEN.IdCargo = ValorLlavePrimariaEntidad;

            if (oRegistrosLN.ListadoPorIdentificador(oRegistrosEN, Program.oDatosDeConexioEN))
            {
                if (oRegistrosLN.TraerDatos().Rows.Count > 0)
                {
                    DataRow Fila = oRegistrosLN.TraerDatos().Rows[0];
                    txtNombre.Text = Fila["Cargo"].ToString();
                    oRegistrosEN = null;
                    oRegistrosLN = null;

                }
                else
                {
                    string Mensaje;
                    Mensaje = string.Format("El registro solicitado de {0} no ha sido encontrado."
                                            + "\n\r-----Causas---- "
                                            + "\n\r1. Este registro pudo haber sido eliminado por otro usuario."
                                            + "\n\r2. El listado no está actualizado.", Nombre_Entidad);

                    MessageBox.Show(Mensaje, "Listado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    oRegistrosEN = null;
                    oRegistrosLN = null;

                    this.Close();
                }

            }
            else
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(oRegistrosLN.Error, "Listado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                oRegistrosEN = null;
                oRegistrosLN = null;
            }

            this.Cursor = Cursors.Default;
        }

        private void EstablecerTituloDeVentana()
        {
            this.Text = string.Format("{0} - {1}", this.Nombre_Entidad, this.OperacionARealizar.ToUpper());
            
        }

        private void LimpiarCampos()
        {
            //txtIdentificador.Text = string.Empty;
            txtNombre.Text = string.Empty;

        }

        private void GuardarValoresDeConfiguracion()
        {
            Properties.Settings.Default.CargoVentanaDespuesDeOperacion = (chkCerrarVentana.CheckState == CheckState.Checked ? true : false);
            Properties.Settings.Default.Save();
        }

        private void LimpiarEP()
        {
            EP.Clear();
        }

        private bool LosDatosIngresadosSonCorrectos()
        {
            LimpiarEP();

            if (Controles.IsNullOEmptyElControl(txtNombre))
            {
                EP.SetError(txtNombre, "Este campo no puede quedar vacío");
                txtNombre.Focus();
                return false;
            }

            return true;

        }

        private CargoEN InformacionDelRegistro()
        {

            CargoEN oRegistroEN = new CargoEN();

            oRegistroEN.IdCargo = Convert.ToInt32((txtIdentificador.Text.Length > 0 ? txtIdentificador.Text : "0"));
            oRegistroEN.Cargo = txtNombre.Text.Trim();

            //partes generales.            
            oRegistroEN.oLoginEN = Program.oLoginEN;
            oRegistroEN.IdUsuarioDeCreacion = Program.oLoginEN.IdUsuario;
            oRegistroEN.IdUsuarioDeModificacion = Program.oLoginEN.IdUsuario;
            oRegistroEN.FechaDeCreacion = System.DateTime.Now;
            oRegistroEN.FechaDeModificacion = System.DateTime.Now;
            return oRegistroEN;

        }

        #endregion

        private void tsbGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (LosDatosIngresadosSonCorrectos())
                {

                    CargoEN oRegistroEN = InformacionDelRegistro();
                    CargoLN oRegistroLN = new CargoLN();

                    if (oRegistroLN.ValidarRegistroDuplicado(oRegistroEN, Program.oDatosDeConexioEN, "AGREGAR"))
                    {

                        MessageBox.Show(oRegistroLN.Error, "Guardar información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }

                    if (oRegistroLN.Agregar(oRegistroEN, Program.oDatosDeConexioEN))
                    {

                        txtIdentificador.Text = oRegistroEN.IdCargo.ToString();
                        ValorLlavePrimariaEntidad = oRegistroEN.IdCargo;

                        EvaluarErrorParaMensajeAPantalla(oRegistroLN.Error, "GUARDAR");

                        oRegistroEN = null;
                        oRegistroLN = null;

                        this.Cursor = Cursors.Default;

                        if (CerrarVentana == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            OperacionARealizar = "Modificar";
                            ObtenerValoresDeConfiguracion();
                            LlamarMetodoSegunOperacion();
                            EstablecerTituloDeVentana();
                            DeshabilitarControlesSegunOperacionesARealizar();
                        }

                    }
                    else
                    {
                        throw new ArgumentException(oRegistroLN.Error);
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Guardar la información del registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (LosDatosIngresadosSonCorrectos())
                {
                    if (txtIdentificador.Text.Length == 0 || txtIdentificador.Text == "0")
                    {
                        MessageBox.Show("No se puede continuar. Ha ocurrido un error y el registro no ha sido cargado correctamente.", OperacionARealizar, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }


                    if (MessageBox.Show("¿Está seguro que desea aplicar los cambios al registro seleccionado?", "Actualizar la Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3) == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }

                    CargoEN oRegistroEN = InformacionDelRegistro();
                    CargoLN oRegistroLN = new CargoLN();

                    if (oRegistroLN.ValidarSiElRegistroEstaVinculado(oRegistroEN, Program.oDatosDeConexioEN, "ACTUALIZAR"))
                    {
                        if (PermitirCambiarRegistroAunqueEstenVinculados == true && AplicarCambio == true)
                        {
                            if (MessageBox.Show(string.Format("Está seguro que desea actualizar los cambios en el registro seleccionado ya que este se encuentra asociado a otras Entidades de manera interna? {0} {1}", Environment.NewLine, oRegistroLN.Error), "Confirmación de Actualización", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.OK)
                            {
                                this.Cursor = Cursors.Default;
                                return;
                            }
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            MessageBox.Show(oRegistroLN.Error, "Actualizar la información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    if (oRegistroLN.ValidarRegistroDuplicado(oRegistroEN, Program.oDatosDeConexioEN, "ACTUALIZAR"))
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show(oRegistroLN.Error, "Actualizar la información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }

                    if (oRegistroLN.Actualizar(oRegistroEN, Program.oDatosDeConexioEN))
                    {

                        txtIdentificador.Text = oRegistroEN.IdCargo.ToString();
                        ValorLlavePrimariaEntidad = oRegistroEN.IdCargo;

                        EvaluarErrorParaMensajeAPantalla(oRegistroLN.Error, "ACTUALIZAR");

                        oRegistroEN = null;
                        oRegistroLN = null;

                        this.Cursor = Cursors.Default;

                        if (CerrarVentana == true)
                        {
                            this.Close();
                        }


                    }
                    else
                    {
                        throw new ArgumentException(oRegistroLN.Error);
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Actualizar la información del registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (LosDatosIngresadosSonCorrectos())
                {
                    if (txtIdentificador.Text.Length == 0 || txtIdentificador.Text == "0")
                    {
                        MessageBox.Show("No se puede continuar. Ha ocurrido un error y el registro no ha sido cargado correctamente.", OperacionARealizar, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }


                    if (MessageBox.Show("¿Está seguro que desea eliminar el registro?", "Eliminar la Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3) == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }

                    CargoEN oRegistroEN = InformacionDelRegistro();
                    CargoLN oRegistroLN = new CargoLN();

                    if (oRegistroLN.ValidarSiElRegistroEstaVinculado(oRegistroEN, Program.oDatosDeConexioEN, "ELIMINAR"))
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show(oRegistroLN.Error, this.OperacionARealizar, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    if (oRegistroLN.Eliminar(oRegistroEN, Program.oDatosDeConexioEN))
                    {

                        txtIdentificador.Text = oRegistroEN.IdCargo.ToString();
                        ValorLlavePrimariaEntidad = oRegistroEN.IdCargo;

                        EvaluarErrorParaMensajeAPantalla(oRegistroLN.Error, "ELIMINAR");

                        oRegistroEN = null;
                        oRegistroLN = null;

                        this.Cursor = Cursors.Default;

                        if (CerrarVentana == true)
                        {
                            this.Close();
                        }


                    }
                    else
                    {
                        throw new ArgumentException(oRegistroLN.Error);
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eliminar la información del registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void tsbLimpiarCampos_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void tsbAplicarCambio_Click(object sender, EventArgs e)
        {
            tsbAplicarCambio.Checked = !tsbAplicarCambio.Checked;
            AplicarCambio = tsbAplicarCambio.Checked;
            if (tsbAplicarCambio.Checked == true)
            {
                tsbAplicarCambio.Image = Properties.Resources.unchecked24x24;
            }
            else
            {
                tsbAplicarCambio.Image = Properties.Resources.checked24x24;
            }
        }

        private void tsbRecarRegistro_Click(object sender, EventArgs e)
        {
            LlenarCamposDesdeBaseDatosSegunID();
        }

        private void tsbCerrarVentana_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkCerrarVentana_CheckedChanged(object sender, EventArgs e)
        {
            this.CerrarVentana = (chkCerrarVentana.CheckState == CheckState.Checked ? true : false);
        }

        private void frmCargoOperacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            GuardarValoresDeConfiguracion();
        }
    }
}
