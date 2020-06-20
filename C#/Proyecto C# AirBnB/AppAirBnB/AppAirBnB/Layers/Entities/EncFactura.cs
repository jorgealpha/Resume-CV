using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.Winform.AppAirBnB.Layers.Interface;

namespace UTN.Winform.AppAirBnB.Layers.Entities
{
    class EncFactura
    {

        public double IDFactura { get; set; }
        public Tarjeta _Tarjeta { get; set; }
        public DateTime Fecha { get; set; }
        public string EstadoFact { get; set; }

        public List<DetFactura> _ListaFacturaDetalle { get; } = new List<DetFactura>();

        public void AddDetalle(DetFactura pFacturaDetalle)
        {
            _ListaFacturaDetalle.Add(pFacturaDetalle);
        }

        public double GetSubTotal()
        {
            return _ListaFacturaDetalle.Sum(p => p._Reservacion.CantDias * p.Precio);
        }

        public double GetImpuesto()
        {
            
            return _ListaFacturaDetalle.Sum(p => p._Impuesto.Porcentaje) /100 * GetSubTotal();
        }

    }
}
