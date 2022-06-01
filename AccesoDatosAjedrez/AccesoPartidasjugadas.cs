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
    public class AccesoPartidasjugadas : IEntidades
    {
        Base b = new Base("Localhost", "root", "", "ajedrez", 3306);
        public void Borrar(dynamic Entidad)
        {
            b.comando(String.Format("call deletePartidasJugadas({0})",
             Entidad.Idjugada));
        }

        public void Guardar(dynamic Entidad)
        {
            b.comando(string.Format("call insertPartidasjugadas(" +
              "'{0}',{1},{2},{3})", Entidad.Coloficha,
                  Entidad.Fkcod_p, Entidad.Fknumasociado, Entidad.Idjugada));
        }

        public DataSet Mostrar(string filtro)
        {
            return b.Obtener
              (string.Format("call showPartidasjugadas('%{0}%')",
                  filtro), "partidasjugadas");
        }
    }
}
