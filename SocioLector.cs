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