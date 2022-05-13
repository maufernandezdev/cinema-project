using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {
        private String Dni;
        private String Estado_Usuario;
        private String Nombre;
        private String Apellido;
        private String Contraseña;
        private DateTime FechaNac;
        private String Mail;

        public Usuario() { }

        public Usuario(String _Nombre, String _Apellido, String _Dni, String _Estado_Usuario, String _Contraseña, DateTime _fecha, String _Mail)
        {
            FechaNac.ToShortDateString();
            Dni = _Dni;
            Estado_Usuario = _Estado_Usuario;
            Nombre = _Nombre;
            Apellido = _Apellido;
            Contraseña = _Contraseña;
            FechaNac = _fecha;
            Mail = _Mail;

        }

        public String dni
        {
            get { return Dni; }
            set { Dni = value; }
        }

        public String estado_usuario
        {
            get { return Estado_Usuario; }
            set { Estado_Usuario = value; }
        }
        public String nombre
        {
            get { return Nombre; }
            set { Nombre = value; }
        }
        public String apellido
        {
            get { return Apellido; }
            set { Apellido = value; }
        }

        public String contraseña
        {
            get { return Contraseña; }
            set { Contraseña = value; }
        }
        public DateTime fecha
        {

            get { return FechaNac; }
            set { FechaNac = value; }
        }

        public String mail
        {
            get { return Mail; }
            set { Mail = value; }
        }
    }
}
