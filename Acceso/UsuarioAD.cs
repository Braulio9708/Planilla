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
    public class UsuarioAD
    {

        public string Error { set; get; }
        private MySqlConnection Cnn = null;
        private MySqlCommand Comando = null;
        private MySqlDataAdapter Adaptador = null;
        private TransaccionesAD oTransaccionesAD = null;
        string Consultas;
        string DescripcionDeLaOperacion;

        private DataTable DT { set; get; }

        public UsuarioAD()
        {
            oTransaccionesAD = new TransaccionesAD();
            oTransaccionesAD.Modulo = "General";
            oTransaccionesAD.Modelo = "UsuarioAD";
            oTransaccionesAD.NombreDelEquipo = Environment.MachineName;
            oTransaccionesAD.FechaDeCreacion = System.DateTime.Now;
            oTransaccionesAD.Tabla = "Usuario";
        }

        #region "Funcion De Datos dll"

        public bool Agregar(UsuarioEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            oTransaccionesAD = new TransaccionesAD();
            try
            {
                InicialisarVariablesGlovales(oDatos);
                Consultas = @"insert into usuario 
				                (Nombre, Login, Contrasena, Email, Estado, IdUsuarioDeCreacion, FechaDeCreacion, IdUsuarioDeModificacion, FechaDeModificacion, IdRol) 
                                values 
                                (@Nombre, @Login, Contrasena, @Email, @Estado, @IdUsuarioDeCreacion, current_timestamp(), @IdUsuarioDeModificacion, current_timestamp(), @IdRol);
                            Select  last_insert_ID() as 'ID';";

                Comando.CommandText = Consultas;

                Comando.Parameters.Add(new MySqlParameter("@IdRol", MySqlDbType.Int32)).Value = oRegistroEN.oRolEN.IdRol;
                Comando.Parameters.Add(new MySqlParameter("@Nombre", MySqlDbType.VarChar, oRegistroEN.Nombre.Trim().Length)).Value = oRegistroEN.Nombre.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Login", MySqlDbType.VarChar, oRegistroEN.Login.Trim().Length)).Value = oRegistroEN.Login.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Contrasena", MySqlDbType.VarChar, oRegistroEN.Contrasena.Trim().Length)).Value = oRegistroEN.Contrasena.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Email", MySqlDbType.VarChar, oRegistroEN.Email.Trim().Length)).Value = oRegistroEN.Email.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Estado", MySqlDbType.VarChar, oRegistroEN.Estado.Trim().Length)).Value = oRegistroEN.Estado.Trim();
                Comando.Parameters.Add(new MySqlParameter("@IdUsuarioDeCreacion", MySqlDbType.Int32)).Value = oRegistroEN.IdUsuarioDeCreacion;
                Comando.Parameters.Add(new MySqlParameter("@IdUsuarioDeModificacion", MySqlDbType.Int32)).Value = oRegistroEN.IdUsuarioDeModificacion;

                InicialisarAdaptador();

                oRegistroEN.IdUsuario = Convert.ToInt32(DT.Rows[0].ItemArray[0].ToString());

                DescripcionDeLaOperacion = string.Format("El registro se ha insertado correctamente. {0} {1}", Environment.NewLine, InformacionDelRegistro(oRegistroEN));


                return true;
            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                DescripcionDeLaOperacion = string.Format("Se produjo el seguiente error: '{2}' al insertar el registro. {0} {1} ", Environment.NewLine, InformacionDelRegistro(oRegistroEN), ex.Message);


                return false;
            }
            finally
            {
                FinalizarConexion();
            }
        }

        public bool Actualizar(UsuarioEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            try
            {
                InicialisarVariablesGlovales(oDatos);

                Consultas = @"UPDATE usuario set
	                            Nombre = @Nombre,
                                Login = @Login,
                                Contrasena = @Contrasena,
                                Email = @Email,
                                Estado = @Estado,
                                IdUsuarioDeModificacion = @IdUsuarioDeModificacion,
                                FechaDeModificacion = @FechaDeModificacion,
                                IdRol = @IdRol
                            where IdUsuario = @IdUsuario;";

                Comando.CommandText = Consultas;

                Comando.Parameters.Add(new MySqlParameter("@IdUsuario", MySqlDbType.Int32)).Value = oRegistroEN.IdUsuario;
                Comando.Parameters.Add(new MySqlParameter("@Nombre", MySqlDbType.VarChar, oRegistroEN.Nombre.Trim().Length)).Value = oRegistroEN.Nombre.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Login", MySqlDbType.VarChar, oRegistroEN.Login.Trim().Length)).Value = oRegistroEN.Login.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Contrasena", MySqlDbType.VarChar, oRegistroEN.Contrasena.Trim().Length)).Value = oRegistroEN.Contrasena.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Email", MySqlDbType.VarChar, oRegistroEN.Email.Trim().Length)).Value = oRegistroEN.Email.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Estado", MySqlDbType.VarChar, oRegistroEN.Estado.Trim().Length)).Value = oRegistroEN.Estado.Trim();
                Comando.Parameters.Add(new MySqlParameter("@IdUsuarioDeModificacion", MySqlDbType.Int32)).Value = oRegistroEN.IdUsuarioDeModificacion;
                Comando.Parameters.Add(new MySqlParameter("@FechaDeModificacion", MySqlDbType.DateTime)).Value = oRegistroEN.FechaDeModificacion;
                Comando.Parameters.Add(new MySqlParameter("@IdRol", MySqlDbType.Int32)).Value = oRegistroEN.oRolEN.IdRol;

                Comando.ExecuteNonQuery();

                InicialisarAdaptador();

                DescripcionDeLaOperacion = string.Format("El registro fue Actualizado correctamente. {0} {1}", Environment.NewLine, InformacionDelRegistro(oRegistroEN));


                return true;
            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                DescripcionDeLaOperacion = string.Format("Se produjo el siguiente error: {2} al actualizar el registro {0} {1}", Environment.NewLine, InformacionDelRegistro(oRegistroEN), ex.Message);


                return false;
            }
            finally
            {
                FinalizarConexion();
                oTransaccionesAD = null;
            }
        }

        public bool Eliminar(UsuarioEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            oTransaccionesAD = new TransaccionesAD();

            try
            {
                InicialisarVariablesGlovales(oDatos);

                Consultas = @"Delete from Usuario where IdUsuario = @IdUsuario;";
                Comando.CommandText = Consultas;

                Comando.Parameters.Add(new MySqlParameter("@IdUsuario", MySqlDbType.Int32)).Value = oRegistroEN.IdUsuario;

                Comando.ExecuteNonQuery();

                DescripcionDeLaOperacion = string.Format("El registro fue eliminado correctamente. {0} {1}", Environment.NewLine, InformacionDelRegistro(oRegistroEN));


                return true;
            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                DescripcionDeLaOperacion = string.Format("Se produjo el siguiente error: {2} al eliminar el registro. {0} {1}", Environment.NewLine, InformacionDelRegistro(oRegistroEN), ex.Message);


                return false;
            }
            finally
            {
                FinalizarConexion();
            }
        }

        public bool Listado(UsuarioEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            try
            {
                
                InicialisarVariablesGlovales(oDatos);
                
                Consultas = string.Format(@"SELECT u.IdUsuario, u.IdRol, u.Nombre as 'Usuario', u.Login, u.Contrasena, u.Email, r.Nombre as 'TipoDeCuenta', u.Estado  FROM usuario as u
                                            inner join rol as r on r.IdRol = u.IdRol
                                            where IdUsuario > 0 {0} {1} ", oRegistroEN.Where, oRegistroEN.OrderBy);
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

        public bool ListadoPorID(UsuarioEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            try
            {
                InicialisarVariablesGlovales(oDatos);

                Consultas = string.Format(@"SELECT u.IdUsuario, u.IdRol, u.Nombre as 'Usuario', u.Login, u.Contrasena, u.Email, r.Nombre as 'TipoDeCuenta', u.Estado  FROM usuario as u
                inner join rol as r on r.IdRol = u.IdRol where IdUsuario = @IdUsuario ", oRegistroEN.IdUsuario);

                Comando.CommandText = Consultas;

                Comando.Parameters.Add(new MySqlParameter("@IdUsuario", MySqlDbType.Int32)).Value = oRegistroEN.IdUsuario;

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

        public bool ListadoParaCombos(UsuarioEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                InicialisarVariablesGlovales(oDatos);

                Consultas = string.Format(@"select IdUsuario, Nombre, Login, Contrasena, Email, Estado, IdUsuarioDeCreacion, FechaDeCreacion, IdUsuarioDeModificacion, FechaDeModificacion, IdRol from usuario where IdUsuario > 0 {0} {1}; ", oRegistroEN.Where, oRegistroEN.OrderBy);
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

        public bool ListadoParaReportes(UsuarioEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                InicialisarVariablesGlovales(oDatos);

                Consultas = string.Format(@"select IdUsuario, Nombre, Login, Contrasena, Email, Estado, IdUsuarioDeCreacion, FechaDeCreacion, IdUsuarioDeModificacion, FechaDeModificacion, IdRol from usuario where IdUsuario > 0 {0} {1} ", oRegistroEN.Where, oRegistroEN.OrderBy);
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

        #region "Funciones Para Retornar Informacion Y Llamados"
        private TransaccionesEN InformacionDelaTransaccion(UsuarioEN oUsuario, String TipoDeOperacion, String Descripcion, String Estado)
        {
            TransaccionesEN oRegistroEN = new TransaccionesEN();

            oRegistroEN.IdRegistro = oUsuario.IdUsuario;
            oRegistroEN.Modelo = "UsuarioAD";
            oRegistroEN.Modulo = "General";
            oRegistroEN.Tabla = "Usuario";
            oRegistroEN.TipoDeOperacion = TipoDeOperacion;
            oRegistroEN.Estado = Estado;
            oRegistroEN.IP = oUsuario.oLoginEN.NumeroIP;
            oRegistroEN.IdUsuario = oUsuario.oLoginEN.IdUsuario;
            oRegistroEN.IdUsuarioAPrueva = oUsuario.oLoginEN.IdUsuario;
            oRegistroEN.DescripcionDelUsuario = DescripcionDeLaOperacion;
            oRegistroEN.DescripcionInterna = Descripcion;
            oRegistroEN.nombredelequipo = oUsuario.oLoginEN.NombreDelEquipo;

            return oRegistroEN;
        }
        private string TraerCadenaDeConexion(DatosDeConexionEN oDatos)
        {                     
            ///Error en la cadena de conexion
            string cadena = string.Format("Data Source='{0}';Initial Catalog='{1}';Persist Security Info=True;User ID='{2}';Password='{3}'", oDatos.Servidor, oDatos.BaseDeDatos, oDatos.Usuario, oDatos.Contrasena);
            return cadena;            
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
        private string InformacionDelRegistro(UsuarioEN oRegistroEN)
        {
            string Cadena = @"IdUsuario: {0}, Nombre: {1}, Login: {2}, Contrasena: {3}, Email: {4}, Estado: {5}, IdUsuarioDeCreacion: {6}, FechaDeCreacion: {7}, IdUsuarioDeModificacion: {8}, FechaDeModificacion: {9}, IdRol: {10}";
            Cadena = string.Format(Cadena, oRegistroEN.IdUsuario, oRegistroEN.Nombre, oRegistroEN.Login, oRegistroEN.Contrasena, oRegistroEN.Email, oRegistroEN.Estado, oRegistroEN.IdUsuarioDeCreacion, oRegistroEN.FechaDeCreacion, oRegistroEN.IdUsuarioDeModificacion, oRegistroEN.FechaDeModificacion, oRegistroEN.oRolEN.IdRol);
            Cadena = Cadena.Replace(",", Environment.NewLine);
            return Cadena;
        }
        #endregion

        #region "Funciones de Validación"

        public bool ValidarRegistroDuplicadoPorNombre(UsuarioEN oRegistroEN, DatosDeConexionEN oDatos, string TipoDeOperacion)
        {

            try
            {

                InicialisarVariablesGlovales(oDatos);

                switch (TipoDeOperacion.Trim().ToUpper())
                {

                    case "AGREGAR":

                        Consultas = @"SELECT CASE WHEN EXISTS(SELECT IdUsuario FROM Usuario WHERE upper(trim(Nombre)) = upper(@Nombre)) THEN 1 ELSE 0 END AS 'RES'";
                        Comando.Parameters.Add(new MySqlParameter("@Nombre", MySqlDbType.VarChar, oRegistroEN.Nombre.Trim().Length)).Value = oRegistroEN.Nombre.Trim();

                        break;

                    case "ACTUALIZAR":

                        Consultas = @"SELECT CASE WHEN EXISTS(SELECT IdUsuario FROM usuario WHERE upper(trim(Nombre)) = upper(@Nombre) and IdUsuario <> @IdUsuario) THEN 1 ELSE 0 END AS 'RES'";
                        Comando.Parameters.Add(new MySqlParameter("@Nombre", MySqlDbType.VarChar, oRegistroEN.Nombre.Trim().Length)).Value = oRegistroEN.Nombre.Trim();
                        Comando.Parameters.Add(new MySqlParameter("@IdUsuario", MySqlDbType.Int32)).Value = oRegistroEN.IdUsuario;

                        break;

                    default:
                        throw new ArgumentException("La aperación solicitada no esta disponible");

                }

                Comando.CommandText = Consultas;

                InicialisarAdaptador();

                if (Convert.ToInt32(DT.Rows[0]["RES"].ToString()) > 0)
                {

                    DescripcionDeLaOperacion = string.Format("Ya existe un registro con el nombre de usuario: {0} {1}", Environment.NewLine, InformacionDelRegistro(oRegistroEN));
                    this.Error = DescripcionDeLaOperacion;
                    return true;

                }

                return false;

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                DescripcionDeLaOperacion = string.Format("Se produjo el seguiente error: '{2}' al validar el registro. {0} {1} ", Environment.NewLine, InformacionDelRegistro(oRegistroEN), ex.Message);
                oTransaccionesAD.Agregar(oRegistroEN.oLoginEN.IdUsuario, oRegistroEN.oLoginEN.NumeroIP, oRegistroEN.IdUsuario, "VALIDAR", "ERROR AL VALIDAR LA INFORMACIÓN DE LA USUARIO", "ERROR", DescripcionDeLaOperacion, oRegistroEN.oLoginEN.IdUsuario, oDatos);

                return false;
            }
            finally
            {

                FinalizarConexion();
                oTransaccionesAD = null;

            }

        }
        public bool ValidarRegistroDuplicadoPorNombreDeSecion(UsuarioEN oRegistroEN, DatosDeConexionEN oDatos, string TipoDeOperacion)
        {

            try
            {

                InicialisarVariablesGlovales(oDatos);

                switch (TipoDeOperacion.Trim().ToUpper())
                {

                    case "AGREGAR":

                        Consultas = @"SELECT CASE WHEN EXISTS(SELECT IdUsuario FROM usuario WHERE upper(trim(Login)) = upper(@Login)) THEN 1 ELSE 0 END AS 'RES'";
                        Comando.Parameters.Add(new MySqlParameter("@Login", MySqlDbType.VarChar, oRegistroEN.Login.Trim().Length)).Value = oRegistroEN.Login.Trim();

                        break;

                    case "ACTUALIZAR":

                        Consultas = @"SELECT CASE WHEN EXISTS(SELECT IdUsuario FROM usuario WHERE upper(trim(Login)) = upper(@Login) and IdUsuario <> @IdUsuario) THEN 1 ELSE 0 END AS 'RES'";
                        Comando.Parameters.Add(new MySqlParameter("@Login", MySqlDbType.VarChar, oRegistroEN.Login.Trim().Length)).Value = oRegistroEN.Login.Trim();
                        Comando.Parameters.Add(new MySqlParameter("@IdUsuario", MySqlDbType.Int32)).Value = oRegistroEN.IdUsuario;

                        break;

                    default:
                        throw new ArgumentException("La aperación solicitada no esta disponible");

                }

                Comando.CommandText = Consultas;

                InicialisarAdaptador();

                if (Convert.ToInt32(DT.Rows[0]["RES"].ToString()) > 0)
                {

                    DescripcionDeLaOperacion = string.Format("Ya existe el nombre de sesión:: {0} {1}", Environment.NewLine, InformacionDelRegistro(oRegistroEN));
                    this.Error = DescripcionDeLaOperacion;
                    return true;

                }

                return false;

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                DescripcionDeLaOperacion = string.Format("Se produjo el seguiente error: '{2}' al validar el registro. {0} {1} ", Environment.NewLine, InformacionDelRegistro(oRegistroEN), ex.Message);
                oTransaccionesAD.Agregar(oRegistroEN.oLoginEN.IdUsuario, oRegistroEN.oLoginEN.NumeroIP, oRegistroEN.IdUsuario, "VALIDAR", "ERROR AL VALIDAR LA INFORMACIÓN DE LA Usuario", "ERROR", DescripcionDeLaOperacion, oRegistroEN.oLoginEN.IdUsuario, oDatos);

                return false;
            }
            finally
            {

                FinalizarConexion();
                oTransaccionesAD = null;

            }

        }

        public bool ValidarRegistroDuplicadoPorContrasena(UsuarioEN oRegistroEN, DatosDeConexionEN oDatos, string TipoDeOperacion)
        {

            try
            {

                InicialisarVariablesGlovales(oDatos);

                switch (TipoDeOperacion.Trim().ToUpper())
                {

                    case "AGREGAR":

                        Consultas = @"SELECT CASE WHEN EXISTS(SELECT IdUsuario FROM usuario WHERE upper(trim(Contrasena)) = upper(@Contrasena)) THEN 1 ELSE 0 END AS 'RES'";
                        Comando.Parameters.Add(new MySqlParameter("@Contrasena", MySqlDbType.VarChar, oRegistroEN.Contrasena.Trim().Length)).Value = oRegistroEN.Contrasena.Trim();

                        break;

                    case "ACTUALIZAR":

                        Consultas = @"SELECT CASE WHEN EXISTS(SELECT IdUsuario FROM usuario WHERE upper(trim(Contrasena)) = upper(@Contrasena) and IdUsuario <> @IdUsuario) THEN 1 ELSE 0 END AS 'RES'";
                        Comando.Parameters.Add(new MySqlParameter("@Contrasena", MySqlDbType.VarChar, oRegistroEN.Contrasena.Trim().Length)).Value = oRegistroEN.Contrasena.Trim();
                        Comando.Parameters.Add(new MySqlParameter("@IdUsuario", MySqlDbType.Int32)).Value = oRegistroEN.IdUsuario;

                        break;

                    default:
                        throw new ArgumentException("La aperación solicitada no esta disponible");

                }

                Comando.CommandText = Consultas;

                InicialisarAdaptador();

                if (Convert.ToInt32(DT.Rows[0]["RES"].ToString()) > 0)
                {

                    DescripcionDeLaOperacion = string.Format("La contraseña que se ingreso ya fue usada: {0} {1}", Environment.NewLine, InformacionDelRegistro(oRegistroEN));
                    this.Error = DescripcionDeLaOperacion;
                    return true;

                }

                return false;

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                DescripcionDeLaOperacion = string.Format("Se produjo el seguiente error: '{2}' al validar el registro. {0} {1} ", Environment.NewLine, InformacionDelRegistro(oRegistroEN), ex.Message);
                oTransaccionesAD.Agregar(oRegistroEN.oLoginEN.IdUsuario, oRegistroEN.oLoginEN.NumeroIP, oRegistroEN.IdUsuario, "VALIDAR", "ERROR AL VALIDAR LA INFORMACIÓN DE LA Usuario", "ERROR", DescripcionDeLaOperacion, oRegistroEN.oLoginEN.IdUsuario, oDatos);

                return false;
            }
            finally
            {

                FinalizarConexion();
                oTransaccionesAD = null;

            }

        }


        #endregion

    }
}
