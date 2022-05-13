using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;
using Entidades;
using System.Data;
using System.Windows.Forms;

namespace Vistas
{
    public partial class DetalledeCompra : System.Web.UI.Page
    {
        NegociosDetalleDeVenta ndv = new NegociosDetalleDeVenta();
        NegociosDetalleVentaArticulos ndva = new NegociosDetalleVentaArticulos();
        NegociosPromociones np = new NegociosPromociones();
        NegociosFuncionesxSalasxAsiento nfsa = new NegociosFuncionesxSalasxAsiento();
        NegociosVentas nv = new NegociosVentas();
        
        Articulos art = new Articulos();
        FuncionesxSala fs = new FuncionesxSala();
        FuncionesxSalasxAsiento fsa = new FuncionesxSalasxAsiento();
        DetalleVentasArticulo dva = new DetalleVentasArticulo();
        Ventas ven = new Ventas();
        Usuario usu = new Usuario();
        private String numero;
        protected void Page_Load(object sender, EventArgs e)
        {
            string Pelicula = Session["ID_Pelicula"].ToString();
            string Sucursal = Session["ID_Sucursal"].ToString();
            string Fecha = Session["Fecha"].ToString();
            string Hora = Session["Horario"].ToString();
            string Precio = Session["Precio"].ToString();
            string Correo = Session["Correo_Ac"].ToString();

            fs.Fecha1 = Fecha;
            fs.Hora_Inicio1 = Hora;
            fs.Precio1 = Convert.ToDecimal(Precio);
            fs.ID_Pelicula1 = Pelicula;
            fs.ID_Sucursal1 = Sucursal;
            usu.mail = Correo;

            if (!IsPostBack)
            {
                nfsa.vaciarReservasPrevias();

                Session["Articulos_Seleccionados"] = null;
                Session["Promocion"] = "sinpromo";
                cargarddlAsiento();
            }
        }

        protected void cargarddlAsiento()
        {
                    ddlAsiento.Items.Clear();
                    ddlAsiento.DataSource = nfsa.obtenerAsientosDisponibles(fs);
                    ddlAsiento.DataValueField = "ID_Asiento_FSA";
                    ddlAsiento.DataTextField = "ID_Asiento_FSA";
                    ddlAsiento.DataBind();
                    ddlAsiento.Items.Insert(0, new ListItem("--Asiento", "0000"));
                    ddlAsiento.SelectedValue = "0000";   
            
        }

        protected void ddlAsiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            nfsa.seleccionarAsiento(fs, ddlAsiento.SelectedValue.ToString());

            cargarddlAsiento();
            cargargvAsientos();
            lblAsientosSeleccionados.Visible = true;
        }

        protected void cargargvAsientos()
        {
            gvAsientos.DataSource = nfsa.obtenerAsientosReservados();
            gvAsientos.DataBind();
        }

