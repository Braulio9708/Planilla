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
    public class CargoLN
    {
        public string Error { set; get; }

        private CargoAD oCargoAD = new CargoAD();

        public bool Agregar(CargoEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if(oCargoAD.Agregar(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oCargoAD.Error;
                return false;
            }
        }

        public bool Actualizar(CargoEN oRegistrEN, DatosDeConexionEN oDatos)
        {
            if(string.IsNullOrEmpty(oRegistrEN.IdCargo.ToString()) || oRegistrEN.IdCargo == 0)
            {
                this.Error = @"Se debe seleccionar un elemento de la lista";
                return false;
            }
            if(oCargoAD.Actualizar(oRegistrEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oCargoAD.Error;
                return false;
            }
        }

        public bool Eliminar(CargoEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (string.IsNullOrEmpty(oREgistroEN.IdCargo.ToString()) || oREgistroEN.IdCargo == 0)
            {

                this.Error = @"Se debe de seleccionar un elemento de la lista";
                return false;
            }

            if (oCargoAD.Eliminar(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oCargoAD.Error;
                return false;
            }

        }

        public bool Listado(CargoEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oCargoAD.Listado(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oCargoAD.Error;
                return false;
            }

        }

        public bool ListadoPorIdentificador(CargoEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oCargoAD.ListadoPorID(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oCargoAD.Error;
                return false;
            }

        }

        public bool ListadoParaCombos(CargoEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oCargoAD.ListadoParaCombos(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oCargoAD.Error;
                return false;
            }

        }

        public bool ListadoParaReportes(CargoEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oCargoAD.ListadoParaReportes(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oCargoAD.Error;
                return false;
            }

        }

        public bool ValidarRegistroDuplicado(CargoEN oREgistroEN, DatosDeConexionEN oDatos, string TipoDeOperacion)
        {

            if (oCargoAD.ValidarRegistroDuplicado(oREgistroEN, oDatos, TipoDeOperacion))
            {
                Error = oCargoAD.Error;
                return true;
            }
            else
            {
                Error = string.Empty;
                return false;
            }

        }

        public bool ValidarSiElRegistroEstaVinculado(CargoEN oREgistroEN, DatosDeConexionEN oDatos, string TipoDeOperacion)
        {

            if (oCargoAD.ValidarSiElRegistroEstaVinculado(oREgistroEN, oDatos, TipoDeOperacion))
            {
                Error = oCargoAD.Error;
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

            return oCargoAD.TraerDatos();

        }

        public int TotalRegistros()
        {
            return oCargoAD.TraerDatos().Rows.Count;
        }

    }
}
