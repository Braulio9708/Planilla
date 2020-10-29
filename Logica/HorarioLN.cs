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
    public class HorarioLN
    {

        public string Error { set; get; }

        private HorarioAD oHorarioAD = new HorarioAD();

        public bool Agregar(HorarioEN oRegistro, DatosDeConexionEN oDatos)
        {
            if (oHorarioAD.Agregar(oRegistro, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oHorarioAD.Error;
                return false;
            }
        }

        public bool Actualizar(HorarioEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if (string.IsNullOrEmpty(oRegistroEN.IdHorario.ToString()) || oRegistroEN.IdHorario == 0)
            {
                this.Error = @"Se debe seleccionar un elemento de la lista.";
                return false;
            }
            if (oHorarioAD.Actualizar(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oHorarioAD.Error;
                return false;
            }
        }

        public bool Eliminar(HorarioEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if (string.IsNullOrEmpty(oRegistroEN.IdHorario.ToString()) || oRegistroEN.IdHorario == 0)
            {
                this.Error = @"Se debe seleccionar un elemento de la lista.";
                return false;
            }
            if (oHorarioAD.Eliminar(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oHorarioAD.Error;
                return false;
            }
        }

        public bool Listado(HorarioEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if (oHorarioAD.Listado(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oHorarioAD.Error;
                return false;
            }
        }

        public bool ListadoPorIdentificador(HorarioEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if(oHorarioAD.ListadoPorID(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oHorarioAD.Error;
                return false;
            }
        }

        public bool ListadoParaCombo(HorarioEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if(oHorarioAD.ListadoParaCombos(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oHorarioAD.Error;
                return false;
            }
        }

        public bool ListadoParaReportes(HorarioEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if(oHorarioAD.ListadoParaReportes(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oHorarioAD.Error;
                return false;
            }
        }

        public bool ValidarSiElRegistroEstaVinculado(HorarioEN oRegistroEN, DatosDeConexionEN oDatos, string TipoDeOperacion)
        {
            if(oHorarioAD.ValidarSiElRegistroEstaVinculado(oRegistroEN, oDatos, TipoDeOperacion))
            {
                Error = oHorarioAD.Error;
                return true;
            }
            else
            {
                Error = string.Empty;
                return false;
            }
        }

        public bool ValidarRegistroDuplicado(HorarioEN oRegistroEN, DatosDeConexionEN oDatos, string TipoDeOperacion)
        {
            if(oHorarioAD.ValidarRegistroDuplicado(oRegistroEN, oDatos, TipoDeOperacion))
            {
                Error = oHorarioAD.Error;
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
            return oHorarioAD.TraerDatos();
        }

        public int TotalRegistros()
        {
            return oHorarioAD.TraerDatos().Rows.Count;
        }

    }
}
