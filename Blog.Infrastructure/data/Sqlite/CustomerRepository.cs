

using Blog.Domain;

namespace Blog.Infrastructure.data.Sqlite
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDbContext _dbContext;

        public CustomerRepository(CustomerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<bool> CheckEmail(string email)
        {
            return Task.FromResult(true);
        }

        public async Task Create(Customer customer)
        {
            _dbContext.Add(customer);

            await _dbContext.SaveChangesAsync();

            await Task.CompletedTask;
        }
    }
}