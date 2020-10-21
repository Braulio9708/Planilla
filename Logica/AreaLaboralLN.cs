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
    public class AreaLaboralLN
    {

        public string Error { set; get; }

        private AreaLaboralAD oAreaLaboralAD = new AreaLaboralAD();

        public bool Agregar(AreaLaboralEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            if (oAreaLaboralAD.Agregar(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oAreaLaboralAD.Error;
                return false;
            }

        }

        public bool Actualizar(AreaLaboralEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            if (string.IsNullOrEmpty(oRegistroEN.IdAreaLaboral.ToString()) || oRegistroEN.IdAreaLaboral == 0)
            {
                this.Error = @"Se debe seleccionar un elemento de la lista";
                return false;
            }
            if (oAreaLaboralAD.Actualizar(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oAreaLaboralAD.Error;
                return false;
            }

        }

        public bool Eliminar(AreaLaboralEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            if (string.IsNullOrEmpty(oRegistroEN.IdAreaLaboral.ToString()) || oRegistroEN.IdAreaLaboral == 0)
            {
                this.Error = @"Se debe seleccionar un elemento de la lista";
                return false;
            }
            if (oAreaLaboralAD.Eliminar(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oAreaLaboralAD.Error;
                return false;
            }

        }

        public bool Listado(AreaLaboralEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if(oAreaLaboralAD.Listado(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oAreaLaboralAD.Error;
                return false;
            }
        }

        public bool ListadoPorIdentificador(AreaLaboralEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if(oAreaLaboralAD.ListadoPorIdentificador(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oAreaLaboralAD.Error;
                return false;
            }
        }

        public bool ListadoParaCombos(AreaLaboralEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if (oAreaLaboralAD.ListadoParaCombos(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oAreaLaboralAD.Error;
                return false;
            }
        }

        public bool ListadoParaReportes(AreaLaboralEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if (oAreaLaboralAD.ListadoParaReportes(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oAreaLaboralAD.Error;
                return false;
            }
        }

        public bool ValidarRegistroDuplicado(AreaLaboralEN oRegistroEN, DatosDeConexionEN oDatos, string TipoDeOperacion)
        {
            if(oAreaLaboralAD.ValidarSiElRegistroEstaDuplicado(oRegistroEN, oDatos, TipoDeOperacion))
            {
                Error = oAreaLaboralAD.Error;
                return true;
            }
            else
            {
                Error = string.Empty;
                return false;
            }
        }

        public bool ValidarSiElRegistroEstaVinculado(AreaLaboralEN oRegistroEN, DatosDeConexionEN oDatos, string TipoDeOperacion)
        {
            if(oAreaLaboralAD.ValidarSiElRegistroEstaVinculado(oRegistroEN, oDatos, TipoDeOperacion))
            {
                Error = oAreaLaboralAD.Error;
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
            return oAreaLaboralAD.TraerDatos();
        }

        public int TotalRegistros()
        {
            return oAreaLaboralAD.TraerDatos().Rows.Count;
        }

    }
}
