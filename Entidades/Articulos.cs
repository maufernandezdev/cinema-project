using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Articulos
    {
        private String ID_Articulo;
        private String Estado_Articulo;
        private String Nombre_Articulo;
        private String Descripcion_Articulo;
        private int Stock;
        private decimal Precio;
        private String Imagen_Articulo;


        public Articulos() { }

        public Articulos(String _ID_Articulo, String _Estado_Articulo, String _Nombre_Articulo, String _Descripcion_Articulo,int _stock, decimal _Precio, String _Imagen_Articulo)
        {

            this.ID_Articulo = _ID_Articulo;
            this.Estado_Articulo = _Estado_Articulo;
            this.Nombre_Articulo = _Nombre_Articulo;
            this.Descripcion_Articulo = _Descripcion_Articulo;
            this.Stock = _stock;
            this.Precio = _Precio;
            this.Imagen_Articulo = _Imagen_Articulo;

        }

        public String id_articulo
        {
            get { return ID_Articulo; }
            set { ID_Articulo = value; }
        }

        public String estado_articulo
        {
            get { return Estado_Articulo; }
            set { Estado_Articulo = value; }
        }
        public String nombre_articulo
        {
            get { return Nombre_Articulo; }
            set { Nombre_Articulo = value; }
        }
        public String descripcion_articulo
        {
            get { return Descripcion_Articulo; }
            set { Descripcion_Articulo = value; }
        }

        public int stock_articulo
        {
            get { return Stock; }
            set { Stock = value; }
        }

        public decimal precio
        {
            get { return Precio; }
            set { Precio = value; }
        }

        public String imagen_articulo
        {
            get { return Imagen_Articulo; }
            set { Imagen_Articulo = value; }

        }
    }
}
