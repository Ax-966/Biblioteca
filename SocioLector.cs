using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class SocioLector:Socio
    {
        private ArrayList sala;

        public SocioLector(string nombreApellido, int dni, int telefono, string direccion, int cantLibros):base(nombreApellido, dni, telefono, direccion, cantLibros)
        {
            sala = new ArrayList();
        }
        public ArrayList Sala
        {
            get
            {
                return sala;
            }
        }
        
    }
}