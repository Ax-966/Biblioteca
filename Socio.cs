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
        private string nombreApellido;
        private int dni;
        private int telefono;
        private string direccion;
        private int cantLibros;
        private ArrayList historial;

        // Constructor --> Este método es importante, ya que, crea la instancia del objeto, con sus valores
        //                 es la famosa llamada al new - nombre de la clase- ();
         public Socio(string nombreApellido, int dni, int telefono, string direccion, int cantLibros)
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
        // Lógica común para devolver un libro
            registro.Estado = "disponible";
            registro.FechaPrestamo = DateTime.MinValue;
            registro.FechaDevolucion = DateTime.MinValue;
            CantLibros--;
            Console.WriteLine($"El libro {registro.Titulo} ha sido devuelto por {NombreApellido}.");
         }
        
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
        public int Dni
        {
            get{
                return dni;
            }
            set{
                dni = value;
            }
        }
         public int Telefono
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