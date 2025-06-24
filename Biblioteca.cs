using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
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
            
        
            if (lib.NDni != "0" && lib.Estado == "prestado")
            {
                throw new PrestamoException("El libro ya está prestado a otro socio.");
            }
            if(lib.Estado == "reparacion" || lib.Condicion == "mala")
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
                if(tieneFecha == false && res == "si")
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
                    lib.Estado = "prestado";
                    s.CantLibros++;
                    s.Historial.Add(lib);
                    SocioLector lector =(SocioLector)s;
                    if (lector.Sala == 0) 
                    {
                         Console.Write("Elija una sala del 1 al 5: ");
                         eleccion = int.Parse(Console.ReadLine());

                        if (eleccion > 0 && eleccion <= 5)
                        {
                            lector.Sala = eleccion;
                            Console.WriteLine("Perfecto, su sala es: " + lector.Sala);
                        }
                        else
                        {
                            Console.WriteLine("Sala no válida. Se asignará automáticamente a la sala 1.");
                            lector.Sala = 1; 
                        }
                    }
                    else
                    {
                      Console.WriteLine("Usted ya tiene una sala asignada: " + lector.Sala);
                    }
                }
            }
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
        public bool ExisteSocio(string dni)
        {
            if(listaSocios != null)
            {   for(int i = 0; i < listaSocios.Count; i++)
                {
                    Socio s = (Socio)listaSocios[i];

                    if(s != null && s.Dni == dni)
                    {
                        return true;
                    }
                }
                  
            }
            return false;
        }
        public bool ExisteLibro(string titulo)
        {
            if(listaEjemplares != null)
            {   for(int i = 0; i < listaEjemplares.Count; i++)
                {
                    Ejemplar ejemplar = (Ejemplar)listaEjemplares[i];

                    if(ejemplar != null && ejemplar.Titulo == titulo)
                    {
                        return true;
                    }
                }
                  
            }
            return false;
        }
        public void BuscarSocio(string dni)
        {
                    if(ExisteSocio(dni))
                    {
                        for(int i = 0; i < listaSocios.Count; i++)
                        {
                            Socio s = (Socio)listaSocios[i];

                            if(s.Dni == dni)
                            {
                                Console.WriteLine($"Nombre: {s.NombreApellido}");
                                if (s.Historial.Count > 0 && s.Historial.Count != null)
                                {
                                    for (int j = 0; j < s.Historial.Count; j++)
                                    {
                                        Ejemplar ejemplar = (Ejemplar)s.Historial[j];
                                        Console.WriteLine($"Libro {j + 1}: {ejemplar.Titulo}");
                                    }
                                    break;           
                                }
                                else
                                {
                                    Console.WriteLine("No hay libros en el historial de este socio.");
                                    break;
                                }
                         
                            }
                        }
                    }
                    else {
                        Console.WriteLine("El dni ingresado no corresponde a ningún socio");
                    }
                
        }
        public void BuscarLibro(string libro)
        { 

                    if(ExisteLibro(libro))
                    {
                        for(int i = 0; i < listaEjemplares.Count; i++)
                        {
                            Ejemplar e = (Ejemplar)listaEjemplares[i];

                            if(e.Titulo == libro)
                            {
                                Console.Write($"Código: {e.Codigo} , Título: {e.Titulo}, Autor: {e.Autor}, Estado: {e.Estado}, Ejemplar: {e.NEjemplar} Prestado: {e.NDni}");
                                break;
                            }
                        }
                    }
                    else {
                        Console.WriteLine("El dni ingresado no corresponde a ningún socio");
                    }
                
        }
        public Socio obtenerSocio(string dni)
        {
            Socio socio = null;
            for (int i = 0; i < listaSocios.Count; i++)
            {
                Socio s = (Socio)listaSocios[i];
                if (s.GetType() == typeof(Socio) && s.Dni == dni)
                {
                    socio = s;
                    Console.WriteLine("Encontrado socio: " + s.NombreApellido);
                    break;
                }
                else if (s.GetType() == typeof(SocioLector) && s.Dni == dni)
                {
                    socio = s;
                    Console.WriteLine("Encotrado socio lector: " + s.NombreApellido);
                    break;
                }
                else { Console.WriteLine("Buscando....."); }

            }
            if (!ExisteSocio(dni))
            {
                Console.WriteLine("No se encontró ningún socio con ese DNI. ");
            }
            return socio;
        }
        public Ejemplar obtenerEjemplarPorDni(string dni)
        { 
            Ejemplar ejemplarEncontrado = null; List<Ejemplar> ejemplares = new List<Ejemplar>();
            var socioE = obtenerSocio(dni);
            int cant = 0;
            foreach (Ejemplar e in listaEjemplares)
            {
                if (e.NDni == socioE.Dni)
                {
                    cant++;
                    ejemplares.Add(e);
                }
            }
            if (cant > 1)
            {
                Console.WriteLine($"Hay {cant} ejemplares prestados a este socio. Por favor, ingrese el número de ejemplar que desea devolver (1-{cant}):");
                int numeroEjemplar = int.Parse(Console.ReadLine());
                if (numeroEjemplar < 1 || numeroEjemplar > cant)
                {
                    Console.WriteLine("Número de ejemplar inválido.");
                    return null;
                }
                ejemplarEncontrado = ejemplares[numeroEjemplar - 1];
            }
            else if (cant == 1)
            { ejemplarEncontrado = ejemplares[0]; }
            else if (cant == 0)
            {
                Console.WriteLine("No hay ejemplares prestados a este socio.");
            }
            else if (ejemplarEncontrado != null)
            {
                Console.WriteLine($"Ejemplar encontrado: {ejemplarEncontrado.Titulo}");
            }
            else
            {
                Console.WriteLine("No se encontró ningún ejemplar con ese DNI.");
            }
            return ejemplarEncontrado;
        }
        public void ListadoSocios()
        {
            if (listaSocios != null)
            {
                Console.WriteLine("Estos son los socios: ");
                for (int i = 0; i < listaSocios.Count; i++)
                {
                    Socio s = (Socio)listaSocios[i];
                    Console.WriteLine(s.NombreApellido);
                }
            }
            else
            {
                Console.WriteLine("No hay socios");
            }
        }
        public void ListadoLibros()
        {
            if(listaEjemplares != null)
            {
                Console.WriteLine("Estos son los ejemplares: ");
                for(int i = 0; i < listaEjemplares.Count; i++)
                {
                    Ejemplar ejemplar =(Ejemplar)listaEjemplares[i];
                    Console.WriteLine(ejemplar.Titulo);
                }
            }
            else
            {
                Console.WriteLine("No hay socios");
            }
        }
      
        public void RepararLibro()
        {
            bool mal = false; Ejemplar encontrado = null;
            for(int i = 0; i < listaEjemplares.Count; i++)
            {
                Ejemplar e =(Ejemplar)listaEjemplares[i];
                if(e.Condicion == "mala" && e.Estado == "disponible")
                {
                    mal = true;
                    encontrado = e;
                    break;
                   
                }
            }
            if(mal == true)
            {
                encontrado.Condicion = "buena";
                Console.WriteLine($"Se ha reparado el libro {encontrado.Titulo} perfectamente");
            }
            else
            {
                Console.WriteLine("No se encontro ningún libro en mal estado con ese código");
            }}
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