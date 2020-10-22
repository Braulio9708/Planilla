using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class CiudadEN
    {
        //"IdMunicipio, Municipio, IdDepartamento
        public int IdCiudad { set; get; }
        public string Ciudad { set; get; }

        //public DepartamentoEN oDepartamentoEN = new DepartamentoEN();
        public LoginEN oLoginEN = new LoginEN();

        public string Where { set; get; }
        public string OrderBy { set; get; }
        public string TituloDelReporte { set; get; }
        public string SubTituloDelReporte { set; get; }
    }
}
