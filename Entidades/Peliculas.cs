using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Peliculas
    {
        String ID_Pelicula;
        String Estado;
        String Titulo;
        int Duracion; /*Convert to int 32*/
        String Clasificacion;
        String Url_Imagen;

        public Peliculas () { }

        public Peliculas(string iD_Pelicula, string estado, string titulo, int duracion, string clasificacion, string url_Imagen)
        {
            ID_Pelicula = iD_Pelicula;
            Estado = estado;
            Titulo = titulo;
            Duracion = duracion;
            Clasificacion = clasificacion;
            Url_Imagen = url_Imagen;
        }

        public String id_pelicula
        {
            get { return ID_Pelicula; }
            set { ID_Pelicula = value; }
        }
        public String estado
        {
            get { return Estado; }
            set { Estado = value; }
        }
        public String titulo
        {
            get { return Titulo; }
            set {Titulo = value; }
        }
        public int duracion
        {
            get { return Duracion; }
            set { Duracion = value; }
        }
        public String clasificacion
        {
            get { return Clasificacion; }
            set { Clasificacion = value; }
        }
        public String url_imagen
        {
            get { return Url_Imagen; }
            set { Url_Imagen = value; }
        }

    }
}
