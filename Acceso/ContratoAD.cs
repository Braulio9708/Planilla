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
    public class ContratoAD
    {
        public string Error { set; get; }
        private MySqlConnection Cnn = null;
        private MySqlCommand Comando = null;
        private MySqlDataAdapter Adaptador = null;
        private TransaccionesAD oTransaccionesAD = null;
        string Consultas;
        string DescripcionDeLaOperacion;
        private DataTable DT { set; get; }

        public ContratoAD()
        {

            oTransaccionesAD = new TransaccionesAD();
            oTransaccionesAD.Modulo = "General";
            oTransaccionesAD.Modelo = "ContratoAD";
            oTransaccionesAD.NombreDelEquipo = Environment.MachineName;
            oTransaccionesAD.FechaDeCreacion = System.DateTime.Now;
            oTransaccionesAD.Tabla = "Contrato";

        }

        #region "Funciones dll"
        public bool Agregar(ContratoEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            try
            {
                InicialisarVariablesGlovales(oDatos);
                Consultas = @"insert into contrato
                        (TipoDeContrato, FechaDeInicio, FechaDeFin, NumeroDeContrato, IdEmpleado)
                        values
                        (@TipoDeContrato, @FechaDeInicio, @FechaDeFin, @NumeroDeContrato, @IdEmpleado);
                        Select  last_insert_ID() as 'ID';";

                Comando.CommandText = Consultas;

                Comando.Parameters.Add(new MySqlParameter("@TipoDeContrato", MySqlDbType.VarChar, oRegistroEN.TipoDeContrato.Trim().Length)).Value = oRegistroEN.TipoDeContrato.Trim();
                Comando.Parameters.Add(new MySqlParameter("@FechaDeInicio", MySqlDbType.Datetime)).Value = oRegistroEN.FechaDeInicio;
                Comando.Parameters.Add(new MySqlParameter("@FechaDeFin", MySqlDbType.Datetime)).Value = oRegistroEN.FechaDeFin;
                Comando.Parameters.Add(new MySqlParameter("@NumeroDeContrato", MySqlDbType.Int32)).Value = oRegistroEN.NumeroDeContrato;
                Comando.Parameters.Add(new MySqlParameter("@IdEmpleado", MySqlDbType.Int32)).Value = oRegistroEN.oEmpladoEN.IdEmpleado;

                InicialisarAdaptador();

                oRegistroEN.IdContrato = Convert.ToInt32(DT.Rows[0].ItemArray[0].ToString());


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

        public bool Actualizar(ContratoEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            try
            {
                InicialisarVariablesGlovales(oDatos);

                Consultas = @"update contrato set 
	
                            TipoDeContrato = @TipoDeContrato,
                            FechaDeInicio = @FechaDeInicio,
                            FechaDeFin = @FechaDeFin,
                            NumeroDeContrato = @NumeroDeContrato,
                            IdEmpleado = @IdEmpleado
    
                            where IdContrato = @IdContrato;";

                Comando.CommandText = Consultas;

                Comando.Parameters.Add(new MySqlParameter("@IdContrato", MySqlDbType.Int32)).Value = oRegistroEN.IdContrato;
                Comando.Parameters.Add(new MySqlParameter("@TipoDeContrato", MySqlDbType.VarChar, oRegistroEN.TipoDeContrato.Trim().Length)).Value = oRegistroEN.TipoDeContrato.Trim();
                Comando.Parameters.Add(new MySqlParameter("@FechaDeInicio", MySqlDbType.Date)).Value = oRegistroEN.FechaDeInicio;
                Comando.Parameters.Add(new MySqlParameter("@FechaDeFin", MySqlDbType.Date)).Value = oRegistroEN.FechaDeFin;
                Comando.Parameters.Add(new MySqlParameter("@NumeroDeContrato", MySqlDbType.Int32)).Value = oRegistroEN.NumeroDeContrato;
                Comando.Parameters.Add(new MySqlParameter("@IdEmpleado", MySqlDbType.Int32)).Value = oRegistroEN.oEmpladoEN.IdEmpleado;

                Comando.ExecuteNonQuery();

                InicialisarAdaptador();

                return true;
            }
            catch(Exception ex)
            {
                this.Error = ex.Message;
                
                return false;
            }
            finally
            {
                FinalizarConexion();
            }
        }

        public bool Eliminar (ContratoEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            try
            {
                InicialisarVariablesGlovales(oDatos);

                Consultas = @"delete from contrato where IdContrato = @IdContrato";

                Comando.CommandText = Consultas;

                Comando.Parameters.Add(new MySqlParameter("@IdContrato", MySqlDbType.Int32)).Value = oRegistroEN.IdContrato;

                Comando.ExecuteNonQuery();

                InicialisarAdaptador();

                return true;
            }
            catch(Exception ex)
            {
                this.Error = ex.Message;
                return false;
            }
            finally
            {
                FinalizarConexion();
            }
        }

        public bool Listado(ContratoEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            try
            {
                InicialisarVariablesGlovales(oDatos);

                Consultas = string.Format(@"Select ctt.IdContrato, ctt.TipoDeContrato as 'Tipo De Contrato', ctt.FechaDeInicio, ctt.FechaDeFin, ctt.NumeroDeContrato as 'Numero De Contrato', ctt.IdEmpleado, emp.Nombre as 'Empleado' from contrato as ctt
									        inner join empleado as emp on emp.IdEmpleado = ctt.IdEmpleado
                                            where IdContrato > 0 {0} {1}", oRegistroEN.Where, oRegistroEN.OrderBy);

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

        public bool ListadoPorID(ContratoEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            try
            {
                InicialisarVariablesGlovales(oDatos);
                
                Consultas = string.Format(@"Select ctt.IdContrato, ctt.TipoDeContrato as 'Tipo De Contrato', ctt.FechaDeInicio, ctt.FechaDeFin, ctt.NumeroDeContrato as 'Numero De Contrato', ctt.IdEmpleado, emp.Nombre as 'Empleado' from contrato as ctt
									        inner join empleado as emp on emp.IdEmpleado = ctt.IdEmpleado
                                            where IdContrato > @IdContrato ", oRegistroEN.IdContrato);

                Comando.CommandText = Consultas;

                Comando.Parameters.Add(new MySqlParameter("@IdContrato", MySqlDbType.Int32)).Value = oRegistroEN.IdContrato;


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

        public bool ListadoParaCombos(ContratoEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                InicialisarVariablesGlovales(oDatos);

                Consultas = string.Format(@"select IdContrato, TipoDeContrato, FechaDeInicio, FechaDeFin, NumeroDeContrato, IdEmpleado from contrato where IdContrato > 0 {0} {1}; ", oRegistroEN.Where, oRegistroEN.OrderBy);
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

        public bool ListadoParaReportes(ContratoEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                InicialisarVariablesGlovales(oDatos);

                Consultas = string.Format(@"select IdContrato, TipoDeContrato, FechaDeInicio, FechaDeFin, NumeroDeContrato, IdEmpleado from contrato where IdContrato > 0 {0} {1} ", oRegistroEN.Where, oRegistroEN.OrderBy);
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
        private TransaccionesEN InformacionDelaTransaccion(ContratoEN oContrato, String TipoDeOperacion, String Descripcion, String Estado)
        {
            TransaccionesEN oRegistroEN = new TransaccionesEN();

            oRegistroEN.IdRegistro = oContrato.IdContrato;
            oRegistroEN.Modelo = "ContratoAD";
            //oRegistroEN.Modulo = "Clientes";
            oRegistroEN.Tabla = "Contrato";
            oRegistroEN.TipoDeOperacion = TipoDeOperacion;
            oRegistroEN.Estado = Estado;
            oRegistroEN.IP = oContrato.oLoginEN.NumeroIP;
            oRegistroEN.IdUsuario = oContrato.oLoginEN.IdUsuario;
            oRegistroEN.IdUsuarioAPrueva = oContrato.oLoginEN.IdUsuario;
            oRegistroEN.DescripcionDelUsuario = DescripcionDeLaOperacion;
            oRegistroEN.DescripcionInterna = Descripcion;
            oRegistroEN.nombredelequipo = oContrato.oLoginEN.NombreDelEquipo;

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
        private string InformacionDelRegistro(ContratoEN oRegistroEN)
        {
            string Cadena = @"IdContrato: {0}, TipoDeContrato: {1}, FechaDeInicio: {2}, FechaDeFin: {3}, NumeroDeContrato: {4}, IdEmpleado: {5}";
            Cadena = string.Format(Cadena, oRegistroEN.IdContrato, oRegistroEN.TipoDeContrato, oRegistroEN.FechaDeInicio, oRegistroEN.FechaDeFin, oRegistroEN.NumeroDeContrato, oRegistroEN.oEmpladoEN.IdEmpleado);
            Cadena = Cadena.Replace(",", Environment.NewLine);
            return Cadena;
        }
        #endregion

        #region "Funciones de Validación"

        public bool ValidarSiElRegistroEstaVinculado(ContratoEN oRegistroEN, DatosDeConexionEN oDatos, string TipoDeOperacion)
        {


            try
            {

                InicialisarVariablesGlobalesProcedure(oDatos);

                Comando.Parameters.Add(new MySqlParameter("@CampoABuscar_", MySqlDbType.VarChar, 200)).Value = "IdContrato";
                Comando.Parameters.Add(new MySqlParameter("@ValorCampoABuscar", MySqlDbType.Int32)).Value = oRegistroEN.IdContrato;
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

        public bool ValidarRegistroDuplicado(ContratoEN oRegistroEN, DatosDeConexionEN oDatos, string TipoDeOperacion)
        {

            try
            {

                InicialisarVariablesGlovales(oDatos);
                
                switch (TipoDeOperacion.Trim().ToUpper())
                {

                    case "AGREGAR":

                        Consultas = @"SELECT CASE WHEN EXISTS(Select IdContrato from contrato where IdEmpleado = @IdEmpleado) THEN 1 ELSE 0 END AS 'RES'";
                        Comando.Parameters.Add(new MySqlParameter("@IdEmpleado", MySqlDbType.Int32)).Value = oRegistroEN.oEmpladoEN.IdEmpleado;
                        
                        break;

                    case "ACTUALIZAR":

                        Consultas = @"SELECT CASE WHEN EXISTS(Select IdContrato from contrato where IdEmpleado = @IdEmpleado and IdContrato <> @IdContrato) THEN 1 ELSE 0 END AS 'RES'";
                        Comando.Parameters.Add(new MySqlParameter("@IdEmpleado", MySqlDbType.Int32)).Value = oRegistroEN.oEmpladoEN.IdEmpleado;
                        Comando.Parameters.Add(new MySqlParameter("@IdContrato", MySqlDbType.Int32)).Value = oRegistroEN.IdContrato;

                        break;

                    default:
                        throw new ArgumentException("La aperación solicitada no esta disponible");

                }
                Console.WriteLine("bUSCAR");
                Comando.CommandText = Consultas;
                
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
