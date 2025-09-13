# Sprint_1_Activity_2
🎵🛒 Console App – Activities Menu in C#
📌 Description

This project is a C# console application that presents a main menu with 4 activities:

1. Grade Point Average – Calculates student averages, shows approved/reproved, and academic risk.

2. Singing Course – Allows registering, listing, and searching participants.

3. Shopping Cart – Save products, display details, and calculate total cost with discount rules.

4. Problem Statement (Customers) – Manage customers, show minors, and find the oldest person.

It is an educational project to practice:

  - Object Oriented Programming (OOP)

 -  Lists and collections

 -  Loops and conditionals

 -  User input validation

 -  Menu-driven flow in console

🛠️ Requirements

 - .NET SDK 6.0+

 - C# compiler

 - IDE: Rider, Visual Studio, or VS Code

 - ▶️ How to Run

Clone the repository and navigate to the project folder:

```bash
git clone https://github.com/usuario/mi-repo.git
cd mi-repo
dotnet run
```

📖 Features
🔹 Main Menu
```bash
===== MAIN MENU =====
1. Calculate grade point average
2. Singing Course
3. Shopping Cart
4. Problem Statement
5. Exit

```
📘 1. Calculate Grade Point Average

  - Enter student notes (0–5).

  - Marks >=3 are Approved, marks <3 are Reproved.

  - Notes <2 are considered academic risk.

  - Calculates the average of all students.

Example (C# code):
```csharp
double average = notes.Average();
Console.WriteLine($"The average of these students is: {average}");
```
🎤 2. Singing Course

  - Register participants.

  - List all participants.

  - Search participant by name (case insensitive).

Example (C# code):
```csharp
var found = participants
    .Where(p => p.Contains(search, StringComparison.OrdinalIgnoreCase))
    .ToList();
```
🛒 3. Shopping Cart

  - Save products with name, price, and quantity.

  - Show details of all products.

  - If Subtotal > 200000, apply 10% discount.

Example (C# code):
```csharp
double subTotal = products.Sum(p => p.Price * p.Quantity);
if (subTotal > 200000)
{
    discount = ((subTotal / 100) * 10);
}
```
👥 4. Customers (Problem Statement)

  - Save customers with name, email, and age.

  - Show all customers.

  - Count how many are minors (<18).

  - Find the oldest customer.

Example (C# code):
```csharp
int minors = customers.Where(c => c.Age < 18).Count();
var adult = customers.OrderByDescending(c => c.Age).First();
```
👨‍💻 Author

  - David Palacios Padilla
    Educational project to practice C# console applications 🚀
