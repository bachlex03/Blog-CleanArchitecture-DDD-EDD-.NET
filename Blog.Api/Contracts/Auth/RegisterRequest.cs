namespace Blog.Api.Contracts.Auth;

public record RegisterRequest(Guid Id, string FirstName, string LastName, string Email, string Password);