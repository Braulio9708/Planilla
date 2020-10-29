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
    public class HorarioAD
    {

        public string Error { set; get; }
        private MySqlConnection Cnn = null;
        private MySqlCommand Comando = null;
        private MySqlDataAdapter Adaptador = null;
        private TransaccionesAD oTransaccionesAD = null;
        string Consultas;

        private DataTable DT { set; get; }

        public HorarioAD()
        {

            oTransaccionesAD = new TransaccionesAD();
            oTransaccionesAD.Modulo = "General";
            oTransaccionesAD.Modelo = "HorarioAD";
            oTransaccionesAD.NombreDelEquipo = Environment.MachineName;
            oTransaccionesAD.FechaDeCreacion = System.DateTime.Now;
            oTransaccionesAD.Tabla = "HorarioAD";

        }

        #region "Funciones dll"

        public bool Agregar(HorarioEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            try
            {
                InicialisarVariablesGlovales(oDatos);

                Consultas = @"insert into horario 
				                (HoraDeEntrada, HoraDeSalida, IdEmpleado) 
                                values 
                                (@HoraDeEntrada, @HoraDeSalida, @IdEmpleado);
                            Select  last_insert_ID() as 'ID';";

                Comando.CommandText = Consultas;

                Comando.Parameters.Add(new MySqlParameter("@HoraDeEntrada", MySqlDbType.Datetime)).Value = oRegistroEN.HoraDeEntrada;
                Comando.Parameters.Add(new MySqlParameter("@HoraDeSalida", MySqlDbType.Datetime)).Value = oRegistroEN.HoraDeSalida;
                Comando.Parameters.Add(new MySqlParameter("@IdEmpleado", MySqlDbType.Int32)).Value = oRegistroEN.oEmpleadoEN.IdEmpleado;
                                                
                InicialisarAdaptador();
                
                oRegistroEN.IdHorario = Convert.ToInt32(DT.Rows[0].ItemArray[0].ToString());
                
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

        public bool Actualizar(HorarioEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            try
            {
                InicialisarVariablesGlovales(oDatos);

                Consultas = @"UPDATE horario set
	                            HoraDeEntrada = @HoraDeEntrada,
                                HoraDeSalida = @HoraDeSalida,
                                IdEmpleado = @IdEmpleado                    
                            where IdHorario = @IdHorario;";

                Comando.CommandText = Consultas;

                Comando.Parameters.Add(new MySqlParameter("@IdHorario", MySqlDbType.Int32)).Value = oRegistroEN.IdHorario;
                Comando.Parameters.Add(new MySqlParameter("@HoraDeEntrada", MySqlDbType.Datetime)).Value = oRegistroEN.HoraDeEntrada;
                Comando.Parameters.Add(new MySqlParameter("@HoraDeSalida", MySqlDbType.Datetime)).Value = oRegistroEN.HoraDeSalida;
                Comando.Parameters.Add(new MySqlParameter("@IdEmpleado", MySqlDbType.Int32)).Value = oRegistroEN.oEmpleadoEN.IdEmpleado;

                Comando.ExecuteNonQuery();
                
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

        public bool Eliminar(HorarioEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            try
            {
                InicialisarVariablesGlovales(oDatos);

                Consultas = @"delete from horario where IdHorario = @IdHorario;";
                
                Comando.CommandText = Consultas;

                Comando.Parameters.Add(new MySqlParameter("@IdHorario", MySqlDbType.Int32)).Value = oRegistroEN.IdHorario;

                Comando.ExecuteNonQuery();

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

        public bool Listado(HorarioEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            try
            {
                InicialisarVariablesGlovales(oDatos);
                
                Consultas = string.Format(@"Select hio.IdHorario, hio.HoraDeEntrada, hio.HoraDeSalida, hio.IdEmpleado, emp.Nombre as 'Empleado' from horario as hio
						                    inner join empleado as emp on emp.IdEmpleado = hio.IdEmpleado
                                            where IdHorario > 0 {0} {1}", oRegistroEN.Where, oRegistroEN.OrderBy);

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

        public bool ListadoPorID(HorarioEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            try
            {
                InicialisarVariablesGlovales(oDatos);

                Consultas = string.Format(@"Select hio.IdHorario, hio.HoraDeEntrada, hio.HoraDeSalida, hio.IdEmpleado, emp.Nombre as 'Empleado' from horario as hio
						                    inner join empleado as emp on emp.IdEmpleado = hio.IdEmpleado
                                            where IdHorario > @IdHorario ", oRegistroEN.IdHorario);

                Comando.Parameters.Add(new MySqlParameter("@IdHorario", MySqlDbType.Int32)).Value = oRegistroEN.IdHorario;

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

        public bool ListadoParaCombos(HorarioEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                InicialisarVariablesGlovales(oDatos);

                Consultas = string.Format(@"Select hio.IdHorario, hio.HoraDeEntrada, hio.HoraDeSalida, hio.IdEmpleado, emp.Nombre as 'Empleado' from horario as hio
						                    inner join empleado as emp on emp.IdEmpleado = hio.IdEmpleado
                                            where IdHorario > 0 {0} {1}; ", oRegistroEN.Where, oRegistroEN.OrderBy);
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

        public bool ListadoParaReportes(HorarioEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            try
            {
                InicialisarVariablesGlovales(oDatos);

                Consultas = string.Format(@"Select hio.IdHorario, hio.HoraDeEntrada, hio.HoraDeSalida, hio.IdEmpleado, emp.Nombre as 'Empleado' from horario as hio
						                    inner join empleado as emp on emp.IdEmpleado = hio.IdEmpleado
                                            where IdHorario > 0 {0} {1} ", oRegistroEN.Where, oRegistroEN.OrderBy);

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
        private TransaccionesEN InformacionDelaTransaccion(HorarioEN oHorario, String TipoDeOperacion, String Descripcion, String Estado)
        {
            TransaccionesEN oRegistroEN = new TransaccionesEN();

            oRegistroEN.IdRegistro = oHorario.IdHorario;
            oRegistroEN.Modelo = "HorarioAD";
            //oRegistroEN.Modulo = "Clientes";
            oRegistroEN.Tabla = "Horario";
            oRegistroEN.TipoDeOperacion = TipoDeOperacion;
            oRegistroEN.Estado = Estado;
            oRegistroEN.IP = oHorario.oLoginEN.NumeroIP;
            oRegistroEN.IdUsuario = oHorario.oLoginEN.IdUsuario;
            oRegistroEN.IdUsuarioAPrueva = oHorario.oLoginEN.IdUsuario;
            oRegistroEN.DescripcionInterna = Descripcion;
            oRegistroEN.nombredelequipo = oHorario.oLoginEN.NombreDelEquipo;

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
        private string InformacionDelRegistro(HorarioEN oRegistroEN)
        {
            string Cadena = @"IdHorario: {0}, HoraDeEntrada: {1}, HoraDeSalida: {2}, IdEmpleado: {3}";
            Cadena = string.Format(Cadena, oRegistroEN.IdHorario, oRegistroEN.HoraDeEntrada, oRegistroEN.HoraDeSalida, oRegistroEN.oEmpleadoEN.IdEmpleado);
            Cadena = Cadena.Replace(",", Environment.NewLine);
            return Cadena;
        }
        #endregion

        #region "Funciones de Validación"

        public bool ValidarSiElRegistroEstaVinculado(HorarioEN oRegistroEN, DatosDeConexionEN oDatos, string TipoDeOperacion)
        {
            try
            {

                InicialisarVariablesGlobalesProcedure(oDatos);

                Comando.Parameters.Add(new MySqlParameter("@CampoABuscar_", MySqlDbType.VarChar, 200)).Value = "IdHorario";
                Comando.Parameters.Add(new MySqlParameter("@ValorCampoABuscar", MySqlDbType.Int32)).Value = oRegistroEN.IdHorario;
                Comando.Parameters.Add(new MySqlParameter("@ExcluirTabla_", MySqlDbType.VarChar, 200)).Value = string.Empty;

                InicialisarAdaptador();

                if (DT.Rows[0].ItemArray[0].ToString().ToUpper() == "NINGUNA".ToUpper())
                {
                    return false;
                }
                else
                {
                    return true;
                }

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

        public bool ValidarRegistroDuplicado(HorarioEN oRegistroEN, DatosDeConexionEN oDatos, string TipoDeOperacion)
        {
            try
            {
                InicialisarVariablesGlovales(oDatos);

                switch (TipoDeOperacion.Trim().ToUpper())
                {

                    case "AGREGAR":

                        Consultas = @"SELECT CASE WHEN EXISTS(Select IdHorario from horario where IdEmpleado = @IdEmpleado) THEN 1 ELSE 0 END AS 'RES'";
                        Comando.Parameters.Add(new MySqlParameter("@IdEmpleado", MySqlDbType.Int32)).Value = oRegistroEN.oEmpleadoEN.IdEmpleado;

                        break;

                    case "ACTUALIZAR":

                        Consultas = @"SELECT CASE WHEN EXISTS(Select IdHorario from horario where IdEmpleado = @IdEmpleado and IdHorario <> @IdHorario) THEN 1 ELSE 0 END AS 'RES'";
                        Comando.Parameters.Add(new MySqlParameter("@IdHorario", MySqlDbType.Int32)).Value = oRegistroEN.IdHorario;
                        Comando.Parameters.Add(new MySqlParameter("@IdEmpleado", MySqlDbType.Int32)).Value = oRegistroEN.oEmpleadoEN.IdEmpleado;

                        break;

                    default:
                        throw new ArgumentException("La aperación solicitada no esta disponible");

                }
                
                Comando.CommandText = Consultas;
                //Console.WriteLine("BUSCAR EL ERROR");
                InicialisarAdaptador();

                if (Convert.ToInt32(DT.Rows[0]["RES"].ToString()) > 0)
                {
                    return true;
                }

                return false;

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

    }
}
