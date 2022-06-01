using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConectarBd;
using EntidadAjedrez;
using System.IO;
using System.Data;

namespace AccesoDatosAjedrez
{
    public class AccesoPartida : IEntidades
    {
        Base b = new Base("Localhost", "root", "", "ajedrez", 3306);
        public void Borrar(dynamic Entidad)
        {
            b.comando(String.Format("call deletePartida({0})",
            Entidad.Cod_p));
        }

        public void Guardar(dynamic Entidad)
        {
            b.comando(string.Format("call insertPartida(" +
              "{0},{1},{2},'{3}',{4},{5})", Entidad.Fknumasociado,
                  Entidad.Fknumasociado2, Entidad.Fknasociado, Entidad.Jornada, Entidad.Fkidsalas, Entidad.Cod_p));
        }

        public DataSet Mostrar(string filtro)
        {
            return b.Obtener
              (string.Format("call showPartida('%{0}%')",
                  filtro), "partida");
        }
    }
}
