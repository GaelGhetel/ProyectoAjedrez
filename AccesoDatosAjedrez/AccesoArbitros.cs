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
    public class AccesoArbitros
    {
        Base b = new Base("Localhost", "root", "", "ajedrez", 3306);

        public void Borrar(dynamic Entidad)
        {
            b.comando(String.Format("call deleteArbitros({0})",
                Entidad.Nasociado));
        }

        public void Guardar(dynamic Entidad)
        {
            b.comando(string.Format("call insertArbitros(" +
              "'{0}','{1}','{2}',{3},{4},{5})", Entidad.Nombre,
                  Entidad.Direccion, Entidad.Telefono, Entidad.Campeonatos, Entidad.Fkncorrelativo, Entidad.Nasociado));
        }

        public DataSet Mostrar(string filtro)
        {
            return b.Obtener
              (string.Format("call showArbitros('%{0}%')",
                  filtro), "arbitros");
        }
    }
}
