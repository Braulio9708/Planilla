using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class DeduccionesEN
    {
        //"IdDeducciones, INSS, IR, Prestamos, TotalDeduccines, IdDetalleDeDeducciones"
        public int IdDeducciones { set; get; }
        public decimal INSS { set; get; }
        public decimal IR { set; get; }
        public decimal Prestamos { set; get; }
        public decimal TotalDeDeducciones { set; get; }

        public DetalleDeDeduccionesEN oDetalleDeDeduccionesEN = new DetalleDeDeduccionesEN();
        public LoginEN oLoginEN = new LoginEN();

        public string Where { set; get; }
        public string OrderBy { set; get; }
        public string TituloDelReporte { set; get; }
        public string SubTituloDelReporte { set; get; }
    }
}
