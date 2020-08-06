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
    class DeduccionesLN
    {

        public string Error { set; get; }

        private DeduccionesAD oDeduccionesAD = new DeduccionesAD();

        public bool Agregar(DeduccionesEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if(oDeduccionesAD.Agregar(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oDeduccionesAD.Error;
                return false;
            }
        }

        public bool Actualizar(DeduccionesEN oRegistrEN, DatosDeConexionEN oDatos)
        {
            if (string.IsNullOrEmpty(oRegistrEN.IdDeducciones.ToString()) || oRegistrEN.IdDeducciones == 0)
            {
                this.Error = @"Se debe seleccionar un elemento de la lista";
                return false;
            }
            if (oDeduccionesAD.Actualizar(oRegistrEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oDeduccionesAD.Error;
                return false;
            }
        }

        public bool Eliminar(DeduccionesEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (string.IsNullOrEmpty(oREgistroEN.IdDeducciones.ToString()) || oREgistroEN.IdDeducciones == 0)
            {

                this.Error = @"Se debe de seleccionar un elemento de la lista";
                return false;
            }

            if (oDeduccionesAD.Eliminar(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oDeduccionesAD.Error;
                return false;
            }

        }

        public bool Listado(DeduccionesEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oDeduccionesAD.Listado(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oDeduccionesAD.Error;
                return false;
            }

        }

        public bool ListadoPorID(DeduccionesEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oDeduccionesAD.ListadoPorID(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oDeduccionesAD.Error;
                return false;
            }

        }

        public bool ListadoParaCombos(DeduccionesEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oDeduccionesAD.ListadoParaCombos(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oDeduccionesAD.Error;
                return false;
            }

        }

        public bool ListadoParaReportes(DeduccionesEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oDeduccionesAD.ListadoParaReportes(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oDeduccionesAD.Error;
                return false;
            }

        }

        public DataTable TraerDatos()
        {
            return oDeduccionesAD.TraerDatos();
        }

        public int TotalRegistros()
        {
            return oDeduccionesAD.TraerDatos().Rows.Count;
        }

    }
}
