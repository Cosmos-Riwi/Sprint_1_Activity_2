using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> concursantes = new List<string>();
        int opcion;

        do
        {
            Console.WriteLine("\nMenú Concurso de Canto:");
            Console.WriteLine("1. Agregar participante");
            Console.WriteLine("2. Mostrar participantes");
            Console.WriteLine("3. Buscar participante");
            Console.WriteLine("4. Contar participantes que comienzan con 'A'");
            Console.WriteLine("5. Salir");
            Console.Write("Elige una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese nombre del participante: ");
                    string nombre = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(nombre))
                    {
                        concursantes.Add(nombre.Trim());
                        Console.WriteLine("Participante agregado.");
                    }
                    else
                    {
                        Console.WriteLine("Nombre inválido.");
                    }
                    break;

                case 2:
                    if (concursantes.Count == 0)
                    {
                        Console.WriteLine("No hay participantes inscritos.");
                    }
                    else
                    {
                        Console.WriteLine("Participantes inscritos:");
                        foreach (string participante in concursantes)
                        {
                            Console.WriteLine(participante);
                        }
                    }
                    break;

                case 3:
                    Console.Write("Ingrese el nombre para buscar: ");
                    string buscar = Console.ReadLine();
                    if (concursantes.Contains(buscar))
                    {
                        Console.WriteLine($"{buscar} está inscrito en el concurso.");
                    }
                    else
                    {
                        Console.WriteLine($"{buscar} NO está inscrito en el concurso.");
                    }
                    break;

                case 4:
                    int contadorA = 0;
                    foreach (string p in concursantes)
                    {
                        if (p.StartsWith("A") || p.StartsWith("a"))
                        {
                            contadorA++;
                        }
                    }
                    Console.WriteLine($"Hay {contadorA} participantes cuyos nombres comienzan con la letra 'A'.");
                    break;

                case 5:
                    Console.WriteLine("Saliendo del programa.");
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

        } while (opcion != 5);
    }
}