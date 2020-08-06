using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class ContratoEN
    {
        //"IdContrato, TipoDeContrato, FechaDeInicio, FechaDeFin, NumeroDeContrato, IdEmpleado"
        public int IdContrato { set; get; }
        public string TipoDeContrato { set; get; }
        public DateTime FechaDeInicio { set; get; }
        public DateTime FechaDeFin { set; get; }
        public int NumeroDeContrato { set; get; }

        public EmpleadoEN oEmpladoEN = new EmpleadoEN();
        public LoginEN oLoginEN = new LoginEN();

        public string Where { set; get; }
        public string OrderBy { set; get; }
        public string TituloDelReporte { set; get; }
        public string SubTituloDelReporte { set; get; }
    }
}
