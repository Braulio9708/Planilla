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
    public partial class frmUsuario : Form
    {
        public frmUsuario()
        {
            InitializeComponent();
        }

        private string Nombre_Entidad_Privilegio = "Usuario";
        private string Nombre_Entidad = "Administrar las categorias de las cuentas";
        private string Nombre_Llave_Primaria = "IdUsuario";
        private int ValorDeLaLlavePrimariaEntidad;
        private int IndiceSelecionado;

        #region "Funciones del programdor"

        public bool ActivarFiltros { set; get; }
        public bool VariosRegistros { set; get; }
        public string TituloVentana { set; get; }
        public UsuarioEN[] oUsuario = new UsuarioEN[0];

        public string Columnas { set; get; }

        public DataTable DTRegistros;

        public bool Activar_btn_imprimir { set; get; }
        /// <summary>
        /// Activa o Desactiva la opcion de ingresar un registro de la barra de menus.
        /// </summary>
        public bool Activar_btn_Nuevo { set; get; }
        /// <summary>
        /// Activa o Desactiva la opción de desplegar el menu contextual de la ventana.
        /// </summary>
        public bool Activar_MenuContextual { set; get; }
        /// <summary>
        /// Activa o Desactiva la opción de ingresar un nuevo registro dentro del menu contextual.
        /// </summary>
        public bool Activar_MenuContextual_Nuevo { set; get; }
        /// <summary>
        /// Activa o Desactiva la opción de ingresar un nuevo registro a partir de uno ya existente, dentro del menu contextual
        /// </summary>
        public bool Activar_MenuContextual_NuevoApartirDe { set; get; }
        /// <summary>
        /// Activa o Desactiva la opción de Modifcar un registro, dentro del menu contextual
        /// </summary>
        public bool Activar_MenuContextual_Modificar { set; get; }
        /// <summary>
        /// Activa o Desactiva la opcioón de Eliminar un registro, dentro del menu contextual.
        /// </summary>
        public bool Activar_MenuContextual_Eliminar { set; get; }
        /// <summary>
        /// Activa o Desactiva la opción la de Consultar, dentro del menu contextual.
        /// </summary>
        public bool Activar_MenuContextual_Consultar { set; get; }

        public bool Activar_Exportacion { set; get; }

        private void ActivarFiltrosDelaBusqueda()
        {
            if (ActivarFiltros == false)
            {

                tsbFiltrar.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                tsbNuevo.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                tsbImprimir.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                tsbMarcarTodos.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                tsbSeleccionarTodos.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;

                tsbMarcarTodos.Visible = false;
                tsbSeleccionarTodos.Visible = false;

                VariosRegistros = false;

                Activar_MenuContextual = true;

                Activar_MenuContextual_Consultar = true;
                Activar_MenuContextual_Nuevo = true;
                Activar_MenuContextual_NuevoApartirDe = true;
                Activar_MenuContextual_Eliminar = true;
                Activar_MenuContextual_Modificar = true;


            }
            else
            {
                if (ActivarFiltros == true)
                {

                    tsbFiltrar.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                    tsbNuevo.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                    tsbImprimir.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                    tsbMarcarTodos.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                    tsbSeleccionarTodos.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;

                    tsbSeleccionarTodos.Visible = true;

                    if (VariosRegistros == false)
                    {
                        tsbMarcarTodos.Visible = false;
                    }
                    else
                    {
                        tsbMarcarTodos.Visible = true;
                    }

                    this.Text = TituloVentana;

                    if (tsbNuevo.Enabled == true)
                    {
                        tsbNuevo.Visible = Activar_btn_Nuevo;
                    }
                    if (tsbImprimir.Visible == true)
                        tsbImprimir.Visible = Activar_btn_imprimir;

                    cmMenu.Enabled = Activar_MenuContextual;
                    AgregrarColumnasAlDTRegistros();

                }
            }
        }

        private void LLenarGrupoDeCuentas()
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


        }

        private void AgregrarColumnasAlDTRegistros()
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

                foreach (DataGridViewRow Fila in dgvListar.Rows)
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

        private void AgregarRegistrosAlDTUsuario()
        {
            if (Columnas == null) return;

            if (oUsuario.Length > 0)
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

        /*private DataTable ConvertirClassADT()
        {
            DataTable DTClass = new DataTable();

            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(oUsuario.GetType());
            System.IO.StringWriter sw = new System.IO.StringWriter();
            serializer.Serialize(sw, oUsuario);

            DataSet ds = new DataSet(Nombre_Entidad_Privilegio);
            System.IO.StringReader reader = new System.IO.StringReader(sw.ToString());
            ds.ReadXml(reader);

            DTClass = ds.Tables[0];
            return DTClass;

        }*/

        private DataTable TraerInformacionDDGV()
        {
            DataTable DT = (DataTable)dgvListar.DataSource;
            DataTable DTCopy = new DataTable();

            if (dgvListar.Rows.Count > 0)
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

            string Where = "";

            if (Controles.IsNullOEmptyElControl(chkUsuario) == false && Controles.IsNullOEmptyElControl(txtUsuario) == false)
            {
                Where += string.Format(" and u.Nombre like '%{0}%' ", txtUsuario.Text.Trim());
            }

            if (Controles.IsNullOEmptyElControl(chkNombreDeSecion) == false && Controles.IsNullOEmptyElControl(txtNombreDeSecion) == false)
            {
                Where += string.Format(" and Login like '%{0}%' ", txtNombreDeSecion.Text.Trim());
            }
            
            if (Controles.IsNullOEmptyElControl(chkTipoDeCuenta) == false && Controles.IsNullOEmptyElControl(cmbTipoDeCuenta) == false)
            {
                Where += string.Format(" and r.IdRol = {0} ", cmbTipoDeCuenta.SelectedValue);
            }

            if (Controles.IsNullOEmptyElControl(chkEstado) == false && Controles.IsNullOEmptyElControl(cmbEstado) == false)
            {
                Where += string.Format(" and upper( u.Estado ) = '{0}' ", cmbEstado.Text);
            }

            return Where;

        }

        /*private string TituloDinamico()
        {

            string Titulo = "";
            //u.idUsuario, u.idRol, u.Nombre as 'Usuario', u.Login, u.Contrasena, u.Email, r.Nombre as 'TipoDeCuenta', u.Estado
            if (Controles.IsNullOEmptyElControl(chkUsuario) == false && Controles.IsNullOEmptyElControl(txtUsuario) == false)
            {
                Titulo += string.Format(" Usuario: '{0}', ", txtUsuario.Text.Trim());
            }

            if (Controles.IsNullOEmptyElControl(chkNombreDeSecion) == false && Controles.IsNullOEmptyElControl(txtNombreDeSecion) == false)
            {
                Titulo += string.Format(" Nombre De Secion: '{0}', ", txtNombreDeSecion.Text);
            }

            if (Controles.IsNullOEmptyElControl(chkEstado) == false && Controles.IsNullOEmptyElControl(cmbEstado) == false)
            {
                Titulo += string.Format(" Estado: '{0}', ", cmbEstado.Text);
            }
                        
            if (Controles.IsNullOEmptyElControl(chkTipoDeCuenta) == false && Controles.IsNullOEmptyElControl(cmbTipoDeCuenta) == false)
            {
                Titulo += string.Format(" Tipo de cuenta: '{0}', ", cmbTipoDeCuenta.Text);
            }


            if (Titulo.Length > 0)
            {
                Titulo = Titulo.Substring(0, Titulo.Length - 2);
            }

            return Titulo;


        }*/

        private void LLenarListado()
        {

            try
            {

                this.Cursor = Cursors.WaitCursor;

                UsuarioEN oRegistrosEN = new UsuarioEN();
                UsuarioLN oRegistrosLN = new UsuarioLN();

                oRegistrosEN.Where = WhereDinamico();
                
                
                if (oRegistrosLN.Listado(oRegistrosEN, Program.oDatosDeConexioEN))
                {                    
                    dgvListar.Columns.Clear();
                    System.Diagnostics.Debug.Print(oRegistrosLN.TraerDatos().Rows.Count.ToString());
                    
                    if (ActivarFiltros == true)
                    {
                        dgvListar.DataSource = AgregarColumnaSeleccionar(oRegistrosLN.TraerDatos());
                    }
                    else
                    {
                        dgvListar.DataSource = oRegistrosLN.TraerDatos();
                    }

                    FormatearDGV();
                    this.dgvListar.ClearSelection();

                    tsbNoRegistros.Text = "No. Registros: " + oRegistrosLN.TotalRegistros().ToString();


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
                this.dgvListar.AllowUserToResizeRows = false;
                this.dgvListar.AllowUserToAddRows = false;
                this.dgvListar.AllowUserToDeleteRows = false;
                this.dgvListar.DefaultCellStyle.BackColor = Color.White;

                if (VariosRegistros == true)
                {
                    this.dgvListar.MultiSelect = VariosRegistros;
                    this.dgvListar.RowHeadersVisible = false;
                }
                else
                {
                    this.dgvListar.MultiSelect = false;
                    this.dgvListar.RowHeadersVisible = true;
                }

                this.dgvListar.DefaultCellStyle.Font = new Font("Segoe UI", 8);
                this.dgvListar.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8);
                this.dgvListar.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
                this.dgvListar.BackgroundColor = System.Drawing.SystemColors.Window;
                this.dgvListar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                string OcultarColumnas = "Contrasena,IdRol,IdUsuarioDeCreacion, FechaDeCreacion, IdUsuarioDeModificacion, FechaDeModificacion";
                OcultarColumnasEnElDGV(OcultarColumnas);

                FormatearColumnasDelDGV();

                this.dgvListar.RowHeadersWidth = 25;

                this.dgvListar.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvListar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                this.dgvListar.StandardTab = true;
                this.dgvListar.ReadOnly = false;
                this.dgvListar.CellBorderStyle = DataGridViewCellBorderStyle.Raised;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FormatoDGV", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OcultarColumnasEnElDGV(String ColumnasDelDGV)
        {
            if (dgvListar.Columns.Count > 0)
            {
                String[] ArrayColumnasDGV = ColumnasDelDGV.Split(',');
                foreach (String c in ArrayColumnasDGV)
                {

                    foreach (DataGridViewColumn c1 in dgvListar.Columns)
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
            if (dgvListar.Columns.Count > 0)
            {

                foreach (DataGridViewColumn c1 in dgvListar.Columns)
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

                    foreach (ToolStripItem item in cmMenu.Items)
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
                    tsbNuevo.Enabled = oRegistroLN.VerificarSiTengoAcceso("Nuevo");

                }
                else
                {

                    cmMenu.Enabled = false;
                    tsbImprimir.Enabled = false;
                    tsbNuevo.Enabled = false;
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

        private void MostrarFormularioParaOperacion(string OperacionesARealizar)
        {

            frmUsuarioOperacion ofrmUsuarioOperacion = new frmUsuarioOperacion();
            ofrmUsuarioOperacion.OperacionARealizar = OperacionesARealizar;
            ofrmUsuarioOperacion.Nombre_Entidad_Privilegio = Nombre_Entidad_Privilegio;
            ofrmUsuarioOperacion.Nombre_Entidad = Nombre_Entidad;
            ofrmUsuarioOperacion.ValorLlavePrimariaEntidad = this.ValorDeLaLlavePrimariaEntidad;
            ofrmUsuarioOperacion.MdiParent = this.ParentForm;
            ofrmUsuarioOperacion.Show();

        }

        private void AsignarLlavePrimaria()
        {
            this.ValorDeLaLlavePrimariaEntidad = Convert.ToInt32(this.dgvListar.Rows[this.IndiceSelecionado].Cells[this.Nombre_Llave_Primaria].Value);
        }

        #endregion

        private void frmUsuario_Shown(object sender, EventArgs e)
        {
            dgvListar.ContextMenuStrip = cmMenu;
            CargarPrivilegiosDelUsuario();
            LLenarGrupoDeCuentas();
            ActivarFiltrosDelaBusqueda();
            tsbFiltroAutomatico_Click(null, null);
        }

        private void tsbFiltrar_Click(object sender, EventArgs e)
        {            
            LLenarListado();
        }

        private void tsbSeleccionarTodos_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                tsbSeleccionarTodos.Checked =! tsbMarcarTodos.Checked;
                if (tsbSeleccionarTodos.Checked == true)
                {
                    tsbSeleccionarTodos.Image = Properties.Resources.unchecked16x16;
                }
                else
                {
                    tsbSeleccionarTodos.Image = Properties.Resources.checked16x16;
                }

                int a = 0;
                this.Cursor = Cursors.WaitCursor;
                if (dgvListar.Rows.Count > 0)
                {
                    foreach (DataGridViewRow Fila in dgvListar.Rows)
                    {
                        if (Convert.ToBoolean(Fila.Cells["Seleccionar"].Value) == true)
                        {
                            a++;
                            Array.Resize(ref oUsuario, a);

                            oUsuario[a - 1] = new UsuarioEN();
                            oUsuario[a - 1].IdUsuario = Convert.ToInt32(Fila.Cells["IdUsuario"].Value);
                            oUsuario[a - 1].Nombre = Fila.Cells["Usuario"].Value.ToString();
                            oUsuario[a - 1].Login = Fila.Cells["Login"].Value.ToString();
                            oUsuario[a - 1].Contrasena = Fila.Cells["Contrasena"].Value.ToString();
                            oUsuario[a - 1].Email = Fila.Cells["Email"].Value.ToString();
                            oUsuario[a - 1].oRolEN.IdRol = Convert.ToInt32(Fila.Cells["IdRol"].Value.ToString());
                            oUsuario[a - 1].oRolEN.Nombre = Fila.Cells["TipoDeCuenta"].Value.ToString();
                            oUsuario[a - 1].Estado = Fila.Cells["Estado"].Value.ToString();

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

                AgregarRegistrosAlDTUsuario();
                this.Cursor = Cursors.Default;
                this.Close();

            }
        }

        private void dgvListar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ActivarFiltros == true)
            {
                if (dgvListar.Columns[dgvListar.CurrentCell.ColumnIndex].Name == "Seleccionar" && VariosRegistros == false)
                {
                    if (Convert.ToBoolean(dgvListar.CurrentCell.Value) == true)
                    {
                        DesmarcarFilas(dgvListar.CurrentCell.RowIndex);
                    }
                }
            }
        }

        private void dgvListar_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            this.IndiceSelecionado = e.RowIndex;
        }

        private void dgvListar_CurrentCellDirtyStateChanged_1(object sender, EventArgs e)
        {
            if (dgvListar.IsCurrentCellDirty)
            {
                dgvListar.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvListar_DoubleClick_1(object sender, EventArgs e)
        {
            if (ActivarFiltros == true)
            {
                int a = 0;
                this.Cursor = Cursors.WaitCursor;

                dgvListar.CurrentRow.Cells["Seleccionar"].Value = true;

                foreach (DataGridViewRow Fila in dgvListar.Rows)
                {
                    if (Convert.ToBoolean(Fila.Cells["Seleccionar"].Value) == true)
                    {

                        a++;
                        Array.Resize(ref oUsuario, a);

                        oUsuario[a - 1] = new UsuarioEN();
                        oUsuario[a - 1].IdUsuario = Convert.ToInt32(Fila.Cells["IdUsuario"].Value);
                        oUsuario[a - 1].Nombre = Fila.Cells["Usuario"].Value.ToString();
                        oUsuario[a - 1].Login = Fila.Cells["Login"].Value.ToString();
                        oUsuario[a - 1].Contrasena = Fila.Cells["Contrasena"].Value.ToString();
                        oUsuario[a - 1].Email = Fila.Cells["Email"].Value.ToString();
                        oUsuario[a - 1].oRolEN.IdRol = Convert.ToInt32(Fila.Cells["IdRol"].Value.ToString());
                        oUsuario[a - 1].oRolEN.Nombre = Fila.Cells["TipoDeCuenta"].Value.ToString();
                        oUsuario[a - 1].Estado = Fila.Cells["Estado"].Value.ToString();

                    }
                }

                this.Cursor = Cursors.Default;
                this.Close();
            }
        }

        private void dgvListar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo Hitest = dgvListar.HitTest(e.X, e.Y);

                if (Hitest.Type == DataGridViewHitTestType.Cell)
                {
                    dgvListar.CurrentCell = dgvListar.Rows[Hitest.RowIndex].Cells[Hitest.ColumnIndex];
                }

            }
        }

        private void tsbMarcarTodos_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                tsbMarcarTodos.Checked = !tsbMarcarTodos.Checked;
                if (tsbMarcarTodos.Checked == true)
                {
                    tsbMarcarTodos.Image = Properties.Resources.unchecked16x16;
                }
                else
                {
                    tsbMarcarTodos.Image = Properties.Resources.checked16x16;
                }

                foreach (DataGridViewRow Fila in dgvListar.Rows)
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

        private void frmUsuario_KeyUp(object sender, KeyEventArgs e)
        {
            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F2) && cmNuevo.Enabled == true)
            {
                nuevoToolStripMenuItem_Click(null, null);
            }

            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F3) && cmActualizar.Enabled == true)
            {
                if (dgvListar.SelectedRows.Count > 0)
                {
                    IndiceSelecionado = dgvListar.CurrentRow.Index;
                    actualizarToolStripMenuItem_Click(null, null);
                }
                else
                {
                    MessageBox.Show("Se debe de seleccionar un registro de la lista", "Actualizar Registro ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F4) && cmEliminar.Enabled == true)
            {
                if (dgvListar.SelectedRows.Count > 0)
                {
                    IndiceSelecionado = dgvListar.CurrentRow.Index;
                    eliminarToolStripMenuItem_Click(null, null);
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

            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F6) && cmVisualizar.Enabled == true && dgvListar.SelectedRows.Count > 0)
            {
                if (dgvListar.SelectedRows.Count > 0)
                {
                    IndiceSelecionado = dgvListar.CurrentRow.Index;
                    visualizarToolStripMenuItem_Click(null, null);
                }
                else
                {
                    MessageBox.Show("Se debe de seleccionar un registro de la lista", "Consultar Registro ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarFormularioParaOperacion("Nuevo");
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AsignarLlavePrimaria();
            MostrarFormularioParaOperacion("Modificar");
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AsignarLlavePrimaria();
            MostrarFormularioParaOperacion("Eliminar");
        }

        private void visualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AsignarLlavePrimaria();
            MostrarFormularioParaOperacion("Consultar");
        }

        private void cmMenu_Opened(object sender, EventArgs e)
        {
            if (dgvListar.DataSource == null || dgvListar.Rows.Count <= 0 || dgvListar.SelectedRows.Count <= 0)
            {
                cmEliminar.Enabled = false;
                cmActualizar.Enabled = false;
                cmVisualizar.Enabled = false;
                cmImprimir.Enabled = false;
            }
            else
            {
                CargarPrivilegiosDelUsuario();

            }
        }                         

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            MostrarFormularioParaOperacion("Nuevo");
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

        private void cmbGruposDeCuentas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Controles.IsNullOEmptyElControl(cmbTipoDeCuenta))
            {
                chkTipoDeCuenta.CheckState = CheckState.Unchecked;
            }
            else { chkTipoDeCuenta.CheckState = CheckState.Checked; }

            if (chkTipoDeCuenta.CheckState == CheckState.Checked && tsbFiltroAutomatico.CheckState == CheckState.Checked)
            {
                LLenarListado();
            }
        }

        private void txtNombreDeSesion_KeyUp(object sender, KeyEventArgs e)
        {
            if (Controles.IsNullOEmptyElControl(txtNombreDeSecion))
            {
                chkNombreDeSecion.CheckState = CheckState.Unchecked;
            }
            else { chkNombreDeSecion.CheckState = CheckState.Checked; }

            if (chkNombreDeSecion.CheckState == CheckState.Checked && tsbFiltroAutomatico.CheckState == CheckState.Checked)
            {
                LLenarListado();
            }
        }        

        private void cmbEstado_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Controles.IsNullOEmptyElControl(cmbEstado))
            {
                chkEstado.CheckState = CheckState.Unchecked;
            }
            else { chkEstado.CheckState = CheckState.Checked; }

            if (chkEstado.CheckState == CheckState.Checked && tsbFiltroAutomatico.CheckState == CheckState.Checked)
            {
                LLenarListado();
            }
        }
        
    }
    
}


    
       
    

