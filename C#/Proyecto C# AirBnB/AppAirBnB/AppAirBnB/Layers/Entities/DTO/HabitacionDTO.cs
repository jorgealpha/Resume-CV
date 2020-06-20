using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTN.Winform.AppAirBnB.Layers.Entities.DTO
{
    class HabitacionDTO
    {

        public double NUM { get; set; }
        public string Descripcion { get; set; }
        public byte[] Foto { get; set; }
        public double Estado { get; set; }
        public double Precio { get; set; }

       
    }
}
