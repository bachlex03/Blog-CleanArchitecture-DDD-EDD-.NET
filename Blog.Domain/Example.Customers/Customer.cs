
namespace Blog.Domain
{
    public class Customer
    {
        public Customer(Guid id, string firstName, string lastName, string email, string password)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }

        public Guid Id { get; private set; }

        public string FirstName { get; private set; } = String.Empty;

        public string LastName { get; private set; } = String.Empty;

        public string Email { get; private set; } = String.Empty;

        public string Password { get; private set; } = String.Empty;
    }
}