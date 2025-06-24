using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class SocioLector:Socio
    {
        private int sala;
        public SocioLector(string nombreApellido, string dni, string telefono, string direccion, int cantLibros, int sala) : base(nombreApellido, dni, telefono, direccion, cantLibros)
        {
            this.sala = 0;
        }
        public override void DevolverLibro(Ejemplar registro)
        {
          Console.WriteLine($"Sala actual: {sala}");
          DateTime fechaHoy = DateTime.Today;

          if (sala != 0 && cantLibros == 1) 
          {
            cantLibros--;
            registro.Estado = "disponible";
            registro.FechaPrestamo = DateTime.MinValue;
            registro.FechaDevolucion = DateTime.MinValue;
            registro.NDni = "0";
            Historial.Remove(registro);
            sala = 0; 
            Console.WriteLine($"Perfecto, el socio lector devolvió el libro y se retiró de la sala.");
          }
          else if (sala != 0 && cantLibros > 1) 
          {
            cantLibros--;
            registro.Estado = "disponible";
            registro.FechaPrestamo = DateTime.MinValue;
            registro.FechaDevolucion = DateTime.MinValue;
            registro.NDni = "0";
            Historial.Remove(registro);
            Console.WriteLine($"Perfecto, el socio lector devolvió el libro  --> {registro.Titulo}, cuyo número de ejemplar es: {registro.NEjemplar}.");
            Console.WriteLine($"El lector sigue en la sala --> {sala}");
          }
          else 
          {
            if (fechaHoy > registro.FechaDevolucion) 
            {
                cantLibros--;
                registro.Estado = "disponible";
                registro.FechaPrestamo = DateTime.MinValue;
                registro.FechaDevolucion = DateTime.MinValue;
                registro.NDni = "0";
                Console.WriteLine($"Perfecto, el libro: {registro.Titulo} fue devuelto correctamente.");
            }
            else 
            {
                Console.WriteLine($"El libro no puede ser devuelto porque está fuera del período permitido. Fecha de devolución esperada: {registro.FechaDevolucion}");
            }
         }

         Console.WriteLine($"El lector ahora tiene {cantLibros} libros en préstamo.");
        }
        public int Sala
        {
            get
            {
                return sala;
            }
            set
            {
                sala = value;
            }
        }
     
    }
}