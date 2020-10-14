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
        /*private string WhereDinamico()
        {
            string Where = " ";

            if (Controles.IsNullOEmptyElControl(chkIdentificador) == false && Controles.IsNullOEmptyElControl(txtIdentificador) == false)
            {
                Where += string.Format(" and IdCargo like '%{0}%' ", txtIdentificador.Text.Trim());
            }
            if (Controles.IsNullOEmptyElControl(chkCargo) == false && Controles.IsNullOEmptyElControl(txtCargo) == false)
            {
                Where += string.Format(" and Cargo like '%{0}%' ", txtCargo.Text.Trim());
            }

            return Where;

        }*/


        private void LLenarListado()
        {

            try
            {

                this.Cursor = Cursors.WaitCursor;

                EmpleadoEN oRegistrosEN = new EmpleadoEN();
                EmpleadoLN oRegistrosLN = new EmpleadoLN();
                //Where  dinamico todavia no esta activado...
                //oRegistrosEN.Where = WhereDinamico();


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
                string OcultarColumnas = "Contrasena,IdRol,IdUsuarioDeCreacion, FechaDeCreacion, IdUsuarioDeModificacion, FechaDeModificacion";
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
    }
}
