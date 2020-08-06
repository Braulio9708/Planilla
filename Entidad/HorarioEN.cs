using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class HorarioEN
    {
        //"IdHorario, HoraDeEntrada, HoraDeSalida, IdEmpleado"
        public int IdHorario { set; get; }
        public DateTime HoraDeEntrada { set; get; }
        public DateTime HoraDeSalida { set; get; }

        public EmpleadoEN oEmpleadoEN = new EmpleadoEN();
        public LoginEN oLoginEN = new LoginEN();

        public string Where { set; get; }
        public string OrderBy { set; get; }
        public string TituloDelReporte { set; get; }
        public string SubTituloDelReporte { set; get; }
    }
}
