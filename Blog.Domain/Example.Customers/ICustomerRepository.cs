namespace Blog.Domain
{
    public interface ICustomerRepository
    {
        public Task<bool> CheckEmail(string email);

        public Task Create(Customer customer);
    }
}