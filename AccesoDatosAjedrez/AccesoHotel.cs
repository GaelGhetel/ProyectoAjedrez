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
    public class AccesoHotel : IEntidades
    {
        Base b = new Base("Localhost", "root", "", "ajedrez", 3306);
        public void Borrar(dynamic Entidad)
        {
            b.comando(String.Format("call deleteHotel({0})",
                Entidad.Idhotel));
        }

        public void Guardar(dynamic Entidad)
        {
            b.comando(string.Format("call insertHotel('{0}','{1}'" +
                ",'{2}',{3})", Entidad.Nombre, Entidad.Direccion, Entidad.Telefono, Entidad.Idhotel));
        }

        public DataSet Mostrar(string filtro)
        {
            return b.Obtener
            (string.Format("call showHotel('%{0}%')",
            filtro), "hotel");
        }
    }
}
