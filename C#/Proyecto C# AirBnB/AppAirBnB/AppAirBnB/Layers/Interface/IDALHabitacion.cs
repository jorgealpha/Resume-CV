using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.Winform.AppAirBnB.Layers.Entities;
using UTN.Winform.AppAirBnB.Layers.Entities.DTO;

namespace UTN.Winform.AppAirBnB.Layers.Interface
{
    interface IDALHabitacion
    {

        
        List<HabitacionDTO> GetAllHabitacion();
        Habitacion GetHabitacionById(double pId);
        Habitacion SaveHabitacion(Habitacion pHabitacion);       
        Habitacion UpdateHabitacion(Habitacion pHabitacion);
        bool DeleteHabitacion(double pId);
    }
}
