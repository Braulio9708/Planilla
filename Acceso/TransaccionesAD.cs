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
    public class TransaccionesAD
    {
        public string Error { set; get; }
        private MySqlConnection Cnn = null;
        private MySqlCommand Comando = null;
        string Consultas;
        public DateTime FechaDeCreacion { set; get; }
        public string NombreDelEquipo { set; get; }
        public string Modelo { set; get; }
        public string Modulo { set; get; }
        public string Tabla { set; get; }
        private DataTable DT { set; get; }

        #region "Funcions de datos dll"
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdUsuario"></param>
        /// <param name="IP"></param>
        /// <param name="IdRegistro"></param>
        /// <param name="TipoDeOperacion"></param>
        /// <param name="DescripcionInterna"></param>
        /// <param name="Estado"></param>
        /// <param name="DescripcionDelUsuario"></param>
        /// <param name="IdUsuarioAPrueva"></param>
        /// <param name="oDatos"></param>
        /// <returns></returns>
        public bool Agregar(int IdUsuario, string IP, int IdRegistro, string TipoDeOperacion, string DescripcionInterna, string Estado, string DescripcionDelUsuario, int IdUsuarioAPrueva, DatosDeConexionEN oDatos)
        {
            try
            {
                InicialisarVariablesGlovales(oDatos);

                Consultas = @"insert into transacciones
                            (IdUsuario, FechaDeCreacion, IP, NombreDelEquipo, IdRegistro, 
                            TipoDeOperacion, DescripcionInterna, Estado, Modelo, 
                            Tabla, DescripcionDelUsuario, IdUsuarioAPrueva)
                            values
                            (@IdUsuario, @FechaDeCreacion, @IP, @NombreDelEquipo, 
                            @IdRegistro, @TipoDeOperacion, @DescripcionInterna, @Estado, 
                            @Modelo, @Tabla, @DescripcionDelUsuario, @IdUsuarioAPrueva);
                            Select  last_insert_ID() as 'ID';";

                Comando.CommandText = Consultas;

                Comando.Parameters.Add(new MySqlParameter("@IdUsuario", MySqlDbType.Int32)).Value = IdUsuario;
                Comando.Parameters.Add(new MySqlParameter("@FechaDeCreacion", MySqlDbType.DateTime)).Value = FechaDeCreacion;
                Comando.Parameters.Add(new MySqlParameter("@IP", MySqlDbType.VarChar, IP.Trim().Length)).Value = IP.Trim();
                Comando.Parameters.Add(new MySqlParameter("@NombreDelEquipo", MySqlDbType.VarChar, NombreDelEquipo.Trim().Length)).Value = NombreDelEquipo.Trim();
                Comando.Parameters.Add(new MySqlParameter("@IdRegistro", MySqlDbType.Int32)).Value = IdRegistro;
                Comando.Parameters.Add(new MySqlParameter("@TipoDeOperacion", MySqlDbType.VarChar, TipoDeOperacion.Trim().Length)).Value = TipoDeOperacion.Trim();
                Comando.Parameters.Add(new MySqlParameter("@DescripcionInterna", MySqlDbType.VarChar, DescripcionInterna.Trim().Length)).Value = DescripcionInterna.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Estado", MySqlDbType.VarChar, Estado.Trim().Length)).Value = Estado.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Modelo", MySqlDbType.VarChar, Modelo.Trim().Length)).Value = Modelo.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Modulo", MySqlDbType.VarChar, Modulo.Trim().Length)).Value = Modulo.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Tabla", MySqlDbType.VarChar, Tabla.Trim().Length)).Value = Tabla.Trim();
                Comando.Parameters.Add(new MySqlParameter("@DescripcionDelUsuario", MySqlDbType.VarChar, DescripcionDelUsuario.Trim().Length)).Value = DescripcionDelUsuario.Trim();
                Comando.Parameters.Add(new MySqlParameter("@IdUsuarioAPrueva", MySqlDbType.Int32)).Value = IdUsuarioAPrueva;

                Comando.ExecuteNonQuery();

                return true;
            }
            catch(Exception ex)
            {
                this.Error = ex.Message;
                return false;
            }
            finally
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
            }
        }

        public bool Agregar(TransaccionesEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            try
            {
                InicialisarVariablesGlovales(oDatos);

                Consultas = @"insert into transacciones
                            (IdUsuario, FechaDeCreacion, IP, NombreDelEquipo, 
                            IdRegistro, TipoDeOperacion, DescripcionInterna, 
                            Estado, Modelo, Modulo, Tabla, DescripcionDelUsuario, 
                            IdUsuarioAPrueva)
                            value
                            (@IdUsuario, current_timestamp(), @IP, @NombreDelEquipo, 
                            @IdRegistro, @TipoDeOperacion, @DescripcionInterna, 
                            @Estado, @Modelo, @Modulo, @Tabla, @DescripcionDelUsuario, 
                            @IdUsuarioAPrueva);

                            select last_insert_id() as 'ID';";

                Comando.CommandText = Consultas;

                Comando.Parameters.Add(new MySqlParameter("@IdUsuario", MySqlDbType.Int32)).Value = oRegistroEN.IdUsuario;
                Comando.Parameters.Add(new MySqlParameter("@IP", MySqlDbType.VarChar, oRegistroEN.IP.Trim().Length)).Value = oRegistroEN.IP.Trim();
                Comando.Parameters.Add(new MySqlParameter("@NombreDelEquipo", MySqlDbType.VarChar, oRegistroEN.nombredelequipo.Trim().Length)).Value = oRegistroEN.nombredelequipo.Trim();
                Comando.Parameters.Add(new MySqlParameter("@IdRegistro", MySqlDbType.Int32)).Value = oRegistroEN.IdRegistro;
                Comando.Parameters.Add(new MySqlParameter("@TipoDeOperacion", MySqlDbType.VarChar, oRegistroEN.TipoDeOperacion.Trim().Length)).Value = oRegistroEN.TipoDeOperacion.Trim();
                Comando.Parameters.Add(new MySqlParameter("@DescripcionInterna", MySqlDbType.VarChar, oRegistroEN.DescripcionInterna.Trim().Length)).Value = oRegistroEN.DescripcionInterna.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Estado", MySqlDbType.VarChar, oRegistroEN.Estado.Trim().Length)).Value = oRegistroEN.Estado.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Modelo", MySqlDbType.VarChar, oRegistroEN.Modelo.Trim().Length)).Value = oRegistroEN.Modelo.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Modulo", MySqlDbType.VarChar, oRegistroEN.Modulo.Trim().Length)).Value = oRegistroEN.Modulo.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Tabla", MySqlDbType.VarChar, oRegistroEN.Tabla.Trim().Length)).Value = oRegistroEN.Tabla.Trim();
                Comando.Parameters.Add(new MySqlParameter("@DescripcionDelUsuario", MySqlDbType.VarChar, oRegistroEN.DescripcionDelUsuario.Trim().Length)).Value = oRegistroEN.DescripcionDelUsuario.Trim();
                Comando.Parameters.Add(new MySqlParameter("@IdUsuarioAPrueva", MySqlDbType.Int32)).Value = oRegistroEN.IdUsuarioAPrueva;

                Comando.ExecuteNonQuery();

                return true;

            }
            catch(Exception ex)
            {
                this.Error = ex.Message;
                return false;
            }
            finally
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
            }
        }

        #endregion

        #region "Funciones que retornan informacion y llamados"
        public void InicialisarVariablesGlovales(DatosDeConexionEN oDatos)
        {
            Cnn = new MySqlConnection(TraerCadenaDeConexion(oDatos));
            Cnn.Open();

            Comando = new MySqlCommand();
            Comando.Connection = Cnn;
            Comando.CommandType = CommandType.Text;
        }
        private string TraerCadenaDeConexion(DatosDeConexionEN oDatos)
        {
            string cadena = string.Format("Data Source='{0}';Initial Catalog='{1}';Persist Security Info=True;User ID='{2}';Password='{3}'", oDatos.Servidor, oDatos.BaseDeDatos, oDatos.Usuario, oDatos.Contrasena);
            return cadena;
        }
        #endregion

    }
}
