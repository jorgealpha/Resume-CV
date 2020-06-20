using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTN.Winform.AppAirBnB.Layers.Interface
{
    interface IBLLLogin
    {

        bool Login(string pUsuario, string pContrasena);

    }
}
