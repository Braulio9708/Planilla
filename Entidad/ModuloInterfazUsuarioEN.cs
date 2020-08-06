using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class ModuloInterfazUsuarioEN
    {
        //"IdModuloInterfazUsuario, Acceso, IdUsuarioDeCreacion, FechaDeCreacion, IdUsuarioDeModificacion, FechaDeModificacion, IdUsuario, IdPrivilegio"
        public int IdModuloInterfazUsuario { set; get; }
        public int Acceso { set; get; }
        public int IdUsuarioDeCreacion { set; get; }
        public DateTime FechaDeCreacion { set; get; }
        public int IdUsuarioDeModificacion { set; get; }
        public DateTime FechaDeModificacion { set; get; }

        public UsuarioEN oUsuarioEN = new UsuarioEN();
        public PrivilegioEN oPrivilegioEN = new PrivilegioEN();
        public LoginEN oLoginEN = new LoginEN();

        public string Where { set; get; }
        public string OrderBy { set; get; }
        public string TituloDelReporte { set; get; }
        public string SubTituloDelReporte { set; get; }
    }
}
