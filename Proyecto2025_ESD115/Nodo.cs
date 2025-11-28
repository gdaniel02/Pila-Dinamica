using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2025_ESD115
{
    internal class Nodo
    {
        public Libro Dato { get; set; }
        public Nodo Siguiente { get; set; }

        public Nodo(Libro dato)
        {
            Dato = dato;
            Siguiente = null;
        }

        public Nodo(Libro dato, Nodo siguiente)
        {
            this.Dato = dato;
            this.Siguiente = siguiente;
        }
    }
}
