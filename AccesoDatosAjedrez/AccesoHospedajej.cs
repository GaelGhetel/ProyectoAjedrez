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
    public class AccesoHospedajej : IEntidades
    {
        Base b = new Base("Localhost", "root", "", "ajedrez", 3306);
        public void Borrar(dynamic Entidad)
        {
            b.comando(String.Format("call deleteHospedajej({0})",
              Entidad.Idhospedajej));
        }

        public void Guardar(dynamic Entidad)
        {
            b.comando(string.Format("call insertHospedajej(" +
              "'{0}','{1}',{2},{3},{4})", Entidad.Fechallegada,
                  Entidad.Fechasalida, Entidad.Fknumasociado, Entidad.Fkidhotel, Entidad.Idhospedajej));
        }

        public DataSet Mostrar(string filtro)
        {
            return b.Obtener
              (string.Format("call showHospedajej('%{0}%')",
                  filtro), "hospedajej");
        }
    }
}
