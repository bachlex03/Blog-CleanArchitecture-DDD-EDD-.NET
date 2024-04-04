namespace Blog.Domain.Example.Customers
{
    public interface ICustomerRepositoryPostgres
    {
        public Task Create(Customer customer);
    }
}