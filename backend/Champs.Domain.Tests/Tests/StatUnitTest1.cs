using Champs.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace Champs.Domain.Tests
{
    public class StatUnitTest1
    {
        [Fact(DisplayName = "Create Stat With Valid State")]
        public void CreateStat_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Stat(1, 125, 580, 90, 3, 1);
            action.Should()
                .NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateChampion_WithNegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Stat(-1, 125, 580, 90, 3, 1);
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid id value!");
        }

        [Fact]
        public void CreateChampion_WithEqualOrLowerThanZeroAttackRangeValue_DomainExceptionInvalidAttackRange()
        {
            Action action = () => new Stat(1, 0, 580, 90, 3, 1);
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid attack range!");
        }

        [Fact]
        public void CreateChampion_WithEqualOrLowerThanZeroBaseHealthPoolValue_DomainExceptionInvalidBaseHealthPool()
        {
            Action action = () => new Stat(1, 125, 0, 90, 3, 1);
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid base health pool!");
        }

        [Fact]
        public void CreateChampion_WithEqualOrLowerThanZeroHealthPoolPerLevelValue_DomainExceptionInvalidHealthPoolPerLevel()
        {
            Action action = () => new Stat(1, 125, 580, 0, 3, 1);
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid health pool per level!");
        }

        [Fact]
        public void CreateChampion_WithEqualOrLowerThanZeroHealthPoolRegenValue_DomainExceptionInvalidHealthPoolRegen()
        {
            Action action = () => new Stat(1, 125, 580, 90, 0, 1);
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid health pool regen!");
        }

        [Fact]
        public void CreateChampion_WithEqualOrLowerThanZeroHealthPoolRegenPerLevelValue_DomainExceptionInvalidHealthPoolRegenPerLevel()
        {
            Action action = () => new Stat(1, 125, 580, 90, 3, 0);
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid health pool regen per level!");
        }
    }
}