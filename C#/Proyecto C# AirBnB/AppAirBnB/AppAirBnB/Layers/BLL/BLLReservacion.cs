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
    class BLLReservacion : IBLLReservacion
    {

        public int GetNextNumeroReserva()
        {
            IDALReservacion _DALReservacion = new DALReservacion();
            return _DALReservacion.GetNextNumeroReserva();
        }

        public int GetCurrentNumeroReserva()
        {
            IDALReservacion _DALReservacion = new DALReservacion();
            return _DALReservacion.GetCurrentNumeroReserva();
        }

        public void SaveReserva(Reservacion pReserva)
        {
            IDALReservacion _DALReservacion = new DALReservacion();


            _DALReservacion.SaveReserva(pReserva);
        }

        public List<Reservacion> GetAllReservacion()
        {
            IDALReservacion _IDALReservacion = new DALReservacion();
            return _IDALReservacion.GetAllReservacion();
        }

        public Reservacion GetReserva(double pNumeroReserva)
        {

            IDALReservacion _IDALReservacion = new DALReservacion();
            return _IDALReservacion.GetReserva(pNumeroReserva);

        }

        public bool DeleteReserva(double pId)
        {

            IDALReservacion _IDALReservacion = new DALReservacion();
            return _IDALReservacion.DeleteReserva(pId);

        }

    }
}
