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
    public class MunicipioLN
    {

        public string Error { set; get; }

        public MunicipoAD oMunicipioAD = new MunicipoAD();

        public bool Agregar(MunicipioEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if(oMunicipioAD.Agregar(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oMunicipioAD.Error;
                return false;
            }
        }

        public bool Actualizar(MunicipioEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if(string.IsNullOrEmpty(oRegistroEN.IdMunicipio.ToString()) || oRegistroEN.IdMunicipio == 0)
            {
                this.Error = string.Format("Se debe seleccionar un elemento de la lista.");
                return false;
            }
            if(oMunicipioAD.Actualizar(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oMunicipioAD.Error;
                return false;
            }
        }

        public bool Eliminar(MunicipioEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if(string.IsNullOrEmpty(oRegistroEN.IdMunicipio.ToString()) || oRegistroEN.IdMunicipio == 0)
            {
                this.Error = string.Format("Se debe seleccionar un elemento de la lista.");
                return false;
            }
            if(oMunicipioAD.Eliminar(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oMunicipioAD.Error;
                return false;
            }
        }

        public bool Listado(MunicipioEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if(oMunicipioAD.Listado(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oMunicipioAD.Error;
                return false;
            }
        }

        public bool ListadoPorIdentificador(MunicipioEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if(oMunicipioAD.ListadoPorIdentificador(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oMunicipioAD.Error;
                return false;
            }
        }

        public bool ListadoParaCombos(MunicipioEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if(oMunicipioAD.ListadoParaCombos(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oMunicipioAD.Error;
                return false;
            }
        }

        public bool ListadoParaReportes(MunicipioEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if(oMunicipioAD.ListadoParaReportes(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oMunicipioAD.Error;
                return false;
            }
        }

        public bool ValidarRegistroDuplicado(MunicipioEN oRegistroEN, DatosDeConexionEN oDatos, string TipoDeOperacion)
        {
            if(oMunicipioAD.ValidarRegistroDuplicado(oRegistroEN, oDatos, TipoDeOperacion))
            {
                Error = oMunicipioAD.Error;
                return true;
            }
            else
            {
                Error = string.Empty;
                return false;
            }
        }

        public bool ValidarSiElRegistroEstaVinculado(MunicipioEN oRegistro, DatosDeConexionEN oDatos, string TipoDeOperacion)
        {
            if(oMunicipioAD.ValidarSiElRegistroEstaVinculado(oRegistro, oDatos, TipoDeOperacion))
            {
                Error = oMunicipioAD.Error;
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
            return oMunicipioAD.TraerDatos();
        }

        public int TotalRegistros()
        {
            return oMunicipioAD.TraerDatos().Rows.Count;
        }

    }
}
