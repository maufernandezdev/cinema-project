using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    public class FuncionesxSala
    {
        private string ID_Funcion;
        private string ID_Pelicula;
        private string ID_Sucursal;
        private string ID_Sala;
        private string Estado;
        private string Hora_Inicio;
        private string Hora_Fin;
        private string Fecha;
        private Decimal Precio;

        public FuncionesxSala()
        {

        }

        public string ID_Funcion1 { get => ID_Funcion; set => ID_Funcion = value; }
        public string ID_Pelicula1 { get => ID_Pelicula; set => ID_Pelicula = value; }
        public string ID_Sucursal1 { get => ID_Sucursal; set => ID_Sucursal = value; }
        public string ID_Sala1 { get => ID_Sala; set => ID_Sala = value; }
        public string Estado1 { get => Estado; set => Estado = value; }
        public string Hora_Inicio1 { get => Hora_Inicio; set => Hora_Inicio = value; }
        public string Hora_Fin1 { get => Hora_Fin; set => Hora_Fin = value; }
        public string Fecha1 { get => Fecha; set => Fecha = value; }
        public decimal Precio1 { get => Precio; set => Precio = value; }
    }
}
