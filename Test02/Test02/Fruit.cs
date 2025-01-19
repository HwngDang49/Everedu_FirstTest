namespace FruitShopSystem
{
    public class Fruit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Origin { get; set; }

        public override string ToString()
        {
            return $"{Id,-5} {Name,-15} {Origin,-10} {Price,5:C}";
        }
    }
}
