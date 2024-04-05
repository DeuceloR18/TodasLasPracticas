using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Cree un programa en c# que tenga la capacidad de sumar, restar, multiplicar,
// y dividir dos numeros introducidos por el usuarios,Además también debería
// calcular el resto de la división en la última linea.
namespace Calculadora_basica
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = Convert.ToInt32(Console.ReadLine());
            int y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("ingresa los numeros a trabajar");
            Console.WriteLine("{0} + {1} = {2}", x, y, x + y);
            Console.WriteLine("{0} - {1} = {2}", x,y, x + y);
            Console.WriteLine("{0} * {1} = {2}", x, y, x + y);
            Console.WriteLine("{0} / {1} = {2}", x, y, y, x + y);
            Console.WriteLine("{0} mod = {2}", x,y, x%y);
            
            Console.ReadKey();
                
        }
    }
}
