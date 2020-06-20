using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTN.Winform.AppAirBnB.Layers.Entities
{
    class DetFactura
    {
 
            public EncFactura _EncFactura { set; get; }
            public int Numero { set; get; }
            public double Precio { set; get; }
            public Impuesto _Impuesto { set; get; }
            public Reservacion _Reservacion { set; get; }
       


    }
}
