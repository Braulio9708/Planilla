using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using Entidad;

namespace Acceso
{
    public class MunicipoAD
    {

        public string Error { set; get; }
        private MySqlConnection Cnn = null;
        private MySqlCommand Comando = null;
        private MySqlDataAdapter Adaptador = null;
        private TransaccionesAD oTransaccionesAD = null;
        string Consultas;
        string DescripcionDeOperacion;
        private DataTable DT { set; get; }

        public MunicipoAD()
        {

            oTransaccionesAD = new TransaccionesAD();
            oTransaccionesAD.Modulo = "General";
            oTransaccionesAD.Modelo = "MunicipoAD";
            oTransaccionesAD.NombreDelEquipo = Environment.MachineName;
            oTransaccionesAD.FechaDeCreacion = System.DateTime.Now;
            oTransaccionesAD.Tabla = "Municipo";

        }

        #region "Funciones para datos dll"

        public bool Agregar(MunicipioEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                InicialisarVariablesGlovales(oDatos);

                Consultas = @"insert into municipio 
				                (Municipio) 
                                values 
                                (@Municipio);
                            Select  last_insert_ID() as 'ID';";

                Comando.CommandText = Consultas;

                Comando.Parameters.Add(new MySqlParameter("@Municipio", MySqlDbType.VarChar, oRegistroEN.Municipio.Trim().Length)).Value = oRegistroEN.Municipio.Trim();

                InicialisarAdaptador();

                oRegistroEN.IdMunicipio = Convert.ToInt32(DT.Rows[0].ItemArray[0].ToString());

                DescripcionDeOperacion = string.Format("El registro fue Insertado Correctamente. {0} {1}", Environment.NewLine, InformacionDelRegistro(oRegistroEN));

                TransaccionesEN oTransacciones = InformacionDelaTransaccion(oRegistroEN, "Agregar", "Agregar Nuevo Registro", "CORRECTO");
                oTransaccionesAD.Agregar(oTransacciones, oDatos);

                return true;

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                DescripcionDeOperacion = string.Format("Se produjo el seguiente error: '{2}' al insertar el registro. {0} {1} ", Environment.NewLine, InformacionDelRegistro(oRegistroEN), ex.Message);
                TransaccionesEN oTransacciones = InformacionDelaTransaccion(oRegistroEN, "Agregar", "Agregar Nuevo Registro", "CORRECTO");
                oTransaccionesAD.Agregar(oTransacciones, oDatos);

                return false;
            }
            finally
            {
                FinalizarConexion();
                oTransaccionesAD = null;
            }

        }

