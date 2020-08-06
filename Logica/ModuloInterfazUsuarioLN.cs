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
    public class ModuloInterfazUsuarioLN
    {
        public string Error { set; get; }

        private ModuloInterfazUsuarioAD oModuloInterfazUsuarioAD = new ModuloInterfazUsuarioAD();

        public bool Agregar(ModuloInterfazUsuarioEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oModuloInterfazUsuarioAD.Agregar(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oModuloInterfazUsuarioAD.Error;
                return false;
            }

        }

        public bool Actualizar(ModuloInterfazUsuarioEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (string.IsNullOrEmpty(oREgistroEN.IdModuloInterfazUsuario.ToString()) || oREgistroEN.IdModuloInterfazUsuario == 0)
            {

                this.Error = @"Se debe de seleccionar un elemento de la lista";
                return false;
            }

            if (oModuloInterfazUsuarioAD.Actualizar(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oModuloInterfazUsuarioAD.Error;
                return false;
            }

        }

        public bool Eliminar(ModuloInterfazUsuarioEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (string.IsNullOrEmpty(oREgistroEN.IdModuloInterfazUsuario.ToString()) || oREgistroEN.IdModuloInterfazUsuario == 0)
            {

                this.Error = @"Se debe de seleccionar un elemento de la lista";
                return false;
            }

            if (oModuloInterfazUsuarioAD.Eliminar(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oModuloInterfazUsuarioAD.Error;
                return false;
            }

        }

        public bool Listado(ModuloInterfazUsuarioEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oModuloInterfazUsuarioAD.Listado(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oModuloInterfazUsuarioAD.Error;
                return false;
            }

        }

        public bool ListadoPrivilegiosDelUsuario(ModuloInterfazUsuarioEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oModuloInterfazUsuarioAD.ListadoPrivilegiosDelUsuario(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oModuloInterfazUsuarioAD.Error;
                return false;
            }

        }

        public bool ListadoPrivilegiosDelUsuariosPorIntefaz(ModuloInterfazUsuarioEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oModuloInterfazUsuarioAD.ListadoPrivilegiosDelUsuariosPorIntefaz(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oModuloInterfazUsuarioAD.Error;
                return false;
            }

        }

        public bool ListadoPrivilegiosDelUsuariosPorModulo(ModuloInterfazUsuarioEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oModuloInterfazUsuarioAD.ListadoPrivilegiosDelUsuariosPorModulo(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oModuloInterfazUsuarioAD.Error;
                return false;
            }

        }

        public bool VerificarSiTengoAcceso(string Privilegio)
        {
            DataTable DT = oModuloInterfazUsuarioAD.TraerDatos();

            var res = from R in DT.AsEnumerable() where R.Field<string>("Privilegio").Trim().ToLower() == Privilegio.Trim().ToLower() select R.Field<Int32>("Acceso");

            if (res.Count() > 0)
            {
                int valor = res.First();
                if (valor == 1)
                    return true;
                else
                    return false;
            }
            else
                return false;

        }

        public bool VerificarSiTengoAccesoDeInterfaz(string Interfaz)
        {
            DataTable DT = oModuloInterfazUsuarioAD.TraerDatos();

            var res = from R in DT.AsEnumerable() where R.Field<string>("Interfaz").Trim().ToLower() == Interfaz.Trim().ToLower() select R.Field<Int32>("Acceso");

            if (res.Count() > 0)
            {
                int valor = res.First();
                if (valor == 1)
                    return true;
                else
                    return false;
            }
            else
                return false;

        }

        public bool ListadoPorIdentificador(ModuloInterfazUsuarioEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oModuloInterfazUsuarioAD.ListadoPorIdentificador(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oModuloInterfazUsuarioAD.Error;
                return false;
            }

        }

        public bool ListadoParaCombos(ModuloInterfazUsuarioEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oModuloInterfazUsuarioAD.ListadoParaCombos(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oModuloInterfazUsuarioAD.Error;
                return false;
            }

        }

        public bool ListadoParaReportes(ModuloInterfazUsuarioEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oModuloInterfazUsuarioAD.ListadoParaReportes(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oModuloInterfazUsuarioAD.Error;
                return false;
            }

        }

        public bool ValidarRegistroDuplicado(ModuloInterfazUsuarioEN oREgistroEN, DatosDeConexionEN oDatos, string TipoDeOperacion)
        {

            if (oModuloInterfazUsuarioAD.ValidarRegistroDuplicado(oREgistroEN, oDatos, TipoDeOperacion))
            {
                Error = oModuloInterfazUsuarioAD.Error;
                return true;
            }
            else
            {
                Error = string.Empty;
                return false;
            }

        }

        public DataTable PrivilegiosDelUsuarioEnDT()
        {

            DataTable DataDT = null;

            try
            {

                DataTable DT = oModuloInterfazUsuarioAD.TraerDatos();

                if (DT.Rows.Count > 0)
                {
                    DataDT = new DataTable();

                    DataDT.Columns.Add("Eliminar", typeof(Boolean));
                    DataDT.Columns.Add("Marcar", typeof(Boolean));
                    DataDT.Columns.Add("IdModuloInterfazUsuario", typeof(Int32));
                    DataDT.Columns.Add("idPrivilegio", typeof(Int32));
                    DataDT.Columns.Add("Privilegio", typeof(string));
                    DataDT.Columns.Add("NombreAMostrar", typeof(string));
                    DataDT.Columns.Add("Modulo", typeof(string));
                    DataDT.Columns.Add("Interfaz", typeof(string));
                    DataDT.Columns.Add("Acceso", typeof(Int32));
                    DataDT.Columns.Add("Actualizar", typeof(Boolean));

                    foreach (DataRow row in DT.Rows)
                    {
                        Boolean Acceso = false;

                        if (Convert.ToInt32(row["Acceso"]) == 1)
                            Acceso = true;

                        DataDT.Rows.Add(false,
                                       Acceso,
                                       row["IdModuloInterfazUsuario"],
                                       row["idPrivilegio"],
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
            catch (Exception ex)
            {
                this.Error = ex.Message;
            }

            return DataDT;
        }

        public DataTable TraerDatos()
        {

            return oModuloInterfazUsuarioAD.TraerDatos();

        }

        public int TotalRegistros()
        {
            return oModuloInterfazUsuarioAD.TraerDatos().Rows.Count;
        }
    }
}
