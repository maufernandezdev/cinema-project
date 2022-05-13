using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dao;
using Entidades;

namespace Negocios
{
    
    public class NegociosPeliculas
    {
        DaoPeliculas dao = new DaoPeliculas();
        public DataTable getTabla()
        {
            return dao.ObtenerTodasLasPeliculas();
        }

        public DataTable getTablaPelis_id(Peliculas peli)
        {
            return dao.ObtenerPelicula_id(peli);
        }

        public bool agregarPelicula (Peliculas peli)
        {
            int filas = 0;
            filas = dao.agregarPeliculas(peli);
            
            if (filas == 1) return true;
            else return false;
            
        }

        public bool existePelicula (Peliculas pel)
        {      
            if (dao.existe_pelicula(pel) == true) return true;
            else return false;

        }

        public bool eliminarPelicula (Peliculas pel)
        {
            if (dao.eliminar_pelicula(pel)) return true;
            else return false;
        }
        public bool modificarPelicula(Peliculas pel)
        {
            if (dao.actualizarPelicula(pel)) return true;
            else return false;
        }
    }
}
