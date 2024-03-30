
namespace Blog.Domain.ExampleCustomer
{
    public class Customer
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; } = String.Empty;

        public string Email { get; private set; } = String.Empty;
    }
}