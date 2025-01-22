using InventoryManagementSystem.Core.Interface;
using InventoryManagementSystem.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.Service
{
    public class InventoryManager : IInventoryManager
    {
        private readonly List<Product> _products = new List<Product>();

        // Adds a new product to the inventory
        public void AddProduct(Product product)
        {
            if (_products.Any(p => p.ProductId == product.ProductId))
                throw new InvalidOperationException("A product with the same ID already exists.");

            _products.Add(product);
        }

        // Removes a product from the inventory by its ID
        public void RemoveProduct(int productId)
        {
            var product = _products.FirstOrDefault(p => p.ProductId == productId);
            if (product == null) throw new KeyNotFoundException("Product not found.");

            _products.Remove(product);
        }

        // Updates the quantity of an existing product
        public void UpdateProduct(int productId, int newQuantity)
        {
            var product = _products.FirstOrDefault(p => p.ProductId == productId);
            if (product == null) throw new KeyNotFoundException("Product not found.");

            product.UpdateQuantity(newQuantity);
        }

        // Lists all products in the inventory
        public void ListProducts()
        {
            if (!_products.Any())
            {
                Console.WriteLine("No products in inventory.");
                return;
            }

            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("| Product ID | Name                 | Quantity In Stock | Price                 |");
            Console.WriteLine("---------------------------------------------------------------------------------");

            foreach (var product in _products)
            {
                Console.WriteLine($"| {product.ProductId,-10} | {product.Name,-20} | {product.QuantityInStock,-17} | {product.Price,-21:C} |");
            }

            Console.WriteLine("---------------------------------------------------------------------------------");
        }

        // Calculates the total value of the inventory
        public decimal GetTotalValue()
        {
            return _products.Sum(p => p.Price * p.QuantityInStock);
        }
    }
}
