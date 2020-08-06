using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class LoginEN
    {
        //"IdUsuario, NombreUsuario, TipoDeCuenta, Ip,NombreDelEquipo"
        public int IdUsuario { set; get; }
        public string NombreUsuario { set; get; }
        public string TipoDeCuenta { set; get; }
        public string IP { set; get; }
        public string NumeroIP { set; get; }
        public string NombreDelEquipo { set; get; }

        public string Login { set; get; }
        public string Contrasena { set; get; }

    }
}
