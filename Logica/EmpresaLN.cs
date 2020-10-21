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
    public class EmpresaLN
    {

        public string Error { set; get; }

        private EmpresaAD oEmpresaAD = new EmpresaAD();

        public bool Agregar(EmpresaEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if(oEmpresaAD.Agregar(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oEmpresaAD.Error;
                return false;
            }
        }

        public bool Actualizar(EmpresaEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if(string.IsNullOrEmpty(oRegistroEN.IdEmpresa.ToString()) || oRegistroEN.IdEmpresa == 0)
            {
                this.Error = string.Format("Se debe seleccionar un elemento  de la lista.");
                return false;
            }
            if(oEmpresaAD.Actualizar(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oEmpresaAD.Error;
                return false;
            }
        }

        public bool Eliminar(EmpresaEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if(string.IsNullOrEmpty(oRegistroEN.IdEmpresa.ToString()) || oRegistroEN.IdEmpresa == 0)
            {
                this.Error = string.Format("Se debe seleccionarun elemento de la lista.");
                return false;
            }
            if(oEmpresaAD.Eliminar(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oEmpresaAD.Error;
                return false;
            }
        }

        public bool Listado(EmpresaEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if(oEmpresaAD.Listado(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oEmpresaAD.Error;
                return false;
            }
        }

        public bool ListadoPorIdentificador(EmpresaEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if(oEmpresaAD.ListadoPorID(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oEmpresaAD.Error;
                return false;
            }
        }

        public bool ListadoParaCombos(EmpresaEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if(oEmpresaAD.ListadoParaCombos(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oEmpresaAD.Error;
                return false;
            }
        }

        public bool ListadoParaReportes(EmpresaEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if(oEmpresaAD.ListadoParaReportes(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oEmpresaAD.Error;
                return false;
            }
        }

        public bool ValidarRegistroDuplicado(EmpresaEN oRegistroEN, DatosDeConexionEN oDatos, string TipoDeOperacion)
        {
            if(oEmpresaAD.ValidarRegistroDuplicado(oRegistroEN, oDatos, TipoDeOperacion))
            {
                Error = oEmpresaAD.Error;
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
            return oEmpresaAD.TraerDatos();
        }

        public int TotalRegistros()
        {
            return oEmpresaAD.TraerDatos().Rows.Count;
        }

    }
}
