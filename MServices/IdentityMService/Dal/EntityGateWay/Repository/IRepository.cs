namespace EntityGateWay.Repository
{
    public interface IRepository<T1, T2>
        where T1 : class
        where T2 : struct
    {
        public Task<List<T1>?> GetAllAsync();
        public Task<T1?> GetByIdAsync(T2 id);
        public Task<bool> AddAsync(T1 entity);
        public Task<bool> UpdateAsync(T1 entity);
        public Task<bool> DeleteByIdAsync(T2 id);
    }
}