using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class ComprasCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gvFacturas_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvFacturas.SelectedRow;
            Session["ID_Venta"] = gvFacturas.DataKeys[row.RowIndex].Values[0];
            Response.Redirect("DetalleFactura.aspx");
        }
    }
}