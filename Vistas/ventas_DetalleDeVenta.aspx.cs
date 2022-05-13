using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Negocios;

namespace Vistas
{
    public enum Columnas_dv { PELICULA, SUCURSAL, SALA, ASIENTO, PRECIO };
    public enum Columnas_dva { ID_DVA, ARTICULO, CANTIDAD, PRECIO };
    public partial class ventas_DetalleDeVenta : System.Web.UI.Page
    {
        NegociosDetalleDeVenta nv = new NegociosDetalleDeVenta();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["detalles_seleccionados"] = null;
                Session["dev_seleccionados"] = null;
                if (Session["numeroVenta"] != null) 
                {
                    String numVenta = Convert.ToString(Session["numeroVenta"]);
                    CargarTablaVentas(numVenta);
                }
                else 
                {
                    CargarGrid_dv_vacio();
                    CargarGrid_dva_vacio();
                    CargarGrid_TotalDva_vacio();
                    CargarGrid_TotalDv_vacio();
                    CargarGrid_TotalVenta_vacio();
                }
                


            }
           

        }
        /* GRID VACIAS */
        public void CargarGrid_dv_vacio()
        {
            DataTable dv = crearTabla_dv();
            agregarFila_dv(dv);
            grdDetalleVentas.DataSource = dv;
            grdDetalleVentas.DataBind();

        }

        /* GRID DETALLE DE VENTA DE ARTICULOS */
        public void CargarGrid_dva_vacio()
        {

            DataTable dva = crearTabla_dva();
            agregarFila_dva(dva);
            grdDetalleVentas_a.DataSource = dva;
            grdDetalleVentas_a.DataBind();

        }
        public void CargarGrid_TotalDva_vacio()
        {
            DataTable Total_dva = crearTabla_Totaldva();
            agregarFila_Totaldva(Total_dva);
            grdTotalDva.DataSource = Total_dva;
            grdTotalDva.DataBind();

        }

        public void CargarGrid_TotalDv_vacio()
        {
            DataTable Total_dv = crearTabla_Totaldv();
            agregarFila_Totaldv(Total_dv);
            grdTotalDv.DataSource = Total_dv;
            grdTotalDv.DataBind();

        }
        public void CargarGrid_TotalVenta_vacio()
        {
            DataTable TotalVenta = crearTabla_TotalVenta();
            agregarFila_TotalVenta(TotalVenta);
            grdTotalVenta.DataSource = TotalVenta;
            grdTotalVenta.DataBind();

        }
        /*Fin carga tablas vacias*/

        /* CREACIÓN DE LAS TABLAS DE MANERA MANUAL*/

        /*tabla detalle venta*/
        public DataTable crearTabla_dv()
        {

            // se crea columna por columna 
            DataTable dt = new DataTable();
            DataColumn columna = new DataColumn(Columnas_dv.PELICULA.ToString(), System.Type.GetType("System.String"));
            dt.Columns.Add(columna);

            columna = new DataColumn(Columnas_dv.SUCURSAL.ToString(), System.Type.GetType("System.String"));
            dt.Columns.Add(columna);

            columna = new DataColumn(Columnas_dv.SALA.ToString(), System.Type.GetType("System.String"));
            dt.Columns.Add(columna);

            columna = new DataColumn(Columnas_dv.ASIENTO.ToString(), System.Type.GetType("System.String"));
            dt.Columns.Add(columna);

            columna = new DataColumn(Columnas_dv.PRECIO.ToString(), System.Type.GetType("System.String"));
            dt.Columns.Add(columna);

            return dt;
        }

        public void agregarFila_dv(DataTable tabla)
        {
            
            for (int i = 0; i < 3; i++)
            {
                DataRow dr = tabla.NewRow();
                dr[Columnas_dv.PELICULA.ToString()] = "-";
                dr[Columnas_dv.SUCURSAL.ToString()] = "-";
                dr[Columnas_dv.SALA.ToString()] = "-";
                dr[Columnas_dv.ASIENTO.ToString()] = "-";
                dr[Columnas_dv.PRECIO.ToString()] = "$0";
                tabla.Rows.Add(dr);

            }
            


        }


        /*tabla dv articulos*/

        public DataTable crearTabla_dva()
        {
            // se crea columna por columna 
            DataTable dt = new DataTable();
            DataColumn columna = new DataColumn(Columnas_dva.ID_DVA.ToString(), System.Type.GetType("System.String"));
            dt.Columns.Add(columna);
            columna = new DataColumn(Columnas_dva.ARTICULO.ToString(), System.Type.GetType("System.String"));
            dt.Columns.Add(columna);

            columna = new DataColumn(Columnas_dva.CANTIDAD.ToString(), System.Type.GetType("System.String"));
            dt.Columns.Add(columna);

            columna = new DataColumn(Columnas_dva.PRECIO.ToString(), System.Type.GetType("System.String"));
            dt.Columns.Add(columna);

            return dt;
        }

        public void agregarFila_dva(DataTable tabla)
        {
            for (int i = 0; i < 3; i++) 
            {
                DataRow dr = tabla.NewRow();
                dr[Columnas_dva.ID_DVA.ToString()] = "-";
                dr[Columnas_dva.ARTICULO.ToString()] = "-";
                dr[Columnas_dva.CANTIDAD.ToString()] = "0";
                dr[Columnas_dva.PRECIO.ToString()] = "$0";
                tabla.Rows.Add(dr);

            }
                
        }

        /* tablas de total */
        public DataTable crearTabla_Totaldva()
        {

            // se crea columna por columna 
            DataTable dt = new DataTable();
            DataColumn columna = new DataColumn("Total", System.Type.GetType("System.String"));
            dt.Columns.Add(columna);
            return dt;
        }

        public void agregarFila_Totaldva(DataTable tabla)
        {
            DataRow dr = tabla.NewRow();
            dr["Total"] = "$0";
            tabla.Rows.Add(dr);
        }

        public DataTable crearTabla_Totaldv()
        {

            // se crea columna por columna 
            DataTable dt = new DataTable();
            DataColumn columna = new DataColumn("Total", System.Type.GetType("System.String"));
            dt.Columns.Add(columna);
            return dt;
        }

        public void agregarFila_Totaldv(DataTable tabla)
        {
            DataRow dr = tabla.NewRow();
            dr["Total"] = "$0";
            tabla.Rows.Add(dr);
        }

        /*tabla total venta*/
        public DataTable crearTabla_TotalVenta()
        {

            // se crea columna por columna 
            DataTable dt = new DataTable();
            DataColumn columna = new DataColumn("Total venta", System.Type.GetType("System.String"));
            dt.Columns.Add(columna);
            return dt;
        }

        public void agregarFila_TotalVenta(DataTable tabla)
        {
            DataRow dr = tabla.NewRow();
            dr["Total venta"] = "$0";
            tabla.Rows.Add(dr);
        }
        /* fin creacion de tablas manual */
        protected void Buscar_Click(object sender, EventArgs e)
        {
            String nro_venta = txt_num_venta.Text;

            /*ingresa solo nro de venta*/
            
            if (nro_venta !="")
            {
                Session["numeroVenta"] = null;
                CargarTablaVentas(nro_venta);        

            }
            
            /*no selecciono ninguno error*/
            if (nro_venta == "")
            {
                Session["numeroVenta"] = null;
                CargarGrid_dv_vacio();
                CargarGrid_dva_vacio();
                CargarGrid_TotalDva_vacio();
                CargarGrid_TotalDv_vacio();
                CargarGrid_TotalVenta_vacio();
            }
            


        }

        public void CargarTablaVentas(String nro_venta) 
        {
           
            
            /*CARGA LAS TABLAS DETALLE DE VENTA Y DETALLE DE VENTA ARTICULOS*/

            grdDetalleVentas.DataSource = nv.getTablaDetalleVenta_NroVenta(nro_venta);
            grdDetalleVentas.DataBind();
            if(grdDetalleVentas.Rows.Count == 0)
            {
                CargarGrid_dv_vacio();
            }
            grdDetalleVentas_a.DataSource = nv.getTablaDetalleVentaArts_NroVenta(nro_venta);
            grdDetalleVentas_a.DataBind();
            if (grdDetalleVentas_a.Rows.Count == 0)
            {
                CargarGrid_dva_vacio();
            }
            /*suma de la tabla total detalle venta */
            grdTotalDv.DataSource = nv.getTablaTotalDetalleVenta_NroVenta(nro_venta);
            grdTotalDv.DataBind();
            if (grdTotalDv.Rows.Count == 0)
            {
                
                CargarGrid_TotalDv_vacio();
                
            }
            /*suma de la tabla total detalle venta articulos*/
            grdTotalDva.DataSource = nv.getTablaTotalDetalleVentaArt_NroVenta(nro_venta);
            grdTotalDva.DataBind();
            if (grdTotalDva.Rows.Count == 0)
            {
                CargarGrid_TotalDva_vacio();
            }
            /*TOTAL DE LA VENTA*/
            grdTotalVenta.DataSource = nv.getTablaTotalVenta_NroVenta(nro_venta);
            grdTotalVenta.DataBind();
            if(grdTotalVenta.Rows.Count == 0)
            {
                CargarGrid_TotalVenta_vacio();
            }


        }
        
        protected void Volver_Click(object sender, EventArgs e)
        {
            Session["numeroVenta"] = null;
            CargarGrid_dv_vacio();
            CargarGrid_dva_vacio();
            CargarGrid_TotalDva_vacio();
            CargarGrid_TotalDv_vacio();
            CargarGrid_TotalVenta_vacio();
            txt_num_venta.Text = "";
        }
    }   
}