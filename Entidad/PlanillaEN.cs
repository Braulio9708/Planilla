using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class PlanillaEN
    {
        //"IdPlanilla, SalarioBase, PagoHorasExtras, Comicion, IdEmpleado, IdDeducciones"
        public int IdPlanilla { set; get; }
        public decimal SalarioBase { set; get; }
        public decimal PagoHorasExtras { set; get; }
        public decimal Comicion { set; get; }

        public EmpleadoEN oEmpleadoEN = new EmpleadoEN();
        public DeduccionesEN oDeducciones = new DeduccionesEN();
        public LoginEN oLoginEN = new LoginEN();

        public string Where { set; get; }
        public string OrderBy { set; get; }
        public string TituloDelReporte { set; get; }
        public string SubTituloDelReporte { set; get; }
    }
}
