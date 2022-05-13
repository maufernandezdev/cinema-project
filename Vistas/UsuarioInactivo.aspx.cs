using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;
using Entidades;

namespace Vistas
{
    public partial class UsuarioInactivo : System.Web.UI.Page
    {
        NegocioUsuario nu = new NegocioUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnConfirmIn_Click(object sender, EventArgs e)
        {
            int fila;
            fila = nu.ActivarCliente(Session["Correo_Inac"].ToString(), Session["Contraseña_Inac"].ToString());
            if (fila == 1)
            {
                Session["Correo_Ac"] = Session["Correo_Inac"];
                Session["Contraseña_Ac"] = Session["Contraseña_Inac"];
                Response.Redirect("Inicio.aspx");
            }
        }

        protected void btnRej_Click(object sender, EventArgs e)
        {
            Session["Correo_Inac"] = null;
            Session["Contraseña_Inac"] = null;
            Response.Redirect("Inicio.aspx");
        }
    }
}