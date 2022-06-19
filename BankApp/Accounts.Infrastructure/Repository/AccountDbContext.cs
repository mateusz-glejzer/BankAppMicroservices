using Accounts.Infrastructure.Dto;
using Microsoft.EntityFrameworkCore;

namespace Accounts.Infrastructure.Repository;

public class AccountDbContext : DbContext
{
    public AccountDbContext(DbContextOptions<AccountDbContext> options) : base(options)
    {
    }

    public DbSet<AccountDto> Accounts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}