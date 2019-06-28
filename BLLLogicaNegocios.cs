
using DALDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLLogica
{
    public class BLLLogicaNegocios
    {

        DALDato dalD = new DALDato();


        public BLLLogicaNegocios() {


        }

        public DataTable retornoSucursalCodigo(int codS)
        {

            

            return dalD.retornoSucursalCodigo(codS);

        }

        public DataTable retornoTodo()
        {



            return dalD.retornoTodo();

        }

        public DataTable retornoSucursalEstado(string estadoS)
        {

            return dalD.retornoSucursalEstado(estadoS);

        }

        public void insertar(string desc , int numE , int numP) {


            dalD.insertSucursal(desc,numE,numP);


        }

        public void borrar(int conS) {


            dalD.delete(conS);


        }


        public void update(int conS, string desc, int numE, int numP)
        {


            dalD.update(conS , desc,  numE,  numP);


        }



    }
}
