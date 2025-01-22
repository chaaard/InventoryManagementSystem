using InventoryManagementSystem.Application.Service;
using InventoryManagementSystem.Core.Interface;
using InventoryManagementSystem.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManagement
{
    class Program
    {
        static void Main()
        {
            IInventoryManager inventoryManager = new InventoryManager();
            while (true)
            {
                Console.WriteLine("\nInventory Management System");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Remove Product");
                Console.WriteLine("3. Update Product Quantity");
                Console.WriteLine("4. List Products");
                Console.WriteLine("5. Get Total Inventory Value");
                Console.WriteLine("6. Exit");
                Console.Write("Select an option: ");

                var input = Console.ReadLine();
                if (!int.TryParse(input, out var choice) || choice < 1 || choice > 6)
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
                }

                try
                {
                    switch (choice)
                    {
                        case 1:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Adding a new product...");
                            Console.ResetColor();

                            Console.Write("Enter Product ID: ");
                            if (!int.TryParse(Console.ReadLine(), out int productId) || productId <= 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid Product ID. It must be a positive integer.");
                                Console.ResetColor();
                                break;
                            }

                            Console.Write("Enter Product Name: ");
                            string? name = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(name))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Product Name cannot be empty.");
                                Console.ResetColor();
                                break;
                            }

                            Console.Write("Enter Quantity: ");
                            if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity < 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid Quantity. It must be a non-negative integer.");
                                Console.ResetColor();
                                break;
                            }

                            Console.Write("Enter Price: ");
                            if (!decimal.TryParse(Console.ReadLine(), out decimal price) || price < 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid Price. It must be a non-negative decimal.");
                                Console.ResetColor();
                                break;
                            }

                            var product = new Product(productId, name, quantity, price);
                            inventoryManager.AddProduct(product);

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Product added successfully.");
                            Console.ResetColor();
                            break;

                        case 2:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Removing a product...");
                            Console.ResetColor();

                            Console.Write("Enter Product ID to Remove: ");
                            int removeId = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                            inventoryManager.RemoveProduct(removeId);

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Product removed successfully.");
                            Console.ResetColor();
                            break;

                        case 3:
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Updating product quantity...");
                            Console.ResetColor();

                            Console.Write("Enter Product ID to Update: ");
                            int updateId = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                            Console.Write("Enter New Quantity: ");
                            int newQuantity = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                            inventoryManager.UpdateProduct(updateId, newQuantity);

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Product updated successfully.");
                            Console.ResetColor();
                            break;

                        case 4:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Listing all products...");
                            Console.ResetColor();

                            inventoryManager.ListProducts();
                            break;

                        case 5:
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("Calculating total inventory value...");
                            Console.ResetColor();

                            decimal totalValue = inventoryManager.GetTotalValue();
                            Console.WriteLine($"Total Inventory Value: {totalValue:C}");
                            break;

                        case 6:
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine("Exiting the application.");
                            Console.ResetColor();
                            return;
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.ResetColor();
                }
            }
        }
    }
}
