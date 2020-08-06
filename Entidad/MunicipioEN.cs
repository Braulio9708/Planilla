using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class MunicipioEN
    {
        //"IdMunicipio, Municipio, IdDepartamento
        public int IdMunicipio { set; get; }
        public string Municipio { set; get; }

        public DepartamentoEN oDepartamentoEN = new DepartamentoEN();
        public LoginEN oLoginEN = new LoginEN();

        public string Where { set; get; }
        public string OrderBy { set; get; }
        public string TituloDelReporte { set; get; }
        public string SubTituloDelReporte { set; get; }
    }
}
