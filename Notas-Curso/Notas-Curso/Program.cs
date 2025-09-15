//Actividad Listas

class NotasCurso
{
    static void Main()
    {
        List<double> notas = new List<double>();
        Console.WriteLine("Ingrese las notas (del 1 al 5). Escriba 'fin' para terminar: ");

        while (true)
        {
            string input = Console.ReadLine();

            if (input.ToLower() == "fin")
                break;

            if (double.TryParse(input, out double nota) && nota >= 1 && nota <= 5)
            {
                notas.Add(nota);
            }
            else
            {
                Console.WriteLine("Por favor ingrese una nota valida de 1 al 5.");
            }
        }

        double sumaNotas = 0;
        bool EstudianteRiesgoAcademico = false;

        Console.WriteLine("\nNotas ingresadas: ");
        foreach (var nota in notas)
        {
            sumaNotas += nota;
            string estado = nota >= 3 ? "Aprobado" : "Reprobado";
            Console.WriteLine($"Nota: {nota} - {estado}");

            if (nota < 2)
            {
                EstudianteRiesgoAcademico = true;
            }
        }

        double promedio = notas.Count > 0 ? sumaNotas / notas.Count : 0;

        Console.WriteLine($"\nEl promedio es: {promedio:F2}");

        if (EstudianteRiesgoAcademico)
        {
            Console.WriteLine("⚠ Hay estudiantes en riesgo academico. ⚠");
        }
    }
}