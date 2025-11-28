using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2025_ESD115
{
    internal class Libro
    {
        //Propiedades
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int ISBN { get; set; }
        public int AnioPublicacion { get; set; }

        //Constructor con parametros
        public Libro(string titulo, string autor, int isbn, int anioPublicacion)
        {
            this.Titulo = titulo;
            this.Autor = autor;
            this.ISBN = isbn;
            this.AnioPublicacion = anioPublicacion;
        }

        public Libro()
        {

        }

        //Implementacion de sobreescritura
        public override string ToString()
        {
            return $"Titulo: {Titulo}, Autor: {Autor}, ISBN: {ISBN}, Anio Publicacion: {AnioPublicacion}";
        }

    }
}
