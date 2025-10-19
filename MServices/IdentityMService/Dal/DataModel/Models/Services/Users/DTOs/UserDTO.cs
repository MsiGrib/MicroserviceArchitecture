namespace DataModel.Models.Services.Users.DTOs
{
    public record class UserDTO
    {
        public Guid Id { get; init; }
        public required string Name { get; init; } = string.Empty;
        public required string Email { get; init; } = string.Empty;
    }
}