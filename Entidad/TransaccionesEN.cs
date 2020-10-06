using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class TransaccionesEN
    {
        public int IdTransacciones { set; get; }
        public int IdUsuario { set; get; }
        
        public string IP { set; get; }

        public string nombredelequipo { set; get; }

        public int IdRegistro { set; get; }
        public string TipoDeOperacion { set; get;}

        public string DescripcionInterna { set; get; }
        public string Estado { set; get; }
        public string Modelo { set; get; }
        public string Modulo { set; get; }
        public string Tabla { set; get; }
        public string DescripcionDelUsuario { set; get; }
        public int IdUsuarioAPrueva { set; get; }

        public string Where { set; get; }
        public string OrderBy { set; get; }
        public string TituloDelReporte { set; get; }
        public string SubTituloDelReporte { set; get; }

    }
}
