using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

class Products
{
    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
}

class Customers
{
    public string Name { get; set; }
    
    public int Age { get; set; }
    
    public string Email { get; set; }
}

class Activity
{
    
    static List<string> participants = new();
    static List<int> notes = new();
    static List<Products> products = new();
    static List<Customers> customers = new();
    
    static void Main()
    {

        int option = 0;

        do
        {
            Console.Clear(); // Limpia la consola en cada iteración
            Console.WriteLine("===== MAIN MENU =====");
            Console.WriteLine("1. Calculate grade point average");
            Console.WriteLine("2. Singing Course");
            Console.WriteLine("3. Shopping Cart");
            Console.WriteLine("4. Problem Statement ");
            Console.WriteLine("5. Exit");
            Console.Write("CHOOSE AN OPTION: ");

            // Validación de opción
            if (!int.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("Invalid option, press a key to continue...");
                Console.ReadKey();
                continue; // vuelve al menú
            }

            switch (option)
            {
                case 1:
                    CalculateAverage();
                    break;

                case 2:
                    SingingCourse();
                    break;

                case 3:
                    ShoppingCart();
                    break;
                
                case 4: 
                    ProblemStatement();
                    break;

                case 5:
                    Console.WriteLine("Exiting the program...");
                    break;

                default:
                    Console.WriteLine("Invalid option, try again.");
                    break;
            }

            if (option != 5)
            {
                Console.WriteLine("Press any key to return to the menu...");
                Console.ReadKey();
            }

        } while (option != 5);
    }

    static void CalculateAverage()
    {
        int cant = 1;
        int cant2 = 0;

        Console.Write("Enter the number of notes: ");
        int n;

        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
        {
            Console.Write("Invalid input. Enter a valid positive number of notes: ");
        }

        while (cant <= n)
        {
            Console.Write($"Enter note {cant}: ");
            int note;


            if (int.TryParse(Console.ReadLine(), out note) && note >= 0 && note <= 5)
            {
                notes.Add(note);
                cant++;
            }
            else
            {
                Console.WriteLine("Invalid note. Please enter a number between 0 and 5.");
            }
        }

        foreach (var x in notes)
        {
            if (x >= 3)
            {
                Console.WriteLine($"{x}: Approved");
            }
            else
            {
                Console.WriteLine($"{x}: Reproved");
                if (x < 2)
                {
                    cant2++;
                }
            }
        }

        if (cant2 != 0)
        {
            Console.WriteLine($"There are {cant2} students who are at academic risk");
        }

        double average = notes.Average();
        Console.WriteLine($"The average of these students is: {average}");
    }

    static void SingingCourse()
    {
        int option = 0;
        do
        {
            Console.Clear();
            Console.WriteLine("===== MENU SINGING COURSE =====");
            Console.WriteLine("1. Save the names of the participants ");
            Console.WriteLine("2. View the names of the participants ");
            Console.WriteLine("3. Search participant ");
            Console.WriteLine("4. Exit");
            Console.Write("CHOOSE AN OPTION: ");

            
            if (!int.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("Invalid option, press a key to continue...");
                Console.ReadKey();
                continue; 
            }

            switch (option)
            {
                case 1:
                    SaveParticipants();
                    break;

                case 2:
                    PrintParticipants();
                    break;

                case 3:
                    SearchParticipants();
                    break;
    
                case 4:
                    Console.WriteLine("Exiting to the main menu...");
                    break;

                default:
                    Console.WriteLine("Invalid option, try again.");
                    break;
            }

            if (option != 4)
            {
                Console.WriteLine("Press any key to return to the menu...");
                Console.ReadKey();
            }

        } while (option != 4);
        
    }

    static void SaveParticipants()
    {
        Console.Write("How many participants do you want to add? ");
        int n;
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
        {
            Console.Write("Invalid number, try again: ");
        }
        

        for (int i = 1; i <= n; i++)
        {
            Console.Write($"Enter the name of participant {i}: ");
            string name = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(name))
            {
                participants.Add(name.Trim());
            }
            else
            {
                Console.WriteLine("Invalid name, not saved.");
            }
        }