        protected void gvAsientos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)gvAsientos.Rows[e.RowIndex];
            nfsa.quitarAsientoSeleccionado(gvAsientos.DataKeys[e.RowIndex].Value.ToString());
            cargarddlAsiento();
            cargargvAsientos();
            if (nfsa.obtenerAsientosReservados().Rows.Count == 0)
            {
                lblAsientosSeleccionados.Visible = false;
            }
        }

        protected void gvArticulos_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            DropDownList ddl = (DropDownList)e.Item.FindControl("ddlStock");
            String valor_hf = ((HiddenField)e.Item.FindControl("hfStock")).Value;
            numero = valor_hf;
            ddl.DataBind();
        }

        protected void ODS_ddlStock_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["Stock"] = numero;

        }

        protected void btnAgregar_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "eventoAgregar")
            {
                dva.id_articulo_dva = e.CommandArgument.ToString();
            }
        }

        protected void cargargvArticulos (DataTable dt)
        {
            gvArticulos.DataSource = dt;
            gvArticulos.DataBind();
        }

        protected void lvArticulos_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            DropDownList ddl = (DropDownList)e.Item.FindControl("ddlStock");
            dva.cantidad = Convert.ToInt32(ddl.SelectedItem.Text.ToString());

            System.Web.UI.WebControls.Label lblPrecio = ((System.Web.UI.WebControls.Label)e.Item.FindControl("PrecioLabel"));
            dva.precio = Convert.ToDecimal(lblPrecio.Text.ToString());
            System.Web.UI.WebControls.Label lblNombre = ((System.Web.UI.WebControls.Label)e.Item.FindControl("Nombre_ArticuloLabel"));
            art.nombre_articulo = lblNombre.Text.ToString();
            System.Web.UI.WebControls.Label lblDescripcion = ((System.Web.UI.WebControls.Label)e.Item.FindControl("Descripcion_ArticuloLabel"));
            art.descripcion_articulo = lblDescripcion.Text.ToString();


            if (dva.cantidad > 0)
            {
                if (Session["Articulos_Seleccionados"] == null)
                {
                    Session["Articulos_Seleccionados"] = crearTabla();
                }
                if (!verificarSeleccion((DataTable)Session["Articulos_Seleccionados"], dva))
                {
                    agregarFila((DataTable)Session["Articulos_Seleccionados"], dva, art);

                    cargargvArticulos((DataTable)Session["Articulos_Seleccionados"]);
                    lblArticulosSeleccionados.Visible = true;
                }
                else 
                { 
                    MessageBox.Show("El artículo ya fue seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                }
            }
            else
            {
                MessageBox.Show("Seleccione la cantidad de artículos por favor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public DataTable crearTabla()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID_Articulo");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Descripcion");
            dt.Columns.Add("Cantidad");
            dt.Columns.Add("Precio");

            return dt;
        }

        public void agregarFila(DataTable dt, DetalleVentasArticulo dva, Articulos art)
        {
            DataRow dr = dt.NewRow();
            dr["ID_Articulo"] = dva.id_articulo_dva;
            dr["Nombre"] = art.nombre_articulo;
            dr["Descripcion"] = art.descripcion_articulo;
            dr["Cantidad"] = dva.cantidad;
            dr["Precio"] = dva.precio;
            dt.Rows.Add(dr);
        }

        public bool verificarSeleccion(DataTable dt, DetalleVentasArticulo dva)
        {

            foreach (DataRow row in dt.Rows)
            {
                if (string.Equals(row["ID_Articulo"], dva.id_articulo_dva))
                {
                    return true;
                }
            }
            return false;
        }


        protected void gvArticulos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)gvArticulos.Rows[e.RowIndex];
            string Articulo = Convert.ToString(gvArticulos.DataKeys[row.RowIndex].Values[0]);

            quitarArticuloSeleccionado(Articulo);
            cargargvArticulos((DataTable)Session["Articulos_Seleccionados"]);

        }

        protected void quitarArticuloSeleccionado(string Articulo)
        {
            DataTable dt = (DataTable)Session["Articulos_Seleccionados"];

            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = dt.Rows[i];
                if (dr["ID_Articulo"].ToString() == Articulo)
                    dt.Rows.Remove(dr);
            }
            dt.AcceptChanges();
            if (dt.Rows.Count == 0)
            {
                lblArticulosSeleccionados.Visible = false;
            }
        }

        protected void btnValidar_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "eventoValidar")
            {
                ven.promocion = e.CommandArgument.ToString();
            }
        }

        protected void lvPromociones_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            System.Web.UI.WebControls.TextBox txtPromocion = ((System.Web.UI.WebControls.TextBox)e.Item.FindControl("txtPromocion"));

            if (txtPromocion.Text.ToString() != "")
            {
                if (np.chequearCodigoPromocional(ven.promocion, txtPromocion.Text.ToString()) == false)
                {
                    MessageBox.Show("Codigo inválido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Promoción agregada con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Session["Promocion"] = ven.promocion;
                    lvPromociones.Visible = false;
                    lblPromo.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Ingrese un código por favor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected void btnFinalizar_Click(object sender, EventArgs e)
        {

            if (nfsa.obtenerAsientosReservados().Rows.Count != 0 )
            {
                nv.cancelarVentaPendiente();
                DataTable dt_dv = new DataTable();
                dt_dv = nfsa.obtenerAsientosSeleccionadosParaDetalleVentas();
                DataTable dt_dva = new DataTable();
                dt_dva = (DataTable)Session["Articulos_Seleccionados"];
                string promocion = Session["Promocion"].ToString();

                if (nv.procesarVenta(usu.mail, promocion))
                {
                    //Recorre la tabla procesando cada asiento al detalle de ventas
                    foreach (DataRow row in dt_dv.Rows)
                    {
                        fsa.ID_Funcion_FSA1 = Convert.ToString(row["ID_Funcion_FSA"]);
                        fsa.ID_Pelicula_FSA1 = Convert.ToString(row["ID_Pelicula_FSA"]);
                        fsa.ID_Sucursal_FSA1 = Convert.ToString(row["ID_Sucursal_FSA"]);
                        fsa.ID_Sala_FSA1 = Convert.ToString(row["ID_Sala_FSA"]);
                        fsa.ID_Asiento_FSA1 = Convert.ToString(row["ID_Asiento_FSA"]);
                        fsa.Fecha_FuncionxSalaAsiento1 = Convert.ToString(row["Fecha_FuncionxSalaAsiento"]);

                        ndv.procesarDetalleVentas(fsa, fs.Precio1);
                    }

                    if (dt_dva != null)
                    {
                        //Recorre la tabla procesando cada articulo al detalle de venta de articulos
                        foreach (DataRow row in dt_dva.Rows)
                        {
                            dva.id_articulo_dva = Convert.ToString(row["ID_Articulo"]);
                            dva.cantidad = Convert.ToInt32(row["Cantidad"]);
                            dva.precio = Convert.ToDecimal(row["Precio"]);
                            ndva.procesarDetalleVentaArticulos(dva);
                        }
                    }
                }
                Response.Redirect("FinalizarCompra.aspx");
            }
            else
            {
                MessageBox.Show("Seleccione al menos un asiento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx");
        }
    }
}