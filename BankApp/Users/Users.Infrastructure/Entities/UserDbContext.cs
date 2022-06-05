using Microsoft.EntityFrameworkCore;

namespace Users.Infrastructure.Entities;

public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {
    }

    public DbSet<UserEntity> Users { get; set; }
    public DbSet<UserAccount> UserAccounts { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>().HasMany(a => a.UserAccounts).WithOne(u=>u.UserEntity);
        modelBuilder.Entity<UserAccount>().HasOne(a => a.UserEntity).WithMany(u => u.UserAccounts);
    }
}