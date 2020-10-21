using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using Entidad;

namespace Acceso
{
    public class AreaLaboralAD
    {
        public string Error { set; get; }
        private MySqlConnection Cnn = null;
        private MySqlCommand Comando = null;
        private MySqlDataAdapter Adaptador = null;
        private TransaccionesAD oTransaccionsaccionesAD = null;
        string Consultas;
        string DescripcionDeLaOperacion;
        private DataTable DT { set; get; }

        public AreaLaboralAD()
        {

            oTransaccionsaccionesAD = new TransaccionesAD();
            oTransaccionsaccionesAD.Modulo = "General";
            oTransaccionsaccionesAD.Modelo = "AreaLaboralAD";
            oTransaccionsaccionesAD.NombreDelEquipo = Environment.MachineName;
            oTransaccionsaccionesAD.FechaDeCreacion = System.DateTime.Now;
            oTransaccionsaccionesAD.Tabla = "AreaLaboral";

        }

        #region "Funciones dll"
        public bool Agregar(AreaLaboralEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            oTransaccionsaccionesAD = new TransaccionesAD();
            try
            {
                InicializarVariablesGlovales(oDatos);

                Consultas = @"insert into arealaboral
                            (Area)
                            value
                            (@Area);
                            select last_insert_id() as 'ID'; ";
                Comando.CommandText = Consultas;

                Comando.Parameters.Add(new MySqlParameter("@Area", MySqlDbType.VarChar, oRegistroEN.Area.Trim().Length)).Value = oRegistroEN.Area.Trim();

                InicializarAdaptador();

                oRegistroEN.IdAreaLaboral = Convert.ToInt32(DT.Rows[0].ItemArray[0].ToString());

                DescripcionDeLaOperacion = string.Format("El registro fue insertado correctamente. {0} {1}", Environment.NewLine, InformacionDelRegistro(oRegistroEN));

                //Agragamos la transaccion...
                TransaccionesEN oTransaccionsacciones = InformacionDeLaTransaccion(oRegistroEN, "Agregar", "Agregar Nuevo Registro", "CORRECTO");
                oTransaccionsaccionesAD.Agregar(oTransaccionsacciones, oDatos);

                return true;
            }
            catch (Exception ex)
            {
                this.Error = ex.Message;
                DescripcionDeLaOperacion = string.Format("Se produjo el seguiente error: '{2}' al insertar el registro. {0} {1} ", Environment.NewLine, InformacionDelRegistro(oRegistroEN), ex.Message);

                //Agregamos la Transacción....
                TransaccionesEN oTransaccionsacciones = InformacionDeLaTransaccion(oRegistroEN, "Agregar", "Agregar Nuevo Registro", "ERROR");
                oTransaccionsaccionesAD.Agregar(oTransaccionsacciones, oDatos);

                return false;
            }
            finally
            {
                FinalizarConexion();
                 oTransaccionsaccionesAD = null;
            }
        }

        public bool Actualizar(AreaLaboralEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            oTransaccionsaccionesAD = new TransaccionesAD();

            try
            {
                InicializarVariablesGlovales(oDatos);

                Consultas = @"update arealaboral set
                                Area = @Area
                                where IdAreaLaboral = @IdAreaLaboral;";

                Comando.CommandText = Consultas;

                Comando.Parameters.Add(new MySqlParameter("@Area", MySqlDbType.VarChar, oRegistroEN.Area.Trim().Length)).Value = oRegistroEN.Area.Trim();

                Comando.ExecuteNonQuery();

                DescripcionDeLaOperacion = string.Format("El registro fue Actualizado Correctamente. {0} {1}", Environment.NewLine, InformacionDelRegistro(oRegistroEN));

                //Agregamos la Transacción....
                TransaccionesEN oTransaccionsacciones = InformacionDeLaTransaccion(oRegistroEN, "Actualizar", "Actualizar Registro", "CORRECTO");
                oTransaccionsaccionesAD.Agregar(oTransaccionsacciones, oDatos);

                return true;

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                DescripcionDeLaOperacion = string.Format("Se produjo el seguiente error: '{2}' al actualizar el registro. {0} {1} ", Environment.NewLine, InformacionDelRegistro(oRegistroEN), ex.Message);

                //Agregamos la Transacción....
                TransaccionesEN oTransaccionsacciones = InformacionDeLaTransaccion(oRegistroEN, "Actualizar", "Actualizar Registro", "ERROR");
                oTransaccionsaccionesAD.Agregar(oTransaccionsacciones, oDatos);

                return false;
            }
            finally
            {
                FinalizarConexion();
                oTransaccionsaccionesAD = null;
            }
        }
        public bool Eliminar(AreaLaboralEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            oTransaccionsaccionesAD = new TransaccionesAD();

            try
            {

                InicializarVariablesGlovales(oDatos);

                Consultas = @"Delete from AreaLaboral where IdAreaLaboral = @IdAreaLaboral;";
                Comando.CommandText = Consultas;

                Comando.Parameters.Add(new MySqlParameter("@IdAreaLaboral", MySqlDbType.Int32)).Value = oRegistroEN.IdAreaLaboral;

                Comando.ExecuteNonQuery();

                DescripcionDeLaOperacion = string.Format("El registro fue Eliminado Correctamente. {0} {1}", Environment.NewLine, InformacionDelRegistro(oRegistroEN));

                //Agregamos la Transacción....
                TransaccionesEN oTransaccionsacciones = InformacionDeLaTransaccion(oRegistroEN, "Eliminar", "Elminar Registro", "CORRECTO");
                oTransaccionsaccionesAD.Agregar(oTransaccionsacciones, oDatos);

                return true;

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                DescripcionDeLaOperacion = string.Format("Se produjo el seguiente error: '{2}' al eliminar el registro. {0} {1} ", Environment.NewLine, InformacionDelRegistro(oRegistroEN), ex.Message);

                //Agregamos la Transacción....
                TransaccionesEN oTransaccionsacciones = InformacionDeLaTransaccion(oRegistroEN, "Eliminar", "Eliminar Registro", "ERROR");
                oTransaccionsaccionesAD.Agregar(oTransaccionsacciones, oDatos);

                return false;
            }
            finally
            {
                FinalizarConexion();
                oTransaccionsaccionesAD = null;
            }

        }

