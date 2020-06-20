using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTN.Winform.AppAirBnB.Layers.Entities
{
    public class Habitacion
    {

        public double NUM { get; set; }
        public string Descripcion { get; set; }
        public byte[] Foto { get; set; }
        public double Estado { get; set; }
        public double Precio { get; set; }

        public override string ToString() => $" {NUM} ";
    }
}
