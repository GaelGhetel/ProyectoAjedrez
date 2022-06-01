using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadAjedrez
{
    public class Hotel
    {
        public Hotel(int idhotel, string nombre, string direccion, string telefono)
        {
            Idhotel = idhotel;
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
        }

        public int Idhotel { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }
}
