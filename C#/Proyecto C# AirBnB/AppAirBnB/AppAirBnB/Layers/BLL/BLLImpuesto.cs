using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.Winform.AppAirBnB.Layers.DAL;
using UTN.Winform.AppAirBnB.Layers.Entities;
using UTN.Winform.AppAirBnB.Layers.Interface;

namespace UTN.Winform.AppAirBnB.Layers.BLL
{
    class BLLImpuesto : IBLLImpuesto
    {

        public Impuesto GetImpuesto()
        {
            IDALImpuesto _DALImpuesto = new DALImpuesto();

            return _DALImpuesto.GetImpuesto();
        }

    }
}
