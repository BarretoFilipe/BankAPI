using BankAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace BankAPI.Infrastructure
{
    public class BankContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        public BankContext(DbContextOptions<BankContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BankContext).Assembly);
        }
    }
}