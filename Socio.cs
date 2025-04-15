using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Socio
    {
        // Variables de instancia --> atributos de la instancia // carácteristicas.
        protected string nombreApellido;
        protected string dni;
        protected string telefono;
        protected string direccion;
        protected int cantLibros;
        protected ArrayList historial;

        // Constructor --> Este método es importante, ya que, crea la instancia del objeto, con sus valores
        //                 es la famosa llamada al new - nombre de la clase- ();
         public Socio(string nombreApellido, string dni, string telefono, string direccion, int cantLibros)
         {
            this.nombreApellido = nombreApellido;
            this.dni = dni;
            this.telefono = telefono;
            this.direccion = direccion;
            this.cantLibros = cantLibros;
            historial = new ArrayList();
        }
        public virtual void DevolverLibro(Ejemplar registro)
        {
            DateTime fechaHoy = DateTime.Today;
            if(fechaHoy > registro.FechaDevolucion)
            {
                cantLibros--;
                registro.Estado = "disponible";
                registro.FechaPrestamo = DateTime.MinValue;
                registro.FechaDevolucion = DateTime.MinValue;
                registro.NDni = "0";
                Console.WriteLine($"Perfecto, el libro: {registro.Titulo} quedo con dni: {registro.NDni} y fechas: {registro.FechaPrestamo} y {registro.FechaDevolucion}");
                Console.WriteLine($"El socio quedo con: {cantLibros} cantidad de libros");
            }
            else
            {
                int faltan = (registro.FechaDevolucion - fechaHoy).Days;
                Console.WriteLine($"Todavía faltan: {faltan}, para devolver el libro");
            }
        }

    // Si no se encuentra el libro

        
        // Propiedades --get --> lectura y set --valor--
        public string NombreApellido
        {
            get{
                return nombreApellido;
            }
            set{
                nombreApellido = value;
            }
        }
        public string Dni
        {
            get{
                return dni;
            }
            set{
                dni = value;
            }
        }
         public string Telefono
         {
             get{
                  return telefono;
             }
             set{
                  telefono = value;
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
        public int CantLibros
        {
            get{
                return cantLibros;
            }
            set{
                cantLibros = value;
            }
        }
        public ArrayList Historial
        {
            get{
                return historial;
            }
            set{
                historial = value;
            }
        }
    }
}