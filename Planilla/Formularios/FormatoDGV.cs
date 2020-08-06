using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planilla.Formularios
{
    public class FormatoDGV
    {

        public string Columna { set; get; }
        public string Descripcion { set; get; }
        public int Tamano { set; get; }
        public bool SoloLectura { set; get; }
        public DataGridViewContentAlignment Alineacion { set; get; }
        public DataGridViewContentAlignment AlineacionDelEncabezado { set; get; }
        public string ToolTip { get; }

        public bool ValorEncontrado { set; get; }

        public FormatoDGV(string NombreDelaColumna)
        {

            this.Columna = NombreDelaColumna.Trim();
            this.ValorEncontrado = true;

            switch (Columna)
            {
                case "Eliminar":
                    this.Descripcion = "Eliminar";
                    this.Tamano = 50;
                    this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = false;
                    break;

                case "IdTipoDeEntidad":
                    this.Descripcion = "ID";
                    this.Tamano = 50;
                    this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;

                case "TipoDeEntidad":
                    this.Descripcion = "Tipo de Entidad";
                    this.Tamano = 200;
                    this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;

                case "Seccion":
                    this.Descripcion = "Sección";
                    this.Tamano = 200;
                    this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;

                case "Ubicacion":
                    this.Descripcion = "Ubicación";
                    this.Tamano = 200;
                    this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;

                case "TipoDeUbicacion":
                    this.Descripcion = "Tipo de Ubicación";
                    this.Tamano = 160;
                    this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;

                case "IdModuloInterfazUsuario":
                    this.Descripcion = "ID";
                    this.Tamano = 50;
                    this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;

                case "Modulo":
                    this.Descripcion = "Modulo";
                    this.Tamano = 160;
                    this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;

                case "Interfaz":
                    this.Descripcion = "Interfaz";
                    this.Tamano = 160;
                    this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;

                case "NombreAMostrar":
                    this.Descripcion = "Nombre Interno";
                    this.Tamano = 200;
                    this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;

                case "Privilegio":
                    this.Descripcion = "Permiso";
                    this.Tamano = 200;
                    this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;

                case "Acceso":
                    this.Descripcion = "Acceso";
                    this.Tamano = 50;
                    this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;

                case "IdPrivilegio":
                    this.Descripcion = "ID";
                    this.Tamano = 50;
                    this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;

                case "IdModuloInterfazRol":
                    this.Descripcion = "ID";
                    this.Tamano = 50;
                    this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;

                case "UsuarioDecreacion":
                    this.Descripcion = "Creado por";
                    this.Tamano = 130;
                    this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;

                case "UsuarioDeModificacion":
                    this.Descripcion = "Modificado por";
                    this.Tamano = 130;
                    this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;

                case "FechaDeCreacion":
                    this.Descripcion = "Crado el";
                    this.Tamano = 130;
                    this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;

                case "FechaDeModificacion":
                    this.Descripcion = "Modificado el";
                    this.Tamano = 130;
                    this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;

                case "Seleccionar":
                    this.Descripcion = " ";
                    this.Tamano = 50;
                    this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = false;
                    break;

                case "Marcar":
                    this.Descripcion = "";
                    this.Tamano = 50;
                    this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;

                case "IdUsuarioDeCreacion":
                    this.Descripcion = "Id-Usuario-Creación";
                    this.Tamano = 50;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                    this.SoloLectura = true;
                    break;

                case "IdUsuarioModificacion":
                    this.Descripcion = "Id-Usuario-Modificación";
                    this.Tamano = 50;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                    this.SoloLectura = true;
                    break;

                default: this.ValorEncontrado = false; break;

            }

        }

        public FormatoDGV(string NombreDelaColumna, string Tabla)
        {

            this.Columna = NombreDelaColumna;

            switch (Tabla)
            {
                case "Empleado":

                    this.ValorEncontrado = true;

                    switch (Columna)
                    {
                        case "Codigo":
                            this.Descripcion = "Código";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;

                            break;

                        case "NoINSS":
                            this.Descripcion = "No. INNS";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;

                            break;

                        case "Nombres":
                            this.Descripcion = "Nombre y Apellidos del Empleado";
                            this.Tamano = 260;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;

                            break;

                        case "AreaLaboral":
                            this.Descripcion = "Area";
                            this.Tamano = 160;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;

                            break;

                        case "Cargo":
                            this.Descripcion = "Cargo";
                            this.Tamano = 160;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;

                            break;

                        case "Direccion":
                            this.Descripcion = "Dirección";
                            this.Tamano = 160;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;

                            break;

                        case "Cumpleanos":
                            this.Descripcion = "Cumpleaños";
                            this.Tamano = 160;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;

                            break;

                        case "Telefono":
                            this.Descripcion = "Teléfono";
                            this.Tamano = 160;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;

                            break;

                        case "FechaDeNacimiento":
                            this.Descripcion = "Fecha de Nacimiento";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;

                            break;

                        case "FechaIngreso":
                            this.Descripcion = "Fecha de Ingreso";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;

                            break;

                        case "Antiguedad":
                            this.Descripcion = "Antiguedad";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;

                            break;

                        case "GradoAcademico":
                            this.Descripcion = "Grado Académico";
                            this.Tamano = 200;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;

                            break;

                        case "OtrosEstudios":
                            this.Descripcion = "Otros Estudios";
                            this.Tamano = 200;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;

                            break;

                        case "INSS":
                            this.Descripcion = "INSS";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;

                            break;

                        case "ContactoDeEmergencia":
                            this.Descripcion = "Contactos de Emergencia";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;

                            break;

                        case "Estado":
                            this.Descripcion = "Estado";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;

                            break;

                        default: this.ValorEncontrado = false; break;
                    }

                    break;

                case "OtrosEstudios":

                    this.ValorEncontrado = true;

                    switch (Columna)
                    {
                        case "Nombre":
                            this.Descripcion = "Otros estudios";
                            this.Tamano = 500;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;

                            break;

                        case "idOtrosEstudios":
                            this.Descripcion = "ID";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;

                            break;

                        default: this.ValorEncontrado = false; break;
                    }

                    break;

                case "DepartamentoOrganizacional":

                    this.ValorEncontrado = true;

                    switch (Columna)
                    {
                        case "Nombre":
                            this.Descripcion = "Departament organizacional";
                            this.Tamano = 300;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;

                            break;

                        case "idDepartamento":
                            this.Descripcion = "ID";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;

                            break;

                        default: this.ValorEncontrado = false; break;
                    }

                    break;

                case "ContactoEnCasoDeEmergencia":

                    this.ValorEncontrado = true;

                    switch (Columna)
                    {
                        case "Nombre":
                            this.Descripcion = "Contacto de Emergencia";
                            this.Tamano = 300;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;

                            break;

                        case "Telefono":
                            this.Descripcion = "Telefono";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;

                            break;

                        case "idContactoEnCasoDeEmergencia":
                            this.Descripcion = "ID";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;

                            break;

                        default: this.ValorEncontrado = false; break;
                    }

                    break;

                case "Departamento":

                    this.ValorEncontrado = true;

                    switch (Columna)
                    {
                        case "Nombre":
                            this.Descripcion = "Departamento";
                            this.Tamano = 300;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;

                            break;

                        case "idDepartamento":
                            this.Descripcion = "ID";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;

                            break;

                        default: this.ValorEncontrado = false; break;
                    }

                    break;

                case "Cargo":

                    this.ValorEncontrado = true;

                    switch (Columna)
                    {
                        case "Nombre":
                            this.Descripcion = "Cargo del empleado";
                            this.Tamano = 300;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;

                            break;

                        case "idCargo":
                            this.Descripcion = "ID";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;

                            break;

                        default: this.ValorEncontrado = false; break;
                    }

                    break;

                case "Ciudad":

                    this.ValorEncontrado = true;

                    switch (Columna)
                    {
                        case "Nombre":
                            this.Descripcion = "Ciudad";
                            this.Tamano = 300;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;

                            break;

                        case "idCiudad":
                            this.Descripcion = "ID";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;

                            break;

                        default: this.ValorEncontrado = false; break;
                    }

                    break;

                case "SalidaDelProductoDetalle":

                    this.ValorEncontrado = true;

                    switch (Columna)
                    {
                        case "Codigo":
                            this.Descripcion = "Código";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = false;
                            this.ToolTip = "Código del producto";
                            break;

                        case "CodigoDeAlmacenamiento":
                            this.Descripcion = "Almacenamiento";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = false;
                            this.ToolTip = "Código de almacenmaiento del producto, este genera en el registro del lugar donde sera guardado el producto ya sea de manera virtual para nuestro sistema o de manera fisica.";
                            break;

                        case "CodigoDeBarra":
                            this.Descripcion = "Código de Barra";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = false;
                            this.ToolTip = "Código de barra del producto, por lo genera este se encuentra en la caja o en alguna parte de la presentación del mismo.";
                            break;

                        case "NombreDelProducto":
                            this.Descripcion = "Descripción del producto";
                            this.Tamano = 200;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = false;
                            this.ToolTip = "Nombre del producto dentro de nuestros items.";
                            break;

                        case "NombreDeLaCategoria":
                            this.Descripcion = "Categoria";
                            this.Tamano = 160;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = false;
                            this.ToolTip = "Las diferentes categorias en las que se pueden clasificar los productos";
                            break;

                        case "UnidadesXPrecentacion":
                            this.Descripcion = "UxP";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            this.ToolTip = "La cantidad de unidades que se tiene por precentación de un producto.";
                            break;

                        case "UnidadDeMedida":
                            this.Descripcion = "Unidad de medida";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            this.ToolTip = "es la unidad de medida en la que se presenta el producto";
                            break;

                        case "NumeroDeLote":
                            this.Descripcion = "Lote";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = false;
                            this.ToolTip = "Numeración del lote, esto lo identifica por producto para saber el lote de vencimiento";
                            break;

                        case "FechaDeVencimientoDelLote":
                            this.Descripcion = "Fecha de vencimiento";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = false;
                            this.ToolTip = "Fecha de vencimiento del lote de productos, si este no contiene uno podemos dejarlo vacio, ya el sistema puede agregarlo a una de 'Sin fecha'";
                            break;

                        case "Cantidad":
                            this.Descripcion = "Cantidad X Presentación";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = false;
                            this.ToolTip = "Cantidad por producto obtenida por presentacion del mismo";
                            break;

                        case "CantidadUnitaria":
                            this.Descripcion = "Unidades";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = false;
                            this.ToolTip = "Canitad de unidades del producto si este tiene...";
                            break;

                        case "Costo":
                            this.Descripcion = "Costo";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            this.ToolTip = "Costo del producto, debemos de tener en cuenta que este en base a compra para realizar calculos de aproximación de productos.";
                            break;

                        case "NuevoCosto":
                            this.Descripcion = "NuevoCosto";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            this.ToolTip = "Nuevo Costo del producto, este calculo se realiza enla sumatoria del costo + utilidad + iva";
                            break;

                        case "SubTotal":
                            this.Descripcion = "SubTotal";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            this.ToolTip = "Es el calculo de manera automatica, entre la cantidad el costo de compra del producto, permitiendo tener un subtotal del producto en inventario con los precios de costo del producto.";
                            break;

                        case "PorcentajeDeUtilidad":
                            this.Descripcion = "Utilidad(%)";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            this.ToolTip = "Porcentaje de utilidad del producto, es mas o menos el aproximado de ganancia del producto, debemos recordar que este se calcula y se le suma al subtotal de utilidad del producto";
                            break;

                        case "Utilidad":
                            this.Descripcion = "Utilidad";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            this.ToolTip = "Nos permite darnos cuenta de cuanto puede la utilidad bruta.";
                            break;

                        case "SubTotalUtilidad":
                            this.Descripcion = "Total Utilidad";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            this.ToolTip = "Este se calcula apartir de la sumatoria utilidad + total de costo,";
                            break;

                        case "ProcentajeIVA"://NuevoCostoDelProducto
                            this.Descripcion = "IVA(%)";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            this.ToolTip = "Valor del interes del valor agregado";
                            break;

                        case "NuevoCostoDelProducto":
                            this.Descripcion = "Nuevo Costo del Producto";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            this.ToolTip = "El valor del nuevo costo, es para saber cuanto cuesta el producto ya con la utilidad + iva en el caso que este se calcule.";
                            break;


                        case "IVA":
                            this.Descripcion = "IVA";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            this.ToolTip = "Valor del interes del valor agregado";
                            break;

                        case "Total":
                            this.Descripcion = "Total";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            this.ToolTip = "Total del producto, es te calculo entre la cantidad de producto comprado y el nuevo costo";
                            break;

                        case "PrecioPorUnidad":
                            this.Descripcion = "Precio x Unidad";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            this.ToolTip = "Precio unitario del producto";
                            break;

                        case "CantidadTotal":
                            this.Descripcion = "Cantidad por precentación";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            this.ToolTip = "Cantidad Total por precentación del producto";
                            break;

                        case "idEntradaDeProductoDetalle":
                            this.Descripcion = "ID";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;
                            break;

                        default: this.ValorEncontrado = false; break;
                    }

                    break;

                case "EntradaDelProductoDetalle":

                    this.ValorEncontrado = true;

                    switch (Columna)
                    {
                        case "Codigo":
                            this.Descripcion = "Código";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = false;
                            this.ToolTip = "Código del producto";
                            break;

                        case "CodigoDeAlmacenamiento":
                            this.Descripcion = "Almacenamiento";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = false;
                            this.ToolTip = "Código de almacenmaiento del producto, este genera en el registro del lugar donde sera guardado el producto ya sea de manera virtual para nuestro sistema o de manera fisica.";
                            break;

                        case "CodigoDeBarra":
                            this.Descripcion = "Código de Barra";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = false;
                            this.ToolTip = "Código de barra del producto, por lo genera este se encuentra en la caja o en alguna parte de la presentación del mismo.";
                            break;

                        case "NombreDelProducto":
                            this.Descripcion = "Descripción del producto";
                            this.Tamano = 200;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = false;
                            this.ToolTip = "Nombre del producto dentro de nuestros items.";
                            break;

                        case "NombreDeLaCategoria":
                            this.Descripcion = "Categoria";
                            this.Tamano = 160;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = false;
                            this.ToolTip = "Las diferentes categorias en las que se pueden clasificar los productos";
                            break;

                        case "UnidadesXPrecentacion":
                            this.Descripcion = "UxP";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            this.ToolTip = "La cantidad de unidades que se tiene por precentación de un producto.";
                            break;

                        case "UnidadDeMedida":
                            this.Descripcion = "Unidad de medida";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            this.ToolTip = "es la unidad de medida en la que se presenta el producto";
                            break;

                        case "NumeroDeLote":
                            this.Descripcion = "Lote";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = false;
                            this.ToolTip = "Numeración del lote, esto lo identifica por producto para saber el lote de vencimiento";
                            break;

                        case "FechaDeVencimientoDelLote":
                            this.Descripcion = "Fecha de vencimiento";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = false;
                            this.ToolTip = "Fecha de vencimiento del lote de productos, si este no contiene uno podemos dejarlo vacio, ya el sistema puede agregarlo a una de 'Sin fecha'";
                            break;

                        case "Cantidad":
                            this.Descripcion = "Cantidad";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = false;
                            this.ToolTip = "Cantidad de producto que vamos ingresar a nuestro sistema, debemos tener cuidado con valores negativos, ya que el sistema los puede validar y no dejarlos pasar";
                            break;

                        case "Costo":
                            this.Descripcion = "Costo";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = false;
                            this.ToolTip = "Costo del producto, debemos de tener en cuenta que este en base a compra para realizar calculos de aproximación de productos.";
                            break;

                        case "SubTotal":
                            this.Descripcion = "SubTotal";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            this.ToolTip = "Es el calculo de manera automatica, entre la cantidad el costo de compra del producto, permitiendo tener un subtotal del producto en inventario con los precios de costo del producto.";
                            break;

                        case "PorcentajeDeUtilidad":
                            this.Descripcion = "Utilidad(%)";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = false;
                            this.ToolTip = "Porcentaje de utilidad del producto, es mas o menos el aproximado de ganancia del producto, debemos recordar que este se calcula y se le suma al subtotal de utilidad del producto";
                            break;

                        case "Utilidad":
                            this.Descripcion = "Utilidad";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = false;
                            this.ToolTip = "Nos permite darnos cuenta de cuanto puede la utilidad bruta.";
                            break;

                        case "SubTotalUtilidad":
                            this.Descripcion = "Total Utilidad";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            this.ToolTip = "Este se calcula apartir de la sumatoria utilidad + total de costo,";
                            break;

                        case "ProcentajeIVA"://NuevoCostoDelProducto
                            this.Descripcion = "IVA(%)";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            this.ToolTip = "Valor del interes del valor agregado";
                            break;

                        case "NuevoCostoDelProducto":
                            this.Descripcion = "Nuevo Costo del Producto";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = false;
                            this.ToolTip = "El valor del nuevo costo, es para saber cuanto cuesta el producto ya con la utilidad + iva en el caso que este se calcule.";
                            break;


                        case "IVA":
                            this.Descripcion = "IVA";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            this.ToolTip = "Valor del interes del valor agregado";
                            break;

                        case "Total":
                            this.Descripcion = "Total";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            this.ToolTip = "Total del producto";
                            break;

                        case "PrecioPorUnidad":
                            this.Descripcion = "Precio x Unidad";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = false;
                            this.ToolTip = "Precio unitario del producto";
                            break;

                        case "CantidadTotal":
                            this.Descripcion = "Cantidad por precentación";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            this.ToolTip = "Cantidad Total por precentación del producto";
                            break;

                        case "idSalidaDelProductoDetalle":
                            this.Descripcion = "ID";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;
                            break;

                        default: this.ValorEncontrado = false; break;
                    }

                    break;

                case "SalidaDelProducto":

                    this.ValorEncontrado = true;

                    switch (Columna)
                    {
                        case "Estado":
                            this.Descripcion = "Estado";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Observaciones":
                            this.Descripcion = "Observaciones";
                            this.Tamano = 260;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Codigo":
                            this.Descripcion = "Código";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Referencia":
                            this.Descripcion = "Referencia";
                            this.Tamano = 160;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "FechaDeLaSalida":
                            this.Descripcion = "Fecha de Salida";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "TipoDeSalida":
                            this.Descripcion = "Tipo de salida";
                            this.Tamano = 160;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Almacen":
                            this.Descripcion = "Almacen";
                            this.Tamano = 160;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "ValorDeLaSalida":
                            this.Descripcion = "Valor";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            break;

                        case "Subtotal":
                            this.Descripcion = "SubTotal";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            break;

                        case "Utilidad":
                            this.Descripcion = "Utilidad";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            break;

                        case "IVA":
                            this.Descripcion = "IVA";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            break;

                        case "Total":
                            this.Descripcion = "Total";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            break;

                        case "idSalidaDelProducto":
                            this.Descripcion = "ID";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;
                            break;

                        default: this.ValorEncontrado = false; break;
                    }

                    break;

                case "EntradaDeProducto":

                    this.ValorEncontrado = true;

                    switch (Columna)
                    {
                        case "Estado":
                            this.Descripcion = "Estado";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Observaciones":
                            this.Descripcion = "Observaciones";
                            this.Tamano = 260;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Codigo":
                            this.Descripcion = "Código";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Referencia":
                            this.Descripcion = "Referencia";
                            this.Tamano = 160;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "FechaDeLaEntrada":
                            this.Descripcion = "Fecha de entrada";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "TipoDeEntrada":
                            this.Descripcion = "Tipo de entrada";
                            this.Tamano = 160;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Almacen":
                            this.Descripcion = "Almacen";
                            this.Tamano = 160;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "ValorDeLaEntrada":
                            this.Descripcion = "Valor";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            break;

                        case "Subtotal":
                            this.Descripcion = "SubTotal";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            break;

                        case "Utilidad":
                            this.Descripcion = "Utilidad";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            break;

                        case "IVA":
                            this.Descripcion = "IVA";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            break;

                        case "Total":
                            this.Descripcion = "Total";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            break;

                        case "idEntradaDeProducto":
                            this.Descripcion = "ID";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;
                            break;

                        default: this.ValorEncontrado = false; break;
                    }

                    break;

                case "TrasladoDeCompraDetalle":

                    this.ValorEncontrado = true;

                    switch (Columna)
                    {
                        case "PrecioUnitario":
                            this.Descripcion = "Precio Unitario";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = false;
                            this.ToolTip = "Precio unitario del producto";
                            break;

                        case "CantidadDetallada":
                            this.Descripcion = "Cantidad Detalla";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = false;
                            this.ToolTip = "Cantidad detalla del traslado del producto";
                            break;

                        case "TotalDeUtilidadDelProductoDestino":
                            this.Descripcion = "Total de Utilidad";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = false;
                            this.ToolTip = "Total del utilidad del producto en el almacen destino";
                            break;

                        case "ValorDelPorcentajeDeIVASobreTotalDeUtilidadDelProductoDestino":
                            this.Descripcion = "IVA";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            this.ToolTip = "Valor del porcentaje de IVA ";
                            break;

                        case "PorcentajeDeIVASobreTotalDeUtilidadDelProductoDestino":
                            this.Descripcion = "IVA(%)";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            break;

                        case "UtilidadDelProductoDestino":
                            this.Descripcion = "SubTotal de Utilidad";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = false;
                            break;

                        case "ValorDelPorcentajeDeUtilidadDestino":
                            this.Descripcion = "Utilidad";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = false;
                            break;

                        case "PorcentajeDeUtilidadDestino":
                            this.Descripcion = "Utilidad(%)";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = false;
                            break;

                        case "SubTotalDestino":
                            this.Descripcion = "SubTotal";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            break;

                        case "CostoDestino":
                            this.Descripcion = "Costo";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = false;
                            break;

                        case "TotalDeUtilidadDelProductoOrigen":
                            this.Descripcion = "Total de Utilidad Origen";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            break;

                        case "ValorDelPorcentajeDeIVASobreElTraslado":
                            this.Descripcion = "IVA Origen";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            break;

                        case "PorcentajeDeIVaSobreElTraslado":
                            this.Descripcion = "IVA (%) Origen";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            break;

                        case "UtilidadDelProductoOrigen":
                            this.Descripcion = "SubTotal De Utilidad Origen";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            break;

                        case "valorDelPorcentajeDeUtilidadOrigen":
                            this.Descripcion = "Utilidad Origen";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            break;

                        case "PorcentajeDeUtilidadOrigen":
                            this.Descripcion = "Utilidad(%)";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            break;

                        case "SubTotalOrigen":
                            this.Descripcion = "SubTotal Origen";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            break;

                        case "CostoOrigen":
                            this.Descripcion = "Costo Origen";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            break;

                        case "Cantidad":
                            this.Descripcion = "Cantidad";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = false;
                            break;

                        case "FechaDeVencimientoDelLote":
                            this.Descripcion = "Fecha vencimiento del lote";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            break;

                        case "NumeroDeLote":
                            this.Descripcion = "No. Lote";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = false;
                            break;

                        case "CodigoDelAlmacenamientoDestino":
                            this.Descripcion = "Almacen Destino";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = false;
                            break;

                        case "ProductoNombre":
                            this.Descripcion = "Producto";
                            this.Tamano = 200;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = false;
                            break;

                        case "CodigoDeAlmacenamientoOrigen":
                            this.Descripcion = "Almacen Origen";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = false;
                            break;

                        case "CodigoDeBarra":
                            this.Descripcion = "Código de Barra";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = false;
                            break;

                        case "Codigo":
                            this.Descripcion = "Código";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = false;
                            break;

                        case "idTrasladoDeProductoDetalle":
                            this.Descripcion = "ID";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;
                            break;

                        default: this.ValorEncontrado = false; break;
                    }

                    break;

                case "TrasladoDeProducto":

                    this.ValorEncontrado = true;

                    switch (Columna)
                    {

                        case "Codigo":
                            this.Descripcion = "Código";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Referencia":
                            this.Descripcion = "Referencia";
                            this.Tamano = 160;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "AlmacenOrigen":
                            this.Descripcion = "Almacenamiento Origen";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "AlmacenDestino":
                            this.Descripcion = "Almacenamiento Destino";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "FechaDelTraslado":
                            this.Descripcion = "Fecha del Traslado";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "ValorDelTraslado":
                            this.Descripcion = "Valor del Traslado";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            break;

                        case "Subtotal":
                            this.Descripcion = "Subtotal";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            break;

                        case "Utilidad":
                            this.Descripcion = "Utilidad";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            break;

                        case "IVA":
                            this.Descripcion = "IVA";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            break;

                        case "Total":
                            this.Descripcion = "Total";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            break;

                        case "Observaciones":
                            this.Descripcion = "Observaciones";
                            this.Tamano = 250;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Estado":
                            this.Descripcion = "Estado";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "idTrasladoDeProducto":
                            this.Descripcion = "ID";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;
                            break;

                        default: this.ValorEncontrado = false; break;
                    }

                    break;

                case "BuscarProductos":

                    this.ValorEncontrado = true;

                    switch (Columna)
                    {

                        case "AplicarComisiones":
                            this.Descripcion = "Aplicar comisión";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;
                            this.ToolTip = "Aplicar comisión sobre el producto";
                            break;

                        case "idProductoConfiguracion":
                            this.Descripcion = "ID";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;
                            this.ToolTip = "Identificador de la configuración asociada al producto";
                            break;

                        case "Estado":
                            this.Descripcion = "Estado";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;
                            this.ToolTip = "Estado del Producto";
                            break;

                        case "AplicarElIVA":
                            this.Descripcion = "Aplicar IVA";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;
                            this.ToolTip = "Aplicar el iva al producto";
                            break;

                        case "UnidadesXPrecentacion":
                            this.Descripcion = "Unidades x presentación";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            this.ToolTip = "Unidades por presentación del producto";
                            break;

                        case "ProductoControlado":
                            this.Descripcion = "Producto Controlado";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;
                            this.ToolTip = "Producto controlado.";
                            break;

                        case "CodigoDelProveedorLaboratorio":
                            this.Descripcion = "Código del Proveedor";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            this.ToolTip = "Código del proveedor";
                            break;

                        case "TablaDeRefereciaDeProveedorOLaboratorio":
                            this.Descripcion = "Referencia";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            this.ToolTip = "Referencia de guardado del producto sobre el laboratorio y proveedor";
                            break;

                        case "idPLEntidad":
                            this.Descripcion = "ID";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            this.ToolTip = "Identificados el Producto asociado al laboratorio";
                            break;

                        case "Observaciones":
                            this.Descripcion = "Observaciones";
                            this.Tamano = 200;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            this.ToolTip = "Observaciones realizadas sobre el producto";
                            break;

                        case "Maximo":
                            this.Descripcion = "Máximo";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            this.ToolTip = "Máximo por producto en almacen";
                            break;

                        case "Minimo":
                            this.Descripcion = "Minimo";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            this.ToolTip = "Minimo por producto en almacen";
                            break;

                        case "ExistenciaPorAlmacen":
                            this.Descripcion = "Existencia en Almacen";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            this.ToolTip = "Existencia en almacen por producto";
                            break;

                        case "PrecioXUnidad":
                            this.Descripcion = "Precio Unitario";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            this.ToolTip = "Precio unitario del producto";
                            break;

                        case "CostoMasPorcentajeSobreCostoMasIVA":
                            this.Descripcion = "Total";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            this.ToolTip = "Total de utilidad del producto";
                            break;

                        case "ValorDelIvaEnProcentaje":
                            this.Descripcion = "IVA(%)";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            this.ToolTip = "Porcentaje del IVA.";
                            break;

                        case "ValorDelIva":
                            this.Descripcion = "IVA";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            this.ToolTip = "Valor del IVA.";
                            break;

                        case "CostoMasPorcentajeDeCosto":
                            this.Descripcion = "SubTotal";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            this.ToolTip = "SubTotal de producto sin aplicar el iva.";
                            break;

                        case "ValorDelPorcentajeSobreCosto":
                            this.Descripcion = "Utilidad";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            this.ToolTip = "Utilidad de producto.";
                            break;

                        case "PorcentajeSobreCosto":
                            this.Descripcion = "Utilidad(%)";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            this.ToolTip = "Porcentaje de utilidad que se obtendra sobre el costo de aquisición del producto";
                            break;

                        case "Costo":
                            this.Descripcion = "Costo";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            this.ToolTip = "Costo de adquisición del producto";
                            break;

                        case "Existencias":
                            this.Descripcion = "Existencias del Producto";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            this.ToolTip = "Existencia total del producto";
                            break;

                        case "Categoria":
                            this.Descripcion = "Categoria del producto";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            this.ToolTip = "Categoria en la se encuentra asociado el producto";
                            break;

                        case "PresentacionDelProducto":
                            this.Descripcion = "Presentación del producto";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            this.ToolTip = "Presentación del producto";
                            break;

                        case "NombreComun":
                            this.Descripcion = "Nombre común";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            this.ToolTip = "Nombre que comunmente se le da al producto";
                            break;

                        case "NombreGenerico":
                            this.Descripcion = "Nombre Generico";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            this.ToolTip = "Nombre generico del producto";
                            break;

                        case "Descripcion":
                            this.Descripcion = "Descripción";
                            this.Tamano = 260;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            this.ToolTip = "Descripción del producto";
                            break;

                        case "Nombre":
                            this.Descripcion = "Producto";
                            this.Tamano = 200;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            this.ToolTip = "Nombre del producto";
                            break;

                        case "CodigoDeAlmacenamiento":
                            this.Descripcion = "Código de Almacenamiento";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            this.ToolTip = "Código del almacenamiento en bodega del producto";
                            break;

                        case "CodigoDeBarra":
                            this.Descripcion = "Código de Barra";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            this.ToolTip = "Código de barra del producto";
                            break;

                        case "Codigo":
                            this.Descripcion = "Código";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            this.ToolTip = "Código del producto";
                            break;

                        case "idProductoPrecio":
                            this.Descripcion = "ID";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.ToolTip = "Identificador del almacenamiento del producto";
                            this.SoloLectura = true;
                            break;

                        case "idCategoria":
                            this.Descripcion = "ID";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.ToolTip = "Identificador de la categoria a la que pertenece el producto";
                            this.SoloLectura = true;
                            break;

                        case "idProductoPresentacion":
                            this.Descripcion = "ID";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.ToolTip = "Identificador de la presentación del producto";
                            this.SoloLectura = true;
                            break;

                        case "idProductoUnidadDeMedida":
                            this.Descripcion = "ID";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.ToolTip = "Identificador de la unidad de media";
                            this.SoloLectura = true;
                            break;

                        case "idProducto":
                            this.Descripcion = "ID";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.ToolTip = "Identificador del producto";
                            this.SoloLectura = true;
                            break;

                        default: this.ValorEncontrado = false; break;
                    }

                    break;

                case "ProductoCostoYOtros":

                    this.ValorEncontrado = true;

                    switch (Columna)
                    {

                        case "Minimo":
                            this.Descripcion = "Mínimo";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = false;
                            this.ToolTip = "Se guarda el valor mínimo del producto";
                            break;

                        case "Maximo":
                            this.Descripcion = "Máximo";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = false;
                            this.ToolTip = "Se guarda el valor máximo del producto";
                            break;

                        case "Costo":
                            this.Descripcion = "Costo";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = false;
                            this.ToolTip = "se guarda el costo de compra del producto";
                            break;

                        case "PorcentajeSobreCosto":
                            this.Descripcion = "% de Utilidad";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = false;
                            this.ToolTip = "Se guarda el valor en porcentaje sobre el costo. (ejemplo: 10;20;50)";
                            break;


                        case "ValorDelPorcentajeSobreCosto":
                            this.Descripcion = "Utilidad";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = false;
                            this.ToolTip = "Ese se calcula apartir de Costo * el Porcentaje de Utilidad";
                            break;

                        case "CostoMasPorcentajeDeCosto":
                            this.Descripcion = "Subtotal";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = false;
                            this.ToolTip = "Se calcula apartir de la suma del costo + la utilidad";
                            break;

                        case "ValorDelIva":
                            this.Descripcion = "Valor del IVA";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = false;
                            this.ToolTip = "Este se calcula apartir del costo * 15 del iva, siempre y cuando al articulo se le aplique iva.";
                            break;

                        case "ValorDelIvaEnProcentaje":
                            this.Descripcion = "IVA";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = false;
                            this.ToolTip = "Valor del porcentaje una ves aplicado el porcentaje del iva.";
                            break;

                        case "CostoMasPorcentajeSobreCostoMasIVA":
                            this.Descripcion = "Total";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            this.ToolTip = "Este se calcula apartir del Subtotal + el Valor del IVA";
                            break;

                        case "PrecioXUnidad":
                            this.Descripcion = "Precio x Unidad";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = false;
                            this.ToolTip = "se calcula apartir del costo entre la cantidad de producto por unidad de presentación";
                            break;

                        case "Estado":
                            this.Descripcion = "Estado";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "DescripcionDelAlmacenamiento":
                            this.Descripcion = "Descripción";
                            this.Tamano = 120;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "CodigoDeAlmacenamiento":
                            this.Descripcion = "Codigo de Almacenamiento";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Descripcion":
                            this.Descripcion = "Descripcion";
                            this.Tamano = 200;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "TablaDeReferenciaDeAlmacenaje":
                            this.Descripcion = "Referencia";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "idAlmacenEntidad":
                            this.Descripcion = "Id-Almacenaje";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            break;

                        case "idProductoPrecio":
                            this.Descripcion = "ID";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;
                            break;

                        default: this.ValorEncontrado = false; break;
                    }

                    break;

                case "ProductoAlmacenaje":

                    this.ValorEncontrado = true;

                    switch (Columna)
                    {
                        case "Estado":
                            this.Descripcion = "Estado";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "DescripcionDelAlmacenamiento":
                            this.Descripcion = "Descripción";
                            this.Tamano = 120;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "CodigoDeAlmacenamiento":
                            this.Descripcion = "Codigo de Almacenamiento";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Descripcion":
                            this.Descripcion = "Descripcion";
                            this.Tamano = 200;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "TablaDeReferenciaDeAlmacenaje":
                            this.Descripcion = "Referencia";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "idAlmacenEntidad":
                            this.Descripcion = "Id-Almacenaje";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            break;

                        case "idProductoPrecio":
                            this.Descripcion = "ID";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;
                            break;

                        default: this.ValorEncontrado = false; break;
                    }

                    break;

                case "DetalleCompra":

                    this.ValorEncontrado = true;

                    switch (Columna)
                    {
                        case "SubTotalDeLaCompra":
                            this.Descripcion = "SubTotal de la Compra";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.ToolTip = "SubTotal de la compra del producto";
                            this.SoloLectura = true;
                            break;

                        case "CodigoDeAlmacenamiento":
                            this.Descripcion = "Código de Almacenamiento";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.ToolTip = "Precio por unidad del producto";
                            this.SoloLectura = false;
                            break;

                        case "PrecioUnitario":
                            this.Descripcion = "Precio Unitario";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.ToolTip = "Precio por unidad del producto";
                            this.SoloLectura = true;
                            break;

                        case "CantidadDetallada":
                            this.Descripcion = "Cantidad Total";
                            this.Tamano = 60;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.ToolTip = "Cantidad Total del producto";
                            this.SoloLectura = true;
                            break;

                        case "TotalDeUtilidadDelProducto":
                            this.Descripcion = "Total de Utilidad";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.ToolTip = "Utilidad total que obtendremos del producto";
                            this.SoloLectura = true;
                            break;

                        case "ValorDelPorcentajeDeIVASobreTotalDeUtilidadDelProducto":
                            this.Descripcion = "Valor del IVA(%)";
                            this.Tamano = 60;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.ToolTip = "El iva se aplicar si el producto lo requiere sobre el nuevo costo del producto";
                            this.SoloLectura = true;
                            break;

                        case "PorcentajeDeIVASobreTotalDeUtilidadDelProducto":
                            this.Descripcion = "IVA(%)";
                            this.Tamano = 60;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.ToolTip = "El iva se aplicar si el producto lo requiere sobre el nuevo costo del producto";
                            this.SoloLectura = true;
                            break;

                        case "UtilidadDelProducto":
                            this.Descripcion = "SubTotal";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.ToolTip = "Utilidad Neta a Conseguir del producto";
                            this.SoloLectura = true;
                            break;

                        case "ValorDelPorcentajeDeUtilidad":
                            this.Descripcion = "Utilidad";
                            this.Tamano = 60;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.ToolTip = "Utilidad que deseamos obtener del producto";
                            this.SoloLectura = false;
                            break;

                        case "PorcentajeDeUtilidad":
                            this.Descripcion = "Utilidad (%)";
                            this.Tamano = 60;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.ToolTip = "Porcentaje de utilidad";
                            this.SoloLectura = false;
                            break;

                        case "NuevoCostoDelProducto":
                            this.Descripcion = "Costo Bonificado";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.ToolTip = "Nuevo costo del producto";
                            this.SoloLectura = false;
                            break;

                        case "TotalDeLaCompra":
                            this.Descripcion = "Total de la Compra";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.ToolTip = "Valor de la compra";
                            this.SoloLectura = true;
                            break;

                        case "ValorDelPorcentajeDelISC":
                            this.Descripcion = "ISC";
                            this.Tamano = 60;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.ToolTip = "Valor aplicado del  % del ISC";
                            this.SoloLectura = true;
                            break;

                        case "PorcentajeDeISC":
                            this.Descripcion = "ISC (%)";
                            this.Tamano = 60;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.ToolTip = "El % del ISC";
                            this.SoloLectura = false;
                            break;

                        case "ValorDelPorcentajeDeIVASobreLaCompra":
                            this.Descripcion = "IVA";
                            this.Tamano = 60;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.ToolTip = "Valor del iva en porcentaje";
                            this.SoloLectura = true;
                            break;

                        case "PorcentajeDeIVaSobreLaCompra":
                            this.Descripcion = "IVA(%)";
                            this.Tamano = 60;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.ToolTip = "iva en porcentaje ejemplo: 10, 20, 30";
                            this.SoloLectura = false;
                            break;

                        case "ValorDelPorcentajeDeDescuento":
                            this.Descripcion = "Descuento";
                            this.Tamano = 60;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.ToolTip = "Valor del descuento que se aplico en porcentaje.";
                            this.SoloLectura = true;
                            break;

                        case "PorcentajeDescuento":
                            this.Descripcion = "Descuento(%)";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.ToolTip = "porcentaje de descuento aplicado sobre la compra del producto";
                            this.SoloLectura = false;
                            break;

                        case "CostoDeCompra":
                            this.Descripcion = "Costo de Compra";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.ToolTip = "Costo de compra del Producto";
                            this.SoloLectura = false;
                            break;

                        case "Bonificacion":
                            this.Descripcion = "Bonificación";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.ToolTip = "Bonificación del producto";
                            this.SoloLectura = false;
                            break;

                        case "Cantidad":
                            this.Descripcion = "Cant";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.ToolTip = "Cantidad de producto comprada";
                            this.SoloLectura = false;
                            break;

                        case "FechaDeVencimientoDelLote":
                            this.Descripcion = "Vencimiento";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.ToolTip = "Fecha de vencimiento del lote de producto.";
                            this.SoloLectura = false;
                            break;

                        case "NumeroDeLote":
                            this.Descripcion = "Lote";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.ToolTip = "Número del lote al que pertenece el producto que se va registras la compra.";
                            this.SoloLectura = false;
                            break;

                        case "UnidadDeMedida":
                            this.Descripcion = "Unidades de medida";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.ToolTip = "Unidades de medida del producto";
                            this.SoloLectura = true;
                            break;

                        case "UnidadesXPrecentacion":
                            this.Descripcion = "Unidades x Presentación";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.ToolTip = "Son la unidades que interna de cada embace.";
                            this.SoloLectura = true;
                            break;

                        case "NombreDeLaPresentacion":
                            this.Descripcion = "Presentación";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.ToolTip = "Presentación en la que biene embazado el producto";
                            this.SoloLectura = true;
                            break;

                        case "NombreDeLaCategoria":
                            this.Descripcion = "Categoria";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.ToolTip = "Categoria a la que pertenese el producto de manera interna";
                            this.SoloLectura = true;
                            break;

                        case "NombreDelProducto":
                            this.Descripcion = "Descripción del producto";
                            this.Tamano = 200;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.ToolTip = "Descripción del producto";
                            this.SoloLectura = false;
                            break;

                        case "CodigoDeBarra":
                            this.Descripcion = "Código de Barra";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.ToolTip = string.Format("Código de barra, es el identificador fisico del producto.{0} Es un numero por los general entre 10 - 13 digitios", Environment.NewLine);
                            this.SoloLectura = false;
                            break;

                        case "Codigo":
                            this.Descripcion = "Código";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.ToolTip = "Código que se le asigno al producto de manera automatica durante su registro.";
                            this.SoloLectura = false;
                            break;

                        case "idProducto":
                            this.Descripcion = "Id Producto";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.ToolTip = "Identificador del producto o Código interno del producto";
                            this.SoloLectura = true;
                            break;

                        case "idCompra":
                            this.Descripcion = "Id Compra";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;
                            this.ToolTip = "Identificador de la compra ó Código interno la compra";
                            break;

                        case "idCompraDetalle":
                            this.Descripcion = "ID";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;
                            this.ToolTip = "Identificador del registro dentro de la tabla Detalle de compra.";
                            break;

                        default: this.ValorEncontrado = false; break;
                    }

                    break;

                case "Compras":

                    this.ValorEncontrado = true;

                    switch (Columna)
                    {
                        case "ProcentajeDeISC":
                            this.Descripcion = "ISC(%)";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            break;

                        case "PorcentajeDeDescuento":
                            this.Descripcion = "Descuento(%)";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            break;

                        case "Codigo":
                            this.Descripcion = "Código";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Referencia":
                            this.Descripcion = "Referencia";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Proveedor":
                            this.Descripcion = "Proveedor";
                            this.Tamano = 160;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "TipoDeCompra":
                            this.Descripcion = "Tipo de Compra";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "ValorDeLaCompra":
                            this.Descripcion = "Valor de la Compra";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            break;

                        case "FechaDeCompra":
                            this.Descripcion = "Fecha de la Compra";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "FechaVencimiento":
                            this.Descripcion = "Fecha de vencimiento";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "TotalGravado":
                            this.Descripcion = "Total gravado";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            break;

                        case "TotalExcento":
                            this.Descripcion = "Total Excento";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            break;

                        case "Descuento":
                            this.Descripcion = "Descuento";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            break;

                        case "ISC":
                            this.Descripcion = "ISC";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            break;

                        case "IVA":
                            this.Descripcion = "IVA";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            break;

                        case "Total":
                            this.Descripcion = "Total";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            break;

                        case "Observaciones":
                            this.Descripcion = "Observaciones";
                            this.Tamano = 160;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Estado":
                            this.Descripcion = "Estado";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Almacen":
                            this.Descripcion = "Almacen";
                            this.Tamano = 160;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "idCompra":
                            this.Descripcion = "ID";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;
                            break;

                        default: this.ValorEncontrado = false; break;
                    }

                    break;

                case "PoliticasDeDevolucion":

                    this.ValorEncontrado = true;

                    switch (Columna)
                    {
                        case "DiasEstipuladosDeDevolicion":
                            this.Descripcion = "Días Estipulados para Devoluición";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            break;

                        case "DiasDeDevolucionSegunLaboratorio":
                            this.Descripcion = "Días Estipulados para Devoluición por el laboratorio";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.BottomRight;
                            this.SoloLectura = true;
                            break;

                        case "Descripcion":
                            this.Descripcion = "Politicas de devolución de productos";
                            this.Tamano = 300;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Laboratorio":
                            this.Descripcion = "Laboratorio";
                            this.Tamano = 200;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Proveedor":
                            this.Descripcion = "Proveedor";
                            this.Tamano = 160;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "idPoliticasDeDevoluciones":
                            this.Descripcion = "ID";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;
                            break;

                        default: this.ValorEncontrado = false; break;
                    }

                    break;

                case "ProductosLote":

                    this.ValorEncontrado = true;

                    switch (Columna)
                    {

                        case "CodigoDeAlmacenamiento":
                            this.Descripcion = "Código de Almacenamiento";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Descripcion":
                            this.Descripcion = "Descripción";
                            this.Tamano = 200;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "FechaDeVencimiento":
                            this.Descripcion = "Fecha de Vencimiento";
                            this.Tamano = 150;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "CantidadDelLote":
                            this.Descripcion = "Cantidad";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            break;

                        case "idLoteDelProducto":
                            this.Descripcion = "ID";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;
                            break;

                        default: this.ValorEncontrado = false; break;
                    }

                    break;

                case "ProductosPromocion":

                    this.ValorEncontrado = true;

                    switch (Columna)
                    {
                        case "Estado":
                            this.Descripcion = "Estado";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Descripcion":
                            this.Descripcion = "Descripción";
                            this.Tamano = 200;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "FechaDeFinalizacion":
                            this.Descripcion = "Finaliza";
                            this.Tamano = 150;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "FechaDeInicio":
                            this.Descripcion = "Inicio";
                            this.Tamano = 150;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "PrecioDelProducto":
                            this.Descripcion = "Precio en Promoción";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            break;

                        case "idProductoPromocion":
                            this.Descripcion = "ID";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;
                            break;

                        default: this.ValorEncontrado = false; break;
                    }

                    break;

                case "ProductoLaboratorio":

                    this.ValorEncontrado = true;

                    switch (Columna)
                    {
                        case "ProveedorLaboratorio":
                            this.Descripcion = "Proveedor/Laboratorio";
                            this.Tamano = 200;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Laboratorio":
                            this.Descripcion = "Laboratorio";
                            this.Tamano = 200;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Proveedor":
                            this.Descripcion = "Proveedor";
                            this.Tamano = 200;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "idProveedorLaboratorio":
                            this.Descripcion = "ID";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;
                            break;

                        default: this.ValorEncontrado = false; break;
                    }

                    break;

                case "AlmacenajeDelProducto":

                    this.ValorEncontrado = true;

                    switch (Columna)
                    {
                        case "CodigoDeAlmacenamiento":
                            this.Descripcion = "Código de Almacenaje";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "DescripcionDelAlmacenamiento":
                            this.Descripcion = "Descripción de almacenaje";
                            this.Tamano = 200;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Almacen":
                            this.Descripcion = "Álmacen";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Bodega":
                            this.Descripcion = "Bodega";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Locacion":
                            this.Descripcion = "Estante/Vitrina/Otros";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Seccion":
                            this.Descripcion = "Sección";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Contenedor":
                            this.Descripcion = "Contenedor";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "CodigoDeAlmacenaje":
                            this.Descripcion = "Código de Almacenaje";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "NombreDelContenedor":
                            this.Descripcion = "Contenedor";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "CodigoDelContenedor":
                            this.Descripcion = "Código de Contenedor";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "NombreDeLaSeccion":
                            this.Descripcion = "Sección";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "CodigoDeLaSeccion":
                            this.Descripcion = "Código de Sección";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "NombreDeLaLocacion":
                            this.Descripcion = "Estante/Vodega/Vitrina";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "CodigoDeLocacion":
                            this.Descripcion = "Código de Bodega";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "NombreDeLaBodega":
                            this.Descripcion = "Nombre de la Bodega";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "CodigoDeBodega":
                            this.Descripcion = "Código de Bodega";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;
                        case "NombreDelAlmacen":
                            this.Descripcion = "Nombre del Almacen";
                            this.Tamano = 160;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;
                        case "CodigoDelAlmacen":
                            this.Descripcion = "Código del Almacen";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "idContenedor":
                            this.Descripcion = "ID";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;
                            break;

                        default: this.ValorEncontrado = false; break;
                    }

                    break;

                case "ProductoSustitutos":

                    this.ValorEncontrado = true;

                    switch (Columna)
                    {

                        case "NombreGenerico":
                            this.Descripcion = "Nombre Generico";
                            this.Tamano = 160;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Nombre":
                            this.Descripcion = "Producto";
                            this.Tamano = 160;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;
                        case "CodigoDeBarra":
                            this.Descripcion = "Código de Barra";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;
                        case "Codigo":
                            this.Descripcion = "Código";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "idBodegaLocacion":
                            this.Descripcion = "ID";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;
                            break;

                        default: this.ValorEncontrado = false; break;
                    }

                    break;
                case "BodegaLocacion":

                    this.ValorEncontrado = true;

                    switch (Columna)
                    {

                        case "Descripcion":
                            this.Descripcion = "Descripción";
                            this.Tamano = 200;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Nombre":
                            this.Descripcion = "Sección";
                            this.Tamano = 200;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Codigo":
                            this.Descripcion = "Código";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "idLocacion":
                            this.Descripcion = "ID";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;
                            break;

                        default: this.ValorEncontrado = false; break;
                    }

                    break;

                case "BodegaAlmacen":

                    this.ValorEncontrado = true;

                    switch (Columna)
                    {

                        case "Descripcion":
                            this.Descripcion = "Descripción";
                            this.Tamano = 200;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Nombre":
                            this.Descripcion = "Bodega";
                            this.Tamano = 200;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Codigo":
                            this.Descripcion = "Código";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "idBodega":
                            this.Descripcion = "ID";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;
                            break;

                        default: this.ValorEncontrado = false; break;
                    }

                    break;

                case "LocacionSeccion":

                    this.ValorEncontrado = true;

                    switch (Columna)
                    {

                        case "Descripcion":
                            this.Descripcion = "Descripción";
                            this.Tamano = 200;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Nombre":
                            this.Descripcion = "Sección";
                            this.Tamano = 200;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Codigo":
                            this.Descripcion = "Código";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "idLocacionSeccion":
                            this.Descripcion = "ID";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;
                            break;

                        default: this.ValorEncontrado = false; break;
                    }

                    break;

                case "SeccionContenedor":

                    this.ValorEncontrado = true;

                    switch (Columna)
                    {

                        case "Descripcion":
                            this.Descripcion = "Descripción";
                            this.Tamano = 200;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Nombre":
                            this.Descripcion = "Contenedor";
                            this.Tamano = 200;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Codigo":
                            this.Descripcion = "Código";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "idLocacionSeccion":
                            this.Descripcion = "ID";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;
                            break;

                        default: this.ValorEncontrado = false; break;
                    }

                    break;

                case "TipoDeSalida":

                    this.ValorEncontrado = true;

                    switch (Columna)
                    {

                        case "Descripcion":
                            this.Descripcion = "Descripción";
                            this.Tamano = 200;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Nombre":
                            this.Descripcion = "Tipo de Salida";
                            this.Tamano = 200;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "idTipoDeSalida":
                            this.Descripcion = "ID";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;
                            break;

                        default: this.ValorEncontrado = false; break;
                    }

                    break;

                case "Producto":

                    this.ValorEncontrado = true;

                    switch (Columna)
                    {

                        case "ValorDelIva":
                            this.Descripcion = "Valor del IVA";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            break;

                        case "ValorDelIvaEnProcentaje":
                            this.Descripcion = "%IVA";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            break;

                        case "AplicarElIva":
                            this.Descripcion = "IVA";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;
                            break;

                        case "Precio5":
                            this.Descripcion = "Precio 5";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            break;

                        case "Precio4":
                            this.Descripcion = "Precio 4";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            break;

                        case "Precio3":
                            this.Descripcion = "Precio 3";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            break;

                        case "Precio2":
                            this.Descripcion = "Precio 2";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            break;

                        case "Precio1":
                            this.Descripcion = "Precio 1";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            break;

                        case "PorcentajeDelPrecio5":
                            this.Descripcion = "%Precio5";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            break;

                        case "Presentacion":
                            this.Descripcion = "Presentación";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "PorcentajeDelPrecio4":
                            this.Descripcion = "%Precio4";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            break;

                        case "PorcentajeDelPrecio3":
                            this.Descripcion = "%Precio3";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            break;

                        case "PorcentajeDelPrecio2":
                            this.Descripcion = "%Precio2";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            break;

                        case "PorcentajeDelPrecio1":
                            this.Descripcion = "%Precio1";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            break;

                        case "Costo":
                            this.Descripcion = "Costo";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            break;

                        case "UnidadDeMedida":
                            this.Descripcion = "UM";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Maximo":
                            this.Descripcion = "Máximo";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            break;

                        case "Minimo":
                            this.Descripcion = "Mínimo";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            break;

                        case "Existencias":
                            this.Descripcion = "Existencias";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;
                            break;

                        case "Observaciones":
                            this.Descripcion = "Observación del Producto";
                            this.Tamano = 200;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Descripcion":
                            this.Descripcion = "Descripción del Producto";
                            this.Tamano = 200;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "CodigoDeBarra":
                            this.Descripcion = "Código de Barra";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Codigo":
                            this.Descripcion = "Código";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "NombreComun":
                            this.Descripcion = "Nombre Común";
                            this.Tamano = 160;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "NombreGenerico":
                            this.Descripcion = "Nombre Genérico";
                            this.Tamano = 160;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Nombre":
                            this.Descripcion = "Producto";
                            this.Tamano = 160;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "PresentacionDelProducto":
                            this.Descripcion = "Presentación";
                            this.Tamano = 160;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "CodigoDelProveedorLaboratorio":
                            this.Descripcion = "Proveedor/Laboratorio";
                            this.Tamano = 160;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Proveedor":
                            this.Descripcion = "Proveedor";
                            this.Tamano = 160;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Laboratorio":
                            this.Descripcion = "Laboratorio";
                            this.Tamano = 160;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "CodigoDeAlmacenamiento":
                            this.Descripcion = "Código de Almacenamiento";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "idProducto":
                            this.Descripcion = "ID";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;
                            break;

                        default: this.ValorEncontrado = false; break;
                    }

                    break;

                case "ProductoUnidadDeMedida":

                    this.ValorEncontrado = true;

                    switch (Columna)
                    {
                        case "Abreviatura":
                            this.Descripcion = "Abreviatura";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Descripcion":
                            this.Descripcion = "Descripción";
                            this.Tamano = 200;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Nombre":
                            this.Descripcion = "Unidad de Medida del producto";
                            this.Tamano = 200;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "idProductoUnidadDeMedida":
                            this.Descripcion = "ID";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;
                            break;

                        default: this.ValorEncontrado = false; break;
                    }

                    break;

                case "ProductoPresentacion":

                    this.ValorEncontrado = true;

                    switch (Columna)
                    {
                        case "Abreviatura":
                            this.Descripcion = "Abreviatura";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Descripcion":
                            this.Descripcion = "Descripción";
                            this.Tamano = 200;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Nombre":
                            this.Descripcion = "Presentación del producto";
                            this.Tamano = 200;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "idProductoPresentacion":
                            this.Descripcion = "ID";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;
                            break;

                        default: this.ValorEncontrado = false; break;
                    }

                    break;

                case "Seccion":

                    this.ValorEncontrado = true;

                    switch (Columna)
                    {

                        case "Descripcion":
                            this.Descripcion = "Descripción";
                            this.Tamano = 200;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "CodigoDeAlmacenaje":
                            this.Descripcion = "Código de Almacenaje";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Nombre":
                            this.Descripcion = "Sección";
                            this.Tamano = 200;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "idSeccion":
                            this.Descripcion = "ID";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;
                            break;

                        default: this.ValorEncontrado = false; break;
                    }

                    break;

                case "Bodega":

                    this.ValorEncontrado = true;

                    switch (Columna)
                    {
                        case "Almacen":
                            this.Descripcion = "Almacen";
                            this.Tamano = 160;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;
                            break;

                        case "CodigoDeAlmacenaje":
                            this.Descripcion = "Codigo de Almacenaje";
                            this.Tamano = 160;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;
                            break;


                        case "PorDefectoParaFacturacion":
                            this.Descripcion = "Por defecto para Facturación";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;
                            break;

                        case "Descripcion":
                            this.Descripcion = "Descripción";
                            this.Tamano = 260;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Nombre":
                            this.Descripcion = "Bodega";
                            this.Tamano = 230;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Codigo":
                            this.Descripcion = "Código";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "idBodega":
                            this.Descripcion = "ID";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;
                            break;

                        default: this.ValorEncontrado = false; break;
                    }

                    break;

                case "Contenedor":

                    this.ValorEncontrado = true;

                    switch (Columna)
                    {

                        case "Descripcion":
                            this.Descripcion = "Descripción";
                            this.Tamano = 260;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "CodigoDeAlmacenaje":
                            this.Descripcion = "Código de Almacenaje";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Nombre":
                            this.Descripcion = "Sección";
                            this.Tamano = 230;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Codigo":
                            this.Descripcion = "Código";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "idContenedor":
                            this.Descripcion = "ID";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;
                            break;

                        default: this.ValorEncontrado = false; break;
                    }

                    break;

                case "Almacen":

                    this.ValorEncontrado = true;

                    switch (Columna)
                    {
                        case "PorDefecto":
                            this.Descripcion = "Por Defecto";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;
                            break;

                        case "Descripcion":
                            this.Descripcion = "Descripción";
                            this.Tamano = 200;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Nombre":
                            this.Descripcion = "Almacen";
                            this.Tamano = 200;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Codigo":
                            this.Descripcion = "Código";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "idAlmacen":
                            this.Descripcion = "ID";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;
                            break;

                        default: this.ValorEncontrado = false; break;
                    }

                    break;

                case "Categoria":

                    this.ValorEncontrado = true;

                    switch (Columna)
                    {
                        case "Descripcion":
                            this.Descripcion = "Descripción";
                            this.Tamano = 200;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Nombre":
                            this.Descripcion = "Categoria";
                            this.Tamano = 200;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "idCategoria":
                            this.Descripcion = "ID";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;
                            break;

                        default: this.ValorEncontrado = false; break;
                    }

                    break;

                case "Locacion":

                    this.ValorEncontrado = true;

                    switch (Columna)
                    {
                        case "CodigoDeAlmacenaje":
                            this.Descripcion = "Codigo de Almacenaje";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Descripcion":
                            this.Descripcion = "Descripción";
                            this.Tamano = 200;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Nombre":
                            this.Descripcion = "Locación del producto";
                            this.Tamano = 200;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "idLocacion":
                            this.Descripcion = "ID";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;
                            break;

                        default: this.ValorEncontrado = false; break;
                    }

                    break;

                case "TipoDeUbicacion":

                    this.ValorEncontrado = true;

                    switch (Columna)
                    {
                        case "Descripcion":
                            this.Descripcion = "Descripción";
                            this.Tamano = 260;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Nombre":
                            this.Descripcion = "Tipo de Ubicación";
                            this.Tamano = 200;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "idTipoDeUbicacion":
                            this.Descripcion = "ID";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;
                            break;

                        default: this.ValorEncontrado = false; break;
                    }

                    break;

                case "Contacto":

                    this.ValorEncontrado = true;

                    switch (Columna)
                    {

                        case "Cedula":
                            this.Descripcion = "Cédula";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Sexo":
                            this.Descripcion = "Sexo";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Estado":
                            this.Descripcion = "Estado";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Facebook":
                            this.Descripcion = "Facebook";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Twitter":
                            this.Descripcion = "Twitter";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Skype":
                            this.Descripcion = "Skype";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Messenger":
                            this.Descripcion = "Messenger";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "FechaDeCumpleanos":
                            this.Descripcion = "Fecha Festiva";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Correo":
                            this.Descripcion = "Correo Electrónico";
                            this.Tamano = 250;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Descripcion":
                            this.Descripcion = "Observaciones";
                            this.Tamano = 250;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Observaciones":
                            this.Descripcion = "Observaciones";
                            this.Tamano = 250;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Movil":
                            this.Descripcion = "Movil";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Telefono":
                            this.Descripcion = "Teléfono";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Direccion":
                            this.Descripcion = "Dirección";
                            this.Tamano = 200;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Contacto":
                            this.Descripcion = "Contacto";
                            this.Tamano = 200;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Nombre":
                            this.Descripcion = "Contacto";
                            this.Tamano = 200;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Codigo":
                            this.Descripcion = "Código";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "idContacto":
                            this.Descripcion = "ID";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;
                            break;

                        default: this.ValorEncontrado = false; break;
                    }

                    break;

                case "Proveedor":

                    this.ValorEncontrado = true;

                    switch (Columna)
                    {

                        case "Estado":
                            this.Descripcion = "Estado";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Facebook":
                            this.Descripcion = "Facebook";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Twitter":
                            this.Descripcion = "Twitter";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Skype":
                            this.Descripcion = "Skype";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Messenger":
                            this.Descripcion = "Messenger";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "FechaDeCumpleanos":
                            this.Descripcion = "Fecha Festiva";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Correo":
                            this.Descripcion = "Correo Electrónico";
                            this.Tamano = 250;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Descripcion":
                            this.Descripcion = "Observaciones";
                            this.Tamano = 250;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Observaciones":
                            this.Descripcion = "Observaciones";
                            this.Tamano = 250;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Movil":
                            this.Descripcion = "Movil";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Telefono":
                            this.Descripcion = "Teléfono";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "SitioWeb":
                            this.Descripcion = "Sitio Web";
                            this.Tamano = 160;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "NoRUC":
                            this.Descripcion = "No RUC";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Direccion":
                            this.Descripcion = "Dirección";
                            this.Tamano = 200;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Proveedor":
                            this.Descripcion = "Proveedor";
                            this.Tamano = 200;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Nombre":
                            this.Descripcion = "Proveedor";
                            this.Tamano = 200;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Codigo":
                            this.Descripcion = "Código";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "idProveedor":
                            this.Descripcion = "ID";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;
                            break;

                        default: this.ValorEncontrado = false; break;
                    }

                    break;

                case "Laboratorio":

                    this.ValorEncontrado = true;

                    switch (Columna)
                    {

                        case "Estado":
                            this.Descripcion = "Estado";
                            this.Tamano = 80;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Facebook":
                            this.Descripcion = "Facebook";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Twitter":
                            this.Descripcion = "Twitter";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Skype":
                            this.Descripcion = "Skype";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Messenger":
                            this.Descripcion = "Messenger";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "FechaDeCumpleanos":
                            this.Descripcion = "Fecha Festiva";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Correo":
                            this.Descripcion = "Correo Electrónico";
                            this.Tamano = 250;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Descripcion":
                            this.Descripcion = "Observaciones";
                            this.Tamano = 250;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Observaciones":
                            this.Descripcion = "Observaciones";
                            this.Tamano = 250;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Movil":
                            this.Descripcion = "Movil";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Telefono":
                            this.Descripcion = "Teléfono";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "SitioWeb":
                            this.Descripcion = "Sitio Web";
                            this.Tamano = 160;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "NoRUC":
                            this.Descripcion = "No RUC";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Direccion":
                            this.Descripcion = "Dirección";
                            this.Tamano = 200;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Laboratorio":
                            this.Descripcion = "Laboratorio";
                            this.Tamano = 200;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Nombre":
                            this.Descripcion = "Laboratorio";
                            this.Tamano = 200;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "Codigo":
                            this.Descripcion = "Código";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            break;

                        case "idLaboratorio":
                            this.Descripcion = "ID";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;
                            break;

                        default: this.ValorEncontrado = false; break;
                    }

                    break;

                case "Rol":

                    this.ValorEncontrado = true;

                    switch (Columna)
                    {
                        case "IdRol":
                            this.Descripcion = "ID";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;

                            break;

                        case "Nombre":
                            this.Descripcion = "Tipo de cuenta";
                            this.Tamano = 350;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;

                            break;

                        case "Descripcion":
                            this.Descripcion = "Descripción de la cuenta";
                            this.Tamano = 300;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;

                            break;

                        default: this.ValorEncontrado = false; break;
                    }

                    break;

                case "Usuario":

                    this.ValorEncontrado = true;

                    switch (Columna)
                    {
                        case "Estado":
                            this.Descripcion = "Estado";
                            this.Tamano = 160;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;

                            break;

                        case "TipoDeCuenta":
                            this.Descripcion = "Tipo de cuenta";
                            this.Tamano = 160;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;

                            break;

                        case "Email":
                            this.Descripcion = "Correo electronico";
                            this.Tamano = 160;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;

                            break;

                        case "Login":
                            this.Descripcion = "Nombre de sesión";
                            this.Tamano = 300;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;

                            break;

                        case "Usuario":
                            this.Descripcion = "Nombre del Usuario";
                            this.Tamano = 300;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;

                            break;

                        case "IdUsuario":
                            this.Descripcion = "ID";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;

                            break;

                        default: this.ValorEncontrado = false; break;
                    }

                    break;

                case "TasaDeCambio":

                    this.ValorEncontrado = true;

                    switch (Columna)
                    {
                        case "Cambio":
                            this.Descripcion = "Cambio";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;

                            break;

                        case "FechaDelCambio":
                            this.Descripcion = "Fecha del Cambio Oficial";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;

                            break;

                        case "idTasaDeCambio":
                            this.Descripcion = "ID";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;

                            break;

                        default: this.ValorEncontrado = false; break;
                    }

                    break;

                case "ImPortarProductos":

                    this.ValorEncontrado = true;

                    switch (Columna)
                    {
                        case "PRODUCTO":
                            this.Descripcion = "Producto";
                            this.Tamano = 160;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = true;

                            break;

                        case "PROVEEDOR":
                            this.Descripcion = "Proveedor";
                            this.Tamano = 160;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;

                            break;

                        case "LABORATORIO":
                            this.Descripcion = "Laboratorio";
                            this.Tamano = 160;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;

                            break;

                        case "DESCRIPCION":
                            this.Descripcion = "Descripción";
                            this.Tamano = 160;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;

                            break;

                        case "PRESENTACION":
                            this.Descripcion = "Presentación";
                            this.Tamano = 160;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;

                            break;

                        case "UNIDADESXPRESENTACION":
                            this.Descripcion = "UXP";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;

                            break;

                        case "UNIDADDEMEDIDA":
                            this.Descripcion = "Unidad de Medida";
                            this.Tamano = 160;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;

                            break;

                        case "CODIGODEBARRA":
                            this.Descripcion = "Código de Barra";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;

                            break;

                        case "CODIGODEUBICACION":
                            this.Descripcion = "Código de Ubicación";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;

                            break;

                        case "CATEGORIA":
                            this.Descripcion = "Categoria";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;

                            break;

                        default: this.ValorEncontrado = false; break;
                    }

                    break;

                default: this.ValorEncontrado = false; break;

            }

        }

    }
}
