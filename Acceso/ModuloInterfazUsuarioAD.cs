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
    public class ModuloInterfazUsuarioAD
    {
        public string Error { set; get; }
        private MySqlConnection Cnn = null;
        private MySqlCommand Comando = null;
        private MySqlDataAdapter Adaptador = null;
        private TransaccionesAD oTransaccionesAD = null;
        string Consultas;
        string DescripcionDeOperacion;
        private DataTable DT { set; get; }

        public ModuloInterfazUsuarioAD()
        {

            oTransaccionesAD = new TransaccionesAD();
            oTransaccionesAD.Modulo = "General";
            oTransaccionesAD.Modelo = "ModuloInterfazUsuariosAD";
            oTransaccionesAD.NombreDelEquipo = Environment.MachineName;
            oTransaccionesAD.FechaDeCreacion = System.DateTime.Now;
            oTransaccionesAD.Tabla = "ModuloInterfazUsuario";

        }

        #region "Funciones para datos dll"        

        public bool Agregar(ModuloInterfazUsuarioEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                IniciarVariablesGlovales(oDatos);

                Consultas = @"insert into modulointerfazusuario 
				                (IdPrivilegio, IdUsuario, Acceso, IdUsuarioDeCreacion, 
                                FechaDeCreacion, IdUsuarioDeModificacion, FechaDeModificacion) 
                                values 
                                (@IdPrivilegio, @IdUsuario, @Acceso, @IdUsuarioDeCreacion, current_timestamp(), 
                                @IdUsuarioDeModificacion, current_timestamp());
                            Select  last_insert_ID() as 'ID';";

                Comando.CommandText = Consultas;

                Comando.Parameters.Add(new MySqlParameter("@IdPrivilegio", MySqlDbType.Int32)).Value = oRegistroEN.oPrivilegioEN.IdPrivilegio;
                Comando.Parameters.Add(new MySqlParameter("@IdUsuario", MySqlDbType.Int32)).Value = oRegistroEN.oUsuarioEN.IdUsuario;
                Comando.Parameters.Add(new MySqlParameter("@Acceso", MySqlDbType.Int32)).Value = oRegistroEN.Acceso;
                Comando.Parameters.Add(new MySqlParameter("@IdUsuarioDeCreacion", MySqlDbType.Int32)).Value = oRegistroEN.oLoginEN.IdUsuario;
                Comando.Parameters.Add(new MySqlParameter("@IdUsuarioDeModificacion", MySqlDbType.Int32)).Value = oRegistroEN.oLoginEN.IdUsuario;

                Adaptador = new MySqlDataAdapter();
                DT = new DataTable();

                Adaptador.SelectCommand = Comando;
                Adaptador.Fill(DT);

                oRegistroEN.IdModuloInterfazUsuario = Convert.ToInt32(DT.Rows[0].ItemArray[0].ToString());

                DescripcionDeOperacion = string.Format("El registro fue Insertado Correctamente. {0} {1}", Environment.NewLine, InformacionDelRegistro(oRegistroEN));

                oTransaccionesAD.Agregar(oRegistroEN.oLoginEN.IdUsuario, oRegistroEN.oLoginEN.NumeroIP, oRegistroEN.IdModuloInterfazUsuario, "AGREGAR", "INFORMACIÓN DE LA MODULO INTERFAZ USUARIO AGREGADA CORRECTAMENTE", "CORRECTA", DescripcionDeOperacion, oRegistroEN.oLoginEN.IdUsuario, oDatos);

                return true;

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                DescripcionDeOperacion = string.Format("Se produjo el seguiente error: '{2}' al insertar el registro. {0} {1} ", Environment.NewLine, InformacionDelRegistro(oRegistroEN), ex.Message);
                oTransaccionesAD.Agregar(oRegistroEN.oLoginEN.IdUsuario, oRegistroEN.oLoginEN.NumeroIP, oRegistroEN.IdModuloInterfazUsuario, "AGREGAR", "ERROR AL AGREGAR LA INFORMACIÓN DE LA ModuloInterfazUsuarios", "ERROR", DescripcionDeOperacion, oRegistroEN.oLoginEN.IdUsuario, oDatos);

                return false;
            }
            finally
            {

                FinalizarLaConexion();

            }

        }

        public bool Actualizar(ModuloInterfazUsuarioEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                IniciarVariablesGlovales(oDatos);

                Consultas = @"UPDATE modulo set
	                            IdPrivilegio = @IdPrivilegio,
                                IdUsuario = @IdUsuario,
                                Acceso = @Acceso,
                                IdUsuarioDeCreacion = @IdUsuarioDeCreacion,
                                FechaDeCreacion = @FechaDeCreacion,
                                IdUsuarioDeModificacion = @IdUsuarioDeModificacion,
                                FechaDeModificacion = @FechaDeModificacion                    
                            where IdModuloInterfazUsuario = @IdModuloInterfazUsuario;";

                Comando.CommandText = Consultas;

                Comando.Parameters.Add(new MySqlParameter("@IdModuloInterfazUsuario", MySqlDbType.Int32)).Value = oRegistroEN.IdModuloInterfazUsuario;
                Comando.Parameters.Add(new MySqlParameter("@IdPrivilegio", MySqlDbType.Int32)).Value = oRegistroEN.oPrivilegioEN.IdPrivilegio;
                Comando.Parameters.Add(new MySqlParameter("@IdUsuario", MySqlDbType.Int32)).Value = oRegistroEN.oUsuarioEN.IdUsuario;
                Comando.Parameters.Add(new MySqlParameter("@Acceso", MySqlDbType.Int32)).Value = oRegistroEN.Acceso;
                Comando.Parameters.Add(new MySqlParameter("@IdUsuarioDeModificacion", MySqlDbType.Int32)).Value = oRegistroEN.oLoginEN.IdUsuario;

                Comando.ExecuteNonQuery();

                DescripcionDeOperacion = string.Format("El registro fue Actualizado Correctamente. {0} {1}", Environment.NewLine, InformacionDelRegistro(oRegistroEN));

                oTransaccionesAD.Agregar(oRegistroEN.oLoginEN.IdUsuario, oRegistroEN.oLoginEN.NumeroIP, oRegistroEN.IdModuloInterfazUsuario, "ACTUALIZAR", "INFORMACIÓN DE LA MODULO INTERFAZ USUARIO ACTUALIZADA", "CORRECTA", DescripcionDeOperacion, oRegistroEN.oLoginEN.IdUsuario, oDatos);

                return true;

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                DescripcionDeOperacion = string.Format("Se produjo el seguiente error: '{2}' al actualizar el registro. {0} {1} ", Environment.NewLine, InformacionDelRegistro(oRegistroEN), ex.Message);
                oTransaccionesAD.Agregar(oRegistroEN.oLoginEN.IdUsuario, oRegistroEN.oLoginEN.NumeroIP, oRegistroEN.IdModuloInterfazUsuario, "ACTUALIZAR", "ERROR AL ACTUALIZAR LA INFORMACIÓN DE LA MODULO INTERFAZ USUARIO", "ERROR", DescripcionDeOperacion, oRegistroEN.oLoginEN.IdUsuario, oDatos);

                return false;
            }
            finally
            {

                FinalizarLaConexion();

            }

        }

        public bool Eliminar(ModuloInterfazUsuarioEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                IniciarVariablesGlovales(oDatos);

                Consultas = @"delete from modulointerfazusuario where IdModuloInterfazUsuario = @IdModuloInterfazUsuario;";
                Comando.CommandText = Consultas;

                Comando.Parameters.Add(new MySqlParameter("@IdModuloInterfazUsuario", MySqlDbType.Int32)).Value = oRegistroEN.IdModuloInterfazUsuario;

                Comando.ExecuteNonQuery();

                DescripcionDeOperacion = string.Format("El registro fue Eliminado Correctamente. {0} {1}", Environment.NewLine, InformacionDelRegistro(oRegistroEN));

                //oTransaccionesAD.Agregar(oRegistroEN.oLoginEN.IdUsuario, oRegistroEN.oLoginEN.NumeroIP, oRegistroEN.IdModuloInterfazUsuario, "ELIMINAR", "INFORMACIÓN DE LA MODULO INTERFAZ USUARIO ELIMINADA", "CORRECTA", DescripcionDeOperacion, oRegistroEN.oLoginEN.IdUsuario, oDatos);

                return true;

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                DescripcionDeOperacion = string.Format("Se produjo el seguiente error: '{2}' al eliminar el registro. {0} {1} ", Environment.NewLine, InformacionDelRegistro(oRegistroEN), ex.Message);
                //oTransaccionesAD.Agregar(oRegistroEN.oLoginEN.IdUsuario, oRegistroEN.oLoginEN.NumeroIP, oRegistroEN.IdModuloInterfazUsuario, "ELIMINAR", "ERROR AL ELIMINAR LA INFORMACIÓN DE LA MODULO INTERFAZ USUARIO", "ERROR", DescripcionDeOperacion, oRegistroEN.oLoginEN.IdUsuario, oDatos);

                return false;
            }
            finally
            {

                FinalizarLaConexion();

            }

        }

        public bool Listado(ModuloInterfazUsuarioEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                IniciarVariablesGlovales(oDatos);

                Consultas = string.Format(@"SELECT miu.IdModuloInterfazUsuario,p.IdPrivilegio, p.idModuloInterfaz, mi.idInterfaz, mi.idModulo,
                miu.Acceso, p.Nombre as 'Privilegio', i.NombreAMostrar,i.Nombre as 'Interfaz', m.Nombre as 'Modulo' 
                FROM modulointerfazusuario as miu
                inner join privilegio as p on p.IdPrivilegio = miu.IdPrivilegio
                inner join modulointerfaz as mi on mi.idModuloInterfaz = p.idModuloInterfaz
                inner join interfaz as i on i.idInterfaz = mi.idInterfaz
                inner join modulo as m on m.idModulo = mi.idModulo
                where miu.IdModuloInterfazUsuario > 0 {0} {1} ", oRegistroEN.Where, oRegistroEN.OrderBy);
                Comando.CommandText = Consultas;

                Adaptador = new MySqlDataAdapter();
                DT = new DataTable();

                Adaptador.SelectCommand = Comando;
                Adaptador.Fill(DT);

                return true;

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                return false;
            }
            finally
            {

                FinalizarLaConexion();

            }

        }

        public bool ListadoPrivilegiosDelUsuario(ModuloInterfazUsuarioEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                IniciarVariablesGlovales(oDatos);

                Consultas = string.Format(@"SELECT miu.IdModuloInterfazUsuario,p.IdPrivilegio, 
                miu.Acceso, p.Nombre as 'Privilegio', i.NombreAMostrar,i.Nombre as 'Interfaz', m.Nombre as 'Modulo' 
                FROM modulointerfazusuario as miu
                inner join privilegio as p on p.IdPrivilegio = miu.IdPrivilegio
                inner join modulointerfaz as mi on mi.IdModuloInterfaz = p.IdModuloInterfaz
                inner join interfaz as i on i.IdInterfaz = mi.IdInterfaz
                inner join modulo as m on m.IdModulo = mi.IdModulo
                where miu.IdModuloInterfazUsuario > 0 and miu.IdUsuario = {0} {1}
                union all
                Select 0 as 'IdModuloInterfazUsuario', p.IdPrivilegio, 0 as 'Acceso', 
                p.Nombre as 'Privilegio', i.NombreAMostrar,i.Nombre as 'Interfaz', m.Nombre as 'Modulo' 
                 from privilegio as p
                inner join modulointerfaz as mi on mi.IdModuloInterfaz = p.IdModuloInterfaz
                inner join interfaz as i on i.IdInterfaz = mi.IdInterfaz
                inner join modulo as m on m.IdModulo = mi.IdModulo
                where p.IdPrivilegio not in (Select IdPrivilegio from modulointerfazusuario where IdUsuario = {0}) {1} {2} ", oRegistroEN.oUsuarioEN.IdUsuario, oRegistroEN.Where, oRegistroEN.OrderBy);
                Comando.CommandText = Consultas;

                Adaptador = new MySqlDataAdapter();
                DT = new DataTable();

                Adaptador.SelectCommand = Comando;
                Adaptador.Fill(DT);

                return true;

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                return false;
            }
            finally
            {

                FinalizarLaConexion();

            }

        }

        public bool ListadoPrivilegiosDelUsuariosPorIntefaz(ModuloInterfazUsuarioEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            
            try
            {
                
                IniciarVariablesGlovales(oDatos);
                
                Consultas = string.Format(@"SELECT miu.IdModuloInterfazUsuario,p.IdPrivilegio, p.idModuloInterfaz, mi.idInterfaz, mi.idModulo,
                                            miu.Acceso, p.Nombre as 'Privilegio', i.NombreAMostrar,i.Nombre as 'Interfaz', m.Nombre as 'Modulo' 
                                            FROM modulointerfazusuario as miu
                                            inner join privilegio as p on p.IdPrivilegio = miu.IdPrivilegio
                                            inner join modulointerfaz as mi on mi.idModuloInterfaz = p.idModuloInterfaz
                                            inner join interfaz as i on i.idInterfaz = mi.idInterfaz
                                            inner join modulo as m on m.idModulo = mi.idModulo
                                            where miu.IdModuloInterfazUsuario > 0 and miu.IdUsuario = {0} and upper(trim( i.Nombre)) = upper('{1}') ", oRegistroEN.oUsuarioEN.IdUsuario, oRegistroEN.oPrivilegioEN.oModuloInterfazEN.oInterfazEN.Nombre.Trim());

                Comando.CommandText = Consultas;

                Adaptador = new MySqlDataAdapter();
                DT = new DataTable();
                DT.Clear();

                Adaptador.SelectCommand = Comando;
                Adaptador.Fill(DT);

                return true;

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                return false;
            }
            finally
            {

                FinalizarLaConexion();

            }

        }

        public bool ListadoPrivilegiosDelUsuariosPorModulo(ModuloInterfazUsuarioEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                IniciarVariablesGlovales(oDatos);

                Consultas = string.Format(@"SELECT miu.IdModuloInterfazUsuario,p.IdPrivilegio, p.idModuloInterfaz, mi.idInterfaz, mi.idModulo,
                miu.Acceso, p.Nombre as 'Privilegio', i.NombreAMostrar,i.Nombre as 'Interfaz', m.Nombre as 'Modulo' 
                FROM modulointerfazusuario as miu
                inner join privilegio as p on p.IdPrivilegio = miu.IdPrivilegio
                inner join modulointerfaz as mi on mi.idModuloInterfaz = p.idModuloInterfaz
                inner join interfaz as i on i.idInterfaz = mi.idInterfaz
                inner join modulo as m on m.idModulo = mi.idModulo
                where miu.IdModuloInterfazUsuario > 0 and miu.IdUsuario = {0} and p.Nombre = 'Acceso' ; ", oRegistroEN.oUsuarioEN.IdUsuario);

                Comando.CommandText = Consultas;

                Adaptador = new MySqlDataAdapter();
                DT = new DataTable();

                Adaptador.SelectCommand = Comando;
                Adaptador.Fill(DT);

                return true;

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                return false;
            }
            finally
            {

                FinalizarLaConexion();

            }

        }

        public bool ListadoPorIdentificador(ModuloInterfazUsuarioEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                IniciarVariablesGlovales(oDatos);

                Consultas = string.Format(@"SELECT miu.IdModuloInterfazUsuario,p.IdPrivilegio, p.idModuloInterfaz, mi.idInterfaz, mi.idModulo,
                miu.Acceso, p.Nombre as 'Privilegio', i.NombreAMostrar,i.Nombre as 'Interfaz', m.Nombre as 'Modulo' 
                FROM modulointerfazusuario as miu
                inner join privilegio as p on p.IdPrivilegio = miu.IdPrivilegio
                inner join modulointerfaz as mi on mi.idModuloInterfaz = p.idModuloInterfaz
                inner join interfaz as i on i.idInterfaz = mi.idInterfaz
                inner join modulo as m on m.idModulo = mi.idModulo
                where miu.IdModuloInterfazUsuario = {0} ", oRegistroEN.IdModuloInterfazUsuario);
                Comando.CommandText = Consultas;

                Adaptador = new MySqlDataAdapter();
                DT = new DataTable();

                Adaptador.SelectCommand = Comando;
                Adaptador.Fill(DT);

                return true;

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                return false;
            }
            finally
            {

                FinalizarLaConexion();

            }

        }

        public bool ListadoParaCombos(ModuloInterfazUsuarioEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                IniciarVariablesGlovales(oDatos);

                Consultas = string.Format(@"SELECT miu.IdModuloInterfazUsuario,p.IdPrivilegio, p.idModuloInterfaz, mi.idInterfaz, mi.idModulo,
                miu.Acceso, p.Nombre as 'Privilegio', i.NombreAMostrar,i.Nombre as 'Interfaz', m.Nombre as 'Modulo' 
                FROM modulointerfazusuario as miu
                inner join privilegio as p on p.IdPrivilegio = miu.IdPrivilegio
                inner join modulointerfaz as mi on mi.idModuloInterfaz = p.idModuloInterfaz
                inner join interfaz as i on i.idInterfaz = mi.idInterfaz
                inner join modulo as m on m.idModulo = mi.idModulo
                where miu.IdModuloInterfazUsuario > 0 {0} {1}; ", oRegistroEN.Where, oRegistroEN.OrderBy);
                Comando.CommandText = Consultas;

                Adaptador = new MySqlDataAdapter();
                DT = new DataTable();

                Adaptador.SelectCommand = Comando;
                Adaptador.Fill(DT);

                return true;

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                return false;
            }
            finally
            {

                FinalizarLaConexion();

            }

        }

        public bool ListadoParaReportes(ModuloInterfazUsuarioEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                IniciarVariablesGlovales(oDatos);

                Consultas = string.Format(@"SELECT miu.IdModuloInterfazUsuario,p.IdPrivilegio, p.idModuloInterfaz, mi.idInterfaz, mi.idModulo,
                miu.Acceso, p.Nombre as 'Privilegio', i.NombreAMostrar,i.Nombre as 'Interfaz', m.Nombre as 'Modulo' 
                FROM modulointerfazusuario as miu
                inner join privilegio as p on p.IdPrivilegio = miu.IdPrivilegio
                inner join modulointerfaz as mi on mi.idModuloInterfaz = p.idModuloInterfaz
                inner join interfaz as i on i.idInterfaz = mi.idInterfaz
                inner join modulo as m on m.idModulo = mi.idModulo
                where miu.IdModuloInterfazUsuario > 0 {0} {1} ", oRegistroEN.Where, oRegistroEN.OrderBy);
                Comando.CommandText = Consultas;

                Adaptador = new MySqlDataAdapter();
                DT = new DataTable();

                Adaptador.SelectCommand = Comando;
                Adaptador.Fill(DT);

                return true;

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                return false;
            }
            finally
            {

                FinalizarLaConexion();

            }

        }

        public bool ListadoPorIdentificadorDelUsuario(ModuloInterfazUsuarioEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                IniciarVariablesGlovales(oDatos);

                Consultas = string.Format(@"SELECT miu.IdModuloInterfazUsuario,p.IdPrivilegio, p.idModuloInterfaz, mi.idInterfaz, mi.idModulo,
                miu.Acceso, p.Nombre as 'Privilegio', i.NombreAMostrar,i.Nombre as 'Interfaz', m.Nombre as 'Modulo' 
                FROM modulointerfazusuario as miu
                inner join privilegio as p on p.IdPrivilegio = miu.IdPrivilegio
                inner join modulointerfaz as mi on mi.idModuloInterfaz = p.idModuloInterfaz
                inner join interfaz as i on i.idInterfaz = mi.idInterfaz
                inner join modulo as m on m.idModulo = mi.idModulo
                where miu.IdModuloInterfazUsuario > 0 {0} {1} ", oRegistroEN.Where, oRegistroEN.OrderBy);
                Comando.CommandText = Consultas;

                Adaptador = new MySqlDataAdapter();
                DT = new DataTable();

                Adaptador.SelectCommand = Comando;
                Adaptador.Fill(DT);

                return true;

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                return false;
            }
            finally
            {

                FinalizarLaConexion();

            }

        }

        #endregion

        #region "Funciones de Validación"

        public bool ValidarRegistroDuplicado(ModuloInterfazUsuarioEN oRegistroEN, DatosDeConexionEN oDatos, string TipoDeOperacion)
        {

            try
            {

                IniciarVariablesGlovales(oDatos);

                switch (TipoDeOperacion.Trim().ToUpper())
                {

                    case "AGREGAR":

                        Consultas = @"SELECT CASE WHEN EXISTS(Select IdModuloInterfazUsuario from modulointerfazusuario where IdPrivilegio = @IdPrivilegio and IdUsuario = @IdUsuario) THEN 1 ELSE 0 END AS 'RES'";
                        Comando.Parameters.Add(new MySqlParameter("@IdPrivilegio", MySqlDbType.Int32)).Value = oRegistroEN.oPrivilegioEN.IdPrivilegio;
                        Comando.Parameters.Add(new MySqlParameter("@IdUsuario", MySqlDbType.Int32)).Value = oRegistroEN.oUsuarioEN.IdUsuario;

                        break;

                    case "ACTUALIZAR":

                        Consultas = @"SELECT CASE WHEN EXISTS(Select IdModuloInterfazUsuario from modulointerfazusuario where IdPrivilegio = @IdPrivilegio and IdUsuario = @IdUsuario and IdModuloInterfazUsuario <> @IdModuloInterfazUsuario) THEN 1 ELSE 0 END AS 'RES'";
                        Comando.Parameters.Add(new MySqlParameter("@IdPrivilegio", MySqlDbType.Int32)).Value = oRegistroEN.oPrivilegioEN.IdPrivilegio;
                        Comando.Parameters.Add(new MySqlParameter("@IdUsuario", MySqlDbType.Int32)).Value = oRegistroEN.oUsuarioEN.IdUsuario;
                        Comando.Parameters.Add(new MySqlParameter("@IdModuloInterfazUsuario", MySqlDbType.Int32)).Value = oRegistroEN.IdModuloInterfazUsuario;

                        break;

                    default:
                        throw new ArgumentException("La aperación solicitada no esta disponible");

                }

                Comando.CommandText = Consultas;

                Adaptador = new MySqlDataAdapter();
                DT = new DataTable();

                Adaptador.SelectCommand = Comando;
                Adaptador.Fill(DT);

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
                oTransaccionesAD.Agregar(oRegistroEN.oLoginEN.IdUsuario, oRegistroEN.oLoginEN.NumeroIP, oRegistroEN.IdModuloInterfazUsuario, "VALIDAR", "ERROR AL VALIDAR LA INFORMACIÓN DE LA MODULO INTERFAZ USUARIO", "ERROR", DescripcionDeOperacion, oRegistroEN.oLoginEN.IdUsuario, oDatos);

                return false;
            }
            finally
            {

                FinalizarLaConexion();

            }

        }

        #endregion

        #region "Funciones que retornan información"

        private void IniciarVariablesGlovales(DatosDeConexionEN oDatos)
        {
            
            Cnn = new MySqlConnection(TraerCadenaDeConexion(oDatos));            
            Cnn.Open();            

            Comando = new MySqlCommand();
            Comando.Connection = Cnn;
            Comando.CommandType = CommandType.Text;
        }
        
        private void FinalizarLaConexion()
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
            oTransaccionesAD = null;
        }

        private string InformacionDelRegistro(ModuloInterfazUsuarioEN oRegistroEN)
        {

            string Cadena = @"IdModuloInterfazUsuario: {0}, IdPrivilegio: {1}, IdUsuario: {2}, Acceso: {3}, IdUsuarioDeCreacion: {4}, FechaDeCreacion: {5}, IdUsuarioDeModificacion: {6}, FechaDeModificacion: {7}";
            Cadena = string.Format(Cadena, oRegistroEN.IdModuloInterfazUsuario, oRegistroEN.oPrivilegioEN.IdPrivilegio, oRegistroEN.oUsuarioEN.IdUsuario, oRegistroEN.Acceso, oRegistroEN.IdUsuarioDeCreacion, oRegistroEN.FechaDeCreacion, oRegistroEN.IdUsuarioDeModificacion, oRegistroEN.FechaDeModificacion);
            Cadena = Cadena.Replace(",", Environment.NewLine);
            return Cadena;

        }

        private string TraerCadenaDeConexion(DatosDeConexionEN oDatos)
        {            
            string cadena = string.Format("Data Source='{0}';Initial Catalog='{1}';Persist Security Info=True;User ID='{2}';Password='{3}'", oDatos.Servidor, oDatos.BaseDeDatos, oDatos.Usuario, oDatos.Contrasena);
            return cadena;            
        }

        public DataTable TraerDatos()
        {
            return DT;
        }

        #endregion

    }
}
