using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Api.Contracts.Auth;
using Blog.Application.Auth;
using Blog.Application.services.RabbitMq;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;
        private readonly IRabbitMqUtil _rabbitUtil;

        public AuthController(IAuthService authService, IRabbitMqUtil rabbitUtil)
        {
            this._authService = authService;
            this._rabbitUtil = rabbitUtil;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            var authResult = _authService.Register(request.FirstName, request.LastName, request.Email, request.Password);

            var response = new AuthResponse(authResult.FirstName, authResult.LastName, authResult.Email, authResult.Token);

            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            await _rabbitUtil.PublishRabbitMessageQueue("api.auth", "Login");

            return Ok(123);
        }

    }
}