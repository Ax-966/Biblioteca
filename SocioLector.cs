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
            base.DevolverLibro(registro); // Llama a la lógica de la clase base
            Sala = 0; // Lógica específica para SocioLector
            Console.WriteLine($"El socio lector {NombreApellido} ha devuelto el libro y se ha retirado de la sala.");
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