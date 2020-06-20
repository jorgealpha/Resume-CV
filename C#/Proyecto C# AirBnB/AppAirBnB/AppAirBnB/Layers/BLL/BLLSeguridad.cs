using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.Winform.AppAirBnB.Layers.DAL;
using UTN.Winform.AppAirBnB.Layers.Interface;

namespace UTN.Winform.AppAirBnB.Layers.BLL
{
    class BLLSeguridad : IBLLSeguridad
    {

        public void CreateUser(string pUuario, string pContrasena, string pBaseDatos)
        {
            IDALSeguridad _DALSeguridad = new DALSeguridad();
            List<string> lista = new List<string>();
            lista.Add("master");
            lista.Add("model");
            lista.Add("msdb");
            lista.Add("tempdb");

            if (lista.FindAll(p => p.Equals(pBaseDatos, StringComparison.CurrentCultureIgnoreCase)).Count > 0)
            {
                throw new Exception($"No se puede crear Logins en la Base de Datos {pBaseDatos}");
            }

            _DALSeguridad.CreateUser(pUuario, pContrasena, pBaseDatos);

        }

        public IEnumerable<string> GetDataBases()
        {
            IDALSeguridad _DALSeguridad = new DALSeguridad();
            return _DALSeguridad.GetDataBases();
        }

        public IEnumerable<string> GetLoginsXDataBase(string pBaseDatos)
        {
            IDALSeguridad _DALSeguridad = new DALSeguridad();
            return _DALSeguridad.GetLoginsXDataBase(pBaseDatos);
        }

        public IEnumerable<string> GetLogins()
        {
            IDALSeguridad _DALSeguridad = new DALSeguridad();
            return _DALSeguridad.GetLogins();
        }

    }
}
