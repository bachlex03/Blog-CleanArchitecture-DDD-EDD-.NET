// <copyright file="AuthResult.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
public record AuthResult(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Token
);