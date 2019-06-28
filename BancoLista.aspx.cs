using BLLLogica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Interface
{
    public partial class BancoDetalle : System.Web.UI.Page
    {

        BLLLogicaNegocios nego = new BLLLogicaNegocios();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            if (Convert.ToInt32(this.codBusqueda.Text) != 0 ) {

                if (nego.retornoSucursalCodigo(Convert.ToInt32(this.codBusqueda.Text)).Rows.Count > 0)
                {
                    SucursalListaGridView.DataSource = nego.retornoSucursalCodigo(Convert.ToInt32(this.codBusqueda.Text));
                    SucursalListaGridView.DataBind();
                }

            }
            else {

                //retornoSucursalEstado(estadoS);

                if (nego.retornoSucursalEstado((this.txtEstado).Text).Rows.Count > 0)
                {
                    SucursalListaGridView.DataSource = nego.retornoSucursalEstado((this.txtEstado).Text);
                    SucursalListaGridView.DataBind();
                }

            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Response.Redirect("BancoDET.aspx");

        }
    }
}