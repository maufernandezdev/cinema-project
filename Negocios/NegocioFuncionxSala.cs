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
    public class NegocioFuncionxSala
    {
        DaoFuncionxSala dao = new DaoFuncionxSala();

        public SqlDataReader getFuncion_Sucursal(String valor)
        {
            return dao.cargar_funcion_sucursal(valor);
        }
    }
}
