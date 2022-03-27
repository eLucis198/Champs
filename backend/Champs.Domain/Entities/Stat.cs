using System.Collections.Generic;
using Champs.Domain.Validation;

namespace Champs.Domain.Entities
{
    public sealed class Stat : Entity
    {
        public int AttackRange { get; private set; }
        public decimal BaseHealthPool { get; private set; }
        public decimal HealthPoolPerLevel { get; private set; }
        public decimal HealthPoolRegen { get; private set; }
        public decimal HealthPoolRegenPerLevel { get; private set; }
        public int ChampionId { get; private set; }

        public Champion Champion { get; set; }

        public Stat(int attackRange, decimal baseHealthPool, decimal healthPoolPerLevel,
            decimal healthPoolRegen, decimal healthPoolRegenPerLevel)
        {
            ValidateDomain(attackRange, baseHealthPool, healthPoolPerLevel, healthPoolRegen, healthPoolRegenPerLevel);
        }

        public Stat(int id, int attackRange, decimal baseHealthPool, decimal healthPoolPerLevel,
            decimal healthPoolRegen, decimal healthPoolRegenPerLevel)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id value!");
            Id = id;

            ValidateDomain(attackRange, baseHealthPool, healthPoolPerLevel, healthPoolRegen, healthPoolRegenPerLevel);
        }

        public void Update(int attackRange, decimal baseHealthPool, decimal healthPoolPerLevel,
            decimal healthPoolRegen, decimal healthPoolRegenPerLevel, int championId)
        {
            ValidateDomain(attackRange, baseHealthPool, healthPoolPerLevel, healthPoolRegen, healthPoolRegenPerLevel);
            ChampionId = championId;
        }

        private void ValidateDomain(int attackRange, decimal baseHealthPool, decimal healthPoolPerLevel,
            decimal healthPoolRegen, decimal healthPoolRegenPerLevel)
        {
            DomainExceptionValidation.When(
                attackRange <= 0,
                "Invalid attack range!");

            DomainExceptionValidation.When(
                baseHealthPool <= 0,
                "Invalid base health pool!");

            DomainExceptionValidation.When(
                healthPoolPerLevel <= 0,
                "Invalid health pool per level!");

            DomainExceptionValidation.When(
                healthPoolRegen <= 0,
                "Invalid health pool regen!");

            DomainExceptionValidation.When(
                healthPoolRegenPerLevel <= 0,
                "Invalid health pool regen per level!");

            AttackRange = attackRange;
            BaseHealthPool = baseHealthPool;
            HealthPoolPerLevel = healthPoolPerLevel;
            HealthPoolRegen = healthPoolRegen;
            HealthPoolRegenPerLevel = healthPoolRegenPerLevel;
        }
    }
}