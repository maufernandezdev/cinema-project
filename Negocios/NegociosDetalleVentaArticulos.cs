using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Negocios
{
    public class NegociosDetalleVentaArticulos
    {
        DaoDetalleVentaArticulos dao = new DaoDetalleVentaArticulos();
        public bool procesarDetalleVentaArticulos(DetalleVentasArticulo dva)
        {
            DaoDetalleVentaArticulos dao = new DaoDetalleVentaArticulos();
            int op = dao.ProcesarDetalleVentaArticulos(dva);
            if (op == 1)
                return true;
            else
                return false;
        }

        public DataTable obtenerArticulosProcesados()
        {
            return dao.ObtenerArticulosProcesados();
        }

        public bool disminuirStock(DetalleVentasArticulo dva)
        {
            return dao.DisminuirStock(dva);
        }
    }
}
