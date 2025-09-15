using System;
using System.Collections.Generic;

class Empleado
{
    public string Nombre;
    public int Edad;
    public string Correo;
}

class Program
{
    static void Main()
    {
        List<Empleado> empleados = new List<Empleado>();
        int opcion;

        do
        {
            Console.WriteLine("\nMenú Empleados:");
            Console.WriteLine("1. Agregar empleado");
            Console.WriteLine("2. Mostrar empleados y estadísticas");
            Console.WriteLine("3. Salir");
            Console.Write("Elige una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Empleado emp = new Empleado();

                    Console.Write("Nombre: ");
                    emp.Nombre = Console.ReadLine();

                    Console.Write("Edad: ");
                    emp.Edad = int.Parse(Console.ReadLine());

                    Console.Write("Correo: ");
                    emp.Correo = Console.ReadLine();

                    empleados.Add(emp);
                    Console.WriteLine("Empleado agregado.");
                    break;

                case 2:
                    if (empleados.Count == 0)
                    {
                        Console.WriteLine("No hay empleados registrados.");
                    }
                    else
                    {
                        int menores = 0;
                        Empleado masViejo = empleados[0];

                        Console.WriteLine("\nEmpleados registrados:");
                        foreach (Empleado e in empleados)
                        {
                            Console.WriteLine($"Nombre: {e.Nombre}, Edad: {e.Edad}, Correo: {e.Correo}");

                            if (e.Edad < 18)
                                menores++;

                            if (e.Edad > masViejo.Edad)
                                masViejo = e;
                        }

                        Console.WriteLine($"\nCantidad de empleados menores de edad: {menores}");
                        Console.WriteLine($"Empleado de mayor edad: {masViejo.Nombre} ({masViejo.Edad} años)");
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
