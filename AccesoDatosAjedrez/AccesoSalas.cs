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
    public class AccesoSalas : IEntidades
    {
        Base b = new Base("Localhost", "root", "", "ajedrez", 3306);
        public void Borrar(dynamic Entidad)
        {
            b.comando(String.Format("call deleteSalas({0})",
            Entidad.Idsalas));
        }

        public void Guardar(dynamic Entidad)
        {
            b.comando(string.Format("call insertSalas({0},{1}" +
             ",'{2}',{3},{4})", Entidad.Nentradas, Entidad.Capacidad, Entidad.Medio, Entidad.Fkidhotel, Entidad.Idsalas));
        }

        public DataSet Mostrar(string filtro)
        {
            return b.Obtener
            (string.Format("call showSalas('%{0}%')",
            filtro), "salas");
        }
    }
}
