using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Entidad;
using System.Data;

namespace Acceso
{
    public class ModuloAD
    {

        public string Error { set; get; }
        private MySqlConnection Cnn = null;
        private MySqlCommand Comando = null;
        private MySqlDataAdapter Adaptador = null;
        private TransaccionesAD oTransaccionesAD = null;
        string Consultas;
        string DescripcionDeLaOperacion;
        private DataTable DT { set; get; }

        public ModuloAD()
        {
            oTransaccionesAD = new TransaccionesAD();
            oTransaccionesAD.Modulo = "General";
            oTransaccionesAD.Modelo = "ModuloAD";
            oTransaccionesAD.NombreDelEquipo = Environment.MachineName;
            oTransaccionesAD.FechaDeCreacion = System.DateTime.Now;
            oTransaccionesAD.Tabla = "Modulo";
        }

        #region "Funciones dll"

        public bool Agregar(ModuloEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            oTransaccionesAD = new TransaccionesAD();
            try
            {
                InicialisarVariablesGlovales(oDatos);
                Consultas = @"insert into modulo 
				                (Nombre, IdUsuarioDeCreacion, FechaDeCreacion, 
                                IdUsuarioDeModificacion, FechaDeModificacion) 
                                values 
                                (@Nombre, @IdUsuarioDeCreacion, @FechaDeCreacion, 
                                @IdUsuarioDeModificacion, @FechaDeModificacion);
                            Select  last_insert_ID() as 'ID';";

                Comando.Parameters.Add(new MySqlParameter("@Nombre", MySqlDbType.VarChar, oRegistroEN.Nombre.Trim().Length)).Value = oRegistroEN.Nombre.Trim();                
                Comando.Parameters.Add(new MySqlParameter("@IdUsuarioDeCreacion", MySqlDbType.Int32)).Value = oRegistroEN.IdUsuarioDeCreacion;
                Comando.Parameters.Add(new MySqlParameter("@FechaDeCreacion", MySqlDbType.Date)).Value = oRegistroEN.FechaDeCreacion;
                Comando.Parameters.Add(new MySqlParameter("@IdUsuarioDeModificacion", MySqlDbType.Int32)).Value = oRegistroEN.IdUsuarioDeModificacion;
                Comando.Parameters.Add(new MySqlParameter("@FechaDeModificacion", MySqlDbType.Date)).Value = oRegistroEN.FechaDeModificacion;

                InicialisarAdaptador();

                oRegistroEN.IdModulo = Convert.ToInt32(DT.Rows[0].ItemArray[0].ToString());

                DescripcionDeLaOperacion = string.Format("El registro se ha insertado correctamente. {0} {1}", Environment.NewLine, InformacionDelRegistro(oRegistroEN));

                TransaccionesEN oTransacciones = InformacionDelaTransaccion(oRegistroEN, "Agregar", "Agregar Nuevo Registro", "CORRECTO");
                oTransaccionesAD.Agregar(oTransacciones, oDatos);

                return true;
            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                DescripcionDeLaOperacion = string.Format("Se produjo el seguiente error: '{2}' al insertar el registro. {0} {1} ", Environment.NewLine, InformacionDelRegistro(oRegistroEN), ex.Message);

                TransaccionesEN oTransacciones = InformacionDelaTransaccion(oRegistroEN, "Agregar", "Agregar Nuevo Registro", "ERROR");
                oTransaccionesAD.Agregar(oTransacciones, oDatos);

                return false;
            }
            finally
            {
                FinalizarConexion();
                oTransaccionesAD = null;
            }
        }

