﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadAjedrez
{
    public class Jugadores
    {
        public Jugadores(int numasociado, string nombre, string direccion, string telefono, int campeonatos, int niveljuego, int fkncorrelativo)
        {
            Numasociado = numasociado;
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
            Campeonatos = campeonatos;
            Niveljuego = niveljuego;
            Fkncorrelativo = fkncorrelativo;
        }

        public int Numasociado { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int Campeonatos { get; set; }
        public int Niveljuego { get; set; }
        public int Fkncorrelativo { get; set; }
    }
}
