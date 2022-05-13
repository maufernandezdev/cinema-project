using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class Precios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["ID_Sucursal"] = null;
                Session["ID_Pelicula"] = null;
                Session["ID_t_Sala"] = null;
            }
        }
    }
}