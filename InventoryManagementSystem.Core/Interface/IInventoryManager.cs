using InventoryManagementSystem.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Core.Interface
{
    public interface IInventoryManager
    {
        void AddProduct(Product product);
        void RemoveProduct(int productId);
        void UpdateProduct(int productId, int newQuantity);
        void ListProducts();
        decimal GetTotalValue();
    }
}
