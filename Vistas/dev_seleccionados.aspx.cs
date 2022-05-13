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
    public partial class dev_seleccionados : System.Web.UI.Page
    {

        NegociosDetalleDeVenta ndev = new NegociosDetalleDeVenta();
        DetalleVentas dev = new DetalleVentas();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["dev_seleccionados"] != null)
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
            Response.Redirect("baja_detalle_ventas.aspx");
        }

        protected void Borrar_Click(object sender, EventArgs e)
        {
            if (Session["dev_seleccionados"] != null)
            {

                if (MessageBox.Show("Seguro que desea dar de baja los detalles seleccionados?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    try
                    {

                        DataTable dt = new DataTable();
                        dt = (DataTable)Session["dev_seleccionados"];

                        /* recorre la tabla y dando de baja los detalles de ventas*/
                        foreach (DataRow row in dt.Rows)
                        {
                            int id_venta = Convert.ToInt32(row["ID Venta"]);
                            int id_det_venta = Convert.ToInt32(row["ID detalle venta"]);
                            ndev.cancelarDetallesDeVentas(id_venta, id_det_venta);
                            /* resta el dinero a las ventas*/
                            Decimal precio = Convert.ToDecimal(row["Precio"]);
                            /* sumar 0.02 para que la cuenta cierre */
                            ndev.restarSaldoDetalleVentas(id_venta, precio);

                        }
                        MessageBox.Show("Detalles dados de baja con éxito", "Genial", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Session["dev_seleccionados"] = null;
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
            dt = (DataTable)Session["dev_seleccionados"];
            grdDetallesSelect.DataSource = dt;
            grdDetallesSelect.DataBind();
        }

        protected void Cancelar_Click(object sender, EventArgs e)
        {
            Session["dev_seleccionados"] = null;
            CargarGridSeleccion();


        }
    }
}