using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConectarBd;
using EntidadAjedrez;

namespace AccesoDatosAjedrez
{
    public class AccesoMovimientos : IEntidades
    {
        Base b = new Base("Localhost", "root", "", "ajedrez", 3306);
        public void Borrar(dynamic Entidad)
        {
            b.comando(String.Format("call deleteMovimientos({0})",
             Entidad.Norden));
        }

        public void Guardar(dynamic Entidad)
        {
            b.comando(string.Format("call insertMovimientos(" +
              "'{0}','{1}',{2},{3})", Entidad.Jugada,
                  Entidad.Comentario, Entidad.Fkcod_p, Entidad.Norden));
        }

        public DataSet Mostrar(string filtro)
        {
            return b.Obtener
              (string.Format("call showMovimientos('%{0}%')",
                  filtro), "movimientos");
        }
    }
}
