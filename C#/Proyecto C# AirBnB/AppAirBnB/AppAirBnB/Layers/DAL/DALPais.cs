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
    class DALPais : IDALPais
    {
        private static readonly ILog _MyLogControlEventos = LogManager.GetLogger("MyControlEventos");

        private Usuario _Usuario = new Usuario();
        public DALPais()
        {
            _Usuario.Login = Settings.Default.Login;
            _Usuario.Password = Settings.Default.Password;
        }
        public List<Pais> GetAllPais()
        {
            IDataReader reader = null;
            List<Pais> lista = new List<Pais>();
            SqlCommand command = new SqlCommand();

            string sql = @"usp_SELECT_Pais_All";
            command.CommandText = sql;
            command.CommandType = CommandType.StoredProcedure;


            try
            {
                using (IDataBase db = FactoryDataBase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    reader = db.ExecuteReader(command);

                    while (reader.Read())
                    {
                        Pais oPais = new Pais();
                        oPais.ID = int.Parse(reader["ID"].ToString());
                        oPais.Detalle = reader["Detalle"].ToString();
                        lista.Add(oPais);
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

        public Pais GetPaisById(double pId)
        {
            DataSet ds = null;
            Pais oPais = new Pais();
            SqlCommand command = new SqlCommand();

            string sql = @"select * from [Pais] where ID = @ID";

            try
            {
                command.Parameters.AddWithValue("@ID", pId);
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
                        oPais.ID = (int)dr["ID"];
                        oPais.Detalle = dr["Detalle"].ToString();


                    }
                }

                return oPais;
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
