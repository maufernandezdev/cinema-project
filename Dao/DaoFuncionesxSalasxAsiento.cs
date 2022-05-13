using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;
using System.CodeDom;

namespace Dao
{
    public class DaoFuncionesxSalasxAsiento
    {
        AccesoDatos ds = new AccesoDatos();

        //Selecciona el asiento cambiandole el estado de'Disponible' a 'Reservado' a la tabla FuncionesxSalasxAsiento
        public int SeleccionarAsiento(FuncionesxSala fs, FuncionesxSalasxAsiento fsa)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosAsientosSeleccionar(ref comando, fs, fsa);
            return ds.sp_Ejecutar(comando, "SP_SeleccionarAsiento");
        }

        //Quita el asiento cambiandole el estado de 'Reservado' a Disponible' a la tabla FuncionesxSalasxAsiento
        public int QuitarAsientoSeleccionado(FuncionesxSalasxAsiento fsa)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosAsientosQuitar(ref comando, fsa);
            return ds.sp_Ejecutar(comando, "SP_QuitarAsientoSeleccionado");
        }

        //Trae una DataTable con los asientos disponibles en esa función
        public DataTable ObtenerAsientosDisponibles(FuncionesxSala fs)
        {
            DataTable dt = new DataTable();
            SqlCommand comando = new SqlCommand();
            ArmarParametrosAsientosSeleccionados(ref comando, fs);
            dt = ds.EjecutarSpConParametros(comando, "SP_AsientosDisponible", "AsientosDisponibles");
            return dt;
        }

        //Trae los asientos que fueron seleccionados por el cliente, es decir los que están en estado 'Reservado'
        public DataTable ObtenerAsientosReservados()
        {
            DataTable dt = new DataTable();
            SqlCommand comando = new SqlCommand();
            dt = ds.EjecutarSpConParametros(comando, "SP_AsientosReservado", "AsientosReservados");
            return dt;
        }

        //Trae un DataTable con los datos de los asientos seleccionados para procesar la compra
        public DataTable ObtenerAsientosSeleccionadosParaDetalleVentas()
        {
            DataTable dt = new DataTable();
            dt = ds.ObtenerTabla("DetalleVentas", "SELECT * FROM FuncionesxSalasxAsiento WHERE Estado_FSA='Reservado'");
            return dt;
        }

        //Arma los parametros para el procedimeiento "SP_SeleccionarAsientos"
        private void ArmarParametrosAsientosSeleccionar(ref SqlCommand comando, FuncionesxSala fs, FuncionesxSalasxAsiento fsa)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = comando.Parameters.Add("@ID_Pelicula", SqlDbType.Char);
            SqlParametros.Value = fsa.ID_Pelicula_FSA1;
            SqlParametros = comando.Parameters.Add("@ID_Sucursal", SqlDbType.Char);
            SqlParametros.Value = fsa.ID_Sucursal_FSA1;
            SqlParametros = comando.Parameters.Add("@ID_Asiento", SqlDbType.Char);
            SqlParametros.Value = fsa.ID_Asiento_FSA1;
            SqlParametros = comando.Parameters.Add("@Horario", SqlDbType.Time);
            SqlParametros.Value = fs.Hora_Inicio1;
            SqlParametros = comando.Parameters.Add("@Fecha", SqlDbType.Date);
            SqlParametros.Value = fsa.Fecha_FuncionxSalaAsiento1;
        }

        //Arma los parametros para el procedimeiento "SP_AsientosDisponible"
        private void ArmarParametrosAsientosSeleccionados(ref SqlCommand comando, FuncionesxSala fs)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = comando.Parameters.Add("@ID_Pelicula", SqlDbType.Char);
            SqlParametros.Value = fs.ID_Pelicula1;
            SqlParametros = comando.Parameters.Add("@ID_Sucursal", SqlDbType.Char);
            SqlParametros.Value = fs.ID_Sucursal1;
            SqlParametros = comando.Parameters.Add("@Horario", SqlDbType.Time);
            SqlParametros.Value = fs.Hora_Inicio1;
            SqlParametros = comando.Parameters.Add("@Fecha", SqlDbType.Date);
            SqlParametros.Value = fs.Fecha1;
        }


        //Arma los parametros para el procedimeiento "SP_QuitarAsientoSeleccionado"
        private void ArmarParametrosAsientosQuitar(ref SqlCommand comando, FuncionesxSalasxAsiento fsa)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = comando.Parameters.Add("@ID_Asiento", SqlDbType.Char);
            SqlParametros.Value = fsa.ID_Asiento_FSA1;
        }

        //Actualiza el estado de los asientos
        public bool ActualizarEstadoAsientos()
        {
            SqlCommand comando = new SqlCommand();
            return ds.chequeo_sp(comando, "SP_ActualizarEstadoAsientos");
        }

        //Vacia los asientos reservados, cambiando el estado 'Reservado' a 'Disponible'
        public bool VaciarReservasPrevias()
        {
            SqlCommand comando = new SqlCommand();
            return ds.chequeo_sp(comando, "SP_VaciarReservas");
        }
    }
}
