using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTN.Winform.AppAirBnB.Layers.Entities
{
   public class Tarjeta
    {

        public int ID { get; set; }
        public string Tipo { get; set; }

        public override string ToString() => $"{Tipo}";

    }
}
