using Champs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Champs.Infra.Data.EntitiesConfiguration
{
    public class SpellConfiguration : IEntityTypeConfiguration<Spell>
    {
        public void Configure(EntityTypeBuilder<Spell> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(p => p.Name).HasMaxLength(60).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(255).IsRequired();

            builder.HasOne(p => p.Champion)
                .WithMany(p => p.Spells)
                .HasForeignKey(p => p.ChampionId);
        }
    }
}