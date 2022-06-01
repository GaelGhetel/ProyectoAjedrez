using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadAjedrez
{
    public class Hospedajea
    {
        public Hospedajea(int idhospedajea, string fechallegada, string fechasalida, int fknasociado, int fkidhotel)
        {
            Idhospedajea = idhospedajea;
            Fechallegada = fechallegada;
            Fechasalida = fechasalida;
            Fknasociado = fknasociado;
            Fkidhotel = fkidhotel;
        }

        public int Idhospedajea { get; set; }
        public string Fechallegada { get; set; }
        public string Fechasalida { get; set; }
        public int Fknasociado { get; set; }
        public int Fkidhotel { get; set; }
    }
}
