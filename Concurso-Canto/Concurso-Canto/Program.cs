class ConcursoCanto
{
    static void Main()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("¡Bienvenido al concurso de canto!");
        Console.ResetColor();
        
        //Lista para almacenar los nombres de los concursantes
        List<string> concursantes = new List<string>();
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nIngrese los nombres de los concursantes (escriba 'fin' para terminar): ");
        Console.ResetColor();

        while (true)
        {
            string input = Console.ReadLine();
            
            if (input.ToLower() == "fin")
                break;
            
            concursantes.Add(input);
        }
        
        //Mostrar los nombres inscritos
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nConcursantes inscritos: ");
        Console.ResetColor();

        foreach (var concursante in concursantes)
        {
            Console.WriteLine($"- {concursante}");
        }
        
        //Preguntar por nombre en específico
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\nIngrese un nombre para verificar si esta inscrito: ");
        Console.ResetColor();
        string buscarNombre = Console.ReadLine();

        if (concursantes.Contains(buscarNombre))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"¡El nombre {buscarNombre} esta inscrito!");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"El nombre {buscarNombre} no esta inscrito");
        }
        Console.ResetColor();
        
        //Contar cuantos nombres inician con la letra A
        int countA = 0;
        foreach (var concursante in concursantes)
        {
            if (concursante.StartsWith("A", StringComparison.OrdinalIgnoreCase))
            {
                countA++;
            }
        }
        
        //Mostrar número de concursantes cuyos nombres inician en 'A'
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write($"\nHay {countA} concursantes cuyo nombre empieza con la letra A");
        
        //Cuenta la cantidad total de concursantes
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write($"\nEl numero total de concursantes es: {concursantes.Count}");

        //Mensaje de despedida :)
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nGracias por participar en el concurso de canto ¡Hasta la proxima!");
        Console.ResetColor();

    }
}