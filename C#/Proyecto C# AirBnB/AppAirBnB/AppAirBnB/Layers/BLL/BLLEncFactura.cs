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
    class BLLEncFactura : IBLLEncFactura
    {

        public int GetCurrentNumeroFactura()
        {
            IDALEncFactura _DALFactura = new DALEncFactura();
            return _DALFactura.GetCurrentNumeroFactura();
        }

        public EncFactura GetFactura(double pNumeroFactura)
        {
            IDALEncFactura _DALFactura = new DALEncFactura();
            return _DALFactura.GetFactura(pNumeroFactura);
        }

        public int GetNextNumeroFactura()
        {
            IDALEncFactura _DALFactura = new DALEncFactura();
            return _DALFactura.GetNextNumeroFactura();
        }

        public EncFactura SaveFactura(EncFactura pFactura)
        {
            IDALEncFactura _IDALEncFactura = new DALEncFactura();

            return _IDALEncFactura.SaveFactura(pFactura);
        }

        

    }
}
