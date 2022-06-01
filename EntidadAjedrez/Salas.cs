using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadAjedrez
{
    public class Salas
    {
        public Salas(int idsalas, int nentradas, int capacidad, string medio, int fkidhotel)
        {
            Idsalas = idsalas;
            Nentradas = nentradas;
            Capacidad = capacidad;
            Medio = medio;
            Fkidhotel = fkidhotel;
        }

        public int Idsalas { get; set; }
        public int Nentradas { get; set; }
        public int Capacidad { get; set; }
        public string Medio { get; set; }
        public int Fkidhotel { get; set; }
    }
}
