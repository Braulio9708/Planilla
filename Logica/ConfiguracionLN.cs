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
    public class ConfiguracionLN
    {

        public string Error { set; get; }

        private ConfiguracionAD oConfiguracionAD = new ConfiguracionAD();

        public bool Agregar(ConfiguracionEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if(oConfiguracionAD.Agregar(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oConfiguracionAD.Error;
                return false;
            }
        }
        public bool Actualizar(ConfiguracionEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if (string.IsNullOrEmpty(oRegistroEN.IdConfiguracion.ToString()) || oRegistroEN.IdConfiguracion == 0)
            {
                this.Error = @"Se debe seleccionar un elemento de la lista";
                return false;
            }
            if (oConfiguracionAD.Actualizar(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oConfiguracionAD.Error;
                return false;
            }
        }

        public bool Eliminar(ConfiguracionEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            if (string.IsNullOrEmpty(oRegistroEN.IdConfiguracion.ToString()) || oRegistroEN.IdConfiguracion == 0)
            {

                this.Error = @"Se debe de seleccionar un elemento de la lista";
                return false;
            }

            if (oConfiguracionAD.Eliminar(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oConfiguracionAD.Error;
                return false;
            }

        }

        public bool Listado(ConfiguracionEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            if (oConfiguracionAD.Listado(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oConfiguracionAD.Error;
                return false;
            }

        }

        public bool ListadoPorIdentificador(ConfiguracionEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            if (oConfiguracionAD.ListadoPorIdentificador(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oConfiguracionAD.Error;
                return false;
            }

        }

        public bool ListadoParaCombos(ConfiguracionEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            if (oConfiguracionAD.ListadoParaCombos(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oConfiguracionAD.Error;
                return false;
            }

        }

        public bool ListadoParaReportes(ConfiguracionEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            if (oConfiguracionAD.ListadoParaReportes(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oConfiguracionAD.Error;
                return false;
            }

        }

        public DataTable TraerDatos()
        {
            return oConfiguracionAD.TraerDatos();
        }

        public int TotalRegistros()
        {
            return oConfiguracionAD.TraerDatos().Rows.Count;
        }

    }
}
