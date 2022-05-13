using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Dao
{
    public class AccesoDatos
    {

        /* ruta de base de datos constante*/
        public const String rutaBDCineteca = "Data Source=localhost\\sqlexpress;;Initial Catalog = Cineteca; Integrated Security = True ";

        public AccesoDatos()
        {

        }

        // trae una conexion abierta 
        public SqlConnection Traer_conexion()
        {
            SqlConnection cn = new SqlConnection(rutaBDCineteca);
            try
            {
                cn.Open();
                return cn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        // obtiene un adaptador 
        public SqlDataAdapter ObtenerAdaptador(String consulta)
        {
            SqlDataAdapter adaptador;
            try
            {
                adaptador = new SqlDataAdapter(consulta, Traer_conexion());
                return adaptador;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /*obtiene un adaptador con store procedure */
        public SqlDataAdapter ObtenerAdaptador_sp(String consulta)
        {
            SqlDataAdapter adaptador;
            try
            {
                adaptador = new SqlDataAdapter(consulta, Traer_conexion());
                return adaptador;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /* insertar, eliminar , modificar */ // Sirve para cuando un usuario ingresa datos // // recibe una store procedure
        public int sp_Ejecutar(SqlCommand Comando, String sp_nombre)
        {
            int filas;
            SqlConnection Conexion = Traer_conexion();
            SqlCommand cmd = new SqlCommand();
            cmd = Comando;
            cmd.Connection = Conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sp_nombre;
            filas = cmd.ExecuteNonQuery();
            Conexion.Close();
            return filas;
        }

        /* insertar, eliminar , modificar */ // Sirve para cuando un usuario ingresa datos // // recibe una consulta
        public int EjecutarProceso(string consulta)
        {
            SqlConnection conexion = new SqlConnection(rutaBDCineteca);
            conexion.Open();
            SqlCommand comando = new SqlCommand(consulta, conexion);
            int filasAfectada = comando.ExecuteNonQuery();
            return filasAfectada;
        }

        /*Cambiar nombre a ObtenerTabla_sp*/
        public DataTable EjecutarSpConParametros(SqlCommand Comando, String sp_nombre, String nombre)
        {
            DataSet ds = new DataSet();
            SqlConnection Conexion = Traer_conexion();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter adapter = new SqlDataAdapter();
            cmd = Comando;
            cmd.Connection = Conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sp_nombre;
            cmd.ExecuteNonQuery();
            adapter.SelectCommand = cmd;
            adapter.Fill(ds, nombre);
            Conexion.Close();
            return ds.Tables[nombre];
        }

        public Boolean existe(String consulta)
        {

            Boolean estado = false;
            SqlConnection cn = Traer_conexion();
            SqlCommand cmd = new SqlCommand(consulta, cn);
            SqlDataReader datos = cmd.ExecuteReader();
            if (datos.Read())
            {
                estado = true;
            }
            return estado;
        }

        public Boolean existe_sp(String consulta, SqlCommand Comando, String sp_nombre)
        {

            Boolean estado = false;
            SqlConnection cn = Traer_conexion();
            SqlCommand cmd = new SqlCommand(consulta, cn);
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sp_nombre;
            SqlDataReader datos = cmd.ExecuteReader();
            if (datos.Read())
            {
                estado = true;
            }
            cn.Close();
            return estado;
        }

        public DataTable ObtenerTabla(String nombre, String sql) // recibe la consulta (string sql) , y el nombre de la tabla (nombre) 
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = ObtenerAdaptador(sql);
            adp.Fill(ds, nombre);
            return ds.Tables[nombre];
        }

        //Sirve para chequear si existe algo con un sp + parametros. Si devuelve 1 el sp, devuelve true. Si devuelve 0 el sp, devuelve false
        public Boolean chequeo_sp(SqlCommand Comando, String sp_nombre) 
        {
            int check;
            SqlConnection Conexion = Traer_conexion();
            SqlCommand cmd = new SqlCommand();
            cmd = Comando;
            cmd.Connection = Conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sp_nombre;
            check = (int) cmd.ExecuteScalar();
            Conexion.Close();
            if (check == 1)
            {
               return true;
            }
            else
            {
                return false;
            }
        }
    }
}
