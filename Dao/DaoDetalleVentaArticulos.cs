using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;
using System.CodeDom;

namespace Dao
{
    public class DaoDetalleVentaArticulos
    {
        AccesoDatos ds = new AccesoDatos();

        //Procesa el detalle de venta de los articulos, agrega el detalle a la tabla DetalleVentaArticulos y queda el estado como 'En proceso'
        public int ProcesarDetalleVentaArticulos(DetalleVentasArticulo dva)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosDetalleVentaArticulosProcesar(ref comando, dva);
            return ds.sp_Ejecutar(comando, "SP_ProcesarDetalleVentaArticulos");
        }

        //Arma los parametros para el procedimeiento "SP_ProcesarDetalleVentaArticulos"
        private void ArmarParametrosDetalleVentaArticulosProcesar(ref SqlCommand comando, DetalleVentasArticulo dva)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = comando.Parameters.Add("@ID_Articulo", SqlDbType.Char);
            SqlParametros.Value = dva.id_articulo_dva;
            SqlParametros = comando.Parameters.Add("@Cantidad", SqlDbType.Int);
            SqlParametros.Value = dva.cantidad;
            SqlParametros = comando.Parameters.Add("@Precio", SqlDbType.Decimal);
            SqlParametros.Value = dva.precio;
        }

        //Obtiene un DataTable con los datos de los articulos seleccionados por el cliente
        public DataTable ObtenerArticulosProcesados()
        {
            DataTable dt = new DataTable();
            dt = ds.ObtenerTabla("ArticulosVendidos", "SELECT ID_Articulo_DVA, Cantidad FROM DetalleVentaArticulos WHERE ID_Venta_DVA= (SELECT MAX(ID_Venta) FROM Ventas)");
            return dt;
        }


        //Disminuye el stock de cada articulo una vez finalizada la venta
        public bool DisminuirStock(DetalleVentasArticulo dva)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosStockDisminuir(ref comando, dva);
            return ds.chequeo_sp(comando, "SP_DisminuirStock");
        }

        //Arma los parametros para ejecutarel procedimiento "SP_DisminuirStock"
        private void ArmarParametrosStockDisminuir(ref SqlCommand comando, DetalleVentasArticulo dva)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = comando.Parameters.Add("@ID_Articulo", SqlDbType.Char);
            SqlParametros.Value = dva.id_articulo_dva;
            SqlParametros = comando.Parameters.Add("@Cantidad", SqlDbType.Int);
            SqlParametros.Value = dva.cantidad;
        }
    }
}
