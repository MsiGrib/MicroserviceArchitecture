using DataModel.Models.DataBase;

namespace EntityGateWay.Repository.Interfaces
{
    public interface IUserRepository : IRepository<User, Guid>
    {
        public Task<bool> ExistUserAsync(Guid id);
        public Task<bool> ExistUserAsync(string email);
    }
}