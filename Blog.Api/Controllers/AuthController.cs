using Blog.Api.Contracts.Auth;
using Blog.Application.Common.Interfaces.Auth;
using Blog.Application.services.RabbitMq;
using Blog.Domain;
using Blog.Infrastructure.data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Blog.Api.controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;
        private readonly IRabbitMqUtil _rabbitUtil;

        public AuthController(IAuthService authService, IRabbitMqUtil rabbitUtil)
        {
            _authService = authService;
            _rabbitUtil = rabbitUtil;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var authResult = await _authService.Register(request.FirstName, request.LastName, request.Email, request.Password);

            if (authResult.IsError)
            {
                return BadRequest(authResult.Errors);
            }

            var response = new AuthResponse(request.FirstName, request.LastName, request.Email, Token: authResult.Value);

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