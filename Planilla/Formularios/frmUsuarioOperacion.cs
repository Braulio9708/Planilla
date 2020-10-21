﻿using System;
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
    public partial class frmUsuarioOperacion : Form
    {
        public frmUsuarioOperacion()
        {
            InitializeComponent();
        }

        public string OperacionARealizar { set; get; }
        public string Nombre_Entidad_Privilegio { set; get; }
        public string Nombre_Entidad { set; get; }
        public int ValorLlavePrimariaEntidad { set; get; }

        private bool CerrarVentana = false;

        private void frmUsuarioOperacion_Shown(object sender, EventArgs e)
        {
            ObtenerValoresDeConfiguracion();
            LLenarInformacionDelTipoDeCuenta();
            LLenarInformacionDelModulo();
            LLenarInformacionDeLaInterfaz();
            LlamarMetodoSegunOperacion();
            EstablecerTituloDeVentana();
            DeshabilitarControlesSegunOperacionesARealizar();

        }

        #region "Funciones"

        private void LLenarInformacionDelTipoDeCuenta()
        {

            try
            {
                this.Cursor = Cursors.WaitCursor;

                RolEN oRegistroEN = new RolEN();
                RolLN oRegistroLN = new RolLN();
                oRegistroEN.Where = "";
                oRegistroEN.OrderBy = "";

                if (oRegistroLN.ListadoParaCombos(oRegistroEN, Program.oDatosDeConexioEN))
                {
                    cmbTipoDeCuenta.DataSource = oRegistroLN.TraerDatos();
                    cmbTipoDeCuenta.DisplayMember = "Nombre";
                    cmbTipoDeCuenta.ValueMember = "IdRol";
                    cmbTipoDeCuenta.SelectedIndex = -1;

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

        private void TraerPrivilegiosParaElUsuarioApartirDelRol()
        {
            try
            {

                if (cmbTipoDeCuenta.SelectedIndex == -1) return;

                this.Cursor = Cursors.WaitCursor;

                ModuloInterfazRolEN oRegistroEN = new ModuloInterfazRolEN();
                ModuloInterfazRolLN oRegistroLN = new ModuloInterfazRolLN();

                oRegistroEN.oRolEN.IdRol = Convert.ToInt32(cmbTipoDeCuenta.SelectedValue);

                if (oRegistroLN.ListadoDePrivilegiosParaElUsuario(oRegistroEN, Program.oDatosDeConexioEN))
                {

                    dgvLista.DataSource = oRegistroLN.PrivilegiosDelRolDT();
                    FormatearDGV();
                    tstNumeroDeRegistro.Text = string.Format("No de registros: {0} ", oRegistroLN.TotalRegistros());

                }
                else
                {
                    throw new ArgumentException(oRegistroLN.Error);
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Traer información de los privilegios del usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void TraerPrivilegiosDelUsuario()
        {

            try
            {

                this.Cursor = Cursors.WaitCursor;

                ModuloInterfazUsuarioEN oRegistroEN = new ModuloInterfazUsuarioEN();
                ModuloInterfazUsuarioLN oRegistroLN = new ModuloInterfazUsuarioLN();

                oRegistroEN.oUsuarioEN.IdUsuario = ValorLlavePrimariaEntidad;

                if (oRegistroLN.ListadoPrivilegiosDelUsuario(oRegistroEN, Program.oDatosDeConexioEN))
                {

                    dgvLista.DataSource = oRegistroLN.PrivilegiosDelUsuarioEnDT();
                    FormatearDGV();
                    tstNumeroDeRegistro.Text = string.Format("No de registros: {0} ", oRegistroLN.TotalRegistros());

                }
                else
                {
                    throw new ArgumentException(oRegistroLN.Error);
                }

                if (OperacionARealizar.ToUpper() == "Eliminar".ToUpper())
                {
                    MarcarParaELiminar();
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Traer información de los privilegios del usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void MarcarParaELiminar()
        {
            try
            {
                if (dgvLista.RowCount > 0)
                {
                    tsbSeleccionar.Enabled = false;
                    foreach (DataGridViewRow fila in dgvLista.Rows)
                    {
                        fila.Cells["Marcar"].Value = true;
                        fila.Cells["Actualizar"].Value = false;
                        fila.Cells["Eliminar"].Value = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Marcar registros para eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatearDGV()
        {
            try
            {
                this.dgvLista.AllowUserToResizeRows = false;
                this.dgvLista.AllowUserToAddRows = false;
                this.dgvLista.AllowUserToDeleteRows = false;
                this.dgvLista.DefaultCellStyle.BackColor = Color.White;

                this.dgvLista.MultiSelect = true;
                this.dgvLista.RowHeadersVisible = true;

                this.dgvLista.DefaultCellStyle.Font = new Font("Segoe UI", 8);
                this.dgvLista.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8);
                this.dgvLista.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
                this.dgvLista.BackgroundColor = System.Drawing.SystemColors.Window;
                this.dgvLista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

                string OcultarColumnas = "Eliminar,IdPrivilegio,Acceso,Actualizar";

                OcultarColumnasEnElDGV(OcultarColumnas);

                FormatearColumnasDelDGV();

                int Id;
                if (string.IsNullOrEmpty(txtIdentificador.Text) || txtIdentificador.Text.Trim().Length == 0)
                {
                    Id = 0;
                }
                else
                {
                    Id = Convert.ToInt32(txtIdentificador.Text);
                }

                if (OperacionARealizar.ToUpper() == "ELIMINAR".ToUpper() || OperacionARealizar.ToUpper() == "CONSULTAR".ToUpper() || Id == 1)
                {
                    dgvLista.Columns["Marcar"].ReadOnly = true;
                }

                this.dgvLista.RowHeadersWidth = 25;

                this.dgvLista.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvLista.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                this.dgvLista.StandardTab = true;
                this.dgvLista.ReadOnly = false;
                this.dgvLista.CellBorderStyle = DataGridViewCellBorderStyle.Raised;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FormatoDGV", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatearColumnasDelDGV()
        {
            if (dgvLista.Columns.Count > 0)
            {

                foreach (DataGridViewColumn c1 in dgvLista.Columns)
                {
                    if (c1.Visible == true)
                    {
                        if (c1.Name.Trim().ToUpper() != "Seleccionar".ToUpper())
                        {
                            FormatoDGV oFormato = new FormatoDGV(c1.Name.Trim());
                            if (oFormato.ValorEncontrado == false)
                            {
                                oFormato = new FormatoDGV(c1.Name.Trim(), "Usuario");
                            }

                            if (oFormato != null)
                            {
                                c1.HeaderText = oFormato.Descripcion;
                                c1.Width = oFormato.Tamano;
                                c1.DefaultCellStyle.Alignment = oFormato.Alineacion;
                                c1.HeaderCell.Style.Alignment = oFormato.AlineacionDelEncabezado;
                                c1.ReadOnly = oFormato.SoloLectura;
                            }
                        }
                    }
                }

            }
        }

        private void OcultarColumnasEnElDGV(String ColumnasDelDGV)
        {
            if (dgvLista.Columns.Count > 0)
            {
                String[] ArrayColumnasDGV = ColumnasDelDGV.Split(',');
                foreach (String c in ArrayColumnasDGV)
                {

                    foreach (DataGridViewColumn c1 in dgvLista.Columns)
                    {
                        if (c1.Name.Trim().ToUpper() == c.Trim().ToUpper())
                        {
                            c1.Visible = false;
                        }
                    }

                }
            }
        }

        private void LLenarInformacionDeLaInterfaz()
        {

            try
            {
                this.Cursor = Cursors.WaitCursor;

                InterfazEN oRegistroEN = new InterfazEN();
                InterfazLN oRegistroLN = new InterfazLN();
                oRegistroEN.Where = "";
                oRegistroEN.OrderBy = "";

                if (oRegistroLN.ListadoParaCombos(oRegistroEN, Program.oDatosDeConexioEN))
                {
                    cmbInterfaz.DataSource = oRegistroLN.TraerDatos();
                    cmbInterfaz.DisplayMember = "Nombre";
                    cmbInterfaz.ValueMember = "IdInterfaz";                    
                    cmbInterfaz.SelectedIndex = -1;

                }
                else { throw new ArgumentException(oRegistroLN.Error); }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Información de la interfaz", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }


        }

        private void LLenarInformacionDelModulo()
        {

            try
            {
                this.Cursor = Cursors.WaitCursor;

                ModuloEN oRegistroEN = new ModuloEN();
                ModuloLN oRegistroLN = new ModuloLN();
                oRegistroEN.Where = "";
                oRegistroEN.OrderBy = "";

                if (oRegistroLN.ListadoParaCombos(oRegistroEN, Program.oDatosDeConexioEN))
                {
                    cmbModulo.DataSource = oRegistroLN.TraerDatos();
                    cmbModulo.DisplayMember = "Nombre";
                    cmbModulo.ValueMember = "IdModulo";
                    cmbModulo.SelectedIndex = -1;

                }
                else { throw new ArgumentException(oRegistroLN.Error); }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Información del modulo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }


        }

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
            chkCerrarVentana.CheckState = (Properties.Settings.Default.UsuarioVentanaDespuesDeOperacion == true ? CheckState.Checked : CheckState.Unchecked);
            this.CerrarVentana = (Properties.Settings.Default.UsuarioVentanaDespuesDeOperacion == true ? true : false);
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
                    tsbGuardar.Enabled = true;
                    tsbNuevo.Enabled = true;
                    tsbActualizar.Enabled = false;
                    tsbEliminar.Enabled = false;
                    tsbRecargar.Enabled = false;

                    txtIdentificador.ReadOnly = true;
                    txtNombreUsuario.Text = string.Empty;
                    cmbTipoDeCuenta.SelectedIndex = -1;

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

                    txtNombreUsuario.ReadOnly = true;
                    cmbTipoDeCuenta.Enabled = false;

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
                    txtNombreUsuario.ReadOnly = true;

                    cmbTipoDeCuenta.Enabled = false;

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

            UsuarioEN oRegistrosEN = new UsuarioEN();
            UsuarioLN oRegistrosLN = new UsuarioLN();

            oRegistrosEN.IdUsuario = ValorLlavePrimariaEntidad;

            if (oRegistrosLN.ListadoPorIdentificador(oRegistrosEN, Program.oDatosDeConexioEN))
            {
                if (oRegistrosLN.TraerDatos().Rows.Count > 0)
                {

                    DataRow Fila = oRegistrosLN.TraerDatos().Rows[0];
                    txtNombreUsuario.Text = Fila["Usuario"].ToString();
                    cmbTipoDeCuenta.SelectedValue = Convert.ToInt32(Fila["IdRol"].ToString());
                    txtNombreSecion.Text = Fila["Login"].ToString();                    
                    //txtContrasena.Text = CifrarCadenas.DesencriptarCadena(Fila["Contrasena"].ToString());
                    //txtConfirmar.Text = CifrarCadenas.DesencriptarCadena(Fila["Contrasena"].ToString());
                    txtCorreoElectronico.Text = Fila["Email"].ToString();
                    cmbEstado.Text = Fila["Estado"].ToString();

                    TraerPrivilegiosDelUsuario();

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
            this.Text = "Administración de " + this.Nombre_Entidad + " - " + this.OperacionARealizar.ToUpper();
            this.InformacionEntidadOperacion.Text = this.Nombre_Entidad + " - " + this.OperacionARealizar;
        }

        private void LimpiarCampos()
        {
            txtIdentificador.Text = string.Empty;
            txtNombreUsuario.Text = string.Empty;
            txtNombreSecion.Text = string.Empty;
            
            txtCorreoElectronico.Text = string.Empty;
            cmbTipoDeCuenta.SelectedIndex = -1;
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

            if (Controles.IsNullOEmptyElControl(txtNombreUsuario))
            {
                EP.SetError(txtNombreUsuario, "Este campo no puede quedar vacío");
                txtNombreUsuario.Focus();
                return false;
            }


            if (Controles.IsNullOEmptyElControl(cmbTipoDeCuenta))
            {
                EP.SetError(cmbTipoDeCuenta, "Se debe seleccionar un valor");
                cmbTipoDeCuenta.Focus();
                return false;
            }


            return true;

        }

        private UsuarioEN InformacionDelRegistro()
        {

            UsuarioEN oRegistroEN = new UsuarioEN();

            oRegistroEN.IdUsuario = Convert.ToInt32((txtIdentificador.Text.Length > 0 ? txtIdentificador.Text : "0"));
            oRegistroEN.Nombre = txtNombreUsuario.Text.Trim();
            oRegistroEN.Login = txtNombreSecion.Text.Trim();            
            oRegistroEN.Contrasena = CifrarCadenas.EncriptarCadena(txtContrasena.Text.Trim());
            oRegistroEN.Email = txtCorreoElectronico.Text.Trim();
            oRegistroEN.Estado = cmbEstado.Text;
            oRegistroEN.oRolEN.IdRol = Convert.ToInt32(cmbTipoDeCuenta.SelectedValue);
            oRegistroEN.oRolEN.Nombre = cmbTipoDeCuenta.Text.Trim();

            //partes generales.            
            oRegistroEN.oLoginEN = Program.oLoginEN;
            oRegistroEN.IdUsuarioDeCreacion = Program.oLoginEN.IdUsuario;
            oRegistroEN.IdUsuarioDeModificacion = Program.oLoginEN.IdUsuario;
            oRegistroEN.FechaDeCreacion = System.DateTime.Now;
            oRegistroEN.FechaDeModificacion = System.DateTime.Now;

            return oRegistroEN;

        }

        private bool EvaluarDataGridView(DataGridView dgv)
        {

            if (OperacionARealizar.Trim().ToUpper() == "MODIFICAR".ToUpper())
            {
                if (dgv.Rows.Count > 0)
                {

                    List<DataGridViewRow> rows = (from item in dgv.Rows.Cast<DataGridViewRow>()
                                                  let Actualizar = Convert.ToBoolean(item.Cells["Actualizar"].Value ?? false)
                                                  where Actualizar.Equals(true)
                                                  select item).ToList<DataGridViewRow>();

                    if (rows.Count > 0)
                    {

                        return true;
                    }
                    else
                    {

                        List<DataGridViewRow> rows1 = (from item in dgv.Rows.Cast<DataGridViewRow>()
                                                       let Eliminar = Convert.ToBoolean(item.Cells["Eliminar"].Value ?? false)
                                                       where Eliminar.Equals(true)
                                                       select item).ToList<DataGridViewRow>();

                        if (rows1.Count > 0)
                        {
                            return true;
                        }

                        return false;

                    }


                }
                else
                {

                    return false;
                }

            }
            else
            {
                return true;
            }
        }

        private int TotalDeFilasMarcadas(String Columna)
        {
            try
            {
                int numero = 0;
                foreach (DataGridViewRow Fila in dgvLista.Rows)
                {
                    if (Convert.ToBoolean(Fila.Cells[Columna].Value) == true)
                    {
                        numero++;
                    }
                }
                return (numero);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al contabilizar las columnas (" + Columna + ") marcadas. \n" + ex.Message, "Total de filas marcadas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (0);
            }
        }

        private bool LosDatosIngresadosEnGrillaSonCorrectosProductosDistribucion(DataGridViewRow Fila)
        {
            return true;
        }

        #region Barra de Progreso

        private void InicializarBarraDeProgreso(int Maximo, int Minimo)
        {
            BarraDeProgreso.Minimum = Minimo;
            BarraDeProgreso.Maximum = Maximo;
        }

        private void MostrarBarraDeProgreso()
        {
            BarraDeProgreso.Visible = true;
            lbaBarraDePrograso.Visible = true;
        }

        private void OcultarBarraDeProgreso()
        {
            BarraDeProgreso.Visible = false;
            lbaBarraDePrograso.Visible = false;
        }

        private void IncrementarBarraDeProgreso(int incremento)
        {
            BarraDeProgreso.Value = incremento;
            lbaBarraDePrograso.Text = BarraDeProgreso.Value.ToString() + " de " + BarraDeProgreso.Maximum;
            Application.DoEvents();
        }

        #endregion

        private bool InsertarActualizarOEliminarPrivilegiosDelUusuario()
        {
            try
            {
                if (EvaluarDataGridView(dgvLista) == false) { return true; }

                if (dgvLista.Rows.Count > 0)
                {
                    MostrarBarraDeProgreso();
                    InicializarBarraDeProgreso(dgvLista.Rows.Count, 0);
                    int indice = 0;
                    int IndiceProgreso = 0;
                    int TotalDeFilasMarcadasParaEliminar = 0;

                    TotalDeFilasMarcadasParaEliminar = TotalDeFilasMarcadas("Eliminar");

                    /*información General correspondiente */

                    UsuarioEN oUsuariosEN = InformacionDelRegistro();

                    /*Fin de la información general*/

                    while (indice <= dgvLista.Rows.Count - 1)
                    {
                        IncrementarBarraDeProgreso(IndiceProgreso + 1);
                        DataGridViewRow Fila = dgvLista.Rows[indice];

                        if (LosDatosIngresadosEnGrillaSonCorrectosProductosDistribucion(Fila) == false)
                        {
                            if (indice < dgvLista.Rows.Count - 1)
                            {
                                if (MessageBox.Show("¿Desea continuar con los registros restantes a procesar?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                                {
                                    OcultarBarraDeProgreso();
                                    return false;
                                }
                                else
                                {
                                    indice++;
                                    IndiceProgreso++;
                                    continue;
                                }
                            }
                            else
                            {
                                OcultarBarraDeProgreso();
                                return false;
                            }
                        }

                        this.Cursor = Cursors.WaitCursor;

                        ModuloInterfazUsuarioEN oRegistrosEN = new ModuloInterfazUsuarioEN();
                        ModuloInterfazUsuarioLN oRegistrosLN = new ModuloInterfazUsuarioLN();

                        oRegistrosEN.oPrivilegioEN.IdPrivilegio = Convert.ToInt32(Fila.Cells["IdPrivilegio"].Value);
                        oRegistrosEN.oPrivilegioEN.Nombre = Fila.Cells["Privilegio"].Value.ToString();
                        oRegistrosEN.oPrivilegioEN.oModuloInterfazEN.oInterfazEN.Nombre = Fila.Cells["Interfaz"].Value.ToString();
                        oRegistrosEN.oPrivilegioEN.oModuloInterfazEN.oInterfazEN.NombreAMostrar = Fila.Cells["NombreAMostrar"].Value.ToString();
                        oRegistrosEN.oPrivilegioEN.oModuloInterfazEN.oModuloEN.Nombre = Fila.Cells["Modulo"].Value.ToString();                       
                        
                        oRegistrosEN.Acceso = Convert.ToBoolean(Fila.Cells["Marcar"].Value.ToString()) == true ? 1 : 0;

                        oRegistrosEN.oUsuarioEN = oUsuariosEN;
                        
                        oRegistrosEN.IdUsuarioDeCreacion = Program.oLoginEN.IdUsuario;
                        oRegistrosEN.IdUsuarioDeModificacion = Program.oLoginEN.IdUsuario;
                        oRegistrosEN.FechaDeCreacion = System.DateTime.Now;
                        oRegistrosEN.FechaDeModificacion = System.DateTime.Now;
                        oRegistrosEN.oLoginEN = Program.oLoginEN;

                        //DETERMINAMOS LA OPERACION A REALIZAR
                        
                        string Operacion = "";
                        string NombreLavePrimariaDetalle = "IdModuloInterfazUsuario";

                        //El orden es importante porque si un usuario agrego una nueva persona pero lo marco para eliminar, no hacemos nada, solo lo quitamos de la lista.
                        if (Convert.ToInt32(Fila.Cells[NombreLavePrimariaDetalle].Value) == 0 && Convert.ToBoolean(Fila.Cells["Eliminar"].Value) == true) { Operacion = "ELIMINAR FILA EN GRILLA"; }
                        //El orden es importante porque si un usuario agrego una nueva persona aunque lo modifique en la grilla, sigue siendo una inserción
                        else if (Convert.ToInt32(Fila.Cells[NombreLavePrimariaDetalle].Value) == 0) { Operacion = "AGREGAR"; }
                        //El orden es importante porque si un usuario modificó una nueva persona y despues lo marco para eliminación, predomina la eliminación
                        else if (Convert.ToInt32(Fila.Cells[NombreLavePrimariaDetalle].Value) > 0 && Convert.ToBoolean(Fila.Cells["Eliminar"].Value) == true) { Operacion = "ELIMINAR"; }
                        //El orden es importante porque si un usuario modifico una nueva persona esta se ejecuta de último en orden de prioridades con respecto a la eliminación
                        else if (Convert.ToInt32(Fila.Cells[NombreLavePrimariaDetalle].Value) > 0 && Convert.ToBoolean(Fila.Cells["Actualizar"].Value) == true) { Operacion = "ACTUALIZAR"; }
                        //Si la fila se cargo de la base de datos y no se indico ninguna acción sobre ella, no hacemos nada
                        else if (Convert.ToInt32(Fila.Cells[NombreLavePrimariaDetalle].Value) > 0 && Convert.ToBoolean(Fila.Cells["Actualizar"].Value) == false && Convert.ToBoolean(Fila.Cells["Eliminar"].Value) == false) { Operacion = "NINGUNA"; }

                        //VALIDACIONES
                        if (Operacion == "ELIMINAR FILA EN GRILLA")
                        {
                            dgvLista.Rows.Remove(Fila);
                            //Cuando eliminamos una fila y hay filas en la grilla, no incrementamos el indice porque al eliminar la fila, la
                            //siguiente ocupa la posicióin de la fila eliminada, entonces no se necesita incrementar, pero si ya no hay filas 
                            //en la grilla si lo incrementamos para que el ciclo pare.
                            if (dgvLista.RowCount <= 0) { indice++; IndiceProgreso++; }
                            continue;
                        }

                        if (Operacion == "NINGUNA")
                        {
                            indice++;
                            IndiceProgreso++;
                            continue;
                        }
                        /*if (Operacion == "AGREGAR")
                        {
                            //pendiente
                        }
                        if (Operacion == "ACTUALIZAR")
                        {
                            //pendiente
                        }
                        if (Operacion == "ELIMINAR")
                        {
                            //Pendiente
                        }*/

                        //OPERACIONES
                        if (Operacion == "AGREGAR")
                        {
                            if (oRegistrosLN.Agregar(oRegistrosEN, Program.oDatosDeConexioEN))
                            {
                                Fila.Cells[NombreLavePrimariaDetalle].Value = oRegistrosEN.IdModuloInterfazUsuario;
                                Fila.Cells["Actualizar"].Value = false;
                                oRegistrosEN = null;
                                oRegistrosLN = null;
                                indice++;
                                IndiceProgreso++;
                                continue;

                                //EscribirNotificacion("Registro guardado correctamente");
                            }
                            else
                            {
                                OcultarBarraDeProgreso();
                                this.Cursor = Cursors.Default;
                                MessageBox.Show(oRegistrosLN.Error, OperacionARealizar, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                oRegistrosLN = null;
                                oRegistrosEN = null;
                                return false;
                            }
                        }
                        if (Operacion == "ACTUALIZAR")
                        {
                            oRegistrosEN.IdModuloInterfazUsuario = Convert.ToInt32(Fila.Cells[NombreLavePrimariaDetalle].Value);

                            if (oRegistrosLN.Actualizar(oRegistrosEN, Program.oDatosDeConexioEN))
                            {
                                dgvLista.Rows[Fila.Index].Cells["Actualizar"].Value = false;

                                oRegistrosEN = null;
                                oRegistrosLN = null;
                                indice++;
                                IndiceProgreso++;
                                continue;
                                //EscribirNotificacion("Registro actualizado correctamente");                            
                            }
                            else
                            {
                                this.Cursor = Cursors.Default;
                                MessageBox.Show(oRegistrosLN.Error, OperacionARealizar, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                OcultarBarraDeProgreso();
                                oRegistrosEN = null;
                                oRegistrosLN = null;
                                return false;
                            }
                        }
                        if (Operacion == "ELIMINAR")
                        {
                            oRegistrosEN.IdModuloInterfazUsuario = Convert.ToInt32(Fila.Cells[NombreLavePrimariaDetalle].Value);
                            
                            if (oRegistrosLN.Eliminar(oRegistrosEN, Program.oDatosDeConexioEN))
                            {
                                dgvLista.Rows.Remove(Fila);

                                oRegistrosEN = null;
                                oRegistrosLN = null;
                                //Cuando eliminamos una fila y hay filas en la grilla, no incrementamos el indice porque al eliminar la fila, la
                                //siguiente ocupa la posicióin de la fila eliminada, entonces no se necesita incrementar, pero si ya no hay filas 
                                //en la grilla si lo incrementamos para que el ciclo pare.
                                if (dgvLista.RowCount <= 0) { indice++; }
                                IndiceProgreso++;
                                continue;
                                //EscribirNotificacion("Registro eliminado correctamente");
                            }
                            else
                            {

                                MessageBox.Show(oRegistrosEN.oPrivilegioEN.oModuloInterfazEN.oModuloEN.Nombre.ToString());
                                OcultarBarraDeProgreso();
                                this.Cursor = Cursors.Default;
                                MessageBox.Show(oRegistrosLN.Error, OperacionARealizar, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                oRegistrosEN = null;
                                oRegistrosLN = null;
                                return false;
                            }
                        }
                        this.Cursor = Cursors.Default;
                    }

                    oUsuariosEN = null;
                    //lblCantidadRegistros.Text = "No. Registros: " + dgvListaProductos.RowCount.ToString();
                    OcultarBarraDeProgreso();
                    return true;
                }
                else { return true; }
            }
            catch (Exception ex)
            {
                OcultarBarraDeProgreso();
                MessageBox.Show("Error al intentar " + OperacionARealizar + " \n Error: " + ex.Message, "Insertar, Actualizar o Eliminar un privilegio del usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public string WhereDinamico()
        {
            string Where = "";

            if (chkModulo.CheckState == CheckState.Checked && Controles.IsNullOEmptyElControl(cmbModulo) == false)
            {
                Where += string.Format(" and m.IdModulo = {0}", cmbModulo.SelectedValue);
            }

            if (chkInterfaz.CheckState == CheckState.Checked && Controles.IsNullOEmptyElControl(cmbInterfaz) == false)
            {
                Where += string.Format(" and i.IdInterfaz = {0}", cmbInterfaz.SelectedValue);
            }

            if (chkPrivilegio.CheckState == CheckState.Checked && Controles.IsNullOEmptyElControl(txtPrivilegio) == false)
            {
                Where += string.Format(" and p.Nombre like '%{0}%'", txtPrivilegio.Text.Trim());
            }

            return Where;
        }

        private void BuscarPrivilegiosDelUsuario()
        {

            try
            {

                this.Cursor = Cursors.WaitCursor;

                ModuloInterfazUsuarioEN oRegistroEN = new ModuloInterfazUsuarioEN();
                ModuloInterfazUsuarioLN oRegistroLN = new ModuloInterfazUsuarioLN();

                oRegistroEN.oUsuarioEN.IdUsuario = ValorLlavePrimariaEntidad;                
                oRegistroEN.Where = WhereDinamico();
                oRegistroEN.OrderBy = "";

                

                if (oRegistroLN.ListadoPrivilegiosDelUsuario(oRegistroEN, Program.oDatosDeConexioEN))
                {

                    dgvLista.DataSource = oRegistroLN.PrivilegiosDelUsuarioEnDT();
                    FormatearDGV();
                    tstNumeroDeRegistro.Text = string.Format("No de registros: {0} ", oRegistroLN.TotalRegistros());

                }
                else
                {
                    throw new ArgumentException(oRegistroLN.Error);
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Traer información de los privilegios del usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void frmUsuarioOperacion_FormClosing(object sender, FormClosingEventArgs e)
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

                    UsuarioEN oRegistroEN = InformacionDelRegistro();
                    UsuarioLN oRegistroLN = new UsuarioLN();

                    if (oRegistroLN.ValidarRegistroDuplicadoPorNombreDeSecion(oRegistroEN, Program.oDatosDeConexioEN, "ACTUALIZAR"))
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show(oRegistroLN.Error, "Actualizar la información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }

                    if (oRegistroLN.ValidarRegistroDuplicadoPorNombre(oRegistroEN, Program.oDatosDeConexioEN, "ACTUALIZAR"))
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show(oRegistroLN.Error, "Actualizar la información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }

                    if (oRegistroLN.ValidarRegistroDuplicadoPorContrasena(oRegistroEN, Program.oDatosDeConexioEN, "ACTUALIZAR"))
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show(oRegistroLN.Error, "Actualizar la información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }

                    if (oRegistroLN.Actualizar(oRegistroEN, Program.oDatosDeConexioEN))
                    {

                        txtIdentificador.Text = oRegistroEN.IdUsuario.ToString();
                        ValorLlavePrimariaEntidad = oRegistroEN.IdUsuario;

                        EvaluarErrorParaMensajeAPantalla(oRegistroLN.Error, "Actualizar");

                        oRegistroEN = null;
                        oRegistroLN = null;

                        if (InsertarActualizarOEliminarPrivilegiosDelUusuario())
                        {

                            if (CerrarVentana == true)
                            {
                                this.Close();
                            }

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

                    UsuarioEN oRegistroEN = InformacionDelRegistro();
                    UsuarioLN oRegistroLN = new UsuarioLN();

                    /*if (oRegistroLN.ValidarSiElRegistroEstaVinculado(oRegistroEN, Program.oDatosDeConexionEN, "ELIMINAR"))
                     {
                         this.Cursor = Cursors.Default;
                         MessageBox.Show(oRegistroLN.Error, this.OperacionARealizar, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                         return;
                     }*/

                    if (InsertarActualizarOEliminarPrivilegiosDelUusuario())
                    {

                        if (oRegistroLN.Eliminar(oRegistroEN, Program.oDatosDeConexioEN))
                        {

                            txtIdentificador.Text = oRegistroEN.IdUsuario.ToString();
                            ValorLlavePrimariaEntidad = oRegistroEN.IdUsuario;

                            EvaluarErrorParaMensajeAPantalla(oRegistroLN.Error, "Eliminar");

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

        private void tsbRecargar_Click(object sender, EventArgs e)
        {
            LlenarCamposDesdeBaseDatosSegunID();
        }

        private void tsbSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {

                this.Cursor = Cursors.WaitCursor;

                if (dgvLista.Rows.Count == 0)
                {
                    throw new ArgumentException("No hay registro dentro la lista. para poder seguir con la operación");
                }

                tsbSeleccionar.Checked = !tsbSeleccionar.Checked;
                if (tsbSeleccionar.Checked == true)
                {
                    tsbSeleccionar.Image = Properties.Resources.unchecked16x16;
                }
                else
                {
                    tsbSeleccionar.Image = Properties.Resources.checked16x16;
                }

                foreach (DataGridViewRow Fila in dgvLista.Rows)
                {
                    Fila.Cells["Marcar"].Value = tsbSeleccionar.Checked;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Seleccionar los datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void tsbFiltarPrivilegios_Click(object sender, EventArgs e)
        {
            BuscarPrivilegiosDelUsuario();
        }

        private void cmbModulo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(cmbModulo.SelectedIndex > -1)
            {
                chkModulo.CheckState = CheckState.Checked;

                if(tsbAplicarFiltroAutomatio.Checked == true && chkModulo.Checked == true)
                {
                    BuscarPrivilegiosDelUsuario();
                }
            }
            else
            {
                chkModulo.CheckState = CheckState.Checked;
            }
        }

        private void tsbAplicarFiltroAutomatio_Click(object sender, EventArgs e)
        {
            tsbAplicarFiltroAutomatio.Checked = !tsbAplicarFiltroAutomatio.Checked;

            if(tsbAplicarFiltroAutomatio.Checked == true)
            {
                tsbAplicarFiltroAutomatio.Image = Properties.Resources.unchecked16x16;
            }
            else
            {
                tsbAplicarFiltroAutomatio.Image = Properties.Resources.checked16x16;
            }
        }

        private void cmbInterfaz_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(cmbInterfaz.SelectedIndex > -1)
            {
                chkInterfaz.CheckState = CheckState.Checked;

                if(tsbAplicarFiltroAutomatio.Checked == true == chkInterfaz.Checked == true)
                {
                    BuscarPrivilegiosDelUsuario();
                }
            }
            else
            {
                chkInterfaz.CheckState = CheckState.Unchecked;
            }
        }

        private void txtPrivilegio_KeyUp(object sender, KeyEventArgs e)
        {
            if (Controles.IsNullOEmptyElControl(txtPrivilegio))
            {
                chkPrivilegio.CheckState = CheckState.Unchecked;
            }
            else
            {
                chkPrivilegio.CheckState = CheckState.Checked;
                if (chkPrivilegio.Checked == true && tsbAplicarFiltroAutomatio.Checked == true)
                {
                    BuscarPrivilegiosDelUsuario();
                }
            }
        }

        private void txtBuscarPrivilegio_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (dgvLista.Rows.Count > 0)
                {
                    List<DataGridViewRow> rows = (from item in dgvLista.Rows.Cast<DataGridViewRow>()
                                                  let Nombre = Convert.ToString(item.Cells["Privilegio"].Value ?? string.Empty).ToUpper()
                                                  where Nombre.Contains(txtBuscarPrivilegio.Text.ToUpper())
                                                  select item).ToList<DataGridViewRow>();
                    if (rows.Count > 0)
                    {
                        dgvLista.ClearSelection();
                        dgvLista.Rows[rows[0].Index].Cells["Privilegio"].Selected = true;
                        dgvLista.FirstDisplayedScrollingRowIndex = rows[0].Index;
                        txtBuscarPrivilegio.ForeColor = Color.DarkBlue;
                    }
                    else
                    {
                        txtBuscarPrivilegio.ForeColor = Color.DarkRed;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar el privilegio. \n" + ex.Message, "Buscar privilegio asociado al usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvLista_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvLista.IsCurrentCellDirty)
            {
                dgvLista.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void cmbTipoDeCuenta_SelectionChangeCommitted(object sender, EventArgs e)
        {
            TraerPrivilegiosParaElUsuarioApartirDelRol();
        }

        private void tsbGuardar_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (LosDatosIngresadosSonCorrectos())
                {

                    UsuarioEN oRegistroEN = InformacionDelRegistro();
                    UsuarioLN oRegistroLN = new UsuarioLN();
                    

                    if (oRegistroLN.ValidarRegistroDuplicadoPorNombre(oRegistroEN, Program.oDatosDeConexioEN, "AGREGAR"))
                    {

                        MessageBox.Show(oRegistroLN.Error, "Guardar información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }

                    if (oRegistroLN.ValidarRegistroDuplicadoPorContrasena(oRegistroEN, Program.oDatosDeConexioEN, "AGREGAR"))
                    {

                        MessageBox.Show(oRegistroLN.Error, "Guardar información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }

                    if (oRegistroLN.ValidarRegistroDuplicadoPorNombreDeSecion(oRegistroEN, Program.oDatosDeConexioEN, "AGREGAR"))
                    {

                        MessageBox.Show(oRegistroLN.Error, "Guardar información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }

                    if (oRegistroLN.Agregar(oRegistroEN, Program.oDatosDeConexioEN))
                    {

                        txtIdentificador.Text = oRegistroEN.IdUsuario.ToString();
                        txtNombreUsuario.Text = oRegistroEN.Nombre.ToString();
                        ValorLlavePrimariaEntidad = oRegistroEN.IdUsuario;                        
                        
                        oRegistroEN = null;
                        oRegistroLN = null;

                       

                        if (InsertarActualizarOEliminarPrivilegiosDelUusuario())
                        {
                            EvaluarErrorParaMensajeAPantalla(oRegistroLN.Error, "Guardar");

                            if (CerrarVentana == true)
                            {

                                this.Close();
                            }
                            else
                            {
                                OperacionARealizar = "MODIFICAR";
                                ObtenerValoresDeConfiguracion();
                                LlamarMetodoSegunOperacion();
                                EstablecerTituloDeVentana();
                                DeshabilitarControlesSegunOperacionesARealizar();
                            }

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
