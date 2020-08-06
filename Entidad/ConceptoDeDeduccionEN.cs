using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class ConceptoDeDeduccionEN
    {
        //"IdConceptoDeDeduccion, ConceptoDeDeduccion"
        public int IdConceptoDeDeduccion { set; get; }
        public string ConceptoDeDeduccion { set; get; }

        public LoginEN oLoginEN = new LoginEN();

        public string Where { set; get; }
        public string OrderBy { set; get; }
        public string TituloDelReporte { set; get; }
        public string SubTituloDelReporte { set; get; }
    }
}
