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
    class DALTarjeta : IDALTarjeta
    {
        private static readonly ILog _MyLogControlEventos = LogManager.GetLogger("MyControlEventos");

        private Usuario _Usuario = new Usuario();
        public DALTarjeta()
        {
            _Usuario.Login = Settings.Default.Login;
            _Usuario.Password = Settings.Default.Password;
        }

        public List<Tarjeta> GetAllTarjeta()
        {
            IDataReader reader = null;
            List<Tarjeta> lista = new List<Tarjeta>();
            Tarjeta oTarjeta = null;
            SqlCommand command = new SqlCommand();

            try
            {
                string sql = @"usp_SELECT_Tarjeta_All";
                command.CommandText = sql;
                command.CommandType = CommandType.StoredProcedure;

                using (IDataBase db = FactoryDataBase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    reader = db.ExecuteReader(command);
                    // Si devolvió filas
                    while (reader.Read())
                    {
                        oTarjeta = new Tarjeta();
                        oTarjeta.ID = int.Parse(reader["ID"].ToString());
                        oTarjeta.Tipo = reader["Tipo"].ToString();
                        lista.Add(oTarjeta);
                    }
                }
                return lista;

            }
            catch (Exception er)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat("Message        {0}\n", er.Message);
                msg.AppendFormat("Source         {0}\n", er.Source);
                msg.AppendFormat("InnerException {0}\n", er.InnerException);
                msg.AppendFormat("StackTrace     {0}\n", er.StackTrace);
                msg.AppendFormat("TargetSite     {0}\n", er.TargetSite);
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }


        }


        public Tarjeta GetTarjetaById(double pIdTarjeta)
        {
            DataSet ds = null;
            Tarjeta oTarjeta = null;
            SqlCommand command = new SqlCommand();
            string sql = @"usp_SELECT_Tarjeta_ByID";

            try
            {
                command.Parameters.AddWithValue("@ID", pIdTarjeta);
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
                        oTarjeta = new Tarjeta();
                        oTarjeta.ID = int.Parse(dr["ID"].ToString());
                        oTarjeta.Tipo = dr["Tipo"].ToString();

                    }
                }

                return oTarjeta;
            }
            catch (Exception er)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat("Message        {0}\n", er.Message);
                msg.AppendFormat("Source         {0}\n", er.Source);
                msg.AppendFormat("InnerException {0}\n", er.InnerException);
                msg.AppendFormat("StackTrace     {0}\n", er.StackTrace);
                msg.AppendFormat("TargetSite     {0}\n", er.TargetSite);
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
        }
    }
}
