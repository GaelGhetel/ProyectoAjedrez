using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadAjedrez
{
    public class Partidasjugadas
    {
        public Partidasjugadas(int idjugada, string coloficha, int fkcod_p, int fknumasociado)
        {
            Idjugada = idjugada;
            Coloficha = coloficha;
            Fkcod_p = fkcod_p;
            Fknumasociado = fknumasociado;
        }

        public int Idjugada { get; set; }
        public string Coloficha { get; set; }
        public int Fkcod_p { get; set; }
        public int Fknumasociado { get; set; }
    }
}
