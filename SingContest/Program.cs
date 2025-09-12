using System;
using System.Collections.Generic;
using System.Linq;

// This list stores the contestant names
List<string> contestants = new();
string option;

do
{
    // This block shows the main menu
    Console.WriteLine(@"
Bienvenido al concurso de canto 
¿Qué acción desea ejecutar?

1. Agregar concursantes
2. Mostrar todos los concursantes
3. Verificar si un concursante está inscrito
4. Contar concursantes totales
5. Contar concursantes que empiezan con 'A'
6. Actualizar nombre de un concursante
7. Eliminar concursante
8. Salir del programa
");
    option = Console.ReadLine();

    switch (option)
    {
        case "1":
            // This block allows the user to add contestants
            Console.WriteLine("¿Cuántos concursantes deseas inscribir?");
            if (int.TryParse(Console.ReadLine(), out int amount) && amount > 0)
            {
                for (int i = 0; i < amount; i++)
                {
                    Console.WriteLine($"Ingresa el nombre del concursante {i + 1}:");
                    string name = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(name))
                    {
                        contestants.Add(name.Trim());
                        Console.WriteLine($" {name} ha sido inscrito.");
                    }
                    else
                    {
                        Console.WriteLine(" Nombre inválido.");
                        i--; // This decreases the counter to retry input
                    }
                }
            }
            else
            {
                Console.WriteLine(" Número inválido.");
            }
            break;

        case "2":
            // This block shows all contestants
            if (contestants.Count > 0)
            {
                Console.WriteLine(" Lista de concursantes inscritos:");
                contestants.ForEach(c => Console.WriteLine($"- {c}"));
            }
            else
            {
                Console.WriteLine("La lista de concursantes está vacía.");
            }
            break;

        case "3":
            // This block checks if a contestant exists
            if (contestants.Count > 0)
            {
                Console.WriteLine("Ingresa el nombre a verificar:");
                string searchName = Console.ReadLine();

                if (contestants.Any(c => c.Equals(searchName, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine($" {searchName} está inscrito en el concurso.");
                }
                else
                {
                    Console.WriteLine($" {searchName} no está inscrito en el concurso.");
                }
            }
            else
            {
                Console.WriteLine("La lista de concursantes está vacía.");
            }
            break;

        case "4":
            // This block counts all contestants
            Console.WriteLine($" El número total de concursantes es: {contestants.Count}");
            break;

        case "5":
            // This block counts contestants whose name starts with 'A'
            int countA = contestants.Count(c => c.StartsWith("A", StringComparison.OrdinalIgnoreCase));
            Console.WriteLine($" El número de concursantes que empiezan con 'A' es: {countA}");
            break;

        case "6":
            // This block updates a contestant's name
            if (contestants.Count > 0)
            {
                Console.WriteLine("Ingresa el nombre actual del concursante que deseas actualizar:");
                string oldName = Console.ReadLine();

                int index = contestants.FindIndex(c => c.Equals(oldName, StringComparison.OrdinalIgnoreCase));
                if (index != -1)
                {
                    Console.WriteLine("Ingresa el nuevo nombre:");
                    string newName = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(newName))
                    {
                        contestants[index] = newName.Trim();
                        Console.WriteLine($" El nombre {oldName} ha sido actualizado a {newName}.");
                    }
                    else
                    {
                        Console.WriteLine(" Nombre inválido.");
                    }
                }
                else
                {
                    Console.WriteLine($" {oldName} no está inscrito en el concurso.");
                }
            }
            else
            {
                Console.WriteLine("La lista de concursantes está vacía.");
            }
            break;

        case "7":
            // This block deletes a contestant
            if (contestants.Count > 0)
            {
                Console.WriteLine("Ingresa el nombre del concursante que deseas eliminar:");
                string deleteName = Console.ReadLine();

                if (contestants.RemoveAll(c => c.Equals(deleteName, StringComparison.OrdinalIgnoreCase)) > 0)
                {
                    Console.WriteLine($" {deleteName} ha sido eliminado del concurso.");
                }
                else
                {
                    Console.WriteLine($" {deleteName} no está inscrito en el concurso.");
                }
            }
            else
            {
                Console.WriteLine("La lista de concursantes está vacía.");
            }
            break;

        case "8":
            // This block exits the program
            Console.WriteLine(" Saliendo del programa...");
            break;

        default:
            // This block handles invalid options
            Console.WriteLine(" Opción no válida. Intenta de nuevo.");
            break;
    }

} while (option != "8");
