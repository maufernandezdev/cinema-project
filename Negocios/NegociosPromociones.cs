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
    public class NegociosPromociones
    {
        DaoPromociones dao = new DaoPromociones();

        public bool chequearCodigoPromocional(string Promocion, string Codigo)
        {
            return dao.ChequearCodigoPromocional(Promocion, Codigo);
        }

    }
}
