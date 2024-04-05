using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arreglos_en_clase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //un arreglo es una estriuctura de datos
            //tiene tamaño, comienzan en la posicicon 0 y terminan en n, por el indice se
            //llega identifica a cualquier lugar (2), es homogenio que son del mismo tipo
            //definicion de un arreglo, int,long, string, person cada uno []
            Persona[] personas = new Persona[2];
            personas[0] = new Persona();
            Persona juan = new Persona();
            juan.nombre = "juan";
            personas[1] = juan;
            personas[0].nombre = "yeff";
            Console.WriteLine(personas[0].nombre);
            Console.ReadKey();
            
           
        }
    }
    class Persona
    {
        public string nombre;
    }
}

