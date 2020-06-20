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
    class BLLHuesped : IBLLHuesped
    {

        public List<Huesped> GetHuespedByFilter(string pDescripcion)
        {
            IDALHuesped _DALHuesped = new DALHuesped();
            return _DALHuesped.GetHuespedByFilter(pDescripcion);
        }

        public Huesped GetHuespedById(double pIdHuesped)
        {
            IDALHuesped _DALHuesped = new DALHuesped();
            return _DALHuesped.GetHuespedById(pIdHuesped);
        }

        public List<Huesped> GetAllHuesped()
        {
            IDALHuesped _DALHuesped = new DALHuesped();
            return _DALHuesped.GetAllHuesped();
        }

        public Huesped SaveHuesped(Huesped oHuesped)
        {


            IDALHuesped _DALHuesped = new DALHuesped();
            Huesped _Huesped = null;

            if (_DALHuesped.GetHuespedById(oHuesped.ID).ID <= 0)
            {
                _Huesped = _DALHuesped.SaveHuesped(oHuesped);

            }
            else
            {
                _Huesped = _DALHuesped.UpdateHuesped(oHuesped);
            }


            return _DALHuesped.GetHuespedById(_Huesped.ID);
        }

        public bool DeleteHuesped(double pId)
        {
            IDALHuesped _DALHuesped = new DALHuesped();
            return _DALHuesped.DeleteHuesped(pId);
        }

    }
}
