using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class ExtrasEN
    {
        //IdExtras, HorasExtras, PrecioHora, FechaHorasExtras, IdEmpleado, IdPlanilla;

        public int IdExtras { set; get; }
        public decimal HorasExtras { set; get; }
        public decimal PrecioHora { set; get; }
        public DateTime FechaHorasExtras { set; get; }

        public EmpleadoEN oEmpleadoEN = new EmpleadoEN();
        public PlanillaEN oPlanillaEN = new PlanillaEN();
        public LoginEN oLoginEN = new LoginEN();

        public string Where { set; get; }
        public string OrderBy { set; get; }
        public string TituloDelReporte { set; get; }
        public string SubTituloDelReporte { set; get; }

    }
}
