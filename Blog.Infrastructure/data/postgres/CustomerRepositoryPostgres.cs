using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Domain;
using Blog.Domain.Example.Customers;

namespace Blog.Infrastructure.data.postgres
{

    public class CustomerRepositoryPostgres : ICustomerRepositoryPostgres
    {
        private readonly AppDbContext _dbContext;

        public CustomerRepositoryPostgres(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(Customer customer)
        {
            _dbContext.Add(customer);

            await _dbContext.SaveChangesAsync();

            await Task.CompletedTask;
        }
    }
}