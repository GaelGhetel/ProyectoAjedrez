using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadAjedrez
{
    public class Movimientos
    {
        public Movimientos(int norden, string jugada, string comentario, int fkcod_p)
        {
            Norden = norden;
            Jugada = jugada;
            Comentario = comentario;
            Fkcod_p = fkcod_p;
        }

        public int Norden { get; set; }
        public string Jugada { get; set; }
        public string Comentario { get; set; }
        public int Fkcod_p { get; set; }
    }
}
