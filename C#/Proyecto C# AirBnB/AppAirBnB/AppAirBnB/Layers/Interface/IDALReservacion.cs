using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.Winform.AppAirBnB.Layers.Entities;

namespace UTN.Winform.AppAirBnB.Layers.Interface
{
    interface IDALReservacion
    {

        int GetNextNumeroReserva();
        int GetCurrentNumeroReserva();
        void SaveReserva(Reservacion pReserva);
        List<Reservacion> GetAllReservacion();
        Reservacion GetReserva(double pNumeroReserva);
        bool DeleteReserva(double pId);

    }
}
