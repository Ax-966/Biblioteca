using System;
using System.Collections;
using System.Runtime.Intrinsics.X86;
using System.Text.RegularExpressions;


namespace Biblioteca
{
    class Program
    {
        public static void Main(string[] args)
        {
            Biblioteca B1 = new Biblioteca("Sara", "Quilmes");


            Socio socio1 = new Socio("Juan Pérez", "12345678", "11-1234-5678", "Calle Falsa 123", 2);
            Socio socio2 = new Socio("María Gómez", "98765432", "11-9876-5432", "Avenida Siempreviva 742", 1);
            SocioLector socioLector1 = new SocioLector("Carlos López", "45678912", "11-4567-8912", "Pasaje El Zorzal 555", 0, 1);
            SocioLector socioLector2 = new SocioLector("Milagros", "19320218", "11-4567-8912", "Varela", 0, 0);

            Ejemplar libro1 = new Ejemplar(100, "El Señor de los Anillos", "J.R.R. Tolkien", "Minotauro", "buena", 2);
            Ejemplar libro2 = new Ejemplar(205, "La invención de Morel", "Bioy Casares", "Alfaguara", "buena", 1);
            Ejemplar libro3 = new Ejemplar(101, "Cumbres Borrascosas", "Emily Brontë", "Penguin Classics", "buena", 1);
            Ejemplar libro4 = new Ejemplar(102, "Dormir al sol", "Adolfo Bioy Casares", "Editorial Sudamericana", "buena", 2);
            Ejemplar libro5 = new Ejemplar(103, "Retrato de un náufrago", "Gabriel García Márquez", "Editorial Planeta", "buena", 3);


        
           
            B1.AgregarSocio(socio1);
            B1.AgregarSocio(socio2);
            B1.AgregarSocio(socioLector1);
            B1.AgregarSocio(socioLector2);

            B1.AgregarLibro(libro1);
            B1.AgregarLibro(libro2);
            B1.AgregarLibro(libro3);
            B1.AgregarLibro(libro4);
            B1.AgregarLibro(libro5);
            int option;
            do
            {
                MostrarMenu();
                if (int.TryParse(Console.ReadLine(), out option))
                {
                    switch (option)
                    {
                        case 1:
                            string nombreApellido, direccion, leer, dni, telefono; int cantLibros;
                            string respuestaSocio = "si";
              
                            while(respuestaSocio.ToLower() == "si")
                            {
                               
                                nombreApellido = InputHelper.PedirTextoValido("Ingrese su nombre y apellido:", EsNombreValido);
                                dni =  InputHelper.PedirTextoValido("Ingrese su DNI:", x => EsNumeroValido(x, 7, 8));
                                telefono = InputHelper.PedirTextoValido("Ingrese un télefono:", x =>EsNumeroValido(x, 10));
                                direccion = InputHelper.PedirTextoValido("Ingrese una dirección:",EsTextoLibreValido);
                
                                bool existeSocio = false;
                                if (B1.ListaSocios != null && B1.ListaSocios.Count > 0)
                                {
                                    for (int i = 0; i < B1.ListaSocios.Count; i++)
                                    {
                                        Socio socio = (Socio)B1.ListaSocios[i];
                                        if (socio.Dni == dni)
                                        {
                                            existeSocio = true;
                                            Console.WriteLine("El socio ya existe");
                                            break;
                                        }
                                    }
                                }
                                if (existeSocio)
                                {
                                    Console.WriteLine("¿Desea agregar otro socio?");
                                    respuestaSocio = Console.ReadLine();
                                }
                                else
                                {
                                    cantLibros = 0;
                                    Console.WriteLine($"¿Desea leer dentro de: {B1.Nombre}  también?");
                                    leer = Console.ReadLine();
                                   
                                    if (leer.ToLower() == "si")
                                    {
                                        int s = 0;
                                        SocioLector sl = new SocioLector(nombreApellido, dni, telefono, direccion, cantLibros, s);
                                        B1.AgregarSocio(sl);
                                    }
                                    else
                                    {
                                        Socio s = new Socio(nombreApellido, dni, telefono, direccion, cantLibros);
                                        B1.AgregarSocio(s);
                                    }

                                    Console.WriteLine("¿Desea agregar otro socio?");
                                    respuestaSocio = Console.ReadLine();
                                }
                            }
                            for(int i = 0; i < B1.ListaSocios.Count; i++)
                            {
                                Socio s =(Socio)B1.ListaSocios[i];
                                Console.WriteLine("Nombre y apellido: " + s.NombreApellido + "DNI: " + s.Dni);
                            }
                            break;
                        case 2:
                            string eliminarSocio = "si";
                            while(eliminarSocio.ToLower() == "si")
                            {
                                Console.WriteLine("Ingrese su dni: ");
                                string dn = Console.ReadLine();
                                bool asociado = false;
                                bool asociadoAlibro = false;
                                Socio s = null;

                                if(B1.ExisteSocio(dn))
                                {
                                    if(B1.ListadoLibros != null)
                                    {
                                        for(int l = 0; l < B1.ListaEjemplares.Count; l++)
                                        {
                                            Ejemplar ePrestado =(Ejemplar)B1.ListaEjemplares[l];
                                            if(ePrestado.NDni == dn)
                                            {
                                                asociadoAlibro = true;
                                                break;
                                            }
                                        }
                                        if(asociadoAlibro == false)
                                        {
                                            for(int socio = 0; socio < B1.ListaSocios.Count; socio++)
                                            {
                                                Socio eliminar = (Socio)B1.ListaSocios[socio];
                                                if(eliminar.Dni == dn)
                                                {
                                                  B1.DarDeBaja(eliminar);
                                                  Console.WriteLine("Se ha eliminado correctamente");
                                                  break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("No se puede eliminar porque esta asociado a un libro");
                                        }
                                    }
                                    else{
                                         for(int socio = 0; socio < B1.ListaSocios.Count; socio++)
                                            {
                                                Socio eliminar = (Socio)B1.ListaSocios[socio];
                                                if(eliminar.Dni == dn)
                                                {
                                                  B1.DarDeBaja(eliminar);
                                                  Console.WriteLine("Se ha eliminado correctamente");
                                                  break;
                                                }
                                            }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("No existe el socio");
                                }
                                B1.ListadoSocios();
                              
                                Console.WriteLine("¿Desea eliminar un socio?");
                                eliminarSocio = Console.ReadLine();
                            }
                        
                            break;
                        case 3:
                            int codigo, ejemplar; string titulo, autor, editorial,  condicion, respuestaL;
                            string respuestaEjemplar = "si";
    
                            while (respuestaEjemplar.ToLower() == "si")
                            {
                                Console.WriteLine("Titulo: ");
                                titulo = Console.ReadLine();
                                Console.WriteLine("Autor: ");
                                autor = Console.ReadLine();
                                Console.WriteLine("Editorial: ");
                                editorial = Console.ReadLine();
                                Console.WriteLine("Condicion: ");
                                condicion = Console.ReadLine();

              
                                if (B1.ListaEjemplares != null && B1.ListaEjemplares.Count > 0)
                                {
                                    bool libroExistente = false; 
                                    for (int i = 0; i < B1.ListaEjemplares.Count; i++) 
                                    {
                                        Ejemplar  e = (Ejemplar)B1.ListaEjemplares[i];
                                        if (e.Titulo == titulo && e.Autor == autor)
                                        {
                                            libroExistente = true; 
                                            int cod = e.Codigo;
                            
                                            Ejemplar E = (Ejemplar)B1.ListaEjemplares[B1.ListaEjemplares.Count - 1];
                                            ejemplar = E.NEjemplar + 1;
                                            Ejemplar NuevoEjemplar = new Ejemplar(cod, titulo, autor, editorial, condicion, ejemplar);
                                            B1.AgregarLibro(NuevoEjemplar);
                                            Console.WriteLine("Se agrego un nuevo ejemplar");
                                            break; 
                                        }
                                    }
                
                                    if (!libroExistente)
                                    {
                                        Ejemplar lib = (Ejemplar)B1.ListaEjemplares[B1.ListaEjemplares.Count - 1];
                                        codigo = lib.Codigo + 1;
                                        ejemplar = 1;
                                        Ejemplar L1 = new Ejemplar(codigo, titulo, autor, editorial,  condicion, ejemplar);
                                        B1.AgregarLibro(L1);
                                        Console.WriteLine("Se agregó un nuevo libro.");
                                    }
                                }
                                else
                                {
                                    
                                    codigo = 1;
                                    ejemplar = 1;
                                    Ejemplar e1 = new Ejemplar(codigo, titulo, autor, editorial,  condicion, ejemplar);
                                    B1.AgregarLibro(e1);
                                    Console.WriteLine("Se agregó el primer libro.");
                                }
                
                                Console.WriteLine("¿Desea ingresar otro Libro? (si/no)");
                                respuestaEjemplar = Console.ReadLine();
                            }
                            if(B1.ListaEjemplares != null && B1.ListaEjemplares.Count > 0)
                            {  
                                for(int i = 0; i < B1.ListaEjemplares.Count; i++)
                                {
                                  Ejemplar e = (Ejemplar)B1.ListaEjemplares[i];
                                  Console.WriteLine("Los libros son: " + " Codigo: " + e.Codigo + "  Titulo: "+ e.Titulo + " Autor: " + e.Autor + " Número de ejemplar: " + e.NEjemplar);
                                }
                            }
                            else{
                                Console.WriteLine("No hay libros");
                            }
                            break;
                        case 4:
                             
                            string respuestaBorrar = "si";
                            while (respuestaBorrar == "si")
                            {
                               Console.WriteLine("Ingrese el código");
                               int cod = int.Parse(Console.ReadLine());
               
                               Console.WriteLine("¿Qué número de ejemplar desea eliminar?");
                               int eleccion = int.Parse(Console.ReadLine());
                              
               
                               bool libroEncontrado = false; 

                               for (int i = 0; i < B1.ListaEjemplares.Count; i++)
                               {
                                   Ejemplar e = (Ejemplar)B1.ListaEjemplares[i];
               
                                   if (e.NEjemplar == eleccion && e.Codigo == cod)
                                   {
                                       libroEncontrado = true;
               
                                       if (e.Estado != "prestado" && e.Estado != "reparacion")
                                       {
                                           B1.EliminarLibro(e);
                                           Console.WriteLine("El libro ha sido eliminado");
                                       }
                                       else
                                       {
                                           Console.WriteLine("El libro está prestado o en reparación y no se puede eliminar");
                                       }
                                       break; 
                                   }
                                }

                                if (!libroEncontrado)
                                {
                                   Console.WriteLine("No se encontró un libro con ese código y número de ejemplar.");
                                }

                                Console.WriteLine("¿Desea eliminar otro libro? (si/no)");
                                respuestaL = Console.ReadLine();
                            }   
                
                            if(B1.ListaEjemplares != null && B1.ListaEjemplares.Count > 0)
                            {  for(int i = 0; i < B1.ListaEjemplares.Count; i++)
                               {
                                 Ejemplar e = (Ejemplar)B1.ListaEjemplares[i];
                                 Console.WriteLine("Los libros son: " + " Codigo: " + e.Codigo + "  Titulo: "+ e.Titulo + " Autor: " + e.Autor + " Número de ejemplar: " + e.NEjemplar);
                               }
                            }
                            else{
                              Console.WriteLine("No hay libros");
                           
                            }
                            break;
                        case 5:
                               string c, ds;

                               string resV = "si";
                               while(resV.ToLower() == "si")
                               {
                                    Console.WriteLine("Ingrese el Dni del socio: ");
                                    ds = Console.ReadLine();
                                    Console.WriteLine("Ingrese el titulo del libro");
                                    c = Console.ReadLine();
                                    bool existeSocio = false; bool existeEjemplar = false;
                                    Socio socioEncontrado = null; 
                                    Ejemplar ejemplarEncontrado = null;
                                    for(int i = 0; i < B1.ListaSocios.Count; i++)
                                    {
                                        Socio socio =(Socio)B1.ListaSocios[i];
                                        if(socio.Dni == ds)
                                        {
                                            existeSocio = true; Console.WriteLine("Se encontro al socio");
                                            socioEncontrado = socio;
                                            break;
                                        }
                                    }
                                    for(int j = 0; j < B1.ListaEjemplares.Count; j++)
                                    {
                                        Ejemplar e =(Ejemplar)B1.ListaEjemplares[j];
                                        if(e.Titulo == c)
                                        {
                                            existeEjemplar = true;
                                            if(e.Estado == "disponible")
                                            {
                                                ejemplarEncontrado = e;
                                                Console.WriteLine("Se encontro un ejemplar disponible"); 
                                                break;
                                            }
                                            
                                        }
                                        
                                    }
                                    if (existeSocio && existeEjemplar && ejemplarEncontrado != null)
                                    {
                                        try
                                        {
                                            B1.PrestarLibro(socioEncontrado, ejemplarEncontrado);
                                        }
                                        catch (PrestamoException ex)
                                        {
                                            Console.WriteLine($"Error: {ex.Message}");
                                        }
                                    }
                                    else if (existeEjemplar && ejemplarEncontrado == null)
                                    {
                    
                                         Console.WriteLine("Se encontró el libro, pero ningún ejemplar está disponible.");
                                    }
                                    else if (!existeSocio)
                                    {
                         
                                        Console.WriteLine("No se ha encontrado al socio.");
                                    }
                                    else if (!existeEjemplar)
                                    {
                         
                                        Console.WriteLine("No se ha encontrado al libro.");
                                    }
                    
                                    Console.WriteLine("¿Desea pedir un libro?");
                                    resV = Console.ReadLine();
                                }  
                                break;
                         case 6:
                                string resD = "si";
                                bool existePrestado = false; Socio socioDevuelve = null;
                                string tituloLibro; Ejemplar ejemplarHaDevolver = null;
                              

                                while (resD.ToLower() == "si")
                                {
                             
                                    string dn = InputHelper.PedirTextoValido("Ingrese su DNI:", x => EsNumeroValido(x, 7, 8));
                                    Ejemplar e = B1.obtenerEjemplarPorDni(dn);
                                    var socioBuscar = B1.obtenerSocio(dn);
                                    if (socioBuscar != null)
                                    {
                                        socioBuscar.DevolverLibro(e);
                                    }
                                    

                                Console.WriteLine("desea devolver libro?");
                                resD = Console.ReadLine();
                                }
                            
                            break;
                         case 7:
                            int opcionSub;

                            do
                            {
                                MostrarSubMenu();
                                if (int.TryParse(Console.ReadLine(), out opcionSub))
                                {
                                    switch(opcionSub)
                                    {
                                        case 1:
                                            dni =  InputHelper.PedirTextoValido("Ingrese su DNI:", x => EsNumeroValido(x, 7, 8));
                                            B1.BuscarSocio(dni);
                                            break;
                                        case 2:
                                            B1.ListadoSocios();
                                            break;
                                        case 3:
                                            string consulta = InputHelper.PedirTextoValido("Ingrese el título del libro:",EsTextoLibreValido);
                                            B1.BuscarLibro(consulta);
                                            break;
                                        case 4:
                                            B1.ListadoLibros();
                                            break;
                                        case 5:
                                            
                                            break;
                                    }
                                }
                            }while (opcionSub != 5);
                            
                            break;
                         case 8:
                            Console.WriteLine("Saliendo...");
                            break;
                        default:
                            Console.WriteLine("Opción inválida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opción inválida. Debe ingresar un número.");
                }

                Console.WriteLine(); 
            } while (option != 8);

   
            
        
        }
        public static void MostrarMenu()
        {
           Console.WriteLine("--- Menú Principal ---");
           Console.WriteLine("                      ");
           
           Console.WriteLine("1. Agregar socio");
           Console.WriteLine("2. Eliminar Socio");
           Console.WriteLine("3. Agregar libro");
           Console.WriteLine("4. Eliminar libro");
           Console.WriteLine("5. Prestar libro");
           Console.WriteLine("6. Devolver libro");
           Console.WriteLine("7. Submenú");
           Console.WriteLine("8. Salir");
           Console.WriteLine("                      ");
           Console.Write("Seleccione una opción: ");
        }
         public static void MostrarSubMenu()
        {
           Console.WriteLine("--- Submenú ---");
           Console.WriteLine("                      ");
           Console.WriteLine("1. Buscar socio");
           Console.WriteLine("2. Lista de socios");
           Console.WriteLine("3. Buscar libro");
           Console.WriteLine("4. Lista de libros");
           Console.WriteLine("5. Salir");
           Console.WriteLine("                      ");
           Console.Write("Seleccione una opción: ");
        }
        public static bool EsNombreValido(string texto)
        {
            var regex = new Regex(@"^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ\s]+$");
            return regex.IsMatch(texto);
        }
        public static bool EsTextoLibreValido(string texto)
        {
            var regex = new Regex(@"^[\w\sáéíóúÁÉÍÓÚüÜñÑ.,:;()\-']+$");
            return regex.IsMatch(texto);
        }
        public static bool EsNumeroValido(string texto, int longitudMin = 1, int longitudMax = 10)
        {
            return texto.All(char.IsDigit) && texto.Length >= longitudMin && texto.Length <= longitudMax;
        }
    }   
}
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
