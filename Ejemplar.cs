using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Ejemplar:Libro
    {
        private int nEjemplar;
        
        public Ejemplar(int codigo, string titulo, string autor, string editorial,  string condicion, int nEjemplar):base(codigo, titulo, autor, editorial, condicion)
        {
            this.nEjemplar = nEjemplar;
        }
        public int NEjemplar
        {
            get{
                return nEjemplar;
            }
            set{
                nEjemplar = value;
            }
        }
        
    }
}