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
            try
            {
                InicialisarVariablesGlovales(oDatos);
                
                Consultas = @"insert into empleado
                            (Nombre, Apellidos, Cedula, Direccion, Telefono, 
                            Celular, Correo, IdCargo, IdCiudad, IdAreaLaboral, NoINSS)
                            value
                            (@Nombre, @Apellidos, @Cedula, @Direccion, @Telefono, 
                            @Celular, @Correo, @IdCargo, @IdCiudad, @IdAreaLaboral, @NoINSS);

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
                Comando.Parameters.Add(new MySqlParameter("@IdCiudad", MySqlDbType.Int32)).Value = oRegistroEN.oCiudadEN.IdCiudad;
                Comando.Parameters.Add(new MySqlParameter("@IdAreaLaboral", MySqlDbType.Int32)).Value = oRegistroEN.oAreaLaboralEN.IdAreaLaboral;
                
                InicialisarAdaptador();
                
                oRegistroEN.IdEmpleado = Convert.ToInt32(DT.Rows[0].ItemArray[0].ToString());
                
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
                            IdCiudad = @IdCiudad, 
                            IdAreaLaboral = @IdAreaLaboral
                            where IdEmpleado = @IdEmpleado;";

                Comando.CommandText = Consultas;
                Comando.Parameters.Add(new MySqlParameter("@IdEmpleado", MySqlDbType.Int32)).Value = oRegistroEN.IdEmpleado;

                Comando.Parameters.Add(new MySqlParameter("@Nombre", MySqlDbType.VarChar, oRegistroEN.Nombre.Trim().Length)).Value = oRegistroEN.Nombre.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Apellidos", MySqlDbType.VarChar, oRegistroEN.Apellidos.Trim().Length)).Value = oRegistroEN.Apellidos.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Cedula", MySqlDbType.VarChar, oRegistroEN.Cedula.Trim().Length)).Value = oRegistroEN.Cedula.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Direccion", MySqlDbType.VarChar, oRegistroEN.Direccion.Trim().Length)).Value = oRegistroEN.Direccion.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Telefono", MySqlDbType.VarChar, oRegistroEN.Telefono.Trim().Length)).Value = oRegistroEN.Telefono.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Celular", MySqlDbType.VarChar, oRegistroEN.Celular.Trim().Length)).Value = oRegistroEN.Celular.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Correo", MySqlDbType.VarChar, oRegistroEN.Correo.Trim().Length)).Value = oRegistroEN.Correo.Trim();
                Comando.Parameters.Add(new MySqlParameter("@NoINSS", MySqlDbType.VarChar, oRegistroEN.NoINSS.Trim().Length)).Value = oRegistroEN.NoINSS.Trim();
                Comando.Parameters.Add(new MySqlParameter("@IdCargo", MySqlDbType.Int32)).Value = oRegistroEN.oCargoEN.IdCargo;
                Comando.Parameters.Add(new MySqlParameter("@IdCiudad", MySqlDbType.Int32)).Value = oRegistroEN.oCiudadEN.IdCiudad;
                Comando.Parameters.Add(new MySqlParameter("@IdAreaLaboral", MySqlDbType.Int32)).Value = oRegistroEN.oAreaLaboralEN.IdAreaLaboral;

                Comando.ExecuteNonQuery();

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

        public bool Eliminar(EmpleadoEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {
                
                InicialisarVariablesGlovales(oDatos);
                
                Consultas = @"Delete from Empleado where IdEmpleado = @IdEmpleado";
                Comando.CommandText = Consultas;
                
                Comando.Parameters.Add(new MySqlParameter("@IdEmpleado", MySqlDbType.Int32)).Value = oRegistroEN.IdEmpleado;
                
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

        public bool Listado(EmpleadoEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            try
            {
                InicialisarVariablesGlovales(oDatos);
                
                Consultas = string.Format(@"select emp.IdEmpleado, emp.Nombre, emp.Apellidos, emp.Cedula, emp.Direccion, emp.Telefono, emp.Celular, emp.Correo, emp.NoINSS,
								emp.IdCargo, emp.IdCiudad, emp.IdAreaLaboral, al.Area as 'AreaLaboral', co.Cargo as 'Cargo', cdd.Ciudad
                                from empleado as emp
                                inner join cargo as co on emp.IdCargo = co.IdCargo
                                inner join arealaboral as al on emp.IdAreaLaboral = al.IdAreaLaboral
                                inner join ciudad as cdd on cdd.IdCiudad = emp.IdCiudad
                                where emp.IdEmpleado > 0 {0} {1} ", oRegistroEN.Where, oRegistroEN.OrderBy);

                Comando.CommandText = Consultas;
                
                InicialisarAdaptador();
                //Console.WriteLine("Buscar Error");
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

                Consultas = string.Format(@"select emp.IdEmpleado, emp.Nombre, emp.Apellidos, emp.Cedula, emp.Direccion, emp.Telefono, emp.Celular, emp.Correo, emp.NoINSS,
								emp.IdCargo, emp.IdCiudad, emp.IdAreaLaboral, al.Area as 'AreaLaboral', co.Cargo as 'Cargo', cdd.Ciudad
                                from empleado as emp
                                inner join cargo as co on emp.IdCargo = co.IdCargo
                                inner join arealaboral as al on emp.IdAreaLaboral = al.IdAreaLaboral
                                inner join ciudad as cdd on cdd.IdCiudad = emp.IdCiudad
                                where emp.IdEmpleado > @IdEmpleado", oRegistroEN.IdEmpleado);

                Comando.CommandText = Consultas;

                Comando.Parameters.Add(new MySqlParameter("@IdEmpleado", MySqlDbType.Int32)).Value = oRegistroEN.IdEmpleado;

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

                Consultas = string.Format(@"select emp.Idempleado, emp.Nombre, emp.Apellidos, emp.Cedula, emp.Direccion, emp.Telefono, emp.Celular, emp.Correo, emp.NoINSS,
								emp.IdCargo, emp.IdCiudad, emp.IdAreaLaboral, al.Area as 'AreaLaboral', co.Cargo as 'Cargo', cdd.Ciudad
                                from empleado as emp
                                inner join cargo as co on emp.IdCargo = co.IdCargo
                                inner join arealaboral as al on emp.IdAreaLaboral = al.IdAreaLaboral
                                inner join ciudad as cdd on cdd.IdCiudad = emp.IdCiudad
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

                Consultas = string.Format(@"select IdEmpleado, Nombre, Apellidos, Cedula, Direccion, Telefono, Celular, Correo, NoINSS, IdCargo, IdCiudad, IdAreaLaboral from empleado where IdEmpleado > 0 {0} {1} ", oRegistroEN.Where, oRegistroEN.OrderBy);
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
            Console.WriteLine("BUSCAR ERROR");
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
            string Cadena= @"IdEmpleado={0}, Nombre={2}, Apellidos={3}, Cedula={4}, Direccion={5}, Telefono={6}, Celular={7}, Correo={8}, NoINSS={9}, IdCargo={10}, IdCiudad={11}, IdAreaLaboral={12}, Area={13}, Cargo={14}, Municipio{15}";
            Cadena = string.Format(Cadena, oRegistroEN.IdEmpleado, oRegistroEN.Nombre, oRegistroEN.Apellidos, oRegistroEN.Cedula, oRegistroEN.Direccion, oRegistroEN.Telefono, oRegistroEN.Celular, oRegistroEN.Correo, oRegistroEN.NoINSS, oRegistroEN.oCargoEN.IdCargo, oRegistroEN.oCiudadEN.IdCiudad,
                oRegistroEN.oAreaLaboralEN.IdAreaLaboral, oRegistroEN.oAreaLaboralEN.Area, oRegistroEN.oCargoEN.Cargo, oRegistroEN.oCiudadEN.Ciudad);
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
            try
            {
                
                InicialisarVariablesGlovales(oDatos);

                switch (TipoDeOperacion.Trim().ToUpper())
                {
                    case "AGREGAR":

                        Consultas = @"SELECT CASE WHEN EXISTS(Select IdEmpleado from empleado where upper(trim(Nombre)) = upper(trim(@Nombre)) and IdCiudad = @IdCiudad and IdAreaLaboral = @IdAreaLaboral and IdCargo = @IdCargo) THEN 1 ELSE 0 END AS 'RES'";
                        Comando.Parameters.Add(new MySqlParameter("@Nombre", MySqlDbType.VarChar, oRegistroEN.Nombre.Trim().Length)).Value = oRegistroEN.Nombre.Trim();
                        Comando.Parameters.Add(new MySqlParameter("@IdCiudad", MySqlDbType.Int32)).Value = oRegistroEN.oCiudadEN.IdCiudad;
                        Comando.Parameters.Add(new MySqlParameter("@IdAreaLaboral", MySqlDbType.Int32)).Value = oRegistroEN.oAreaLaboralEN.IdAreaLaboral;
                        Comando.Parameters.Add(new MySqlParameter("@IdCargo", MySqlDbType.Int32)).Value = oRegistroEN.oCargoEN.IdCargo;

                        break;

                    case "ACTUALIZAR":

                        Consultas = @"SELECT CASE WHEN EXISTS(Select IdEmpleado from empleado where upper(trim(Nombre)) = upper(trim(Nombre)) and IdEmpleado <> @IdEmpleado) THEN 1 ELSE 0 END AS 'RES'";
                        Comando.Parameters.Add(new MySqlParameter("@Nombre", MySqlDbType.VarChar, oRegistroEN.Nombre.Trim().Length)).Value = oRegistroEN.Nombre.Trim();
                        Comando.Parameters.Add(new MySqlParameter("@IdEmpleado", MySqlDbType.Int32)).Value = oRegistroEN.IdEmpleado;

                        break;

                    default:
                        throw new ArgumentException("La aperación solicitada no esta disponible");

                }

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
