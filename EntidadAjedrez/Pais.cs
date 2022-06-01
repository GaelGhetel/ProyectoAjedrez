using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadAjedrez
{
    public class Pais
    {
        public Pais(int ncorrelativo, string nombre, int nclubes)
        {
            Ncorrelativo = ncorrelativo;
            Nombre = nombre;
            Nclubes = nclubes;
        }

        public int Ncorrelativo { get; set; }
        public string Nombre { get; set; }
        public int Nclubes { get; set; }
    }
}
