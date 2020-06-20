using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTN.Winform.AppAirBnB.Layers.Entities
{
    class Reservacion
    {

        public double ID { get; set; }
        public Huesped _Huesped { get; set; }
        public Habitacion _Habitacion { get; set; }
        public DateTime CheckIN { get; set; }
        public DateTime CheckOUT { get; set; }
        public double CantDias { get; set; }
        public double Subtotal { get; set; }


    }
}
