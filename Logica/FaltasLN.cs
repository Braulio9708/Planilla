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
    public class FaltasLN
    {

        public string Error { set; get; }

        private FaltasAD oFaltasAD = new FaltasAD();

        public bool Agregar(FaltasEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if(oFaltasAD.Agregar(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oFaltasAD.Error;
                return false;
            }
        }

        public bool Actualizar(FaltasEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if(string.IsNullOrEmpty(oRegistroEN.IdFaltas.ToString()) || oRegistroEN.IdFaltas == 0)
            {
                this.Error = @"Se debe seleccionar un elemneto de la lista.";
                return false;
            }
            else
            {
                Error = oFaltasAD.Error;
                return false;
            }
        }

        public bool Eliminar(FaltasEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if(oFaltasAD.Eliminar(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oFaltasAD.Error;
                return false;
            }
        }

        public bool Listado(FaltasEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if(oFaltasAD.Listado(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oFaltasAD.Error;
                return false;
            }
        }

        public bool ListadoPorIdentificador(FaltasEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if(oFaltasAD.ListadoPorID(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oFaltasAD.Error;
                return false;
            }
        }

        public bool ListadoParaCombos(FaltasEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if(oFaltasAD.ListadoParaCombos(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oFaltasAD.Error;
                return false;
            }
        }

        public bool ListadoParaReportes(FaltasEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            if(oFaltasAD.ListadoParaReportes(oRegistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oFaltasAD.Error;
                return false;
            }
        }

        public DataTable TraerDatos()
        {

            return oFaltasAD.TraerDatos();

        }

        public int TotalRegistros()
        {
            return oFaltasAD.TraerDatos().Rows.Count;
        }

    }
}
