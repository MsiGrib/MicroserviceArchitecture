using DataModel.Models.DataBase;
using EntityGateWay.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EntityGateWay.Repository.Implementations
{
    internal class UserRepository : IUserRepository
    {
        private readonly IdentityDBContext _context;

        public UserRepository(IdentityDBContext context)
        {
            _context = context;
        }

        #region Get

        public async Task<List<User>?> GetAllAsync()
        {
            return await _context.Users
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        #endregion

        #region Add

        public async Task<bool> AddAsync(User entity)
        {
            await _context.Users
                .AddAsync(entity);
            int result = await _context.SaveChangesAsync();

            return result == 1;
        }

        #endregion

        #region Update

        public async Task<bool> UpdateAsync(User entity)
        {
            _context.Update(entity);
            int result = await _context.SaveChangesAsync();

            return result == 1;
        }

        #endregion

        #region Delete

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity is not null)
            {
                _context.Users
                    .Remove(entity);
                int result = await _context.SaveChangesAsync();

                return result == 1;
            }

            return false;
        }

        #endregion

        #region Other

        public async Task<bool> ExistUserAsync(Guid id)
            => await _context.Users
            .AnyAsync(x => x.Id == id);

        public async Task<bool> ExistUserAsync(string email)
            => await _context.Users
                .AnyAsync(x => x.Email == email);

        #endregion
    }
}