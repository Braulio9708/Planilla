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
    public partial class frmAreaLaboral : Form
    {
        public frmAreaLaboral()
        {
            InitializeComponent();
        }


        private string Nombre_Entidad_Privilegio = "AreaLaboral";
        private string Nombre_Entidad = "Administrador de Areas Laborales";
        private string Nombre_Llave_Primaria = "IdAreaLaboral";
        private int ValorLlavePrimariaEntidad;
        private int IndiceSeleccionado;

        #region "Funciones del programador"

        public bool Activar_Filtros { set; get; }
        public bool VariosRegistros { set; get; }
        public string TituloDeLaVentana { set; get; }
        public AreaLaboralEN[] oAreaLaboral = new AreaLaboralEN[0];

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
            if(Activar_Filtros == false)
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
                Activar_MenuContextual_Eliminar = true;
                Activar_MenuContextual_Modificar = true;
                Activar_MenuContextual_Nuevo = true;
                Activar_MenuContextual_NuevoApartiDe = true;
            }
            else
            {
                if(Activar_Filtros == true)
                {
                    tsbFiltrar.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                    tsbNuevo.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                    tsbImprimir.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                    tsbMarcarTodos.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                    tsbSeleccionarTodos.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;

                    tsbSeleccionarTodos.Visible = true;

                    if(VariosRegistros == true)
                    {
                        tsbMarcarTodos.Visible = false;
                    }
                    else
                    {
                        tsbMarcarTodos.Visible = true;
                    }
                    this.Text = TituloDeLaVentana;

                    if (tsbImprimir.Enabled == true)
                    {
                        tsbImprimir.Visible = Activar_btn_Nuevo;
                    }
                    if(tsbImprimir.Visible == true)
                    {
                        tsbImprimir.Visible = Activar_btn_Imprimir;
                    }

                    mcsMenu.Enabled = Activar_MenuContextual;
                    AgregarColumnasAlDTRegistro();
                }
            }
        }

        private void AgregarColumnasAlDTRegistro()
        {
            if (Columnas == null) return;

            if(DTRegistros == null)
            {
                string[] ArrayColumnas = Columnas.Split(',');
                DTRegistros = new DataTable();

                foreach(string item in ArrayColumnas)
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
                    if(Fila.Index!=FilaMarcada && Convert.ToBoolean(Fila.Cells["Seleccionar"].Value) == true)
                    {
                        Fila.Cells["Seleccionar"].Value = false;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al desmarcar filas. \n" + ex.Message, "FormatoDGV", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AgregarRegistroAlDTUsuario()
        {
            if (Columnas == null) return;

            if(oAreaLaboral.Length > 0)
            {
                DataTable DTClass = TraerInformacionDDGV();

                foreach(DataRow Fila in DTClass.Rows)
                {
                    bool Existe = false;

                    if(DTRegistros.Rows.Count > 0)
                    {
                        foreach(DataRow Item in DTRegistros.Rows)
                        {
                            int IdRegistro;
                            int.TryParse(Item[Nombre_Llave_Primaria].ToString(), out IdRegistro);

                            if(IdRegistro == Convert.ToInt32(Fila[Nombre_Llave_Primaria]))
                            {
                                Existe = true;
                            }
                        }
                    }
                    else
                    {
                        Existe = false;
                    }
                    if(Existe == false)
                    {
                        DataRow row = DTRegistros.Rows.Add();

                        String[] ArrayColumnas = Columnas.Split(',');

                        foreach(string c in ArrayColumnas)
                        {
                            row[c.Trim()] = Fila[c.Trim()];
                        }

                        Application.DoEvents();
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

            if (Controles.IsNullOEmptyElControl(chkIdentificador) == false && Controles.IsNullOEmptyElControl(txtIdentificador) == false)
            {
                Where += string.Format(" and IdAreaLaboral like '%{0}%' ", txtIdentificador.Text.Trim());
            }
            if (Controles.IsNullOEmptyElControl(chkArea) == false && Controles.IsNullOEmptyElControl(txtArea) == false)
            {
                Where += string.Format(" and Area like '%{0}%' ", txtArea.Text.Trim());
            }

            return Where;
        }

        private void LlenarListado()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                AreaLaboralEN oRegistroEN = new AreaLaboralEN();
                AreaLaboralLN oRegistroLN = new AreaLaboralLN();
                            
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

                    tsbNoRegistros.Text = "No. Registros: " + oRegistroLN.TotalRegistros().ToString();
                }
                else
                {
                    throw new ArgumentException(oRegistroLN.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Llenar listado de registro en la lista", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.WaitCursor;
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

                string OcultarColumnas = "";
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
                foreach (string c in ArrayColumnasDGV)
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
                                oFormato = new FormatoDGV(c1.Name.Trim(), "Cargo");
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
                            if (item.GetType() == typeof(ToolStripItem))
                            {
                                item.Enabled = oRegistroLN.VerificarSiTengoAcceso(item.Tag.ToString());
                            }
                        }
                    }
                    //Crear el pribiegio para esta operacion...
                    tsbImprimir.Enabled = oRegistroLN.VerificarSiTengoAcceso("Imprimir");
                    tsbNuevo.Enabled = oRegistroLN.VerificarSiTengoAcceso("Nuevo");
                    cmActualizar.Enabled = oRegistroLN.VerificarSiTengoAcceso("Actualizar");
                    cmEliminar.Enabled = oRegistroLN.VerificarSiTengoAcceso("Eliminar");
                    cmVisualizar.Enabled = oRegistroLN.VerificarSiTengoAcceso("Visualizar");
                    //cmImprimir.Enabled = oRegistroLN.VerificarSiTengoAcceso("Imprimir");
                }
                else
                {
                    mcsMenu.Enabled = false;
                    tsbImprimir.Enabled = false;
                    tsbNuevo.Enabled = false;
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

        private void MostrarFormularioSegunOpeacion()
        {

        }

        private void AsignarLlavePrimaria()
        {
            this.ValorLlavePrimariaEntidad = Convert.ToInt32(this.dgvLista.Rows[this.IndiceSeleccionado].Cells[this.Nombre_Llave_Primaria].Value);
        }

        private void LlenarInformacionDeEmpresa()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                EmpresaEN oRegistroEN = new EmpresaEN();
                // oRegistroLN = new MunicipioLN();
                oRegistroEN.Where = "";
                oRegistroEN.OrderBy = "";

                if (oRegistroLN.ListadoParaCombos(oRegistroEN, Program.oDatosDeConexioEN))
                {
                    cmbMunicipio.DataSource = oRegistroLN.TraerDatos();
                    cmbMunicipio.DisplayMember = "Municipio";
                    cmbMunicipio.ValueMember = "IdMunicipio";
                    cmbMunicipio.SelectedIndex = -1;
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
    }
}
