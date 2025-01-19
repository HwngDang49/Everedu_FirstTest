namespace FruitShopSystem
{
    public class OrderItem
    {
        public Fruit Product { get; set; }
        public int Quantity { get; set; }

        public double Amount => Product.Price * Quantity;

        public override string ToString()
        {
            return $"{Product.Name,-10} {Quantity,8} {Product.Price,8:C} {Amount,8:C}";
        }
    }
}
