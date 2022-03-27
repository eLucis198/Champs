using Champs.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Champs.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        public DbSet<Champion> Champions { get; set; }
        public DbSet<Stat> Stats { get; set; }
        public DbSet<Spell> Spells { get; set; }
    }
}