using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTN.Winform.AppAirBnB.Layers.Interface
{
    interface IBLLSeguridad
    {

        void CreateUser(string pUuario, string pContrasena, string pBaseDatos);
        IEnumerable<string> GetDataBases();
        IEnumerable<string> GetLoginsXDataBase(string pBaseDatos);
        IEnumerable<string> GetLogins();


    }
}
