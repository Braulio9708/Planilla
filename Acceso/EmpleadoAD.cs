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
                            Celular, Correo, IdCargo, IdMunicipio, IdAreaLaboral, NoINSS)
                            value
                            (@Nombre, @Apellidos, @Cedula, @Direccion, @Telefono, 
                            @Celular, @Correo, @IdCargo, @IdMunicipio, @IdAreaLaboral, @NoINSS);

                            select last_insert_id() as 'ID';";

                Comando.CommandText = Consultas;

                Comando.Parameters.Add(new MySqlParameter("@Nombre", MySqlDbType.VarChar, oRegistroEN.Nombre.Trim().Length)).Value = oRegistroEN.Nombre.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Apellidos", MySqlDbType.VarChar, oRegistroEN.Apellidos.Trim().Length)).Value = oRegistroEN.Apellidos.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Cedula", MySqlDbType.VarChar, oRegistroEN.Cedula.Trim().Length)).Value = oRegistroEN.Cedula.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Direccion", MySqlDbType.VarChar, oRegistroEN.Direccion.Trim().Length)).Value = oRegistroEN.Direccion.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Telefono", MySqlDbType.VarChar, oRegistroEN.Telefono.Trim().Length)).Value = oRegistroEN.Telefono.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Celular", MySqlDbType.VarChar, oRegistroEN.Celular.Trim().Length)).Value = oRegistroEN.Celular.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Correo", MySqlDbType.VarChar, oRegistroEN.Correo.Trim().Length)).Value = oRegistroEN.Correo.Trim();
                Comando.Parameters.Add(new MySqlParameter("@NoINSS", MySqlDbType.VarChar, oRegistroEN.NoINSS.Trim().Length)).Value = oRegistroEN.NoINSS.Trim();
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
                            NoINSS = @NoINSS,
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
                Comando.Parameters.Add(new MySqlParameter("@NoINSS", MySqlDbType.VarChar, oRegistroEN.NoINSS.Trim().Length)).Value = oRegistroEN.NoINSS.Trim();
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
                
                Consultas = string.Format(@"select emp.IdEmpleado, emp.Nombre, emp.Apellidos, emp.Cedula, emp.Direccion, emp.Telefono, emp.Celular, emp.Correo, emp.NoINSS,
								emp.IdCargo, emp.IdMunicipio, emp.IdAreaLaboral, al.Area as 'AreaLaboral', co.Cargo as 'Cargo', mpo.Municipio as 'Municipio'
                                from empleado as emp
                                inner join cargo as co on emp.IdCargo = co.IdCargo
                                inner join arealaboral as al on emp.IdAreaLaboral = al.IdAreaLaboral
                                inner join municipio as mpo on emp.IdMunicipio = mpo.IdMunicipio
                                where emp.IdEmpleado > 0 {0} {1} ", oRegistroEN.Where, oRegistroEN.OrderBy);

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

                Consultas = string.Format(@"select emp.idempleado, emp.Nombre, emp.Apellidos, emp.Cedula, emp.Direccion, emp.Telefono, emp.Celular, emp.Correo, emp.NoINSS,
								emp.idCargo, emp.idMunicipio, emp.idAreaLaboral, al.Area as 'AreaLaboral', co.Cargo as 'Cargo', mpo.Municipio as 'Municipio'
                                from empleado as emp
                                inner join cargo as co on emp.idCargo = co.idCargo
                                inner join arealaboral as al on emp.idAreaLaboral = al.idAreaLaboral
                                inner join municipio as mpo on emp.idMunicipio = mpo.idMunicipio
                                where emp.idEmpleado > {0}", oRegistroEN.IdEmpleado);

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

                Consultas = string.Format(@"select emp.idempleado, emp.Nombre, emp.Apellidos, emp.Cedula, emp.Direccion, emp.Telefono, emp.Celular, emp.Correo, emp.NoINSS,
								emp.idCargo, emp.idMunicipio, emp.idAreaLaboral, al.Area as 'AreaLaboral', co.Cargo as 'Cargo', mpo.Municipio as 'Municipio'
                                from empleado as emp
                                inner join cargo as co on emp.idCargo = co.idCargo
                                inner join arealaboral as al on emp.idAreaLaboral = al.idAreaLaboral
                                inner join municipio as mpo on emp.idMunicipio = mpo.idMunicipio
                                where emp.idEmpleado > 0 {0} {1}; ", oRegistroEN.Where, oRegistroEN.OrderBy);
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

                Consultas = string.Format(@"select IdEmpleado, Nombre, Apellidos, Cedula, Direccion, Telefono, Celular, Correo, NoINSS, IdCargo, IdMunicipio, IdAreaLaboral from empleado where IdEmpleado > 0 {0} {1} ", oRegistroEN.Where, oRegistroEN.OrderBy);
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
            string Cadena= @"IdEmpleado={0}, Nombre={2}, Apellidos={3}, Cedula={4}, Direccion={5}, Telefono={6}, Celular={7}, Correo={8}, NoINSS={9}, IdCargo={10}, IdMunicipio={11}, IdAreaLaboral={12}, Area={13}, Cargo={14}, Municipio{15}";
            Cadena = string.Format(Cadena, oRegistroEN.IdEmpleado, oRegistroEN.Nombre, oRegistroEN.Apellidos, oRegistroEN.Cedula, oRegistroEN.Direccion, oRegistroEN.Telefono, oRegistroEN.Celular, oRegistroEN.Correo, oRegistroEN.NoINSS, oRegistroEN.oCargoEN.IdCargo, oRegistroEN.oMunicipioEN.IdMunicipio,
                oRegistroEN.oAreaLaboralEN.IdAreaLaboral, oRegistroEN.oAreaLaboralEN.Area, oRegistroEN.oCargoEN.Cargo, oRegistroEN.oMunicipioEN.Municipio);
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

        public bool ValidarRegistroDuplicado(EmpleadoEN oRegistroEN, DatosDeConexionEN oDatos, string TipoDeOperacion)
        {
            oTransaccionesAD = new TransaccionesAD();

            try
            {

                InicialisarVariablesGlovales(oDatos);

                switch (TipoDeOperacion.Trim().ToUpper())
                {

                    case "AGREGAR":

                        Consultas = @"SELECT CASE WHEN EXISTS(Select IdEmpleado from empleado where IdAreaLaboral = @IdAreaLaboral and  IdCargo = @IdCargo and  IdMunicipio = @IdMunicipio and upper(trim(Nombre)) = upper(trim( @Nombre)) and upper(trim(Apellidos)) = upper(trim(@Apellidos)) and upper(trim(Cedula)) = upper(trim(@Cedula)) and upper(trim(Direccion)) = upper(trim(@Direccion)) and upper(trim(Telefono)) = upper(trim(@Telefono)) and upper(trim(Celular)) = upper(trim(@Celular)) and upper(trim(Correo)) = upper(trim(@Correo)) and upper(trim(NoINSS)) = upper(trim(@NoINSS))) THEN 1 ELSE 0 END AS 'RES'";
                        Comando.Parameters.Add(new MySqlParameter("@IdAreaLaboral", MySqlDbType.Int32)).Value = oRegistroEN.oAreaLaboralEN.IdAreaLaboral;
                        Comando.Parameters.Add(new MySqlParameter("@IdCargo", MySqlDbType.Int32)).Value = oRegistroEN.oCargoEN.IdCargo;
                        Comando.Parameters.Add(new MySqlParameter("@Municipio", MySqlDbType.Int32)).Value = oRegistroEN.oMunicipioEN.IdMunicipio;
                        Comando.Parameters.Add(new MySqlParameter("@Nombre", MySqlDbType.VarChar, oRegistroEN.Nombre.Trim().Length)).Value = oRegistroEN.Nombre.Trim();
                        Comando.Parameters.Add(new MySqlParameter("@Apellidos", MySqlDbType.VarChar, oRegistroEN.Apellidos.Trim().Length)).Value = oRegistroEN.Apellidos.Trim();
                        Comando.Parameters.Add(new MySqlParameter("@Cedula", MySqlDbType.VarChar, oRegistroEN.Cedula.Trim().Length)).Value = oRegistroEN.Cedula.Trim();
                        Comando.Parameters.Add(new MySqlParameter("@Direccion", MySqlDbType.VarChar, oRegistroEN.Direccion.Trim().Length)).Value = oRegistroEN.Direccion.Trim();
                        Comando.Parameters.Add(new MySqlParameter("@Telefono", MySqlDbType.VarChar, oRegistroEN.Telefono.Trim().Length)).Value = oRegistroEN.Telefono.Trim();
                        Comando.Parameters.Add(new MySqlParameter("@Celular", MySqlDbType.VarChar, oRegistroEN.Celular.Trim().Length)).Value = oRegistroEN.Celular.Trim();
                        Comando.Parameters.Add(new MySqlParameter("@Correo", MySqlDbType.VarChar, oRegistroEN.Correo.Trim().Length)).Value = oRegistroEN.Correo.Trim();
                        Comando.Parameters.Add(new MySqlParameter("@NoINSS", MySqlDbType.VarChar, oRegistroEN.NoINSS.Trim().Length)).Value = oRegistroEN.NoINSS.Trim();
                        break;

                    case "ACTUALIZAR":

                        Consultas = @"SELECT CASE WHEN EXISTS(Select IdEmpleado from empleado where IdAreaLaboral = @IdAreaLaboral and  IdCargo = @IdCargo and  IdMunicipio = @IdMunicipio and upper(trim(Nombre)) = upper(trim( @Nombre)) and upper(trim(Apellidos)) = upper(trim(@Apellidos)) and upper(trim(Cedula)) = upper(trim(@Cedula)) and IdEmpleado <> @IdEmpleado) THEN 1 ELSE 0 END AS 'RES'";
                        Comando.Parameters.Add(new MySqlParameter("@IdEmpleado", MySqlDbType.Int32)).Value = oRegistroEN.IdEmpleado;
                        Comando.Parameters.Add(new MySqlParameter("@IdAreaLaboral", MySqlDbType.Int32)).Value = oRegistroEN.oAreaLaboralEN.IdAreaLaboral;
                        Comando.Parameters.Add(new MySqlParameter("@IdCargo", MySqlDbType.Int32)).Value = oRegistroEN.oCargoEN.IdCargo;
                        Comando.Parameters.Add(new MySqlParameter("@Municipio", MySqlDbType.Int32)).Value = oRegistroEN.oMunicipioEN.IdMunicipio;
                        Comando.Parameters.Add(new MySqlParameter("@Nombre", MySqlDbType.VarChar, oRegistroEN.Nombre.Trim().Length)).Value = oRegistroEN.Nombre.Trim();
                        Comando.Parameters.Add(new MySqlParameter("@Apellidos", MySqlDbType.VarChar, oRegistroEN.Apellidos.Trim().Length)).Value = oRegistroEN.Apellidos.Trim();
                        Comando.Parameters.Add(new MySqlParameter("@Cedula", MySqlDbType.VarChar, oRegistroEN.Cedula.Trim().Length)).Value = oRegistroEN.Cedula.Trim();
                        Comando.Parameters.Add(new MySqlParameter("@Direccion", MySqlDbType.VarChar, oRegistroEN.Direccion.Trim().Length)).Value = oRegistroEN.Direccion.Trim();
                        Comando.Parameters.Add(new MySqlParameter("@Telefono", MySqlDbType.VarChar, oRegistroEN.Telefono.Trim().Length)).Value = oRegistroEN.Telefono.Trim();
                        Comando.Parameters.Add(new MySqlParameter("@Celular", MySqlDbType.VarChar, oRegistroEN.Celular.Trim().Length)).Value = oRegistroEN.Celular.Trim();
                        Comando.Parameters.Add(new MySqlParameter("@Correo", MySqlDbType.VarChar, oRegistroEN.Correo.Trim().Length)).Value = oRegistroEN.Correo.Trim();
                        Comando.Parameters.Add(new MySqlParameter("@NoINSS", MySqlDbType.VarChar, oRegistroEN.NoINSS.Trim().Length)).Value = oRegistroEN.NoINSS.Trim();

                        break;

                    default:
                        throw new ArgumentException("La aperación solicitada no esta disponible");

                }

                Comando.CommandText = Consultas;

                InicialisarAdaptador();

                if (Convert.ToInt32(DT.Rows[0]["RES"].ToString()) > 0)
                {

                    DescripcionDeLaOperacion = string.Format("Ya existe información del Registro dentro de nuestro sistema: {0} {1}", Environment.NewLine, InformacionDelRegistro(oRegistroEN));
                    this.Error = DescripcionDeLaOperacion;
                    return true;

                }

                return false;

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                DescripcionDeLaOperacion = string.Format("Se produjo el seguiente error: '{2}' al validar el registro. {0} {1} ", Environment.NewLine, InformacionDelRegistro(oRegistroEN), ex.Message);

                //Agregamos la Transacción....
                TransaccionesEN oTransaccion = InformacionDeLaTransaccion(oRegistroEN, "VALIDAR", "REGISTRO DUPLICADO DENTRO DE LA BASE DE DATOS", "ERROR");
                oTransaccionesAD.Agregar(oTransaccion, oDatos);

                return false;
            }
            finally
            {

                FinalizarConexion();
                oTransaccionesAD = null;

            }

        }

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
