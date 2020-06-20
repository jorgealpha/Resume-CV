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
    class DALReservacion : IDALReservacion
    {


        private static readonly ILog _MyLogControlEventos = LogManager.GetLogger("MyControlEventos");
        Usuario _Usuario = new Usuario();
        public DALReservacion()
        {
            _Usuario.Login = Settings.Default.Login;
            _Usuario.Password = Settings.Default.Password;
        }



        public void SaveReserva(Reservacion pReserva)
        {
            
            string sqlReserva = string.Empty;

            SqlCommand cmdReservacion = new SqlCommand();

            SqlCommand cmdHabitacion = new SqlCommand();
            List<IDbCommand> listaCommands = new List<IDbCommand>();
            double rows = 0;



            //pReserva.CheckIN = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

            //pReserva.CheckOUT = (DateTime)System.Data.SqlTypes.SqlDateTime.MaxValue;



            sqlReserva = @"usp_INSERT_Reservacion";

            cmdReservacion.CommandType = CommandType.StoredProcedure;

            try
            {
                // Encabezado de factura
                cmdReservacion.Parameters.AddWithValue("@ID", pReserva.ID);
                cmdReservacion.Parameters.AddWithValue("@IDHuesped", pReserva._Huesped.ID);
                cmdReservacion.Parameters.AddWithValue("@NUMHabitacion", pReserva._Habitacion.NUM);
                cmdReservacion.Parameters.AddWithValue("@CheckIN", pReserva.CheckIN);
                cmdReservacion.Parameters.AddWithValue("@CheckOUT", pReserva.CheckOUT);
                cmdReservacion.Parameters.AddWithValue("@CantDias", pReserva.CantDias);
                cmdReservacion.Parameters.AddWithValue("@Subtotal", pReserva.Subtotal);
                cmdReservacion.CommandText = sqlReserva;
                
                // Agregar a la lista de commands
                listaCommands.Add(cmdReservacion);





                using (IDataBase db = FactoryDataBase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {

                    rows = db.ExecuteNonQuery(listaCommands, IsolationLevel.ReadCommitted);
                }

                // Si devuelve filas quiere decir que se salvo entonces extraerlo

                if (rows == 0)
                {
                    throw new Exception("No se pudo guardar correctamente la Reserva");
                }
                
            }
            catch (SqlException sqlError)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.CreateSQLExceptionsErrorDetails(sqlError));


                msg.AppendFormat("SQL             {0}\n", cmdReservacion.CommandText);

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
     
        public int GetNextNumeroReserva()
        {

            DataSet ds = null;
            IDbCommand command = new SqlCommand();
            int numeroReserva = 0;
            string sql = @"SELECT NEXT VALUE FOR SequenceNoReserva";

            DataTable dt = null;
            try
            {
                command.CommandText = sql;
                command.CommandType = CommandType.Text;

                using (IDataBase db = FactoryDataBase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {

                    ds = db.ExecuteReader(command, "query");
                }

                // Extraer la tabla 
                dt = ds.Tables[0];
                //Extraer el valor que viene en el DataTable 
                numeroReserva = int.Parse(dt.Rows[0][0].ToString());
                return numeroReserva;
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

        public int GetCurrentNumeroReserva()
        {

            DataSet ds = null;
            IDbCommand command = new SqlCommand();
            int numeroFactura = 0;
            string sql = @"SELECT current_value FROM sys.sequences WHERE name = 'SequenceNoReserva'  ";
            DataTable dt = null;
            try
            {

                command.CommandText = sql;
                command.CommandType = CommandType.Text;


                using (IDataBase db = FactoryDataBase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {

                    ds = db.ExecuteReader(command, "query");
                }

                // Extraer la tabla 
                dt = ds.Tables[0];
                //Extraer el valor que viene en el DataTable 
                numeroFactura = int.Parse(dt.Rows[0][0].ToString());
                return numeroFactura;
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

        public Reservacion GetReserva(double pNumeroReserva)
        {

            Reservacion oReservacion = new Reservacion();
            DataSet ds = null;

            IDALHabitacion _DALHabitacion = new DALHabitacion();
            IDALHuesped _DALHuesped = new DALHuesped();

            SqlCommand command = new SqlCommand();

            string sql = @" ";


            sql = @"select * from [Reservacion] where ID = @ID";

            try
            {
                command.CommandText = sql;
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@ID", pNumeroReserva);

                using (IDataBase db = FactoryDataBase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    ds = db.ExecuteReader(command, "query");
                }

                // Si devolvió filas
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    oReservacion = new Reservacion()
                    {
                        ID = (int)dr["ID"],
                        _Huesped = _DALHuesped.GetHuespedById(double.Parse(dr["IDHuesped"].ToString())),
                        _Habitacion = _DALHabitacion.GetHabitacionById(double.Parse(dr["NUMHabitacion"].ToString())),
                        CheckIN = (DateTime)(dr["CheckIN"]),
                        CheckOUT = (DateTime)(dr["CheckIN"]),
                        CantDias = (int)dr["CantDias"],
                        Subtotal = double.Parse(dr["Subtotal"].ToString())
                    };

                    foreach (var item in ds.Tables[0].Rows)
                    {

                        oReservacion.ID = double.Parse(dr["ID"].ToString());
                        oReservacion._Huesped = _DALHuesped.GetHuespedById(double.Parse(dr["IDHuesped"].ToString()));
                        oReservacion._Habitacion = _DALHabitacion.GetHabitacionById(double.Parse(dr["NUMHabitacion"].ToString()));
                        oReservacion.CheckIN = (DateTime)(dr["CheckIN"]);
                        oReservacion.CheckOUT = (DateTime)(dr["CheckOUT"]);
                        oReservacion.CantDias = double.Parse(dr["CantDias"].ToString());
                        oReservacion.Subtotal = double.Parse(dr["Subtotal"].ToString());

                    }
                }

                return oReservacion;
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


        public List<Reservacion> GetAllReservacion()
        {
            DataSet ds = null;
            List<Reservacion> lista = new List<Reservacion>();
            SqlCommand command = new SqlCommand();

            IDALHabitacion _DALHabitacion = new DALHabitacion();
            IDALHuesped _DALHuesped = new DALHuesped();

            string sql = @"usp_SELECT_Reservacion_All";
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
                        Reservacion oReservacion = new Reservacion()
                        {
                            ID = double.Parse(dr["ID"].ToString()),
                            _Huesped = _DALHuesped.GetHuespedById(double.Parse(dr["IDHuesped"].ToString())),
                            _Habitacion = _DALHabitacion.GetHabitacionById(double.Parse(dr["NUMHabitacion"].ToString())),
                            CheckIN = (DateTime)dr["CheckIN"],
                            CheckOUT = (DateTime)dr["CheckOUT"],
                            CantDias = (int)dr["CantDias"],
                            Subtotal = double.Parse(dr["Subtotal"].ToString())


                        };

                        lista.Add(oReservacion);
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


        public bool DeleteReserva(double pId)
        {
            bool retorno = false;
            double rows = 0d;
            SqlCommand command = new SqlCommand();
            try
            {
                /// string sql = @"Delete from  Cliente Where (IdCliente = @IdCliente) ";
                string sql = "usp_DELETE_Reservacion_ByID";
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



    }
}

