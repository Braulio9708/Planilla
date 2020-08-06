using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{    
    public class AreaLaboralEN
    {
        //"IdAreaLaboral, Area, IdEmpresa"
        public int IdAreaLaboral { set; get; }
        public string Area { set; get; }

        public EmpresaEN oEmpresaEN = new EmpresaEN();
        public LoginEN oLoginEN = new LoginEN();

        public string Where { set; get; }
        public string OrderBy { set; get; }
        public string TituloDelReporte { set; get; }
        public string SubTituloDelReporte { set; get; }
    }
}
