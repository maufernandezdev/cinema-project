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
    public partial class Registro : System.Web.UI.Page
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
        protected void btnregistro_Click(object sender, EventArgs e)
        {
            int estado;
            Usuario cli = new Usuario();
            NegocioUsuario nc = new NegocioUsuario();
            if (Convert.ToBoolean(Session["Valido"]) == true)
            {
                cli.nombre = ((TextBox)nombre.FindControl("nombre")).Text;
                cli.apellido = ((TextBox)ape.FindControl("ape")).Text;
                cli.dni = ((TextBox)dni.FindControl("dni")).Text;
                cli.contraseña = ((TextBox)contra.FindControl("contra")).Text;
                cli.fecha = Convert.ToDateTime(fecha.Text);
                cli.mail = ((TextBox)email.FindControl("email")).Text;
                estado = nc.AgregarCliente(cli);
                if (estado == 1)
                {
                    lblReg.CssClass = "green-text msglbl";
                    lblReg.Text = "Usuario registrado.";
                }
                else if (estado == 0)
                {
                    lblReg.CssClass = "red-text msglbl";
                    lblReg.Text = "Este usuario ya está registrado.";
                    nombre.Text = "";
                    ape.Text = "";
                    dni.Text = "";
                    email.Text = "";
                    fecha.Text = "";
                }
                Session["Valido"] = null;
            }
        }

        protected void cvContra_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Length > 30)
            {
                args.IsValid = false;
                Session["Valido"] = false;
            }
            else
            {
                args.IsValid = true;
                Session["Valido"] = true;
            }
        }
    }
}