        Console.WriteLine("Participants saved successfully!");
    }

    static void PrintParticipants()
    {
        Console.WriteLine("===== LIST OF PARTICIPANTS =====");
        if (participants.Count == 0)
        {
            Console.WriteLine("No participants registered.");
        }
        else
        {
            foreach (var p in participants)
            {
                Console.WriteLine("-> " + p);
            }
            Console.WriteLine($"Total of participants: {participants.Count}");
        }
    }

    static void SearchParticipants()
    {
        Console.Write("Enter the name to search: ");
        string search = Console.ReadLine();

        var found = participants
            .Where(p => p.Contains(search, StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (found.Count == 0)
        {
            Console.WriteLine("No participants found with that name.");
        }
        else
        {
            Console.WriteLine("Found participants:");
            foreach (var p in found)
            {
                Console.WriteLine("-> " + p);
            }
        }
    }
    
    static void ShoppingCart()
    {
        int option = 0;
        do
        {
            Console.Clear();
            Console.WriteLine("===== MENU SHOPPING CART =====");
            Console.WriteLine("1. Save products ");
            Console.WriteLine("2. View details ");
            Console.WriteLine("3. Total cost  ");
            Console.WriteLine("4. Exit");
            Console.Write("CHOOSE AN OPTION: ");

            
            if (!int.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("Invalid option, press a key to continue...");
                Console.ReadKey();
                continue; 
            }

            switch (option)
            {
                case 1:
                    SaveProducts();
                    break;

                case 2:
                    PrintDetails();
                    break;

                case 3:
                    TotalCosts();
                    break;
    
                case 4:
                    Console.WriteLine("Exiting to the main menu...");
                    break;

                default:
                    Console.WriteLine("Invalid option, try again.");
                    break;
            }

            if (option != 4)
            {
                Console.WriteLine("Press any key to return to the menu...");
                Console.ReadKey();
            }

        } while (option != 4);
        
    }

    static void SaveProducts()
    {
        Console.Write("How many products do you want to add? ");
        int n;
        
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
        {
            Console.Write("Invalid number, try again: ");
        }
        
        for (int i = 1; i <= n; i++)
        {
            Console.Write($"Enter the name of product {i}: ");
            string name = Console.ReadLine();
            
            Console.Write("Enter the quantity of product: ");
            int quantity;
            while (!int.TryParse(Console.ReadLine(), out quantity) || quantity < 0)
            {
                Console.Write("Invalid quantity, try again: ");
            }
            
            Console.Write($"Enter product price : ");
            double price;
            while (!double.TryParse(Console.ReadLine(), out price) || price <= 0)
            {
                Console.Write("Invalid price, try again: ");
            }
            
            products.Add(new Products { Name = name, Price = price, Quantity = quantity });
            Console.WriteLine("Products saved successfully!");
        }
    }

    static void PrintDetails()
    {
        if (products.Count == 0)
        {
            Console.WriteLine("No products saved yet");
            return;
        }
        
        Console.WriteLine("\n===== PRODUCT LIST =====");
        foreach (var p in products)
        {   
            Console.WriteLine($"Name: {p.Name} Price: {p.Price} Quantity: {p.Quantity}");
            if (p.Quantity == 0)
            {
                Console.WriteLine($"\nThe product {p.Name} has no quantity.");
            }
            
        }
    }

    static void TotalCosts()
    {
        double discount = 0;
        double subTotal = products.Sum(p => p.Price * p.Quantity);
        Console.WriteLine("SubTotal costs: " + subTotal);
        
        if (subTotal > 200000)
        {
            discount = ((subTotal / 100) * 10);
            Console.WriteLine("Total discount: " + discount);
        }
        
        double total = subTotal - discount;
        Console.WriteLine("Total costs: " + total );
        
    }

    static void ProblemStatement()
    {
        int option = 0;
        do
        {
            Console.Clear();
            Console.WriteLine("===== MENU FLOW =====");
            Console.WriteLine("1. Save customers ");
            Console.WriteLine("2. View customers ");
            Console.WriteLine("3. Exit");
            Console.Write("CHOOSE AN OPTION: ");

            
            if (!int.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("Invalid option, press a key to continue...");
                Console.ReadKey();
                continue; 
            }

            switch (option)
            {
                case 1:
                    SaveCustomers();
                    break;

                case 2:
                    PrintCustomers();
                    break;
    
                case 3:
                    Console.WriteLine("Exiting to the main menu...");
                    break;

                default:
                    Console.WriteLine("Invalid option, try again.");
                    break;
            }

            if (option != 3)
            {
                Console.WriteLine("Press any key to return to the menu...");
                Console.ReadKey();
            }

        } while (option != 3);
    }

    static void SaveCustomers()
    {
        Console.WriteLine("How many customers do you want to add? ");
        int n;

        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
        {
            Console.Write("Invalid number, try again: ");
        }

        for (int i = 1; i <= n; i++)
        {
            Console.Write($"Enter customer name {i}: : ");
            string name = Console.ReadLine();
            
            
            if (!string.IsNullOrWhiteSpace(name))
            {
                Console.Write("Enter customer email: ");
                string email = Console.ReadLine();
                
                if (!string.IsNullOrWhiteSpace(email))
                {
                    Console.Write("Enter customer age: ");
                    int age;

                    while (!int.TryParse(Console.ReadLine(), out age) || age <= 0)
                    {
                        Console.Write("Invalid number, try again: ");
                        return;
                    }
                
                    customers.Add(new Customers { Name = name.Trim(), Email = email.Trim(), Age = age });
                    Console.WriteLine("Customers saved successfully!");
                }
                else
                {
                    Console.WriteLine("Invalid Email, not saved.");
                    i--;
                }
            }
            else
            {
                Console.WriteLine("Invalid name, not saved.");
                i--;
            }
            
            
        }
        
    }

    static void PrintCustomers()
    {
     
        if (customers.Count == 0)
        {
            Console.WriteLine("No customers saved yet");
            return;
        }
        
        Console.WriteLine("\n===== CUSTOMERS =====");
        foreach (var c in customers)
        {
            Console.WriteLine($"Name: {c.Name} Email: {c.Email} Age: {c.Age}");
        }
        
        int minors = customers.Where(c => c.Age < 18).Count();
        var adult = customers.OrderByDescending(c => c.Age).First();
        
        Console.WriteLine($"There are {minors} minors");
        Console.WriteLine($"The person {adult.Name} is the old man: {adult.Age} age");
        
        
    }
}