        public bool Actualizar(ModuloEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            oTransaccionesAD = new TransaccionesAD();
            try
            {
                InicialisarVariablesGlovales(oDatos);

                Consultas = @"UPDATE modulo set
	                            Nombre = @Nombre,                   
                                IdUsuarioDeCreacion = @IdUsuarioDeCreacion,
                                FechaDeCreacion = @FechaDeCreacion,
                                IdUsuarioDeModificacion = @IdUsuarioDeModificacion,
                                FechaDeModificacion = @FechaDeModificacion                    
                            where IdModulo = @IdModulo;";

                Comando.Parameters.Add(new MySqlParameter("@IdModulo", MySqlDbType.Int32)).Value = oRegistroEN.IdModulo;
                Comando.Parameters.Add(new MySqlParameter("@Nombre", MySqlDbType.VarChar, oRegistroEN.Nombre.Trim().Length)).Value = oRegistroEN.Nombre.Trim();
                Comando.Parameters.Add(new MySqlParameter("@IdUsuarioDeCreacion", MySqlDbType.Int32)).Value = oRegistroEN.IdUsuarioDeCreacion;
                Comando.Parameters.Add(new MySqlParameter("@FechaDeCreacion", MySqlDbType.Date)).Value = oRegistroEN.FechaDeCreacion;
                Comando.Parameters.Add(new MySqlParameter("@IdUsuarioDeModificacion", MySqlDbType.Int32)).Value = oRegistroEN.IdUsuarioDeModificacion;
                Comando.Parameters.Add(new MySqlParameter("@FechaDeModificacion", MySqlDbType.Date)).Value = oRegistroEN.FechaDeModificacion;

                Comando.ExecuteNonQuery();

                DescripcionDeLaOperacion = string.Format("El registro fue Actualizado correctamente. {0} {1}", Environment.NewLine, InformacionDelRegistro(oRegistroEN));

                TransaccionesEN oTransacciones = InformacionDelaTransaccion(oRegistroEN, "Actualizar", "Actualizar Registro", "CORRECTO");
                oTransaccionesAD.Agregar(oTransacciones, oDatos);

                return true;

            }
            catch (Exception ex)
            {

                this.Error = ex.Message;

                DescripcionDeLaOperacion = string.Format("Se produjo el siguiente error: {2} al actualizar el registro {0} {1}", Environment.NewLine, InformacionDelRegistro(oRegistroEN), ex.Message);

                TransaccionesEN oTransacciones = InformacionDelaTransaccion(oRegistroEN, "Actualizar", "Actualizar Registro", "ERROR");
                oTransaccionesAD.Agregar(oTransacciones, oDatos);

                return false;

            }
            finally
            {
                FinalizarConexion();
                oTransaccionesAD = null;
            }
        }

        public bool Eliminar(ModuloEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            oTransaccionesAD = new TransaccionesAD();
            try
            {
                InicialisarVariablesGlovales(oDatos);

                Consultas = @"delete from modulo where IdModulo = @IdModulo;";

                Comando.Parameters.Add(new MySqlParameter("@IdModulo", MySqlDbType.Int32)).Value = oRegistroEN.IdModulo;

                Comando.ExecuteNonQuery();

                DescripcionDeLaOperacion = string.Format("El registro fue eliminado correctamente. {0} {1}", Environment.NewLine, InformacionDelRegistro(oRegistroEN));

                //Agregamos la transaccion...
                TransaccionesEN oTransacciones = InformacionDelaTransaccion(oRegistroEN, "Eliminar", "Elminar Registro", "CORRECTO");
                oTransaccionesAD.Agregar(oTransacciones, oDatos);

                return true;

            }
            catch (Exception ex)
            {
                DescripcionDeLaOperacion = string.Format("Se produjo el siguiente error: {2} al eliminar el registro. {0} {1}", Environment.NewLine, InformacionDelRegistro(oRegistroEN), ex.Message);

                TransaccionesEN oTransacciones = InformacionDelaTransaccion(oRegistroEN, "Eliminar", "Eliminar Registro", "ERROR");
                oTransaccionesAD.Agregar(oTransacciones, oDatos);

                return false;
            }
            finally
            {
                FinalizarConexion();
                oTransaccionesAD = null;
            }
        }

