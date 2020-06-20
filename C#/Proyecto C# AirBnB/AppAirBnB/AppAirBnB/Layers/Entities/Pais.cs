using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTN.Winform.AppAirBnB.Layers.Entities
{
    public class Pais
    {

        public double ID { get; set; }
        public string Detalle { get; set; }

        public override string ToString() => Detalle;

    }
}
