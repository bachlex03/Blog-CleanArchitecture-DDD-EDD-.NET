using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Api.Contracts.Auth;
using Blog.Application.Auth;
using Blog.Application.services.RabbitMq;
using Blog.Domain.ExampleCustomer;
using Blog.Infrastructure.data;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;
        private readonly IRabbitMqUtil _rabbitUtil;
        private readonly CustomerDbContext _customerDbContext;

        public AuthController(IAuthService authService, IRabbitMqUtil rabbitUtil, CustomerDbContext customerDbContext)
        {
            _authService = authService;
            _rabbitUtil = rabbitUtil;
            _customerDbContext = customerDbContext;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {

            var authResult = _authService.Register(request.FirstName, request.LastName, request.Email, request.Password);

            var customer = new Customer(authResult.Id, authResult.FirstName, authResult.LastName, authResult.Email, request.Password);

            _customerDbContext.Add(customer);

            _customerDbContext.SaveChangesAsync();

            var response = new AuthResponse(authResult.FirstName, authResult.LastName, authResult.Email, authResult.Token);

            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {

            await _rabbitUtil.PublishRabbitMessageQueue("api.auth", "Login");

            return Ok("Login result");
        }

    }
}