using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Dao
{
    public class DaoArticulos
    {
        AccesoDatos ds = new AccesoDatos();
        public const String sp_AgregarArticulos = "sp_AgregarArticulos";
        public const String sp_actualizarArticulo = "sp_actualizarArticulo";
        public const String sp_deleteArticulo = "sp_deleteArticulo";
        /* parametros sql 
            @id_articulo char(4),
            @estado varchar(20),
            @nombre varchar(30),
            @descripcion varchar(50), 
            @precio decimal(8,2),
            @url varchar(50)
         
         */
        private void ArmarParametrosArticulo(ref SqlCommand Comando, Articulos art)
        {

            SqlParameter parametros = new SqlParameter();
            parametros = Comando.Parameters.Add("@id_articulo", SqlDbType.Char, 4);
            parametros.Value = art.id_articulo;

            parametros = Comando.Parameters.Add("@estado", SqlDbType.VarChar, 20);
            parametros.Value = art.estado_articulo;

            parametros = Comando.Parameters.Add("@nombre", SqlDbType.VarChar, 30);
            parametros.Value = art.nombre_articulo;

            parametros = Comando.Parameters.Add("@descripcion", SqlDbType.VarChar, 50);
            parametros.Value = art.descripcion_articulo;

            parametros = Comando.Parameters.Add("@stock", SqlDbType.Int);
            parametros.Value = art.stock_articulo;

            parametros = Comando.Parameters.Add("@precio", SqlDbType.Decimal);
            parametros.Value = art.precio;

            parametros = Comando.Parameters.Add("@url", SqlDbType.VarChar, 50);
            parametros.Value = art.imagen_articulo;

        }

        public DataTable ObtenerTodasLosArticulos()
        {
            return ds.ObtenerTabla("Articulos", "SELECT ID_Articulo[ID Articulo], Estado_Articulo[Estado],Nombre_Articulo[Nombre],Descripción_Articulo[Descripción],Precio[Precio],URL_Articulo[Url artículo] From Articulos");
        }
        public DataTable ObtenerArticulo_id(Articulos art)
        {
            return ds.ObtenerTabla("Articulos", "SELECT ID_Articulo[ID Articulo], Estado_Articulo[Estado],Nombre_Articulo[Nombre],Descripción_Articulo[Descripción],Precio[Precio],URL_Articulo[Url artículo] From Articulos WHERE ID_Articulo='" + art.id_articulo  + "'");
        }


        public int agregarArticulo(Articulos art)
        {
            SqlCommand Comando = new SqlCommand();
            ArmarParametrosArticulo(ref Comando, art);
            return ds.sp_Ejecutar(Comando, sp_AgregarArticulos);

        }

        public Boolean existe_articulo(Articulos art)
        {

            return ds.existe("Select * From Articulos WHERE ID_Articulo= '" + art.id_articulo + "'");

        }

        private void parametrosEliminarArticulo(ref SqlCommand Comando, Articulos art)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = Comando.Parameters.Add("@id_articulo", SqlDbType.Char, 4);
            parametros.Value = art.id_articulo;
        }

        public bool eliminar_articulo(Articulos art)
        {
            SqlCommand Comando = new SqlCommand();
            parametrosEliminarArticulo(ref Comando, art);
            int filas = ds.sp_Ejecutar(Comando, sp_deleteArticulo);
            if (filas == 1)
                return true;
            else
                return false;
        }

        public bool actualizarArticulo(Articulos art)
        {
            SqlCommand Comando = new SqlCommand();
            ArmarParametrosArticulo(ref Comando, art);
            int filas = ds.sp_Ejecutar(Comando, sp_actualizarArticulo);
            if (filas == 1)
                return true;
            else
                return false;
        }


    }
}
