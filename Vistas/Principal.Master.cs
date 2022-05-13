using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using System.Data;
using Negocios;
using System.Diagnostics;

namespace Vistas
{
    public partial class Principal : System.Web.UI.MasterPage
    {
        NegocioUsuario nu = new NegocioUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Correo_Ac"] != null && Session["Contraseña_Ac"] != null)
                {
                    ddm.CssClass = "d-none";
                    logueado.CssClass = "dropdown-menu dropdown-menu-lg-right mr-5 pl-2 pr-2 text-md-center";
                    lbluser.Text = "Bienvenido/a " + Session["Nombre"].ToString() + "!";
                    lbluser.CssClass = "nombreuser";
                }
                else
                {
                    if(Session["Inactivo"] != null && Session["Inactivo"].ToString() == "Eliminado")
                    {
                        lbluser.Text = "Usuario eliminado.";
                        lbluser.CssClass = "nombreuser";
                    }
                    logueado.CssClass = "d-none";
                    ddm.CssClass = "dropdown-menu dropdown-menu-lg-right mr-5 pl-2 pr-2 text-md-center";
                }

            }

        }

        protected void btnIniciar_Click(object sender, EventArgs e)
        {
            NegocioUsuario nc = new NegocioUsuario();
            DataTable dt = nc.getRegistroUsuario(correo.Text, contraseña.Text);
            if (dt.Rows.Count > 0)
            {
                Session["Estado"] = Convert.ToString(dt.Rows[0][1]);
                Session["Nombre"] = Convert.ToString(dt.Rows[0][2]);
                if (Session["Estado"].ToString() == "Activo")
                {
                    lblerror.Text = "";
                    Session["Correo_Ac"] = correo.Text;
                    Session["Contraseña_Ac"] = contraseña.Text;                    
                    if (Convert.ToInt32(dt.Rows[0][7]) == 1)
                    {
                        Response.Redirect("Inicio.aspx");
                    }
                    else
                    {
                        Response.Redirect("Inicio_admin.aspx");
                    }
                }
                else if (Session["Estado"].ToString() == "Inactivo")
                {
                    Session["Correo_Inac"] = correo.Text;
                    Session["Contraseña_Inac"] = contraseña.Text;
                    Response.Redirect("UsuarioInactivo.aspx");
                }
            }
            else
            {
                lblerror.Text = "Correo o contraseña inválido";
            }
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Session["Correo_Ac"] = null;
            Session["Contraseña_Ac"] = null;
            Session["Inactivo"] = null;
            lbluser.Text = "";
            Response.Redirect("Inicio.aspx");
        }

        protected void btnPerfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("Perfil.aspx");
        }

        protected void btnCompras_Click(object sender, EventArgs e)
        {
            Response.Redirect("FacturasCliente.aspx");
        }
    }
}


