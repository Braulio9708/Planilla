using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Entidad;


namespace Acceso
{
    public class LoginAD
    {
        public string Error { set; get; }
        private MySqlConnection Cnn = null;
        private MySqlCommand Comando = null;
        private MySqlDataAdapter Adaptador = null;
        string Consultas;
        //string DescripcionDeLaOperacion;
        private DataTable DT { set; get; }

        private string TraerCadenaDeConexion(DatosDeConexionEN oDatos)
        {
            string Cadena = string.Format("Data Source= '{0}'; Initial Catalog = '{1}';Persist Security Info=True;User ID='{2}';Password='{3}';", oDatos.Servidor, oDatos.BaseDeDatos, oDatos.Usuario, oDatos.Contrasena);
            return Cadena;
        }
        private void InicializarVariablesGlobales(DatosDeConexionEN oDatos)
        {
            Cnn = new MySqlConnection(TraerCadenaDeConexion(oDatos));
            Cnn.Open();

            Comando = new MySqlCommand();
            Comando.Connection = Cnn;
            Comando.CommandType = CommandType.Text;
        }
        private void InicializarVariablesGlobalesProcedure(DatosDeConexionEN oDatos)
        {
            Cnn = new MySqlConnection(TraerCadenaDeConexion(oDatos));
            Cnn.Open();

            Comando = new MySqlCommand();
            Comando.Connection = Cnn;
            Comando.CommandType = CommandType.StoredProcedure;
        }
        private void FinalizarConeccion()
        {
            if (Cnn != null)
            {
                if (Cnn.State == ConnectionState.Open)
                {
                    Cnn.Close();
                }
                Cnn = null;
                Comando = null;
                Adaptador = null;
            }
        }

        #region "Funciones Generales"

        public bool IniciarLaSesionDelUsuario(LoginEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                InicializarVariablesGlobales(oDatos);
                Comando.CommandType = CommandType.Text;

                Consultas = @"Select u.IdUsuario, u.IdRol, u.Nombre as 'NUsuario',
                rl.Nombre as 'NRol' from Usuario as u
                inner join Rol as rl on rl.IdRol = u.IdRol
                Where upper(trim( rl.Estado )) = 'ACTIVO' and
                upper(Trim(u.Estado)) = 'ACTIVO'  and
                upper(trim(u.Login)) = @Login and
                u.Contrasena = @Contrasena ";

                Comando.CommandText = Consultas;

                Comando.Parameters.Add(new MySqlParameter("@Login", MySqlDbType.VarChar, oRegistroEN.Login.Trim().Length)).Value = oRegistroEN.Login.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Contrasena", MySqlDbType.VarChar, oRegistroEN.Contrasena.Trim().Length)).Value = oRegistroEN.Contrasena;

                Adaptador = new MySqlDataAdapter();
                DT = new DataTable();

                Adaptador.SelectCommand = Comando;
                Adaptador.Fill(DT);

                if (DT.Rows.Count > 0)
                {

                    oRegistroEN.IdUsuario = Convert.ToInt32(DT.Rows[0]["IdUsuario"].ToString());
                    oRegistroEN.NombreUsuario = DT.Rows[0]["NUsuario"].ToString();
                    oRegistroEN.TipoDeCuenta = DT.Rows[0]["NRol"].ToString();

                    return true;

                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
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
                Adaptador = null;

            }

        }

        public DataTable TraerDatos()
        {
            return DT;
        }

        #endregion
    }
}
