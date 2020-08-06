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
    public class DeduccionesAD
    {

        public string Error { set; get; }
        private MySqlConnection Cnn = null;
        private MySqlCommand Comando = null;
        private MySqlDataAdapter Adaptador = null;
        private TransaccionesAD oTransaccionesAD = null;
        string Consultas;
        string DescripcionDeLaOperacion;
        private DataTable DT { set; get; }

        public DeduccionesAD()
        {

            oTransaccionesAD = new TransaccionesAD();
            oTransaccionesAD.Modulo = "General";
            oTransaccionesAD.Modelo = "DeduccionesAD";
            oTransaccionesAD.NombreDelEquipo = Environment.MachineName;
            oTransaccionesAD.FechaDeCreacion = System.DateTime.Now;
            oTransaccionesAD.Tabla = "Deducciones";

        }

        #region "Funciones dll"

        public bool Agregar(DeduccionesEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            oTransaccionesAD = new TransaccionesAD();
            try
            {
                InicialisarVariablesGlovales(oDatos);
                Consultas = @"insert into deducciones
                            (INSS, IR, Prestamos, TotalDeduccines, IdDetalleDeDeducciones)
                            values
                            (@INSS, @IR, @Prestamos, @TotalDeduccines, @IdDetalleDeDeducciones);
                            Select  last_insert_ID() as 'ID';
                            ";

                Comando.Parameters.Add(new MySqlParameter("@INSS", MySqlDbType.Decimal)).Value = oRegistroEN.INSS;
                Comando.Parameters.Add(new MySqlParameter("@IR", MySqlDbType.Decimal)).Value = oRegistroEN.IR;
                Comando.Parameters.Add(new MySqlParameter("@Prestamos", MySqlDbType.Decimal)).Value = oRegistroEN.Prestamos;
                Comando.Parameters.Add(new MySqlParameter("@TotalDeduccines", MySqlDbType.Decimal)).Value = oRegistroEN.TotalDeDeducciones;
                Comando.Parameters.Add(new MySqlParameter("@IdDetalleDeDeducciones", MySqlDbType.Int32)).Value = oRegistroEN.oDetalleDeDeduccionesEN.IdDetalleDeDeducciones;

                InicialisarAdaptador();

                oRegistroEN.IdDeducciones = Convert.ToInt32(DT.Rows[0].ItemArray[0].ToString());

                DescripcionDeLaOperacion = string.Format("El registro se ha insertado correctamente. {0} {1}", Environment.NewLine, InformacionDelRegistro(oRegistroEN));

                TransaccionesEN oTransacciones = InformacionDelaTransaccion(oRegistroEN, "Agregar", "Agregar Nuevo Registro", "CORRECTO");
                oTransaccionesAD.Agregar(oTransacciones, oDatos);

                return true;
            }
            catch(Exception ex)
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

        public bool Actualizar(DeduccionesEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            oTransaccionesAD = new TransaccionesAD();
            try
            {
                InicialisarVariablesGlovales(oDatos);

                Consultas = @"update Deducciones set 
	
                            INSS = @INSS,
                            IR = @IR,
                            Prestamos = @Prestamos,
                            TotalDeduccines = @TotalDeduccines,
                            IdDetalleDeDeducciones = @IdDetalleDeDeducciones

                            where IdDeducciones = @IdDeducciones;";

                Comando.Parameters.Add(new MySqlParameter("@IdDeducciones", MySqlDbType.Int32)).Value = oRegistroEN.IdDeducciones;
                Comando.Parameters.Add(new MySqlParameter("@INSS", MySqlDbType.Decimal)).Value = oRegistroEN.INSS;
                Comando.Parameters.Add(new MySqlParameter("@IR", MySqlDbType.Decimal)).Value = oRegistroEN.IR;
                Comando.Parameters.Add(new MySqlParameter("@Prestamos", MySqlDbType.Decimal)).Value = oRegistroEN.Prestamos;
                Comando.Parameters.Add(new MySqlParameter("@TotalDeduccines", MySqlDbType.Decimal)).Value = oRegistroEN.TotalDeDeducciones;
                Comando.Parameters.Add(new MySqlParameter("@IdDetalleDeDeducciones", MySqlDbType.Int32)).Value = oRegistroEN.oDetalleDeDeduccionesEN.IdDetalleDeDeducciones;

                Comando.ExecuteNonQuery();

                DescripcionDeLaOperacion = string.Format("El registro fue Actualizado correctamente. {0} {1}", Environment.NewLine, InformacionDelRegistro(oRegistroEN));

                TransaccionesEN oTransacciones = InformacionDelaTransaccion(oRegistroEN, "Actualizar", "Actualizar Registro", "CORRECTO");
                oTransaccionesAD.Agregar(oTransacciones, oDatos);

                return true;

            }
            catch(Exception ex)
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

        public bool Eliminar(DeduccionesEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            oTransaccionesAD = new TransaccionesAD();
            try
            {
                InicialisarVariablesGlovales(oDatos);

                Consultas = @"delete from deducciones where IdDeducciones = @IdDeducciones;";

                Comando.Parameters.Add(new MySqlParameter("@IdDeducciones", MySqlDbType.Int32)).Value = oRegistroEN.IdDeducciones;

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

        public bool Listado(DeduccionesEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            try
            {
                InicialisarVariablesGlovales(oDatos);

                Consultas = string.Format(@"Select IdDeducciones, INSS, IR, Prestamos, TotalDeduccines, IdDetalleDeDeducciones from deducciones where IdDeducciones > 0 {0} {1}", oRegistroEN.Where, oRegistroEN.OrderBy);

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

        public bool ListadoPorID(DeduccionesEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            try
            {
                InicialisarVariablesGlovales(oDatos);

                Consultas = string.Format(@"Select IdDeducciones, INSS, IR, Prestamos, TotalDeduccines, IdDetalleDeDeducciones from deducciones where IdDeducciones > {0} ", oRegistroEN.IdDeducciones);
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

        public bool ListadoParaCombos(DeduccionesEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                InicialisarVariablesGlovales(oDatos);

                Consultas = string.Format(@"select IdDeducciones, INSS, IR, Prestamos, TotalDeduccines, IdDetalleDeDeducciones from deducciones where IdDeducciones > 0 {0} {1}; ", oRegistroEN.Where, oRegistroEN.OrderBy);
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

        public bool ListadoParaReportes(DeduccionesEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                InicialisarVariablesGlovales(oDatos);

                Consultas = string.Format(@"select IdDeducciones, INSS, IR, Prestamos, TotalDeduccines, IdDetalleDeDeducciones from deducciones where IdDeducciones > 0 {0} {1} ", oRegistroEN.Where, oRegistroEN.OrderBy);
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

        private TransaccionesEN InformacionDelaTransaccion(DeduccionesEN oDeducciones, String TipoDeOperacion, String Descripcion, String Estado)
        {
            TransaccionesEN oRegistroEN = new TransaccionesEN();

            oRegistroEN.IdRegistro = oDeducciones.IdDeducciones;
            oRegistroEN.Modelo = "DeduccionesAD";
            //oRegistroEN.Modulo = "Clientes";
            oRegistroEN.Tabla = "Deducciones";
            oRegistroEN.TipoDeOperacion = TipoDeOperacion;
            oRegistroEN.Estado = Estado;
            oRegistroEN.IP = oDeducciones.oLoginEN.NumeroIP;
            oRegistroEN.IdUsuario = oDeducciones.oLoginEN.IdUsuario;
            oRegistroEN.IdUsuarioAPrueva = oDeducciones.oLoginEN.IdUsuario;
            oRegistroEN.DescripcionDelUsuario = DescripcionDeLaOperacion;
            oRegistroEN.DescripcionInterna = Descripcion;
            oRegistroEN.nombredelequipo = oDeducciones.oLoginEN.NombreDelEquipo;

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
        private string InformacionDelRegistro(DeduccionesEN oRegistroEN)
        {
            string Cadena = @"IdDeducciones: {0}, INSS: {1}, IR: {2}, Prestamos: {3}, TOtalDeDeducciones: {4}, IdDetalleDeDeducciones: {5}";
            Cadena = string.Format(Cadena, oRegistroEN.IdDeducciones, oRegistroEN.INSS, oRegistroEN.IR, oRegistroEN.Prestamos, oRegistroEN.TotalDeDeducciones, oRegistroEN.oDetalleDeDeduccionesEN.IdDetalleDeDeducciones);
            Cadena = Cadena.Replace(",", Environment.NewLine);
            return Cadena;
        }

        
        #endregion

    }
}
