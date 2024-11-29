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
        private int [] salas;
        
        public Biblioteca(string nombre, string direccion)
        {
            this.nombre = nombre;
            this.direccion = direccion;
            listaSocios = new ArrayList();
            listaEjemplares = new ArrayList();
            librosReparacion = new ArrayList();
            salas = new int[]{1,2,3,4,5};
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
            string res;
            bool tieneFecha = false;
            
        
            if (lib.NDni != 0 && lib.Estado == "prestado")
            {
                throw new PrestamoException("El libro ya está prestado a otro socio.");
            }
            if(lib.Estado == "reparacion" && lib.Condicion == "mala")
            {
                throw new PrestamoException("El libro esta en reparación o en malas condiciones");
            }

         
            if (s.CantLibros > 0 && s.GetType() == typeof(Socio))
            {
                throw new PrestamoException("El socio ya tiene otro libro en préstamo.");
            }
            if(s.GetType() == typeof(SocioLector))
            {
                Console.WriteLine("Desea llevarlo a su casa");
                res = Console.ReadLine(); 
                if(res == "si")
                {
                     for(int i = 0; i < s.Historial.Count; i++)
                     {
                        Ejemplar registro =(Ejemplar)s.Historial[i];
                        if (registro.FechaPrestamo != DateTime.MinValue && registro.FechaPrestamo != DateTime.MaxValue && registro.FechaDevolucion != DateTime.MinValue && registro.FechaDevolucion != DateTime.MaxValue)
                        {
                            tieneFecha = true;
                            Console.WriteLine("No se puede llevar el libro, solo leer aquí");
                            break;
                        }
                    }
                }
               
            if(tieneFecha == false)
            {
                
                
                    lib.NDni = s.Dni;
                    lib.Estado = "prestado";
                    s.CantLibros = s.CantLibros + 1;
                    lib.FechaPrestamo = fp;
                    lib.FechaDevolucion = fd;
                    s.Historial.Add(lib);
                    Console.WriteLine("Se agrego el libro al socio");
                    Console.WriteLine($"Préstamo realizado con éxito:");
                    Console.WriteLine($"Título del libro: {lib.Titulo}");
                    Console.WriteLine($"Fecha inicial: {fp:yyyy-MM-dd}");
                    Console.WriteLine($"Fecha de devolución: {fd:yyyy-MM-dd}");
                
            }   
            else
            {
                    int eleccion;
                    lib.NDni = s.Dni;
                    s.CantLibros++;
                    s.Historial.Add(lib);
                    Console.Write("Esta son las salas: ");
                    foreach(int sala in Salas)
                    {
                        Console.WriteLine(sala);
                    }
                    Console.Write("Elija una sala: ");
                    eleccion = int.Parse(Console.ReadLine());
                    if(eleccion <= 5 && eleccion > 0)
                    {
                        SocioLector lector =(SocioLector)s;
                        lector.Sala = eleccion;
                        Console.WriteLine("Perfecto, su sala es: " + lector.Sala);
                    }
                }
                 
               
                
                
            
               

               
               
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
                Console.WriteLine("Se agrego el libro al socio");
                     Console.WriteLine($"Préstamo realizado con éxito:");
                    Console.WriteLine($"Título del libro: {lib.Titulo}");
                     Console.WriteLine($"Fecha inicial: {fp:yyyy-MM-dd}");
                     Console.WriteLine($"Fecha de devolución: {fd:yyyy-MM-dd}");
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
        public int []Salas
        {
            get
            {
                return salas;
            }
        }
    }
}