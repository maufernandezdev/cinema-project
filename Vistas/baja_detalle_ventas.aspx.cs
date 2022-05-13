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

namespace Vistas
{
    public partial class baja_detalle_ventas : System.Web.UI.Page
    {

        NegociosDetalleDeVenta ndev = new NegociosDetalleDeVenta();
        DetalleVentas dev = new DetalleVentas();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                Session["detalles_seleccionados"] = null;
                Session["numeroVenta"] = null;
                

            }
        }
        public void CargarGridDetalleDeVenta()
        {

            grdDetalleVentas.DataSourceID = "dsDetalleVentas";
            grdDetalleVentas.DataBind();

        }

        protected void Buscar_Click(object sender, EventArgs e)
        {
            String nro_venta = txt_num_venta.Text;

            if (nro_venta != "")
            {
                
                grdDetalleVentas.DataSourceID = "dsDetalleVentas_nv";
                grdDetalleVentas.DataBind();

            }
            else
            {
                /*no ingreso nada */
            }
        }

        protected void Volver_Click(object sender, EventArgs e)
        {
            grdDetalleVentas.PageIndex = 0;
            CargarGridDetalleDeVenta();
            txt_num_venta.Text = "";
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
                    grdDetalleVentas.PageIndex = 0;
                    CargarGridDetalleDeVenta();
                    txt_num_venta.Text = "";

                }
            }
            else
            {
                MessageBox.Show("No hay detalles de seleccionados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        protected void grdDetalleVentas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdDetalleVentas.PageIndex = e.NewPageIndex;
            CargarGridDetalleDeVenta();
        }

       
        public DataTable crearTabla()
        {

            // se crea columna por columna 
            DataTable dt = new DataTable();
            DataColumn columna = new DataColumn("ID Venta", System.Type.GetType("System.String"));
            dt.Columns.Add(columna);

            columna = new DataColumn("ID detalle venta", System.Type.GetType("System.String"));
            dt.Columns.Add(columna);

            columna = new DataColumn("Fecha", System.Type.GetType("System.String"));
            dt.Columns.Add(columna);

            columna = new DataColumn("Precio", System.Type.GetType("System.String"));
            dt.Columns.Add(columna);

            return dt;
        }

        public void agregarFila(DataTable tabla, String idVenta, String idDetVenta, String fecha, String precio)
        {
            DataRow dr = tabla.NewRow();
            dr["ID Venta"] = idVenta;
            dr["ID detalle venta"] = idDetVenta;
            dr["Fecha"] = fecha;
            dr["Precio"] = precio;
            
            tabla.Rows.Add(dr);

        }

        public bool verificarSeleccion(DataTable tabla, String id, String idDet)
        {

            foreach (DataRow row in tabla.Rows)
            {

                if (string.Equals(row["ID Venta"], id) && string.Equals(row["ID detalle venta"], idDet))
                {
                    return true;
                }


            }


            return false;
        }

        protected void Seleccion_Click(object sender, EventArgs e)
        {
            Response.Redirect("dev_seleccionados.aspx");
        }

        protected void grdDetalleVentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = grdDetalleVentas.SelectedRow;

            String s_idVenta = Convert.ToString(grdDetalleVentas.DataKeys[row.RowIndex].Values[0]);
            String s_IdDetalleVenta = Convert.ToString(grdDetalleVentas.DataKeys[row.RowIndex].Values[1]);
            String s_fecha = Convert.ToString(grdDetalleVentas.DataKeys[row.RowIndex].Values[2]);
            String s_precio = Convert.ToString(grdDetalleVentas.DataKeys[row.RowIndex].Values[3]);

            if (Session["dev_seleccionados"] == null)
            {
                Session["dev_seleccionados"] = crearTabla();
            }
            if (!verificarSeleccion((DataTable)Session["dev_seleccionados"], s_idVenta, s_IdDetalleVenta))
            {
                agregarFila((DataTable)Session["dev_seleccionados"], s_idVenta, s_IdDetalleVenta, s_fecha, s_precio);

            }
            else { MessageBox.Show("El detalle ya fue seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        
    }
}