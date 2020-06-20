using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.Winform.AppAirBnB.Layers.Entities;
using UTN.Winform.AppAirBnB.Layers.Entities.DTO;
using UTN.Winform.AppAirBnB.Layers.Interface;
using UTN.Winform.AppAirBnB.Layers.Persistencia;
using UTN.Winform.AppAirBnB.Properties;
using UTN.Winform.AppAirBnB.Util;

namespace UTN.Winform.AppAirBnB.Layers.DAL
{
    class DALSysUserRolDTO : IDALSysUserRolDTO
    {

        private static readonly ILog _MyLogControlEventos = LogManager.GetLogger("MyControlEventos");

        private Usuario _Usuario = new Usuario();
        public DALSysUserRolDTO()
        {
            _Usuario.Login = Settings.Default.Login;
            _Usuario.Password = Settings.Default.Password;
        }


        public bool DeleteSysUser(string pId)
        {
            double rows = 0;
            // Crear el SQL
            string sql = @"usp_DELETE_SysUser_ByID";
            SqlCommand command = new SqlCommand();

            try
            {
                // Pasar parámetros
                command.Parameters.AddWithValue("@Login", pId);
                command.CommandText = sql;
                command.CommandType = CommandType.StoredProcedure;

                // Ejecutar
                using (IDataBase db = FactoryDataBase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    rows = db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);
                }

                return rows > 0;
            }
            catch (SqlException sqlError)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.CreateSQLExceptionsErrorDetails(sqlError));
                msg.AppendFormat("SQL             {0}\n", command.CommandText);
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
            catch (Exception er)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.CreateGenericErrorExceptionDetail(er));
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
        }



        public List<SysUserRolDTO> GetAllSysUser()
        {
            DataSet ds = null;
            List<SysUserRolDTO> lista = new List<SysUserRolDTO>();
            SqlCommand command = new SqlCommand();

            string sql = @"usp_SELECT_SysUser_All";
            try
            {
                command.CommandText = sql;
                command.CommandType = CommandType.StoredProcedure;

                using (IDataBase db = FactoryDataBase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    ds = db.ExecuteReader(command, "query");
                }

                // Si devolvió filas
                if (ds.Tables[0].Rows.Count > 0)
                {

                    // Iterar en todas las filas y Mapearlas
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        SysUserRolDTO oSysUserRolDTO = new SysUserRolDTO()
                        {
                            Login = (dr["Login"].ToString()),
                            Password= (dr["Password"].ToString()),
                            Id = double.Parse(dr["IdRol"].ToString()),
                            //Descripcion = (dr["Descripcion"].ToString()),
                            IDUser = (int)(dr["IDUser"])
                            
                           
                        };

                        lista.Add(oSysUserRolDTO);
                    }
                }

                return lista;
            }
            catch (SqlException sqlError)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.CreateSQLExceptionsErrorDetails(sqlError));
                msg.AppendFormat("SQL             {0}\n", command.CommandText);
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
            catch (Exception er)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.CreateGenericErrorExceptionDetail(er));
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
        }



        public List<SysUser> GetSysUserByFilter(string pDescripcion)
        {
            DataSet ds = null;
            SqlCommand command = new SqlCommand();
            List<SysUser> lista = new List<SysUser>();
            string sql = @" select * from  [SysUser] where [Login] like @Login";

            try
            {
                // Pasar Parámetro
                command.Parameters.AddWithValue("@Login", pDescripcion);
                command.CommandText = sql;
                command.CommandType = CommandType.Text;

                // Ejecutar
                using (IDataBase db = FactoryDataBase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    ds = db.ExecuteReader(command, "query");
                }

                // Si devolvió valores
                if (ds.Tables[0].Rows.Count > 0)
                {
                    // Itetarar en las filas
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        
                       SysUser oSysUser = new SysUser()
                       {
                           Login = (dr["Login"].ToString()),
                           Password = (dr["Password"].ToString()),
                           IdRol = (int)(dr["IdRol"]),
                           IDUser = (int)(dr["IDUser"])
                       };

                        lista.Add(oSysUser);

                    }

                }

                return lista;
            }
            catch (SqlException sqlError)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.CreateSQLExceptionsErrorDetails(sqlError));
                msg.AppendFormat("SQL             {0}\n", command.CommandText);
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
            catch (Exception er)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.CreateGenericErrorExceptionDetail(er));
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
        }

        public SysUser GetSysUserById(double pId)
        {
            DataSet ds = null;
            SysUser oSysUser = null;
            SysUserRolDTO DTO = new SysUserRolDTO(); 
            string sql = @" select * from  [SysUser] where IDUser = @IDUser";

            SqlCommand command = new SqlCommand();

            try
            {
                command.Parameters.AddWithValue("@IDUser", pId);
                command.CommandText = sql;
                command.CommandType = CommandType.Text;

                using (IDataBase db = FactoryDataBase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    ds = db.ExecuteReader(command, "query");
                }

                // Si retornó valores 
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //Extraer la primera fila, como se buscó por Id entonces solo una debe devolver  
                    DataRow dr = ds.Tables[0].Rows[0];
                    oSysUser = new SysUser()
                    {
                        Login = (dr["Login"].ToString()),
                        Password = (dr["Password"].ToString()),
                        IdRol = (int)(dr["IdRol"]),
                        IDUser = (int)(dr["IDUser"])
                    };


                }

                return oSysUser;
            }
            catch (SqlException sqlError)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.CreateSQLExceptionsErrorDetails(sqlError));
                msg.AppendFormat("SQL             {0}\n", command.CommandText);
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
            catch (Exception er)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.CreateGenericErrorExceptionDetail(er));
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
        }



        public SysUser SaveSysUser(SysUser pSysUser)
        {
            SysUser oSysUser = null;
            string sql = @"usp_INSERT_SysUser";


            SqlCommand command = new SqlCommand();
            double rows = 0;

            try
            {

                // Pasar parámetros
                command.Parameters.AddWithValue("@Login", pSysUser.Login);
                command.Parameters.AddWithValue("@Password", pSysUser.Password);
                command.Parameters.AddWithValue("@IdRol", pSysUser.IdRol);
                command.Parameters.AddWithValue("@IDUser", pSysUser.IDUser);
                command.CommandText = sql;
                command.CommandType = CommandType.StoredProcedure;


                using (IDataBase db = FactoryDataBase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {

                    rows = db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);
                }

                // Si devuelve filas quiere decir que se salvo entonces extraerlo
                if (rows > 0)
                    oSysUser = GetSysUserById(pSysUser.IDUser);

                return oSysUser;
            }
            catch (SqlException sqlError)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.CreateSQLExceptionsErrorDetails(sqlError));
                msg.AppendFormat("SQL             {0}\n", command.CommandText);
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
            catch (Exception er)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.CreateGenericErrorExceptionDetail(er));
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
        }


        public SysUser UpdateSysUser(SysUser pSysUser)
        {
            SysUser oSysUser = null;
            string sql = @"usp_UPDATE_SysUser";



            SqlCommand command = new SqlCommand();
            double rows = 0;

            try
            {

                // Pasar parámetros
                command.Parameters.AddWithValue("@Login", pSysUser.Login);
                command.Parameters.AddWithValue("@Password", pSysUser.Password);
                command.Parameters.AddWithValue("@IdRol", pSysUser.IdRol);
                command.Parameters.AddWithValue("@IDUser", pSysUser.IDUser);
                command.CommandText = sql;
                command.CommandType = CommandType.StoredProcedure;


                using (IDataBase db = FactoryDataBase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {

                    rows = db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);
                }

                // Si devuelve filas quiere decir que se salvo entonces extraerlo
                if (rows > 0)
                    oSysUser = GetSysUserById(pSysUser.IDUser);

                return oSysUser;
            }
            catch (SqlException sqlError)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.CreateSQLExceptionsErrorDetails(sqlError));
                msg.AppendFormat("SQL             {0}\n", command.CommandText);
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
            catch (Exception er)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.CreateGenericErrorExceptionDetail(er));
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
        }
    }
}
