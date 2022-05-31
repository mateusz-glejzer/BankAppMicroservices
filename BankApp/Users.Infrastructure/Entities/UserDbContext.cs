using Microsoft.EntityFrameworkCore;

namespace Users.Infrastructure.Entities;

public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {
    }

    public DbSet<UserEntity> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>()
            .Property(user => user.Name).IsRequired();
    }
}