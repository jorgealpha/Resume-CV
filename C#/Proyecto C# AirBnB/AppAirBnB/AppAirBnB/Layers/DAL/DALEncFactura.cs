using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.Winform.AppAirBnB.Layers.BLL;
using UTN.Winform.AppAirBnB.Layers.Entities;
using UTN.Winform.AppAirBnB.Layers.Interface;
using UTN.Winform.AppAirBnB.Layers.Persistencia;
using UTN.Winform.AppAirBnB.Properties;
using UTN.Winform.AppAirBnB.Util;

namespace UTN.Winform.AppAirBnB.Layers.DAL
{
    class DALEncFactura : IDALEncFactura
    {
        private static readonly ILog _MyLogControlEventos = LogManager.GetLogger("MyControlEventos");
        Usuario _Usuario = new Usuario();
        public DALEncFactura()
        {
            _Usuario.Login = Settings.Default.Login;
            _Usuario.Password = Settings.Default.Password;
        }
        public EncFactura SaveFactura(EncFactura pFactura)
        {
            EncFactura oFacturaEncabezado = new EncFactura();
            IBLLTarjeta _BLLTarjeta = new BLLTarjeta();

            string sqlEncabezado = string.Empty;
            string sqlDetalle = string.Empty;
            string sqlHabitacion = string.Empty;
            SqlCommand cmdFacturaEncabezado = new SqlCommand();
            SqlCommand cmdFacturaDetalle = new SqlCommand();
            SqlCommand cmdHabitacion = new SqlCommand();
            List<IDbCommand> listaCommands = new List<IDbCommand>();
            
            double rows = 0;

            sqlEncabezado = @"usp_INSERT_EncFactura";


            try
            {
                // Encabezado de factura
                cmdFacturaEncabezado.Parameters.AddWithValue("@IDFactura", pFactura.IDFactura);
                cmdFacturaEncabezado.Parameters.AddWithValue("@IDTarjeta", pFactura._Tarjeta.ID);
                cmdFacturaEncabezado.Parameters.AddWithValue("@Fecha", DateTime.Now.Date);
                cmdFacturaEncabezado.Parameters.AddWithValue("@EstadoFact", pFactura.EstadoFact);

                cmdFacturaEncabezado.CommandText = sqlEncabezado;
                cmdFacturaEncabezado.CommandType = CommandType.StoredProcedure;
                // Agregar a la lista de commands
                listaCommands.Add(cmdFacturaEncabezado);


                // Detalle de factura
                

                // Guardar el detalle de la factura y a la vez rebajar el saldo del producto en Electronico
                foreach (DetFactura pFacturaDetalle in pFactura._ListaFacturaDetalle)
                {
                    sqlDetalle = @"usp_INSERT_DetFactura";

                    
                    cmdFacturaDetalle = new SqlCommand();
                    cmdFacturaDetalle.Parameters.AddWithValue("@IDFactura", GetCurrentNumeroFactura());
                    cmdFacturaDetalle.Parameters.AddWithValue("@Numero", pFacturaDetalle.Numero);
                    cmdFacturaDetalle.Parameters.AddWithValue("@Precio", pFacturaDetalle._Reservacion.Subtotal);
                    cmdFacturaDetalle.Parameters.AddWithValue("@Impuesto", pFacturaDetalle._Impuesto.Porcentaje);
                    cmdFacturaDetalle.Parameters.AddWithValue("@IDReservacion", pFacturaDetalle._Reservacion.ID);

                    cmdFacturaDetalle.CommandText = sqlDetalle;
                    cmdFacturaDetalle.CommandType = CommandType.StoredProcedure;
                    // Agregar a la lista de comandos
                    listaCommands.Add(cmdFacturaDetalle);

                    // Cambiar 
                    //cmdHabitacion = new SqlCommand();
                    //cmdHabitacion.Parameters.AddWithValue("@NUM", pFacturaDetalle._Reservacion._Habitacion.NUM);
                    //cmdHabitacion.Parameters.AddWithValue("@Estado", 1);
                    //sqlHabitacion = @"usp_UPDATE_Habitacion";
                    //cmdHabitacion.CommandText = sqlHabitacion;
                    //cmdHabitacion.CommandType = CommandType.StoredProcedure;
                    //listaCommands.Add(cmdHabitacion);

                }


                using (IDataBase db = FactoryDataBase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {

                    rows = db.ExecuteNonQuery(listaCommands, IsolationLevel.ReadCommitted);
                    
                }

                // Si devuelve filas quiere decir que se salvo entonces extraerlo

                if (rows == 0)
                {
                    throw new Exception("No se pudo  correctamente la factura");
                }
                else
                {
                    //oFacturaEncabezado = GetFactura(pFactura.IDFactura);
                }

                return oFacturaEncabezado;
            }
            catch (SqlException sqlError)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.CreateSQLExceptionsErrorDetails(sqlError));


                msg.AppendFormat("SQL             {0}\n", cmdFacturaEncabezado.CommandText);
                msg.AppendFormat("SQL             {0}\n", cmdFacturaDetalle.CommandText);
                msg.AppendFormat("SQL             {0}\n", cmdHabitacion.CommandText);
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

        /// <summary>
        /// Extraer un consecutivo para asignar el numero de factura
        ///  Investigue como crear secuencias en SQLServer
        /// http://technet.microsoft.com/es-es/library/ff878091.aspx
        /// CREATE SEQUENCE SecuenciaNoFactura  START WITH 1 INCREMENT BY 1 ;
        /// </summary>
        /// <returns>Num. de factura</returns>
        public int GetNextNumeroFactura()
        {

            DataSet ds = null;
            IDbCommand command = new SqlCommand();
            int numeroFactura = 0;
            string sql = @"SELECT NEXT VALUE FOR SequenceNoFactura";

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

        public int GetCurrentNumeroFactura()
        {

            DataSet ds = null;
            IDbCommand command = new SqlCommand();
            int numeroFactura = 0;
            string sql = @"SELECT current_value FROM sys.sequences WHERE name = 'SequenceNoFactura'  ";
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

        public EncFactura GetFactura(double pNumeroFactura)
        {

            EncFactura oFacturaEncabezado = new EncFactura();
            DataSet ds = null;
            IDALHuesped _DALHuesped = new DALHuesped();
            IDALTarjeta _DALTarjeta = new DALTarjeta();
            IDALReservacion _DALReservacion = new DALReservacion();
            IDALEncFactura _DALEncFactura = new DALEncFactura();
            IBLLImpuesto _BLLImpuestotest = new BLLImpuesto();
            SqlCommand command = new SqlCommand();

            string sql = @"";


            sql = @"usp_SELECT_EncFactura_ByID";

            try
            {
                command.Parameters.AddWithValue("@IDFactura", pNumeroFactura);
                command.CommandText = sql;
                command.CommandType = CommandType.StoredProcedure;
                

                using (IDataBase db = FactoryDataBase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    ds = db.ExecuteReader(command, "query");
                }

                // Si devolvió filas
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    oFacturaEncabezado = new EncFactura()
                    {
                        
                        IDFactura = double.Parse(dr["IDFactura"].ToString()),
                        _Tarjeta = _DALTarjeta.GetTarjetaById(int.Parse(dr["IDTarjeta"].ToString())),
                        Fecha = DateTime.Parse(dr["Fecha"].ToString()),
                        EstadoFact = dr["EstadoFact"].ToString()

                    };

                    foreach (var item in ds.Tables[0].Rows)
                    {
                        DetFactura oFacturaDetalle = new DetFactura();
                        oFacturaDetalle._EncFactura = _DALEncFactura.GetFactura(pNumeroFactura);
                        oFacturaDetalle.Numero = int.Parse(dr["Numero"].ToString());
                        oFacturaDetalle.Precio = double.Parse(dr["Precio"].ToString());
                        oFacturaDetalle._Impuesto = _BLLImpuestotest.GetImpuesto();
                        // Enumerar la secuencia
                        oFacturaDetalle._Reservacion = _DALReservacion.GetReserva(pNumeroFactura);
                        // Agregar
                        oFacturaEncabezado.AddDetalle(oFacturaDetalle);
                    }
                }


                return oFacturaEncabezado;
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
