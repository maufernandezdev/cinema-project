using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Entidades;

namespace Dao
{
    public class DaoUsuario
    {
        private AccesoDatos acc = new AccesoDatos();        
        private String consulta;
        SqlCommand comando;


        private void armarParametrosAgregarCliente(SqlCommand Comando, Usuario cli)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = Comando.Parameters.Add("@Nombre", SqlDbType.VarChar, 30);
            parametros.Value = cli.nombre;
            parametros = Comando.Parameters.Add("@Apellido", SqlDbType.VarChar, 30);
            parametros.Value = cli.apellido;
            parametros = Comando.Parameters.Add("@Dni", SqlDbType.Char, 8);
            parametros.Value = cli.dni;
            parametros = Comando.Parameters.Add("@Contraseña", SqlDbType.Char, 30);
            parametros.Value = cli.contraseña;
            parametros = Comando.Parameters.Add("@Correo", SqlDbType.VarChar, 30);
            parametros.Value = cli.mail;
            parametros = Comando.Parameters.Add("@Fecha", SqlDbType.Date);
            parametros.Value = cli.fecha;
        }

        private void armarParametrosAct_DesacCliente(SqlCommand Comando, Usuario cli)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = Comando.Parameters.Add("@Contraseña", SqlDbType.Char, 30);
            parametros.Value = cli.contraseña;
            parametros = Comando.Parameters.Add("@Correo", SqlDbType.VarChar, 30);
            parametros.Value = cli.mail;
        }

        public int ModificarCorreo(String correoInicial, String correoFinal, String contraseña)
        {
            consulta = "UPDATE USUARIOS SET CORREO = '" + correoFinal + "' WHERE CORREO = '" + correoInicial + "' AND CONTRASEÑA = '" + contraseña + "'"; 
            return acc.EjecutarProceso(consulta);
        }

        public int ModificarContra(String contraInicial, String contraFinal, String correo)
        {
            consulta = "UPDATE USUARIOS SET CONTRASEÑA = '" + contraFinal + "' WHERE CORREO = '" + correo + "' AND CONTRASEÑA = '" + contraInicial + "'";
            return acc.EjecutarProceso(consulta);
        }

        public int AgregarCliente(Usuario cli)
        {
            comando = new SqlCommand();
            armarParametrosAgregarCliente(comando, cli);
            return acc.sp_Ejecutar(comando, "spAgregarUsuario");
        }

        public int EliminarCliente(Usuario cli)
        {
            comando = new SqlCommand();
            armarParametrosAct_DesacCliente(comando, cli);
            return acc.sp_Ejecutar(comando, "sp_bajaCliente");
        }

        public int ActivarCliente(Usuario cli)
        {
            comando = new SqlCommand();
            armarParametrosAct_DesacCliente(comando, cli);
            return acc.sp_Ejecutar(comando, "sp_altaCliente");
        }

        public bool existeUsuario(String dni)
        {
            consulta = "SELECT * FROM Usuarios WHERE DNI_Usuario = '" + dni + "'";
            return acc.existe(consulta);
        }


        public DataTable getUsuario(String correo, String contraseña)
        {
            consulta = "SELECT * FROM Usuarios WHERE Correo = '" + correo + "' AND " +
            "Contraseña = '" + contraseña + "'";
            return (acc.ObtenerTabla("Registro", consulta));
        }
    }
}
