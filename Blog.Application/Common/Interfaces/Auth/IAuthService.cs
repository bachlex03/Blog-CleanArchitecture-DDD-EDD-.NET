using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorOr;

namespace Blog.Application.Common.Interfaces.Auth
{
    public interface IAuthService
    {
        public Task<ErrorOr<string>> Register(string FirstName, string LastName, string Email, string Password);

        public Task<ErrorOr<string>> Login(string Email, string Password);
    }
}