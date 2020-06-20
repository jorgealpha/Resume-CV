using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.Winform.AppAirBnB.Layers.DAL;
using UTN.Winform.AppAirBnB.Layers.Entities;
using UTN.Winform.AppAirBnB.Layers.Interface;

namespace UTN.Winform.AppAirBnB.Layers.BLL
{
    class BLLPais : IBLLPais
    {

        public List<Pais> GetAllPais()
        {
            IDALPais _DALPais = new DALPais();

            return _DALPais.GetAllPais();

        }

        public Pais GetPaisById(double pId)
        {
            IDALPais _DALPais = new DALPais();

            return _DALPais.GetPaisById(pId);
        }
    }
}
