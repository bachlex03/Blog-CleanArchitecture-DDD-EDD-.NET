namespace Blog.Api.Contracts.Auth;

public record AuthResponse(string FirstName, string LastName, string Email, string Token);