
using Blog.Domain.ExampleCustomer;
using Blog.Domain.ExampleProduct;

namespace Blog.Domain.Example.Order
{
    public class Order
    {
        private Order() { }

        public static Order Create(Customer customer)
        {
            var order = new Order
            {
                Id = Guid.NewGuid(),
                CustomerId = customer.Id,
            };

            return order;
        }

        public Guid Id;

        public Guid CustomerId { get; private set; }

        private readonly HashSet<LineItem> LineItems = [];

        public void Add(Product product)
        {
            var lineItems = new LineItem(Guid.NewGuid(), Id, product.Id, product.Price);

            this.LineItems.Add(lineItems);
        }
    }
}

public class LineItem
{
    internal LineItem(Guid id, Guid orderId, Guid productId, Money price)
    {
        Id = id;
        OrderId = orderId;
        ProductId = productId;
        Price = price;

    }

    public Guid Id { get; private set; }

    public Guid OrderId { get; private set; }

    public Guid ProductId { get; private set; }

    public Money Price { get; private set; }

}