using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.Winform.AppAirBnB.Layers.Entities;

namespace UTN.Winform.AppAirBnB.Layers.Interface
{
    interface IBLLTarjeta
    {
        List<Tarjeta> GetAllTarjeta();
        Tarjeta GetTarjetaById(double pIdTarjeta);
    }
}
