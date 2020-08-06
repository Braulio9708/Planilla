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
    public class ContratoLN
    {

        public string Error { set; get; }

        private ContratoAD oContratoAD = new ContratoAD();

        public bool Agregar(ContratoEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if (oContratoAD.Agregar(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oContratoAD.Error;
                return false;
            }
        }

        public bool Actualizar(ContratoEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if (string.IsNullOrEmpty(oRegistroEN.IdContrato.ToString()) || oRegistroEN.IdContrato == 0)
            {
                this.Error = @"Se debe seleccionar un elemento de la lista";
                return false;
            }
            if (oContratoAD.Actualizar(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oContratoAD.Error;
                return false;
            }
        }

        public bool Eliminar(ContratoEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (string.IsNullOrEmpty(oREgistroEN.IdContrato.ToString()) || oREgistroEN.IdContrato == 0)
            {

                this.Error = @"Se debe de seleccionar un elemento de la lista";
                return false;
            }

            if (oContratoAD.Eliminar(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oContratoAD.Error;
                return false;
            }

        }

        public bool Listado(ContratoEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oContratoAD.Listado(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oContratoAD.Error;
                return false;
            }

        }

        public bool ListadoPorID(ContratoEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oContratoAD.ListadoPorID(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oContratoAD.Error;
                return false;
            }

        }

        public bool ListadoParaCombos(ContratoEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oContratoAD.ListadoParaCombos(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oContratoAD.Error;
                return false;
            }

        }

        public bool ListadoParaReportes(ContratoEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oContratoAD.ListadoParaReportes(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oContratoAD.Error;
                return false;
            }

        }

        public DataTable TraerDatos()
        {
            return oContratoAD.TraerDatos();
        }

        public int TotalRegistros()
        {
            return oContratoAD.TraerDatos().Rows.Count;
        }

    }
}
