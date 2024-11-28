# Biblioteca

using System;
using System.Collections;

namespace Biblioteca
{
    class Program
    {
        public static void Main(string[] args)
        {
            Biblioteca B1 = new Biblioteca("Sara", "Quilmes");
            string titulo, autor, editorial, estado, condicion, respuesta;
            int codigo, ejemplar;
            Socio dni = null;
            DateTime fechaPrestamo = DateTime.MinValue;
            DateTime fechaDevolucion = DateTime.MinValue;

            Console.WriteLine("¿Desea ingresar un Libro? (si/no)");
            respuesta = Console.ReadLine();
            while (respuesta == "si")
            {
                Console.WriteLine("Titulo: ");
                titulo = Console.ReadLine();
                Console.WriteLine("Autor: ");
                autor = Console.ReadLine();
                Console.WriteLine("Editorial: ");
                editorial = Console.ReadLine();
                Console.WriteLine("Estado: ");
                estado = Console.ReadLine();
                Console.WriteLine("Condicion: ");
                condicion = Console.ReadLine();

                // Verificar si ya hay libros en la lista
                if (B1.ListaLibros != null && B1.ListaLibros.Count > 0)
                {
                    bool libroExistente = false; // Variable para controlar si el libro existe
                    for (int i = 0; i < B1.ListaLibros.Count; i++) // Cambié el `<=` por `<`
                    {
                        Libro libro = (Libro)B1.ListaLibros[i];
                        if (libro.Titulo == titulo && libro.Autor == autor)
                        {
                            libroExistente = true; // Marcamos que existe el libro
                            int cod = libro.Codigo;
                            if (B1.ListaEjemplares != null && B1.ListaEjemplares.Count > 0)
                            {
                                Ejemplar E = (Ejemplar)B1.ListaEjemplares[B1.ListaEjemplares.Count - 1];
                                ejemplar = E.NEjemplar + 1;
                                Ejemplar NuevoEjemplar = new Ejemplar(cod, titulo, autor, editorial, estado, dni, fechaPrestamo, fechaDevolucion, condicion, ejemplar);
                                B1.AgregarLibro(NuevoEjemplar);
                                Console.WriteLine("Se agrego un nuevo ejemplar");
                            }
                            else
                            {
                                ejemplar = 1;
                                Ejemplar NuevoEjemplar = new Ejemplar(cod, titulo, autor, editorial, estado, dni, fechaPrestamo, fechaDevolucion, condicion, ejemplar);
                                B1.AgregarLibro(NuevoEjemplar);
                                Console.WriteLine("No había ningún libro en la lista ejemplares, se agrego el primero");
                            }
                            break; // Salimos del bucle ya que encontramos el libro
                        }
                    }

                    // Si el libro no existe, agregamos un nuevo libro
                    if (!libroExistente)
                    {
                        Libro lib = (Libro)B1.ListaLibros[B1.ListaLibros.Count - 1];
                        codigo = lib.Codigo + 1;
                        Libro L1 = new Libro(codigo, titulo, autor, editorial, estado, dni, fechaPrestamo, fechaDevolucion, condicion);
                        B1.AgregarLibro(L1);
                        Console.WriteLine("Se agregó un nuevo libro.");
                    }
                }
                else
                {
                    // Si no hay libros, agregamos el primero
                    codigo = 1;
                    Libro L1 = new Libro(codigo, titulo, autor, editorial, estado, dni, fechaPrestamo, fechaDevolucion, condicion);
                    B1.AgregarLibro(L1);
                    Console.WriteLine("Se agregó el primer libro.");
                }

                // Pregunta al final del bloque while
                Console.WriteLine("¿Desea ingresar otro Libro? (si/no)");
                respuesta = Console.ReadLine();
            }
            if(B1.ListaLibros != null && B1.ListaLibros.Count > 0)
            {  for(int i = 0; i < B1.ListaLibros.Count; i++)
               {
                 Libro libro = (Libro)B1.ListaLibros[i];
                 Console.WriteLine("Los libros son: " + " Codigo: " + libro.Codigo + "  Titulo: "+ libro.Titulo + " Autor: " + libro.Autor);
               }
            }
            else{
              Console.WriteLine("No hay libros");
            }
             if(B1.ListaEjemplares != null && B1.ListaEjemplares.Count > 0)
             {  for(int i = 0; i < B1.ListaEjemplares.Count; i++)
               {
                 Ejemplar libro = (Ejemplar)B1.ListaEjemplares[i];
                 Console.WriteLine("Los libros son: " + " Codigo:" +libro.Codigo + " Titulo:"+ libro.Titulo + " Autor:" + libro.Autor + " Número de ejemplar :" + libro.NEjemplar);
               }
             }
             else{
               Console.WriteLine("No hay ejemplares");
             }
        }   
    }
}