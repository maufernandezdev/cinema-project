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


namespace Vistas
{
    public partial class ventas_modif_Ventas : System.Web.UI.Page
    {
        NegociosVentas nv = new NegociosVentas();
        NegociosDetalleDeVenta ndev = new NegociosDetalleDeVenta();
        Ventas ven = new Ventas();
        DetalleVentas dev = new DetalleVentas();
        DetalleVentasArticulo devArt = new DetalleVentasArticulo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Session["numeroVenta"] = null;
                Session["detalles_seleccionados"] = null;
                Session["dev_seleccionados"] = null;
                CargarGrid();
  
                
            }
            
            
        }

        protected void Buscar_Click(object sender, EventArgs e)
        {
            
            String nro_venta = txt_num_venta.Text;
            
                if (nro_venta != "")
                {
                ven.id_venta = Convert.ToInt32(nro_venta);
                if(nv.existeVenta(ven))
                {

                    DataTable tabla_de_ventas = nv.getTablaVentaPorNumVen(nro_venta);
                    grdVentas.DataSource = tabla_de_ventas;
                    grdVentas.DataBind();

                }
                else
                {
                    MessageBox.Show("La venta no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CargarGrid();
                }
                        
                        
                }
                else
                {
                    /*no ingreso nada */
                }
        

        }

        protected void Volver_Click(object sender, EventArgs e)
        {
            grdVentas.PageIndex = 0;
            CargarGrid();
            txt_num_venta.Text = "";
        }

        public void CargarGrid()
        {
            DataTable tablaVentas = nv.getTabla();
            grdVentas.DataSource = tablaVentas;
            grdVentas.DataBind();

        }
        public void CargarGridDetalleDeVenta() 
        {
            DataTable tablaVentas = ndev.getTablaDetalleDeVenta();
            grdVentas.DataSource = tablaVentas;
            grdVentas.DataBind();
        }
        
        protected void grdVentas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdVentas.PageIndex = e.NewPageIndex;
            CargarGrid();
        }

        protected void Borrar_Click(object sender, EventArgs e)
        {
            
            
                if (txt_num_venta.Text != "")
                {

                    int nro_venta = Convert.ToInt32(txt_num_venta.Text);
                    ven.id_venta = nro_venta;
                    dev.id_venta_dv = nro_venta;
                    devArt.id_venta_dva = nro_venta;

                    if (nv.existeVenta(ven))
                    {
                        if (MessageBox.Show("Seguro que desea dar de baja las ventas seleccionadas?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (nv.BorrarVenta(ven))
                            {
                            MessageBox.Show("Venta dada de baja con éxito", "Genial", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ndev.BorrarDetalleVenta(dev);
                            ndev.BorrarDetalleVentaArticulos(devArt);
                            CargarGrid();

                            }
                            else
                            {
                            CargarGrid();
                            MessageBox.Show("La venta no pude ser borrada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                        
                    }
                    else
                    {
                    MessageBox.Show("La venta no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CargarGrid();
                    }


                }
    
        }

            
    }
}