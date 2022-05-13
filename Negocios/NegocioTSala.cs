using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Dao;
using System.Data.SqlClient;

namespace Negocios
{
    public class NegocioTSala
    {
        private DaoTipoSala dao = new DaoTipoSala();

        public SqlDataReader getTSala(String valor, String suc)
        {
            return dao.cargar_t_sala(valor, suc);
        }
    }
}
