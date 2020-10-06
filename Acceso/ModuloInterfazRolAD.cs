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
    public class ModuloInterfazRolAD
    {

        public string Error { set; get; }
        private MySqlConnection Cnn = null;
        private MySqlCommand Comando = null;
        private MySqlDataAdapter Adaptador = null;
        private TransaccionesAD oTransaccionesAD = null;
        string Consultas;
        string DescripcionDeOperacion;
        private DataTable DT { set; get; }

        public ModuloInterfazRolAD()
        {

            oTransaccionesAD = new TransaccionesAD();
            oTransaccionesAD.Modulo = "General";
            oTransaccionesAD.Modelo = "ModuloInterfazRolAD";
            oTransaccionesAD.NombreDelEquipo = Environment.MachineName;
            oTransaccionesAD.FechaDeCreacion = System.DateTime.Now;
            oTransaccionesAD.Tabla = "ModuloInterfazRol";

        }

        #region "Funciones para datos dll"

        public bool Agregar(ModuloInterfazRolEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                InicialisarVariablesGlovales(oDatos);

                Consultas = @"insert into modulointerfazRol 
				                (IdPrivilegio, IdRol, Acceso, IdUsuarioDeCreacion, 
                                FechaDeCreacion, IdUsuarioDeModificacion, FechaDeModificacion) 
                                values 
                                (@IdPrivilegio, @IdRol, @Acceso, @IdUsuarioDeCreacion, current_timestamp(), 
                                @IdUsuarioDeModificacion, current_timestamp());
                            Select  last_insert_ID() as 'ID';";

                Comando.CommandText = Consultas;

                Comando.Parameters.Add(new MySqlParameter("@IdPrivilegio", MySqlDbType.Int32)).Value = oRegistroEN.oPrivilegioEN.IdPrivilegio;
                Comando.Parameters.Add(new MySqlParameter("@IdRol", MySqlDbType.Int32)).Value = oRegistroEN.oRolEN.IdRol;
                Comando.Parameters.Add(new MySqlParameter("@Acceso", MySqlDbType.Int32)).Value = oRegistroEN.Acceso;
                Comando.Parameters.Add(new MySqlParameter("@IdUsuarioDeCreacion", MySqlDbType.Int32)).Value = oRegistroEN.oLoginEN.IdUsuario;
                Comando.Parameters.Add(new MySqlParameter("@IdUsuarioDeModificacion", MySqlDbType.Int32)).Value = oRegistroEN.oLoginEN.IdUsuario;

                InicialisarAdaptador();

                oRegistroEN.IdModuloInterfazRol = Convert.ToInt32(DT.Rows[0].ItemArray[0].ToString());

                DescripcionDeOperacion = string.Format("El registro fue Insertado Correctamente. {0} {1}", Environment.NewLine, InformacionDelRegistro(oRegistroEN));

                //oTransaccionesAD.Agregar(oRegistroEN.oLoginEN.IdUsuario, oRegistroEN.oLoginEN.NumeroIP,oRegistroEN.IdModuloInterfazRol, "AGREGAR", "INFORMACIÓN DE LA MODULO INTERFAZ ROL AGREGADA CORRECTAMENTE", "CORRECTA", DescripcionDeOperacion, oRegistroEN.oLoginEN.IdUsuario, oDatos);

                return true;

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                DescripcionDeOperacion = string.Format("Se produjo el seguiente error: '{2}' al insertar el registro. {0} {1} ", Environment.NewLine, InformacionDelRegistro(oRegistroEN), ex.Message);
                //oTransaccionesAD.Agregar(oRegistroEN.oLoginEN.IdUsuario, oRegistroEN.oLoginEN.NumeroIP, oRegistroEN.IdModuloInterfazRol, "AGREGAR", "ERROR AL AGREGAR LA INFORMACIÓN DE LA ModuloInterfazRol", "ERROR", DescripcionDeOperacion, oRegistroEN.oLoginEN.IdUsuario, oDatos);

                return false;
            }
            finally
            {
                FinalizarConexion();
                oTransaccionesAD = null;
            }

        }

        public bool Actualizar(ModuloInterfazRolEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                InicialisarVariablesGlovales(oDatos);

                Consultas = @"UPDATE modulointerfazrol set
	                            IdPrivilegio = @IdPrivilegio,
                                IdRol = @IdRol,
                                Acceso = @Acceso,
                                IdUsuarioDeCreacion = @IdUsuarioDeCreacion,
                                FechaDeCreacion = @FechaDeCreacion,
                                IdUsuarioDeModificacion = @IdUsuarioDeModificacion,
                                FechaDeModificacion = @FechaDeModificacion                    
                            where IdModuloInterfazRol = @IdModuloInterfazRol;";

                Comando.CommandText = Consultas;

                Comando.Parameters.Add(new MySqlParameter("@IdModuloInterfazRol", MySqlDbType.Int32)).Value = oRegistroEN.IdModuloInterfazRol;
                Comando.Parameters.Add(new MySqlParameter("@IdPrivilegio", MySqlDbType.Int32)).Value = oRegistroEN.oPrivilegioEN.IdPrivilegio;
                Comando.Parameters.Add(new MySqlParameter("@IdRol", MySqlDbType.Int32)).Value = oRegistroEN.oRolEN.IdRol;
                Comando.Parameters.Add(new MySqlParameter("@Acceso", MySqlDbType.Int32)).Value = oRegistroEN.Acceso;
                Comando.Parameters.Add(new MySqlParameter("@IdUsuarioDeModificacion", MySqlDbType.Int32)).Value = oRegistroEN.oLoginEN.IdUsuario;

                Comando.ExecuteNonQuery();

                DescripcionDeOperacion = string.Format("El registro fue Actualizado Correctamente. {0} {1}", Environment.NewLine, InformacionDelRegistro(oRegistroEN));

                //oTransaccionesAD.Agregar(oRegistroEN.oLoginEN.IdUsuario, oRegistroEN.oLoginEN.NumeroIP, oRegistroEN.IdModuloInterfazRol, "ACTUALIZAR", "INFORMACIÓN DE LA MODULO INTERFAZ ROL ACTUALIZADA", "CORRECTA", DescripcionDeOperacion, oRegistroEN.oLoginEN.IdUsuario, oDatos);

                return true;

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                DescripcionDeOperacion = string.Format("Se produjo el seguiente error: '{2}' al actualizar el registro. {0} {1} ", Environment.NewLine, InformacionDelRegistro(oRegistroEN), ex.Message);
                //oTransaccionesAD.Agregar(oRegistroEN.oLoginEN.IdUsuario, oRegistroEN.oLoginEN.NumeroIP, oRegistroEN.IdModuloInterfazRol, "ACTUALIZAR", "ERROR AL ACTUALIZAR LA INFORMACIÓN DE LA MODULO INTERFAZ ROL", "ERROR", DescripcionDeOperacion, oRegistroEN.oLoginEN.IdUsuario, oDatos);

                return false;
            }
            finally
            {
                FinalizarConexion();
                oTransaccionesAD = null;
            }

        }

        public bool Eliminar(ModuloInterfazRolEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                InicialisarVariablesGlovales(oDatos);

                Consultas = @"DELETE FROM modulointerfazrol WHERE IdModuloInterfazRol = @IdModuloInterfazRol;";
                Comando.CommandText = Consultas;

                Comando.Parameters.Add(new MySqlParameter("@IdModuloInterfazRol", MySqlDbType.Int32)).Value = oRegistroEN.IdModuloInterfazRol;

                Comando.ExecuteNonQuery();

                DescripcionDeOperacion = string.Format("El registro fue Eliminado Correctamente. {0} {1}", Environment.NewLine, InformacionDelRegistro(oRegistroEN));

                //oTransaccionesAD.Agregar(oRegistroEN.oLoginEN.IdUsuario, oRegistroEN.oLoginEN.NumeroIP, oRegistroEN.IdModuloInterfazRol, "ELIMINAR", "INFORMACIÓN DE LA MODULO INTERFAZ ROL ELIMINADA", "CORRECTA", DescripcionDeOperacion, oRegistroEN.oLoginEN.IdUsuario, oDatos);

                return true;

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                DescripcionDeOperacion = string.Format("Se produjo el seguiente error: '{2}' al eliminar el registro. {0} {1} ", Environment.NewLine, InformacionDelRegistro(oRegistroEN), ex.Message);
                //oTransaccionesAD.Agregar(oRegistroEN.oLoginEN.IdUsuario, oRegistroEN.oLoginEN.NumeroIP, oRegistroEN.IdModuloInterfazRol, "ELIMINAR", "ERROR AL ELIMINAR LA INFORMACIÓN DE LA MODULO INTERFAZ ROL", "ERROR", DescripcionDeOperacion, oRegistroEN.oLoginEN.IdUsuario, oDatos);

                return false;
            }
            finally
            {
                FinalizarConexion();
            }

        }

        public bool Listado(ModuloInterfazRolEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                InicialisarVariablesGlovales(oDatos);

                Consultas = string.Format(@"SELECT mir.IdModuloInterfazRol, mir.IdRol,mir.IdPrivilegio, p.IdModuloInterfaz, mi.IdInterfaz, mi.IdModulo,
                i.Nombre as 'Interfaz', i.NombreAMostrar, m.Nombre as 'Modulo' , mir.Acceso
                FROM modulointerfazrol as mir
                inner join privilegio as p on p.IdPrivilegio = mir.IdPrivilegio
                inner join modulointerfaz as mi on mi.IdModuloInterfaz = p.IdModuloInterfaz
                inner join interfaz as i on i.IdInterfaz = mi.IdInterfaz
                inner join modulo as m on m.IdModulo = mi.IdModulo
                where mir.IdModuloInterfazRol > 0 {0} {1} ", oRegistroEN.Where, oRegistroEN.OrderBy);
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

        public bool ListadoDePrivilegiosParaELUsuario(ModuloInterfazRolEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                InicialisarVariablesGlovales(oDatos);

                Consultas = string.Format(@"SELECT IdModuloInterfazRol,p.IdPrivilegio, 
                mir.Acceso, p.Nombre as 'Privilegio', i.NombreAMostrar,i.Nombre as 'Interfaz', m.Nombre as 'Modulo' 
                FROM modulointerfazrol as mir
                inner join privilegio as p on p.IdPrivilegio = mir.IdPrivilegio
                inner join modulointerfaz as mi on mi.IdModuloInterfaz = p.IdModuloInterfaz
                inner join interfaz as i on i.IdInterfaz = mi.IdInterfaz
                inner join modulo as m on m.IdModulo = mi.IdModulo
                where mir.IdModuloInterfazRol > 0 and mir.IdRol = 1
                UNION ALL
                Select 0 as 'IdModuloInterfazUsuario', p.IdPrivilegio, 0 as 'Acceso', 
                p.Nombre as 'Privilegio', i.NombreAMostrar,i.Nombre as 'Interfaz', m.Nombre as 'Modulo' 
                 from privilegio as p
                inner join modulointerfaz as mi on mi.IdModuloInterfaz = p.IdModuloInterfaz
                inner join interfaz as i on i.IdInterfaz = mi.IdInterfaz
                inner join modulo as m on m.IdModulo = mi.IdModulo
                where p.IdPrivilegio not in (Select IdPrivilegio from modulointerfazrol where IdRol = 0);", oRegistroEN.oRolEN.IdRol);
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

        public bool ListadoDePrivilegioDelRol(ModuloInterfazRolEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                InicialisarVariablesGlovales(oDatos);

                Consultas = string.Format(@"SELECT mir.IdModuloInterfazRol,p.IdPrivilegio, 
                mir.Acceso, p.Nombre as 'Privilegio', i.NombreAMostrar,i.Nombre as 'Interfaz', m.Nombre as 'Modulo' 
                FROM modulointerfazrol as mir
                inner join privilegio as p on p.IdPrivilegio = mir.IdPrivilegio
                inner join modulointerfaz as mi on mi.IdModuloInterfaz = p.IdModuloInterfaz
                inner join interfaz as i on i.IdInterfaz = mi.IdInterfaz
                inner join modulo as m on m.IdModulo = mi.IdModulo
                where mir.IdModuloInterfazRol > 0 and mir.IdRol = {0} {1}
                UNION ALL
                Select 0 as 'IdModuloInterfazRol', p.IdPrivilegio, 0 as 'Acceso', 
                p.Nombre as 'Privilegio', i.NombreAMostrar,i.Nombre as 'Interfaz', m.Nombre as 'Modulo' 
                 from privilegio as p
                inner join modulointerfaz as mi on mi.IdModuloInterfaz = p.IdModuloInterfaz
                inner join interfaz as i on i.IdInterfaz = mi.IdInterfaz
                inner join modulo as m on m.IdModulo = mi.IdModulo
                where p.IdPrivilegio not in (Select IdPrivilegio from modulointerfazrol where IdRol = {0}) {1} {2}", oRegistroEN.oRolEN.IdRol, oRegistroEN.Where, oRegistroEN.OrderBy);
                System.Diagnostics.Debug.Print(Consultas);
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

        public bool ListadoPorIdentificador(ModuloInterfazRolEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                InicialisarVariablesGlovales(oDatos);

                Consultas = string.Format(@"SELECT mir.IdModuloInterfazRol, mir.IdRol,mir.IdPrivilegio, p.IdModuloInterfaz, mi.IdInterfaz, mi.IdModulo,
                i.Nombre as 'Interfaz', i.NombreAMostrar, m.Nombre as 'Modulo' , mir.Acceso
                FROM modulointerfazrol as mir
                inner join privilegio as p on p.IdPrivilegio = mir.IdPrivilegio
                inner join modulointerfaz as mi on mi.IdModuloInterfaz = p.IdModuloInterfaz
                inner join interfaz as i on i.IdInterfaz = mi.IdInterfaz
                inner join modulo as m on m.IdModulo = mi.IdModulo
                where mir.IdModuloInterfazRol > {0} ", oRegistroEN.IdModuloInterfazRol);
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

        public bool ListadoParaCombos(ModuloInterfazRolEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                InicialisarVariablesGlovales(oDatos);

                Consultas = string.Format(@"SELECT mir.IdModuloInterfazRol, mir.IdRol,mir.IdPrivilegio, p.IdModuloInterfaz, mi.IdInterfaz, mi.IdModulo,
                i.Nombre as 'Interfaz', i.NombreAMostrar, m.Nombre as 'Modulo' , mir.Acceso
                FROM modulointerfazrol as mir
                inner join privilegio as p on p.IdPrivilegio = mir.IdPrivilegio
                inner join modulointerfaz as mi on mi.IdModuloInterfaz = p.IdModuloInterfaz
                inner join interfaz as i on i.IdInterfaz = mi.IdInterfaz
                inner join modulo as m on m.IdModulo = mi.IdModulo
                where mir.IdModuloInterfazRol > 0 {0} {1}; ", oRegistroEN.Where, oRegistroEN.OrderBy);
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

        public bool ListadoParaReportes(ModuloInterfazRolEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                InicialisarVariablesGlovales(oDatos);

                Consultas = string.Format(@"SELECT mir.IdModuloInterfazRol, mir.IdRol,mir.IdPrivilegio, p.IdModuloInterfaz, mi.IdInterfaz, mi.IdModulo,
                i.Nombre as 'Interfaz', i.NombreAMostrar, m.Nombre as 'Modulo' , mir.Acceso
                FROM modulointerfazrol as mir
                inner join privilegio as p on p.IdPrivilegio = mir.IdPrivilegio
                inner join modulointerfaz as mi on mi.IdModuloInterfaz = p.IdModuloInterfaz
                inner join interfaz as i on i.IdInterfaz = mi.IdInterfaz
                inner join modulo as m on m.IdModulo = mi.IdModulo
                where mir.IdModuloInterfazRol > 0 {0} {1} ", oRegistroEN.Where, oRegistroEN.OrderBy);
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

        public bool ListadoPorIdentificadorDelRol(ModuloInterfazRolEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                InicialisarVariablesGlovales(oDatos);

                Consultas = string.Format(@"SELECT mir.IdModuloInterfazRol, mir.IdRol,mir.IdPrivilegio, p.IdModuloInterfaz, mi.IdInterfaz, mi.IdModulo,
                i.Nombre as 'Interfaz', i.NombreAMostrar, m.Nombre as 'Modulo' , mir.Acceso
                FROM modulointerfazrol as mir
                inner join privilegio as p on p.IdPrivilegio = mir.IdPrivilegio
                inner join modulointerfaz as mi on mi.IdModuloInterfaz = p.IdModuloInterfaz
                inner join interfaz as i on i.IdInterfaz = mi.IdInterfaz
                inner join modulo as m on m.IdModulo = mi.IdModulo
                where mir.IdRol > {0} ", oRegistroEN.oRolEN.IdRol);
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

        public bool ValidarRegistroDuplicado(ModuloInterfazRolEN oRegistroEN, DatosDeConexionEN oDatos, string TipoDeOperacion)
        {

            try
            {

                InicialisarVariablesGlovales(oDatos);

                switch (TipoDeOperacion.Trim().ToUpper())
                {

                    case "AGREGAR":

                        Consultas = @"SELECT CASE WHEN EXISTS(Select IdModuloInterfazRol from modulointerfazrol where IdPrivilegio = @IdPrivilegio and IdRol = @IdRol) THEN 1 ELSE 0 END AS 'RES'";
                        Comando.Parameters.Add(new MySqlParameter("@IdPrivilegio", MySqlDbType.Int32)).Value = oRegistroEN.oPrivilegioEN.IdPrivilegio;
                        Comando.Parameters.Add(new MySqlParameter("@IdRol", MySqlDbType.Int32)).Value = oRegistroEN.oRolEN.IdRol;

                        break;

                    case "ACTUALIZAR":

                        Consultas = @"SELECT CASE WHEN EXISTS(Select IdModuloInterfazRol from modulointerfazrol where IdPrivilegio = @IdPrivilegio and IdRol = @IdRol and IdModuloInterfazRol <> @IdModuloInterfazRol) THEN 1 ELSE 0 END AS 'RES'";
                        Comando.Parameters.Add(new MySqlParameter("@IdPrivilegio", MySqlDbType.Int32)).Value = oRegistroEN.oPrivilegioEN.IdPrivilegio;
                        Comando.Parameters.Add(new MySqlParameter("@IdRol", MySqlDbType.Int32)).Value = oRegistroEN.oRolEN.IdRol;
                        Comando.Parameters.Add(new MySqlParameter("@IdModuloInterfazRol", MySqlDbType.Int32)).Value = oRegistroEN.IdModuloInterfazRol;

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
                oTransaccionesAD.Agregar(oRegistroEN.oLoginEN.IdUsuario, oRegistroEN.oLoginEN.NumeroIP, oRegistroEN.IdModuloInterfazRol, "VALIDAR", "ERROR AL VALIDAR LA INFORMACIÓN DE LA MODULO INTERFAZ ROL", "ERROR", DescripcionDeOperacion, oRegistroEN.oLoginEN.IdUsuario, oDatos);

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
        private TransaccionesEN InformacionDelaTransaccion(ModuloInterfazRolEN oModuloInterfazRol, String TipoDeOperacion, String Descripcion, String Estado)
        {
            TransaccionesEN oRegistroEN = new TransaccionesEN();

            oRegistroEN.IdRegistro = oModuloInterfazRol.IdModuloInterfazRol;
            oRegistroEN.Modelo = "ModuloInterfazRolAD";
            //oRegistroEN.Modulo = "Clientes";
            oRegistroEN.Tabla = "ModuloInterfazRol";
            oRegistroEN.TipoDeOperacion = TipoDeOperacion;
            oRegistroEN.Estado = Estado;
            oRegistroEN.IP = oModuloInterfazRol.oLoginEN.NumeroIP;
            oRegistroEN.IdUsuario = oModuloInterfazRol.oLoginEN.IdUsuario;
            oRegistroEN.IdUsuarioAPrueva = oModuloInterfazRol.oLoginEN.IdUsuario;
            oRegistroEN.DescripcionDelUsuario = DescripcionDeOperacion;
            oRegistroEN.DescripcionInterna = Descripcion;
            oRegistroEN.nombredelequipo = oModuloInterfazRol.oLoginEN.NombreDelEquipo;

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
        private string InformacionDelRegistro(ModuloInterfazRolEN oRegistroEN)
        {
            string Cadena = @"IdModuloInterfazRol: {0}, IdPrivilegio: {1}, IdRol: {2}, Acceso: {3}, FechaDeCreacion: {4}, IdUsuarioDeCreacion: {5}, FechaDeModificacion: {6}, IdUsuarioDeModificacion: {7}";
            Cadena = string.Format(Cadena, oRegistroEN.IdModuloInterfazRol, oRegistroEN.oPrivilegioEN.IdPrivilegio, oRegistroEN.oRolEN.IdRol, oRegistroEN.Acceso, oRegistroEN.FechaDeCreacion, oRegistroEN.IdUsuarioDeCreacion, oRegistroEN.FechaDeModificacion, oRegistroEN.IdUsuarioDeModificacion);
            Cadena = Cadena.Replace(",", Environment.NewLine);
            return Cadena;
        }
        #endregion
    }
}
