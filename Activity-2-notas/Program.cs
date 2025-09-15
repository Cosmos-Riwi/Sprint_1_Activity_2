using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> notas = new List<int>();
        int opcion;

        Console.WriteLine("Programa para ingresar notas de estudiantes.");

        do
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Ingresar nota");
            Console.WriteLine("2. Mostrar notas y resultados");
            Console.WriteLine("3. Salir");
            Console.Write("Elija una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese la nota (1 a 5): ");
                    int nota = int.Parse(Console.ReadLine());

                    if (nota >= 1 && nota <= 5)
                    {
                        notas.Add(nota);
                        Console.WriteLine("Nota agregada.");
                    }
                    else
                    {
                        Console.WriteLine("Nota inválida, debe estar entre 1 y 5.");
                    }
                    break;

                case 2:
                    if (notas.Count == 0)
                    {
                        Console.WriteLine("No hay notas para mostrar.");
                    }
                    else
                    {
                        int suma = 0;
                        bool hayAlerta = false;

                        Console.WriteLine("\nNotas ingresadas:");
                        for (int i = 0; i < notas.Count; i++)
                        {
                            int n = notas[i];
                            string estado;

                            if (n >= 3)
                            {
                                estado = "Aprobó";
                            }
                            else
                            {
                                estado = "Reprobó";
                            }

                            Console.WriteLine("Nota: " + n + " - " + estado);

                            suma += n;

                            if (n < 2)
                            {
                                hayAlerta = true;
                            }
                        }

                        double promedio = (double)suma / notas.Count;
                        Console.WriteLine("Promedio del grupo: " + promedio.ToString("F2"));

                        if (hayAlerta)
                        {
                            Console.WriteLine("¡Hay estudiantes en riesgo académico!");
                        }
                    }
                    break;

                case 3:
                    Console.WriteLine("Saliendo del programa.");
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

        } while (opcion != 3);
    }
}