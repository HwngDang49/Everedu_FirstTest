using System;
using System.Collections.Generic;
using System.Linq;

namespace FruitShopSystem
{
    class Program
    {
        static List<Fruit> fruits = new List<Fruit>();
        static List<Order> orders = new List<Order>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("FRUIT SHOP SYSTEM\n");
                Console.WriteLine("1. Create Fruit");
                Console.WriteLine("2. View Orders");
                Console.WriteLine("3. Shopping (for buyer)");
                Console.WriteLine("4. Exit\n");
                Console.Write("Please choose an option: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        CreateFruit();
                        break;
                    case "2":
                        ViewOrders();
                        break;
                    case "3":
                        Shopping();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Press any key to try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void CreateFruit()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("CREATE FRUIT\n");
                Console.Write("Enter Fruit Id: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Enter Fruit Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Price: ");
                double price = double.Parse(Console.ReadLine());

                Console.Write("Enter Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                Console.Write("Enter Origin: ");
                string origin = Console.ReadLine();

                fruits.Add(new Fruit { Id = id, Name = name, Price = price, Quantity = quantity, Origin = origin });
                Console.WriteLine("Fruit created successfully!\n");

                Console.Write("Do you want to create another fruit? (Y/N): ");
                string choice = Console.ReadLine();
                if (choice.ToUpper() != "Y")
                {
                    Console.WriteLine("All Fruits:\n");
                    Console.WriteLine("Id    Name            Origin     Price");
                    fruits.ForEach(f => Console.WriteLine(f));
                    Console.WriteLine("\nPress any key to return to main menu.");
                    Console.ReadKey();
                    break;
                }
            }
        }

        static void ViewOrders()
        {
            Console.Clear();
            Console.WriteLine("VIEW ORDERS\n");
            if (!orders.Any())
            {
                Console.WriteLine("No orders found.\n");
            }
            else
            {
                foreach (var order in orders)
                {
                    Console.WriteLine(order);
                }
            }
            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
        }

        static void Shopping()
        {
            Console.Clear();
            Console.WriteLine("SHOPPING\n");
            if (!fruits.Any())
            {
                Console.WriteLine("No fruits available for shopping.\nPress any key to return to main menu.");
                Console.ReadKey();
                return;
            }

            List<OrderItem> cart = new List<OrderItem>();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("List of Fruits:\n");
                Console.WriteLine("Id    Name            Origin     Price");
                fruits.ForEach(f => Console.WriteLine(f));

                Console.Write("Enter Fruit Id to select (or 0 to finish): ");
                int id = int.Parse(Console.ReadLine());

                if (id == 0)
                {
                    if (cart.Any())
                    {
                        Console.Clear();
                        Console.WriteLine("Your Cart:\n");
                        Console.WriteLine("Product     Quantity    Price   Amount\n");
                        cart.ForEach(item => Console.WriteLine(item));
                        Console.WriteLine($"Total: {cart.Sum(item => item.Amount):C}\n");

                        Console.Write("Input your name to place order: ");
                        string customerName = Console.ReadLine();

                        orders.Add(new Order { CustomerName = customerName, Items = cart });
                        Console.WriteLine("Order placed successfully!\nPress any key to return to main menu.");
                        Console.ReadKey();
                    }
                    return;
                }

                var fruit = fruits.FirstOrDefault(f => f.Id == id);
                if (fruit == null)
                {
                    Console.WriteLine("Invalid Fruit Id. Press any key to try again.");
                    Console.ReadKey();
                    continue;
                }

                Console.WriteLine($"You selected: {fruit.Name}");
                Console.Write("Please input quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                if (quantity > fruit.Quantity)
                {
                    Console.WriteLine("sold out. Press any key to try again.");
                    Console.ReadKey();
                    continue;
                }

                fruit.Quantity -= quantity;
                cart.Add(new OrderItem { Product = fruit, Quantity = quantity });

                Console.Write("Do you want to order now? (Y/N): ");
                string choice = Console.ReadLine();
                if (choice.ToUpper() == "Y")
                {
                    Console.Clear();
                    Console.WriteLine("Your Cart:\n");
                    Console.WriteLine("Product     Quantity    Price   Amount\n");
                    cart.ForEach(item => Console.WriteLine(item));
                    Console.WriteLine($"Total: {cart.Sum(item => item.Amount):C}\n");

                    Console.Write("Input your name to place order: ");
                    string customerName = Console.ReadLine();

                    orders.Add(new Order { CustomerName = customerName, Items = cart });
                    Console.WriteLine("Order placed successfully!\nPress any key to return to main menu.");
                    Console.ReadKey();
                    return;
                }
            }
        }
    }
}
