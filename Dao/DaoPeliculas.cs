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
    public class DaoPeliculas
    {
        AccesoDatos ds = new AccesoDatos();
        /* nombre de parametros 
         *  (@id_pelicula char (4),
            @estado varchar(20),
            @titulo varchar(50),
            @duracion int,
            @clasif varchar(50),
            @url varchar(50)        
         */
        public const String sp_AgregarPelicula = "sp_AgregarPelicula";
        public const String sp_deletePelicula = "sp_deletePelicula";
        public const String sp_actualizarPelicula = "sp_actualizarPelicula";

        private void armarParametrosPeliculas(ref SqlCommand Comando, Peliculas peli)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = Comando.Parameters.Add("@id_pelicula", SqlDbType.Char, 4);
            parametros.Value = peli.id_pelicula;
            parametros = Comando.Parameters.Add("@estado", SqlDbType.VarChar, 20);
            parametros.Value = peli.estado;
            parametros = Comando.Parameters.Add("@titulo", SqlDbType.VarChar, 50);
            parametros.Value = peli.titulo;
            parametros = Comando.Parameters.Add("@duracion", SqlDbType.Int);
            parametros.Value = peli.duracion;
            parametros = Comando.Parameters.Add("@clasif", SqlDbType.VarChar, 50);
            parametros.Value = peli.clasificacion;
            parametros = Comando.Parameters.Add("@url", SqlDbType.VarChar, 50);
            parametros.Value = peli.url_imagen;

        }


        public DataTable ObtenerTodasLasPeliculas()
        {
            return ds.ObtenerTabla("Peliculas", "Select ID_Pelicula[Pelicula],ID_Estado_Pelicula[Estado],Título_Pelicula[Título],Duración_Pelicula[Duración],Clasificación_Pelicula[Clasificación],URL_Portada[Url imagen] From Peliculas");
        }
        public DataTable ObtenerPelicula_id(Peliculas pel)
        {
            return ds.ObtenerTabla("Peliculas", "Select ID_Pelicula[Pelicula],ID_Estado_Pelicula[Estado],Título_Pelicula[Título],Duración_Pelicula[Duración],Clasificación_Pelicula[Clasificación],URL_Portada[Url imagen] From Peliculas WHERE ID_Pelicula='"+pel.id_pelicula+"'");
        }

        public int agregarPeliculas(Peliculas peli)
        {
            SqlCommand Comando = new SqlCommand();
            armarParametrosPeliculas(ref Comando, peli);
            return ds.sp_Ejecutar(Comando, sp_AgregarPelicula);

        }

        public Boolean existe_pelicula(Peliculas pe)
        {
            
            return ds.existe("Select * From Peliculas WHERE ID_Pelicula= '" + pe.id_pelicula + "'");

        }

        private void parametrosEliminarPeliculas(ref SqlCommand Comando, Peliculas pel)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = Comando.Parameters.Add("@id_pelicula", SqlDbType.Char,4);
            parametros.Value = pel.id_pelicula;
        }

        public bool eliminar_pelicula(Peliculas pelis)
        {
            SqlCommand Comando = new SqlCommand();
            parametrosEliminarPeliculas(ref Comando, pelis);
            int filas = ds.sp_Ejecutar(Comando, sp_deletePelicula);
            if (filas == 1)
                return true;
            else
                return false;
        }

        

        // actualiza los Productos , se le envia un objeto del tipo Producto 
        public bool actualizarPelicula(Peliculas peli)
        {
            SqlCommand Comando = new SqlCommand();
            armarParametrosPeliculas(ref Comando, peli);
            int filas = ds.sp_Ejecutar(Comando, sp_actualizarPelicula);
            if (filas == 1)
                return true;
            else
                return false;
        }

       
    }
}
