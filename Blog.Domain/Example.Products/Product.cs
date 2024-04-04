namespace Blog.Domain
{
    public class Product
    {
        public Product(Guid id, string name, Money price, Sku sku)
        {
            Id = id;
            Name = name;
            Price = price;
            Sku = sku;
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public Money Price { get; private set; }

        public Sku Sku { get; private set; }
    }
}
