using BLLLogica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Interface
{
    public partial class BancoLista : System.Web.UI.Page
    {

        BLLLogicaNegocios nego = new BLLLogicaNegocios();


        protected void Page_Load(object sender, EventArgs e)
        {




        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {


            nego.insertar(this.descripcion.Text,Convert.ToInt32( this.numEmpleados.Text),this.drpprovincia.SelectedIndex+1);


            if (nego.retornoTodo().Rows.Count > 0)
            {
                SucursalGridView.DataSource = nego.retornoTodo();
                SucursalGridView.DataBind();
            }

            
            


        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            nego.borrar(Convert.ToInt32(this.txtBorrar.Text));


            if (nego.retornoTodo().Rows.Count > 0)
            {
                SucursalGridView.DataSource = nego.retornoTodo();
                SucursalGridView.DataBind();
            }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {



        }
    }
}