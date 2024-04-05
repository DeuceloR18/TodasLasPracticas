using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Desafio_3
{
    internal class ListaDeTareas 
        {
        private List<string> tareas;

    public ListaDeTareas()
    {
        tareas = new List<string>();
    }

    public void MostrarTareas()
    {
        Console.WriteLine("Tareas por realizar:");
        for (int i = 0; i < tareas.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {tareas[i]}");
        }
    }

    public void AgregarTarea(string tarea)
    {
        tareas.Add(tarea);
        Console.WriteLine("Tarea agregada con éxito.");
    }

    public void EliminarTarea(int indice)
    {
        if (indice > 0 && indice <= tareas.Count)
        {
            tareas.RemoveAt(indice - 1);
            Console.WriteLine("Tarea eliminada con éxito.");
        }
        else
        {
            Console.WriteLine("Índice inválido.");
        }
    }

    public static void Main()
    {
        ListaDeTareas lista = new ListaDeTareas();
        string opcion;
        do
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Mostrar Tareas");
            Console.WriteLine("2. Agregar Tarea");
            Console.WriteLine("3. Eliminar Tarea");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    lista.MostrarTareas();
                    break;
                case "2":
                    Console.Write("Ingrese la tarea a agregar: ");
                    string nuevaTarea = Console.ReadLine();
                    lista.AgregarTarea(nuevaTarea);
                    break;
                case "3":
                    Console.Write("Ingrese el número de la tarea a eliminar: ");
                    int indice = Convert.ToInt32(Console.ReadLine());
                    lista.EliminarTarea(indice);
                    break;
            }
        } while (opcion != "4");
    }
    }
}
