using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;
using System.Data;
using System.Data.SqlClient;
using Entidades;
using System.Windows.Forms;
using System.Configuration;

namespace Vistas
{
    public partial class articulos_alta : System.Web.UI.Page
    {
        NegociosArticulos na = new NegociosArticulos();
        Articulos art = new Articulos();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Session["dev_seleccionados"] = null;
                Session["numeroVenta"] = null;
                Session["detalles_seleccionados"] = null;
                lbl_campoObligatorio.Visible = false;
                
                CargarGrid();
            }
            
        }
        public void CargarGrid()
        {
            DataTable tablaArticulos = na.getTabla();
            grdArticulos.DataSource = tablaArticulos;
            grdArticulos.DataBind();

        }
        protected void grdArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdArticulos.PageIndex = e.NewPageIndex;
            CargarGrid();
        }

        protected void grdArticulos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdArticulos.EditIndex = e.NewEditIndex; // quieren editar la grilla en esta posicion (la que trae e.NewEditIndex)
            CargarGrid();
        }

        protected void grdArticulos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdArticulos.EditIndex = -1;
            CargarGrid();
        }

        protected void Buscar_Click(object sender, EventArgs e)
        {
            if(txt_art.Text!="")
            {
                art.id_articulo = txt_art.Text;
                if (na.existeArticulo(art))
                {
                    lbl_campoObligatorio.Visible = false;
                    DataTable tablaArticulos = na.getTabla_idArticulo(art);
                    grdArticulos.DataSource = tablaArticulos;
                    grdArticulos.DataBind();
                }
                else
                {
                    MessageBox.Show("El artículo no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CargarGrid();
                }
            }
            
            else
            {
                lbl_campoObligatorio.Visible = true;
                CargarGrid();
            }
        }

        protected void Volver_Click(object sender, EventArgs e)
        {
            lbl_campoObligatorio.Visible = false;
            grdArticulos.PageIndex = 0;
            CargarGrid();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            bool flag = false;
            art.id_articulo = txt_id_articulo.Text;
            art.estado_articulo = txt_estado_articulo.Text;
            art.nombre_articulo = txt_nombre_articulo.Text;
            art.descripcion_articulo = txt_descripcion_art.Text;
            try 
            {
                art.precio = Convert.ToDecimal(txt_precio_art.Text);
            }
            catch (Exception exc) 
            {
                flag = true;
                MessageBox.Show("Ingrese valores decimales con coma", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (txt_precio_art.Text.Contains(".")) { flag = true; }
            art.imagen_articulo = txt_url_articulo.Text;
            if (cv_id_art.IsValid==true&& cv_estado_art.IsValid == true && cv_nombre_art.IsValid == true && cv_desc_art.IsValid == true && cv_url_art.IsValid == true && flag==false)
            {

                try
                {

                    if (na.existeArticulo(art))
                    {
                        MessageBox.Show("El artículo " + txt_id_articulo.Text + " ya existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (na.agregarArticulo(art))
                        {
                            MessageBox.Show("El artículo se agrego " + txt_nombre_articulo.Text + " con éxito.", "Genial", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            vaciarCampos();
                            CargarGrid();

                        }
                        else
                        {
                            MessageBox.Show("Error al agregar artículo " + txt_nombre_articulo.Text + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }

                }

                catch (Exception exc)
                {
                    MessageBox.Show("Error al agregar artículo " + txt_nombre_articulo.Text + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Error al agregar artículo.","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }
        protected void grdArticulos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            bool modificar = true;
            //Buscar los datos del edititemplate
            String s_id_articulo = ((System.Web.UI.WebControls.Label)grdArticulos.Rows[e.RowIndex].FindControl("lbl_id_articulo")).Text;
            String s_estado = ((System.Web.UI.WebControls.TextBox)grdArticulos.Rows[e.RowIndex].FindControl("txt_estado_art")).Text;
            String s_nombre = ((System.Web.UI.WebControls.TextBox)grdArticulos.Rows[e.RowIndex].FindControl("txt_nombre")).Text;
            String s_descripcion = ((System.Web.UI.WebControls.TextBox)grdArticulos.Rows[e.RowIndex].FindControl("txt_descripcion")).Text;
            String s_precio = ((System.Web.UI.WebControls.TextBox)grdArticulos.Rows[e.RowIndex].FindControl("txt_precio")).Text;
            String s_url = ((System.Web.UI.WebControls.TextBox)grdArticulos.Rows[e.RowIndex].FindControl("txt_imagen")).Text;

            if (s_id_articulo == "" || s_estado == "" || s_nombre == "" || s_descripcion == "" || s_precio == "" || s_url == "") modificar = false;
            
            art.id_articulo = s_id_articulo;
            art.estado_articulo = s_estado;
            art.nombre_articulo = s_nombre;
            art.descripcion_articulo = s_descripcion;
            art.precio = Convert.ToDecimal(s_precio);
            art.imagen_articulo = s_url;
            /*validar tamaño de strings*/

            if(modificar==true)
            {
                na.modificarArticulo(art);// se envia el objeto con los nuevos valores y se actualiza en la BD
                grdArticulos.EditIndex = -1;
                CargarGrid(); // se vuelve a cargar la grilla actualizada
                MessageBox.Show("Artículo modificado con éxito.", "Genial", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo modificar el artículo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
             
        }

        protected void grdArticulos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            String idArticulo = ((System.Web.UI.WebControls.Label)grdArticulos.Rows[e.RowIndex].FindControl("lbl_id_articulo")).Text;// se toma en un string el id del producto segun la fila donde se toco el boton eliminar
            art.id_articulo = idArticulo;
            String nombreArt = ((System.Web.UI.WebControls.Label)grdArticulos.Rows[e.RowIndex].FindControl("lbl_nombre")).Text;// se toma en un string el id del producto segun la fila donde se toco el boton eliminar
            
            try 
            {
                if(MessageBox.Show("Seguro que desea eliminar el artículo "+nombreArt+"?", "Eliminar",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)            
                {
                    if (na.eliminarArticulo(art))
                    {
                        MessageBox.Show("El artículo "+nombreArt+" se eliminó con éxito.", "Genial", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        grdArticulos.PageIndex = 0; /* va a la pagina 1 */
                        CargarGrid();// se carga de nuevo la grilla sin el registro ya eliminado
                    }
                    else 
                    {
                        MessageBox.Show("No se pudo completar la operación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {   
                    grdArticulos.PageIndex = 0; /* va a la pagina 1 */
                    CargarGrid();// se carga de nuevo la grilla sin el registro ya eliminado
                }
                
            }
            catch(Exception exc)
            {
                
                MessageBox.Show("No se pueden eliminar datos relacionados con otras tablas.","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
                
            }
            

        }

        public void vaciarCampos()
        {

            txt_id_articulo.Text = "";
            txt_estado_articulo.Text = "";
            txt_nombre_articulo.Text = "";
            txt_descripcion_art.Text = "";
            txt_precio_art.Text = "";
            txt_url_articulo.Text="";
            txt_stock.Text = "";

        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if(args.Value.Length > 4)
            {
                args.IsValid = false;
            }
        }

        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Length > 20)
            {
                args.IsValid = false;
            }
        }

        protected void CustomValidator3_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Length > 30)
            {
                args.IsValid = false;
            }
        }

        protected void CustomValidator4_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Length > 50)
            {
                args.IsValid = false;
            }
        }

        protected void CustomValidator6_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Length > 50)
            {
                args.IsValid = false;
            }
        }
    }
}