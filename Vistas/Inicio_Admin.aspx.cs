using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class Inicio_Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            { 
                Session["numeroVenta"] = null;
                Session["detalles_seleccionados"] = null;
                Session["dev_seleccionados"] = null;
            }
        }
    }
}