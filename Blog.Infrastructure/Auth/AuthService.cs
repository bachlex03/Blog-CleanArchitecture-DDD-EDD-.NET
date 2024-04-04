using Blog.Application.Common.Interfaces.Auth;
using Blog.Domain;
using Blog.Domain.Example.Customers;
using Blog.Infrastructure.data.postgres;
using ErrorOr;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Auth
{
    public class AuthService : IAuthService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerRepositoryPostgres _customerRepositoryPostgres;
        private readonly IJwtGenerator _jwtGenerator;

        private readonly AppDbContext appDbContext;

        public AuthService(ICustomerRepository customerRepository, IJwtGenerator jwtGenerator, AppDbContext appDbContext, ICustomerRepositoryPostgres customerRepositoryPostgres)
        {
            _customerRepository = customerRepository;
            _jwtGenerator = jwtGenerator;
            this.appDbContext = appDbContext;
            _customerRepositoryPostgres = customerRepositoryPostgres;
        }

        public Task<ErrorOr<string>> Login(string Email, string Password)
        {
            throw new NotImplementedException();
        }

        public async Task<ErrorOr<string>> Register(string FirstName, string LastName, string Email, string Password)
        {
            var isExist = await _customerRepository.CheckEmail(Email);

            if (!isExist)
            {
                return Error.Conflict("Email already exists");
            }

            Customer customer = new Customer(Guid.NewGuid(), FirstName, LastName, Email, Password);

            await _customerRepository.Create(customer);
            await _customerRepositoryPostgres.Create(customer);

            return _jwtGenerator.JwtGenerator(FirstName, LastName, Email);
        }
    }
}