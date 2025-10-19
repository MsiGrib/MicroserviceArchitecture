using DataModel.Models.DataBase;
using EntityGateWay.Configurations;
using Microsoft.EntityFrameworkCore;

namespace EntityGateWay
{
    public class IdentityDBContext : DbContext
    {
        #region DbSets

        public DbSet<User> Users { get; set; }

        #endregion

        public IdentityDBContext(DbContextOptions<IdentityDBContext> options) : base(options) { }

        #region Configurations DBContext

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}