        public bool Listado(ModuloEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            try
            {
                InicialisarVariablesGlovales(oDatos);

                Consultas = string.Format(@"Select IdModulo, Nombre, IdUsuarioDeCreacion, FechaDeCreacion, IdUsuarioDeModificacion, 
                                          FechaDeModificacion from modulo where IdModulo = 0 {0} {1}", oRegistroEN.Where, oRegistroEN.OrderBy);

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

        public bool ListadoPorID(ModuloEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            try
            {
                InicialisarVariablesGlovales(oDatos);

                Consultas = string.Format(@"Select IdModulo, Nombre, IdUsuarioDeCreacion, FechaDeCreacion, IdUsuarioDeModificacion, 
                                          FechaDeModificacion from modulo where IdModulo = {0} ", oRegistroEN.IdModulo);
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

        public bool ListadoParaCombos(ModuloEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                InicialisarVariablesGlovales(oDatos);

                Consultas = string.Format(@"select IdModulo, Nombre, IdUsuarioDeCreacion, FechaDeCreacion, IdUsuarioDeModificacion, FechaDeModificacion from modulo where IdModulo > 0 {0} {1}; ", oRegistroEN.Where, oRegistroEN.OrderBy);
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

        public bool ListadoParaReportes(ModuloEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                InicialisarVariablesGlovales(oDatos);

                Consultas = string.Format(@"select IdModulo, Nombre, IdUsuarioDeCreacion, FechaDeCreacion, IdUsuarioDeModificacion, FechaDeModificacion from modulo where IdModulo > 0 {0} {1} ", oRegistroEN.Where, oRegistroEN.OrderBy);
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

        #endregion

        #region "Funciones de Validación"

        public bool ValidarRegistroDuplicado(ModuloEN oRegistroEN, DatosDeConexionEN oDatos, string TipoDeOperacion)
        {

            try
            {

                InicialisarVariablesGlovales(oDatos);

                switch (TipoDeOperacion.Trim().ToUpper())
                {

                    case "AGREGAR":

                        Consultas = @"SELECT CASE WHEN EXISTS(SELECT IdModulo FROM Modulo WHERE upper(trim(Nombre)) = upper(@Nombre)) THEN 1 ELSE 0 END AS 'RES'";
                        Comando.Parameters.Add(new MySqlParameter("@Nombre", MySqlDbType.VarChar, oRegistroEN.Nombre.Trim().Length)).Value = oRegistroEN.Nombre.Trim();

                        break;

                    case "ACTUALIZAR":

                        Consultas = @"SELECT CASE WHEN EXISTS(SELECT IdModulo FROM Modulo WHERE upper(trim(Nombre)) = upper(@Nombre) and IdModulo <> @idModulo) THEN 1 ELSE 0 END AS 'RES'";
                        Comando.Parameters.Add(new MySqlParameter("@Nombre", MySqlDbType.VarChar, oRegistroEN.Nombre.Trim().Length)).Value = oRegistroEN.Nombre.Trim();
                        Comando.Parameters.Add(new MySqlParameter("@idModulo", MySqlDbType.Int32)).Value = oRegistroEN.IdModulo;

                        break;

                    default:
                        throw new ArgumentException("La aperación solicitada no esta disponible");

                }

                Comando.CommandText = Consultas;

                InicialisarAdaptador();

                if (Convert.ToInt32(DT.Rows[0]["RES"].ToString()) > 0)
                {

                    DescripcionDeLaOperacion = string.Format("Ya existe información del Registro dentro de nuestro sistema: {0} {1}", Environment.NewLine, InformacionDelRegistro(oRegistroEN));
                    this.Error = DescripcionDeLaOperacion;
                    return true;

                }

                return false;

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                DescripcionDeLaOperacion = string.Format("Se produjo el seguiente error: '{2}' al validar el registro. {0} {1} ", Environment.NewLine, InformacionDelRegistro(oRegistroEN), ex.Message);
                oTransaccionesAD.Agregar(oRegistroEN.oLoginEN.IdUsuario, oRegistroEN.oLoginEN.NumeroIP, oRegistroEN.IdModulo, "VALIDAR", "ERROR AL VALIDAR LA INFORMACIÓN DE LA Modulo", "ERROR", DescripcionDeLaOperacion, oRegistroEN.oLoginEN.IdUsuario, oDatos);

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
        private TransaccionesEN InformacionDelaTransaccion(ModuloEN oModulo, String TipoDeOperacion, String Descripcion, String Estado)
        {
            TransaccionesEN oRegistroEN = new TransaccionesEN();

            oRegistroEN.IdRegistro = oModulo.IdModulo;
            oRegistroEN.Modelo = "ModuloAD";
            //oRegistroEN.Modulo = "Clientes";
            oRegistroEN.Tabla = "Modulo";
            oRegistroEN.TipoDeOperacion = TipoDeOperacion;
            oRegistroEN.Estado = Estado;
            oRegistroEN.IP = oModulo.oLoginEN.NumeroIP;
            oRegistroEN.IdUsuario = oModulo.oLoginEN.IdUsuario;
            oRegistroEN.IdUsuarioAPrueva = oModulo.oLoginEN.IdUsuario;
            oRegistroEN.DescripcionDelUsuario = DescripcionDeLaOperacion;
            oRegistroEN.DescripcionInterna = Descripcion;
            oRegistroEN.nombredelequipo = oModulo.oLoginEN.NombreDelEquipo;

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
        private string InformacionDelRegistro(ModuloEN oRegistroEN)
        {
            string Cadena = @"IdModulo: {0}, Nombre: {1}, FechaDeCreacion: {2}, IdUsuarioDeCreacion: {3}, FechaDeModificacion: {4}, IdUsuarioDeModificacion: {5}";
            Cadena = string.Format(Cadena, oRegistroEN.IdModulo, oRegistroEN.Nombre, oRegistroEN.FechaDeCreacion, oRegistroEN.IdUsuarioDeCreacion, oRegistroEN.FechaDeModificacion, oRegistroEN.IdUsuarioDeModificacion);
            Cadena = Cadena.Replace(",", Environment.NewLine);
            return Cadena;
        }
        #endregion

    }
}
