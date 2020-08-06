using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class PrestacionesEN
    {

        //IdPrestaciones, Aguinaldo, Antiguedad, Liquidacion, Vacaciones, IdEmpleado;

        public int IdPrestaciones { set; get; }
        public decimal Aguinaldo { set; get; }
        public decimal Antiguedad { set; get; }
        public decimal Liquidacion { set; get; }
        public decimal Vacaciones { set; get; }

        public EmpleadoEN oEmpleadoEN = new EmpleadoEN();
        public LoginEN oLoginEN = new LoginEN();

        public string Where { set; get; }
        public string OrderBy { set; get; }
        public string TituloDelReporte { set; get; }
        public string SubTituloDelReporte { set; get; }

    }
}
