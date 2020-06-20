using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.Winform.AppAirBnB.Layers.Entities;
using UTN.Winform.AppAirBnB.Layers.Interface;
using UTN.Winform.AppAirBnB.Layers.Persistencia;
using UTN.Winform.AppAirBnB.Properties;

namespace UTN.Winform.AppAirBnB.Layers.DAL
{
    class DALSeguridad : IDALSeguridad
    {

        private static readonly ILog _MyLogControlEventos = LogManager.GetLogger("MyControlEventos");

        Usuario _Usuario = new Usuario();
        public DALSeguridad()
        {
            _Usuario.Login = Settings.Default.Login;
            _Usuario.Password = Settings.Default.Password;
        }

        /// <summary>
        /// Retorna todas las Bases de Datos
        /// </summary>
        /// <returns>List<string></returns>
        public IEnumerable<string> GetDataBases()
        {

            SqlCommand command = new SqlCommand();
            DataSet ds = null;
            string sql = @"  select * from sys.databases  ";
            List<string> lista = new List<string>();

            try
            {

                command.CommandText = sql;
                command.CommandType = CommandType.Text;

                using (IDataBase db = FactoryDataBase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    ds = db.ExecuteReader(command, "query");
                }


                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    lista.Add(row[0].ToString());
                }

                return lista;
            }
            catch (SqlException sqlError)
            {
                StringBuilder msg = new StringBuilder();
                //msg.AppendFormat(Utilitarios.CreateSQLExceptionsErrorDetails(sqlError));
                msg.AppendFormat("SQL             {0}\n", command.CommandText);
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
            catch (Exception er)
            {
                StringBuilder msg = new StringBuilder();
                //msg.AppendFormat(Utilitarios.CreateGenericErrorExceptionDetail(er));
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }

        }

        /// <summary>
        /// Crea un usuario dependiendo de la Base de Datos
        /// </summary>
        /// <param name="pUsuario">Usuario</param>
        /// <param name="pContrasena">Contrasena</param>
        /// <param name="pBaseDatos">Base de Datos</param>
        public void CreateUser(string pUsuario, string pContrasena, string pBaseDatos)
        {
            StringBuilder sql = new StringBuilder();
            SqlCommand command = new SqlCommand();
            try
            {


                sql.AppendFormat("CREATE LOGIN [{0}] WITH PASSWORD=N'{1}', DEFAULT_DATABASE=[{2}],CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF ",
                                  pUsuario, pContrasena, pBaseDatos);
                sql.AppendFormat("EXEC master..sp_addsrvrolemember @loginame = N'{0}', @rolename = N'sysadmin'   ", pUsuario);
                sql.AppendFormat("USE [{0}]  ", pBaseDatos);
                sql.AppendFormat("CREATE USER [{0}] FOR LOGIN [{1}]  ", pUsuario, pUsuario);

                command.CommandText = sql.ToString();

                using (IDataBase db = FactoryDataBase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    // Note ExecuteNonQuery NO LLEVA TRANSACCION!!!
                    db.ExecuteNonQuery(command);

                }
            }
            catch (SqlException sqlError)
            {
                StringBuilder msg = new StringBuilder();
                //msg.AppendFormat(Utilitarios.CreateSQLExceptionsErrorDetails(sqlError));
                msg.AppendFormat("SQL             {0}\n", command.CommandText);
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
            catch (Exception er)
            {
                StringBuilder msg = new StringBuilder();
               //msg.AppendFormat(Utilitarios.CreateGenericErrorExceptionDetail(er));
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }


        }

        /// <summary>
        /// Extraer los usuarios por Base de Datos
        /// </summary>
        /// <param name="pBaseDatos"></param>
        /// <returns></returns>
        public IEnumerable<string> GetLoginsXDataBase(string pBaseDatos)
        {
            SqlCommand command = new SqlCommand();
            DataSet ds = null;
            string sql = @"   select name from sys.syslogins where dbname =  @basedatos  ";
            List<string> lista = new List<string>();


            try
            {
                command.Parameters.AddWithValue("@basedatos", pBaseDatos);
                command.CommandText = sql;
                command.CommandType = CommandType.Text;

                using (IDataBase db = FactoryDataBase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    ds = db.ExecuteReader(command, "query");
                }


                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    lista.Add(row[0].ToString());
                }

                return lista;

            }
            catch (SqlException sqlError)
            {
                StringBuilder msg = new StringBuilder();
               // msg.AppendFormat(Utilitarios.CreateSQLExceptionsErrorDetails(sqlError));
                msg.AppendFormat("SQL             {0}\n", command.CommandText);
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
            catch (Exception er)
            {
                StringBuilder msg = new StringBuilder();
                //msg.AppendFormat(Utilitarios.CreateGenericErrorExceptionDetail(er));
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
        }

        public IEnumerable<string> GetLogins()
        {
            SqlCommand command = new SqlCommand();
            DataSet ds = null;
            string sql = @"   select name from sys.syslogins  ";
            List<string> lista = new List<string>();

            try
            {
                command.CommandText = sql;
                command.CommandType = CommandType.Text;

                using (IDataBase db = FactoryDataBase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    ds = db.ExecuteReader(command, "query");
                }


                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    lista.Add(row[0].ToString());
                }

                return lista;
            }
            catch (SqlException sqlError)
            {
                StringBuilder msg = new StringBuilder();
                //msg.AppendFormat(Utilitarios.CreateSQLExceptionsErrorDetails(sqlError));
                msg.AppendFormat("SQL             {0}\n", command.CommandText);
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
            catch (Exception er)
            {
                StringBuilder msg = new StringBuilder();
                //msg.AppendFormat(Utilitarios.CreateGenericErrorExceptionDetail(er));
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
        }

    }
}
