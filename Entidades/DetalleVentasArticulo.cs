using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetalleVentasArticulo
    {
        private int ID_dvArticulos;
        private int ID_Venta_dva;
        private String ID_Articulo_dva;
        private String Estado;
        private int Cantidad;
        private decimal Precio;


        public DetalleVentasArticulo() { }

        public DetalleVentasArticulo(int _ID_dvArticulos, int _ID_Venta_dva, String _ID_Articulo_dva, String _Estado, int _Cantidad, decimal _Precio)
        {

            this.ID_dvArticulos = _ID_dvArticulos;
            this.ID_Venta_dva = _ID_Venta_dva;
            this.ID_Articulo_dva = _ID_Articulo_dva;
            this.Estado = _Estado;
            this.Cantidad = _Cantidad;
            this.Precio = _Precio;

        }

        public int id_dv_articulo
        {
            get { return ID_dvArticulos; }
            set { ID_dvArticulos = value; }
        }

        public int id_venta_dva
        {
            get { return ID_Venta_dva; }
            set { ID_Venta_dva = value; }
        }
        public String id_articulo_dva
        {
            get { return ID_Articulo_dva; }
            set { ID_Articulo_dva = value; }
        }
        public String estado
        {
            get { return Estado; }
            set { Estado = value; }
        }
        public int cantidad
        {
            get { return Cantidad; }
            set { Cantidad = value; }
        }

        public decimal precio
        {
            get { return Precio; }
            set { Precio = value; }
        }
    }
}
