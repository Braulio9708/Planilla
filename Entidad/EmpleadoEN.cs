using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class EmpleadoEN
    {
        //"IdEmpleado, Nombre, Apellidos, Cedula, Direccion, Telefono, Celular, Correo, IdCargo, IdMunicipio, IdAreaLaboral"
        public int IdEmpleado { set; get; }
        public string Nombre { set; get; }
        public string Apellidos {set; get; }
        public string Cedula { set; get; }
        public string Direccion { set; get; }
        public string Telefono { set; get; }
        public string Celular { set; get; }
        public string Correo { set; get; }
        public string NoINSS { set; get; }

        public CargoEN oCargoEN = new CargoEN();
        public MunicipioEN oMunicipioEN = new MunicipioEN();        
        public AreaLaboralEN oAreaLaboralEN = new AreaLaboralEN();
        public LoginEN oLoginEN = new LoginEN();

        public string Where { set; get; }
        public string OrderBy { set; get; }
        public string TituloDelReporte { set; get; }
        public string SubTituloDelReporte { set; get; }
    }
}
