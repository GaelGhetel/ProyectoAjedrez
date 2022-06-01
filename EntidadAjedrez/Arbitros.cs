using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadAjedrez
{
    public class Arbitros
    {
        public Arbitros(int nasociado, string nombre, string direccion, string telefono, int campeonatos, int fkncorrelativo)
        {
            Nasociado = nasociado;
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
            Campeonatos = campeonatos;
            Fkncorrelativo = fkncorrelativo;
        }
        public int Nasociado { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int Campeonatos { get; set; }
        public int Fkncorrelativo { get; set; }
    }
}
