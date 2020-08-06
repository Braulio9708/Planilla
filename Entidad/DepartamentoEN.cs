using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class DepartamentoEN
    {
        //"IdDepartamento, Departamento, IdPais"
        public int IdDepartamento { set; get; }
        public string Departamento { set; get; }

        public PaisEN oPaisEN = new PaisEN();
        public LoginEN oLoginEN = new LoginEN();

        public string Where { set; get; }
        public string OrderBy { set; get; }
        public string TituloDelReporte { set; get; }
        public string SubTituloDelReporte { set; get; }
    }
}
