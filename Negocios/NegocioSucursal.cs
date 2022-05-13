using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao;
using Entidades;

namespace Negocios
{
    public class NegocioSucursal
    {
        private DaoSucursal dao = new DaoSucursal();

        public SqlDataReader getSucursal()
        {
            return dao.cargar_sucursal();
        }

        public SqlDataReader getSucursalFuncion(String valor)
        {
            return dao.cargar_sucursal_funcion(valor);
        }

        public SqlDataReader getSucursalPelicula(String valor)
        {
            return dao.cargar_sucursal_pelicula(valor);
        }
    }
}
