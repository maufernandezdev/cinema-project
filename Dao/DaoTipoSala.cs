using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Dao
{

    public class DaoTipoSala
    {
        private String consulta;
        private SqlDataReader dr;
        private AccesoDatos acc = new AccesoDatos();
        private SqlCommand cmd;

        public SqlDataReader cargar_t_sala(String valor, String suc)
        {
            consulta = "SELECT DISTINCT ID_TipoSala, Descripcion_TipoSala FROM TipoSalas " +
                "INNER JOIN SALAS ON ID_TipoSala_Sala = ID_TipoSala " +
                "INNER JOIN FuncionesxSala ON ID_Sala_FuncionxSala = ID_Sala " +
                "WHERE ID_Pelicula_FuncionxSala = '" + valor + "' AND ID_Sucursal_FuncionxSala = '" + suc + "'";
            cmd = new SqlCommand(consulta, acc.Traer_conexion());
            dr = cmd.ExecuteReader();
            return dr;
        }
    }
}
