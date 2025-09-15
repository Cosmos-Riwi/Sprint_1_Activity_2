using System;
using System.Collections.Generic;

class Producto
{
    public string Nombre { get; set; }
    public int Cantidad { get; set; }
    public double Precio { get; set; }

    public double Subtotal => Cantidad * Precio;
}

class Program
{
    static void Main()
    {
        List<Producto> carrito = new List<Producto>();
        string opcion;

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("🛒 Bienvenido al Carrito de Compras Online 🛒");
        Console.ResetColor();

        do
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n====== MENÚ DEL CARRITO ======");
            Console.WriteLine("1. Agregar producto");
            Console.WriteLine("2. Mostrar carrito");
            Console.WriteLine("3. Editar producto");
            Console.WriteLine("4. Eliminar producto");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
            Console.ResetColor();

            opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1": // AGREGAR
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Ingrese el nombre del producto: ");
                    string nombre = Console.ReadLine();

                    Console.Write("Ingrese la cantidad: ");
                    int cantidad;
                    while (!int.TryParse(Console.ReadLine(), out cantidad) || cantidad < 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("❌ Cantidad inválida, intente de nuevo: ");
                        Console.ResetColor();
                    }

                    Console.Write("Ingrese el precio: ");
                    double precio;
                    while (!double.TryParse(Console.ReadLine(), out precio) || precio < 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("❌ Precio inválido, intente de nuevo: ");
                        Console.ResetColor();
                    }

                    carrito.Add(new Producto { Nombre = nombre, Cantidad = cantidad, Precio = precio });

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("✅ Producto agregado con éxito.");
                    Console.ResetColor();
                    break;

                case "2": // MOSTRAR
                    MostrarCarrito(carrito);
                    break;

                case "3": // EDITAR
                    if (carrito.Count == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("❌ El carrito está vacío.");
                        Console.ResetColor();
                        break;
                    }

                    MostrarCarrito(carrito);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\nIngrese el número del producto a editar: ");
                    Console.ResetColor();

                    if (int.TryParse(Console.ReadLine(), out int indiceEditar) &&
                        indiceEditar >= 1 && indiceEditar <= carrito.Count)
                    {
                        Producto prodEditar = carrito[indiceEditar - 1];

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"Editando: {prodEditar.Nombre}");
                        Console.ResetColor();

                        Console.Write("Nuevo nombre (Enter para no cambiar): ");
                        string nuevoNombre = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(nuevoNombre))
                            prodEditar.Nombre = nuevoNombre;

                        Console.Write("Nueva cantidad (Enter para no cambiar): ");
                        string nuevaCantidadInput = Console.ReadLine();
                        if (int.TryParse(nuevaCantidadInput, out int nuevaCantidad) && nuevaCantidad >= 0)
                            prodEditar.Cantidad = nuevaCantidad;

                        Console.Write("Nuevo precio (Enter para no cambiar): ");
                        string nuevoPrecioInput = Console.ReadLine();
                        if (double.TryParse(nuevoPrecioInput, out double nuevoPrecio) && nuevoPrecio >= 0)
                            prodEditar.Precio = nuevoPrecio;

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("✅ Producto editado correctamente.");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("❌ Número inválido.");
                        Console.ResetColor();
                    }
                    break;

                case "4": // ELIMINAR
                    if (carrito.Count == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("❌ El carrito está vacío.");
                        Console.ResetColor();
                        break;
                    }

                    MostrarCarrito(carrito);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\nIngrese el número del producto a eliminar: ");
                    Console.ResetColor();

                    if (int.TryParse(Console.ReadLine(), out int indiceEliminar) &&
                        indiceEliminar >= 1 && indiceEliminar <= carrito.Count)
                    {
                        string eliminado = carrito[indiceEliminar - 1].Nombre;
                        carrito.RemoveAt(indiceEliminar - 1);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"✅ Producto '{eliminado}' eliminado.");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("❌ Número inválido.");
                        Console.ResetColor();
                    }
                    break;

                case "5":
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nGracias por usar el carrito de compras. ¡Hasta luego!");
                    Console.ResetColor();
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("❌ Opción inválida, intente de nuevo.");
                    Console.ResetColor();
                    break;
            }

        } while (opcion != "5");
    }

    // MÉTODO PARA MOSTRAR EL CARRITO
    static void MostrarCarrito(List<Producto> carrito)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n📦 Detalle del carrito:");
        Console.ResetColor();

        if (carrito.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("El carrito está vacío.");
            Console.ResetColor();
            return;
        }

        double total = 0;
        for (int i = 0; i < carrito.Count; i++)
        {
            var p = carrito[i];
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{i + 1}. {p.Nombre} | Cantidad: {p.Cantidad} | Precio: ${p.Precio} | Subtotal: ${p.Subtotal}");
            Console.ResetColor();

            if (p.Cantidad == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"⚠ Advertencia: El producto '{p.Nombre}' tiene cantidad 0.");
                Console.ResetColor();
            }

            total += p.Subtotal;
        }

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\n💵 Total sin descuento: ${total}");
        Console.ResetColor();

        if (total > 200)
        {
            double descuento = total * 0.10;
            double totalConDescuento = total - descuento;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Se aplicó un 10% de descuento (${descuento}).");
            Console.WriteLine($"💲 Total a pagar con descuento: ${totalConDescuento}");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("No aplica descuento.");
            Console.ResetColor();
        }
    }
}
