using System;
using System.Collections;
using System.Runtime.Intrinsics.X86;

namespace Biblioteca
{
    class Program
    {
        public static void Main(string[] args)
        {
                // >>>>>>>>> PRUEBA DATETIME <<<<<<<<<<<<<<<<

            //    DateTime fp = new DateTime(2024, 11, 27); 
            //    DateTime fd = new DateTime(2024, 11, 10); 
//
           //
            //    int diasRestantes = (fd - fp).Days;
//
            //    if (diasRestantes > 0)
            //    {
            //        Console.WriteLine($"Faltan {diasRestantes} días para llegar a la fecha límite.");
            //    }
            //    else
            //    {
            //        Console.WriteLine("La fecha límite ya ha pasado o es hoy.");
            //    }
//
//
//
//
//
//
//
//
//
//
//
//
//
            Biblioteca B1 = new Biblioteca("Sara", "Quilmes");

          
            //       >>>>>>>>>  A G R E G A R  -  S O C I O  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            string nombreApellido, direccion, respuestaS, leer; int dni, telefono, cantLibros;
              
            Console.WriteLine("¿Desea agregar a un socio?");
            respuestaS = Console.ReadLine();
            
            while(respuestaS == "si")
            {
                Console.WriteLine("Ingrese su nombre y apellido: ");
                nombreApellido = Console.ReadLine();
                Console.WriteLine("Ingrese el DNI: ");
                dni = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese su télefono: ");
                telefono = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese su dirección: ");
                direccion = Console.ReadLine();
                
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

                // Si el socio ya existe, preguntar si desea agregar otro y evitar más lógica
                if (existeSocio)
                {
                    Console.WriteLine("¿Desea agregar otro socio?");
                    respuestaS = Console.ReadLine();
                }
                else
                {
                    // Si el socio no existe, proceder a agregarlo
                    cantLibros = 0;
                    Console.WriteLine("¿Desea leer dentro de: " + B1.Nombre + " también?");
                    leer = Console.ReadLine();
                    if (leer == "si")
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
                    respuestaS = Console.ReadLine();
                }
            }
            for(int i = 0; i < B1.ListaSocios.Count; i++)
            {
                Socio s =(Socio)B1.ListaSocios[i];
                Console.WriteLine("Nombre y apellido: " + s.NombreApellido + "DNI: " + s.Dni);
            }
//          
            // >>>>>>>>>>>>>>>>>>> E L I M I N A R  -  S O C I O <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            Console.WriteLine("¿Desea eliminar a un socio?");
            respuestaS = Console.ReadLine();
            
            while(respuestaS == "si")
            {
                Console.WriteLine("Ingrese su dni: ");
                int dn = int.Parse(Console.ReadLine());
                bool asociado = false;

                for(int i = 0; i < B1.ListaSocios.Count; i++)
                {
                    Socio s =(Socio)B1.ListaSocios[i];
                    if(s.Dni == dn)
                    {
                        for(int j = 0; i < B1.ListaEjemplares.Count; j++)
                        {
                            Ejemplar e =(Ejemplar)B1.ListaEjemplares[j];
                            if(e.NDni == dn)
                            {
                                asociado = true;
                                Console.WriteLine("No se puede eliminar, tiene libros prestados");
                                break;

                            }
                        }
                        if(asociado)
                        {
                            Console.WriteLine("¿Desea eliminar un socio?");
                            respuestaS = Console.ReadLine();
                        }
                        else
                        {
                            B1.DarDeBaja(s);
                            Console.WriteLine("Se elimino correctamente");
                            Console.WriteLine("¿Desea eliminar un socio?");
                            respuestaS = Console.ReadLine();
                        }
                        
                    }
                }
            }
             for(int i = 0; i < B1.ListaSocios.Count; i++)
            {
                Socio s =(Socio)B1.ListaSocios[i];
                Console.WriteLine("Nombre y apellido: " + s.NombreApellido + "DNI: " + s.Dni);
            }


//
//












































































































                // >>>>>>>>>>>>>>> A G R E G A R  -  E J E M P L A R  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

           //   Biblioteca B1 = new Biblioteca("Sara", "Quilmes");
             int codigo, ejemplar; string titulo, autor, editorial, estado, condicion, respuestaL;
    
//          
            Console.WriteLine("¿Desea ingresar un Libro? (si/no)");
            respuestaL = Console.ReadLine();
            while (respuestaL == "si")
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
                                Ejemplar NuevoEjemplar = new Ejemplar(cod, titulo, autor, editorial, estado,condicion, ejemplar);
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
                        Ejemplar L1 = new Ejemplar(codigo, titulo, autor, editorial, estado, condicion, ejemplar);
                        B1.AgregarLibro(L1);
                        Console.WriteLine("Se agregó un nuevo libro.");
                    }
                }
                else
                {
                    
                    codigo = 1;
                    ejemplar = 1;
                    Ejemplar e1 = new Ejemplar(codigo, titulo, autor, editorial, estado, condicion, ejemplar);
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
        
            int ds, c; string  resV;

           
            
            Console.WriteLine("¿Desea pedir un libro?");
            resV = Console.ReadLine();
            while(resV == "si")
            {
                 Console.WriteLine("Ingrese el Dni del socio: ");
                 ds = int.Parse(Console.ReadLine());
                 Console.WriteLine("Ingrese el titulo del libro");
                 c = int.Parse(Console.ReadLine());
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
                    if(e.Codigo == c)
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
    Console.WriteLine("desea devolver libro?");
    resD = Console.ReadLine();
}
            B1.RepararLibro();
        }
    }
}
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
