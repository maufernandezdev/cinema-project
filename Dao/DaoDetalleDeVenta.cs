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
    public class DaoDetalleDeVenta
    {
        AccesoDatos ds = new AccesoDatos();
        /*sp detalles de ventas */ 
        /*sp detalle de venta articulos */
        public const String sp_totalDva_dni = "sp_totalDva_dni"; /*Suma total detalle de ventas de articulos por dni*/
        public const String sp_totalDva_dninv = "sp_totalDva_dninv"; /*Suma total detalle de ventas de articulos por dni y numero de venta*/
        /*sp detalle de ventas*/
        public const String sp_totalDv_dni = "sp_totalDv_dni"; /*Suma total detalle de ventas por dni*/
        public const String sp_totalDetalleVenta_nv = "sp_totalDetalleVenta_nv"; /*Suma total detalle de ventas por nro venta*/
        public const String sp_totalDv_dninv = "sp_totalDv_dninv"; /*Suma total detalle de ventas por dni y numero de venta*/

        /*sp total ventas*/
        public const String sp_totalventa_dni = "sp_totalventa_dni";
        public const String sp_totalventa_NroVenta = "sp_totalventa_NroVenta";
        public const String sp_totalventa_dninv = "sp_totalventa_dninv";

        /*sp baja logica de detalla de ventas*/
        public const String sp_BajaLogicaDetalleVentaArt = "sp_BajaLogicaDetalleVentaArt";
        public const String sp_BajaLogicaDetalleVenta = "sp_BajaLogicaDetalleVenta";

        public const String sp_bajaDetalleVentasArts = "sp_bajaDetalleVentasArts";
        public const String sp_precioxcant_dva = "sp_precioxcant_dva"; /*trae el el precio por cant de un dva*/
        public const String sp_bajaDetalleVentas = "sp_bajaDetalleVentas";
        public const String sp_restarDetalles = "sp_restarDetalles";
        

        public DataTable ObtenerTodosLosDetallesDeVenta()
        {
            return ds.ObtenerTabla("DetalleVentas", "Select ID_Venta_DV,ID_DetalleVenta,ID_Funcion_DV,ID_Pelicula_DV,ID_Sala_DV,ID_Asiento_DV,Fecha_DV,Precio from DetalleVentas WHERE Estado_DV='Realizado' ORDER BY ID_Venta_DV");
        }

        public DataTable ObtenerTodosLosDetallesDeVentaArts()
        {
            return ds.ObtenerTabla("DetalleVentaArticulos", "Select DISTINCT ID_Venta_DVA[ID Venta],ID_DVA[ID Detalle],ID_Articulo_DVA[ID artículo],Cantidad,Precio from DetalleVentaArticulos WHERE Estado_DVA='Realizado'");
        }
        public DataTable ObtenerDVPorNroVenta(DetalleVentas detalle_venta)
        {
            
            return ds.ObtenerTabla("DetalleVentas", "Select ID_Venta_DV[ID Venta],ID_DetalleVenta[ID Detalle],ID_Funcion_DV[Función],ID_Pelicula_DV[Película],ID_Sala_DV[Sala],ID_Asiento_DV[Asiento],Fecha_DV[Fecha],Precio from DetalleVentas WHERE Estado_DV='Realizado' AND ID_Venta_DV='" + detalle_venta.id_venta_dv + "'");
        }
        public DataTable ObtenerDVAPorNroVenta(DetalleVentasArticulo detalle_venta_art)
        {
            
            return ds.ObtenerTabla("DetalleVentaArticulos", "Select ID_Venta_DVA[ID Venta],ID_DVA[ID Detalle],ID_Articulo_DVA[ID artículo],Cantidad,Precio from DetalleVentaArticulos WHERE Estado_DVA='Realizado' AND ID_Venta_DVA='" + detalle_venta_art.id_venta_dva + "'");
        }

        /*Detalles de ventas por nro de venta */
        public DataTable ObtenerDetallaVenta_numVen(String nroVenta)
        {
            int n_venta = Convert.ToInt32(nroVenta);

            return ds.ObtenerTabla("DetalleVentas", "SELECT p.Título_Pelicula[PELICULA], s.Nombre_Sucursal[SUCURSAL] , dv.ID_Sala_DV[SALA], dv.ID_Asiento_DV[SIENTO],dv.Precio[PRECIO] " +
                "FROM DetalleVentas dv INNER JOIN Peliculas p on p.ID_Pelicula = dv.ID_Pelicula_DV " +
                "INNER JOIN Sucursales s on s.ID_Sucursal = dv.ID_Sucursal_DV WHERE dv.ID_Venta_DV = " + n_venta + "");
        }
        public DataTable ObtenerDetalleVentaArticulos_numVen(String nroVenta)
        {

            int n_venta = Convert.ToInt32(nroVenta);
            return ds.ObtenerTabla("DetalleVentaArticulos", "SELECT dva.ID_DVA, a.Nombre_Articulo[ARTICULO], dva.Cantidad[CANTIDAD], dva.Precio[PRECIO]" +
                " From DetalleVentaArticulos dva INNER JOIN Articulos a on a.ID_Articulo = dva.ID_Articulo_DVA " +
                "WHERE dva.ID_Venta_DVA =" + n_venta + "");

        }

        /*Detalles de ventas por dni */
        public DataTable ObtenerDetalleVentas_dni(String dni)
        {

            return ds.ObtenerTabla("DetalleVentas", "SELECT p.Título_Pelicula, s.Nombre_Sucursal , dv.ID_Sala_DV, dv.ID_Asiento_DV,dv.Precio " +
                "FROM DetalleVentas dv INNER JOIN Ventas v on v.ID_Venta = dv.ID_Venta_DV " +
                "INNER JOIN Peliculas p on p.ID_Pelicula = dv.ID_Pelicula_DV " +
                "INNER JOIN Sucursales s on s.ID_Sucursal = dv.ID_Sucursal_DV WHERE dv.ID_Venta_DV = ID_Venta AND v.DNI_Cliente_Venta = " + dni + "");
        }

        public DataTable ObtenerDetalleVentasArts_dni(String dni)
        {

            return ds.ObtenerTabla("DetalleVentaArticulos", "SELECT dva.ID_DVA, a.Nombre_Articulo, dva.Cantidad, dva.Precio " +
                "From DetalleVentaArticulos dva INNER JOIN Articulos a on a.ID_Articulo = dva.ID_Articulo_DVA" +
                " INNER JOIN Ventas v on v.ID_Venta = dva.ID_Venta_DVA WHERE v.DNI_Cliente_Venta = " + dni + "");

        }
        /*Detalles de ventas por nro de venta y dni */
        public DataTable ObtenerDetalleVentasArts_Dni_NumVen(String dni, String nroVenta)
        {

            int n_venta = Convert.ToInt32(nroVenta);

            return ds.ObtenerTabla("DetalleVentaArticulos", "SELECT dva.ID_DVA, a.Nombre_Articulo, dva.Cantidad, dva.Precio " +
                "From DetalleVentaArticulos dva INNER JOIN Articulos a on a.ID_Articulo = dva.ID_Articulo_DVA " +
                "INNER JOIN Ventas v on v.ID_Venta = dva.ID_Venta_DVA " +
                "WHERE v.DNI_Cliente_Venta = " + dni + " AND dva.ID_Venta_DVA = " + n_venta + "");

        }

        public DataTable ObtenerDetalleVentas_Dni_NumVen(String dni, String nroVenta)
        {

            int n_venta = Convert.ToInt32(nroVenta);


            return ds.ObtenerTabla("DetalleVentas", "SELECT p.Título_Pelicula, s.Nombre_Sucursal , dv.ID_Sala_DV, dv.ID_Asiento_DV,dv.Precio " +
                "FROM DetalleVentas dv INNER JOIN Ventas v on v.ID_Venta = dv.ID_Venta_DV " +
                "INNER JOIN Peliculas p on p.ID_Pelicula = dv.ID_Pelicula_DV " +
                "INNER JOIN Sucursales s on s.ID_Sucursal = dv.ID_Sucursal_DV WHERE v.DNI_Cliente_Venta = " + dni + " AND dv.ID_Venta_DV = " + n_venta + "");


        }
        /* suma de los detalles de ventas */

        /* detalle de articulos */
        /* suma detalle de venta articulos por nro de venta */
        public DataTable SumaDetalleVentasArts_NumVen(String nroVenta)
        {
            int n_venta = Convert.ToInt32(nroVenta);
            return ds.ObtenerTabla("DetalleVentaArticulos", "SELECT SUM(Precio*Cantidad)as[Total]From DetalleVentaArticulos dva " +
                "WHERE dva.ID_Venta_DVA = " + n_venta + "");

        }

        /* suma detalle de venta articulos por dni */
        public DataTable SumaDetalleVentasArts_Dni(String dni)
        {

            SqlCommand Comando = new SqlCommand();
            AccesoDatos ad = new AccesoDatos();
            DataTable dt = new DataTable();
            SqlParameter parametros = new SqlParameter();
            parametros = Comando.Parameters.Add("@dni", SqlDbType.Char, 8);
            parametros.Value = dni;
            dt = ad.EjecutarSpConParametros(Comando, sp_totalDva_dni, "DetalleVentaArticulo");
            return dt;


        }

        /* suma detalle de venta articulos por nro de venta y dni */
        private void parametrosSumarDetalleVentasArts(ref SqlCommand Comando, Usuario cli, Ventas ven)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = Comando.Parameters.Add("@dni", SqlDbType.Char, 8);
            parametros.Value = cli.dni;

            parametros = Comando.Parameters.Add("@nro_venta", SqlDbType.Int);
            parametros.Value = ven.id_venta;

        }

        public DataTable SumaDetalleVentasArts_Dni_NumVen(String dni, String numVenta)
        {
            Usuario cli = new Usuario();
            Ventas ven = new Ventas();
            cli.dni = dni;
            ven.id_venta = Convert.ToInt32(numVenta);
            SqlCommand Comando = new SqlCommand();
            AccesoDatos ad = new AccesoDatos();
            DataTable dt = new DataTable();
            parametrosSumarDetalleVentasArts(ref Comando, cli, ven);
            dt = ad.EjecutarSpConParametros(Comando, sp_totalDva_dninv, "DetalleVentaArticulo");
            return dt;
        }

        /* detalle de ventas*/

        /* suma detalle de venta por dni */
        public DataTable sumaDetalleVenta_Dni(String dni)
        {

            SqlCommand Comando = new SqlCommand();
            AccesoDatos ad = new AccesoDatos();
            DataTable dt = new DataTable();
            SqlParameter parametros = new SqlParameter();
            parametros = Comando.Parameters.Add("@dni", SqlDbType.Char, 8);
            parametros.Value = dni;
            dt = ad.EjecutarSpConParametros(Comando, sp_totalDv_dni, "DetalleVentas");
            return dt;


        }

        /* suma detalle de venta por nro venta */
        public DataTable SumaDetalleVenta_numVen(String nroVenta)
        {
            int id_venta = Convert.ToInt32(nroVenta);
            SqlCommand Comando = new SqlCommand();
            AccesoDatos ad = new AccesoDatos();
            DataTable dt = new DataTable();
            SqlParameter parametros = new SqlParameter();
            parametros = Comando.Parameters.Add("@id", SqlDbType.Int);
            parametros.Value = id_venta;
            dt = ad.EjecutarSpConParametros(Comando, sp_totalDetalleVenta_nv, "DetalleVentas");
            return dt;


        }

        /* suma detalle de venta por nro de venta y dni */
        private void parametrosSumarDetalleVenta(ref SqlCommand Comando, Ventas ven)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = Comando.Parameters.Add("@dni", SqlDbType.Char, 8);
            parametros.Value = ven.dni_cliente;

            parametros = Comando.Parameters.Add("@nro_venta", SqlDbType.Int);
            parametros.Value = ven.id_venta;

        }

        public DataTable SumaDetalleVenta_Dni_NumVen(String dni, String numVenta)
        {

            Ventas ven = new Ventas();
            ven.dni_cliente = dni;
            ven.id_venta = Convert.ToInt32(numVenta);
            SqlCommand Comando = new SqlCommand();
            AccesoDatos ad = new AccesoDatos();
            DataTable dt = new DataTable();
            parametrosSumarDetalleVenta(ref Comando, ven);
            dt = ad.EjecutarSpConParametros(Comando, sp_totalDv_dninv, "DetalleVentas");
            return dt;
        }


        /* suma total de la venta */

        public DataTable SumaTotalVenta_Dni(String dni)
        {

            SqlCommand Comando = new SqlCommand();
            AccesoDatos ad = new AccesoDatos();
            DataTable dt = new DataTable();
            SqlParameter parametros = new SqlParameter();
            parametros = Comando.Parameters.Add("@dni", SqlDbType.Char, 8);
            parametros.Value = dni;
            dt = ad.EjecutarSpConParametros(Comando, sp_totalventa_dni, "Ventas");
            return dt;
        }

        /* suma total venta por nro venta */
        public DataTable SumaTotalVenta_NumVen(String nroVenta)
        {
            int id_venta = Convert.ToInt32(nroVenta);
            SqlCommand Comando = new SqlCommand();
            AccesoDatos ad = new AccesoDatos();
            DataTable dt = new DataTable();
            SqlParameter parametros = new SqlParameter();
            parametros = Comando.Parameters.Add("@id", SqlDbType.Int);
            parametros.Value = id_venta;
            dt = ad.EjecutarSpConParametros(Comando, sp_totalventa_NroVenta, "Ventas");
            return dt;


        }

        /* suma total venta por nro de venta y dni */
        private void parametrosSumarTotalVenta(ref SqlCommand Comando, Ventas ven)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = Comando.Parameters.Add("@dni", SqlDbType.Char, 8);
            parametros.Value = ven.dni_cliente;

            parametros = Comando.Parameters.Add("@nro_venta", SqlDbType.Int);
            parametros.Value = ven.id_venta;

        }

        public DataTable SumaTotalVenta_DniNumVen(String dni, String numVenta)
        {

            Ventas ven = new Ventas();
            ven.dni_cliente = dni;
            ven.id_venta = Convert.ToInt32(numVenta);
            SqlCommand Comando = new SqlCommand();
            AccesoDatos ad = new AccesoDatos();
            DataTable dt = new DataTable();
            parametrosSumarTotalVenta(ref Comando, ven);
            dt = ad.EjecutarSpConParametros(Comando, sp_totalventa_dninv, "Ventas");
            return dt;
        }


        
        /*DELETE DETALLE DE VENTAS*/
        private void armarParametrosDetalleVentas(ref SqlCommand Comando, DetalleVentas dev)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = Comando.Parameters.Add("@id", SqlDbType.Int);
            parametros.Value = dev.id_venta_dv;
            /*parametros = Comando.Parameters.Add("@estado", SqlDbType.VarChar, 20);
            parametros.Value = dev.estado;*/


        }

        // baja detalle de venta de manera logica 
        public bool BajaDetalleVentas(DetalleVentas dev)
        {
            SqlCommand Comando = new SqlCommand();
            armarParametrosDetalleVentas(ref Comando, dev);
            AccesoDatos ad = new AccesoDatos();
            int filas = ad.sp_Ejecutar(Comando, sp_BajaLogicaDetalleVenta);
            if (filas >= 1)
                return true;
            else
                return false;
        }
        private void armarParametrosDetalleVentaArticulos(ref SqlCommand Comando, DetalleVentasArticulo devArt)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = Comando.Parameters.Add("@id", SqlDbType.Int);
            parametros.Value = devArt.id_venta_dva;
            /*parametros = Comando.Parameters.Add("@estado", SqlDbType.VarChar, 20);
            parametros.Value = ven.estado;*/


        }

        // baja de la detalle de venta articulos de manera logica 
        public bool BajaDetalleVentaArticulos(DetalleVentasArticulo devArt)
        {
            SqlCommand Comando = new SqlCommand();
            armarParametrosDetalleVentaArticulos(ref Comando, devArt);
            AccesoDatos ad = new AccesoDatos();
            int filas = ad.sp_Ejecutar(Comando, sp_BajaLogicaDetalleVentaArt);
            if (filas >= 1)
                return true;
            else
                return false;
        }

        public bool CancelarDetArts(int nro_venta, int id_det_venta)
        {

            SqlCommand Comando = new SqlCommand();
            SqlParameter parametros = new SqlParameter();
            parametros = Comando.Parameters.Add("@id", SqlDbType.Int);
            parametros.Value = nro_venta;
            parametros = Comando.Parameters.Add("@id_dva", SqlDbType.Int);
            parametros.Value = id_det_venta;
            AccesoDatos ad = new AccesoDatos();
            int filas = ad.sp_Ejecutar(Comando, sp_bajaDetalleVentasArts);
            if (filas == 1)
                return true;
            else
                return false;
        }

        public bool restarMontoDetVentaArts(int nro_venta, decimal monto)
        {

            SqlCommand Comando = new SqlCommand();
            SqlParameter parametros = new SqlParameter();
            parametros = Comando.Parameters.Add("@id_venta", SqlDbType.Int);
            parametros.Value = nro_venta;
            parametros = Comando.Parameters.Add("@monto", SqlDbType.Decimal);
            parametros.Value = monto;
            AccesoDatos ad = new AccesoDatos();
            int filas = ad.sp_Ejecutar(Comando, sp_restarDetalles);
            if (filas == 1)
                return true;
            else
                return false;
        }
        public bool CancelarDetalleVenta(int nro_venta, int id_det_venta)
        {

            SqlCommand Comando = new SqlCommand();
            SqlParameter parametros = new SqlParameter();
            parametros = Comando.Parameters.Add("@id", SqlDbType.Int);
            parametros.Value = nro_venta;
            parametros = Comando.Parameters.Add("@id_dv", SqlDbType.Int);
            parametros.Value = id_det_venta;
            AccesoDatos ad = new AccesoDatos();
            int filas = ad.sp_Ejecutar(Comando, sp_bajaDetalleVentas);
            if (filas == 1)
                return true;
            else
                return false;
        }
        public bool restarMontoDetalleVenta(int nro_venta, decimal monto)
        {

            SqlCommand Comando = new SqlCommand();
            SqlParameter parametros = new SqlParameter();
            parametros = Comando.Parameters.Add("@id_venta", SqlDbType.Int);
            parametros.Value = nro_venta;
            parametros = Comando.Parameters.Add("@monto", SqlDbType.Decimal);
            parametros.Value = monto;
            AccesoDatos ad = new AccesoDatos();
            int filas = ad.sp_Ejecutar(Comando, sp_restarDetalles);
            if (filas == 1)
                return true;
            else
                return false;
        }

        //Procesa el detalle de venta, agrega el detalle a la tabla DetalleVentas y queda el estado como 'En proceso'
        public int ProcesarDetalleVentas(FuncionesxSalasxAsiento fsa, decimal precio)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosDetalleVentasProcesar(ref comando, fsa, precio);
            return ds.sp_Ejecutar(comando, "SP_ProcesarDetalleVentas");
        }

        //Arma los parametros para el procedimeiento "SP_ProcesarDetalleVentas"
        private void ArmarParametrosDetalleVentasProcesar(ref SqlCommand comando, FuncionesxSalasxAsiento fsa, decimal precio)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = comando.Parameters.Add("@ID_Funcion", SqlDbType.Char);
            SqlParametros.Value = fsa.ID_Funcion_FSA1;
            SqlParametros = comando.Parameters.Add("@ID_Pelicula", SqlDbType.Char);
            SqlParametros.Value = fsa.ID_Pelicula_FSA1;
            SqlParametros = comando.Parameters.Add("@ID_Sucursal", SqlDbType.Char);
            SqlParametros.Value = fsa.ID_Sucursal_FSA1;
            SqlParametros = comando.Parameters.Add("@ID_Sala", SqlDbType.Char);
            SqlParametros.Value = fsa.ID_Sala_FSA1;
            SqlParametros = comando.Parameters.Add("@ID_Asiento", SqlDbType.Char);
            SqlParametros.Value = fsa.ID_Asiento_FSA1;
            SqlParametros = comando.Parameters.Add("@Fecha", SqlDbType.Date);
            SqlParametros.Value = fsa.Fecha_FuncionxSalaAsiento1;
            SqlParametros = comando.Parameters.Add("@Precio", SqlDbType.Decimal);
            SqlParametros.Value = precio;
        }
    }
}
