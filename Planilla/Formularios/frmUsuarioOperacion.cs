using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidad;
using Logica;
using Funciones;

namespace Planilla.Formularios
{
    public partial class frmUsuarioOperacion : Form
    {
        public frmUsuarioOperacion()
        {
            InitializeComponent();
        }

        public string OperacionARealizar { set; get; }
        public string Nombre_Entidad_Privilegio { set; get; }
        public string Nombre_Entidad { set; get; }
        public int ValorLlavePrimariaEntidad { set; get; }

        private bool CerrarVentana = false;
    }
}
