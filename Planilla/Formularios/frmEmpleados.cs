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

        private string Nombre_Entidad_Privilegio = "Empleado";
        private string Nombre_Entidad = "Administrador de empleados";
        private string Nombre_Llave_Primaria = "IdEmpleado";
        private int ValorLlavePrimariaEntidad;
        private int IndiceSeleccionado;

        #region "Funciones del programador"

        public bool Activar_Filtros { set; get; }
        public bool VariosRegistros { set; get; }
        public string TituloDeVentana { set; get; }

        public EmpleadoEN[] oEmpleadoEN = new EmpleadoEN[0];

        public string columnas { set; get; }

        public DataTable DTRegistros;

        public bool Activar_btn_Imprimir { set; get; }
        public bool Activar_btn_Nuevo { set; get; }
        public bool Activar_MenuContextual { set; get; }
        public bool Activar_MenuContextual_Nuevo { set; get; }
        public bool Activar_MenuContextual_NuevoAPartirDe { set; get; }
        public bool Activar_MenuContextual_Modificar { set; get; }
        public bool Activar_MenuContextual_Eliminar { set; get; }
        public bool Activar_MenuContextual_Consultar { set; get; }

        private void ActivarFiltosDeBusqueda()
        {
            if (Activar_Filtros == false)
            {
                tsbFiltrar.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                tsbNuevoRegistro.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                tsbMarcarTodo.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                tsbSeleccionar.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                tsbImprimir.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;

                tsbMarcarTodo.Visible = false;
                tsbSeleccionar.Visible = false;

                VariosRegistros = false;

                Activar_MenuContextual = true;
                Activar_MenuContextual_Nuevo = true;
                Activar_MenuContextual_NuevoAPartirDe = true;
                Activar_MenuContextual_Modificar = true;
                Activar_MenuContextual_Eliminar = true;
                Activar_MenuContextual_Consultar = true;

            }
            else
            {
                if (Activar_Filtros == true)
                {
                    tsbFiltrar.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                    tsbNuevoRegistro.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                    tsbMarcarTodo.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                    tsbSeleccionar.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                    tsbImprimir.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;

                    if (VariosRegistros == false)
                    {
                        tsbMarcarTodo.Visible = false;
                    }
                    else
                    {
                        tsbMarcarTodo.Visible = true;
                    }

                    this.Text = TituloDeVentana;

                    if (tsbNuevoRegistro.Enabled == true)
                    {
                        tsbNuevoRegistro.Visible = Activar_btn_Nuevo;
                    }

                    if (tsbImprimir.Visible == true)
                    {
                        tsbImprimir.Visible = Activar_btn_Imprimir;
                    }


                    mcsMenu.Enabled = Activar_MenuContextual;
                    AgregarColumnasAlDTRegistros();
                }
            }
        }

        private void AgregarColumnasAlDTRegistros()
        {
            if (columnas == null) return;

            if (DTRegistros == null)
            {
                string[] arrayColumnas = columnas.Split(',');

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
                MessageBox.Show("Error al desmarcar filas. \n" + ex.Message, "FomatoDGV", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AgregarRegistrosAlDTUsuario()
        {
            if (columnas == null) return;

            if (oEmpleadoEN.Length > 0)
            {
                DataTable DTClass = TraerInformacionDelDGV();

                foreach (DataRow Fila in DTClass.Rows)
                {
                    bool Existe = false;

                    if (DTRegistros.Rows.Count > 0)
                    {
                        foreach (DataRow item in DTRegistros.Rows)
                        {
                            int IdRegistros;
                            int.TryParse(item[Nombre_Llave_Primaria].ToString(), out IdRegistros);

                            if (IdRegistros == Convert.ToInt32(Fila[Nombre_Llave_Primaria]))
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

                        String[] ArrayColumnas = columnas.Split(',');

                        foreach (string c in ArrayColumnas)
                        {
                            row[c.Trim()] = Fila[c.Trim()];
                        }
                        Application.DoEvents();
                    }
                }
            }
        }

        private DataTable ConvertirClassADT()
        {
            DataTable DTClass = new DataTable();

            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(oEmpleadoEN.GetType());
            System.IO.StringWriter sw = new System.IO.StringWriter();
            serializer.Serialize(sw, oEmpleadoEN);

            DataSet ds = new DataSet(Nombre_Entidad_Privilegio);
            System.IO.StringReader reader = new System.IO.StringReader(sw.ToString());
            ds.ReadXml(reader);

            DTClass = ds.Tables[0];
            return DTClass;

        }

        private DataTable TraerInformacionDelDGV()
        {
            DataTable DT = (DataTable)dgvLista.DataSource;
            DataTable DTCopy = new DataTable();

            if (dgvLista.Rows.Count > 0)
            {
                DTCopy = DT.AsEnumerable().Where(r => r.Field<bool>("Seleccionar") == true).CopyToDataTable();
            }
            return DTCopy;
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

        private string WhereDinamico()
        {
            string where = " ";

            if (Controles.IsNullOEmptyElControl(chkNombre) == false && Controles.IsNullOEmptyElControl(txtNombre) == false)
            {
                where += string.Format(" and emp.Nombre like '%{0}%'", txtNombre.Text.Trim());
            }
            if (Controles.IsNullOEmptyElControl(chkApellidos) == false && Controles.IsNullOEmptyElControl(txtApellidos) == false)
            {
                where += string.Format(" and emp.Apellidos like '%{0}%'", txtApellidos.Text.Trim());
            }
            if (Controles.IsNullOEmptyElControl(chkCedula) == false && Controles.IsNullOEmptyElControl(txtCedula) == false)
            {
                where += string.Format(" and emp.Cedula like '%{0}%'", txtCedula.Text.Trim());
            }
            if (Controles.IsNullOEmptyElControl(chkEmail) == false && Controles.IsNullOEmptyElControl(txtEmail) == false)
            {
                where += string.Format(" and emp.Correo like '%{0}%'", txtEmail.Text.Trim());
            }
            if (Controles.IsNullOEmptyElControl(chkNoInss) == false && Controles.IsNullOEmptyElControl(txtNoInss) == false)
            {
                where += string.Format(" and emp.NoINSS like '%{0}%'", txtNoInss.Text.Trim());
            }
            if (Controles.IsNullOEmptyElControl(chkAreaLaboral) == false && Controles.IsNullOEmptyElControl(cmbAreaLaboral) == false)
            {
                where += string.Format(" and al.Area like {0}", cmbAreaLaboral.Text.Trim());
            }
            if (Controles.IsNullOEmptyElControl(chkCargo) == false && Controles.IsNullOEmptyElControl(cmbCargo) == false)
            {
                where += string.Format(" and co.Cargo like {0}", cmbCargo.Text.Trim());
            }
            if (Controles.IsNullOEmptyElControl(chkMunicipio) == false && Controles.IsNullOEmptyElControl(cmbMunicipio) == false)
            {
                where += string.Format(" and mpo.Municipio like {0}", cmbMunicipio.Text.Trim());
            }

            return where;
        }

        private void LlenarListado()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                EmpleadoEN oRegistroEN = new EmpleadoEN();
                EmpleadoLN oRegistroLN = new EmpleadoLN();

                oRegistroEN.Where = WhereDinamico();

                if (oRegistroLN.Listado(oRegistroEN, Program.oDatosDeConexioEN))
                {
                    dgvLista.Columns.Clear();
                    System.Diagnostics.Debug.Print(oRegistroLN.TraerDatos().Rows.Count.ToString());

                    if (Activar_Filtros == true)
                    {
                        dgvLista.DataSource = AgregarColumnaSeleccionar(oRegistroLN.TraerDatos());
                    }
                    else
                    {
                        dgvLista.DataSource = oRegistroLN.TraerDatos();
                    }

                    FormatearDGV();
                    this.dgvLista.ClearSelection();

                    tsbNoRegistros.Text = "No Registros: " + oRegistroLN.TotalRegistros().ToString();
                }
                else
                {
                    throw new ArgumentException(oRegistroLN.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lelnar listado del registro en la lista", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                string OcultarColumnas = "idEmplado, idAreaLaboral, idCargo, idMunicipio";
                OcultarColumnasEnElDGV(OcultarColumnas);

                FormatearColumnasEnELDGV();

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
            if (dgvLista.Rows.Count > 0)
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

        private void FormatearColumnasEnELDGV()
        {
            if (dgvLista.Columns.Count > 0)
            {
                foreach (DataGridViewColumn c1 in dgvLista.Columns)
                {
                    if (c1.Visible == true)
                    {
                        if (c1.Name.Trim().ToUpper() != "Seleccionar".ToUpper())
                        {
                            FormatoDGV oFormato = new FormatoDGV(c1.Name.Trim(), "Empleado");
                            if (oFormato.ValorEncontrado == false)
                            {
                                oFormato = new FormatoDGV(c1.Name.Trim());
                            }
                            if (oFormato != null)
                            {
                                if (oFormato.ValorEncontrado == true)
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
        }

        private void CargarPrivilegios()
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
                            if (item.GetType() == typeof(ToolStripMenuItem))
                            {
                                item.Enabled = oRegistroLN.VerificarSiTengoAcceso(item.Tag.ToString());
                            }
                        }
                    }

                    tsbImprimir.Enabled = oRegistroLN.VerificarSiTengoAcceso("Imprimir");
                    tsbNuevoRegistro.Enabled = oRegistroLN.VerificarSiTengoAcceso("Nuevo");
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
                MessageBox.Show(ex.Message, "Privilegios de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void MostrarFormularioParaOperacion(string OperacionARealizar)
        {
            /*
            frmEmpleadoOperacion ofrmEmpleadoOperacion = new frmEmpleadoOperacion();
            ofrmEmpleadoOperacion.OperacionARealizar = OperacionesARealizar;
            ofrmEmpleadoOperacion.NOMBRE_ENTIDAD_PRIVILEGIO = NOMBRE_ENTIDAD_PRIVILEGIO;
            ofrmEmpleadoOperacion.NombreEntidad = NOMBRE_ENTIDAD;
            ofrmEmpleadoOperacion.ValorLlavePrimariaEntidad = this.ValorLlavePrimariaEntidad;
            ofrmEmpleadoOperacion.MdiParent = this.ParentForm;
            ofrmEmpleadoOperacion.Show();*/
        }

        private void AsignarLlavePrimaria()
        {
            this.ValorLlavePrimariaEntidad = Convert.ToInt32(this.dgvLista.Rows[this.IndiceSeleccionado].Cells[this.Nombre_Llave_Primaria].Value);
        }

        private void LlenarCargosDelEmpleado()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                CargoEN oRegistroEN = new CargoEN();
                CargoLN oRegistroLN = new CargoLN();
                oRegistroEN.Where = "";
                oRegistroEN.OrderBy = "";

                if (oRegistroLN.ListadoParaCombos(oRegistroEN, Program.oDatosDeConexioEN))
                {
                    cmbCargo.DataSource = oRegistroLN.TraerDatos();
                    cmbCargo.DisplayMember = "Cargo";
                    cmbCargo.ValueMember = "IdCargo";
                    cmbCargo.SelectedIndex = -1;
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
        }

        private void LlenarAreaLaboral()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                AreaLaboralEN oRegistroEN = new AreaLaboralEN();
                AreaLaboralLN oRegistroLN = new AreaLaboralLN();
                oRegistroEN.Where = "";
                oRegistroEN.OrderBy = "";

                if (oRegistroLN.ListadoParaCombos(oRegistroEN, Program.oDatosDeConexioEN))
                {
                    cmbAreaLaboral.DataSource = oRegistroLN.TraerDatos();
                    cmbAreaLaboral.DisplayMember = "Area";
                    cmbAreaLaboral.ValueMember = "IdAreaLaboral";
                    cmbAreaLaboral.SelectedIndex = -1;
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
        }

        private void LlenarMunicipio()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                MunicipioEN oRegistroEN = new MunicipioEN();
                //MunicipioLN oRegistroLN = new MunicipioLN();
                oRegistroEN.Where = "";
                oRegistroEN.OrderBy = "";

                if (oRegistroLN.ListadoParaCombos(oRegistroEN, Program.oDatosDeConexioEN))
                {
                    cmbCargo.DataSource = oRegistroLN.TraerDatos();
                    cmbCargo.DisplayMember = "Area";
                    cmbCargo.ValueMember = "IdAreaLaboral";
                    cmbCargo.SelectedIndex = -1;
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
        }
        #endregion





        private void frmEmpleados_Shown(object sender, EventArgs e)
        {
            dgvLista.ContextMenuStrip = mcsMenu;
            CargarPrivilegios();
            LlenarCargosDelEmpleado();
            LlenarAreaLaboral();
            ActivarFiltosDeBusqueda();
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
            LlenarListado();
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

                tsbMarcarTodo.Checked = !tsbMarcarTodo.Checked;
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
                tsbSeleccionar.Checked = !tsbSeleccionar.Checked;
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
                            Array.Resize(ref oEmpleadoEN, a);

                            oEmpleadoEN[a - 1] = new EmpleadoEN();
                            oEmpleadoEN[a - 1].IdEmpleado = Convert.ToInt32(Fila.Cells["IdEmpleado"].Value);
                            oEmpleadoEN[a - 1].Nombre = Fila.Cells["Nombre"].Value.ToString();
                            oEmpleadoEN[a - 1].Apellidos = Fila.Cells["Apellidos"].Value.ToString();
                            oEmpleadoEN[a - 1].Cedula = Fila.Cells["Cedula"].Value.ToString();
                            oEmpleadoEN[a - 1].Direccion = Fila.Cells["Direccion"].Value.ToString();
                            oEmpleadoEN[a - 1].Telefono = Fila.Cells["Telefono"].Value.ToString();
                            oEmpleadoEN[a - 1].Celular = Fila.Cells["Celular"].Value.ToString();
                            oEmpleadoEN[a - 1].Correo = Fila.Cells["Correo"].Value.ToString();
                            oEmpleadoEN[a - 1].NoINSS = Fila.Cells["NoINSS"].Value.ToString();
                            oEmpleadoEN[a - 1].oCargoEN.IdCargo = Convert.ToInt32(Fila.Cells["IdCargo"].Value.ToString());
                            oEmpleadoEN[a - 1].oMunicipioEN.IdMunicipio = Convert.ToInt32(Fila.Cells["IdMunicipio"].Value.ToString());
                            oEmpleadoEN[a - 1].oAreaLaboralEN.IdAreaLaboral = Convert.ToInt32(Fila.Cells["IdAreaLaboral"].Value.ToString());
                            oEmpleadoEN[a - 1].oAreaLaboralEN.Area = Fila.Cells["Area"].Value.ToString();
                            oEmpleadoEN[a - 1].oCargoEN.Cargo = Fila.Cells["Cargo"].Value.ToString();
                            oEmpleadoEN[a - 1].oMunicipioEN.Municipio = Fila.Cells["Municipio"].Value.ToString();
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

                AgregarColumnasAlDTRegistros();
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
                LlenarListado();
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
                LlenarListado();
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
                LlenarListado();
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
                LlenarListado();
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
                LlenarListado();
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
                LlenarListado();
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
                LlenarListado();
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
                LlenarListado();
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
                CargarPrivilegios();

            }
        }

        private void dgvLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Activar_Filtros == true)
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
            if (Activar_Filtros == true)
            {
                int a = 0;
                this.Cursor = Cursors.WaitCursor;

                dgvLista.CurrentRow.Cells["Seleccionar"].Value = true;

                foreach (DataGridViewRow Fila in dgvLista.Rows)
                {
                    if (Convert.ToBoolean(Fila.Cells["Seleccionar"].Value) == true)
                    {

                        a++;
                        Array.Resize(ref oEmpleadoEN, a);

                        oEmpleadoEN[a - 1] = new EmpleadoEN();
                        oEmpleadoEN[a - 1].IdEmpleado = Convert.ToInt32(Fila.Cells["IdEmpleado"].Value);
                        oEmpleadoEN[a - 1].Nombre = Fila.Cells["Nombre"].Value.ToString();
                        oEmpleadoEN[a - 1].Apellidos = Fila.Cells["Apellidos"].Value.ToString();
                        oEmpleadoEN[a - 1].Cedula = Fila.Cells["Cedula"].Value.ToString();
                        oEmpleadoEN[a - 1].Direccion = Fila.Cells["Direccion"].Value.ToString();
                        oEmpleadoEN[a - 1].Telefono = Fila.Cells["Telefono"].Value.ToString();
                        oEmpleadoEN[a - 1].Celular = Fila.Cells["Celular"].Value.ToString();
                        oEmpleadoEN[a - 1].Correo = Fila.Cells["Correo"].Value.ToString();
                        oEmpleadoEN[a - 1].NoINSS = Fila.Cells["NoINSS"].Value.ToString();
                        oEmpleadoEN[a - 1].oCargoEN.IdCargo = Convert.ToInt32(Fila.Cells["IdCargo"].Value.ToString());
                        oEmpleadoEN[a - 1].oMunicipioEN.IdMunicipio = Convert.ToInt32(Fila.Cells["IdMunicipio"].Value.ToString());
                        oEmpleadoEN[a - 1].oAreaLaboralEN.IdAreaLaboral = Convert.ToInt32(Fila.Cells["IdAreaLaboral"].Value.ToString());
                        oEmpleadoEN[a - 1].oAreaLaboralEN.Area = Fila.Cells["Area"].Value.ToString();
                        oEmpleadoEN[a - 1].oCargoEN.Cargo = Fila.Cells["Cargo"].Value.ToString();
                        oEmpleadoEN[a - 1].oMunicipioEN.Municipio = Fila.Cells["Municipio"].Value.ToString();
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
                DataGridView.HitTestInfo HitTest = dgvLista.HitTest(e.X, e.Y);

                if(HitTest.Type == DataGridViewHitTestType.Cell)
                {
                    dgvLista.CurrentCell = dgvLista.Rows[HitTest.RowIndex].Cells[HitTest.ColumnIndex];
                }
            }

        }

        private void cmNuevo_Click(object sender, EventArgs e)
        {
            MostrarFormularioParaOperacion("Nuevo");
        }

        private void cmActualizar_Click(object sender, EventArgs e)
        {
            AsignarLlavePrimaria();
            MostrarFormularioParaOperacion("Modificar");
        }

        private void cmEliminar_Click(object sender, EventArgs e)
        {
            AsignarLlavePrimaria();
            MostrarFormularioParaOperacion("Eliminar");
        }

        private void cmVisualizar_Click(object sender, EventArgs e)
        {
            AsignarLlavePrimaria();
            MostrarFormularioParaOperacion("Consultar");
        }

        private void frmEmpleados_KeyUp(object sender, KeyEventArgs e)
        {
            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F2) && cmNuevo.Enabled == true)
            {
                cmNuevo_Click(null, null);
            }

            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F3) && cmActualizar.Enabled == true)
            {
                if (dgvLista.SelectedRows.Count > 0)
                {
                    IndiceSeleccionado = dgvLista.CurrentRow.Index;
                    cmActualizar_Click(null, null);
                }
                else
                {
                    MessageBox.Show("Se debe de seleccionar un registro de la lista", "Actualizar Registro ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F4) && cmEliminar.Enabled == true)
            {
                if (dgvLista.SelectedRows.Count > 0)
                {
                    IndiceSeleccionado = dgvLista.CurrentRow.Index;
                    cmEliminar_Click(null, null);
                }
                else
                {
                    MessageBox.Show("Se debe de seleccionar un registro de la lista", "Eliminar Registro ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F5))
            {
                tsbFiltrar_Click(null, null);
            }

            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F6) && cmVisualizar.Enabled == true && dgvLista.SelectedRows.Count > 0)
            {
                if (dgvLista.SelectedRows.Count > 0)
                {
                    IndiceSeleccionado = dgvLista.CurrentRow.Index;
                    cmVisualizar_Click(null, null);
                }
                else
                {
                    MessageBox.Show("Se debe de seleccionar un registro de la lista", "Consultar Registro ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
