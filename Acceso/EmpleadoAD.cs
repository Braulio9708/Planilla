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
    public class EmpleadoAD
    {
        public string Error { set; get; }
        private MySqlConnection Cnn = null;
        private MySqlCommand Comando = null;
        private MySqlDataAdapter Adaptador = null;
        private TransaccionesAD oTransaccionesAD = null;
        string Consultas;
        string DescripcionDeLaOperacion;
        private DataTable DT { set; get; }

        public EmpleadoAD()
        {

            oTransaccionesAD = new TransaccionesAD();
            oTransaccionesAD.Modulo = "General";
            oTransaccionesAD.Modelo = "EmpleadoAD";
            oTransaccionesAD.NombreDelEquipo = Environment.MachineName;
            oTransaccionesAD.FechaDeCreacion = System.DateTime.Now;
            oTransaccionesAD.Tabla = "Empleado";

        }

        #region "Funciones dll"

        public bool Agregar(EmpleadoEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            oTransaccionesAD = new TransaccionesAD();
            try
            {
                InicialisarVariablesGlovales(oDatos);

                Consultas = @"insert into empleado
                            (Nombre, Apellidos, Cedula, Direccion, Telefono, 
                            Celular, Correo, IdCargo, IdMunicipio, IdAreaLaboral)
                            value
                            (@Nombre, @Apellidos, @Cedula, @Direccion, @Telefono, 
                            @Celular, @Correo, @IdCargo, @IdMunicipio, @IdAreaLaboral);

                            select last_insert_id() as 'ID';";

                Comando.CommandText = Consultas;

                Comando.Parameters.Add(new MySqlParameter("@Nombre", MySqlDbType.VarChar, oRegistroEN.Nombre.Trim().Length)).Value = oRegistroEN.Nombre.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Apellidos", MySqlDbType.VarChar, oRegistroEN.Apellidos.Trim().Length)).Value = oRegistroEN.Apellidos.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Cedula", MySqlDbType.VarChar, oRegistroEN.Cedula.Trim().Length)).Value = oRegistroEN.Cedula.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Direccion", MySqlDbType.VarChar, oRegistroEN.Direccion.Trim().Length)).Value = oRegistroEN.Direccion.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Telefono", MySqlDbType.VarChar, oRegistroEN.Telefono.Trim().Length)).Value = oRegistroEN.Telefono.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Celular", MySqlDbType.VarChar, oRegistroEN.Celular.Trim().Length)).Value = oRegistroEN.Celular.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Correo", MySqlDbType.VarChar, oRegistroEN.Correo.Trim().Length)).Value = oRegistroEN.Correo.Trim();
                Comando.Parameters.Add(new MySqlParameter("@IdCargo", MySqlDbType.Int32)).Value = oRegistroEN.oCargoEN.IdCargo;
                Comando.Parameters.Add(new MySqlParameter("@IdMunicipio", MySqlDbType.Int32)).Value = oRegistroEN.oMunicipioEN.IdMunicipio;
                Comando.Parameters.Add(new MySqlParameter("@IdAreaLaboral", MySqlDbType.Int32)).Value = oRegistroEN.oAreaLaboralEN.IdAreaLaboral;

                InicialisarAdaptador();

                oRegistroEN.IdEmpleado = Convert.ToInt32(DT.Rows[0].ItemArray[0].ToString());

                DescripcionDeLaOperacion = string.Format("El registro fue Insertado Correctamente. {0} {1}", Environment.NewLine, InformacionDelRegistro(oRegistroEN));

                //agregamos la transaccion
                TransaccionesEN oTransacciones = InformacionDeLaTransaccion(oRegistroEN, "Agregar", "Agregar Nuevo Registro", "CORRECTO");
                oTransaccionesAD.Agregar(oTransacciones, oDatos);

                return true;
            }
            catch(Exception ex)
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

        public bool Actualizar(EmpleadoEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            oTransaccionesAD = new TransaccionesAD();

            try
            {
                InicialisarVariablesGlovales(oDatos);

                Consultas = @"update empleado set
                            Nombre = @Nombre, 
                            Apellidos = @Apellidos, 
                            Cedula = @Cedula, 
                            Direccion = @Direccion, 
                            Telefono = @Telefono, 
                            Celular = @Celular, 
                            Correo = @Correo, 
                            IdCargo = @IdCargo, 
                            IdMunicipio = @IdMunicipio, 
                            IdAreaLaboral = @IdAreaLaboral
                            where IdEmpleado = @IdEmpleado;";

                Comando.CommandText = Consultas;

                Comando.Parameters.Add(new MySqlParameter("@Nombre", MySqlDbType.VarChar, oRegistroEN.Nombre.Trim().Length)).Value = oRegistroEN.Nombre.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Apellidos", MySqlDbType.VarChar, oRegistroEN.Apellidos.Trim().Length)).Value = oRegistroEN.Apellidos.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Cedula", MySqlDbType.VarChar, oRegistroEN.Cedula.Trim().Length)).Value = oRegistroEN.Cedula.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Direccion", MySqlDbType.VarChar, oRegistroEN.Direccion.Trim().Length)).Value = oRegistroEN.Direccion.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Telefono", MySqlDbType.VarChar, oRegistroEN.Telefono.Trim().Length)).Value = oRegistroEN.Telefono.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Celular", MySqlDbType.VarChar, oRegistroEN.Celular.Trim().Length)).Value = oRegistroEN.Celular.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Correo", MySqlDbType.VarChar, oRegistroEN.Correo.Trim().Length)).Value = oRegistroEN.Correo.Trim();
                Comando.Parameters.Add(new MySqlParameter("@IdCargo", MySqlDbType.Int32)).Value = oRegistroEN.oCargoEN.IdCargo;
                Comando.Parameters.Add(new MySqlParameter("@IdMunicipio", MySqlDbType.Int32)).Value = oRegistroEN.oMunicipioEN.IdMunicipio;
                Comando.Parameters.Add(new MySqlParameter("@IdAreaLaboral", MySqlDbType.Int32)).Value = oRegistroEN.oAreaLaboralEN.IdAreaLaboral;

                Comando.ExecuteNonQuery();

                DescripcionDeLaOperacion = string.Format("El registro fue Actualizado Correctamente. {0} {1}", Environment.NewLine, InformacionDelRegistro(oRegistroEN));

                //Agregamos la Transacción....
                TransaccionesEN oTransacciones = InformacionDeLaTransaccion(oRegistroEN, "Actualizar", "Actualizar Registro", "CORRECTO");
                oTransaccionesAD.Agregar(oTransacciones, oDatos);

                return true;

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                DescripcionDeLaOperacion = string.Format("Se produjo el seguiente error: '{2}' al actualizar el registro. {0} {1} ", Environment.NewLine, InformacionDelRegistro(oRegistroEN), ex.Message);

                //Agregamos la Transacción....
                TransaccionesEN oTransacciones = InformacionDeLaTransaccion(oRegistroEN, "Actualizar", "Actualizar Registro", "ERROR");
                oTransaccionesAD.Agregar(oTransacciones, oDatos);

                return false;
            }
            finally
            {
                FinalizarConexion();
                oTransaccionesAD = null;
            }
        }

        public bool Eliminar(EmpleadoEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            oTransaccionesAD = new TransaccionesAD();

            try
            {

                InicialisarVariablesGlovales(oDatos);

                Consultas = @"Delete from Empleado where IdEmpleado = @IdEmpleado;";
                Comando.CommandText = Consultas;

                Comando.Parameters.Add(new MySqlParameter("@IdEmpleado", MySqlDbType.Int32)).Value = oRegistroEN.IdEmpleado;

                Comando.ExecuteNonQuery();

                DescripcionDeLaOperacion = string.Format("El registro fue Eliminado Correctamente. {0} {1}", Environment.NewLine, InformacionDelRegistro(oRegistroEN));

                //Agregamos la Transacción....
                TransaccionesEN oTransacciones = InformacionDeLaTransaccion(oRegistroEN, "Eliminar", "Elminar Registro", "CORRECTO");
                oTransaccionesAD.Agregar(oTransacciones, oDatos);

                return true;

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                DescripcionDeLaOperacion = string.Format("Se produjo el seguiente error: '{2}' al eliminar el registro. {0} {1} ", Environment.NewLine, InformacionDelRegistro(oRegistroEN), ex.Message);

                //Agregamos la Transacción....
                TransaccionesEN oTransacciones = InformacionDeLaTransaccion(oRegistroEN, "Eliminar", "Eliminar Registro", "ERROR");
                oTransaccionesAD.Agregar(oTransacciones, oDatos);

                return false;
            }
            finally
            {
                FinalizarConexion();
                oTransaccionesAD = null;
            }

        }

        public bool Listado(EmpleadoEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            try
            {
                InicialisarVariablesGlovales(oDatos);

                Consultas = string.Format(@"Select emp.IdEmpleado, emp.IdCargo, emp.IdMunicipio, emp.IdAreaLaboral,
				                            emp.Nombre, emp.Apellidos, emp.Cedula, 
                                            emp.Direccion, emp.Telefono, emp.Celular, 
                                            emp.Correo,  dol.Area as 'AreaLaboral', 
                                            co.Cargo as 'Cargo', cd.Municipio as 'Municipio'                
                                            From Empleado as emp
                                            inner join AreaLaboral as dol on dol.IdAreaLaboral = emp.IdAreaLaboral
                                            inner join Cargo as co on co.IdCargo = emp.IdCargo
                                            inner join Municipio as cd on cd.IdMunicipio = emp.IdMunicipio
                                            Where emp.idEmpleado > 0  {0} {1} ", oRegistroEN.Where, oRegistroEN.OrderBy);

                Comando.CommandText = Consultas;

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

        public bool ListadoPorIdentificador(EmpleadoEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            try
            {
                InicialisarVariablesGlovales(oDatos);

                Consultas = string.Format(@"Select emp.Nombre, emp.Apellidos, emp.Cedula, 
                emp.Direccion, emp.Telefono, emp.Celular, 
                emp.Correo,emp.IdCargo, emp.IdMunicipio, emp.IdAreaLaboral,dol.Area as 'AreaLaboral', 
                co.Cargo as 'Cargo', cd.Municipio as 'Municipio'
                From Empleado as emp
                inner join AreaLaboral as dol on dol.IdAreaLaboral = emp.IdAreaLaboral
                inner join Cargo as co on co.IdCargo = emp.IdCargo
                inner join Municipio as cd on cd.IdMunicipio = emp.IdMunicipio
                Where emp.idEmpleado = {0}", oRegistroEN.IdEmpleado);

                Comando.CommandText = Consultas;

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

        public bool ListadoParaCombos(EmpleadoEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                InicialisarVariablesGlovales(oDatos);

                Consultas = string.Format(@"select IdEmpleado, Nombre, Apellidos, Cedula, Direccion, Telefono, Celular, Correo, IdCargo, IdMunicipio, IdAreaLaboral from empleado where IdEmpleado > 0 {0} {1}; ", oRegistroEN.Where, oRegistroEN.OrderBy);
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

        public bool ListadoParaReportes(EmpleadoEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                InicialisarVariablesGlovales(oDatos);

                Consultas = string.Format(@"select IdEmpleado, Nombre, Apellidos, Cedula, Direccion, Telefono, Celular, Correo, IdCargo, IdMunicipio, IdAreaLaboral from empleado where IdEmpleado > 0 {0} {1} ", oRegistroEN.Where, oRegistroEN.OrderBy);
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

        #region "Funciones de retorno"

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

        private TransaccionesEN InformacionDeLaTransaccion(EmpleadoEN oEmpleadoEN, string TipoDeOperacion, string Descripcion, string Estado)
        {
            TransaccionesEN oRegistroEN = new TransaccionesEN();

            oRegistroEN.IdRegistro = oEmpleadoEN.IdEmpleado;
            oRegistroEN.Modelo = "EmpleadoAD";
            oRegistroEN.Tabla = "Empleado";
            oRegistroEN.TipoDeOperacion = TipoDeOperacion;
            oRegistroEN.Estado = Estado;
            oRegistroEN.IP = oEmpleadoEN.oLoginEN.NumeroIP;
            oRegistroEN.IdUsuario = oEmpleadoEN.oLoginEN.IdUsuario;
            oRegistroEN.IdUsuarioAPrueva = oEmpleadoEN.oLoginEN.IdUsuario;
            oRegistroEN.DescripcionDelUsuario = DescripcionDeLaOperacion;
            oRegistroEN.DescripcionInterna = Descripcion;
            oRegistroEN.nombredelequipo = oEmpleadoEN.oLoginEN.NombreDelEquipo;

            return oRegistroEN;
        }

        private string InformacionDelRegistro(EmpleadoEN oRegistroEN)
        {
            string Cadena= @"IdEmpleado={0}, IdAreaLaboral={1}, IdCargo={2}, IdMunicipio={3}, Nombre={4}, Apellidos={5}, Cedula={6}, Direccion={7}, Telefono={8}, Celular={9}, Correo={10}";
            Cadena = string.Format(Cadena, oRegistroEN.IdEmpleado, oRegistroEN.oAreaLaboralEN.IdAreaLaboral, oRegistroEN.oCargoEN.IdCargo,
                oRegistroEN.oMunicipioEN.IdMunicipio, oRegistroEN.Nombre, oRegistroEN.Apellidos, oRegistroEN.Cedula, oRegistroEN.Direccion, oRegistroEN.Telefono, oRegistroEN.Celular, oRegistroEN.Correo);
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

        #region "Funciones de Validación"

        public bool ValidarSiElRegistroEstaVinculado(EmpleadoEN oRegistroEN, DatosDeConexionEN oDatos, string TipoDeOperacion)
        {
            oTransaccionesAD = new TransaccionesAD();

            try
            {

                InicialisarVariablesGlobalesProcedure(oDatos);
                Comando.CommandText = "ValidarSiElRegistroEstaVinculado";

                Comando.Parameters.Add(new MySqlParameter("@CampoABuscar_", MySqlDbType.VarChar, 200)).Value = "IdEmpleado";
                Comando.Parameters.Add(new MySqlParameter("@ValorCampoABuscar", MySqlDbType.Int32)).Value = oRegistroEN.IdEmpleado;
                Comando.Parameters.Add(new MySqlParameter("@ExcluirTabla_", MySqlDbType.VarChar, 200)).Value = string.Empty;

                InicialisarAdaptador();

                if (DT.Rows[0].ItemArray[0].ToString().ToUpper() == "NINGUNA".ToUpper())
                {
                    return false;
                }
                else
                {

                    this.Error = String.Format("La Operación: '{1}', {0} no se puede completar por que el registro: {0} '{2}', {0} se encuentra asociado con: {0} {3}", Environment.NewLine, TipoDeOperacion, InformacionDelRegistro(oRegistroEN));
                    DescripcionDeLaOperacion = this.Error;

                    //Agregamos la Transacción....
                    TransaccionesEN oTransacciones = InformacionDeLaTransaccion(oRegistroEN, "VALIDAR", "VALIDAR SI EL REGISTRO ESTA VINCULADO", "CORRECTO");
                    oTransaccionesAD.Agregar(oTransacciones, oDatos);

                    return true;
                }

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;
                DescripcionDeLaOperacion = string.Format("Se produjo el seguiente error: '{2}' al validar el registro. {0} {1} ", Environment.NewLine, InformacionDelRegistro(oRegistroEN), ex.Message);

                //Agregamos la Transacción....
                TransaccionesEN oTransacciones = InformacionDeLaTransaccion(oRegistroEN, "VALIDAR", "VALIDAR SI EL REGISTRO ESTA VINCULADO", "ERROR");
                oTransaccionesAD.Agregar(oTransacciones, oDatos);

                return false;
            }
            finally
            {

                FinalizarConexion();
                oTransaccionesAD = null;

            }

        }        

        #endregion
    }
}
