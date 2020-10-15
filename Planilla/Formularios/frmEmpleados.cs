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
    public partial class frmEmpleados : Form
    {
        public frmEmpleados()
        {
            InitializeComponent();
        }

        private string Nombre_Entidad_Privilegio = "Cargo";
        private string Nombre_Entidad = "Administrador de cargos del empleado";
        private string Nombre_Llave_Primaria = "IdCargo";
        private int ValorLlavePrimariaEntidad;
        private int IndiceSeleccionado;

        #region "Funciones del programador"

        public bool ActivarFiltros { set; get; }
        public bool VariosRegistros { set; get; }
        public string TituloVentana { set; get; }
        public EmpleadoEN[] oEmpleado = new EmpleadoEN[0];

        public string Columnas { set; get; }

        public DataTable DTRegistros;

        public bool Activar_btn_Imprimir { set; get; }
        public bool Activar_btn_Nuevo { set; get; }
        public bool Activar_MenuContextual { set; get; }
        public bool Activar_MenuContextual_Nuevo { set; get; }
        public bool Activar_MenuContextual_NuevoApartiDe { set; get; }
        public bool Activar_MenuContextual_Modificar { set; get; }
        public bool Activar_MenuContextual_Eliminar { set; get; }
        public bool Activar_MenuContextual_Consultar { set; get; }

        public bool Activar_Exportacion { set; get; }


        private void ActivarFiltrosDeBusqueda()
        {
            if (ActivarFiltros == false)
            {
                tsbFiltrar.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                tsbImprimir.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                tsbImprimir.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                tsbMarcarTodo.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                tsbSeleccionar.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;

                tsbMarcarTodo.Visible = false;
                tsbSeleccionar.Visible = false;

                VariosRegistros = false;

                Activar_MenuContextual = true;

                Activar_MenuContextual_Consultar = true;
                Activar_MenuContextual_Nuevo = true;
                Activar_MenuContextual_NuevoApartiDe = true;
                Activar_MenuContextual_Eliminar = true;
                Activar_MenuContextual_Modificar = true;

            }
            else
            {
                if (ActivarFiltros == true)
                {
                    tsbFiltrar.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                    tsbImprimir.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                    tsbImprimir.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                    tsbMarcarTodo.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                    tsbSeleccionar.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;

                    tsbSeleccionar.Visible = true;

                    if (VariosRegistros == true)
                    {
                        tsbMarcarTodo.Visible = true;
                    }
                    else
                    {
                        tsbMarcarTodo.Visible = true;
                    }
                    this.Text = TituloVentana;

                    if (tsbImprimir.Enabled == true)
                    {
                        tsbImprimir.Visible = Activar_btn_Nuevo;
                    }
                    if (tsbImprimir.Visible == true)
                    {
                        tsbImprimir.Visible = Activar_btn_Imprimir;
                    }

                    mcsMenu.Enabled = Activar_MenuContextual;
                    AgregarColumnasAlDTRegistro();
                }
            }
        }


        //Ver los componentes nesesarios para abilitar esta operacion...
        /*private void LLenarGrupoDeCuentas()
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
                MessageBox.Show(ex.Message, "Información del tipo de cuentas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }


        }*/

        private void AgregarColumnasAlDTRegistro()
        {
            if (Columnas == null) return;

            if (DTRegistros == null)
            {
                string[] arrayColumnas = Columnas.Split(',');
                DTRegistros = new DataTable();

                foreach (string item in arrayColumnas)
                {
                    DataColumn c = DTRegistros.Columns.Add();
                    c.ColumnName = item.Trim();
                }
            }
        }

        private void DesmarcarFilas(int FilaMarcada)
        {
            try
            {

                foreach (DataGridViewRow Fila in dgvLista.Rows)
                {
                    if (Fila.Index != FilaMarcada && Convert.ToBoolean(Fila.Cells["Seleccionar"].Value) == true)
                    {
                        Fila.Cells["Seleccionar"].Value = false;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al desmarcar filas. \n" + ex.Message, "FormatoDGV", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AgregarRegistroAlDTUsuario()
        {
            if (Columnas == null) return;

            if (oEmpleado.Length > 0)
            {
                DataTable DTClass = TraerInformacionDDGV();

                foreach (DataRow Fila in DTClass.Rows)
                {
                    bool Existe = false;

                    if (DTRegistros.Rows.Count > 0)
                    {
                        foreach (DataRow Item in DTRegistros.Rows)
                        {
                            int IdRegistro;
                            int.TryParse(Item[Nombre_Llave_Primaria].ToString(), out IdRegistro);

                            if (IdRegistro == Convert.ToInt32(Fila[Nombre_Llave_Primaria]))
                            {
                                Existe = true;
                            }
                        }
                    }
                    else
                    {
                        Existe = false;
                    }
                    if (Existe == false)
                    {
                        DataRow row = DTRegistros.Rows.Add();

                        String[] ArrayColumnas = Columnas.Split(',');

                        foreach (string c in ArrayColumnas)
                        {
                            row[c.Trim()] = Fila[c.Trim()];
                        }
                        Application.DoEvents();
                    }
                }
            }
        }

        private DataTable AgregarColumnaSeleccionar(DataTable Datos)
        {
            DataColumn Seleccionar = new DataColumn("Seleccionar", Type.GetType("System.Boolean"));
            Seleccionar.Caption = " ";
            Seleccionar.DefaultValue = false;

            Datos.Columns.Add(Seleccionar);
            Seleccionar.SetOrdinal(0);

            return Datos;

        }

        //Para que funcione el where dinamico fata crear los llamados a las clases correspondientes...
        //Para que funcione el where dinamico falta cambiar algunos de los controles de busquedas de texbox a combobox...
        private string WhereDinamico()
        {
            string Where = " ";

            if (Controles.IsNullOEmptyElControl(chkNombre) == false && Controles.IsNullOEmptyElControl(txtNombre) == false)
            {
                Where += string.Format(" and Nombre like '%{0}%' ", txtNombre.Text.Trim());
            }
            if (Controles.IsNullOEmptyElControl(chkApellidos) == false && Controles.IsNullOEmptyElControl(txtApellidos) == false)
            {
                Where += string.Format(" and Apellidos like '%{0}%' ", txtApellidos.Text.Trim());
            }
            if(Controles.IsNullOEmptyElControl(chkCedula) == false && Controles.IsNullOEmptyElControl(txtCedula) == false)
            {
                Where += string.Format(" and Cedula like '%{0}%' ", txtCedula.Text.Trim());
            }
            if(Controles.IsNullOEmptyElControl(chkEmail) == false && Controles.IsNullOEmptyElControl(txtEmail) == false)
            {
                Where += string.Format(" and Correo like '%{0}%' ", txtEmail.Text.Trim());
            }
            if(Controles.IsNullOEmptyElControl(chkAreaLaboral) == false && Controles.IsNullOEmptyElControl(cmbAreaLaboral) == false)
            {
                Where += string.Format(" and dol.Area = {0}", cmbAreaLaboral.Text);
            }
            if(Controles.IsNullOEmptyElControl(chkCargo) == false && Controles.IsNullOEmptyElControl(cmbCargo))
            {
                Where += string.Format(" and co.Cargo = {0}", cmbCargo.Text);
            }
            if(Controles.IsNullOEmptyElControl(chkMunicipio) == false && Controles.IsNullOEmptyElControl(cmbMunicipio) == false)
            {
                Where += string.Format(" and cd.Municipio = {0}", cmbMunicipio.Text);
            }

            return Where;

        }


        private void LLenarListado()
        {

            try
            {

                this.Cursor = Cursors.WaitCursor;

                EmpleadoEN oRegistrosEN = new EmpleadoEN();
                EmpleadoLN oRegistrosLN = new EmpleadoLN();
                
                oRegistrosEN.Where = WhereDinamico();


                if (oRegistrosLN.Listado(oRegistrosEN, Program.oDatosDeConexioEN))
                {
                    dgvLista.Columns.Clear();
                    System.Diagnostics.Debug.Print(oRegistrosLN.TraerDatos().Rows.Count.ToString());

                    if (ActivarFiltros == true)
                    {
                        dgvLista.DataSource = AgregarColumnaSeleccionar(oRegistrosLN.TraerDatos());
                    }
                    else
                    {
                        dgvLista.DataSource = oRegistrosLN.TraerDatos();
                    }

                    FormatearDGV();
                    this.dgvLista.ClearSelection();

                    NoRegistros.Text = "No. Registros: " + oRegistrosLN.TotalRegistros().ToString();


                }
                else
                {
                    throw new ArgumentException(oRegistrosLN.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Llenar listado de registro en la lista", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
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

                if (VariosRegistros == true)
                {
                    this.dgvLista.MultiSelect = VariosRegistros;
                    this.dgvLista.RowHeadersVisible = false;
                }
                else
                {
                    this.dgvLista.MultiSelect = false;
                    this.dgvLista.RowHeadersVisible = true;
                }

                this.dgvLista.DefaultCellStyle.Font = new Font("Segoe UI", 8);
                this.dgvLista.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8);
                this.dgvLista.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
                this.dgvLista.BackgroundColor = System.Drawing.SystemColors.Window;
                this.dgvLista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                string OcultarColumnas = "IdEmpleado, IdCargo, IdMunicipio, IdAreaLaboral";
                OcultarColumnasEnElDGV(OcultarColumnas);

                FormatearColumnasDelDGV();

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

        private DataTable TraerInformacionDDGV()
        {
            DataTable DT = (DataTable)dgvLista.DataSource;
            DataTable DTCopy = new DataTable();

            if (dgvLista.Rows.Count > 0)
            {
                DTCopy = DT.AsEnumerable().Where(r => r.Field<bool>("Seleccionar") == true).CopyToDataTable();
            }

            return DTCopy;
        }

        private void CargarPrivilegiosUsuario()
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
                    foreach (ToolStripItem item in mcsMenu.Items)
                    {
                        if (item.Tag != null)
                        {
                            if (item.GetType() == typeof(ToolStripItem))
                            {
                                item.Enabled = oRegistroLN.VerificarSiTengoAcceso(item.Tag.ToString());
                            }
                        }
                    }

                    tsbImprimir.Enabled = true;
                    tsbNuevoRegistro.Enabled = true;
                }
                else
                {
                    mcsMenu.Enabled = false;
                    tsbImprimir.Enabled = false;
                    tsbNuevoRegistro.Enabled = false;
                    throw new ArgumentException(oRegistroLN.Error);
                }

                oRegistroEN = null;
                oRegistroLN = null;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Privilegios De Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void MostrarFormularioParaOperacion(string OperacionARealizar)
        {
            //Crear el formulario para la operacion...
            /*frmCargoOperacion ofrmCargoOperacion = new frmCargoOperacion();
            ofrmCargoOperacion.OperacionARealizar = OperacionARealizar;
            ofrmCargoOperacion.Nombre_Entidad_Privilegio = Nombre_Entidad_Privilegio;
            ofrmCargoOperacion.Nombre_Entidad = Nombre_Entidad;
            ofrmCargoOperacion.ValorLlavePrimariaEntidad = this.ValorLlavePrimariaEntidad;
            ofrmCargoOperacion.MdiParent = this.ParentForm;
            ofrmCargoOperacion.Show();*/
        }

        private void AsignarLalvePrimaria()
        {
            this.ValorLlavePrimariaEntidad = Convert.ToInt32(this.dgvLista.Rows[this.IndiceSeleccionado].Cells[this.Nombre_Llave_Primaria].Value);
        }
        
        #endregion

        private void frmEmpleados_Shown(object sender, EventArgs e)
        {
            dgvLista.ContextMenuStrip = mcsMenu;
            CargarPrivilegiosUsuario();

            ActivarFiltrosDeBusqueda();
            tsbFiltroAutomatico_Click(null, null);
        }

        private void tsbFiltroAutomatico_Click(object sender, EventArgs e)
        {
            tsbFiltroAutomatico.Checked = !tsbFiltroAutomatico.Checked;

            if (tsbFiltroAutomatico.Checked == true)
            {
                tsbFiltroAutomatico.Image = Properties.Resources.unchecked16x16;
            }
            else
            {
                tsbFiltroAutomatico.Image = Properties.Resources.checked16x16;
            }
        }

        private void tsbFiltrar_Click(object sender, EventArgs e)
        {
            LLenarListado();
        }



        private void tsbNuevoRegistro_Click(object sender, EventArgs e)
        {
            MostrarFormularioParaOperacion("Nuevo");
        }

        private void tsbMarcarTodo_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                tsbMarcarTodo.Checked = ! tsbMarcarTodo.Checked;
                if (tsbMarcarTodo.Checked == true)
                {
                    tsbMarcarTodo.Image = Properties.Resources.unchecked16x16;
                }
                else
                {
                    tsbMarcarTodo.Image = Properties.Resources.checked16x16;
                }

                foreach (DataGridViewRow Fila in dgvLista.Rows)
                {
                    Fila.Cells["Seleccionar"].Value = true;
                    //Si se llamo a la interfaz para seleccionar un solo registro, despues de marcar el primero, llamamos al que desmarca y terminamos
                    if (VariosRegistros == false)
                    {
                        DesmarcarFilas(Fila.Index);
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al marcar filas. \n" + ex.Message, "Marcar todas las filas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void tsbSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                tsbSeleccionar.Checked = ! tsbSeleccionar.Checked;
                if (tsbSeleccionar.Checked == true)
                {
                    tsbSeleccionar.Image = Properties.Resources.unchecked16x16;
                }
                else
                {
                    tsbSeleccionar.Image = Properties.Resources.checked16x16;
                }

                int a = 0;
                this.Cursor = Cursors.WaitCursor;
                if (dgvLista.Rows.Count > 0)
                {
                    foreach (DataGridViewRow Fila in dgvLista.Rows)
                    {
                        if (Convert.ToBoolean(Fila.Cells["Seleccionar"].Value) == true)
                        {
                            a++;
                            Array.Resize(ref oEmpleado, a);

                            oEmpleado[a - 1] = new EmpleadoEN();
                            oEmpleado[a - 1].IdEmpleado = Convert.ToInt32(Fila.Cells["IdEmpleado"].Value);
                            oEmpleado[a - 1].Nombre = Fila.Cells["Nombre"].Value.ToString();
                            oEmpleado[a - 1].Apellidos = Fila.Cells["Apellidos"].Value.ToString();
                            oEmpleado[a - 1].Cedula = Fila.Cells["Cedula"].Value.ToString();
                            oEmpleado[a - 1].Direccion = Fila.Cells["Direccion"].Value.ToString();
                            oEmpleado[a - 1].Telefono = Fila.Cells["Telefono"].Value.ToString();
                            oEmpleado[a - 1].Celular = Fila.Cells["Celular"].Value.ToString();
                            oEmpleado[a - 1].Correo = Fila.Cells["Correo"].Value.ToString();
                            oEmpleado[a - 1].NoINSS = Fila.Cells["NoINSS"].Value.ToString();
                            oEmpleado[a - 1].oAreaLaboralEN.IdAreaLaboral = Convert.ToInt32(Fila.Cells["IdAreaLaboral"].Value.ToString());
                            oEmpleado[a - 1].oAreaLaboralEN.Area = Fila.Cells["AreaLaboral"].Value.ToString();
                            oEmpleado[a - 1].oCargoEN.IdCargo = Convert.ToInt32(Fila.Cells["IdCargo"].Value.ToString());
                            oEmpleado[a - 1].oCargoEN.Cargo = Fila.Cells["Cargo"].Value.ToString();
                            oEmpleado[a - 1].oMunicipioEN.IdMunicipio = Convert.ToInt32(Fila.Cells["IdMunicipio"].Value.ToString());
                            oEmpleado[a - 1].oMunicipioEN.Municipio = Fila.Cells["Municipio"].Value.ToString();
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Seleccionar los registros", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

                AgregarColumnasAlDTRegistro();
                this.Cursor = Cursors.Default;
                this.Close();

            }
        }

        private void txtNombre_KeyUp(object sender, KeyEventArgs e)
        {
            if (Controles.IsNullOEmptyElControl(txtNombre))
            {
                chkNombre.CheckState = CheckState.Unchecked;
            }
            else { chkNombre.CheckState = CheckState.Checked; }

            if (chkNombre.CheckState == CheckState.Checked && tsbFiltroAutomatico.CheckState == CheckState.Checked)
            {
                LLenarListado();
            }
        }

        private void txtApellidos_KeyUp(object sender, KeyEventArgs e)
        {
            if (Controles.IsNullOEmptyElControl(txtApellidos))
            {
                chkApellidos.CheckState = CheckState.Unchecked;
            }
            else { chkApellidos.CheckState = CheckState.Checked; }

            if (chkApellidos.CheckState == CheckState.Checked && tsbFiltroAutomatico.CheckState == CheckState.Checked)
            {
                LLenarListado();
            }
        }

        private void txtCedula_KeyUp(object sender, KeyEventArgs e)
        {
            if (Controles.IsNullOEmptyElControl(txtCedula))
            {
                chkCedula.CheckState = CheckState.Unchecked;
            }
            else { chkCedula.CheckState = CheckState.Checked; }

            if (chkCedula.CheckState == CheckState.Checked && tsbFiltroAutomatico.CheckState == CheckState.Checked)
            {
                LLenarListado();
            }
        }

        private void txtEmail_KeyUp(object sender, KeyEventArgs e)
        {
            if (Controles.IsNullOEmptyElControl(txtEmail))
            {
                chkEmail.CheckState = CheckState.Unchecked;
            }
            else { chkEmail.CheckState = CheckState.Checked; }

            if (chkEmail.CheckState == CheckState.Checked && tsbFiltroAutomatico.CheckState == CheckState.Checked)
            {
                LLenarListado();
            }
        }

        private void txtNoInss_KeyUp(object sender, KeyEventArgs e)
        {
            if (Controles.IsNullOEmptyElControl(txtNoInss))
            {
                chkNoInss.CheckState = CheckState.Unchecked;
            }
            else { chkNoInss.CheckState = CheckState.Checked; }

            if (chkNoInss.CheckState == CheckState.Checked && tsbFiltroAutomatico.CheckState == CheckState.Checked)
            {
                LLenarListado();
            }
        }

        private void cmbAreaLaboral_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Controles.IsNullOEmptyElControl(cmbAreaLaboral))
            {
                chkAreaLaboral.CheckState = CheckState.Unchecked;
            }
            else { chkAreaLaboral.CheckState = CheckState.Checked; }

            if (chkAreaLaboral.CheckState == CheckState.Checked && tsbFiltroAutomatico.CheckState == CheckState.Checked)
            {
                LLenarListado();
            }
        }

        private void cmbCargo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Controles.IsNullOEmptyElControl(cmbCargo))
            {
                chkCargo.CheckState = CheckState.Unchecked;
            }
            else { chkCargo.CheckState = CheckState.Checked; }

            if (chkCargo.CheckState == CheckState.Checked && tsbFiltroAutomatico.CheckState == CheckState.Checked)
            {
                LLenarListado();
            }
        }

        private void cmbMunicipio_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Controles.IsNullOEmptyElControl(cmbMunicipio))
            {
                chkMunicipio.CheckState = CheckState.Unchecked;
            }
            else { chkMunicipio.CheckState = CheckState.Checked; }

            if (chkMunicipio.CheckState == CheckState.Checked && tsbFiltroAutomatico.CheckState == CheckState.Checked)
            {
                LLenarListado();
            }
        }

        private void mcsMenu_Opened(object sender, EventArgs e)
        {
            if (dgvLista.DataSource == null || dgvLista.Rows.Count <= 0 || dgvLista.SelectedRows.Count <= 0)
            {
                cmEliminar.Enabled = false;
                cmActualizar.Enabled = false;
                cmVisualizar.Enabled = false;
                cmImprimir.Enabled = false;
            }
            else
            {
                CargarPrivilegiosUsuario();

            }
        }

        private void dgvLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ActivarFiltros == true)
            {
                if (dgvLista.Columns[dgvLista.CurrentCell.ColumnIndex].Name == "Seleccionar" && VariosRegistros == false)
                {
                    if (Convert.ToBoolean(dgvLista.CurrentCell.Value) == true)
                    {
                        DesmarcarFilas(dgvLista.CurrentCell.RowIndex);
                    }
                }
            }
        }

        private void dgvLista_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            this.IndiceSeleccionado = e.RowIndex;
        }

        private void dgvLista_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvLista.IsCurrentCellDirty)
            {
                dgvLista.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvLista_DoubleClick(object sender, EventArgs e)
        {
            if (ActivarFiltros == true)
            {
                int a = 0;
                this.Cursor = Cursors.WaitCursor;

                dgvLista.CurrentRow.Cells["Seleccionar"].Value = true;

                foreach (DataGridViewRow Fila in dgvLista.Rows)
                {
                    if (Convert.ToBoolean(Fila.Cells["Seleccionar"].Value) == true)
                    {   

                        a++;
                        Array.Resize(ref oEmpleado, a);

                        oEmpleado[a - 1] = new EmpleadoEN();
                        oEmpleado[a - 1].IdEmpleado = Convert.ToInt32(Fila.Cells["IdEmpleado"].Value);
                        oEmpleado[a - 1].Nombre = Fila.Cells["Nombre"].Value.ToString();
                        oEmpleado[a - 1].Apellidos = Fila.Cells["Apellidos"].Value.ToString();
                        oEmpleado[a - 1].Cedula = Fila.Cells["Cedula"].Value.ToString();
                        oEmpleado[a - 1].Direccion = Fila.Cells["Direccion"].Value.ToString();
                        oEmpleado[a - 1].Telefono = Fila.Cells["Telefono"].Value.ToString();
                        oEmpleado[a - 1].Celular = Fila.Cells["Celular"].Value.ToString();
                        oEmpleado[a - 1].Correo = Fila.Cells["Correo"].Value.ToString();
                        oEmpleado[a - 1].NoINSS = Fila.Cells["NoINSS"].Value.ToString();
                        oEmpleado[a - 1].oAreaLaboralEN.IdAreaLaboral = Convert.ToInt32(Fila.Cells["IdAreaLaboral"].Value.ToString());
                        oEmpleado[a - 1].oAreaLaboralEN.Area = Fila.Cells["Area"].Value.ToString();
                        oEmpleado[a - 1].oCargoEN.IdCargo = Convert.ToInt32(Fila.Cells["IdCargo"].Value.ToString());
                        oEmpleado[a - 1].oCargoEN.Cargo = Fila.Cells["Cargo"].Value.ToString();
                        oEmpleado[a - 1].oMunicipioEN.IdMunicipio = Convert.ToInt32(Fila.Cells["IdMunicipio"].Value.ToString());
                        oEmpleado[a - 1].oMunicipioEN.Municipio = Fila.Cells["Municipio"].Value.ToString();
                     }
                }

                this.Cursor = Cursors.Default;
                this.Close();
            }
        }

        private void dgvLista_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo Hitest = dgvLista.HitTest(e.X, e.Y);

                if (Hitest.Type == DataGridViewHitTestType.Cell)
                {
                    dgvLista.CurrentCell = dgvLista.Rows[Hitest.RowIndex].Cells[Hitest.ColumnIndex];
                }

            }
        }

        private void cmNuevo_Click(object sender, EventArgs e)
        {            
            MostrarFormularioParaOperacion("Nuevo");
        }

        private void cmActualizar_Click(object sender, EventArgs e)
        {
            AsignarLalvePrimaria();
            MostrarFormularioParaOperacion("Modificar");
        }

        private void cmEliminar_Click(object sender, EventArgs e)
        {
            AsignarLalvePrimaria();
            MostrarFormularioParaOperacion("Eliminar");
        }

        private void cmVisualizar_Click(object sender, EventArgs e)
        {
            AsignarLalvePrimaria();
            MostrarFormularioParaOperacion("Consultar");
        }
    }
}
