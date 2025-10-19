using DataModel.Models.Services.Users.Inputs;
using System.Text.RegularExpressions;

namespace IdentityMService.Validators
{
    public class AuthorizationValidator : BaseValidator
    {
        public static (bool IsValid, List<string> Errors) SignUpAsync(UserInput input)
        {
            var errors = BaseValidate(input) ?? new List<string>();
            if (!errors.Any())
                return (false, errors);

            if (string.IsNullOrWhiteSpace(input.Name))
                errors.Add("Name is required.");

            if (string.IsNullOrWhiteSpace(input.Password))
                errors.Add("Name is required.");

            if (string.IsNullOrWhiteSpace(input.Email))
                errors.Add("Email is required.");
            else if (!Regex.IsMatch(input.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                errors.Add("Email format is invalid.");

            return (!errors.Any(), errors);
        }
    }
}