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
        protected int nDni;
        protected DateTime fechaPrestamo;
        protected DateTime fechaDevolucion;
        protected string condicion;

        public Libro(int codigo, string titulo, string autor, string editorial, string estado, string condicion)
        {
            this.codigo = codigo;
            this.titulo = titulo;
            this.autor = autor;
            this.editorial = editorial;
            this.estado = estado;
            this.nDni = 0;
            this.fechaPrestamo = DateTime.MinValue;
            this.fechaDevolucion = DateTime.MinValue;
        }
        public int Codigo
        {
            get
            {
                return codigo;
            }
            set
            {
                codigo = value;
            }
        }
        public string Titulo
        {
            get
            {
                return titulo;
            }
            set
            {
                titulo = value;
            }
        }
        public string Autor
        {
            get
            {
                return autor;
            }
            set
            {
                autor = value;
            }
        }
        public string Editorial
        {
            get
            {
                return editorial;
            }
            set
            {
                editorial = value;
            }
        }
        public string Estado
        {
            get
            {
                return estado;
            }
            set
            {
                estado = value;
            }
        }
        public int NDni
        {
            get
            {
                return nDni;
            }
            set
            {
                nDni = value;
            }
        }
        public DateTime FechaPrestamo
        {
            get
            {
                return fechaPrestamo;
            }
            set
            {
                fechaPrestamo = value;
            }
        }
        public DateTime FechaDevolucion
        {
            get
            {
                return fechaDevolucion;
            }
            set
            {
                fechaDevolucion = value;
            }
        }
        public string Condicion
        {
            get
            {
                return condicion;
            }
            set
            {
                condicion = value;
            }
        }


       
    }
}