using Proyecto2025_ESD115;
using System;

class Program
{
    static void Main(string[] args)
    {
        //Instancia de la clase pila dinamica
        PilaDinamica pila = new PilaDinamica();
        //Variable que sirve para almacenar la opcion que digita el usuario
        int opcion;

        //Ciclo iterativo adecuado para manejar el menu
        do
        {
            //Impresion del menu
            Console.WriteLine("-----------------------");
            Console.WriteLine("  SISTEMA DE GESTION DE LIBROS  ");
            Console.WriteLine("-----------------------");
            Console.WriteLine("1. Registrar libro");
            Console.WriteLine("2. Desapilar libro");
            Console.WriteLine("3. Mostrar libro");
            Console.WriteLine("4. Salir");
            Console.Write("Selecciona una opcion: ");
            //Validacion para cuando en el programa reciba un numero
            while (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Error: debes ingresar un número válido.");
                Console.Write("Selecciona una opción: ");
            }
            Console.Clear();

            //Estructura adecuada para manejar las opciones
            switch (opcion)
            {
                case 1:
                    //Instancia de la clase libro con el objeto libro
                    Libro libro = new Libro();

                    //Se solicitan los datos del libro
                    do
                    {
                        //solicitud del titulo del libro y validacion para que el titulo no quede vacio
                        Console.Write("Ingrese el título del libro: ");
                        libro.Titulo = Console.ReadLine().Trim();
                        if (string.IsNullOrEmpty(libro.Titulo))
                        {
                            Console.WriteLine("Error: el título no puede estar vacío....");
                        }
                    } while (string.IsNullOrEmpty(libro.Titulo));

                    do
                    {
                        //solicitud del autor del libro y validacion para que el autor no quede vacio
                        Console.Write("Ingrese el autor del libro: ");
                        libro.Autor = Console.ReadLine().Trim();
                        if (string.IsNullOrEmpty(libro.Autor))
                        {
                            Console.WriteLine("Error: el autor no puede estar vacío.");
                        }
                    } while (string.IsNullOrEmpty(libro.Autor));

                    int isbn;
                    bool isbnValido;
                    do
                    {
                        //solicitud del numero ISBN del libro y validacion para que no se cierre si no se digita un numero valido
                        //Validacion para que no se repita un numero ISBN existente
                        Console.Write("Ingrese el número ISBN: ");
                        string entrada = Console.ReadLine();
                        isbnValido = int.TryParse(entrada, out isbn);

                        if (!isbnValido)
                        {
                            Console.WriteLine("Error: el ISBN debe ser un número.");
                        }
                        else if (pila.ExisteISBN(isbn))
                        {
                            Console.WriteLine("Error: ya existe un libro con ese número ISBN.");
                            isbnValido = false;
                        }
                    } while (!isbnValido);
                    libro.ISBN = isbn;

                    int anio;
                    bool anioValido;
                    do
                    {
                        //solicitud del año de publicación del libro, validación por si se digita un dato que no sea int.
                        //Validación para que el año solo sea valido si este entre 1000-2025.
                        Console.Write("Ingrese el año de publicación: ");
                        string entrada = Console.ReadLine();
                        anioValido = int.TryParse(entrada, out anio);

                        if (!anioValido)
                        {
                            Console.WriteLine("Error: el año debe ser un número.");
                        }
                        if (anio < 1000 || anio > 2025)
                        {
                            Console.WriteLine("Es imposible que el año del libro sea el numero digitado, por favor digite un año valido");
                        }
                    } while (!anioValido || anio < 1000 || anio > 2025);
                    libro.AnioPublicacion = anio;

                    //Llamada a la funcion Apilar de la clase Pila Dinamica
                    pila.Apilar(libro);
                    Console.WriteLine("");
                    Console.WriteLine("Se ha registrado el libro correctamente");
                    Console.WriteLine("Por favor pulse cualquier tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                    break;

                case 2:
                    //Instancia de la clase Libro con el objeto eliminado
                    Libro eliminado = pila.Desapilar();
                    //Se evalua que la pila no este vacia
                    if (eliminado != null)
                    {
                        Console.WriteLine("Se ha desapilado el siguiente libro: ");
                        Console.WriteLine(eliminado);
                        Console.WriteLine("");
                        Console.WriteLine("Por favor pulse cualquier tecla para continuar...");
                    }
                    Console.ReadKey();
                    Console.Clear();
                    break;

                case 3:
                    //llamamos a la funcion para que muestre los libros registrados
                    pila.MostrarPila();
                    Console.ReadKey();
                    Console.Clear();
                    break;

                case 4:
                    //Salida del ciclo do-while y cierre del sistema
                    Console.WriteLine("Saliendo del sistema...");
                    Console.WriteLine("Por favor pulse cualquier tecla para cerrar...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                default:
                    //Validación en caso que se digite una opcion invalida
                    Console.WriteLine("La opcion seleccionada no forma parte del menu, por favor seleccione una opcion valida.");
                    Console.WriteLine("Pulse cualquier tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }
            Console.Clear();
        }
        while (opcion != 4);
    }
}