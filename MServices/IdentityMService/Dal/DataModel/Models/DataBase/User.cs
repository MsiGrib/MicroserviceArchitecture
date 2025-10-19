namespace DataModel.Models.DataBase
{
    public class User : IEntity<Guid>
    {
        public Guid Id { get; init; }
        public required string Name { get; init; } = string.Empty;
        public required string Email { get; init; } = string.Empty;
        public required string PasswordHash { get; init; } = string.Empty;
        public required string Salt { get; init; } = string.Empty;
    }
}