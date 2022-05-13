using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class Administrador : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Session["Correo_Ac"] = null;
            Session["Contraseña_Ac"] = null;
            Server.Transfer("Inicio.aspx");
        }
    }
}