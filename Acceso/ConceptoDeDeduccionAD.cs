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
    public class ConceptoDeDeduccionAD
    {
        public string Error { set; get; }
        private MySqlConnection Cnn = null;
        private MySqlCommand Comando = null;
        private MySqlDataAdapter Adaptador = null;
        private TransaccionesAD oTransaccionesAD = null;
        string Consultas;
        string DescripcionDeLaOperacion;
        private DataTable DT { set; get; }

        public ConceptoDeDeduccionAD()
        {

            oTransaccionesAD = new TransaccionesAD();
            oTransaccionesAD.Modulo = "General";
            oTransaccionesAD.Modelo = "ConceptoDeDeduccionAD";
            oTransaccionesAD.NombreDelEquipo = Environment.MachineName;
            oTransaccionesAD.FechaDeCreacion = System.DateTime.Now;
            oTransaccionesAD.Tabla = "ConceptoDeDeduccion";

        }

        #region "Funciones dll"
        public bool Agregar(ConceptoDeDeduccionEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            oTransaccionesAD = new TransaccionesAD();

            try
            {
                InicializarVariablesGlovales(oDatos);

                Consultas = @"insert into conceptodededuccion
                            (ConceptoDeDeduccion)
                            value
                            (@ConceptoDeDeduccion);

                            select last_insert_id() as 'ID';";

                Comando.CommandText = Consultas;

                Comando.Parameters.Add(new MySqlParameter("@ConceptoDeDeduccion", MySqlDbType.VarChar, oRegistroEN.ConceptoDeDeduccion.Trim().Length)).Value = oRegistroEN.ConceptoDeDeduccion.Trim();

                InicializarAdaptador();

                oRegistroEN.IdConceptoDeDeduccion = Convert.ToInt32(DT.Rows[0].ItemArray[0].ToString());

                DescripcionDeLaOperacion = string.Format("El registro fue insertado correctamente. {0} {1}", Environment.NewLine, InformacionDelRegistro(oRegistroEN));

                TransaccionesEN oTransacciones = InformacionDeLaTransaccion(oRegistroEN, "Agregar", "Agregar Nuevo Registro", "CORRECTO");
                oTransaccionesAD.Agregar(oTransacciones, oDatos);

                return true;
            }
            catch (Exception ex)
            {
                this.Error = ex.Message;
                DescripcionDeLaOperacion = string.Format("Se produjo el seguiente error: '{2}' al insertar el registro. {0} {1} ", Environment.NewLine, InformacionDelRegistro(oRegistroEN), ex.Message);

                //Agregamos la Transacción....
                TransaccionesEN oTransacciones = InformacionDeLaTransaccion(oRegistroEN, "Agregar", "Agregar Nuevo Registro", "ERROR");
                oTransaccionesAD.Agregar(oTransacciones, oDatos);

                return false;
            }
            finally
            {
                FinalizarConexion();
                oTransaccionesAD = null;
            }
        }

        public bool Actualizar(ConceptoDeDeduccionEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            oTransaccionesAD = new TransaccionesAD();

            try
            {
                InicializarVariablesGlovales(oDatos);

                Consultas = @"update conceptodededuccion set
                            ConceptoDeDeduccion = @ConceptoDeDeduccion
                            where IdConceptoDeDeduccion = @IdConceptoDeDeduccion;";

                Comando.CommandText = Consultas;

                Comando.Parameters.Add(new MySqlParameter("@IdConceptoDeDeduccion", MySqlDbType.Int32)).Value = oRegistroEN.IdConceptoDeDeduccion;
                Comando.Parameters.Add(new MySqlParameter("@ConceptoDeDeduccion", MySqlDbType.VarChar, oRegistroEN.ConceptoDeDeduccion.Trim().Length)).Value = oRegistroEN.ConceptoDeDeduccion.Trim();

                Comando.ExecuteNonQuery();

                DescripcionDeLaOperacion = string.Format("El registro fue Actualizado Correctamente. {0} {1}", Environment.NewLine, InformacionDelRegistro(oRegistroEN));

                //Agregamos la transaccion...
                TransaccionesEN oTransaccion = InformacionDeLaTransaccion(oRegistroEN, "Actualizar", "Actualizar Registro", "CORRECTO");
                oTransaccionesAD.Agregar(oTransaccion, oDatos);

                return true;
            }
            catch(Exception ex)
            {
                this.Error = ex.Message;

                DescripcionDeLaOperacion = string.Format("Se produjo el seguiente error: '{2}' al actualizar el registro. {0} {1} ", Environment.NewLine, InformacionDelRegistro(oRegistroEN), ex.Message);

                //Agregamos la Transacción....
                TransaccionesEN oTransaccion = InformacionDeLaTransaccion(oRegistroEN, "Actualizar", "Actualizar Registro", "ERROR");
                oTransaccionesAD.Agregar(oTransaccion, oDatos);

                return false;

            }
            finally
            {
                FinalizarConexion();
                oTransaccionesAD = null;
            }
        }
        
        public bool Eliminar(ConceptoDeDeduccionEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            oTransaccionesAD = new TransaccionesAD();
            try
            {
                InicializarVariablesGlovales(oDatos);

                Consultas = @"delete from conceptodededuccion where IdConceptoDeDeduccion = @IdConceptoDeDeduccion;";

                Comando.CommandText = Consultas;

                Comando.Parameters.Add(new MySqlParameter("@IdConceptoDeDeduccion", MySqlDbType.Int32)).Value = oRegistroEN.IdConceptoDeDeduccion;

                Comando.ExecuteNonQuery();

                DescripcionDeLaOperacion = string.Format("El registro fue eliminado correctamente. {0} {1}", Environment.NewLine, InformacionDelRegistro(oRegistroEN));

                //Agregamos la transaccion...
                TransaccionesEN oTransacciones = InformacionDeLaTransaccion(oRegistroEN, "Eliminar", "Elminar Registro", "CORRECTO");
                oTransaccionesAD.Agregar(oTransacciones, oDatos);

                return true;
            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                DescripcionDeLaOperacion = string.Format("Se produjo el siguiente error: '{2}' al actualizar el registro. {0} {1}", Environment.NewLine, InformacionDelRegistro(oRegistroEN), ex.Message);

                //Agregamos la transaccion...
                TransaccionesEN oTransaccion = InformacionDeLaTransaccion(oRegistroEN, "Actualizar", "Actualizar Registro", "ERROR");
                oTransaccionesAD.Agregar(oTransaccion, oDatos);

                return false;
            }
            finally
            {
                FinalizarConexion();
                oTransaccionesAD = null;
            }
        }

        public bool Listado(ConceptoDeDeduccionEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            try
            {
                InicializarVariablesGlovales(oDatos);

                Consultas = string.Format(@"Select IdConceptoDeDeduccion, ConceptoDeDeduccion from conceptodededuccion where IdConceptoDeDeduccion > 0 {0} {1} ", oRegistroEN.Where, oRegistroEN.OrderBy);
                Comando.CommandText = Consultas;

                InicializarAdaptador();

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

        public bool ListadoPorID(ConceptoDeDeduccionEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            try
            {
                InicializarVariablesGlovales(oDatos);

                Consultas = string.Format(@"Select IdConceptoDeDeduccion, ConceptoDeDeduccion from conceptodededuccion where IdConceptoDeDeduccion = @IdConceptoDeDeduccion ", oRegistroEN.IdConceptoDeDeduccion);

                Comando.Parameters.Add(new MySqlParameter("@IdConceptoDeDeduccion", MySqlDbType.Int32)).Value = oRegistroEN.IdConceptoDeDeduccion;

                Comando.CommandText = Consultas;

                InicializarAdaptador();

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

        public bool ListadoParaCombos(ConceptoDeDeduccionEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                InicializarVariablesGlovales(oDatos);

                Consultas = string.Format(@"select IdConceptoDeDeduccion, ConceptoDeDeduccion from conceptodededuccion where IdConceptoDeDeduccion > 0 {0} {1}; ", oRegistroEN.Where, oRegistroEN.OrderBy);
                Comando.CommandText = Consultas;

                InicializarAdaptador();

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

        public bool ListadoParaReportes(ConceptoDeDeduccionEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                InicializarVariablesGlovales(oDatos);

                Consultas = string.Format(@"select IdConceptoDeDeduccion, ConceptoDeDeduccion from conceptodededuccion where IdConceptoDeDeduccion > 0 {0} {1} ", oRegistroEN.Where, oRegistroEN.OrderBy);
                Comando.CommandText = Consultas;

                InicializarAdaptador();

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

        #region "Funciones de retorno"

        public DataTable TraerDatos()
        {
            return DT;
        }

        private void InicializarVariablesGlovales(DatosDeConexionEN oDatos)
        {
            Cnn = new MySqlConnection(TraerCadenaDeConexion(oDatos));
            Cnn.Open();

            Comando = new MySqlCommand();
            Comando.Connection = Cnn;
            Comando.CommandType = CommandType.Text;
        }
        private void InicializarAdaptador()
        {
            Adaptador = new MySqlDataAdapter();
            DT = new DataTable();

            Adaptador.SelectCommand = Comando;
            Adaptador.Fill(DT);
        }
        private string TraerCadenaDeConexion(DatosDeConexionEN oDatos)
        {
            string cadena = string.Format("Data Source='{0}';Initial Catalog='{1}';Persist Security Info=True;User ID='{2}';Password='{3}'", oDatos.Servidor, oDatos.BaseDeDatos, oDatos.Usuario, oDatos.Contrasena);
            return cadena;
        }
        private string InformacionDelRegistro(ConceptoDeDeduccionEN oRegistroEN)
        {
            string Cadena = @"IdConceptoDeDeduccion: {0}, ConceptoDeDeduccion: {1}";
            Cadena = string.Format(Cadena, oRegistroEN.IdConceptoDeDeduccion, oRegistroEN.ConceptoDeDeduccion);
            Cadena = Cadena.Replace(",", Environment.NewLine);
            return Cadena;
        }
        private TransaccionesEN InformacionDeLaTransaccion(ConceptoDeDeduccionEN oConceptoDeDeduccionEN, string TipoDeOperacion, string Descripcion, string Estado)
        {
            TransaccionesEN oRegistroEN = new TransaccionesEN();

            oRegistroEN.IdRegistro = oConceptoDeDeduccionEN.IdConceptoDeDeduccion;
            oRegistroEN.Modelo = "ConceptoDeDeduccionAD";
            oRegistroEN.Tabla = "ConceptoDeDeduccion";
            oRegistroEN.TipoDeOperacion = TipoDeOperacion;
            oRegistroEN.Estado = Estado;
            oRegistroEN.IP = oConceptoDeDeduccionEN.oLoginEN.NumeroIP;
            oRegistroEN.IdUsuario = oConceptoDeDeduccionEN.oLoginEN.IdUsuario;
            oRegistroEN.IdUsuarioAPrueva = oConceptoDeDeduccionEN.oLoginEN.IdUsuario;
            oRegistroEN.DescripcionDelUsuario = DescripcionDeLaOperacion;
            oRegistroEN.DescripcionInterna = Descripcion;
            oRegistroEN.nombredelequipo = oConceptoDeDeduccionEN.oLoginEN.NombreDelEquipo;

            return oRegistroEN;
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
        #endregion


        #region "Funciones del programador"

        public bool ValidarSiElRegistroEstaVinculado(ConceptoDeDeduccionEN oRegistroEN, DatosDeConexionEN oDatos, string TipoDeOperacion)
        {


            try
            {

                InicializarVariablesGlovales(oDatos);

                Comando.Parameters.Add(new MySqlParameter("@CampoABuscar_", MySqlDbType.VarChar, 200)).Value = "IdConceptoDeDeduccion";
                Comando.Parameters.Add(new MySqlParameter("@ValorCampoABuscar", MySqlDbType.Int32)).Value = oRegistroEN.IdConceptoDeDeduccion;
                Comando.Parameters.Add(new MySqlParameter("@ExcluirTabla_", MySqlDbType.VarChar, 200)).Value = string.Empty;

                InicializarAdaptador();

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

        #endregion

    }
}
