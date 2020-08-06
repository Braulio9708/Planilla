using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class DetalleDeDeduccionesEN
    {
        //"IdDetalleDeDeducciones, Cuotas, MontoPorCuota, IdConceptoDeDeduccion"
        public int IdDetalleDeDeducciones { set; get; }
        public int Cuota { set; get; }
        public decimal MontoPorCuota { set; get; }

        public ConceptoDeDeduccionEN oConceptoDeDeduccionEN = new ConceptoDeDeduccionEN();
        public LoginEN oLoginEN = new LoginEN();

        public string Where { set; get; }
        public string OrderBy { set; get; }
        public string TituloDelReporte { set; get; }
        public string SubTituloDelReporte { set; get; }
    }
}
