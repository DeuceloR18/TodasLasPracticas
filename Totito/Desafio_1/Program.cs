using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] tablero = new char[3, 3];
            InicializarTablero(ref tablero);
            string nombre1 = "";
            string nombre2 = "";
            Console.WriteLine("WELCOME TO THE TOTITO");
            Console.WriteLine("---------------------");
            Console.WriteLine(TableroVisual(tablero));


            while (nombre1.Length < 2)
            {
                Console.WriteLine("Jugador1. llevaras la x. ingresa tu nombre:");
                nombre1 = Console.ReadLine();
                Console.WriteLine();
                if (nombre1.Length < 2)
                {
                    Console.WriteLine("Ingrese un numero mas largo");
                }
            }
            while (nombre2.Length < 2)
            {
                Console.WriteLine("Jugador2, llevaras la O, ingresa tu nombre:");
                nombre2 = Console.ReadLine();
                Console.WriteLine();
                if (nombre2.Length < 2)
                {
                    Console.WriteLine("Ingrese un numero mas largo");
                }
            }
            bool EsTurnoJugadorUno = true;
            while (!HayGanador(tablero))
            {
                Console.WriteLine("WELCOME TO THE TOTITO");
                Console.WriteLine("---------------------");
                Console.WriteLine();
                Console.WriteLine("TableroVisual(tablero)");
                Console.WriteLine();

                string nombrejugador = "";

                if (EsTurnoJugadorUno)
                {
                    nombrejugador = nombre1;
                }
                else
                {
                    nombrejugador = nombre2;
                }

                string coordenada = "";

                while (!EsCoordendaValida(coordenada) || YaEstaOcupada(tablero, coordenada))
                {
                    Console.WriteLine($"{nombrejugador}, ingrese la coordenada donde quieres jugar");
                    Console.WriteLine("O por ejemplo puedes ingresar la coordenada A1.");

                    coordenada = Console.ReadLine();

                    if (EsCoordendaValida(coordenada))
                    {
                        Console.WriteLine("la coordenada que has ingresado no es valida");
                        Console.WriteLine();
                    }
                    if (YaEstaOcupada(tablero, coordenada))
                    {
                        Console.WriteLine("la coordenada que has ingresado no es valida, ingresa otra");
                        Console.WriteLine();
                    }
                }
                char CaracterUsado = ' ';
                if (EsTurnoJugadorUno)
                {
                    CaracterUsado = 'x';
                }
                else
                {
                    CaracterUsado = '0';
                }

                PonerCoordenadas(ref tablero, coordenada, CaracterUsado);
                if (HayGanador(tablero))
                {
                    break;
                }
                EsTurnoJugadorUno = !EsTurnoJugadorUno;
            }

            if (HayGanador(tablero))
            {
                Console.WriteLine("FIN");
                if (Ganador(tablero) == 'X')
                {
                    Console.WriteLine($"{nombre1} ha ganado esta vez.");

                }
                else
                {
                    Console.WriteLine($"{nombre2} ha ganado esta vez.");
                }
            }
            
            Console.ReadKey();
            
        }

        static void InicializarTablero(ref char[,] tablero)
        {
            for (int contador1 = 0; contador1 < 3; contador1++)

            {
                for (int contador2 = 0; contador2 < 3; contador2++)
                {
                    tablero[contador1, contador2] = ' ';
                }
            }
        }

        static string TableroVisual(char[,] tablero)
        {
            string TableroVisual = "";
            TableroVisual = "    1   2   3" + Environment.NewLine;
            TableroVisual += "   ┌──┬───┬──┐" + Environment.NewLine;
            TableroVisual += $"A  |{tablero[0, 0]} | {tablero[0, 1]} |{tablero[0, 2]} |" + Environment.NewLine;
            TableroVisual += "   ├──┼──−┼──┤" + Environment.NewLine;
            TableroVisual += $"B  |{tablero[1, 0]} | {tablero[1, 1]} |{tablero[1, 2]} |" + Environment.NewLine;
            TableroVisual += "   ├──┼──−┼──┤" + Environment.NewLine;
            TableroVisual += $"C  |{tablero[2, 0]} | {tablero[2, 1]} |{tablero[2, 2]} |" + Environment.NewLine;
            TableroVisual += "   ├──┼──−┼──┤" + Environment.NewLine;
            TableroVisual += "   └──┴───┴──┘" + Environment.NewLine;

            return TableroVisual;

        }

        static char Ganador(char[,] tablero)
        {
            if (tablero[0, 0] == tablero[0, 1] && tablero[0, 1] == tablero[0, 2] && tablero[0, 0] != ' ')
            {
                return tablero[0, 0];

            }
            if (tablero[1, 0] == tablero[1, 1] && tablero[1, 1] == tablero[1, 2] && tablero[1, 0] != ' ')
            {
                return tablero[1, 0];
            }
            if (tablero[2, 0] == tablero[2, 1] && tablero[2, 1] == tablero[2, 2] && tablero[2, 0] != ' ')
            {  
                return tablero[2, 0];
            }
            if (tablero[0, 0] == tablero[1, 0] && tablero[1, 0] == tablero[2, 0] && tablero[0, 0] != ' ')
            {
                return tablero[0, 0];

            }
            if (tablero[0, 0] == tablero[1, 1] && tablero[1, 1] == tablero[2, 1] && tablero[0, 1] != ' ')
            {
                return tablero[0, 1];

            }
            if (tablero[0, 2] == tablero[1, 2] && tablero[1, 2] == tablero[2, 2] && tablero[0, 2] != ' ')
            {
                return tablero[0, 2];

            }
            if (tablero[0, 0] == tablero[1, 1] && tablero[1, 1] == tablero[2, 2] && tablero[0, 0] != ' ')
            {
                return tablero[0, 0];

            }
            if (tablero[0, 2] == tablero[1, 1] && tablero[1, 1] == tablero[2, 0] && tablero[0, 2] != ' ')
            {
                return tablero[0, 0];

            }
            return ' ';
        }

        static bool HayGanador(char[,] tablero)
        {
            return Ganador(tablero) != ' ';
        }

        static bool YaEstaOcupada(char[,] tablero, int x, int y)
        {
            if (x < 0 || x >2)
            {
                throw new ArgumentException("El valor de x debe de ser 0, 1 o 2", "x");
            }
            if(y < 0 || y > 2)
            {
                throw new ArgumentException("El valor de y debe de ser 0, 1 o 2", "y");
            }
            return tablero[x, y] != ' ';
        }
        static bool YaEstaOcupada(char[,] tablero, string coordenada)
        {
            switch (coordenada)
            {
                case "A1":
                    return YaEstaOcupada(tablero, 0, 0);
                case "A2":
                    return YaEstaOcupada(tablero, 0, 1);
                case "A3":
                    return YaEstaOcupada(tablero, 0, 2);
                case "B1":
                    return YaEstaOcupada(tablero, 1, 0);
                case "B2":
                    return YaEstaOcupada(tablero, 1, 1);
                case "B3":
                    return YaEstaOcupada(tablero, 1, 2);
                case "c1":
                    return YaEstaOcupada(tablero, 2, 0);
                case "C2":
                    return YaEstaOcupada(tablero, 2, 1);
                case "C3":
                    return YaEstaOcupada(tablero, 2, 2);

            }
            return false;
        }

        static void PonerCoordenadas(ref char[,] tablero, string coordenada, char letra)
        
        {
            coordenada = coordenada.ToUpper();

            switch(coordenada)
            {
                case "A1":
                    tablero[0, 0] = letra;
                    return;
                case "A2":
                    tablero[0, 1] = letra;
                    return;
                case "A3":
                    tablero[0, 2] = letra;
                    return;
                case "B1":
                    tablero[1, 1] = letra;
                    return;
                case "B2":
                    tablero[1, 2] = letra;
                    return;
                case "B3":
                    tablero[0, 2] = letra;
                    return;
                case "c1":
                    tablero[2, 1] = letra;
                    return;
                case "C2":
                    tablero[2, 2] = letra;
                    return;
                case "C3":
                    tablero[2, 2] = letra;
                    return;

            }
        } 
        static bool EsCoordendaValida(string coordenada)
        {
            switch (coordenada)
            {
                case "A1":
                case "A2":
                case "A3":
                case "B1":
                case "B2":
                case "B3":
                case "c1":
                case "C2":  
                case "C3":
                    return true;
                default:
                    return false; 
                   
            }
        }

    }
}
    


