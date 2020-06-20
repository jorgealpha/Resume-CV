using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.Winform.AppAirBnB.Layers.Entities;

namespace UTN.Winform.AppAirBnB.Layers.Interface
{
    interface IBLLHuesped
    {

        List<Huesped> GetHuespedByFilter(string pDescripcion);
        Huesped GetHuespedById(double pIdHuesped);

        List<Huesped> GetAllHuesped();

        Huesped SaveHuesped(Huesped oHuesped);

        bool DeleteHuesped(double pId);

    }
}
