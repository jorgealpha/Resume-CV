using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTN.Winform.AppAirBnB.Layers.Entities
{
    public class Huesped
    {

        public double ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public Pais _Pais { get; set; }

        public override string ToString() => $"{ID} {Nombre} {Apellido1}";

    }
}
