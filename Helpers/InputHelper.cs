using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca
{
    public static class InputHelper
    {
         public static string PedirTextoValido(string mensaje, Func<string, bool> validador)
        {
            string input;
            do
            {
                Console.WriteLine(mensaje);
                input = Console.ReadLine();

                if (!validador(input))
                    Console.WriteLine("Entrada inválida. Intente nuevamente.");

            } while (!validador(input));

            return input;
        }
    }   
}
