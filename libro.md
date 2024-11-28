using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca
{
     abstract public class Libro
    {
        protected int codigo;
        protected string titulo;
        protected string autor;
        protected string editorial;
        protected string estado;
        protected Socio nDni;
        protected DateTime fechaPrestamo;
        protected DateTime fechaDevolucion;
        protected string condicion;
       
    
        public abstract int Codigo
        {
            get{
                return codigo;
            }
            set{
                codigo = value;
            }
        }
        public abstract string Titulo
        {
            get{
                return titulo;
            }
            set{
                titulo = value;
            }
        }
        public abstract string Autor
        {
            get{
                return autor;
            }
            set{
                autor = value;
            }
        }
        public abstract string Editorial
        {
            get{
                return editorial;
            }
            set{
                editorial = value;
            }
        }
        public abstract string Estado
        {
            get{
                return estado;
            }
            set{
                estado = value;
            }
        }
        public abstract  Socio NDni
        {
            get{
                return nDni;
            }
            set{
                nDni = value;
            }
        }
        public abstract DateTime FechaPrestamo
        {
            get{
                return fechaPrestamo;
           }
           set{
                fechaPrestamo = value;
           }
        }
        public abstract DateTime FechaDevolucion
        {
            get{
                return fechaDevolucion;
            }
            set{
                fechaDevolucion = value; 
            }
        }
        public abstract string Condicion
        {
            get{
                return condicion;
            }
            set{
                condicion = value;
            }
        }
    }
}