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
    class BLLTarjeta : IBLLTarjeta
    {
        public List<Tarjeta> GetAllTarjeta()
        {
            IDALTarjeta _DALTarjeta = new DALTarjeta();
            return _DALTarjeta.GetAllTarjeta();
        }

        public Tarjeta GetTarjetaById(double pIdTarjeta)
        {
            IDALTarjeta _DALTarjeta = new DALTarjeta();
            return _DALTarjeta.GetTarjetaById(pIdTarjeta);

        }
    }
}
