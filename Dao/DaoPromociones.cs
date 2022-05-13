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
    public class DaoPromociones
    {
        AccesoDatos ds = new AccesoDatos();

        //Chequea si el código promocional es válido
        public bool ChequearCodigoPromocional(string Promocion, string Codigo)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosPromocionChequear(ref comando, Promocion, Codigo);
            return ds.chequeo_sp(comando, "SP_ChequearPromocion");
        }


        //Arma los parametros para el procedimeiento "SP_ChequearPromocion"
        private void ArmarParametrosPromocionChequear(ref SqlCommand comando, string promocion, string codigo)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = comando.Parameters.Add("@ID_Promocion", SqlDbType.Char);
            SqlParametros.Value = promocion;
            SqlParametros = comando.Parameters.Add("@Codigo", SqlDbType.Char);
            SqlParametros.Value = codigo;
        }

    }
}
