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
    class ModuloInterfazAD
    {

        public string Error { set; get; }
        private MySqlConnection Cnn = null;
        private MySqlCommand Comando = null;
        private MySqlDataAdapter Adaptador = null;
        private TransaccionesAD oTransaccionesAD = null;
        string Consultas;
        string DescripcionDeOperacion;
        private DataTable DT { set; get; }

        public ModuloInterfazAD()
        {

            oTransaccionesAD = new TransaccionesAD();
            oTransaccionesAD.Modulo = "General";
            oTransaccionesAD.Modelo = "ModuloInterfazAD";
            oTransaccionesAD.NombreDelEquipo = Environment.MachineName;
            oTransaccionesAD.FechaDeCreacion = System.DateTime.Now;
            oTransaccionesAD.Tabla = "ModuloInterfaz";

        }

        #region "Funciones para datos dll"

        public bool Agregar(ModuloInterfazEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            oTransaccionesAD = new TransaccionesAD();
            try
            {

                InicialisarVariablesGlovales(oDatos);

                Consultas = @"insert into modulointerfaz 
				                (IdModulo, IdInterfaz, IdUsuarioDeCreacion, 
                                FechaDeCreacion, IdUsuarioDeModificacion, FechaDeModificacion) 
                                values 
                                (@IdModulo, @IdInterfaz, @IdUsuarioDeCreacion, current_timestamp(), 
                                @IdUsuarioDeModificacion, current_timestamp());
                            Select  last_insert_ID() as 'ID';";

                Comando.CommandText = Consultas;

                Comando.Parameters.Add(new MySqlParameter("@IdModulo", MySqlDbType.Int32)).Value = oRegistroEN.oModuloEN.IdModulo;
                Comando.Parameters.Add(new MySqlParameter("@IdInterfaz", MySqlDbType.Int32)).Value = oRegistroEN.oInterfazEN.IdInterfaz;
                Comando.Parameters.Add(new MySqlParameter("@IdUsuarioDeCreacion", MySqlDbType.Int32)).Value = oRegistroEN.oLoginEN.IdUsuario;
                Comando.Parameters.Add(new MySqlParameter("@IdUsuarioDeModificacion", MySqlDbType.Int32)).Value = oRegistroEN.oLoginEN.IdUsuario;

                InicialisarAdaptador();

                oRegistroEN.IdModuloInterfaz = Convert.ToInt32(DT.Rows[0].ItemArray[0].ToString());

                DescripcionDeOperacion = string.Format("El registro fue Insertado Correctamente. {0} {1}", Environment.NewLine, InformacionDelRegistro(oRegistroEN));

                oTransaccionesAD.Agregar(oRegistroEN.oLoginEN.IdUsuario, oRegistroEN.oLoginEN.NumeroIP, oRegistroEN.IdModuloInterfaz, "AGREGAR", "INFORMACIÓN DE LA MODULO INTERFAZ AGREGADA CORRECTAMENTE", "CORRECTA", DescripcionDeOperacion, oRegistroEN.oLoginEN.IdUsuario, oDatos);

                return true;

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                DescripcionDeOperacion = string.Format("Se produjo el seguiente error: '{2}' al insertar el registro. {0} {1} ", Environment.NewLine, InformacionDelRegistro(oRegistroEN), ex.Message);
                oTransaccionesAD.Agregar(oRegistroEN.oLoginEN.IdUsuario, oRegistroEN.oLoginEN.NumeroIP, oRegistroEN.IdModuloInterfaz, "AGREGAR", "ERROR AL AGREGAR LA INFORMACIÓN DE LA MODULOINTERFAZ", "ERROR", DescripcionDeOperacion, oRegistroEN.oLoginEN.IdUsuario, oDatos);

                return false;
            }
            finally
            {

                FinalizarConexion();
                oTransaccionesAD = null;

            }

        }

        public bool Actualizar(ModuloInterfazEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            oTransaccionesAD = new TransaccionesAD();
            try
            {

                InicialisarVariablesGlovales(oDatos);

                Consultas = @"UPDATE modulointerfaz set
	                            IdModulo = @IdModulo,
                                IdInterfaz = @IdInterfaz,
                                IdUsuarioDeCreacion = @IdUsuarioDeCreacion,
                                FechaDeCreacion = @FechaDeCreacion,
                                IdUsuarioDeModificacion = @IdUsuarioDeModificacion,
                                FechaDeModificacion = @FechaDeModificacion                    
                            where IdModuloInterfaz = @IdModuloInterfaz;";

                Comando.CommandText = Consultas;

                Comando.Parameters.Add(new MySqlParameter("@IdModuloInterfaz", MySqlDbType.Int32)).Value = oRegistroEN.IdModuloInterfaz;
                Comando.Parameters.Add(new MySqlParameter("@IdModulo", MySqlDbType.Int32)).Value = oRegistroEN.oModuloEN.IdModulo;
                Comando.Parameters.Add(new MySqlParameter("@IdInterfaz", MySqlDbType.Int32)).Value = oRegistroEN.oInterfazEN.IdInterfaz;
                Comando.Parameters.Add(new MySqlParameter("@IdUsuarioDeModificacion", MySqlDbType.Int32)).Value = oRegistroEN.oLoginEN.IdUsuario;


                Comando.ExecuteNonQuery();

                DescripcionDeOperacion = string.Format("El registro fue Actualizado Correctamente. {0} {1}", Environment.NewLine, InformacionDelRegistro(oRegistroEN));

                oTransaccionesAD.Agregar(oRegistroEN.oLoginEN.IdUsuario, oRegistroEN.oLoginEN.NumeroIP, oRegistroEN.IdModuloInterfaz, "ACTUALIZAR", "INFORMACIÓN DE LA MODULO INTERFAZ ACTUALIZADA", "CORRECTA", DescripcionDeOperacion, oRegistroEN.oLoginEN.IdUsuario, oDatos);

                return true;

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                DescripcionDeOperacion = string.Format("Se produjo el seguiente error: '{2}' al actualizar el registro. {0} {1} ", Environment.NewLine, InformacionDelRegistro(oRegistroEN), ex.Message);
                oTransaccionesAD.Agregar(oRegistroEN.oLoginEN.IdUsuario, oRegistroEN.oLoginEN.NumeroIP, oRegistroEN.IdModuloInterfaz, "ACTUALIZAR", "ERROR AL ACTUALIZAR LA INFORMACIÓN DE LA MODULO INTERFAZ", "ERROR", DescripcionDeOperacion, oRegistroEN.oLoginEN.IdUsuario, oDatos);

                return false;
            }
            finally
            {

                FinalizarConexion();
                oTransaccionesAD = null;

            }

        }

        public bool Eliminar(ModuloInterfazEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            oTransaccionesAD = new TransaccionesAD();
            try
            {

                InicialisarVariablesGlovales(oDatos);

                Consultas = @"DELETE FROM modulointerfaz WHERE IdModuloInterfaz = @IdModuloInterfaz;";
                Comando.CommandText = Consultas;

                Comando.Parameters.Add(new MySqlParameter("@IdModuloInterfaz", MySqlDbType.Int32)).Value = oRegistroEN.IdModuloInterfaz;

                Comando.ExecuteNonQuery();

                DescripcionDeOperacion = string.Format("El registro fue Eliminado Correctamente. {0} {1}", Environment.NewLine, InformacionDelRegistro(oRegistroEN));

                oTransaccionesAD.Agregar(oRegistroEN.oLoginEN.IdUsuario, oRegistroEN.oLoginEN.NumeroIP, oRegistroEN.IdModuloInterfaz, "ELIMINAR", "INFORMACIÓN DE LA MODULO INTERFAZ ELIMINADA", "CORRECTA", DescripcionDeOperacion, oRegistroEN.oLoginEN.IdUsuario, oDatos);

                return true;

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                DescripcionDeOperacion = string.Format("Se produjo el seguiente error: '{2}' al eliminar el registro. {0} {1} ", Environment.NewLine, InformacionDelRegistro(oRegistroEN), ex.Message);
                oTransaccionesAD.Agregar(oRegistroEN.oLoginEN.IdUsuario, oRegistroEN.oLoginEN.NumeroIP, oRegistroEN.IdModuloInterfaz, "ELIMINAR", "ERROR AL ELIMINAR LA INFORMACIÓN DE LA MOUDLO INTERFAZ", "ERROR", DescripcionDeOperacion, oRegistroEN.oLoginEN.IdUsuario, oDatos);

                return false;
            }
            finally
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

        }

        public bool Listado(ModuloInterfazEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                Cnn = new MySqlConnection(TraerCadenaDeConexion(oDatos));
                Cnn.Open();

                Comando = new MySqlCommand();
                Comando.Connection = Cnn;
                Comando.CommandType = CommandType.Text;

                Consultas = string.Format(@"SELECT mi.IdModuloInterfaz, mi.IdInterfaz, mi.IdModulo, 
                i.Nombre as 'Interfaz', i.NombreAMostrar, m.Nombre as 'Modulo', 
                mi.IdUsuarioDeCreacion, mi.FechaDeCreacion, mi.IdUsuarioDeCreacion, mi.FechaDeModificacion
                FROM modulointerfaz AS mi
                inner join modulo as m on m.IdModulo = mi.IdModulo
                inner join interfaz as i on i.IdInterfaz = mi.IdInterfaz
                where mi.IdModuloInterfaz > 0 {0} {1} ", oRegistroEN.Where, oRegistroEN.OrderBy);
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

                if (Cnn != null)
                {

                    FinalizarConexion();

                }

            }
        }

        public bool ListadoPorIdentificador(ModuloInterfazEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                InicialisarVariablesGlovales(oDatos);

                Consultas = string.Format(@"SELECT mi.IdModuloInterfaz, mi.IdInterfaz, mi.IdModulo, 
                i.Nombre as 'Interfaz', i.NombreAMostrar, m.Nombre as 'Modulo', 
                mi.IdUsuarioDeCreacion, mi.FechaDeCreacion, mi.IdUsuarioDeCreacion, mi.FechaDeModificacion
                FROM modulointerfaz AS mi
                inner join modulo as m on m.IdModulo = mi.IdModulo
                inner join interfaz as i on i.IdInterfaz = mi.IdInterfaz
                where mi.IdModuloInterfaz = {0} ", oRegistroEN.IdModuloInterfaz);
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

        public bool ListadoParaCombos(ModuloInterfazEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                InicialisarVariablesGlovales(oDatos);

                Consultas = string.Format(@"SELECT mi.IdModuloInterfaz, mi.IdInterfaz, mi.IdModulo, 
                i.Nombre as 'Interfaz', i.NombreAMostrar, m.Nombre as 'Modulo', 
                mi.IdUsuarioDeCreacion, mi.FechaDeCreacion, mi.IdUsuarioDeCreacion, mi.FechaDeModificacion
                FROM modulointerfaz AS mi
                inner join modulo as m on m.IdModulo = mi.IdModulo
                inner join interfaz as i on i.IdInterfaz = mi.IdInterfaz
                where mi.IdModuloInterfaz > 0 {0} {1}; ", oRegistroEN.Where, oRegistroEN.OrderBy);
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

        public bool ListadoParaReportes(ModuloInterfazEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                InicialisarVariablesGlovales(oDatos);

                Consultas = string.Format(@"SELECT mi.IdModuloInterfaz, mi.IdInterfaz, mi.IdModulo, 
                i.Nombre as 'Interfaz', i.NombreAMostrar, m.Nombre as 'Modulo', 
                mi.IdUsuarioDeCreacion, mi.FechaDeCreacion, mi.IdUsuarioDeCreacion, mi.FechaDeModificacion
                FROM modulointerfaz AS mi
                inner join modulo as m on m.IdModulo = mi.IdModulo
                inner join interfaz as i on i.IdInterfaz = mi.IdInterfaz
                where mi.IdModuloInterfaz > 0 {0} {1} ", oRegistroEN.Where, oRegistroEN.OrderBy);
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

        public bool ValidarRegistroDuplicado(ModuloInterfazEN oRegistroEN, DatosDeConexionEN oDatos, string TipoDeOperacion)
        {

            try
            {

                InicialisarVariablesGlovales(oDatos);

                switch (TipoDeOperacion.Trim().ToUpper())
                {

                    case "AGREGAR":

                        Consultas = @"SELECT CASE WHEN EXISTS(select IdModuloInterfaz from modulointerfaz where IdModulo = @IdModulo and IdInterfaz = @IdInterfaz) THEN 1 ELSE 0 END AS 'RES'";
                        Comando.Parameters.Add(new MySqlParameter("@IdModulo", MySqlDbType.Int32)).Value = oRegistroEN.oModuloEN.IdModulo;
                        Comando.Parameters.Add(new MySqlParameter("@IdInterfaz", MySqlDbType.Int32)).Value = oRegistroEN.oInterfazEN.IdInterfaz;

                        break;

                    case "ACTUALIZAR":

                        Consultas = @"SELECT CASE WHEN EXISTS(select IdModuloInterfaz from modulointerfaz where IdModulo = @IdModulo and IdInterfaz = @IdInterfaz and IdModuloInterfaz <> @IdModuloInterfaz) THEN 1 ELSE 0 END AS 'RES'";
                        Comando.Parameters.Add(new MySqlParameter("@IdModulo", MySqlDbType.Int32)).Value = oRegistroEN.oModuloEN.IdModulo;
                        Comando.Parameters.Add(new MySqlParameter("@IdInterfaz", MySqlDbType.Int32)).Value = oRegistroEN.oInterfazEN.IdInterfaz;
                        Comando.Parameters.Add(new MySqlParameter("@IdModuloInterfaz", MySqlDbType.Int32)).Value = oRegistroEN.IdModuloInterfaz;

                        break;

                    default:
                        throw new ArgumentException("La operación solicitada no esta disponible");

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
                oTransaccionesAD.Agregar(oRegistroEN.oLoginEN.IdUsuario, oRegistroEN.oLoginEN.NumeroIP, oRegistroEN.IdModuloInterfaz, "VALIDAR", "ERROR AL VALIDAR LA INFORMACIÓN DE LA MODULO INTERFAZ", "ERROR", DescripcionDeOperacion, oRegistroEN.oLoginEN.IdUsuario, oDatos);

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
        private TransaccionesEN InformacionDelaTransaccion(InterfazEN oInterfaz, String TipoDeOperacion, String Descripcion, String Estado)
        {
            TransaccionesEN oRegistroEN = new TransaccionesEN();

            oRegistroEN.IdRegistro = oInterfaz.IdInterfaz;
            oRegistroEN.Modelo = "InterfazAD";
            //oRegistroEN.Modulo = "Clientes";
            oRegistroEN.Tabla = "Interfaz";
            oRegistroEN.TipoDeOperacion = TipoDeOperacion;
            oRegistroEN.Estado = Estado;
            oRegistroEN.IP = oInterfaz.oLoginEN.NumeroIP;
            oRegistroEN.IdUsuario = oInterfaz.oLoginEN.IdUsuario;
            oRegistroEN.IdUsuarioAPrueva = oInterfaz.oLoginEN.IdUsuario;
            oRegistroEN.DescripcionDelUsuario = DescripcionDeOperacion;
            oRegistroEN.DescripcionInterna = Descripcion;
            oRegistroEN.nombredelequipo = oInterfaz.oLoginEN.NombreDelEquipo;

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
        private string InformacionDelRegistro(ModuloInterfazEN oRegistroEN)
        {
            string Cadena = @"IdModuloInterfaz: {0}, IdModulo: {1}, IdInterfaz: {2}, FechaDeCreacion: {3}, IdUsuarioDeCreacion: {4}, FechaDeModificacion: {5}, IdUsuarioDeModificacion: {6}";
            Cadena = string.Format(Cadena, oRegistroEN.IdModuloInterfaz, oRegistroEN.oModuloEN.IdModulo, oRegistroEN.oInterfazEN.IdInterfaz,
                oRegistroEN.FechaDeCreacion, oRegistroEN.IdUsuarioDeCreacion, oRegistroEN.FechaDeModificacion, oRegistroEN.IdUsuarioDeModificacion);
            Cadena = Cadena.Replace(",", Environment.NewLine);
            return Cadena;
        }
        #endregion

    }
}
