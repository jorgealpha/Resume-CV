using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALDatos
{
    public class DALDato
    {

        SqlParameter parameter = new SqlParameter();

         
        SqlConnection cnn;
        SqlCommand cmd;

        SqlDataAdapter da;


        public DALDato() {




        }

        public void insertSucursal(string desc,int numEmp,int numP ) {


            //getting Connection String from Web.config file  
            string cnnString = ConfigurationManager.ConnectionStrings["SQL1"].ConnectionString;
            //Method for DataBinding  

            DataTable dt = new DataTable();
            SqlConnection cnn = new SqlConnection(cnnString);

            cmd = new SqlCommand("INSERT INTO Sucursal(desSucursal,numEmpleados,numProvincia,cocEstado,fecIngreso)VALUES(@descrip, @numE, @numP,'ACT',@fecha)",cnn);
            cmd.Parameters.AddWithValue("@descrip", desc);

            cmd.Parameters.AddWithValue("@numE", numEmp);

            cmd.Parameters.AddWithValue("@numP", numP);

            cmd.Parameters.AddWithValue("@fecha", DateTime.Today);


            cnn.Open();

            da = new SqlDataAdapter(cmd);

            dt = new DataTable();
            da.Fill(dt);
            cnn.Close();


        }


        public void delete(int conS) {


            //getting Connection String from Web.config file  
            string cnnString = ConfigurationManager.ConnectionStrings["SQL1"].ConnectionString;
            //Method for DataBinding  

            DataTable dt = new DataTable();
            SqlConnection cnn = new SqlConnection(cnnString);

            cmd = new SqlCommand("DELETE FROM Sucursal WHERE(conSucursal = @conS)", cnn);
            cmd.Parameters.AddWithValue("@conS", conS);

           


            cnn.Open();

            da = new SqlDataAdapter(cmd);

            dt = new DataTable();
            da.Fill(dt);
            cnn.Close();


        }


        public void update(int codS,string desc, int numEmp, int numP)
        {


            //getting Connection String from Web.config file  
            string cnnString = ConfigurationManager.ConnectionStrings["SQL1"].ConnectionString;
            //Method for DataBinding  

            DataTable dt = new DataTable();
            SqlConnection cnn = new SqlConnection(cnnString);

            cmd = new SqlCommand("UPDATE Sucursal SET  desSucursal = @descrip, numEmpleados = @numE , numProvincia = @numP, 'ACT', fecIngreso = @fecha WHERE(conSucursal = @conSucursal)", cnn);

            cmd.Parameters.AddWithValue("@conSucursal", codS);

            cmd.Parameters.AddWithValue("@descrip", desc);

            cmd.Parameters.AddWithValue("@numE", numEmp);

            cmd.Parameters.AddWithValue("@numP", numP);

            cmd.Parameters.AddWithValue("@fecha", DateTime.Today);


            cnn.Open();

            da = new SqlDataAdapter(cmd);

            dt = new DataTable();
            da.Fill(dt);
            cnn.Close();


        }

        public DataTable retornoSucursalCodigo(int codS)
        {

            //getting Connection String from Web.config file  
            string cnnString = ConfigurationManager.ConnectionStrings["SQL1"].ConnectionString;
            //Method for DataBinding  

            DataTable dt = new DataTable();
            SqlConnection cnn = new SqlConnection(cnnString);

            cmd = new SqlCommand("SELECT conSucursal, desSucursal, numEmpleados, numProvincia, cocEstado, fecIngreso FROM  Sucursal WHERE conSucursal = @conSucursal" , cnn);
            cmd.Parameters.AddWithValue("@conSucursal", codS);
            

            cnn.Open();

            da = new SqlDataAdapter(cmd);

            dt = new DataTable();
            da.Fill(dt);
            cnn.Close();

            return dt;

        }

        public DataTable retornoSucursalEstado(string estadoS)
        {

            //getting Connection String from Web.config file  
            string cnnString = ConfigurationManager.ConnectionStrings["SQL1"].ConnectionString;
            //Method for DataBinding  

            DataTable dt = new DataTable();
            SqlConnection cnn = new SqlConnection(cnnString);

            cmd = new SqlCommand("SELECT conSucursal, desSucursal, numEmpleados, numProvincia, cocEstado, fecIngreso FROM  Sucursal WHERE cocEstado = @cocEstado", cnn);
            cmd.Parameters.AddWithValue("@cocEstado", estadoS);
            

            cnn.Open();

            da = new SqlDataAdapter(cmd);

            dt = new DataTable();
            da.Fill(dt);
            cnn.Close();

            return dt;

        }

        public DataTable retornoTodo()
        {

            //getting Connection String from Web.config file  
            string cnnString = ConfigurationManager.ConnectionStrings["SQL1"].ConnectionString;
            //Method for DataBinding  

            DataTable dt = new DataTable();
            SqlConnection cnn = new SqlConnection(cnnString);

            cmd = new SqlCommand("SELECT * FROM  Sucursal ", cnn);
            


            cnn.Open();

            da = new SqlDataAdapter(cmd);

            dt = new DataTable();
            da.Fill(dt);
            cnn.Close();

            return dt;

        }





    }
}
