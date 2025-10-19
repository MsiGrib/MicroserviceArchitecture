using DataModel.Models.Services.Users.Inputs;

namespace Business.Services.Interfaces
{
    public interface IUserService
    {
        public Task<bool> RegistrationUserAsync(UserInput input);
        public Task<bool> ExistUserAsync(Guid id);
        public Task<bool> ExistUserAsync(string email);
    }
}