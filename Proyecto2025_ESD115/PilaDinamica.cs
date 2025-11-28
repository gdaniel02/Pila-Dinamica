using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2025_ESD115
{
    internal class PilaDinamica
    {
        //Propiedades
        private Nodo tope;
        private int contador;

        //Constructor
        public PilaDinamica()
        {
            tope = null;
            contador = 0;
        }

        //Metodo que permite agregar libros a la pila
        public void Apilar(Libro libro)
        {
            if (this.tope == null)
            {
                //la pila esta vacia
                this.tope = new Nodo(libro);
            }
            else
            {
                Nodo nuevoNodo = new Nodo(libro, this.tope);
                this.tope = nuevoNodo;
            }

            this.contador++;
        }

        //Metodo que permite eliminar libros de la pila
        public Libro Desapilar()
        {
            if (this.contador == 0)
            {
                //pila vacia
                //throw new InvalidOperationException("La pila esta vacia, no hay libros");
                Console.WriteLine("La pila esta vacia, no se puede desapilar ningun elemento");
                Console.WriteLine("Por favor pulse cualquier tecla para continuar...");
                return null;
            }
            else
            {
                Libro resultado = this.tope.Dato;
                this.tope = this.tope.Siguiente;
                this.contador--;
                return resultado;
            }
        }

        //Metodo que devuelve el dato del tope de la pila
        public Libro Peek()
        {
            return this.tope.Dato;
        }

        //Metodo que permite mostrar los libros 
        public void MostrarPila()
        {
            if (this.contador == 0)
            {
                //pila vacia
                //throw new InvalidOperationException("La pila esta vacia, no hay libros.");
                Console.WriteLine("La pila esta vacia, no se puede eliminar ningun elemento");
                Console.WriteLine("Por favor pulse cualquier tecla para continuar...");
            }

            Nodo inicio = this.tope;
            while (inicio != null)
            {
                Console.WriteLine(inicio.Dato.ToString());
                inicio = inicio.Siguiente;
            }
        }

        //Metodo para comprobar que el numero ISBN no se repita
        public bool ExisteISBN(int isbn)
        {
            Nodo actual = this.tope;
            while (actual != null)
            {
                if (actual.Dato != null && actual.Dato.ISBN == isbn)
                {
                    return true;
                }
                actual = actual.Siguiente;
            }
            return false;
        }
    }
}
