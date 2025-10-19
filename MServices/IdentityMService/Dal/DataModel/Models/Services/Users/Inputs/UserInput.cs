﻿namespace DataModel.Models.Services.Users.Inputs
{
    public class UserInput
    {
        public required string Name { get; init; } = string.Empty;
        public required string Email { get; init; } = string.Empty;
        public required string Password { get; init; } = string.Empty;
    }
}