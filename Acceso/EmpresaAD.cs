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
    public class EmpresaAD
    {

        public string Error { set; get; }
        private MySqlConnection Cnn = null;
        private MySqlCommand Comando = null;
        private MySqlDataAdapter Adaptador = null;
        private TransaccionesAD oTransaccionesAD = null;
        string Consultas;
        string DescripcionDeLaOperacion;
        private DataTable DT { set; get; }

        public EmpresaAD()
        {

            oTransaccionesAD = new TransaccionesAD();
            oTransaccionesAD.Modulo = "General";
            oTransaccionesAD.Modelo = "EmpresaAD";
            oTransaccionesAD.NombreDelEquipo = Environment.MachineName;
            oTransaccionesAD.FechaDeCreacion = System.DateTime.Now;
            oTransaccionesAD.Tabla = "Empresa";

        }

        #region "Funciones dll"
        public bool Agregar(EmpresaEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            oTransaccionesAD = new TransaccionesAD();
            try
            {
                InicialisarVariablesGlovales(oDatos);
                Consultas = @"insert into empresa 
				            (Nombre, Direccion, Telefono, NRuc, Logo, Celular, Email, SitioWeb, Descripcion, IdUsuario) 
                            values 
                            (@Nombre, @Direccion, @Telefono, @NRuc, @Logo, @Celular, @Email, @SitioWeb, @Descripcion, @IdUsuario);
                        Select  last_insert_ID() as 'ID';";

                Comando.Parameters.Add(new MySqlParameter("@Nombre", MySqlDbType.VarChar, oRegistroEN.Nombre.Trim().Length)).Value = oRegistroEN.Nombre.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Direccion", MySqlDbType.VarChar, oRegistroEN.Direccion.Trim().Length)).Value = oRegistroEN.Direccion.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Telefono", MySqlDbType.VarChar, oRegistroEN.Telefono.Trim().Length)).Value = oRegistroEN.Telefono.Trim();
                Comando.Parameters.Add(new MySqlParameter("@NRuc", MySqlDbType.VarChar, oRegistroEN.NRuc.Trim().Length)).Value = oRegistroEN.NRuc.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Celular", MySqlDbType.VarChar, oRegistroEN.Celular.Trim().Length)).Value = oRegistroEN.Celular.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Email", MySqlDbType.VarChar, oRegistroEN.Email.Trim().Length)).Value = oRegistroEN.Email.Trim();
                Comando.Parameters.Add(new MySqlParameter("@SitioWeb", MySqlDbType.VarChar, oRegistroEN.SitioWeb.Trim().Length)).Value = oRegistroEN.SitioWeb.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Descripcion", MySqlDbType.VarChar, oRegistroEN.Descripcion.Trim().Length)).Value = oRegistroEN.Descripcion.Trim();
                Comando.Parameters.Add(new MySqlParameter("@IdUsuario", MySqlDbType.Int32)).Value = oRegistroEN.oUsuarioEN.IdUsuario;
                Comando.Parameters.Add(new MySqlParameter("@Logo", MySqlDbType.Binary)).Value = oRegistroEN.ALogo;

                InicialisarAdaptador();

                oRegistroEN.IdEmpresa = Convert.ToInt32(DT.Rows[0].ItemArray[0].ToString());

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

        public bool Actualizar(EmpresaEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            oTransaccionesAD = new TransaccionesAD();
            try
            {
                InicialisarVariablesGlovales(oDatos);

                Consultas = @"UPDATE empresa set
	                            Nombre = @Nombre, 
                                Direccion = @Direccion, 
                                Telefono = @Telefono, 
                                NRuc = @NRuc, 
                                Logo = @Logo, 
                                Celular = @Celular, 
                                Email = @Email, 
                                SitioWeb = @SitioWeb, 
                                Descripcion = @Descripcion,
                                IdUsuario = @IdUsuario
                    
                            where IdEmpresa = @IdEmpresa;";

                Comando.Parameters.Add(new MySqlParameter("@IdEmpresa", MySqlDbType.Int32)).Value = oRegistroEN.IdEmpresa;
                Comando.Parameters.Add(new MySqlParameter("@Nombre", MySqlDbType.VarChar, oRegistroEN.Nombre.Trim().Length)).Value = oRegistroEN.Nombre.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Direccion", MySqlDbType.VarChar, oRegistroEN.Direccion.Trim().Length)).Value = oRegistroEN.Direccion.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Telefono", MySqlDbType.VarChar, oRegistroEN.Telefono.Trim().Length)).Value = oRegistroEN.Telefono.Trim();
                Comando.Parameters.Add(new MySqlParameter("@NRuc", MySqlDbType.VarChar, oRegistroEN.NRuc.Trim().Length)).Value = oRegistroEN.NRuc.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Celular", MySqlDbType.VarChar, oRegistroEN.Celular.Trim().Length)).Value = oRegistroEN.Celular.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Email", MySqlDbType.VarChar, oRegistroEN.Email.Trim().Length)).Value = oRegistroEN.Email.Trim();
                Comando.Parameters.Add(new MySqlParameter("@SitioWeb", MySqlDbType.VarChar, oRegistroEN.SitioWeb.Trim().Length)).Value = oRegistroEN.SitioWeb.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Descripcion", MySqlDbType.VarChar, oRegistroEN.Descripcion.Trim().Length)).Value = oRegistroEN.Descripcion.Trim();
                Comando.Parameters.Add(new MySqlParameter("@IdUsuario", MySqlDbType.Int32)).Value = oRegistroEN.oUsuarioEN.IdUsuario;
                Comando.Parameters.Add(new MySqlParameter("@Logo", MySqlDbType.Binary)).Value = oRegistroEN.ALogo;

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

        public bool Eliminar(EmpresaEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            oTransaccionesAD = new TransaccionesAD();

            try
            {
                InicialisarVariablesGlovales(oDatos);

                Consultas = @"delete from empresa where Idempresa = @Idempresa;";

                Comando.Parameters.Add(new MySqlParameter("@IdEmpresa", MySqlDbType.Int32)).Value = oRegistroEN.IdEmpresa;

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

        public bool Listado(EmpresaEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            try
            {
                InicialisarVariablesGlovales(oDatos);

                Consultas = string.Format(@"Select IdEmpresa, Nombre, Direccion, Telefono, NRuc, Logo, Celular, Email, SitioWeb, Descripcion, IdUsuario from empresa where IdEmpresa = 0 {0} {1}", oRegistroEN.Where, oRegistroEN.OrderBy);

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

        public bool ListadoPorID(EmpresaEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            try
            {
                InicialisarVariablesGlovales(oDatos);

                Consultas = string.Format(@"Select IdEmpresa, Nombre, Direccion, Telefono, NRuc, Logo, Celular, Email, SitioWeb, Descripcion, IdUsuario from empresa where IdEmpresa = {0} ", oRegistroEN.IdEmpresa);
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

        public bool ListadoParaCombos(EmpresaEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                InicialisarVariablesGlovales(oDatos);

                Consultas = string.Format(@"select IdEmpresa, Nombre, Direccion, Telefono, NRuc, Logo, Celular, Email, SitioWeb, Descripcion, IdUsuario from empresa where IdEmpresa > 0 {0} {1}; ", oRegistroEN.Where, oRegistroEN.OrderBy);
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

        public bool ListadoParaReportes(EmpresaEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                InicialisarVariablesGlovales(oDatos);

                Consultas = string.Format(@"select IdEmpresa, Nombre, Direccion, Telefono, NRuc, Logo, Celular, Email, SitioWeb, Descripcion, IdUsuario from empresa where IdEmpresa > 0 {0} {1} ", oRegistroEN.Where, oRegistroEN.OrderBy);
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

        public bool ValidarRegistroDuplicado(EmpresaEN oRegistroEN, DatosDeConexionEN oDatos, string TipoDeOperacion)
        {
            oTransaccionesAD = new TransaccionesAD();

            try
            {

                InicialisarVariablesGlovales(oDatos);

                switch (TipoDeOperacion.Trim().ToUpper())
                {

                    case "AGREGAR":
                        //Nombre, Direccion, Telefono, NRuc, Logo, Celular, Email, SitioWeb, Descripcion, IdUsuario
                        Consultas = @"SELECT CASE WHEN EXISTS(SELECT IdEmpresa FROM empresa WHERE upper(trim(Nombre)) = upper(@Nombre)) THEN 1 ELSE 0 END AS 'RES'";
                        Comando.Parameters.Add(new MySqlParameter("@Nombre", MySqlDbType.VarChar, oRegistroEN.Nombre.Trim().Length)).Value = oRegistroEN.Nombre.Trim();                      
                                             
                        break;

                    case "ACTUALIZAR":

                        Consultas = @"SELECT CASE WHEN EXISTS(SELECT IdEmpresa FROM empresa WHERE upper(trim(Nombre)) = upper(@Nombre) and IdEmpresa <> @IdEmpresa) THEN 1 ELSE 0 END AS 'RES'";
                        Comando.Parameters.Add(new MySqlParameter("@Nombre", MySqlDbType.VarChar, oRegistroEN.Nombre.Trim().Length)).Value = oRegistroEN.Nombre.Trim();
                        Comando.Parameters.Add(new MySqlParameter("@IdEmpresa", MySqlDbType.Int32)).Value = oRegistroEN.IdEmpresa;

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
                TransaccionesEN oTransaccion = InformacionDelaTransaccion(oRegistroEN, "VALIDAR", "REGISTRO DUPLICADO DENTRO DE LA BASE DE DATOS", "ERROR");
                oTransaccionesAD.Agregar(oTransaccion, oDatos);

                return false;
            }
            finally
            {

                FinalizarConexion();
                oTransaccionesAD = null;

            }
        }

        

        #endregion

        #region "Funciones Para Retornar Informacion Y Llamados"


        private TransaccionesEN InformacionDelaTransaccion(EmpresaEN oEmpresa, String TipoDeOperacion, String Descripcion, String Estado)
        {
            TransaccionesEN oRegistroEN = new TransaccionesEN();

            oRegistroEN.IdRegistro = oEmpresa.IdEmpresa;
            oRegistroEN.Modelo = "EmpresaAD";
            oRegistroEN.Modulo = "General";
            oRegistroEN.Tabla = "Empresa";
            oRegistroEN.TipoDeOperacion = TipoDeOperacion;
            oRegistroEN.Estado = Estado;
            oRegistroEN.IP = oEmpresa.oLoginEN.NumeroIP;
            oRegistroEN.IdUsuario = oEmpresa.oLoginEN.IdUsuario;
            oRegistroEN.IdUsuarioAPrueva = oEmpresa.oLoginEN.IdUsuario;
            oRegistroEN.DescripcionDelUsuario = DescripcionDeLaOperacion;
            oRegistroEN.DescripcionInterna = Descripcion;
            oRegistroEN.nombredelequipo = oEmpresa.oLoginEN.NombreDelEquipo;

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
        private string InformacionDelRegistro(EmpresaEN oRegistroEN)
        {
            string Cadena = @"IdEmpresa: {0}, Nombre: {1}, Direccion: {2}, Telefono: {3}, NRuc: {4}, oLogo: {5}, Celular: {6}, Email: {7}, StioWeb: {8}, Descripcion: {9}, IdUsuario: {10}";
            Cadena = string.Format(Cadena, oRegistroEN.IdEmpresa, oRegistroEN.Nombre, oRegistroEN.Direccion, oRegistroEN.Telefono, oRegistroEN.NRuc, oRegistroEN.oLogo, oRegistroEN.Celular, oRegistroEN.Email, oRegistroEN.SitioWeb, oRegistroEN.Descripcion, oRegistroEN.oUsuarioEN.IdUsuario);
            Cadena = Cadena.Replace(",", Environment.NewLine);
            return Cadena;
        }
        #endregion


    }
}
