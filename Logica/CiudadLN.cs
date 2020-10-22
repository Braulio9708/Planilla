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
    public class CiudadLN
    {

        public string Error { set; get; }

        public CiudadAD oCiudadAD = new CiudadAD();

        public bool Agregar(CiudadEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            
            if (oCiudadAD.Agregar(oRegistroEN, oDatos))
            {                
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oCiudadAD.Error;
                return false;
            }
        }

        public bool Actualizar(CiudadEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if(string.IsNullOrEmpty(oRegistroEN.IdCiudad.ToString()) || oRegistroEN.IdCiudad == 0)
            {
                this.Error = string.Format("Se debe seleccionar un elemento de la lista.");
                return false;
            }
            if(oCiudadAD.Actualizar(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oCiudadAD.Error;
                return false;
            }
        }

        public bool Eliminar(CiudadEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if(string.IsNullOrEmpty(oRegistroEN.IdCiudad.ToString()) || oRegistroEN.IdCiudad == 0)
            {
                this.Error = string.Format("Se debe seleccionar un elemento de la lista.");
                return false;
            }
            if(oCiudadAD.Eliminar(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oCiudadAD.Error;
                return false;
            }
        }

        public bool Listado(CiudadEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if(oCiudadAD.Listado(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oCiudadAD.Error;
                return false;
            }
        }

        public bool ListadoPorIdentificador(CiudadEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if(oCiudadAD.ListadoPorIdentificador(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oCiudadAD.Error;
                return false;
            }
        }

        public bool ListadoParaCombos(CiudadEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if(oCiudadAD.ListadoParaCombos(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oCiudadAD.Error;
                return false;
            }
        }

        public bool ListadoParaReportes(CiudadEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if(oCiudadAD.ListadoParaReportes(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oCiudadAD.Error;
                return false;
            }
        }

        public bool ValidarRegistroDuplicado(CiudadEN oRegistroEN, DatosDeConexionEN oDatos, string TipoDeOperacion)
        {
            if(oCiudadAD.ValidarRegistroDuplicado(oRegistroEN, oDatos, TipoDeOperacion))
            {
                Error = oCiudadAD.Error;
                return true;
            }
            else
            {
                Error = string.Empty;
                return false;
            }
        }

        public bool ValidarSiElRegistroEstaVinculado(CiudadEN oRegistro, DatosDeConexionEN oDatos, string TipoDeOperacion)
        {
            if(oCiudadAD.ValidarSiElRegistroEstaVinculado(oRegistro, oDatos, TipoDeOperacion))
            {
                Error = oCiudadAD.Error;
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
            return oCiudadAD.TraerDatos();
        }

        public int TotalRegistros()
        {
            return oCiudadAD.TraerDatos().Rows.Count;
        }

    }
}
