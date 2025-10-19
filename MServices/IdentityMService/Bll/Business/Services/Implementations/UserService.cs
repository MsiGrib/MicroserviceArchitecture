using Business.Services.Interfaces;
using DataModel.Models.DataBase;
using DataModel.Models.Services.Users.Inputs;
using EntityGateWay.Repository.Interfaces;
using Utility.Security;

namespace Business.Services.Implementations
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> RegistrationUserAsync(UserInput input)
        {
            var passwordHashResult = PasswordHash.CreatePasswordHash(input.Password);

            var newUser = new User
            {
                Id = Guid.CreateVersion7(),
                Name = input.Name,
                Email = input.Email,
                PasswordHash = passwordHashResult.HashBase64,
                Salt = passwordHashResult.SaltBase64,
            };

            return await _repository.AddAsync(newUser);
        }

        public async Task<bool> ExistUserAsync(Guid id)
            => await _repository.ExistUserAsync(id);

        public async Task<bool> ExistUserAsync(string email)
            => await _repository.ExistUserAsync(email);
    }
}