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
    public partial class devarts_seleccionados : System.Web.UI.Page
    {

        NegociosDetalleDeVenta ndev = new NegociosDetalleDeVenta();
        DetalleVentasArticulo dva = new DetalleVentasArticulo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["detalles_seleccionados"] != null)
            {

                CargarGridSeleccion();

            }
            else
            {
              /*no hay ventas seleccionadas*/  
            }

        }

        protected void Volver_Click(object sender, EventArgs e)
        {
            Response.Redirect("baja_detalle_ventasArts.aspx");
        }

        protected void Borrar_Click(object sender, EventArgs e)
        {
            if (Session["detalles_seleccionados"] != null) 
            {
                if (MessageBox.Show("Seguro que desea dar de baja los detalles seleccionados?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    try
                    {

                        DataTable dt = new DataTable();
                        dt = (DataTable)Session["detalles_seleccionados"];

                        /* recorre la tabla y dando de baja los detalles de ventas*/
                        foreach (DataRow row in dt.Rows)
                        {
                            int id_venta = Convert.ToInt32(row["ID Venta"]);
                            int id_det_venta = Convert.ToInt32(row["ID detalle venta artículo"]);
                            ndev.cancelarDetallesArts(id_venta, id_det_venta);
                            /* resta el dinero a las ventas*/
                            Double monto = Convert.ToDouble(row["Total"]) + 0.02;
                            Decimal montoFinal = Convert.ToDecimal(monto);
                            /* sumar 0.02 para que la cuenta cierre */
                            ndev.restarSaldoDeVenta(id_venta, montoFinal);

                        }
                        MessageBox.Show("Detalles dados de baja con éxito", "Genial", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Session["detalles_seleccionados"] = null;
                    }

                    catch (Exception exc)
                    {
                        MessageBox.Show("Ocurrio un error y no se pude completar la operación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {

                    CargarGridSeleccion();

                }


            }
            else
            {
                MessageBox.Show("No hay detalles de seleccionados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                

        }

        protected void grdDetallesSelect_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdDetallesSelect.PageIndex = e.NewPageIndex;
            CargarGridSeleccion();
        }
        public void CargarGridSeleccion()
        {
            DataTable dt = new DataTable();
            dt = (DataTable)Session["detalles_seleccionados"];
            grdDetallesSelect.DataSource = dt;
            grdDetallesSelect.DataBind();
        }

        protected void Cancelar_Click(object sender, EventArgs e)
        {
            Session["detalles_seleccionados"] = null;
            CargarGridSeleccion();


        }
    }
}