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
    public class AccesoHospedajea : IEntidades
    {
        Base b = new Base("Localhost", "root", "", "ajedrez", 3306);
        public void Borrar(dynamic Entidad)
        {
            b.comando(String.Format("call deleteHospedajea({0})",
             Entidad.Idhospedajea));
        }

        public void Guardar(dynamic Entidad)
        {
            b.comando(string.Format("call insertHospedajea(" +
  "'{0}','{1}',{2},{3},{4})", Entidad.Fechallegada,
      Entidad.Fechasalida, Entidad.Fknasociado, Entidad.Fkidhotel, Entidad.Idhospedajea));
        }

        public DataSet Mostrar(string filtro)
        {
            return b.Obtener
              (string.Format("call showHospedajea('%{0}%')",
                  filtro), "hospedajea");
        }
    }
}
