using System.Collections.Generic;
using System.Linq;

namespace FruitShopSystem
{
    public class Order
    {
        public string CustomerName { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public double Total => Items.Sum(item => item.Amount);

        public override string ToString()
        {
            string result = $"Customer: {CustomerName}\n";
            result += "Product     Quantity    Price   Amount\n";
            result += string.Join("\n", Items);
            result += $"\nTotal: {Total:C}\n";
            return result;
        }
    }
}
