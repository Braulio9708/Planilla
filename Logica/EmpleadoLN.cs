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
    public class EmpleadoLN
    {

        public string Error { set; get; }

        private EmpleadoAD oEmpleadoAD = new EmpleadoAD();

        public bool Agregar(EmpleadoEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if(oEmpleadoAD.Agregar(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oEmpleadoAD.Error;
                return false;
            }
        }

        public bool Actualizar(EmpleadoEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if(string.IsNullOrEmpty(oRegistroEN.IdEmpleado.ToString()) || oRegistroEN.IdEmpleado == 0)
            {
                this.Error = @"Se debe seleccionar un elemento de la lista";
                return false;
            }
            if(oEmpleadoAD.Actualizar(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oEmpleadoAD.Error;
                return false;
            }
        }

        public bool Eliminar(EmpleadoEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if(string.IsNullOrEmpty(oRegistroEN.IdEmpleado.ToString()) || oRegistroEN.IdEmpleado == 0)
            {
                this.Error = @"Se debe seleccionar un elemento de la lista";
                return false;
            }
            if(oEmpleadoAD.Eliminar(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oEmpleadoAD.Error;
                return false;
            }
        }

        public bool Listado(EmpleadoEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if(oEmpleadoAD.Listado(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oEmpleadoAD.Error;
                return false;
            }
        }

        public bool ListadoPorIdentificador(EmpleadoEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if(oEmpleadoAD.ListadoPorIdentificador(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = string.Empty;
                return false;
            }
        }

        public bool ListadoParaCombos(EmpleadoEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if(oEmpleadoAD.ListadoParaCombos(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oEmpleadoAD.Error;
                return false;
            }
        }

        public bool ListadoParaReportes(EmpleadoEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if(oEmpleadoAD.ListadoParaReportes(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oEmpleadoAD.Error;
                return false;
            }
        }

        public bool ValidarSiElRegistroEstaVinculado(EmpleadoEN oRegistroEN, DatosDeConexionEN oDatos, string TipoDeOperacion)
        {
            if(oEmpleadoAD.ValidarSiElRegistroEstaVinculado(oRegistroEN, oDatos, TipoDeOperacion))
            {
                Error = oEmpleadoAD.Error;
                return true;
            }
            else
            {
                Error = string.Empty;
                return false;
            }
        }

        public bool ValidarRegistroDuplicado(EmpleadoEN oRegistroEN, DatosDeConexionEN oDatos, string TipoDeOperacion)
        {
            if(oEmpleadoAD.ValidarRegistroDuplicado(oRegistroEN, oDatos, TipoDeOperacion))
            {
                Error = oEmpleadoAD.Error;
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
            return oEmpleadoAD.TraerDatos();
        }

        public int TotalRegistros()
        {
            return oEmpleadoAD.TraerDatos().Rows.Count;
        }

    }
}
