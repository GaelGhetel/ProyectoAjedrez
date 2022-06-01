using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ConectarBd;
using EntidadAjedrez;
using System.IO;
namespace AccesoDatosAjedrez
{
    public class AccesoPais:IEntidades
    {
        Base b = new Base("Localhost", "root", "", "ajedrez", 3306);

        public void Borrar(dynamic Entidad)
        {
            b.comando(String.Format("call deletePais({0})",
                Entidad.Ncorrelativo));
        }

        public void Guardar(dynamic Entidad)
        {
            b.comando(string.Format("call insertPais('{0}',{1}"+
                ",{2})",Entidad.Nombre,Entidad.Nclubes,Entidad.Ncorrelativo));
        }

        public DataSet Mostrar(string filtro)
        {
            return b.Obtener
                (string.Format("call showPais('%{0}%')",
                filtro), "pais");
        }
    }
}
