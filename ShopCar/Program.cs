using System;
using System.Collections.Generic;

// The program simulates a shopping cart with CRUD functionalities
List<(string Name, int Quantity, double Price)> cart = new List<(string, int, double)>();

bool exit = false;

while (!exit)
{
    // Show menu
    Console.WriteLine("\n--- Carrito de Compras ---");
    Console.WriteLine("1. Agregar producto");
    Console.WriteLine("2. Mostrar productos");
    Console.WriteLine("3. Revisar cantidades");
    Console.WriteLine("4. Calcular total");
    Console.WriteLine("5. Salir");
    Console.Write("Seleccione una opción: ");
    string option = Console.ReadLine()!;

    switch (option)
    {
        case "1":
            // Add product to the list
            Console.Write("Ingrese el nombre del producto: ");
            string productName = Console.ReadLine()!;

            Console.Write("Ingrese la cantidad: ");
            int productQuantity = int.Parse(Console.ReadLine()!);

            Console.Write("Ingrese el precio: ");
            double productPrice = double.Parse(Console.ReadLine()!);

            cart.Add((productName, productQuantity, productPrice));
            Console.WriteLine("Producto agregado con éxito.");
            break;

        case "2":
            // Show all products in the list
            Console.WriteLine("\n--- Productos en el carrito ---");
            if (cart.Count == 0)
            {
                Console.WriteLine("El carrito está vacío.");
            }
            else
            {
                foreach (var item in cart)
                {
                    Console.WriteLine($"Producto: {item.Name}, Cantidad: {item.Quantity}, Precio: {item.Price}");
                }
            }
            break;

        case "3":
            // Check if any product has zero quantity
            Console.WriteLine("\n--- Revisión de cantidades ---");
            bool hasZero = false;

            foreach (var item in cart)
            {
                if (item.Quantity == 0)
                {
                    Console.WriteLine($"Advertencia: El producto {item.Name} tiene cantidad 0.");
                    hasZero = true;
                }
            }

            if (!hasZero)
            {
                Console.WriteLine("Todos los productos tienen cantidades válidas.");
            }
            break;

        case "4":
            // Calculate total cost with possible discount
            double total = 0;
            foreach (var item in cart)
            {
                total += item.Quantity * item.Price;
            }

            Console.WriteLine($"\nSubtotal: {total}");

            if (total > 200)
            {
                double discount = total * 0.10;
                total -= discount;
                Console.WriteLine($"Se aplicó un 10% de descuento. Total con descuento: {total}");
            }
            else
            {
                Console.WriteLine($"Total: {total}");
            }
            break;

        case "5":
            // Exit program
            exit = true;
            Console.WriteLine("Gracias por usar el sistema de carrito de compras.");
            break;

        default:
            Console.WriteLine("Opción no válida, intente de nuevo.");
            break;
    }
}
