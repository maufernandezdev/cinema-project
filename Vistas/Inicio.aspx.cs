using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocios;

namespace Vistas
{
    public partial class Inicio : System.Web.UI.Page
    {
        NegocioFuncionxSala nfxs = new NegocioFuncionxSala();
        NegocioSucursal ns = new NegocioSucursal();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargar_ddl_suc();
                cargar_ddl_func();
                Session["ID_Sucursal"] = null;
                Session["ID_Pelicula"] = null;
                Session["ID_t_Sala"] = null;

            }
        }

        protected void cargar_ddl_suc()
        {
            ddlSuc.DataSource = ns.getSucursal();
            ddlSuc.DataTextField = "Nombre_Sucursal";
            ddlSuc.DataValueField = "Id_Sucursal";
            ddlSuc.DataBind();
            ddlSuc.Items.Insert(0, new ListItem("--Seleccione Sucursal--", "0000"));
            ddlSuc.SelectedValue = "0000";
        }

        protected void cargar_ddl_func()
        {
            ddlFunc.Items.Insert(0, new ListItem("--Seleccione Película--", "0000"));
            ddlFunc.SelectedValue = "0000";
        }

        protected void ddlSuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlFunc.DataSource = nfxs.getFuncion_Sucursal(ddlSuc.SelectedValue);
            ddlFunc.DataTextField = "Título_Pelicula";
            ddlFunc.DataValueField = "ID_Pelicula";
            ddlFunc.DataBind();
        }

        protected void btnddls_Click(object sender, EventArgs e)
        {
            if (ddlSuc.SelectedItem.Value != "0000" && ddlFunc.SelectedItem.Value != "0000")
            {
                Session["ID_Pelicula"] = ddlFunc.SelectedItem.Value;
                Session["ID_Sucursal"] = ddlSuc.SelectedItem.Value;

                Response.Redirect("Funciones.aspx");
            }
            else
            {
                lblddl.Text = "Seleccione una Sucursal.";
            }
        }

        protected void imgpeli_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "eventoLvPelis")
            {
                Session["ID_Pelicula"] = e.CommandArgument;
                Response.Redirect("FuncionesPelicula.aspx");
            }
        }

        protected void imgpeli2d_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "eventoLvPelis2d")
            {
                Session["ID_t_Sala"] = 1;
                Session["ID_Pelicula"] = e.CommandArgument;
                Response.Redirect("FuncionesPelicula.aspx");
            }
        }
        protected void imgpeli3d_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "eventoLvPelis3d")
            {
                Session["ID_t_Sala"] = 2;
                Session["ID_Pelicula"] = e.CommandArgument;
                Response.Redirect("FuncionesPelicula.aspx");
            }
        }
        protected void imgpeli4d_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "eventoLvPelis4d")
            {
                Session["ID_t_Sala"] = 3;
                Session["ID_Pelicula"] = e.CommandArgument;
                Response.Redirect("FuncionesPelicula.aspx");
            }
        }
        protected void imgpeliPr_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "eventoLvPelisPr")
            {
                Session["ID_t_Sala"] = 4;
                Session["ID_Pelicula"] = e.CommandArgument;
                Response.Redirect("FuncionesPelicula.aspx");
            }
        }
    }
}