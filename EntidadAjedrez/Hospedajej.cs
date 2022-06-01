using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadAjedrez
{
    public class Hospedajej
    {
        public Hospedajej(int idhospedajej, string fechallegada, string fechasalida, int fknumasociado, int fkidhotel)
        {
            Idhospedajej = idhospedajej;
            Fechallegada = fechallegada;
            Fechasalida = fechasalida;
            Fknumasociado = fknumasociado;
            Fkidhotel = fkidhotel;
        }

        public int Idhospedajej { get; set; }
        public string Fechallegada { get; set; }
        public string Fechasalida { get; set; }
        public int Fknumasociado { get; set; }
        public int Fkidhotel { get; set; }
    }
}
