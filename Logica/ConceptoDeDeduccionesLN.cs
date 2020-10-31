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
    public class ConceptoDeDeduccionesLN
    {

        public string Error { set; get; }

        private ConceptoDeDeduccionAD oConceptoDeDeduccionAD = new ConceptoDeDeduccionAD();

        public bool Agregar(ConceptoDeDeduccionEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if (oConceptoDeDeduccionAD.Agregar(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oConceptoDeDeduccionAD.Error;
                return false;
            }
        }

        public bool Actualizar(ConceptoDeDeduccionEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if(string.IsNullOrEmpty(oRegistroEN.IdConceptoDeDeduccion.ToString()) || oRegistroEN.IdConceptoDeDeduccion == 0)
            {
                this.Error = @"Se debe seleccionar un elemento de la lista";
                return false;
            }
            if(oConceptoDeDeduccionAD.Actualizar(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oConceptoDeDeduccionAD.Error;
                return false;
            }
        }

        public bool Eliminar(ConceptoDeDeduccionEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (string.IsNullOrEmpty(oREgistroEN.IdConceptoDeDeduccion.ToString()) || oREgistroEN.IdConceptoDeDeduccion == 0)
            {

                this.Error = @"Se debe de seleccionar un elemento de la lista";
                return false;
            }

            if (oConceptoDeDeduccionAD.Eliminar(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oConceptoDeDeduccionAD.Error;
                return false;
            }

        }

        public bool Listado(ConceptoDeDeduccionEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oConceptoDeDeduccionAD.Listado(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oConceptoDeDeduccionAD.Error;
                return false;
            }

        }

        public bool ListadoPorID(ConceptoDeDeduccionEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oConceptoDeDeduccionAD.ListadoPorID(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oConceptoDeDeduccionAD.Error;
                return false;
            }

        }

        public bool ListadoParaCombos(ConceptoDeDeduccionEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oConceptoDeDeduccionAD.ListadoParaCombos(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oConceptoDeDeduccionAD.Error;
                return false;
            }

        }

        public bool ListadoParaReportes(ConceptoDeDeduccionEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oConceptoDeDeduccionAD.ListadoParaReportes(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oConceptoDeDeduccionAD.Error;
                return false;
            }

        }

        public bool ValidarSiElRegistroEstaVinculado(ConceptoDeDeduccionEN oRegistroEN, DatosDeConexionEN oDatos, string TipoDeOperacion)
        {
            if(oConceptoDeDeduccionAD.ValidarSiElRegistroEstaVinculado(oRegistroEN, oDatos, TipoDeOperacion))
            {
                Error = oConceptoDeDeduccionAD.Error;
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
            return oConceptoDeDeduccionAD.TraerDatos();
        }

        public int TotalRegistros()
        {
            return oConceptoDeDeduccionAD.TraerDatos().Rows.Count;
        }

    }
}
