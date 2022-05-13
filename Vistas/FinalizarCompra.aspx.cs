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
    public partial class FinalizarCompra : System.Web.UI.Page
    {
        NegociosDetalleDeVenta ndv = new NegociosDetalleDeVenta();
        NegociosDetalleVentaArticulos ndva = new NegociosDetalleVentaArticulos();
        NegociosFuncionesxSalasxAsiento nfsa = new NegociosFuncionesxSalasxAsiento();
        NegociosVentas nv = new NegociosVentas();

        DetalleVentasArticulo dva = new DetalleVentasArticulo();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPagar_Click(object sender, EventArgs e)
        {
            if (nv.realizarVenta())
            {
                nfsa.actualizarEstadoAsientos();

                DataTable dt_art = new DataTable();
                dt_art = ndva.obtenerArticulosProcesados();

                if (dt_art.Rows != null)
                {
                    //Recorre la tabla disminuyendo el stock de cada articulo comprado
                    foreach (DataRow row in dt_art.Rows)
                    {
                        dva.id_articulo_dva = Convert.ToString(row["ID_Articulo_DVA"]);
                        dva.cantidad = Convert.ToInt32(row["Cantidad"]);

                        ndva.disminuirStock(dva);
                    }
                }
            }
            MessageBox.Show("Se ha completado la compra con éxito", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Response.Redirect("Inicio.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            if (nv.cancelarVenta())
            {
                Response.Redirect("Inicio.aspx");
            }
                
        }
    }
}