        public bool Listado(AreaLaboralEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            try
            {
                InicializarVariablesGlovales(oDatos);

                Consultas = string.Format(@"select al.Area AS 'Area Laboral', esa.Nombre as 'Empresa' 
								            from arealaboral as al
                                            inner join empresa as esa on al.IdEmpresa = esa.IdEmpresa
                                            where al.IdAreaLaboral > 0  {0} {1} ", oRegistroEN.Where, oRegistroEN.OrderBy);

                Comando.CommandText = Consultas;

                InicializarAdaptador();

                return true;
            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                return false;
            }
            finally
            {
                FinalizarConexion();
            }
        }

        public bool ListadoPorIdentificador(AreaLaboralEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            try
            {
                InicializarVariablesGlovales(oDatos);

                Consultas = string.Format(@"select al.IdAreaLaboral, al.Area as 'Area Laboral', al.IdEmpresa, esa.Nombre as 'Empresa' 
								            from arealaboral as al
                                            inner join empresa as esa on al.IdEmpresa = esa.IdEmpresa
                                            where al.IdAreaLaboral > {0}", oRegistroEN.IdAreaLaboral);

                Comando.CommandText = Consultas;
                

                InicializarAdaptador();

                return true;
            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                return false;
            }
            finally
            {
                FinalizarConexion();
            }
        }

        public bool ListadoParaCombos(AreaLaboralEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                InicializarVariablesGlovales(oDatos);

                Consultas = string.Format(@"select al.IdAreaLaboral, al.Area as 'Area Laboral', al.IdEmpresa, esa.Nombre as 'Empresa' 
								            from arealaboral as al
                                            inner join empresa as esa on al.IdEmpresa = esa.IdEmpresa
                                            where al.IdAreaLaboral > 0 {0} {1}; ", oRegistroEN.Where, oRegistroEN.OrderBy);
                Comando.CommandText = Consultas;

                InicializarAdaptador();

                return true;

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                return false;
            }
            finally
            {

                FinalizarConexion();

            }

        }

        public bool ListadoParaReportes(AreaLaboralEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                InicializarVariablesGlovales(oDatos);

                Consultas = string.Format(@"select IdAreaLaboral, Area, IdEmpresa from arealaboral where IdAreaLaboral > 0 {0} {1} ", oRegistroEN.Where, oRegistroEN.OrderBy);
                Comando.CommandText = Consultas;

                InicializarAdaptador();

                return true;

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                return false;
            }
            finally
            {

                FinalizarConexion();

            }

        }

        #endregion

        #region "Funciones de retorno"

        public DataTable TraerDatos()
        {
            return DT;
        }

        private void InicializarVariablesGlovales(DatosDeConexionEN oDatos)
        {
            Cnn = new MySqlConnection(TraerCadenaDeConexion(oDatos));
            Cnn.Open();

            Comando = new MySqlCommand();
            Comando.Connection = Cnn;
            Comando.CommandType = CommandType.Text;
        }
        private void InicializarVariablesGlovalesProcedure(DatosDeConexionEN oDatos)
        {
            Cnn = new MySqlConnection(TraerCadenaDeConexion(oDatos));
            Cnn.Open();

            Comando = new MySqlCommand();
            Comando.Connection = Cnn;
            Comando.CommandType = CommandType.StoredProcedure;
            
        }
        private void InicializarAdaptador()
        {
            Adaptador = new MySqlDataAdapter();
            DT = new DataTable();

            Adaptador.SelectCommand = Comando;
            Adaptador.Fill(DT);
        }
        private string TraerCadenaDeConexion(DatosDeConexionEN oDatos)
        {
            string cadena = string.Format("Data Source='{0}';Initial Catalog='{1}';Persist Security Info=True;User ID='{2}';Password='{3}'", oDatos.Servidor, oDatos.BaseDeDatos, oDatos.Usuario, oDatos.Contrasena);
            return cadena;
        }
        private string InformacionDelRegistro(AreaLaboralEN oRegistroEN)
        {
            string Cadena = @"IdAreaLaboral: {0}, Area: {1}";
            Cadena = string.Format(Cadena, oRegistroEN.IdAreaLaboral, oRegistroEN.Area);
            Cadena = Cadena.Replace(",", Environment.NewLine);
            return Cadena;
        }
        private TransaccionesEN InformacionDeLaTransaccion(AreaLaboralEN oAreaLaboral, string TipoDeOperacion, string Descripcion, string Estado)
        {
            TransaccionesEN oRegistroEN = new TransaccionesEN();

            oRegistroEN.IdRegistro = oAreaLaboral.IdAreaLaboral;
            oRegistroEN.Modelo = "AreaLaboralAD";
            oRegistroEN.Tabla = "AreaLaboral";
            oRegistroEN.TipoDeOperacion = TipoDeOperacion;
            oRegistroEN.Estado = Estado;
            oRegistroEN.IP = oAreaLaboral.oLoginEN.NumeroIP;
            oRegistroEN.IdUsuario = oAreaLaboral.oLoginEN.IdUsuario;
            oRegistroEN.IdUsuarioAPrueva = oAreaLaboral.oLoginEN.IdUsuario;
            oRegistroEN.DescripcionDelUsuario = DescripcionDeLaOperacion;
            oRegistroEN.DescripcionInterna = Descripcion;
            oRegistroEN.nombredelequipo = oAreaLaboral.oLoginEN.NombreDelEquipo;

            return oRegistroEN;
        }
        private void FinalizarConexion()
        {
            if (Cnn != null)
            {
                if (Cnn.State == ConnectionState.Open)
                {
                    Cnn.Close();
                }
            }
            Cnn = null;
            Comando = null;
            Adaptador = null;
        }
        #endregion

        #region "Funciones de validacion"
        public bool ValidarSiElRegistroEstaVinculado(AreaLaboralEN oRegistroEN, DatosDeConexionEN oDatos, string TipoDeOperacion)
        {
            oTransaccionsaccionesAD = new TransaccionesAD();

            try
            {

                InicializarVariablesGlovalesProcedure(oDatos);
                Comando.CommandText = "ValidarSiElRegistroEstaVinculado";

                Comando.Parameters.Add(new MySqlParameter("@CampoABuscar_", MySqlDbType.VarChar, 200)).Value = "idDepartamentoOrganizacional";
                Comando.Parameters.Add(new MySqlParameter("@ValorCampoABuscar", MySqlDbType.Int32)).Value = oRegistroEN.IdAreaLaboral;
                Comando.Parameters.Add(new MySqlParameter("@ExcluirTabla_", MySqlDbType.VarChar, 200)).Value = string.Empty;

                Adaptador = new MySqlDataAdapter();
                DT = new DataTable();

                Adaptador.SelectCommand = Comando;
                Adaptador.Fill(DT);

                if (DT.Rows[0].ItemArray[0].ToString().ToUpper() == "NINGUNA".ToUpper())
                {
                    return false;
                }
                else
                {

                    this.Error = String.Format("La Operación: '{1}', {0} no se puede completar por que el registro: {0} '{2}', {0} se encuentra asociado con: {0} {3}", Environment.NewLine, TipoDeOperacion, InformacionDelRegistro(oRegistroEN));
                    DescripcionDeLaOperacion = this.Error;

                    //Agregamos la Transacción....
                    TransaccionesEN oTransaccion = InformacionDeLaTransaccion(oRegistroEN, "VALIDAR", "VALIDAR SI EL REGISTRO ESTA VINCULADO", "CORRECTO");
                    oTransaccionsaccionesAD.Agregar(oTransaccion, oDatos);

                    return true;
                }

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                DescripcionDeLaOperacion = string.Format("Se produjo el seguiente error: '{2}' al validar el registro. {0} {1} ", Environment.NewLine, InformacionDelRegistro(oRegistroEN), ex.Message);

                //Agregamos la Transacción....
                TransaccionesEN oTransaccionsacciones = InformacionDeLaTransaccion(oRegistroEN, "VALIDAR", "VALIDAR SI EL REGISTRO ESTA VINCULADO", "ERROR");
                oTransaccionsaccionesAD.Agregar(oTransaccionsacciones, oDatos);

                return false;
            }
            finally
            {

                FinalizarConexion();
                oTransaccionsaccionesAD = null;

            }

        }
        #endregion

    }
}
