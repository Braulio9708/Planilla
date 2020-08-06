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
    class DetalleDeDeduccionesAD
    {
        public string Error { set; get; }
        private MySqlConnection Cnn = null;
        private MySqlCommand Comando = null;
        private MySqlDataAdapter Adaptador = null;
        private TransaccionesAD oTransaccionesAD = null;
        string Consultas;
        string DescripcionDeLaOperacion;
        private DataTable DT { set; get; }

        public DetalleDeDeduccionesAD()
        {

            oTransaccionesAD = new TransaccionesAD();
            oTransaccionesAD.Modulo = "General";
            oTransaccionesAD.Modelo = "DetalleDeDeduccionesAD";
            oTransaccionesAD.NombreDelEquipo = Environment.MachineName;
            oTransaccionesAD.FechaDeCreacion = System.DateTime.Now;
            oTransaccionesAD.Tabla = "DetalleDeDeducciones";

        }

        #region "Funciones dll"
        public bool Agregar(DetalleDeDeduccionesEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            oTransaccionesAD = new TransaccionesAD();
            try
            {
                InicialisarVariablesGlovales(oDatos);

                Consultas = @"insert into detalledededucciones 
				            (Cuota, MontoPorCuota, IdConceptoDeDeduccion) 
                            values 
                            (@Cuota, @MontoPorCuota, @IdConceptoDeDeduccion);
                                    Select  last_insert_ID() as 'ID';";

                Comando.Parameters.Add(new MySqlParameter("@Cuota", MySqlDbType.Decimal)).Value = oRegistroEN.Cuota;
                Comando.Parameters.Add(new MySqlParameter("@MontoPorCuota", MySqlDbType.Decimal)).Value = oRegistroEN.MontoPorCuota;
                Comando.Parameters.Add(new MySqlParameter("@IdConceptoDeDeduccion", MySqlDbType.Int32)).Value = oRegistroEN.oConceptoDeDeduccionEN.IdConceptoDeDeduccion;
                

                InicialisarAdaptador();

                oRegistroEN.IdDetalleDeDeducciones = Convert.ToInt32(DT.Rows[0].ItemArray[0].ToString());

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

        public bool Actualizar(DetalleDeDeduccionesEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            oTransaccionesAD = new TransaccionesAD();
            try
            {
                InicialisarVariablesGlovales(oDatos);

                Consultas = @"update detalledededucciones set 
	
                            Cuota = @Cuota,
                            MontoPorCuota = @MontoPorCuota,
                            IdConceptoDeDeduccion = @IdConceptoDeDeduccion
                            
                            where IdDetalleDeDeducciones = @IdDetalleDeDeducciones; ";

                Comando.Parameters.Add(new MySqlParameter("@Cuota", MySqlDbType.Decimal)).Value = oRegistroEN.Cuota;
                Comando.Parameters.Add(new MySqlParameter("@MontoPorCuota", MySqlDbType.Decimal)).Value = oRegistroEN.MontoPorCuota;
                Comando.Parameters.Add(new MySqlParameter("@IdConceptoDeDeduccion", MySqlDbType.Int32)).Value = oRegistroEN.oConceptoDeDeduccionEN.IdConceptoDeDeduccion;
                
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

        public bool Eliminar(DetalleDeDeduccionesEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            oTransaccionesAD = new TransaccionesAD();

            try
            {
                InicialisarVariablesGlovales(oDatos);

                Consultas = @"delete from detalledededucciones where IdDetalleDeDeducciones = @IdDetalleDeDeducciones;";

                Comando.Parameters.Add(new MySqlParameter("@IdDetalleDeDeducciones", MySqlDbType.Int32)).Value = oRegistroEN.IdDetalleDeDeducciones;

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

        public bool Listado(DetalleDeDeduccionesEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            try
            {
                InicialisarVariablesGlovales(oDatos);

                Consultas = string.Format(@"Select IdDetalleDeDeducciones, Cuota, MontoPorCuota, IdConceptoDeDeduccion from detalledededucciones where IdDetalleDeDeducciones = 0 {0} {1}", oRegistroEN.Where, oRegistroEN.OrderBy);

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

        public bool ListadoPorID(DetalleDeDeduccionesEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            try
            {
                InicialisarVariablesGlovales(oDatos);

                Consultas = string.Format(@"Select IdDetalleDeDeducciones, Cuota, MontoPorCuota, IdConceptoDeDeduccion from detalledededucciones where IdDetalleDeDeducciones = {0} ", oRegistroEN.IdDetalleDeDeducciones);
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

        public bool ListadoParaCombos(DetalleDeDeduccionesEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                InicialisarVariablesGlovales(oDatos);

                Consultas = string.Format(@"select IdDetalleDeDeducciones, Cuotas, MontoPorCuota, IdConceptoDeDeduccion from detalledededucciones where IdDetalleDeDeducciones > 0 {0} {1}; ", oRegistroEN.Where, oRegistroEN.OrderBy);
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

        public bool ListadoParaReportes(DetalleDeDeduccionesEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                InicialisarVariablesGlovales(oDatos);

                Consultas = string.Format(@"select IdDetalleDeDeducciones, Cuotas, MontoPorCuota, IdConceptoDeDeduccion from detalledededucciones where IdDetalleDeDeducciones > 0 {0} {1} ", oRegistroEN.Where, oRegistroEN.OrderBy);
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
        private TransaccionesEN InformacionDelaTransaccion(DetalleDeDeduccionesEN oDetalleDeDeducciones, String TipoDeOperacion, String Descripcion, String Estado)
        {
            TransaccionesEN oRegistroEN = new TransaccionesEN();

            oRegistroEN.IdRegistro = oDetalleDeDeducciones.IdDetalleDeDeducciones;
            oRegistroEN.Modelo = "DetalleDeDeduccionesAD";
            //oRegistroEN.Modulo = "Clientes";
            oRegistroEN.Tabla = "DetalleDeDeducciones";
            oRegistroEN.TipoDeOperacion = TipoDeOperacion;
            oRegistroEN.Estado = Estado;
            oRegistroEN.IP = oDetalleDeDeducciones.oLoginEN.NumeroIP;
            oRegistroEN.IdUsuario = oDetalleDeDeducciones.oLoginEN.IdUsuario;
            oRegistroEN.IdUsuarioAPrueva = oDetalleDeDeducciones.oLoginEN.IdUsuario;
            oRegistroEN.DescripcionDelUsuario = DescripcionDeLaOperacion;
            oRegistroEN.DescripcionInterna = Descripcion;
            oRegistroEN.nombredelequipo = oDetalleDeDeducciones.oLoginEN.NombreDelEquipo;

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
        private string InformacionDelRegistro(DetalleDeDeduccionesEN oRegistroEN)
        {
            string Cadena = @"IdDetalleDeDeducciones: {0}, Cuota: {1}, MontoPorCuota: {2}, IdConceptoDeDeduccion:{3}";
            Cadena = string.Format(Cadena, oRegistroEN.IdDetalleDeDeducciones, oRegistroEN.Cuota, oRegistroEN.MontoPorCuota, oRegistroEN.oConceptoDeDeduccionEN.IdConceptoDeDeduccion);
            Cadena = Cadena.Replace(",", Environment.NewLine);
            return Cadena;
        }
        #endregion

    }
}
