using Champs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Champs.Infra.Data.EntitiesConfiguration
{
    public class StatConfiguration : IEntityTypeConfiguration<Stat>
    {
        public void Configure(EntityTypeBuilder<Stat> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(p => p.BaseHealthPool).HasPrecision(5, 2);
            builder.Property(p => p.HealthPoolPerLevel).HasPrecision(5, 2);
            builder.Property(p => p.HealthPoolRegen).HasPrecision(5, 2);
            builder.Property(p => p.HealthPoolRegenPerLevel).HasPrecision(5, 2);

            builder.HasOne(p => p.Champion)
                .WithOne(p => p.Stat)
                .HasForeignKey<Stat>(p => p.ChampionId);
        }
    }
}