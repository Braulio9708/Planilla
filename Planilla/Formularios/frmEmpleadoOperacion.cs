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
    public partial class frmEmpleadoOperacion : Form
    {
        public frmEmpleadoOperacion()
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

        private void frmEmpleadoOperacion_Shown(object sender, EventArgs e)
        {
            LlenarInformacionDelMunicipio();
            LlenarInformacionDelAreaLaboral();
            LlenarInformacionDelCargo();
            OctenerValoresDeConfiguracion();
            LlenarMetodoSegunOperacion();
            EstableserTituloDeLaVentana();
            DesavilitarControlesSegunOperacion();
            CargarPrivilegiosDeUsuarios();

            tsbGuardar.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            tsbEliminar.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            tsbActualizar.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            tsbNuevo.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            tsbRecargar.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            tsbSalir.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;

            CargarPrivilegiosDelUsuarioPermitirCambiar();
        }

        #region "Funciones del programador"
        private void EvaluarErrorParaMensageEnPantalla(String Error, string TipoDeOperacion)
        {
            if(string.IsNullOrEmpty(Error) || Error.Trim().Length == 0)
            {
                Error = string.Empty;
                MessageBox.Show(string.Format("Operación '{0}' realizada correctamente", TipoDeOperacion), string.Format("{0} Registro", TipoDeOperacion), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string Cadena = "";
                switch (TipoDeOperacion.ToUpper())
                {
                    case "GUARDAR":
                        Cadena = "Registro guardado correctamente pero con errores: ";
                        break;
                    case "ACTUALIZAR":
                        Cadena = "Registro actualizado correctamente pero con errores: ";
                        break;
                    case "Eliminar":
                        Cadena = "Registro eliminado correctamente pero con errores: ";
                        break;
                }
                Cadena = string.Format("{0} {1} {1} {2}", Cadena, Environment.NewLine, Error);
                MessageBox.Show(Cadena, string.Format("{0} Registro", TipoDeOperacion), MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                if (oRegistroLN.ListadoPrivilegiosDelUsuariosPorIntefaz(oRegistroEN, Program.oDatosDeConexioEN))
                {
                    PermitirCambiarRegistroAunqueEstenVinculados = oRegistroLN.VerificarSiTengoAcceso("Permitir modificar registros vinculados");
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

        private void CargarPrivilegiosDeUsuarios()
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

                        DesavilitarControlesSegunOperacion();

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

        private void OctenerValoresDeConfiguracion()
        {
            chkCerrarVentana.CheckState = (Properties.Settings.Default.CargoVentanaDespuesDeOperacion == true ? CheckState.Checked : CheckState.Unchecked);
            this.CerrarVentana = (Properties.Settings.Default.CargoVentanaDespuesDeOperacion == true ? true : false);
        }

        private void DesavilitarControlesSegunOperacion()
        {
            switch (this.OperacionARealizar.ToUpper())
            {
                case "NUEVO":
                    tsbGuardar.Enabled = true;
                    tsbNuevo.Enabled = true;
                    tsbActualizar.Enabled = false;
                    tsbEliminar.Enabled = false;
                    tsbRecargar.Enabled = false;

                    txtIdentificador.ReadOnly = true;
                    txtNombre.Text = string.Empty;
                    cmbAreaLaboral.SelectedIndex = -1;
                    cmbCargo.SelectedIndex = -1;
                    cmbMunicipio.SelectedIndex = -1;

                    break;

                case "MODIFICAR":
                    tsbGuardar.Enabled = false;
                    tsbNuevo.Enabled = true;
                    tsbActualizar.Enabled = true;
                    tsbEliminar.Enabled = false;
                    tsbRecargar.Enabled = true;

                    txtIdentificador.ReadOnly = true;

                    break;

                case "ELIMINAR":
                    tsbGuardar.Enabled = false;
                    tsbNuevo.Enabled = false;
                    tsbActualizar.Enabled = false;
                    tsbEliminar.Enabled = true;
                    tsbRecargar.Enabled = false;

                    chkCerrarVentana.CheckState = CheckState.Checked;
                    chkCerrarVentana.Enabled = false;
                    txtIdentificador.ReadOnly = true;

                    txtNombre.ReadOnly = true;
                    txtApellidos.ReadOnly = true;
                    txtCedula.ReadOnly = true;
                    txtDireccion.ReadOnly = true;
                    txtTelefono.ReadOnly = true;
                    txtCelular.ReadOnly = true;
                    txtCorreoElectronico.ReadOnly = true;
                    txtNoINSS.ReadOnly = true;
                    cmbAreaLaboral.Enabled = false;
                    cmbCargo.Enabled = false;
                    cmbMunicipio.Enabled = false;

                    break;

                case "CONSULTAR":
                    tsbGuardar.Enabled = false;
                    tsbNuevo.Enabled = false;
                    tsbActualizar.Enabled = false;
                    tsbEliminar.Enabled = false;
                    tsbRecargar.Enabled = false;
                    txtIdentificador.ReadOnly = true;

                    chkCerrarVentana.CheckState = CheckState.Checked;
                    chkCerrarVentana.Enabled = false;
                    txtNombre.ReadOnly = true;

                    cmbAreaLaboral.Enabled = false;
                    cmbCargo.Enabled = false;
                    cmbMunicipio.Enabled = false;

                    break;

                default:
                    MessageBox.Show("La operación solicitada no está disponible.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;

            }
        }

        private void LlenarMetodoSegunOperacion()
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

        private void Nuevo()
        {

        }

        private void Modificar()
        {
            txtIdentificador.Text = ValorLlavePrimariaEntidad.ToString();
            LlenarCamposSegunBaseDeDatosSegunID();
        }

        private void Eliminar()
        {
            txtIdentificador.Text = ValorLlavePrimariaEntidad.ToString();
            LlenarCamposSegunBaseDeDatosSegunID();
        }

        private void Consultar()
        {
            txtIdentificador.Text = ValorLlavePrimariaEntidad.ToString();
            LlenarCamposSegunBaseDeDatosSegunID();
        }

        private void NuevoAPartirDeRegistroSeleccionado()
        {
            LlenarCamposSegunBaseDeDatosSegunID();
        }

        private void LlenarCamposSegunBaseDeDatosSegunID()
        {
            this.Cursor = Cursors.WaitCursor;

            EmpleadoEN oRegistrosEN = new EmpleadoEN();
            EmpleadoLN oRegistrosLN = new EmpleadoLN();

            oRegistrosEN.IdEmpleado = ValorLlavePrimariaEntidad;
            
            if (oRegistrosLN.ListadoPorIdentificador(oRegistrosEN, Program.oDatosDeConexioEN))
            {
                
                if (oRegistrosLN.TraerDatos().Rows.Count > 0)
                {

                    DataRow Fila = oRegistrosLN.TraerDatos().Rows[0];
                    txtNombre.Text = Fila["Nombre"].ToString();
                    txtApellidos.Text = Fila["Apellidos"].ToString();
                    txtCedula.Text = Fila["Cedula"].ToString();
                    txtDireccion.Text = Fila["Direccion"].ToString();
                    txtTelefono.Text = Fila["Telefono"].ToString();
                    txtCelular.Text = Fila["Celular"].ToString();
                    txtCorreoElectronico.Text = Fila["Correo"].ToString();
                    txtNoINSS.Text = Fila["NoINSS"].ToString();

                    cmbAreaLaboral.SelectedValue = Convert.ToInt32(Fila["IdAreaLaboral"].ToString());
                    cmbCargo.SelectedValue = Convert.ToInt32(Fila["IdCargo"].ToString());
                    cmbMunicipio.SelectedValue = Convert.ToInt32(Fila["IdCiudad"].ToString());
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

        private void EstableserTituloDeLaVentana()
        {
            this.Text = string.Format("{0} - {1}", this.Nombre_Entidad, this.OperacionARealizar.ToUpper());
            this.InformacionEntidadOperacion.Text = this.Nombre_Entidad + " - " + this.OperacionARealizar;
        }

        private void LimpiarCampos()
        {
            txtIdentificador.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellidos.Text = string.Empty;
            txtCedula.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtCelular.Text = string.Empty;
            txtCorreoElectronico.Text = string.Empty;
            txtNoINSS.Text = string.Empty;

            cmbAreaLaboral.SelectedIndex = -1;
            cmbCargo.SelectedIndex = -1;
            cmbMunicipio.SelectedIndex = -1;
        }

        private void GuardarValoresDeConfiguracion()
        {
            Properties.Settings.Default.UsuarioVentanaDespuesDeOperacion = (chkCerrarVentana.CheckState == CheckState.Checked ? true : false);
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

        private EmpleadoEN InformacionDelRegistro()
        {
            EmpleadoEN oRegistroEN = new EmpleadoEN();

            oRegistroEN.IdEmpleado = Convert.ToInt32((txtIdentificador.Text.Length > 0 ? txtIdentificador.Text : "0"));
            oRegistroEN.Nombre = txtNombre.Text.Trim();
            oRegistroEN.Apellidos = txtApellidos.Text.Trim();
            oRegistroEN.Cedula = txtCedula.Text.Trim();
            oRegistroEN.Direccion = txtDireccion.Text.Trim();
            oRegistroEN.Telefono = txtTelefono.Text.Trim();
            oRegistroEN.Celular = txtCelular.Text.Trim();
            oRegistroEN.Correo = txtCorreoElectronico.Text.Trim();
            oRegistroEN.NoINSS = txtNoINSS.Text.Trim();

            oRegistroEN.oAreaLaboralEN.IdAreaLaboral = Convert.ToInt32(cmbAreaLaboral.SelectedValue);
            oRegistroEN.oAreaLaboralEN.Area = cmbAreaLaboral.Text.Trim();
            oRegistroEN.oCargoEN.IdCargo = Convert.ToInt32(cmbCargo.SelectedValue);
            oRegistroEN.oCargoEN.Cargo = cmbCargo.Text.Trim();
            oRegistroEN.oCiudadEN.IdCiudad = Convert.ToInt32(cmbMunicipio.SelectedValue);
            oRegistroEN.oCiudadEN.Ciudad = cmbMunicipio.Text.Trim();
            
            return oRegistroEN;
        }

        private void LlenarInformacionDelCargo()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                CargoEN oRegistroEN = new CargoEN();
                CargoLN oRegistroLN = new CargoLN();
                oRegistroEN.Where = "";
                oRegistroEN.OrderBy = "";

                if(oRegistroLN.Listado(oRegistroEN, Program.oDatosDeConexioEN))
                {
                    cmbCargo.DataSource = oRegistroLN.TraerDatos();
                    cmbCargo.DisplayMember = "Cargo";
                    cmbCargo.ValueMember = "IdCargo";
                    cmbCargo.SelectedIndex = -1;
                }
                else { throw new ArgumentException(oRegistroLN.Error); }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Información de los tipos de cuentas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void LlenarInformacionDelAreaLaboral()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                AreaLaboralEN oRegistroEN = new AreaLaboralEN();
                AreaLaboralLN oRegistroLN = new AreaLaboralLN();
                oRegistroEN.Where = "";
                oRegistroEN.OrderBy = "";

                if (oRegistroLN.Listado(oRegistroEN, Program.oDatosDeConexioEN))
                {
                    cmbAreaLaboral.DataSource = oRegistroLN.TraerDatos();
                    cmbAreaLaboral.DisplayMember = "Area Laboral";
                    cmbAreaLaboral.ValueMember = "IdAreaLaboral";
                    cmbAreaLaboral.SelectedIndex = -1;
                }
                else { throw new ArgumentException(oRegistroLN.Error); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Información de los tipos de cuentas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void LlenarInformacionDelMunicipio()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                CiudadEN oRegistroEN = new CiudadEN();
                CiudadLN oRegistroLN = new CiudadLN();
                oRegistroEN.Where = "";
                oRegistroEN.OrderBy = "";

                if (oRegistroLN.Listado(oRegistroEN, Program.oDatosDeConexioEN))
                {
                    cmbMunicipio.DataSource = oRegistroLN.TraerDatos();
                    cmbMunicipio.DisplayMember = "Ciudad";
                    cmbMunicipio.ValueMember = "IdCiudad";
                    cmbMunicipio.SelectedIndex = -1;
                }
                else { throw new ArgumentException(oRegistroLN.Error); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Información de los tipos de cuentas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
                
        #endregion

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void chkCerrarVentana_CheckedChanged(object sender, EventArgs e)
        {
            this.CerrarVentana = (chkCerrarVentana.CheckState == CheckState.Checked ? true : false);
        }

        private void frmEmpleadoOperacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            GuardarValoresDeConfiguracion();
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

                    EmpleadoEN oRegistroEN = InformacionDelRegistro();
                    EmpleadoLN oRegistroLN = new EmpleadoLN();

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

                    if (oRegistroLN.ValidarRegistroDuplicado(oRegistroEN, Program.oDatosDeConexion, "ACTUALIZAR"))
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show(oRegistroLN.Error, "Actualizar la información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }

                    if (oRegistroLN.Actualizar(oRegistroEN, Program.oDatosDeConexioEN))
                    {

                        txtIdentificador.Text = oRegistroEN.IdEmpleado.ToString();
                        ValorLlavePrimariaEntidad = oRegistroEN.IdEmpleado;

                        EvaluarErrorParaMensageEnPantalla(oRegistroLN.Error, "Actualizar");

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

                    EmpleadoEN oRegistroEN = InformacionDelRegistro();
                    EmpleadoLN oRegistroLN = new EmpleadoLN();

                    if (oRegistroLN.ValidarSiElRegistroEstaVinculado(oRegistroEN, Program.oDatosDeConexioEN, "ELIMINAR"))
                    {
                        MessageBox.Show("Buscar Error");
                        this.Cursor = Cursors.Default;
                        MessageBox.Show(oRegistroLN.Error, this.OperacionARealizar, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    if (oRegistroLN.Eliminar(oRegistroEN, Program.oDatosDeConexioEN))
                    {
                        
                        txtIdentificador.Text = oRegistroEN.IdEmpleado.ToString();
                        ValorLlavePrimariaEntidad = oRegistroEN.IdEmpleado;

                        EvaluarErrorParaMensageEnPantalla(oRegistroLN.Error, "Eliminar");

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

        private void tsbGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                
                if (LosDatosIngresadosSonCorrectos())
                {
                    EmpleadoEN oRegistroEN = InformacionDelRegistro();
                    EmpleadoLN oRegistroLN = new EmpleadoLN();

                    if (oRegistroLN.ValidarRegistroDuplicado(oRegistroEN, Program.oDatosDeConexioEN, "AGREGAR"))
                    {
                        
                        MessageBox.Show(oRegistroLN.Error, "Guardar información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }

                    

                    if (oRegistroLN.Agregar(oRegistroEN, Program.oDatosDeConexioEN))
                    {

                        txtIdentificador.Text = oRegistroEN.IdEmpleado.ToString();
                        ValorLlavePrimariaEntidad = oRegistroEN.IdEmpleado;

                        EvaluarErrorParaMensageEnPantalla(oRegistroLN.Error, "Guardar");

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
                            OctenerValoresDeConfiguracion();
                            LlenarMetodoSegunOperacion();
                            EstableserTituloDeLaVentana();
                            DesavilitarControlesSegunOperacion();
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

        
    }
}
