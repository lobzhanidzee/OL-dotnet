namespace VendingMachine
{
    internal class Product
    {
        public string Name { get; private set; }
        public ProductCategory Category { get; private set; }
        public decimal Price { get; private set; }

        public decimal Discount { get; private set; }

        public Product(string name, ProductCategory category, decimal price)
        {
            this.Name = name;
            this.Category = category;
            this.Price = price;

            if (Category == ProductCategory.Drinks)
            {
                Discount = 15;
            }
            else if (Category == ProductCategory.Snacks)
            {
                Discount = 20;
            }
        }
    }
}
