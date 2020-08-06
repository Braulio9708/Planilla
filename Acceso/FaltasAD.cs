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
    public class FaltasAD
    {

        public string Error { set; get; }
        private MySqlConnection Cnn = null;
        private MySqlCommand Comando = null;
        private MySqlDataAdapter Adaptador = null;
        private TransaccionesAD oTransaccionesAD = null;
        string Consultas;
        string DescripcionDeLaOperacion;
        private DataTable DT { set; get; }

        public FaltasAD()
        {

            oTransaccionesAD = new TransaccionesAD();
            oTransaccionesAD.Modulo = "General";
            oTransaccionesAD.Modelo = "FaltasAD";
            oTransaccionesAD.NombreDelEquipo = Environment.MachineName;
            oTransaccionesAD.FechaDeCreacion = System.DateTime.Now;
            oTransaccionesAD.Tabla = "FaltasAD";

        }

        #region "Funciones dll"

        public bool Agregar(FaltasEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            oTransaccionesAD = new TransaccionesAD();
            try
            {
                InicialisarVariablesGlovales(oDatos);
                Consultas = @"insert into faltas 
				                (Fecha, IdEmpleado) 
                                values 
                                (@Fecha, @IdEmpleado);
                            Select  last_insert_ID() as 'ID';";

                Comando.Parameters.Add(new MySqlParameter("@Fecha", MySqlDbType.Date)).Value = oRegistroEN.Fecha;
                Comando.Parameters.Add(new MySqlParameter("@IdEmpleado", MySqlDbType.Int32)).Value = oRegistroEN.oEmpleadoEN.IdEmpleado;

                InicialisarAdaptador();

                oRegistroEN.IdFaltas = Convert.ToInt32(DT.Rows[0].ItemArray[0].ToString());

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

        public bool Actualizar(FaltasEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            oTransaccionesAD = new TransaccionesAD();
            try
            {
                InicialisarVariablesGlovales(oDatos);

                Consultas = @"UPDATE faltas set
	                            Fecha = @Fecha, 
                                IdEmpleado = @IdEmpleado                    
                            where IdFaltas = @IdFaltas;";

                Comando.Parameters.Add(new MySqlParameter("@IdFaltas", MySqlDbType.Int32)).Value = oRegistroEN.IdFaltas;
                Comando.Parameters.Add(new MySqlParameter("@Fecha", MySqlDbType.Date)).Value = oRegistroEN.Fecha;
                Comando.Parameters.Add(new MySqlParameter("@IdEmpleado", MySqlDbType.Int32)).Value = oRegistroEN.oEmpleadoEN.IdEmpleado;

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

        public bool Eliminar(FaltasEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            oTransaccionesAD = new TransaccionesAD();
            try
            {
                InicialisarVariablesGlovales(oDatos);

                Consultas = @"delete from faltas where IdFaltas = @IdFaltas;";

                Comando.Parameters.Add(new MySqlParameter("@IdFaltas", MySqlDbType.Int32)).Value = oRegistroEN.IdFaltas;

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

        public bool Listado(FaltasEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            try
            {
                InicialisarVariablesGlovales(oDatos);

                Consultas = string.Format(@"Select IdFaltas, Fecha, IdEmpleado from faltas where IdFaltas = 0 {0} {1}", oRegistroEN.Where, oRegistroEN.OrderBy);

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

        public bool ListadoPorID(FaltasEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            try
            {
                InicialisarVariablesGlovales(oDatos);

                Consultas = string.Format(@"Select IdFaltas, Fecha, IdEmpleado from faltas where IdFaltas = {0} ", oRegistroEN.IdFaltas);
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

        public bool ListadoParaCombos(FaltasEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                InicialisarVariablesGlovales(oDatos);

                Consultas = string.Format(@"select IdFaltas, Fecha, IdEmpleado from faltas where IdFaltas > 0 {0} {1}; ", oRegistroEN.Where, oRegistroEN.OrderBy);
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

        public bool ListadoParaReportes(FaltasEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                InicialisarVariablesGlovales(oDatos);

                Consultas = string.Format(@"select IdFaltas, Fecha, IdEmpleado from faltas where IdFaltas > 0 {0} {1} ", oRegistroEN.Where, oRegistroEN.OrderBy);
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
        private TransaccionesEN InformacionDelaTransaccion(FaltasEN oFaltas, String TipoDeOperacion, String Descripcion, String Estado)
        {
            TransaccionesEN oRegistroEN = new TransaccionesEN();

            oRegistroEN.IdRegistro = oFaltas.IdFaltas;
            oRegistroEN.Modelo = "FaltasAD";
            //oRegistroEN.Modulo = "Clientes";
            oRegistroEN.Tabla = "Faltas";
            oRegistroEN.TipoDeOperacion = TipoDeOperacion;
            oRegistroEN.Estado = Estado;
            oRegistroEN.IP = oFaltas.oLoginEN.NumeroIP;
            oRegistroEN.IdUsuario = oFaltas.oLoginEN.IdUsuario;
            oRegistroEN.IdUsuarioAPrueva = oFaltas.oLoginEN.IdUsuario;
            oRegistroEN.DescripcionDelUsuario = DescripcionDeLaOperacion;
            oRegistroEN.DescripcionInterna = Descripcion;
            oRegistroEN.nombredelequipo = oFaltas.oLoginEN.NombreDelEquipo;

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
        private string InformacionDelRegistro(FaltasEN oRegistroEN)
        {
            string Cadena = @"IdFaltas: {0}, Fecha: {1}, IdEmpleado: {2}";
            Cadena = string.Format(Cadena, oRegistroEN.IdFaltas, oRegistroEN.Fecha, oRegistroEN.oEmpleadoEN.IdEmpleado);
            Cadena = Cadena.Replace(",", Environment.NewLine);
            return Cadena;
        }
        #endregion

    }
}
