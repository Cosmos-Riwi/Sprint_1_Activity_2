class Empleado
{
    public string Nombre { get; set; }
    public int Edad { get; set; }
    public string Correo { get; set; }
}

class Program
{
    static void Main()
    {
        List<Empleado> empleados = new List<Empleado>();
        string opcion;

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Bienvenido al sistema de gestion de empleados");
        Console.ResetColor();

        do
        {
            // Menú interactivo
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n======== Menu De Empleados ========");
            Console.WriteLine("1. Agregar empleado");
            Console.WriteLine("2. Mostrar empleados");
            Console.WriteLine("3. Contar menores de edad");
            Console.WriteLine("4. Encontrar al empleado mas viejo");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opcion: ");
            Console.ResetColor();

            opcion = Console.ReadLine();

            switch (opcion)
            {
                //Agregar empleado
                case "1": 
                    AgregarEmpleado(empleados);
                    break;

                //Mostrar empleados
                case "2": 
                    MostrarEmpleados(empleados);
                    break;

                //Contar menores de edad
                case "3": 
                    MenorDeEdad(empleados);
                    break;

                //Encontrar empleado viejo
                case "4": 
                    EncontrarEmpleadoViejo(empleados);
                    break;

                //Salir
                case "5":
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n👋 Gracias por usar el sistema de gestion de empleados. ¡Hasta luego!");
                    Console.ResetColor();
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("❌ Opcion invalida, intente de nuevo.");
                    Console.ResetColor();
                    break;
            }

        } while (opcion != "5");
    }

    //Agregar empleado
    static void AgregarEmpleado(List<Empleado> empleados)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Ingrese el nombre del empleado: ");
        string nombre = Console.ReadLine();

        int edad;
        while (true)
        {
            Console.Write("Ingrese la edad del empleado: ");
            if (int.TryParse(Console.ReadLine(), out edad) && edad >= 0)
                break;
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Edad invalida, por favor ingrese una edad valida.");
                Console.ResetColor();
            }
        }

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Ingrese el correo electronico del empleado: ");
        string correo = Console.ReadLine();
        Console.ResetColor();

        empleados.Add(new Empleado { Nombre = nombre, Edad = edad, Correo = correo });

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("✅ Empleado agregado con exito.");
        Console.ResetColor();
    }

    //Mostrar empleados
    static void MostrarEmpleados(List<Empleado> empleados)
    {
        if (empleados.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("❌ No hay empleados registrados.");
            Console.ResetColor();
            return;
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n📋 Detalle de empleados registrados:");
        Console.ResetColor();

        foreach (var empleado in empleados)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"- Nombre: {empleado.Nombre}, Edad: {empleado.Edad}, Correo: {empleado.Correo}");
            Console.ResetColor();
        }
    }

    //Contar menores de edad
    static void MenorDeEdad(List<Empleado> empleados)
    {
        int menoresDeEdad = 0;
        foreach (var empleado in empleados)
        {
            if (empleado.Edad < 18)
                menoresDeEdad++;
        }

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\nEl total de empleados menores de edad es: {menoresDeEdad}");
        Console.ResetColor();
    }

    //Encontrar al empleado más viejo
    static void EncontrarEmpleadoViejo(List<Empleado> empleados)
    {
        if (empleados.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("❌ No hay empleados registrados.");
            Console.ResetColor();
            return;
        }

        Empleado empleadoViejo = empleados[0];
        foreach (var empleado in empleados)
        {
            if (empleado.Edad > empleadoViejo.Edad)
            {
                empleadoViejo = empleado;
            }
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"\nEl empleado mas viejo es {empleadoViejo.Nombre}, con {empleadoViejo.Edad} años.");
        Console.ResetColor();
    }
}
