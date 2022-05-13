using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;

namespace Dao
{
    public class DaoSucursal
    {
        private String consulta;
        private AccesoDatos acc = new AccesoDatos();
        private SqlCommand cmd;
        private SqlDataReader dr;

        public SqlDataReader cargar_sucursal()
        {
            consulta = "SELECT [ID_Sucursal], [Nombre_Sucursal] FROM [Sucursales] WHERE Estado_Sucursal = 'Activa'";
            cmd = new SqlCommand(consulta, acc.Traer_conexion());
            dr = cmd.ExecuteReader();
            return dr;
        }

        public SqlDataReader cargar_sucursal_pelicula(String valor)
        {
            consulta = "SELECT DISTINCT [ID_Sucursal], [Nombre_Sucursal] FROM [Sucursales]" +
                "INNER JOIN FuncionesxSala ON ID_Sucursal_FuncionxSala = ID_Sucursal WHERE ID_Pelicula_FuncionxSala = '" + valor + "' AND Estado_Sucursal = 'Activa'";
            cmd = new SqlCommand(consulta, acc.Traer_conexion());
            dr = cmd.ExecuteReader();
            return dr;
        }

        public SqlDataReader cargar_sucursal_funcion(String valor)
        {
            consulta = "SELECT DISTINCT ID_Sucursal, Nombre_Sucursal, Estado_Sucursal FROM Sucursales " +
                "INNER JOIN FuncionesxSala ON ID_Sucursal_FuncionxSala = ID_Sucursal " +
                "WHERE ID_Pelicula_FuncionxSala = '" + valor + "' AND Estado_Sucursal = 'Activa'";
            cmd = new SqlCommand(consulta, acc.Traer_conexion());
            dr = cmd.ExecuteReader();
            return dr;
        }
    }
}