        public bool Actualizar(MunicipioEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                InicialisarVariablesGlovales(oDatos);

                Consultas = @"UPDATE municipio set
	                            Municipio = @Municipio
                            where IdMunicipio = @IdMunicipio;";

                Comando.CommandText = Consultas;

                Comando.Parameters.Add(new MySqlParameter("@IdMunicipio", MySqlDbType.Int32)).Value = oRegistroEN.IdMunicipio;
                Comando.Parameters.Add(new MySqlParameter("@Municipio", MySqlDbType.VarChar, oRegistroEN.Municipio.Trim().Length)).Value = oRegistroEN.Municipio.Trim();
                
                Comando.ExecuteNonQuery();

                DescripcionDeOperacion = string.Format("El registro fue Actualizado Correctamente. {0} {1}", Environment.NewLine, InformacionDelRegistro(oRegistroEN));

                TransaccionesEN oTransacciones = InformacionDelaTransaccion(oRegistroEN, "Agregar", "Agregar Nuevo Registro", "CORRECTO");
                oTransaccionesAD.Agregar(oTransacciones, oDatos);

                return true;

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                DescripcionDeOperacion = string.Format("Se produjo el seguiente error: '{2}' al actualizar el registro. {0} {1} ", Environment.NewLine, InformacionDelRegistro(oRegistroEN), ex.Message);
                TransaccionesEN oTransacciones = InformacionDelaTransaccion(oRegistroEN, "Agregar", "Agregar Nuevo Registro", "CORRECTO");
                oTransaccionesAD.Agregar(oTransacciones, oDatos);

                return false;
            }
            finally
            {
                FinalizarConexion();
                oTransaccionesAD = null;
            }

        }

        public bool Eliminar(MunicipioEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                InicialisarVariablesGlovales(oDatos);

                Consultas = @"DELETE FROM municipio WHERE IdMunicipio = @IdMunicipio;";
                Comando.CommandText = Consultas;

                Comando.Parameters.Add(new MySqlParameter("@IdMunicipio", MySqlDbType.Int32)).Value = oRegistroEN.IdMunicipio;

                Comando.ExecuteNonQuery();

                DescripcionDeOperacion = string.Format("El registro fue Eliminado Correctamente. {0} {1}", Environment.NewLine, InformacionDelRegistro(oRegistroEN));

                TransaccionesEN oTransacciones = InformacionDelaTransaccion(oRegistroEN, "Agregar", "Agregar Nuevo Registro", "CORRECTO");
                oTransaccionesAD.Agregar(oTransacciones, oDatos);

                return true;

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                DescripcionDeOperacion = string.Format("Se produjo el seguiente error: '{2}' al eliminar el registro. {0} {1} ", Environment.NewLine, InformacionDelRegistro(oRegistroEN), ex.Message);
                TransaccionesEN oTransacciones = InformacionDelaTransaccion(oRegistroEN, "Agregar", "Agregar Nuevo Registro", "CORRECTO");
                oTransaccionesAD.Agregar(oTransacciones, oDatos);

                return false;
            }
            finally
            {
                FinalizarConexion();
            }

        }

        public bool Listado(MunicipioEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                InicialisarVariablesGlovales(oDatos);

                Consultas = string.Format(@"Select IdMunicipio, Municipio from municipio where IdMunicipio > 0 {0} {1} ", oRegistroEN.Where, oRegistroEN.OrderBy);
                Comando.CommandText = Consultas;

                InicialisarAdaptador();

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
                
        public bool ListadoPorIdentificador(MunicipioEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                InicialisarVariablesGlovales(oDatos);

                Consultas = string.Format(@"Select IdMunicipio, Municipio from municipio where IdMunicipio > 0{0} ", oRegistroEN.IdMunicipio);
                Comando.CommandText = Consultas;

                InicialisarAdaptador();

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

        public bool ListadoParaCombos(MunicipioEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                InicialisarVariablesGlovales(oDatos);

                Consultas = string.Format(@"Select IdMunicipio, Municipio from municipio where IdMunicipio > 0 {0} {1}; ", oRegistroEN.Where, oRegistroEN.OrderBy);
                Comando.CommandText = Consultas;

                InicialisarAdaptador();

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

        public bool ListadoParaReportes(MunicipioEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                InicialisarVariablesGlovales(oDatos);

                Consultas = string.Format(@"Select IdMunicipio, Municipio from municipio where IdMunicipio > 0 {0} {1} ", oRegistroEN.Where, oRegistroEN.OrderBy);
                Comando.CommandText = Consultas;

                InicialisarAdaptador();

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

        public bool ValidarRegistroDuplicado(MunicipioEN oRegistroEN, DatosDeConexionEN oDatos, string TipoDeOperacion)
        {
            oTransaccionesAD = new TransaccionesAD();

            try
            {

                InicialisarVariablesGlovales(oDatos);

                switch (TipoDeOperacion.Trim().ToUpper())
                {

                    case "AGREGAR":

                        Consultas = @"SELECT CASE WHEN EXISTS(Select IdMunicipio from Municipio where upper(trim(Municipio)) = upper(trim(@Municipio))) THEN 1 ELSE 0 END AS 'RES'";
                        Comando.Parameters.Add(new MySqlParameter("@Municipio", MySqlDbType.VarChar, oRegistroEN.Municipio.Trim().Length)).Value = oRegistroEN.Municipio.Trim();

                        break;

                    case "ACTUALIZAR":

                        Consultas = @"SELECT CASE WHEN EXISTS(Select IdMunicipio from Municipio where upper(trim(Municipio)) = upper(trim(@Municipio)) and IdMunicipio <> @IdMunicipio) THEN 1 ELSE 0 END AS 'RES'";
                        Comando.Parameters.Add(new MySqlParameter("@Municipio", MySqlDbType.VarChar, oRegistroEN.Municipio.Trim().Length)).Value = oRegistroEN.Municipio.Trim();
                        Comando.Parameters.Add(new MySqlParameter("@IdMunicipio", MySqlDbType.Int32)).Value = oRegistroEN.IdMunicipio;

                        break;

                    default:
                        throw new ArgumentException("La aperación solicitada no esta disponible");

                }

                Comando.CommandText = Consultas;

                InicialisarAdaptador();

                if (Convert.ToInt32(DT.Rows[0]["RES"].ToString()) > 0)
                {

                    DescripcionDeOperacion = string.Format("Ya existe información del Registro dentro de nuestro sistema: {0} {1}", Environment.NewLine, InformacionDelRegistro(oRegistroEN));
                    this.Error = DescripcionDeOperacion;
                    return true;

                }

                return false;

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                DescripcionDeOperacion = string.Format("Se produjo el seguiente error: '{2}' al validar el registro. {0} {1} ", Environment.NewLine, InformacionDelRegistro(oRegistroEN), ex.Message);

                //Agregamos la Transacción....
                TransaccionesEN oTransaccion = InformacionDelaTransaccion(oRegistroEN, "VALIDAR", "REGISTRO DUPLICADO DENTRO DE LA BASE DE DATOS", "ERROR");
                oTransaccionesAD.Agregar(oTransaccion, oDatos);

                return false;
            }
            finally
            {

                FinalizarConexion();
                oTransaccionesAD = null;

            }

        }

        public bool ValidarSiElRegistroEstaVinculado(MunicipioEN oRegistroEN, DatosDeConexionEN oDatos, string TipoDeOperacion)
        {
            oTransaccionesAD = new TransaccionesAD();

            try
            {

                InicialisarVariablesGlobalesProcedure(oDatos);

                Comando.Parameters.Add(new MySqlParameter("@CampoABuscar_", MySqlDbType.VarChar, 200)).Value = "IdMunicipio";
                Comando.Parameters.Add(new MySqlParameter("@ValorCampoABuscar", MySqlDbType.Int32)).Value = oRegistroEN.IdMunicipio;
                Comando.Parameters.Add(new MySqlParameter("@ExcluirTabla_", MySqlDbType.VarChar, 200)).Value = string.Empty;

                InicialisarAdaptador();

                if (DT.Rows[0].ItemArray[0].ToString().ToUpper() == "NINGUNA".ToUpper())
                {
                    return false;
                }
                else
                {

                    this.Error = String.Format("La Operación: '{1}', {0} no se puede completar por que el registro: {0} '{2}', {0} se encuentra asociado con: {0} {3}", Environment.NewLine, TipoDeOperacion, InformacionDelRegistro(oRegistroEN));
                    DescripcionDeOperacion = this.Error;

                    //Agregamos la Transacción....
                    TransaccionesEN oTransaccion = InformacionDelaTransaccion(oRegistroEN, "VALIDAR", "VALIDAR SI EL REGISTRO ESTA VINCULADO", "CORRECTO");
                    oTransaccionesAD.Agregar(oTransaccion, oDatos);

                    return true;
                }

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                DescripcionDeOperacion = string.Format("Se produjo el seguiente error: '{2}' al validar el registro. {0} {1} ", Environment.NewLine, InformacionDelRegistro(oRegistroEN), ex.Message);

                //Agregamos la Transacción....
                TransaccionesEN oTransaccion = InformacionDelaTransaccion(oRegistroEN, "VALIDAR", "VALIDAR SI EL REGISTRO ESTA VINCULADO", "ERROR");
                oTransaccionesAD.Agregar(oTransaccion, oDatos);

                return false;
            }
            finally
            {

                FinalizarConexion();
                oTransaccionesAD = null;

            }

        }
        #endregion

        #region "Funciones Para Retornar Informacion Y Llamados"
        private TransaccionesEN InformacionDelaTransaccion(MunicipioEN oMunicipio, String TipoDeOperacion, String Descripcion, String Estado)
        {
            TransaccionesEN oRegistroEN = new TransaccionesEN();

            oRegistroEN.IdRegistro = oMunicipio.IdMunicipio;
            oRegistroEN.Modelo = "MunicipioAD";
            oRegistroEN.Modulo = "General";
            oRegistroEN.Tabla = "Municipio";
            oRegistroEN.TipoDeOperacion = TipoDeOperacion;
            oRegistroEN.Estado = Estado;
            oRegistroEN.IP = oMunicipio.oLoginEN.NumeroIP;
            oRegistroEN.IdUsuario = oMunicipio.oLoginEN.IdUsuario;
            oRegistroEN.IdUsuarioAPrueva = oMunicipio.oLoginEN.IdUsuario;
            oRegistroEN.DescripcionDelUsuario = DescripcionDeOperacion;
            oRegistroEN.DescripcionInterna = Descripcion;
            oRegistroEN.nombredelequipo = oMunicipio.oLoginEN.NombreDelEquipo;

            return oRegistroEN;
        }
        private string TraerCadenaDeConexion(DatosDeConexionEN oDatos)
        {
            string Cadena = string.Format(@"Data Source = '{0}'; Initial Catalog = '{1}'; Persist Security Info = True; User ID = '{2}'; Password = '{3}'", oDatos.Servidor, oDatos.BaseDeDatos, oDatos.Usuario, oDatos.Contrasena);
            return Cadena;
        }
        private void InicialisarVariablesGlovales(DatosDeConexionEN oDatos)
        {
            Cnn = new MySqlConnection(TraerCadenaDeConexion(oDatos));
            Cnn.Open();

            Comando = new MySqlCommand();
            Comando.Connection = Cnn;
            Comando.CommandType = CommandType.Text;
        }
        private void InicialisarVariablesGlobalesProcedure(DatosDeConexionEN oDatos)
        {

            Cnn = new MySqlConnection(TraerCadenaDeConexion(oDatos));
            Cnn.Open();

            Comando = new MySqlCommand();
            Comando.Connection = Cnn;
            Comando.CommandType = CommandType.StoredProcedure;
        }
        public void InicialisarAdaptador()
        {
            Adaptador = new MySqlDataAdapter();
            DT = new DataTable();

            Adaptador.SelectCommand = Comando;
            Adaptador.Fill(DT);
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
        public DataTable TraerDatos()
        {
            return DT;
        }
        private string InformacionDelRegistro(MunicipioEN oRegistroEN)
        {
            string Cadena = @"IdMunicipio: {0}, Municipio: {1}";
            Cadena = string.Format(Cadena, oRegistroEN.IdMunicipio, oRegistroEN.Municipio);
            Cadena = Cadena.Replace(",", Environment.NewLine);
            return Cadena;
        }
        #endregion

    }
}
