using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetalleVentas
    {
        public DetalleVentas() { }

        private int ID_Venta_dv;
        private int ID_DetalleDeVenta;
        private String ID_Funcion;
        private String ID_Pelicula;
        private String ID_Sucursal;
        private String ID_Sala;
        private String ID_Asiento;
        private String Fecha;
        private Decimal Precio;
        private String Estado;

        public DetalleVentas(int _ID_Venta_dv, int _ID_DetalleDeVenta, String _ID_Funcion, String _ID_Pelicula, String _ID_Sucursal, String _ID_Sala, String _ID_Asiento, String _Fecha , decimal _Precio, String _Estado)
        {

            this.ID_Venta_dv = _ID_Venta_dv;
            this.ID_DetalleDeVenta = _ID_DetalleDeVenta;
            this.ID_Funcion = _ID_Funcion;
            this.ID_Pelicula = _ID_Pelicula;
            this.ID_Sucursal = _ID_Sucursal;
            this.ID_Sala = _ID_Sala;
            this.ID_Asiento = _ID_Asiento;
            this.Fecha = _Fecha;
            this.Precio = _Precio;
            this.Estado = _Estado;

        }

        public int id_venta_dv
        {
            get { return ID_Venta_dv; }
            set { ID_Venta_dv = value; }
        }
        public int id_dv
        {
            get { return ID_DetalleDeVenta; }
            set { ID_DetalleDeVenta = value; }
        }
        public String id_funcion
        {
            get { return ID_Funcion; }
            set { ID_Funcion = value; }
        }

        public String id_pelicula
        {
            get { return ID_Pelicula; }
            set { ID_Pelicula = value; }
        }
        
        public String id_sucursal
        {
            get { return ID_Sucursal; }
            set { ID_Sucursal = value; }
        }

        public String id_sala
        {
            get { return ID_Sala; }
            set { ID_Sala = value; }
        }
        
        public String id_asiento
        {
            get { return ID_Asiento; }
            set { ID_Asiento = value; }
        }

        public String fecha
        {
            get { return Fecha; }
            set { Fecha = value; }
        }
        public Decimal precio
        {
            get { return Precio; }
            set { Precio = value; }
        }
        public String estado
        {
            get { return Estado; }
            set { Estado = value; }
        }






    }
}
