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
    public class ConfiguracionAD
    {
        public string Error { set; get; }
        private MySqlConnection Cnn = null;
        private MySqlCommand Comando = null;
        private MySqlDataAdapter Adaptador = null;
        private TransaccionesAD oTransaccionesAD = null;
        string DescripcionDeLaOperacion;
        string Consultas;
        private DataTable DT { set; get; }

        public ConfiguracionAD()
        {

            oTransaccionesAD = new TransaccionesAD();
            oTransaccionesAD.Modulo = "General";
            oTransaccionesAD.Modelo = "ConfiguracionAD";
            oTransaccionesAD.NombreDelEquipo = Environment.MachineName;
            oTransaccionesAD.FechaDeCreacion = System.DateTime.Now;
            oTransaccionesAD.Tabla = "Configuracion";

        }

        #region "Funciones dll"
        public bool Agregar(ConfiguracionEN oRegistroEN, DatosDeConexionEN oDatos)
        {           
            try
            {
                InicializarVariablesGlovales(oDatos);

                Consultas = @"insert into configuracion
                            (RutaDeRespaldo, RutaDeRespaldoDeEcxel, PathMySqlDump, 
                            PathMySql, NombreDelSistema, TiempoDeRespaldo, ImpuestoDeValorAgregado, 
                            CorreoDelRemitente, ServicioSmtp, ContrasenaDelRemitente, 
                            PuertoDelServidor, AsuntoDelCorreo, MensageDelCorreo)
                            value
                            (@RutaDeRespaldo, @RutaDeRespaldoDeEcxel, @PathMySqlDump, @PathMySql, 
                            @NombreDelSistema, @TiempoDeRespaldo, @ImpuestoDeValorAgregado, @CorreoDelRemitente, 
                            @ServicioSmtp, @ContrasenaDelRemitente, @PuertoDelServidor, @AsuntoDelCorreo, @MensageDelCorreo);

                            select last_insert_id() as 'ID';";

                Comando.CommandText = Consultas;

                Comando.Parameters.Add(new MySqlParameter("@RutaDeRespaldo", MySqlDbType.VarChar, oRegistroEN.RutaDeRespaldo.Trim().Length)).Value = oRegistroEN.RutaDeRespaldo.Trim();
                Comando.Parameters.Add(new MySqlParameter("@RutaDeRespaldoDeEcxel", MySqlDbType.VarChar, oRegistroEN.RutaRespaldosDeExcel.Trim().Length)).Value = oRegistroEN.RutaRespaldosDeExcel.Trim();
                Comando.Parameters.Add(new MySqlParameter("@PathMySqlDump", MySqlDbType.VarChar, oRegistroEN.PathMySQLDump.Trim().Length)).Value = oRegistroEN.PathMySQLDump.Trim();
                Comando.Parameters.Add(new MySqlParameter("@PathMySql", MySqlDbType.VarChar, oRegistroEN.PathMySQL.Trim().Length)).Value = oRegistroEN.PathMySQL.Trim();
                Comando.Parameters.Add(new MySqlParameter("@NombreDelSistema", MySqlDbType.VarChar, oRegistroEN.NombreDelSistema.Trim().Length)).Value = oRegistroEN.NombreDelSistema.Trim();
                Comando.Parameters.Add(new MySqlParameter("@TiempoDeRespaldo", MySqlDbType.Int32)).Value = oRegistroEN.TiempoDeRespaldo;
                Comando.Parameters.Add(new MySqlParameter("@ImpuestoDeValorAgregado", MySqlDbType.Decimal)).Value = oRegistroEN.ImpuestoDeValorAgrgado;
                Comando.Parameters.Add(new MySqlParameter("@CorreoDelRemitente", MySqlDbType.VarChar, oRegistroEN.CorreoDelRemitente.Trim().Length)).Value = oRegistroEN.CorreoDelRemitente.Trim();
                Comando.Parameters.Add(new MySqlParameter("@ServicioSmtp", MySqlDbType.VarChar, oRegistroEN.ServicioSmtp.Trim().Length)).Value = oRegistroEN.ServicioSmtp.Trim();
                Comando.Parameters.Add(new MySqlParameter("@ContrasenaDelRemitente", MySqlDbType.VarChar, oRegistroEN.ContrasenaDelRemitente.Trim().Length)).Value = oRegistroEN.ContrasenaDelRemitente.Trim();
                Comando.Parameters.Add(new MySqlParameter("@PuertoDelServidor", MySqlDbType.Int32)).Value = oRegistroEN.PuertoDelServidor;
                Comando.Parameters.Add(new MySqlParameter("@AsuntoDelCorreo", MySqlDbType.VarChar, oRegistroEN.AsuntoDelCorreo.Trim().Length)).Value = oRegistroEN.AsuntoDelCorreo.Trim();
                Comando.Parameters.Add(new MySqlParameter("@MensageDelCorreo", MySqlDbType.VarChar, oRegistroEN.MensageDelCorreo.Trim().Length)).Value = oRegistroEN.MensageDelCorreo.Trim();

                InicializarAdaptador();

                oRegistroEN.IdConfiguracion = Convert.ToInt32(DT.Rows[0].ItemArray[0].ToString());

                DescripcionDeLaOperacion = string.Format("El registro fue insertado correctamente. {0} {1}", Environment.NewLine, InformacionDelRegistro(oRegistroEN));

                oTransaccionesAD.Agregar(oRegistroEN.oLoginEN.IdUsuario, oRegistroEN.oLoginEN.NumeroIP, oRegistroEN.IdConfiguracion, "AGREGAR", "INFORMACIÓN DE LA CONFIGURACIÓN AGREGADA CORRECTAMENTE", "CORRECTA", DescripcionDeLaOperacion, oRegistroEN.oLoginEN.IdUsuario, oDatos);
                /*TransaccionesEN oTransacciones = InformacionDeLaTransaccion(oRegistroEN, "Agregar", "Agregar Nuevo Registro", "CORRECTO");
                oTransaccionesAD.Agregar(oTransacciones, oDatos);*/

                return true;
            }
            catch (Exception ex)
            {
                this.Error = ex.Message;
                DescripcionDeLaOperacion = string.Format("Se produjo el seguiente error: '{2}' al insertar el registro. {0} {1} ", Environment.NewLine, InformacionDelRegistro(oRegistroEN), ex.Message);

                oTransaccionesAD.Agregar(oRegistroEN.oLoginEN.IdUsuario, oRegistroEN.oLoginEN.NumeroIP, oRegistroEN.IdConfiguracion, "AGREGAR", "ERROR AL AGREGAR LA INFORMACIÓN DE LA CONFIGURACIÓN", "ERROR", DescripcionDeLaOperacion, oRegistroEN.oLoginEN.IdUsuario, oDatos);
                /*//Agregamos la Transacción....
                TransaccionesEN oTransacciones = InformacionDeLaTransaccion(oRegistroEN, "Agregar", "Agregar Nuevo Registro", "ERROR");
                oTransaccionesAD.Agregar(oTransacciones, oDatos);*/

                return false;
            }
            finally
            {
                FinalizarConexion();
                oTransaccionesAD = null;
            }
        }

        public bool Actualizar(ConfiguracionEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            try
            {
                InicializarVariablesGlovales(oDatos);
                Consultas = @"update configuracion set
                            RutaDeRespaldo = @RutaDeRespaldo,
                            RutaDeRespaldoDeEcxel = @RutaDeRespaldoDeEcxel,
                            PathMySqlDump = @PathMySqlDump,
                            PathMySql = @PathMySql,
                            NombreDelSistema = @NombreDelSistema,
                            TiempoDeRespaldo = @TiempoDeRespaldo,
                            ImpuestoDeValorAgregado = @ImpuestoDeValorAgregado,
                            CorreoDelRemitente = @CorreoDelRemitente,
                            ServicioSmtp = @ServicioSmtp,
                            ContrasenaDelRemitente = @ContrasenaDelRemitente,
                            PuertoDelServidor = @PuertoDelServidor,
                            AsuntoDelCorreo = @AsuntoDelCorreo,
                            MensageDelCorreo = @MensageDelCorreo
                            where IdConfiguracion = @IdConfiguracion;";

                Comando.CommandText = Consultas;

                Comando.Parameters.Add(new MySqlParameter("@IdConfiguracion", MySqlDbType.Int32)).Value = oRegistroEN.IdConfiguracion;
                Comando.Parameters.Add(new MySqlParameter("@RutaDeRespaldo", MySqlDbType.VarChar, oRegistroEN.RutaDeRespaldo.Trim().Length)).Value = oRegistroEN.RutaDeRespaldo.Trim();
                Comando.Parameters.Add(new MySqlParameter("@RutaDeRespaldoDeEcxel", MySqlDbType.VarChar, oRegistroEN.RutaRespaldosDeExcel.Trim().Length)).Value = oRegistroEN.RutaRespaldosDeExcel.Trim();
                Comando.Parameters.Add(new MySqlParameter("@PathMySqlDump", MySqlDbType.VarChar, oRegistroEN.PathMySQLDump.Trim().Length)).Value = oRegistroEN.PathMySQLDump.Trim();
                Comando.Parameters.Add(new MySqlParameter("@PathMySql", MySqlDbType.VarChar, oRegistroEN.PathMySQL.Trim().Length)).Value = oRegistroEN.PathMySQL.Trim();
                Comando.Parameters.Add(new MySqlParameter("@NombreDelSistema", MySqlDbType.VarChar, oRegistroEN.NombreDelSistema.Trim().Length)).Value = oRegistroEN.NombreDelSistema.Trim();
                Comando.Parameters.Add(new MySqlParameter("@TiempoDeRespaldo", MySqlDbType.Int32)).Value = oRegistroEN.TiempoDeRespaldo;
                Comando.Parameters.Add(new MySqlParameter("@ImpuestoDeValorAgregado", MySqlDbType.Decimal)).Value = oRegistroEN.ImpuestoDeValorAgrgado;
                Comando.Parameters.Add(new MySqlParameter("@CorreoDelRemitente", MySqlDbType.VarChar, oRegistroEN.CorreoDelRemitente.Trim().Length)).Value = oRegistroEN.CorreoDelRemitente.Trim();
                Comando.Parameters.Add(new MySqlParameter("@ServicioSmtp", MySqlDbType.VarChar, oRegistroEN.ServicioSmtp.Trim().Length)).Value = oRegistroEN.ServicioSmtp.Trim();
                Comando.Parameters.Add(new MySqlParameter("@ContrasenaDelRemitente", MySqlDbType.VarChar, oRegistroEN.ContrasenaDelRemitente.Trim().Length)).Value = oRegistroEN.ContrasenaDelRemitente.Trim();
                Comando.Parameters.Add(new MySqlParameter("@PuertoDelServidor", MySqlDbType.Int32)).Value = oRegistroEN.PuertoDelServidor;
                Comando.Parameters.Add(new MySqlParameter("@AsuntoDelCorreo", MySqlDbType.VarChar, oRegistroEN.AsuntoDelCorreo.Trim().Length)).Value = oRegistroEN.AsuntoDelCorreo.Trim();
                Comando.Parameters.Add(new MySqlParameter("@MensageDelCorreo", MySqlDbType.VarChar, oRegistroEN.MensageDelCorreo.Trim().Length)).Value = oRegistroEN.MensageDelCorreo.Trim();

                Comando.ExecuteNonQuery();

                DescripcionDeLaOperacion = string.Format("El registro fue Actualizado Correctamente. {0} {1}", Environment.NewLine, InformacionDelRegistro(oRegistroEN));

                oTransaccionesAD.Agregar(oRegistroEN.oLoginEN.IdUsuario, oRegistroEN.oLoginEN.NumeroIP, oRegistroEN.IdConfiguracion, "ACTUALIZAR", "INFORMACIÓN DE LA CONFIGURACIÓN ACTUALIZADA", "CORRECTA", DescripcionDeLaOperacion, oRegistroEN.oLoginEN.IdUsuario, oDatos);

                return true;

            }
            catch(Exception ex)
            {
                this.Error = ex.Message;

                DescripcionDeLaOperacion = string.Format("Se produjo el seguiente error: '{2}' al actualizar el registro. {0} {1} ", Environment.NewLine, InformacionDelRegistro(oRegistroEN), ex.Message);
                oTransaccionesAD.Agregar(oRegistroEN.oLoginEN.IdUsuario, oRegistroEN.oLoginEN.NumeroIP, oRegistroEN.IdConfiguracion, "ACTUALIZAR", "ERROR AL ACTUALIZAR LA INFORMACIÓN DE LA CONFIGURACIÓN", "ERROR", DescripcionDeLaOperacion, oRegistroEN.oLoginEN.IdUsuario, oDatos);

                return false;
            }
            finally
            {
                FinalizarConexion();
                oTransaccionesAD = null;
            }
        }

        public bool Eliminar(ConfiguracionEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            try
            {
                InicializarVariablesGlovales(oDatos);

                Consultas = @"delete from configuracion where IdConfiguracion = @IdConfiguracion;";
                Comando.CommandText = Consultas;

                Comando.Parameters.Add(new MySqlParameter("@IdConfiguracion", MySqlDbType.Int32)).Value = oRegistroEN.IdConfiguracion;

                Comando.ExecuteNonQuery();

                DescripcionDeLaOperacion = string.Format("El registro fue Eliminado Correctamente. {0} {1}", Environment.NewLine, InformacionDelRegistro(oRegistroEN));

                oTransaccionesAD.Agregar(oRegistroEN.oLoginEN.IdUsuario, oRegistroEN.oLoginEN.NumeroIP, oRegistroEN.IdConfiguracion, "ELIMINAR", "INFORMACIÓN DE LA CONFIGURACIÓN ELIMINADA", "CORRECTA", DescripcionDeLaOperacion, oRegistroEN.oLoginEN.IdUsuario, oDatos);

                return true;
            }
            catch(Exception ex)
            {
                this.Error = ex.Message;

                DescripcionDeLaOperacion = string.Format("Se produjo el seguiente error: '{2}' al eliminar el registro. {0} {1} ", Environment.NewLine, InformacionDelRegistro(oRegistroEN), ex.Message);
                oTransaccionesAD.Agregar(oRegistroEN.oLoginEN.IdUsuario, oRegistroEN.oLoginEN.NumeroIP, oRegistroEN.IdConfiguracion, "ELIMINAR", "ERROR AL ELIMINAR LA INFORMACIÓN DE LA CONFIGURACIÓN", "ERROR", DescripcionDeLaOperacion, oRegistroEN.oLoginEN.IdUsuario, oDatos);

                return false;
            }
            finally
            {
                FinalizarConexion();
                oTransaccionesAD = null;
            }
        }

        public bool Listado(ConfiguracionEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                InicializarVariablesGlovales(oDatos);

                Consultas = string.Format(@"Select IdConfiguracion, RutaDeRespaldo, RutaDeRespaldoDeEcxel, PathMySqlDump, PathMySql, NombreDelSistema, TiempoDeRespaldo, ImpuestoDeValorAgregado, CorreoDelRemitente, ServicioSmtp, ContrasenaDelRemitente, 
                                        PuertoDelServidor, AsuntoDelCorreo, MensageDelCorreofrom configuracion where IdConfiguracion > 0 {0} {1} ", oRegistroEN.Where, oRegistroEN.OrderBy);
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

        public bool ListadoPorIdentificador(ConfiguracionEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                InicializarVariablesGlovales(oDatos);

                Consultas = string.Format(@"Select IdConfiguracion, RutaDeRespaldo, RutaDeRespaldoDeEcxel, PathMySqlDump, PathMySql, NombreDelSistema, TiempoDeRespaldo, ImpuestoDeValorAgregado, CorreoDelRemitente, ServicioSmtp, ContrasenaDelRemitente, PuertoDelServidor, AsuntoDelCorreo, MensageDelCorreo from configuracion where IdConfiguracion = {0} ", oRegistroEN.IdConfiguracion);
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

        public bool ListadoParaCombos(ConfiguracionEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                InicializarVariablesGlovales(oDatos);

                Consultas = string.Format(@"Select IdConfiguracion, RutaDeRespaldo, RutaDeRespaldoDeEcxel, PathMySqlDump, PathMySql, NombreDelSistema, TiempoDeRespaldo, ImpuestoDeValorAgregado, CorreoDelRemitente, ServicioSmtp, ContrasenaDelRemitente, PuertoDelServidor, AsuntoDelCorreo, MensageDelCorreo from configuracion where IdConfiguracion > 0 {0} {1}; ", oRegistroEN.Where, oRegistroEN.OrderBy);
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

        public bool ListadoParaReportes(ConfiguracionEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                InicializarVariablesGlovales(oDatos);

                Consultas = string.Format(@"select IdConfiguracion, RutaDeRespaldo, RutaDeRespaldoDeEcxel, PathMySqlDump, PathMySql, NombreDelSistema, TiempoDeRespaldo, ImpuestoDeValorAgregado, CorreoDelRemitente, ServicioSmtp, ContrasenaDelRemitente, PuertoDelServidor, AsuntoDelCorreo, MensageDelCorreo from configuracion where IdConfiguracion > 0 {0} {1} ", oRegistroEN.Where, oRegistroEN.OrderBy);
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
        private string InformacionDelRegistro(ConfiguracionEN oRegistroEN)
        {
            string Cadena = @"IdConfiguracion: {0}, Configuracion: {1}";
            Cadena = string.Format(Cadena, oRegistroEN.IdConfiguracion, oRegistroEN.RutaDeRespaldo);
            Cadena = Cadena.Replace(",", Environment.NewLine);
            return Cadena;
        }
        private TransaccionesEN InformacionDeLaTransaccion(ConfiguracionEN oConfiguracionEN, string TipoDeOperacion, string Descripcion, string Estado)
        {
            TransaccionesEN oRegistroEN = new TransaccionesEN();

            oRegistroEN.IdRegistro = oConfiguracionEN.IdConfiguracion;
            oRegistroEN.Modelo = "ConfiguracionAD";
            oRegistroEN.Tabla = "Configuracion";
            oRegistroEN.TipoDeOperacion = TipoDeOperacion;
            oRegistroEN.Estado = Estado;
            oRegistroEN.IP = oConfiguracionEN.oLoginEN.NumeroIP;
            oRegistroEN.IdUsuario = oConfiguracionEN.oLoginEN.IdUsuario;
            oRegistroEN.IdUsuarioAPrueva = oConfiguracionEN.oLoginEN.IdUsuario;
            oRegistroEN.DescripcionDelUsuario = DescripcionDeLaOperacion;
            oRegistroEN.DescripcionInterna = Descripcion;
            oRegistroEN.nombredelequipo = oConfiguracionEN.oLoginEN.NombreDelEquipo;

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
    }
}
