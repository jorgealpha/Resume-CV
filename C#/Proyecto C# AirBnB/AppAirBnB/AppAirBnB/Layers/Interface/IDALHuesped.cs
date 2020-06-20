using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.Winform.AppAirBnB.Layers.Entities;

namespace UTN.Winform.AppAirBnB.Layers.Interface
{
    interface IDALHuesped
    {

        List<Huesped> GetHuespedByFilter(string pDescripcion);
        Huesped GetHuespedById(double pId);

        List<Huesped> GetAllHuesped();

        Huesped SaveHuesped(Huesped oHuesped);

        Huesped UpdateHuesped(Huesped pHuesped);

        bool DeleteHuesped(double pId);

    }
}
