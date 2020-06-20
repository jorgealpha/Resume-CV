using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.Winform.AppAirBnB.Layers.Entities;
using UTN.Winform.AppAirBnB.Layers.Entities.DTO;

namespace UTN.Winform.AppAirBnB.Layers.Interface
{
    interface IBLLHabitacion
    {
        List<HabitacionDTO> GetAllHabitacion();
        Habitacion SaveHabitacion(Habitacion pHabitacion);
        bool DeleteHabitacion(double pId);
        Habitacion GetHabitacionById(double pId);
        Habitacion UpdateHabitacion(Habitacion pHabitacion);
    }
}
