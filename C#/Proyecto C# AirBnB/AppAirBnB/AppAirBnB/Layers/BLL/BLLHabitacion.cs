using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.Winform.AppAirBnB.Layers.DAL;
using UTN.Winform.AppAirBnB.Layers.Entities;
using UTN.Winform.AppAirBnB.Layers.Entities.DTO;
using UTN.Winform.AppAirBnB.Layers.Interface;

namespace UTN.Winform.AppAirBnB.Layers.BLL
{
    class BLLHabitacion : IBLLHabitacion
    {
        public bool DeleteHabitacion(double pId)
        {
            IDALHabitacion _IDALHabitacion = new DALHabitacion();
            return _IDALHabitacion.DeleteHabitacion(pId);
        }

        public List<HabitacionDTO> GetAllHabitacion()
        {
            IDALHabitacion _IDALHabitacion = new DALHabitacion();
            return _IDALHabitacion.GetAllHabitacion();
        }

        public Habitacion GetHabitacionById(double pId)
        {
            IDALHabitacion _IDALHabitacion = new DALHabitacion();
            return _IDALHabitacion.GetHabitacionById(pId);
        }

        
        public Habitacion SaveHabitacion(Habitacion pHabitacion)
        {
            IDALHabitacion _IDALHabitacion = new DALHabitacion();
            Habitacion oHabitacion = null;
            if (_IDALHabitacion.GetHabitacionById(pHabitacion.NUM) == null)
                oHabitacion = _IDALHabitacion.SaveHabitacion(pHabitacion);
            else
                oHabitacion = _IDALHabitacion.UpdateHabitacion(pHabitacion);

            return oHabitacion;
        }

        public Habitacion UpdateHabitacion(Habitacion pHabitacion)
        {
            throw new NotImplementedException();
        }
    }
}
