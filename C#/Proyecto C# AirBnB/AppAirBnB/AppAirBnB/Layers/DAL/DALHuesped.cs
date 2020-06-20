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
using UTN.Winform.AppAirBnB.Util;

namespace UTN.Winform.AppAirBnB.Layers.DAL
{
    class DALHuesped : IDALHuesped
    {

        private static readonly ILog _MyLogControlEventos = LogManager.GetLogger("MyControlEventos");

        Usuario _Usuario = new Usuario();
        public DALHuesped()
        {
            _Usuario.Login = Settings.Default.Login;
            _Usuario.Password = Settings.Default.Password;
        }

        public bool DeleteHuesped(double pId)
        {
            bool retorno = false;
            double rows = 0d;
            SqlCommand command = new SqlCommand();
            try
            {
                /// string sql = @"Delete from  Cliente Where (IdCliente = @IdCliente) ";
                string sql = "usp_DELETE_Huesped_ByID";
                command.Parameters.AddWithValue("@ID", pId);
                command.CommandText = sql;
                command.CommandType = CommandType.StoredProcedure;

                using (IDataBase db = FactoryDataBase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    rows = db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);
                }

                // Si devuelve filas quiere decir que se salvo entonces extraerlo
                if (rows > 0)
                    retorno = true;

                return retorno;
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

        public List<Huesped> GetAllHuesped()
        {
            DataSet ds = null;
            List<Huesped> lista = new List<Huesped>();
            SqlCommand command = new SqlCommand();
            IDALPais _Pais = new DALPais();
 
                string sql = @"usp_SELECT_Huesped_All";

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
                    //// Iterar en todas las filas y Mapearlas
                    

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Huesped oHuesped = new Huesped();
                        oHuesped.ID = (int)dr["ID"];
                        oHuesped.Nombre = dr["Nombre"].ToString();
                        oHuesped.Apellido1 = dr["Apellido1"].ToString();
                        oHuesped.Apellido2 = dr["Apellido2"].ToString();
                        oHuesped.Telefono = dr["Telefono"].ToString();
                        oHuesped.Correo = dr["Correo"].ToString();
                        oHuesped._Pais = _Pais.GetPaisById(Double.Parse(dr["IDPais"].ToString()));
                        lista.Add(oHuesped);
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

        public List<Huesped> GetHuespedByFilter(string pDescripcion)
        {
            DataSet ds = null;
            List<Huesped> lista = new List<Huesped>();
            SqlCommand command = new SqlCommand();

            IDALPais _DALPais = new DALPais();

            try
            {
                string sql = @" select * from  Huesped1 WITH (NOLOCK) Where Nombre+Apellido1+Apellido2 like @filtro ";
                command.Parameters.AddWithValue("@filtro", pDescripcion);
                command.CommandText = sql;
                command.CommandType = CommandType.Text;

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
                        Huesped oHuesped = new Huesped();
                        oHuesped.ID = (int)dr["ID"];
                        oHuesped.Nombre = dr["Nombre"].ToString();
                        oHuesped.Apellido1 = dr["Apellido1"].ToString();
                        oHuesped.Apellido2 = dr["Apellido2"].ToString();
                        oHuesped.Telefono = dr["Telefono"].ToString();
                        oHuesped.Correo = dr["Correo"].ToString();
                        oHuesped._Pais = _DALPais.GetPaisById(Double.Parse(dr["IDPais"].ToString()));

                        lista.Add(oHuesped);
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


        public Huesped GetHuespedById(double pIdHuesped)
        {
            DataSet ds = null;
            Huesped oHuesped = new Huesped();
            SqlCommand command = new SqlCommand();

            IDALPais _DALPais = new DALPais();


            string sql = @"select * from [Huesped] where ID = @ID";

            try
            {
                command.Parameters.AddWithValue("@ID", pIdHuesped);
                command.CommandText = sql;
                command.CommandType = CommandType.Text;

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
                        oHuesped.ID = (int)dr["ID"];
                        oHuesped.Nombre = dr["Nombre"].ToString();
                        oHuesped.Apellido1 = dr["Apellido1"].ToString();
                        oHuesped.Apellido2 = dr["Apellido2"].ToString();
                        oHuesped.Telefono = dr["Telefono"].ToString();
                        oHuesped.Correo = dr["Correo"].ToString();
                        oHuesped._Pais = _DALPais.GetPaisById(Double.Parse(dr["IDPais"].ToString()));



                    }
                }

                return oHuesped;
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

        public Huesped SaveHuesped(Huesped oHuesped)
        {

            Huesped _Huesped = null;
            string sql = @"usp_INSERT_Huesped";
            SqlCommand cmd = new SqlCommand();
            double rows = 0;

            try
            {

                
                cmd.Parameters.AddWithValue("@ID", oHuesped.ID);
                cmd.Parameters.AddWithValue("@Nombre", oHuesped.Nombre);
                cmd.Parameters.AddWithValue("@Apellido1", oHuesped.Apellido1);
                cmd.Parameters.AddWithValue("@Apellido2", oHuesped.Apellido2);
                cmd.Parameters.AddWithValue("@Telefono", oHuesped.Telefono);
                cmd.Parameters.AddWithValue("@Correo", oHuesped.Correo);
                cmd.Parameters.AddWithValue("@IDPais", oHuesped._Pais.ID);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.StoredProcedure;


                using (IDataBase db = FactoryDataBase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {

                    rows = db.ExecuteNonQuery(cmd, IsolationLevel.ReadCommitted);
                }

                // Si devuelve filas quiere decir que se salvo entonces extraerlo
                if (rows > 0)
                    _Huesped = GetHuespedById(oHuesped.ID);

                return _Huesped;

            }
            catch (SqlException sqlError)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.CreateSQLExceptionsErrorDetails(sqlError));
                msg.AppendFormat("SQL             {0}\n", cmd.CommandText);
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

        public Huesped UpdateHuesped(Huesped pHuesped)
        {
            Huesped _Huesped = null;
            string sql = @"usp_UPDATE_Huesped";
            SqlCommand cmd = new SqlCommand();
            double rows = 0;

            try
            {


                cmd.Parameters.AddWithValue("@ID", pHuesped.ID);
                cmd.Parameters.AddWithValue("@Nombre", pHuesped.Nombre);
                cmd.Parameters.AddWithValue("@Apellido1", pHuesped.Apellido1);
                cmd.Parameters.AddWithValue("@Apellido2", pHuesped.Apellido2);
                cmd.Parameters.AddWithValue("@Telefono", pHuesped.Telefono);
                cmd.Parameters.AddWithValue("@Correo", pHuesped.Correo);
                cmd.Parameters.AddWithValue("@IDPais", pHuesped._Pais.ID);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.StoredProcedure;


                using (IDataBase db = FactoryDataBase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {

                    rows = db.ExecuteNonQuery(cmd, IsolationLevel.ReadCommitted);
                }

                // Si devuelve filas quiere decir que se salvo entonces extraerlo
                if (rows > 0)
                    _Huesped = GetHuespedById(pHuesped.ID);

                return _Huesped;

            }
            catch (SqlException sqlError)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.CreateSQLExceptionsErrorDetails(sqlError));
                msg.AppendFormat("SQL             {0}\n", cmd.CommandText);
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
