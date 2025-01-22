using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Core.Model
{
    public class Product
    {
        public int ProductId { get; private set; }
        public string Name { get; private set; }
        public int QuantityInStock { get; private set; }
        public decimal Price { get; private set; }

        // Constructor to initialize Product properties
        public Product(int productId, string name, int quantityInStock, decimal price)
        {
            if (productId <= 0) throw new ArgumentException("Product ID must be a positive integer.");
            if (quantityInStock < 0) throw new ArgumentException("Quantity cannot be negative.");
            if (price < 0) throw new ArgumentException("Price cannot be negative.");

            ProductId = productId;
            Name = name;
            QuantityInStock = quantityInStock;
            Price = price;
        }

        // Updates the quantity of the product
        public void UpdateQuantity(int newQuantity)
        {
            if (newQuantity < 0) throw new ArgumentException("Quantity cannot be negative.");
            QuantityInStock = newQuantity;
        }

        // Overrides ToString for a readable product representation
        public override string ToString()
        {
            return $"ID: {ProductId}, Name: {Name}, Quantity: {QuantityInStock}, Price: {Price:C}";
        }
    }
}
