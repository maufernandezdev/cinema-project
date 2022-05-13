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
using System.Linq.Expressions;
using System.Configuration;

namespace Vistas
{
    public partial class peliculas_alta : System.Web.UI.Page
    {
        NegociosPeliculas np = new NegociosPeliculas();
        Peliculas pelicula = new Peliculas();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["numeroVenta"] = null;
                Session["detalles_seleccionados"] = null;
                Session["dev_seleccionados"] = null;
                CargarGrid();
            }
            
        }


        public void CargarGrid()
        {
            DataTable tablaPeliculas = np.getTabla();
            grdPelis.DataSource = tablaPeliculas;
            grdPelis.DataBind();

        }

        protected void grdPelis_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            grdPelis.PageIndex = e.NewPageIndex;
            CargarGrid();
        }
        protected void grdPelis_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdPelis.EditIndex = e.NewEditIndex; // quieren editar la grilla en esta posicion (la que trae e.NewEditIndex)
            CargarGrid();
        }

        protected void grdPelis_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdPelis.EditIndex = -1;
            CargarGrid();
        }


        protected void Buscar_Click(object sender, EventArgs e)
        {
            pelicula.id_pelicula = txt_peli.Text;
            if (np.existePelicula(pelicula)==false)
            {
                MessageBox.Show("La película " + txt_peli.Text + " no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataTable tablaPeliculas = np.getTablaPelis_id(pelicula);
                grdPelis.DataSource = tablaPeliculas;
                grdPelis.DataBind();
                
            }

        }

        protected void Volver_Click(object sender, EventArgs e)
        {
            grdPelis.PageIndex = 0;
            CargarGrid();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            pelicula.id_pelicula = txt_id_peli.Text;
            pelicula.estado = txt_estado_peli.Text;
            pelicula.titulo = txt_titulo_peli.Text;
            if (txt_duracion_peli.Text != "") { pelicula.duracion = Convert.ToInt32(txt_duracion_peli.Text); }
            pelicula.clasificacion = txt_clasif_peli.Text;
            pelicula.url_imagen = txt_url_peli.Text;

            if((cv_id_peli.IsValid==true || Session["id_peli"]==null) && (cv_estado_peli.IsValid==true|| Session["estado"]==null) && (cv_titulo.IsValid==true || Session["titulo"]==null) && (cv_clasif.IsValid==true|| Session["clasif"]==null) && (cv_url.IsValid==true|| Session["url"]==null))
            {
                try
                {
                    
                    if (np.existePelicula(pelicula))
                    {
                        MessageBox.Show("La película " + txt_id_peli.Text + " ya existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (np.agregarPelicula(pelicula))
                        {
                            MessageBox.Show("Se agregó película " + txt_titulo_peli.Text + " con éxito.", "Genial", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            vaciar_campos();
                            grdPelis.PageIndex = 0;
                            CargarGrid();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo agregar " + txt_titulo_peli.Text + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }

                catch (Exception exc)
                {
                    MessageBox.Show("Error al agregar película " + txt_titulo_peli.Text + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else 
            {
                MessageBox.Show("Error al agregar película.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            



        }
        public void vaciar_campos()
        {

            txt_id_peli.Text = "";
            txt_estado_peli.Text = "";
            txt_titulo_peli.Text = "";
            txt_duracion_peli.Text = "";
            txt_clasif_peli.Text = "";
            txt_url_peli.Text = "";

        }

        protected void grdPelis_RowUpdating(object sender, GridViewUpdateEventArgs e)
         {

             bool modificar = true;
             //Buscar los datos del edititemplate
             String s_id_pelicula = ((System.Web.UI.WebControls.Label)grdPelis.Rows[e.RowIndex].FindControl("lbl_id_pelicula")).Text;
             String s_estado = ((System.Web.UI.WebControls.TextBox)grdPelis.Rows[e.RowIndex].FindControl("txt_estado_peli")).Text;
             String s_titulo = ((System.Web.UI.WebControls.TextBox)grdPelis.Rows[e.RowIndex].FindControl("txt_titulo")).Text;
             String s_duracion = ((System.Web.UI.WebControls.TextBox)grdPelis.Rows[e.RowIndex].FindControl("txt_duracion")).Text;
             String s_clasif = ((System.Web.UI.WebControls.TextBox)grdPelis.Rows[e.RowIndex].FindControl("txt_clasificacion")).Text;
             String s_url = ((System.Web.UI.WebControls.TextBox)grdPelis.Rows[e.RowIndex].FindControl("txt_imagen")).Text;
            
            if (s_id_pelicula == "" || s_estado == "" || s_titulo == "" || s_duracion == "" || s_clasif == "" || s_url == "") modificar = false;
            if(modificar==true)
            {
                if (s_id_pelicula.Length > 4) modificar = false;
                if (s_estado.Length > 20) modificar = false;
                if (s_titulo.Length > 50) modificar = false;
                try
                {
                    pelicula.duracion = Convert.ToInt32(s_duracion);
                    if (pelicula.duracion < 0 && pelicula.duracion > 500) modificar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo modificar película.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (s_clasif.Length > 50) modificar = false;
                if (s_url.Length > 50) modificar = false;

            }
            
            pelicula.id_pelicula = s_id_pelicula;
            pelicula.estado = s_estado;
            pelicula.titulo = s_titulo;
            pelicula.clasificacion = s_clasif;
            pelicula.url_imagen = s_url;


            if(modificar==true)
            {
                np.modificarPelicula(pelicula);// se envia el objeto con los nuevos valores y se actualiza en la BD
                grdPelis.EditIndex = -1;
                CargarGrid(); // se vuelve a cargar la grilla actualizada
                MessageBox.Show("Película modificado con éxito.", "Genial", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo modificar la película.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                

              
        }

        protected void grdPelis_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            String Id_Pelicula = ((System.Web.UI.WebControls.Label)grdPelis.Rows[e.RowIndex].FindControl("lbl_id_pelicula")).Text;// se toma en un string el id del producto segun la fila donde se toco el boton eliminar
            pelicula.id_pelicula = Id_Pelicula;
            try
            {

                if (MessageBox.Show("Seguro que desea eliminar la película " + Id_Pelicula + "?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (np.eliminarPelicula(pelicula))
                    {
                        MessageBox.Show("Se elimino con éxito " + Id_Pelicula + ".", "Genial", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarGrid();// se carga de nuevo la grilla sin el registro ya eliminado
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar " + Id_Pelicula + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    CargarGrid();
                }

            }
            
            catch (Exception exc)
            {

                MessageBox.Show("No se pueden eliminar datos relacionados con otras tablas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }


        }

        protected void CustomValidator11_ServerValidate(object source, ServerValidateEventArgs args)
        {
            
            if (args.Value.Length > 4)
            {
                args.IsValid = false;
                Session["id_peli"] = false;
                
            }
            
        }

        protected void CustomValidator12_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Length > 20)
            {
                args.IsValid = false;
                Session["estado"] = false;
            }
        }

        protected void CustomValidator13_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Length > 50)
            {
                args.IsValid = false;
                Session["titulo"] = false;
            }
        }
        protected void CustomValidator14_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Length > 50)
            {
                args.IsValid = false;
                Session["clasif"] = false;
            }
        }
        protected void CustomValidator15_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Length > 50)
            {
                args.IsValid = false;
                Session["url"] = false;
            }
        }
    }
}