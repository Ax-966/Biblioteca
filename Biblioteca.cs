using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Biblioteca
    {
        private string nombre;
        private string direccion;
        private ArrayList listaSocios;
        private ArrayList listaEjemplares;
        private ArrayList librosReparacion;
        
        public Biblioteca(string nombre, string direccion)
        {
            this.nombre = nombre;
            this.direccion = direccion;
            listaSocios = new ArrayList();
            listaEjemplares = new ArrayList();
            librosReparacion = new ArrayList();
        }
        public void AgregarLibro(Libro libro)
        {
          listaEjemplares.Add(libro);
        }
        public void EliminarLibro(Libro libro)
        {
            listaEjemplares.Remove(libro);
        }
        public void AgregarSocio(Socio socio)
        {
            listaSocios.Add(socio);
        }
        public void DarDeBaja(Socio s)
        {
            listaSocios.Remove(s);
        }
        public void PrestarLibro(Socio s, Libro lib)
        {
            DateTime fp = DateTime.Today;
            DateTime fd = fp.AddDays(15);
         
            if (lib.NDni != 0 && lib.Estado == "prestado")
            {
                throw new PrestamoException("El libro ya está prestado a otro socio.");
            }
            if(lib.Estado == "reparacion")
            {
                throw new PrestamoException("El libro esta en reparación");
            }

            // Validar si el socio ya tiene otro libro en préstamo
            if (s.CantLibros > 0)
            {
                throw new PrestamoException("El socio ya tiene otro libro en préstamo.");
            }

        // Realizar el préstamo
            if(s.GetType() == typeof(Socio))
            {
                lib.NDni = s.Dni;
                lib.Estado = "prestado";
                s.CantLibros = s.CantLibros + 1;
                lib.FechaPrestamo = fp;
                lib.FechaDevolucion = fd;
                s.Historial.Add(lib);
                Console.WriteLine("Se agrego los libros al socio");
                     Console.WriteLine($"Préstamo realizado con éxito:");
                    Console.WriteLine($"Título del libro: {lib.Titulo}");
                     Console.WriteLine($"Fecha inicial: {fp:yyyy-MM-dd}");
                     Console.WriteLine($"Fecha de devolución: {fd:yyyy-MM-dd}");
            }
            else{
                lib.NDni = s.Dni;
                s.CantLibros++;
                s.Historial.Add(lib);
                Console.WriteLine("El socio lector puede agregar todos los libros que quiera");
            }
            

      
        }

         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
           // if(lib.NDni == 0)
           // {
           //     if(s.GetType() == typeof(Socio))
           //     {
           //         if(s.CantLibros == 0)
           //         {
           //             lib.NDni = s.Dni;
           //             s.CantLibros = 1;
           //             lib.FechaPrestamo = fp;
           //             lib.FechaDevolucion = fd;
           //             Console.WriteLine($"Fecha inicial: {fp:yyyy-MM-dd}");
           //             Console.WriteLine($"Fecha después de 15 días: {fd:yyyy-MM-dd}");
           //             
           //         }
           //     }
           //     else
           //     {
           //         lib.NDni = s.Dni;
           //         s.CantLibros = s.CantLibros + 1;
           //         Console.WriteLine("Se agrego el libro al socio lector");
           //     }
           // }
           // else
           // {
           //     Console.WriteLine("No se puede prestar porque el libro ya lo tiene un socio");
           // }
        
        public void DevolverLibro(Libro lib)
        {

        }
        public string Nombre
        {
            get{
                return nombre;
            }
            set{
                nombre = value;
            }
        }
        public string Direccion
        {
            get{
                return direccion;
            }
            set{
                direccion = value;
            }
        }
   
        public ArrayList ListaSocios{
            get{
                return listaSocios;
            }
            set{
                   listaSocios = value;
            }
        }
         public ArrayList ListaEjemplares{
            get{
                return listaEjemplares;
            }
            set{
                   listaEjemplares = value;
            }
        }
         public ArrayList LibrosReparacion{
            get{
                return librosReparacion;
            }
            set{
                   librosReparacion = value;
            }
        }
        
    }
}