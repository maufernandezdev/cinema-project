using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;

namespace Dao
{
    public class DaoFuncionxSala
    {
        private String consulta;
        private AccesoDatos acc = new AccesoDatos();
        private SqlCommand cmd;
        private SqlDataReader dr;


        public SqlDataReader cargar_funcion_sucursal(String valor)
        {
            consulta = "SELECT DISTINCT ID_Pelicula, Título_Pelicula FROM Peliculas " +
               "INNER JOIN FuncionesxSala ON ID_Pelicula_FuncionxSala = ID_Pelicula " +
               "WHERE ID_Sucursal_FuncionxSala = '" + valor + "'";
            cmd = new SqlCommand(consulta, acc.Traer_conexion());
            dr = cmd.ExecuteReader();
            return dr;
        }
    }
}
