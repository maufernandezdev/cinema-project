using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dao;
using Entidades;

namespace Negocios
{
    public class NegociosVentas
    {
        DaoVentas dao = new DaoVentas();
        public DataTable getTabla()
        {
            
            return dao.ObtenerTodasLasVentas();
        }
        public DataTable getTablaVentaPorDni(String dni)
        {
            return dao.ObtenerVentaPorDni(dni);

        }
        public DataTable getTablaVentaPorNumVen(String nroVenta)
        {
            return dao.ObtenerVentaPorNroVenta(nroVenta);
        }
        public DataTable getTablaVentaPorSucursal(String sucu)
        {

            return dao.ObtenerVentasPorSucursal(sucu);
        }
        public DataTable getTablaVentaPorFecha(DateTime fecha)
        {
            return dao.ObtenerVentasPorFecha(fecha);

        }

        public DataTable getTablaVentaPorDniNroVenta(String dni,String venta)
        {
            return dao.ObtenerVentasPor_Dni_NumVen(dni, venta);

        }

        public DataTable getTablaVentaPor_DniFecha (String dni,DateTime fecha)
        {
            return dao.ObtenerVentasPor_Dni_Fecha(dni, fecha);
        }

        
            public DataTable getTablaVentaPor_NroVenta_Fecha(String idventa, DateTime fecha)
        {
            return dao.ObtenerVentasPor_NroVenta_Fecha(idventa, fecha);
        }
       

         public DataTable getTablaVentaPor_Dni_NroVenta_Fecha(String dni,String idventa, DateTime fecha)
        {
            return dao.ObtenerVentasPorDni_NroVenta_Fecha(dni,idventa, fecha);
        }

        public bool BorrarVenta(Ventas ven)
        {

            if (dao.BajaVenta(ven))
            {
                return true;
            }
            else
            {
                return false;
            }



        }

        public bool existeVenta(Ventas ven)
        {
            if (dao.existe_venta(ven))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool procesarVenta(string correo, string promocion)
        {
            int op = dao.ProcesarVenta(correo, promocion);
            if (op == 1)
                return true;
            else
                return false;
        }

        public bool realizarVenta()
        {
            return dao.RealizarVenta();
        }

        public bool cancelarVenta()
        {
            return dao.CancelarVenta();
        }

        public bool cancelarVentaPendiente()
        {
            return dao.CancelarVentaPendiente();
        }

    }
}
