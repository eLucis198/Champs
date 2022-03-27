using Champs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Champs.Infra.Data.EntitiesConfiguration
{
    public class ChampionConfiguration : IEntityTypeConfiguration<Champion>
    {
        public void Configure(EntityTypeBuilder<Champion> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(p => p.Name).HasMaxLength(20).IsRequired();
            builder.Property(p => p.Title).HasMaxLength(60).IsRequired();
        }
    }
}