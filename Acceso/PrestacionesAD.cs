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
    class PrestacionesAD
    {

        public string Error { set; get; }
        private MySqlConnection Cnn = null;
        private MySqlCommand Comando = null;
        private MySqlDataAdapter Adaptador = null;
        private TransaccionesAD oTransaccionesAD = null;
        string Consultas;
        string DescripcionDeLaOperacion;

        private DataTable DT { set; get; }

        public PrestacionesAD()
        {
            oTransaccionesAD = new TransaccionesAD();
            oTransaccionesAD.Modulo = "General";
            oTransaccionesAD.Modelo = "PrestacionesAD";
            oTransaccionesAD.NombreDelEquipo = Environment.MachineName;
            oTransaccionesAD.FechaDeCreacion = System.DateTime.Now;
            oTransaccionesAD.Tabla = "Prestaciones";
        }

        #region "Funcion De Datos dll"

        public bool Agregar(PrestacionesEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            oTransaccionesAD = new TransaccionesAD();
            try
            {
                InicialisarVariablesGlovales(oDatos);
                Consultas = @"insert into prestaciones 
				                (Aguinaldo, Antiguedad, Liquidacion, Vacaciones, IdEmpleado) 
                                values 
                                (@Aguinaldo, @Antiguedad, @Liquidacion, @Vacaciones, @IdEmpleado);
                            Select  last_insert_ID() as 'ID';";

                Comando.Parameters.Add(new MySqlParameter("@Aguinaldo", MySqlDbType.Decimal)).Value = oRegistroEN.Aguinaldo;
                Comando.Parameters.Add(new MySqlParameter("@Antiguedad", MySqlDbType.Decimal)).Value = oRegistroEN.Antiguedad;
                Comando.Parameters.Add(new MySqlParameter("@Liquidacion", MySqlDbType.Decimal)).Value = oRegistroEN.Liquidacion;
                Comando.Parameters.Add(new MySqlParameter("@Vacaciones", MySqlDbType.Decimal)).Value = oRegistroEN.Vacaciones;
                Comando.Parameters.Add(new MySqlParameter("@IdEmpleado", MySqlDbType.Int32)).Value = oRegistroEN.oEmpleadoEN.IdEmpleado;

                InicialisarAdaptador();

                oRegistroEN.IdPrestaciones = Convert.ToInt32(DT.Rows[0].ItemArray[0].ToString());

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

        public bool Actualizar(PrestacionesEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            oTransaccionesAD = new TransaccionesAD();

            try
            {
                InicialisarVariablesGlovales(oDatos);

                Consultas = @"UPDATE prestaciones set
	                            Aguinaldo = @Aguinaldo,
                                Antiguedad = @Antiguedad,
                                Liquidacion = @Liquidacion,
                                Vacaciones = @Vacaciones,
                                IdEmpleado = @IdEmpleado                    
                            where IdPrestaciones = @IdPrestaciones;";

                Comando.CommandText = Consultas;

                Comando.Parameters.Add(new MySqlParameter("@IdPrestaciones", MySqlDbType.Int32)).Value = oRegistroEN.IdPrestaciones;
                Comando.Parameters.Add(new MySqlParameter("@Aguinaldo", MySqlDbType.Decimal)).Value = oRegistroEN.Aguinaldo;
                Comando.Parameters.Add(new MySqlParameter("@Antiguedad", MySqlDbType.Decimal)).Value = oRegistroEN.Antiguedad;
                Comando.Parameters.Add(new MySqlParameter("@Liquidacion", MySqlDbType.Decimal)).Value = oRegistroEN.Liquidacion;
                Comando.Parameters.Add(new MySqlParameter("@Vacaciones", MySqlDbType.Decimal)).Value = oRegistroEN.Vacaciones;
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

        public bool Eliminar(PrestacionesEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            oTransaccionesAD = new TransaccionesAD();

            try
            {
                InicialisarVariablesGlovales(oDatos);

                Consultas = @"Delete from prestaciones where IdPrestaciones = @IdPrestaciones;";
                Comando.CommandText = Consultas;

                Comando.Parameters.Add(new MySqlParameter("@IdPrestaciones", MySqlDbType.Int32)).Value = oRegistroEN.IdPrestaciones;

                Comando.ExecuteNonQuery();

                DescripcionDeLaOperacion = string.Format("El registro fue eliminado correctamente. {0} {1}", Environment.NewLine, InformacionDelRegistro(oRegistroEN));

                //Agregamos la transaccion...
                TransaccionesEN oTransacciones = InformacionDelaTransaccion(oRegistroEN, "Eliminar", "Elminar Registro", "CORRECTO");
                oTransaccionesAD.Agregar(oTransacciones, oDatos);

                return true;
            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

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

        public bool Listado(PrestacionesEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            try
            {
                InicialisarVariablesGlovales(oDatos);

                Consultas = string.Format(@"Select IdPrestaciones, Aguinaldo, Antiguedad, Liquidacion, Vacaciones, IdEmpleado from prestaciones where IdPrestaciones > 0 {0} {1} ", oRegistroEN.Where, oRegistroEN.OrderBy);
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

        public bool ListadoPorID(PrestacionesEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            try
            {
                InicialisarVariablesGlovales(oDatos);

                Consultas = string.Format(@"Select IdPrestaciones, Aguinaldo, Antiguedad, Liquidacion, Vacaciones, IdEmpleado from prestaciones where IdPrestaciones > {0} ", oRegistroEN.IdPrestaciones);
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

        public bool ListadoParaCombos(PrestacionesEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                InicialisarVariablesGlovales(oDatos);

                Consultas = string.Format(@"select IdPrestaciones, Aguinaldo, Antiguedad, Liquidacion, Vacaciones, IdEmpleado from prestaciones where IdPrestaciones > 0 {0} {1}; ", oRegistroEN.Where, oRegistroEN.OrderBy);
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

        public bool ListadoParaReportes(PrestacionesEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                InicialisarVariablesGlovales(oDatos);

                Consultas = string.Format(@"select IdPrestaciones, Aguinaldo, Antiguedad, Liquidacion, Vacaciones, IdEmpleado from prestaciones where IdPrestaciones > 0 {0} {1} ", oRegistroEN.Where, oRegistroEN.OrderBy);
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
        private TransaccionesEN InformacionDelaTransaccion(PrestacionesEN oPrestaciones, String TipoDeOperacion, String Descripcion, String Estado)
        {
            TransaccionesEN oRegistroEN = new TransaccionesEN();

            oRegistroEN.IdRegistro = oPrestaciones.IdPrestaciones;
            oRegistroEN.Modelo = "PrestacionAD";
            //oRegistroEN.Modulo = "#";
            oRegistroEN.Tabla = "Prestaciones";
            oRegistroEN.TipoDeOperacion = TipoDeOperacion;
            oRegistroEN.Estado = Estado;
            oRegistroEN.IP = oPrestaciones.oLoginEN.NumeroIP;
            oRegistroEN.IdUsuario = oPrestaciones.oLoginEN.IdUsuario;
            oRegistroEN.IdUsuarioAPrueva = oPrestaciones.oLoginEN.IdUsuario;
            oRegistroEN.DescripcionDelUsuario = DescripcionDeLaOperacion;
            oRegistroEN.DescripcionInterna = Descripcion;
            oRegistroEN.nombredelequipo = oPrestaciones.oLoginEN.NombreDelEquipo;

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
        private string InformacionDelRegistro(PrestacionesEN oRegistroEN)
        {
            string Cadena = @"IdPrestaciones: {0}, Aguinaldo: {1}, Antiguedad: {2}, Liquidacion: {3}, Vacaciones: {4}, IdEmpleado: {5}";
            Cadena = string.Format(Cadena, oRegistroEN.IdPrestaciones, oRegistroEN.Aguinaldo, oRegistroEN.Antiguedad, oRegistroEN.Liquidacion, oRegistroEN.Vacaciones, oRegistroEN.oEmpleadoEN.IdEmpleado);
            Cadena = Cadena.Replace(",", Environment.NewLine);
            return Cadena;
        }
        #endregion

    }
}
