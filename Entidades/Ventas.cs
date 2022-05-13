using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ventas
    {
        private int ID_Venta;
        private String Dni_Cliente_Venta;
        private String Estado;
        private String Promocion;
        private DateTime Fecha;
        private decimal Total;


        public Ventas() { }

        public Ventas(int _ID_Venta, String _Dni_Cliente_Venta, String _Estado, String _Promocion, DateTime _fecha, decimal _Total)
        {

            this.ID_Venta = _ID_Venta;
            this.Dni_Cliente_Venta = _Dni_Cliente_Venta;
            this.Estado = _Estado;
            this.Promocion = _Promocion;
            this.Fecha = _fecha;
            this.Total = _Total;

        }

        public int id_venta
        {
            get { return ID_Venta; }
            set { ID_Venta = value; }
        }

        public String dni_cliente
        {
            get { return Dni_Cliente_Venta; }
            set { Dni_Cliente_Venta = value; }
        }
        public String estado
        {
            get { return Estado; }
            set { Estado = value; }
        }
        public String promocion
        {
            get { return Promocion; }
            set { Promocion = value; }
        }

        public DateTime fecha
        {

            get { return Fecha; }
            set { Fecha = value; }
        }

        public decimal total
        {
            get { return Total; }
            set { Total = value; }
        }
    }
}
