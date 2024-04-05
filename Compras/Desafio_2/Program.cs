using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] producto = new int[5, 5];
            producto[0, 0] = 1;
            int[] totalCompras = new int[5];

            decimal[,] comprasClientes = {
             //Cliente1
            {25, 50, 100, 99, 45},  
            // Cliente 2
            {100, 30, 49, 100, 99},
            // Cliente 3
            {50, 50, 0, 76, 20}, 
            // Cliente 4
            {99, 50, 32, 78, 50},
            // Cliente 5
            {67, 90, 67, 99, 45} 
        };

            CalcularDescuentos(comprasClientes);
        }

        public static void CalcularDescuentos(decimal[,] compras)
        {
            for (int i = 0; i < compras.GetLength(0); i++)
            {
                decimal totalCompras = 0;
                for (int j = 0; j < compras.GetLength(1); j++)
                {
                    totalCompras += compras[i, j];
                }

                decimal descuento = 0m;
                if (totalCompras >= 1000m)
                {
                    descuento = totalCompras * 0.20m;
                }
                else if (totalCompras >= 100)
                {
                    
                                  descuento = totalCompras * 0.10m;
                }

                decimal totalConDescuento = totalCompras - descuento;
                Console.WriteLine($"Cliente {i + 1}: Total Compras = {totalCompras:C}, Descuento = {descuento:C}, Total con Descuento = {totalConDescuento:C}");
                Console.ReadKey();  
            }
        }
}   }
