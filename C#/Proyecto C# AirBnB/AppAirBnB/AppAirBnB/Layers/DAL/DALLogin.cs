using log4net;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.Winform.AppAirBnB.Layers.Interface;
using UTN.Winform.AppAirBnB.Layers.Persistencia;
using UTN.Winform.AppAirBnB.Util;

namespace UTN.Winform.AppAirBnB.Layers.DAL
{
    class DALLogin : IDALLogin
    {
        private static readonly ILog _MyLogControlEventos = LogManager.GetLogger("MyControlEventos");

        public bool Login(string pUsuario, string pContrasena)
        {
            StringBuilder conexion = new StringBuilder();

            try
            {

                using (IDataBase db = FactoryDataBase.CreateDataBase(FactoryConexion.CreateConnection(pUsuario, pContrasena)))
                {
                    // Si esto da error es porque el usuario no existe! 
                }

                return true;
            }
            catch (SqlException sqlError)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.CreateSQLExceptionsErrorDetails(sqlError));

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
