using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocios;

namespace Vistas
{
    public partial class Funciones : System.Web.UI.Page
    {
        FuncionesxSala fs = new FuncionesxSala();
        NegocioFuncionxSala nfs = new NegocioFuncionxSala();
        NegocioTSala nts = new NegocioTSala();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargar_ddl_Sala();
            }


        }

        protected void cargar_ddl_Sala()
        {
            ddlSala.DataSource = nts.getTSala(Session["ID_Pelicula"].ToString(), Session["ID_Sucursal"].ToString());
            ddlSala.DataTextField = "Descripcion_TipoSala";
            ddlSala.DataValueField = "ID_TipoSala";
            ddlSala.DataBind();
            ddlSala.Items.Insert(0, new ListItem("--Seleccione Tipo de Sala--", "0000"));
            ddlSala.SelectedValue = "0000";            
        }


        protected void ddlSala_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ID_t_Sala"] = ddlSala.SelectedItem.Value;
        }

        protected void gvFunciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Session["Correo_Ac"] != null && Session["Contraseña_Ac"] != null)
            {
                lbliniciosesion.CssClass = "d-none";
                GridViewRow row = gvFunciones.SelectedRow;
                string Fecha = Convert.ToString(gvFunciones.DataKeys[row.RowIndex].Values[0]);
                string Hora = Convert.ToString(gvFunciones.DataKeys[row.RowIndex].Values[1]);
                string Precio = Convert.ToString(gvFunciones.DataKeys[row.RowIndex].Values[2]);

                fs.Fecha1 = Fecha;
                fs.Hora_Inicio1 = Hora;
                fs.Precio1 = Convert.ToDecimal(Precio);

                Session["Fecha"] = fs.Fecha1;
                Session["Horario"] = fs.Hora_Inicio1;
                Session["Precio"] = fs.Precio1;
                Response.Redirect("DetalledeCompra.aspx");
            }
            else
            {
                lbliniciosesion.CssClass = "msglogin";
            }
        }
    }
}