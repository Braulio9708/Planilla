using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class ConfiguracionEN
    {

        //"IdConfiguracion, RutaDeRespaldos, RutaRespaldosDeExcel, PathMySQLDump, PathMySQL, TiempoDeRespaldo, ImpuestoDeValorAgrgado, CorreoDelRemitente, ServicioSmtp, ContrasenaDelRemitente, PuertoDelServidor, AsuntoDelCorreo, MensageDelCorreo"
        public int IdConfiguracion { set; get; }
        public string RutaDeRespaldo { set; get; }
        public string RutaRespaldosDeExcel { set; get; }
        public string PathMySQLDump { set; get; }
        public string PathMySQL { set; get; }        
        public string NombreDelSistema { set; get; }
        public int TiempoDeRespaldo { set; get; }
        public decimal ImpuestoDeValorAgrgado { set; get; }        
        public string CorreoDelRemitente { set; get; }
        public string ServicioSmtp { set; get; }
        public string ContrasenaDelRemitente { set; get; }
        public int PuertoDelServidor { set; get; }
        public string AsuntoDelCorreo { set; get; }
        public string MensageDelCorreo { set; get; }

        public LoginEN oLoginEN = new LoginEN();

        public string Where { set; get; }
        public string OrderBy { set; get; }
        public string TituloDelReporte { set; get; }
        public string SubTituloDelReporte { set; get; }
    }
}
