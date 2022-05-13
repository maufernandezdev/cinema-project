using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Negocios
{
    public class NegociosFuncionesxSalasxAsiento
    {
        DaoFuncionesxSalasxAsiento dao = new DaoFuncionesxSalasxAsiento();

        public bool seleccionarAsiento(FuncionesxSala fs, string asiento)
        {
            int cantFilas = 0;

            FuncionesxSalasxAsiento fsa = new FuncionesxSalasxAsiento();
            fsa.ID_Pelicula_FSA1 = fs.ID_Pelicula1;
            fsa.ID_Sucursal_FSA1 = fs.ID_Sucursal1;
            fsa.ID_Asiento_FSA1 = asiento;
            fsa.Fecha_FuncionxSalaAsiento1 = fs.Fecha1;

            cantFilas = dao.SeleccionarAsiento(fs, fsa);

            if (cantFilas == 1)
                return true;
            else
                return false;
        }

        public bool quitarAsientoSeleccionado(string asiento)
        {
            FuncionesxSalasxAsiento fsa = new FuncionesxSalasxAsiento();
            fsa.ID_Asiento_FSA1 = asiento;

            int op = dao.QuitarAsientoSeleccionado(fsa);
            if (op == 1)
                return true;
            else
                return false;
        }

        public DataTable obtenerAsientosDisponibles(FuncionesxSala fs)
        {
            return dao.ObtenerAsientosDisponibles(fs);
        }

        public DataTable obtenerAsientosReservados()
        {
            return dao.ObtenerAsientosReservados();
        }

        public DataTable obtenerAsientosSeleccionadosParaDetalleVentas()
        {
            return dao.ObtenerAsientosSeleccionadosParaDetalleVentas();
        }

        public bool actualizarEstadoAsientos()
        {
            return dao.ActualizarEstadoAsientos();
        }

        public bool vaciarReservasPrevias()
        {
            return dao.VaciarReservasPrevias();
        }

    }
}
