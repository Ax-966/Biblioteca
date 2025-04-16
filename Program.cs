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
                
                                for(int i = 0; i < B1.ListaSocios.Count; i++)
                                {
                                    s =(Socio)B1.ListaSocios[i];
                                    if(s.Dni == dn)
                                    {
                                        asociado = true;
                                        for(int j = 0; i < B1.ListaEjemplares.Count; j++)
                                        {
                                            Ejemplar e =(Ejemplar)B1.ListaEjemplares[j];
                                            if(e.NDni == dn)
                                            {
                                                asociadoAlibro = true;
                                                break;
                
                                            }
                                        }
                                    }
                                }
                                if(asociado == true && asociadoAlibro == false)
                                {
                                    B1.DarDeBaja(s);
                                    Console.WriteLine("Se elimino correctamente");
                                    
                                }
                                else if(asociadoAlibro)
                                {
                                    Console.WriteLine("Se encontró al socio con ese dni, pero no se puede eliminar porque tiene un libro prestado je");
                                   
                                }
                                else
                                {
                                    Console.WriteLine("No se encontró ese dni asociado a ningún socio.");
                                }
                                        
                                    
                                  
                                
                                Console.WriteLine("¿Desea eliminar un socio?");
                                eliminarSocio = Console.ReadLine();
                            }
                            for(int i = 0; i < B1.ListaSocios.Count; i++)
                            {
                                Socio s =(Socio)B1.ListaSocios[i];
                                Console.WriteLine("Nombre y apellido del socio eliminado: " + s.NombreApellido + "DNI: " + s.Dni);
                            }
                            break;
                        case 3:
                           
                            break;
                        case 4:
                            
                            break;
                        case 5:
                            
                            break;
                         case 6:
                            
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

                Console.WriteLine(); // Espacio para mejorar la legibilidad
            } while (option != 8);

            

            
            // >>>>>>>>>>>>>>>>>>> E L I M I N A R  -  S O C I O <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            
           
            
           


//
//












































































































                // >>>>>>>>>>>>>>> A G R E G A R  -  E J E M P L A R  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

           //   Biblioteca B1 = new Biblioteca("Sara", "Quilmes");
             int codigo, ejemplar; string titulo, autor, editorial,  condicion, respuestaL;
    
//          
            Console.WriteLine("¿Desea ingresar un Libro? (si/no)");
            respuestaL = Console.ReadLine();
            while (respuestaL.ToLower() == "si")
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
                            if (B1.ListaEjemplares != null && B1.ListaEjemplares.Count > 0)
                            {
                                Ejemplar E = (Ejemplar)B1.ListaEjemplares[B1.ListaEjemplares.Count - 1];
                                ejemplar = E.NEjemplar + 1;
                                Ejemplar NuevoEjemplar = new Ejemplar(cod, titulo, autor, editorial, condicion, ejemplar);
                                B1.AgregarLibro(NuevoEjemplar);
                                Console.WriteLine("Se agrego un nuevo ejemplar");
                            }
                      
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

           //  >>>>>>>>>>>>>>>> E L I M I N A R  -  E J E M P L A R <<<<<<<<<<<<<<<<<<<<<<<<<<<<


            Console.WriteLine("¿Desea eliminar algún libro?");
            respuestaL = Console.ReadLine();
            while (respuestaL == "si")
            {
                Console.WriteLine("Ingrese el código");
                int cod = int.Parse(Console.ReadLine());

                Console.WriteLine("¿Qué número de ejemplar desea eliminar?");
                int eleccion = int.Parse(Console.ReadLine());
               

                bool libroEncontrado = false; // Indicador de que se encontró el libro

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
           // }
            }
            // >>>>>>>>>>>< P R E S T A R  -  L I B R O  <<<<<<<<<<<<<<<<<<<<<<<<<
        
             string c, ds, resV;

           
            
            Console.WriteLine("¿Desea pedir un libro?");
            resV = Console.ReadLine();
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
        // Caso: El libro existe, pero no hay ejemplares disponibles
                     Console.WriteLine("Se encontró el libro, pero ningún ejemplar está disponible.");
                }
                else if (!existeSocio || !existeEjemplar)
                {
        // Caso: No se encontró el socio o el libro
                    Console.WriteLine("No se ha encontrado al socio o al libro.");
                }

                Console.WriteLine("¿Desea pedir un libro?");
                resV = Console.ReadLine();
            }
        
        // >>>>>>>>>>>>> D E V O L V E R -  L I B R O <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
         string resD;
        bool existePrestado = false;
        int codDevolver;
        Console.WriteLine("desea devolver libro?");
        resD = Console.ReadLine();

while (resD == "si")
{
    Console.WriteLine("Ingrese el código del libro");
    codDevolver = int.Parse(Console.ReadLine());
    

    for (int i = 0; i < B1.ListaSocios.Count; i++)
    {
        Socio s = (Socio)B1.ListaSocios[i]; // Puede ser Socio o SocioLector
        for(int j = 0; j < s.Historial.Count; j++)
        {
            Ejemplar registro = (Ejemplar)s.Historial[i];

            if (registro.Codigo == codDevolver)
             {
                int e;
                Console.WriteLine("Ingrese el número del ejemplar");
                e = int.Parse(Console.ReadLine());
    
                if (registro.NEjemplar == e)
                {
                    Console.WriteLine($"El ejemplar está asociado al socio cuyo DNI es: {registro.NDni}");
                    s.DevolverLibro(registro); // Llama al método de la clase específica (Socio o SocioLector)
                    break;
                }
            }    
        }
    }
    Console.WriteLine("desea devolver libro?");
    resD = Console.ReadLine();
   
}
            
        
        }
        public static void MostrarMenu()
        {
           Console.WriteLine("--- Menú Principal ---");
           Console.WriteLine("1. Agregar socio");
           Console.WriteLine("2. Eliminar Socio");
           Console.WriteLine("3. Agregar libro");
           Console.WriteLine("4. Eliminar libro");
           Console.WriteLine("5. Prestar libro");
           Console.WriteLine("6. Devolver libro");
           Console.WriteLine("7. Submenú");
           Console.WriteLine("8. Salir");
           Console.Write("Seleccione una opción: ");
        }
         public static void MostrarSubMenu()
        {
           Console.WriteLine("--- Submenú ---");
           Console.WriteLine("1. Buscar socio");
           Console.WriteLine("2. Lista de socios");
           Console.WriteLine("3. Buscar libro");
           Console.WriteLine("4. Lista de libros");
           Console.WriteLine("5. Salir");
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
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
