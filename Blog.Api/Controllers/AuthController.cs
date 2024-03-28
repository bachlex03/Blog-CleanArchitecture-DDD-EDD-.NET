using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Api.Contracts.Auth;
using Blog.Application.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController(IAuthService _authService) : ControllerBase
    {
        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            var authResult = _authService.Register(request.FirstName, request.LastName, request.Email, request.Password);

            var response = new AuthResponse(authResult.FirstName, authResult.LastName, authResult.Email, authResult.Token);

            return Ok(response);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            return Ok(request);
        }

    }
}