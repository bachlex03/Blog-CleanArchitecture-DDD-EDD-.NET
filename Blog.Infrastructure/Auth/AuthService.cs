using Blog.Application.Common.Interfaces.Auth;
using Blog.Domain;
using ErrorOr;

namespace Blog.Infrastructure.Auth
{
    public class AuthService : IAuthService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IJwtGenerator _jwtGenerator;

        public AuthService(ICustomerRepository customerRepository, IJwtGenerator jwtGenerator)
        {
            _customerRepository = customerRepository;
            _jwtGenerator = jwtGenerator;
        }

        public Task<ErrorOr<string>> Login(string Email, string Password)
        {
            throw new NotImplementedException();
        }

        public async Task<ErrorOr<string>> Register(string FirstName, string LastName, string Email, string Password)
        {
            Boolean isExist = await _customerRepository.CheckEmail(Email);

            if (!isExist)
            {
                return Error.Conflict("Email already exists");
            }

            var customer = new Customer(Guid.NewGuid(), FirstName, LastName, Email, Password);

            await _customerRepository.Create(customer);

            return _jwtGenerator.JwtGenerator(FirstName, LastName, Email);
        }
    }
}