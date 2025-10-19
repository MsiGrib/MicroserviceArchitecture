namespace DataModel.Models.Services.Users.DTOs
{
    public record class TokenInfo
    {
        public string Token { get; init; } = string.Empty;
    }
}