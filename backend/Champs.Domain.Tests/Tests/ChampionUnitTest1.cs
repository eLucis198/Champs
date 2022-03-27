using Champs.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace Champs.Domain.Tests
{
    public class ChampionUnitTest1
    {
        [Fact(DisplayName = "Create Champhion With Valid State")]
        public void CreateChampion_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Champion(1, "Aatrox", "the Darkin Blade");
            action.Should()
                .NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateChampion_WithNegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Champion(-1, "Aatrox", "the Darkin Blade");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid id value!");
        }

        [Fact]
        public void CreateChampion_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Champion(1, null, "the Darkin Blade");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required!");
        }

        [Fact]
        public void CreateChampion_WithEmptyNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Champion(1, " ", "the Darkin Blade");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required!");
        }

        [Fact]
        public void CreateChampion_WithShortNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Champion(1, "Aa", "the Darkin Blade");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Minimum 3 characters!");
        }

        [Fact]
        public void CreateChampion_WithBigNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Champion(1, "Aatroxxxxxxxxxxxxxxxx", "the Darkin Blade");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Maximum 20 characters!");
        }

        [Fact]
        public void CreateChampion_WithNullTitleValue_DomainExceptionInvalidTitle()
        {
            Action action = () => new Champion(1, "Aatrox", null);
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid title. Title is required!");
        }

        [Fact]
        public void CreateChampion_WithEmptyTitleValue_DomainExceptionInvalidTitle()
        {
            Action action = () => new Champion(1, "Aatrox", "    ");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid title. Title is required!");
        }

        [Fact]
        public void CreateChampion_WithBigTitleValue_DomainExceptionInvalidTitle()
        {
            Action action = () => new Champion(1, "Aatrox", "the Darkin Bladethe Darkin Bladethe Darkin Bladethe Darkin Blade");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid title. Maximum 60 characters!");
        }
    }
}
