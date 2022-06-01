using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConectarBd;
using EntidadAjedrez;
using System.IO;

namespace AccesoDatosAjedrez
{
    public class AccesoJugadores:IEntidades
    {
        Base b = new Base("Localhost", "root", "", "ajedrez", 3306);

        public void Borrar(dynamic Entidad)
        {
            b.comando(String.Format("call deleteJugadores({0})",
                Entidad.Numasociado));
        }

        public void Guardar(dynamic Entidad)
        {
            b.comando(string.Format("call insertJugadores(" +
              "'{0}','{1}','{2}',{3},{4},{5},{6})", Entidad.Nombre,
                  Entidad.Direccion, Entidad.Telefono, Entidad.Campeonatos, Entidad.Niveljuego, Entidad.Fkncorrelativo,Entidad.Numasociado));
        }

        public DataSet Mostrar(string filtro)
        {
            return b.Obtener
              (string.Format("call showJugadores('%{0}%')",
                  filtro), "jugadores");
        }
    }
}
