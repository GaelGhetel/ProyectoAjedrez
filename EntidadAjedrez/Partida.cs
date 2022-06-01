using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadAjedrez
{
    public class Partida
    {
        public Partida(int cod_p, int fknumasociado, int fknumasociado2, int fknasociado, string jornada, int fkidsalas)
        {
            Cod_p = cod_p;
            Fknumasociado = fknumasociado;
            Fknumasociado2 = fknumasociado2;
            Fknasociado = fknasociado;
            Jornada = jornada;
            Fkidsalas = fkidsalas;
        }

        public int Cod_p { get; set; }
        public int Fknumasociado { get; set; }
        public int Fknumasociado2 { get; set; }
        public int Fknasociado { get; set; }
        public string Jornada { get; set; }
        public int Fkidsalas { get; set; }
    }
}
