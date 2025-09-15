using System;
using System.Collections.Generic;

class Producto
{
    public string Nombre;
    public int Cantidad;
    public double Precio;
}

class Program
{
    static void Main()
    {
        List<Producto> carrito = new List<Producto>();
        int opcion;

        do
        {
            Console.WriteLine("\nMenú Carrito de Compras:");
            Console.WriteLine("1. Agregar producto");
            Console.WriteLine("2. Mostrar carrito");
            Console.WriteLine("3. Salir");
            Console.Write("Elige una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Producto prod = new Producto();

                    Console.Write("Nombre del producto: ");
                    prod.Nombre = Console.ReadLine();

                    Console.Write("Cantidad: ");
                    prod.Cantidad = int.Parse(Console.ReadLine());

                    Console.Write("Precio unitario: ");
                    prod.Precio = double.Parse(Console.ReadLine());

                    carrito.Add(prod);
                    Console.WriteLine("Producto agregado.");
                    break;

                case 2:
                    if (carrito.Count == 0)
                    {
                        Console.WriteLine("El carrito está vacío.");
                    }
                    else
                    {
                        double total = 0;
                        bool avisoCantidadCero = false;

                        Console.WriteLine("\nProductos en el carrito:");
                        foreach (Producto p in carrito)
                        {
                            Console.WriteLine($"Producto: {p.Nombre}, Cantidad: {p.Cantidad}, Precio unitario: {p.Precio}");

                            if (p.Cantidad == 0)
                                avisoCantidadCero = true;

                            total += p.Cantidad * p.Precio;
                        }

                        if (avisoCantidadCero)
                            Console.WriteLine("¡Advertencia! Hay productos con cantidad cero.");

                        if (total > 200)
                        {
                            total = total * 0.9; // 10% de descuento
                            Console.WriteLine("Se aplicó un descuento del 10%.");
                        }

                        Console.WriteLine($"Total a pagar: {total:F2}");
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