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
    class DALHabitacion : IDALHabitacion
    {


        private Usuario _Usuario = new Usuario();
        public DALHabitacion()
        {
            _Usuario.Login = Settings.Default.Login;
            _Usuario.Password = Settings.Default.Password;
        }

        public bool DeleteHabitacion(double pId)
        {

            double rows = 0;
            // Crear el SQL
            string sql = @"usp_DELETE_Habitacion_ByID";
            SqlCommand command = new SqlCommand();

            try
            {
                // Pasar parámetros
                command.Parameters.AddWithValue("@NUM", pId);
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
                //_MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
            catch (Exception er)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.CreateGenericErrorExceptionDetail(er));
                //_MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
        }


        public List<HabitacionDTO> GetAllHabitacion()
        {
            DataSet ds = null;
            List<HabitacionDTO> lista = new List<HabitacionDTO>();
            SqlCommand command = new SqlCommand();

            string sql = @"usp_SELECT_Habitacion_All";
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
                        HabitacionDTO oHabitacionDTO = new HabitacionDTO()
                        {
                            NUM = double.Parse(dr["NUM"].ToString()),
                            Descripcion = dr["Descripcion"].ToString(),
                            Foto = (byte[])dr["Foto"],
                            Estado = (int)dr["Estado"],
                            Precio = double.Parse(dr["Precio"].ToString())

                        };

                        lista.Add(oHabitacionDTO);
                    }
                }

                return lista;
            }
            catch (SqlException sqlError)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.CreateSQLExceptionsErrorDetails(sqlError));
                msg.AppendFormat("SQL             {0}\n", command.CommandText);
                //_MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
            catch (Exception er)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.CreateGenericErrorExceptionDetail(er));
                //_MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
        }

        public Habitacion GetHabitacionById(double pId)
        {
            DataSet ds = null;
            Habitacion oHabitacion = null;
            string sql = @"Select * from [Habitacion] where NUM = @NUM";

            SqlCommand command = new SqlCommand();

            try
            {
                command.Parameters.AddWithValue("@NUM", pId);
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
                    oHabitacion = new Habitacion()
                    {
                        NUM = double.Parse(dr["NUM"].ToString()),                        
                        Descripcion = dr["Descripcion"].ToString(),
                        Foto = (byte[])dr["Foto"],
                        Estado = (int)dr["Estado"],
                        Precio = double.Parse(dr["Precio"].ToString())


                    };


                }

                return oHabitacion;
            }
            catch (SqlException sqlError)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.CreateSQLExceptionsErrorDetails(sqlError));
                msg.AppendFormat("SQL             {0}\n", command.CommandText);
                //_MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
            catch (Exception er)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.CreateGenericErrorExceptionDetail(er));
                //_MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
        }

        public Habitacion SaveHabitacion(Habitacion pHabitacion)
        {
            Habitacion oHabitacion = null;
            string sql = @"usp_INSERT_Habitacion";


            SqlCommand command = new SqlCommand();
            double rows = 0;

            try
            {

                // Pasar parámetros
                command.Parameters.AddWithValue("@NUM", pHabitacion.NUM);
                command.Parameters.AddWithValue("@Descripcion", pHabitacion.Descripcion);
                command.Parameters.AddWithValue("@Foto", pHabitacion.Foto.ToArray());
                command.Parameters.AddWithValue("Estado", pHabitacion.Estado);
                command.Parameters.AddWithValue("Precio", pHabitacion.Precio);

                command.CommandText = sql;
                command.CommandType = CommandType.StoredProcedure;


                using (IDataBase db = FactoryDataBase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {

                    rows = db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);
                }

                // Si devuelve filas quiere decir que se salvo entonces extraerlo
                if (rows > 0)
                    oHabitacion = GetHabitacionById(pHabitacion.NUM);

                return oHabitacion;
            }
            catch (SqlException sqlError)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.CreateSQLExceptionsErrorDetails(sqlError));
                msg.AppendFormat("SQL             {0}\n", command.CommandText);
                //_MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
            catch (Exception er)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.CreateGenericErrorExceptionDetail(er));
                //_MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
        }

        public Habitacion UpdateHabitacion(Habitacion pHabitacion)
        {
            Habitacion oHabitacion = null;
            string sql = @"usp_UPDATE_Habitacion";



            SqlCommand command = new SqlCommand();
            double rows = 0;

            try
            {

                // Pasar parámetros
                command.Parameters.AddWithValue("@NUM", pHabitacion.NUM);
                command.Parameters.AddWithValue("@Descripcion", pHabitacion.Descripcion);
                command.Parameters.AddWithValue("@Foto", pHabitacion.Foto.ToArray());
                command.Parameters.AddWithValue("Estado", pHabitacion.Estado);
                command.Parameters.AddWithValue("Precio", pHabitacion.Precio);

                command.CommandText = sql;
                command.CommandType = CommandType.StoredProcedure;


                using (IDataBase db = FactoryDataBase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {

                    rows = db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);
                }

                // Si devuelve filas quiere decir que se salvo entonces extraerlo
                if (rows > 0)
                    oHabitacion = GetHabitacionById(pHabitacion.NUM);

                return oHabitacion;
            }
            catch (SqlException sqlError)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.CreateSQLExceptionsErrorDetails(sqlError));
                msg.AppendFormat("SQL             {0}\n", command.CommandText);
                //_MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
            catch (Exception er)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.CreateGenericErrorExceptionDetail(er));
                //_MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
        }
    }
}
