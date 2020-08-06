using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class EmpresaEN
    {
        //IdEmpresa, Nombre, Direccion, Telefono, NRuc, oLogo, ALogo, Celular, EMail, SitioWeb, Descripcion
        public int IdEmpresa { set; get; }
        public string Nombre { set; get; }
        public string Direccion { set; get; }
        public string Telefono { set; get; }
        public string NRuc { set; get; }

        /// <summary>
        /// Variable de tipo Objeto para la imagen de la Empresa
        /// </summary>
        public Object oLogo { set; get; }
        /// <summary>
        /// Variable de tipo Arreglo para la imagen de la Empresa
        /// </summary>
        public byte[] ALogo { set; get; }
        
        public string Celular { set; get; }
        public string Email { set; get; }
        public string SitioWeb { set; get; }
        public string Descripcion { set; get; }

        public UsuarioEN oUsuarioEN = new UsuarioEN();
        public LoginEN oLoginEN = new LoginEN();

        public string Where { set; get; }
        public string OrderBy { set; get; }
        public string TituloDelReporte { set; get; }
        public string SubTituloDelReporte { set; get; }
    }
}
