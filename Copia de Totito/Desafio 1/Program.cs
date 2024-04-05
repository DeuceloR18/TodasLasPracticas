using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_1 { }
 class ToTiTo
{
    static char[,] tablero = new char[3, 3];

    static void InicializarTablero()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                tablero[i, j] = ' ';
            }
        }
    }

    static void ImprimirTablero()
    {
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine(" {0} | {1} | {2} ", tablero[i, 0], tablero[i, 1], tablero[i, 2]);
            if (i < 2)
            {
                Console.WriteLine("---|---|---");
            }
        }
    }

    static bool RealizarMovimiento(int fila, int columna, char jugador)
    {
        if (tablero[fila, columna] == ' ')
        {
            tablero[fila, columna] = jugador;
            return true;
        }
        return false;
    }

    static bool HayGanador(char jugador)
    {
        for (int i = 0; i < 3; i++)
        {
            if (tablero[i, 0] == jugador && tablero[i, 1] == jugador && tablero[i, 2] == jugador ||
                tablero[0, i] == jugador && tablero[1, i] == jugador && tablero[2, i] == jugador)
            {
                return true;
            }
        }

        if (tablero[0, 0] == jugador && tablero[1, 1] == jugador && tablero[2, 2] == jugador ||
            tablero[0, 2] == jugador && tablero[1, 1] == jugador && tablero[2, 0] == jugador)
        {
            return true;
        }

        return false;
    }

    static void Main()
    {
        InicializarTablero();
        char jugadorActual = 'X';
        bool juegoTerminado = false;

        for (int turno = 0; turno < 9 && !juegoTerminado; turno++)
        {
            ImprimirTablero();
            Console.WriteLine("Turno del jugador {0}", jugadorActual);
            Console.WriteLine("Ingresa la fila y columna (0, 1, 2): ");
            int fila = Convert.ToInt32(Console.ReadLine());
            int columna = Convert.ToInt32(Console.ReadLine());

            if (RealizarMovimiento(fila, columna, jugadorActual))
            {
                if (HayGanador(jugadorActual))
                {
                    ImprimirTablero();
                    Console.WriteLine("Jugador {0} ha ganado!", jugadorActual);
                    juegoTerminado = true;
                }

                jugadorActual = jugadorActual == 'X' ? 'O' : 'X';
            }
            else
            {
                Console.WriteLine("Movimiento inválido, intenta de nuevo.");
                turno--;
            }
        }

        if (!juegoTerminado)
        {
            ImprimirTablero();
            Console.WriteLine("El juego es un empate.");
        }
    }
}