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


        public SocioLector(string nombreApellido, int dni, int telefono, string direccion, int cantLibros, int sala):base(nombreApellido, dni, telefono, direccion, cantLibros)
        {
            this.sala = 0;
      
        }
      public override void DevolverLibro(Ejemplar registro)
      {
       
          Console.WriteLine($"Sala actual: {sala}");
          DateTime fechaHoy = DateTime.Today;

          if (sala != 0) // Si el lector está en una sala
          {
            cantLibros--;
            registro.Estado = "disponible";
            registro.FechaPrestamo = DateTime.MinValue;
            registro.FechaDevolucion = DateTime.MinValue;
            registro.NDni = 0;
            sala = 0; // El lector se retira de la sala
            Console.WriteLine($"Perfecto, el socio lector devolvió el libro y se retiró de la sala.");
        }
        else // Si no está en una sala, verificar fecha de devolución
        {
            if (fechaHoy > registro.FechaDevolucion) // Dentro del período permitido
            {
            cantLibros--;
            registro.Estado = "disponible";
            registro.FechaPrestamo = DateTime.MinValue;
            registro.FechaDevolucion = DateTime.MinValue;
            registro.NDni = 0;
            Console.WriteLine($"Perfecto, el libro: {registro.Titulo} fue devuelto correctamente.");
            }
            else // Fuera del período permitido
            {
            Console.WriteLine($"El libro no puede ser devuelto porque está fuera del período permitido. Fecha de devolución esperada: {registro.FechaDevolucion}");
            }
    }

    // Mensaje de estado actual del socio lector
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