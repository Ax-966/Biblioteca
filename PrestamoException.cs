using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca
{
  public class PrestamoException : Exception
 {
    public PrestamoException(string message) : base(message) { }
    
    }
}