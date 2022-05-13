using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Dao
{
    public class DaoVentas
    {
        AccesoDatos ds = new AccesoDatos();
        /*sp ventas*/
        public const String sp_ventas_Fecha = "sp_ventas_Fecha";
        public const String sp_ventas_DniNroVenta = "sp_ventas_DniNroVenta";
        public const String sp_ventas_DniFecha = "sp_ventas_DniFecha";
        public const String sp_ventas_NroVentaFecha = "sp_ventas_NroVentaFecha";
        public const String sp_ventas_DniNroVentaFecha = "sp_ventas_DniNroVentaFecha";
        public const String sp_BajaLogicaVenta = "sp_BajaLogicaVenta";



        public DataTable ObtenerTodasLasVentas()
        {
            return ds.ObtenerTabla("Ventas", "Select ID_Venta[ID_Venta],DNI_Cliente_Venta[Dni cliente],ID_Promocion_Venta[Promoción],Fecha,Total from Ventas WHERE Estado_Venta='Realizada'");
        }
        public DataTable ObtenerVentaPorDni(String Dni)
        {

            return ds.ObtenerTabla("Ventas", "Select * from Ventas WHERE DNI_Cliente_Venta='" + Dni + "'");
        }

        public DataTable ObtenerVentaPorNroVenta(String nroVenta)
        {
            int n_venta = Convert.ToInt32(nroVenta);
            return ds.ObtenerTabla("Ventas", "Select * from Ventas WHERE ID_Venta='" + n_venta + "'");
        }
        public DataTable ObtenerVentasPorSucursal(String Sucursal)
        {

            return ds.ObtenerTabla("Ventas", "Select * From Ventas v INNER JOIN DetalleVentas dv on dv.ID_Venta_DV = v.ID_Venta" +
                " INNER JOIN Sucursales s on s.ID_Sucursal = dv.ID_Sucursal_DV WHERE s.ID_Sucursal = '" + Sucursal + "'");
        }

        public DataTable ObtenerVentasPorFecha(DateTime fecha)
        {

            SqlCommand Comando = new SqlCommand();
            AccesoDatos ad = new AccesoDatos();
            DataTable dt = new DataTable();
            SqlParameter parametros = new SqlParameter();
            parametros = Comando.Parameters.Add("@fecha", SqlDbType.Date);
            parametros.Value = fecha;
            dt = ad.EjecutarSpConParametros(Comando, sp_ventas_Fecha, "Ventas");
            return dt;
        }
        private void parametrosVentasDniNroVenta (ref SqlCommand Comando, Ventas ven)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = Comando.Parameters.Add("@dni", SqlDbType.Char, 8);
            parametros.Value = ven.dni_cliente;

            parametros = Comando.Parameters.Add("@id", SqlDbType.Int);
            parametros.Value = ven.id_venta;

        }

        public DataTable ObtenerVentasPor_Dni_NumVen(String dni, String numVenta)
        {
            
            Ventas ven = new Ventas();
            ven.dni_cliente = dni;
            ven.id_venta = Convert.ToInt32(numVenta);
            SqlCommand Comando = new SqlCommand();
            AccesoDatos ad = new AccesoDatos();
            DataTable dt = new DataTable();
            parametrosVentasDniNroVenta(ref Comando, ven);
            dt = ad.EjecutarSpConParametros(Comando, sp_ventas_DniNroVenta, "Ventas");
            return dt;
        }


        private void parametrosVentasDniFecha (ref SqlCommand Comando, Ventas ven)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = Comando.Parameters.Add("@dni", SqlDbType.Char, 8);
            parametros.Value = ven.dni_cliente;

            parametros = Comando.Parameters.Add("@fecha", SqlDbType.Date);
            parametros.Value = ven.fecha;

        }

        public DataTable ObtenerVentasPor_Dni_Fecha(String dni, DateTime fecha)
        {

            Ventas ven = new Ventas();
            ven.dni_cliente = dni;
            ven.fecha = fecha;
            SqlCommand Comando = new SqlCommand();
            AccesoDatos ad = new AccesoDatos();
            DataTable dt = new DataTable();
            parametrosVentasDniFecha(ref Comando, ven);
            dt = ad.EjecutarSpConParametros(Comando, sp_ventas_DniFecha, "Ventas");
            return dt;
        }
        private void parametrosVentas_NroVenta_Fecha (ref SqlCommand Comando, Ventas ven)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = Comando.Parameters.Add("@id", SqlDbType.Int);
            parametros.Value = ven.id_venta;

            parametros = Comando.Parameters.Add("@fecha", SqlDbType.Date);
            parametros.Value = ven.fecha;

        }

        public DataTable ObtenerVentasPor_NroVenta_Fecha (String nroVenta, DateTime fecha)
        {
            
            Ventas ven = new Ventas();
            ven.id_venta = Convert.ToInt32(nroVenta);
            ven.fecha = fecha;
            SqlCommand Comando = new SqlCommand();
            AccesoDatos ad = new AccesoDatos();
            DataTable dt = new DataTable();
            parametrosVentas_NroVenta_Fecha(ref Comando, ven);
            dt = ad.EjecutarSpConParametros(Comando, sp_ventas_NroVentaFecha, "Ventas");
            return dt;
        }

        private void parametrosVentasDni_NroVenta_Fecha(ref SqlCommand Comando, Ventas ven)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = Comando.Parameters.Add("@dni", SqlDbType.Char,8);
            parametros.Value = ven.dni_cliente;

            parametros = Comando.Parameters.Add("@id", SqlDbType.Int);
            parametros.Value = ven.id_venta; 

            parametros = Comando.Parameters.Add("@fecha", SqlDbType.Date);
            parametros.Value = ven.fecha;

        }

        public DataTable ObtenerVentasPorDni_NroVenta_Fecha(String dni,String nroVenta, DateTime fecha)
        {

            Ventas ven = new Ventas();
            ven.dni_cliente = dni;
            ven.id_venta = Convert.ToInt32(nroVenta);
            ven.fecha = fecha;
            SqlCommand Comando = new SqlCommand();
            AccesoDatos ad = new AccesoDatos();
            DataTable dt = new DataTable();
            parametrosVentasDni_NroVenta_Fecha(ref Comando, ven);
            dt = ad.EjecutarSpConParametros(Comando, sp_ventas_DniNroVentaFecha, "Ventas");
            return dt;
        }
        /*DELETE DE VENTA*/
        private void armarParametrosVenta(ref SqlCommand Comando, Ventas ven)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = Comando.Parameters.Add("@id", SqlDbType.Int);
            parametros.Value = ven.id_venta;
            /*parametros = Comando.Parameters.Add("@estado", SqlDbType.VarChar, 20);
            parametros.Value = ven.estado;*/
            

        }

        // baja de la venta de manera logica 
        public bool BajaVenta(Ventas ven)
        {
       
            SqlCommand Comando = new SqlCommand();
            armarParametrosVenta(ref Comando, ven);
            AccesoDatos ad = new AccesoDatos();
            int filas = ad.sp_Ejecutar(Comando, sp_BajaLogicaVenta);
            if (filas == 1)
                return true;
            else
                return false;
        }

        public Boolean existe_venta(Ventas ven)
        {
            return ds.existe("Select * From Ventas WHERE ID_Venta='"+ven.id_venta+"'");
            
        }

        //Procesa la venta, agrega la venta a la tabla Ventas y queda el estado como 'En proceso'
        public int ProcesarVenta(string correo, string promocion)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosVentaProcesar(ref comando, correo, promocion);
            return ds.sp_Ejecutar(comando, "SP_ProcesarVenta");
        }

        //Arma los parametros para el procedimeiento "SP_ProcesarVenta"
        private void ArmarParametrosVentaProcesar(ref SqlCommand comando, string correo, string promocion)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = comando.Parameters.Add("@Correo_Cliente", SqlDbType.VarChar);
            SqlParametros.Value = correo;
            SqlParametros = comando.Parameters.Add("@ID_Promocion", SqlDbType.VarChar);
            SqlParametros.Value = promocion;
        }

        public bool RealizarVenta()
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosRealizarVenta(ref comando);
            return ds.chequeo_sp(comando, "SP_FinalizarVenta");
        }

        public bool CancelarVenta()
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosCancelarVenta(ref comando);
            return ds.chequeo_sp(comando, "SP_FinalizarVenta");
        }

        public bool CancelarVentaPendiente()
        {
            SqlCommand comando = new SqlCommand();
            return ds.chequeo_sp(comando, "SP_FinalizarVentaPendiente");
        }

        private void ArmarParametrosRealizarVenta(ref SqlCommand comando)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = comando.Parameters.Add("@Estado", SqlDbType.VarChar);
            SqlParametros.Value = "Realizada";
        }

        private void ArmarParametrosCancelarVenta(ref SqlCommand comando)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = comando.Parameters.Add("@Estado", SqlDbType.VarChar);
            SqlParametros.Value = "Cancelada";
        }

    }
}
