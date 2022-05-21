using Microsoft.EntityFrameworkCore;
using Users.Infrastructure.SqlServer.Entities;

namespace Users.Infrastructure.SqlServer;

public class UsersDbContext : DbContext
{
    public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
    {
    }

    public DbSet<UserEntity> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>()
            .Property(user => user.Id)
            .IsRequired();
    }
}