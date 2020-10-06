using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Acceso;
using System.Data;

namespace Logica
{
    public class ModuloInterfazRolLN
    {
        public string Error { set; get; }

        private ModuloInterfazRolAD oModuloInterfazRolAD = new ModuloInterfazRolAD();

        public bool Agregar(ModuloInterfazRolEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oModuloInterfazRolAD.Agregar(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oModuloInterfazRolAD.Error;
                return false;
            }

        }

        public bool Actualizar(ModuloInterfazRolEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if(string.IsNullOrEmpty(oRegistroEN.IdModuloInterfazRol.ToString()) || oRegistroEN.IdModuloInterfazRol == 0)
            {
                this.Error = @"Se debe seleccionar un elemento de la lista";
                return false;
            }
            if(oModuloInterfazRolAD.Actualizar(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oModuloInterfazRolAD.Error;
                return false;
            }
        }

        public bool Eliminar(ModuloInterfazRolEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if(string.IsNullOrEmpty(oRegistroEN.IdModuloInterfazRol.ToString()) || oRegistroEN.IdModuloInterfazRol == 0)
            {
                this.Error = @"Se debe seleccionar un elemento de la lista";
                return false;
            }
            if(oModuloInterfazRolAD.Eliminar(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oModuloInterfazRolAD.Error;
                return false;
            }
        }

        public bool Listado(ModuloInterfazRolEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if(oModuloInterfazRolAD.Listado(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oModuloInterfazRolAD.Error;
                return false;
            }
        }

        public bool ListadoDePrivilegiosParaElUsuario(ModuloInterfazRolEN oRegistrEN, DatosDeConexionEN oDatos)
        {
            if(oModuloInterfazRolAD.ListadoDePrivilegiosParaELUsuario(oRegistrEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oModuloInterfazRolAD.Error;
                return false;
            }
        }

        public bool ListadoDePrivilegiosDelRol(ModuloInterfazRolEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if(oModuloInterfazRolAD.ListadoDePrivilegioDelRol(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oModuloInterfazRolAD.Error;
                return false;
            }
        }
        public bool ListadoPorIdentificador(ModuloInterfazRolEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if(oModuloInterfazRolAD.ListadoPorIdentificador(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oModuloInterfazRolAD.Error;
                return false;
            }
        }

        public bool ListadoParaCombos(ModuloInterfazRolEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if(oModuloInterfazRolAD.ListadoParaCombos(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oModuloInterfazRolAD.Error;
                return false;
            }
        }

        public bool ListadoParaReportes(ModuloInterfazRolEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if(oModuloInterfazRolAD.ListadoParaReportes(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oModuloInterfazRolAD.Error;
                return false;
            }
        }

        public bool ValidarRegistroDuplicado(ModuloInterfazRolEN oRegistroEN, DatosDeConexionEN oDatos, string TipoDeOperacion)
        {
            if(oModuloInterfazRolAD.ValidarRegistroDuplicado(oRegistroEN, oDatos, TipoDeOperacion))
            {
                Error = oModuloInterfazRolAD.Error;
                return true;
            }
            else
            {
                Error = string.Empty;
                return false;
            }
        }

        public DataTable TraerDatos()
        {
            return oModuloInterfazRolAD.TraerDatos();
        }

        public int TotalRegistros()
        {
            return oModuloInterfazRolAD.TraerDatos().Rows.Count;
        }
        public DataTable PrivilegiosDelRolParaUsuarioDT()
        {
            DataTable DataDT = null;
            try
            {
                if(DataDT.Rows.Count > 0)
                {
                    DataDT = new DataTable();

                    DataDT.Columns.Add("Eliminar", typeof(Boolean));
                    DataDT.Columns.Add("Marcar", typeof(Boolean));
                    DataDT.Columns.Add("IdModuloInterfazUsuario", typeof(Int32));
                    DataDT.Columns.Add("IdPrivilegio", typeof(Int32));
                    DataDT.Columns.Add("Privilegio", typeof(string));
                    DataDT.Columns.Add("NombreAMostrar", typeof(string));
                    DataDT.Columns.Add("Modulo", typeof(string));
                    DataDT.Columns.Add("Interfaz", typeof(string));
                    DataDT.Columns.Add("Acceso", typeof(Int32));
                    DataDT.Columns.Add("Actualizar", typeof(Boolean));

                    foreach(DataRow row in DataDT.Rows)
                    {
                        Boolean Acceso = false;

                        if (Convert.ToInt32(row["Acceso"]) == 1)
                            Acceso = true;

                        DataDT.Rows.Add(false, Acceso,
                            row["IdModuloInterfazUsuario"],
                            row["IdPrivilegio"],
                            row["Privilegio"],
                            row["Modulo"],
                            row["Interfaz"],
                            Convert.ToInt32(row["Acceso"]),
                            true);
                    }
                }
                else
                {
                    return DataDT;
                }
            }
            catch(Exception ex)
            {
                this.Error = ex.Message;
            }
            return DataDT;
        }

        public DataTable PrivilegiosDelRolDT()
        {
            DataTable DataDT = null;

            try
            {
                DataTable DT = oModuloInterfazRolAD.TraerDatos();

                if(DT.Rows.Count > 0)
                {
                    DataDT = new DataTable();

                    DataDT.Columns.Add("Eliminar", typeof(Boolean));
                    DataDT.Columns.Add("Marcar", typeof(Boolean));
                    DataDT.Columns.Add("IdModuloInterfazRol", typeof(Int32));
                    DataDT.Columns.Add("IdPrivilegio", typeof(Int32));
                    DataDT.Columns.Add("Privilegio", typeof(string));
                    DataDT.Columns.Add("NombreAMostrar", typeof(string));
                    DataDT.Columns.Add("Modulo", typeof(string));
                    DataDT.Columns.Add("Interfaz", typeof(string));
                    DataDT.Columns.Add("Acceso", typeof(Int32));
                    DataDT.Columns.Add("Actualizar", typeof(Boolean));

                    foreach(DataRow row in DT.Rows)
                    {
                        Boolean Acceso = false;

                        if(Convert.ToInt32(row["Acceso"]) == 1)
                        
                            Acceso = true;

                            DataDT.Rows.Add(false,
                                Acceso,
                                row["IdmoduloInterfazRol"],
                                row["IdPrivilegio"],
                                row["Privilegio"],
                                row["NombreAMostrar"],
                                row["Modulo"],
                                row["Interfaz"],
                                Convert.ToInt32(row["Acceso"]),
                                true);
                        
                    }
                }
                else
                {
                    return DataDT;
                }
            }
            catch(Exception ex)
            {
                this.Error = ex.Message;
            }
            return DataDT;
        }
    }
}
