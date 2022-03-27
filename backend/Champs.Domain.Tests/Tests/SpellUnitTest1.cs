using Champs.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace Champs.Domain.Tests.Tests
{
    public class SpellUnitTest1
    {
        [Fact(DisplayName = "Create Spell With Valid State")]
        public void CreateSpell_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Spell(1, "The Darkin Blade", 
                "Aatrox slams his greatsword down, dealing physical damage. He can swing three times, each with a different area of effect.",
                5);
            action.Should()
                .NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateSpell_WithNegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Spell(-1, "The Darkin Blade", 
                "Aatrox slams his greatsword down, dealing physical damage. He can swing three times, each with a different area of effect.",
                5);
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid id value!");
        }

        [Fact]
        public void CreateSpell_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Spell(1, null, 
                "Aatrox slams his greatsword down, dealing physical damage. He can swing three times, each with a different area of effect.",
                5);
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid name. Name is required!");
        }

        [Fact]
        public void CreateSpell_WithEmptyNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Spell(1, "    ", 
                "Aatrox slams his greatsword down, dealing physical damage. He can swing three times, each with a different area of effect.",
                5);
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid name. Name is required!");
        }

        [Fact]
        public void CreateSpell_WithShortNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Spell(1, "Th", 
                "Aatrox slams his greatsword down, dealing physical damage. He can swing three times, each with a different area of effect.",
                5);
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid name. Minimum 3 characters!");
        }

        [Fact]
        public void CreateSpell_WithBigNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Spell(1, "The Darkin BladeThe Darkin BladeThe Darkin BladeThe Darkin Blade", 
                "Aatrox slams his greatsword down, dealing physical damage. He can swing three times, each with a different area of effect.",
                5);
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid name. Maximum 60 characters!");
        }

        [Fact]
        public void CreateSpell_WithNullDescriptionValue_DomainExceptionInvalidDescription()
        {
            Action action = () => new Spell(1, "The Darkin Blade", 
                null,
                5);
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid description. Description is required!");
        }

        [Fact]
        public void CreateSpell_WithEmptyDescriptionValue_DomainExceptionInvalidDescription()
        {
            Action action = () => new Spell(1, "The Darkin Blade", 
                "    ",
                5);
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid description. Description is required!");
        }

        [Fact]
        public void CreateSpell_WithShortDescriptionValue_DomainExceptionInvalidDescription()
        {
            Action action = () => new Spell(1, "The Darkin Blade", 
                "Aatrox sl",
                5);
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid description. Minimum 10 characters!");
        }

        [Fact]
        public void CreateSpell_WithBigDescriptionValue_DomainExceptionInvalidDescription()
        {
            Action action = () => new Spell(1, "The Darkin Blade", 
                "Aatrox slams his greatsword down, dealing physical damage. He can swing three times, each with a different area of effect.Aatrox slams his greatsword down, dealing physical damage. He can swing three times, each with a different area of effect.Aatrox slams his greatsword down, dealing physical damage. He can swing three times, each with a different area of effect.",
                5);
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid description. Maximum 255 characters!");
        }

        [Fact]
        public void CreateSpell_WithLessThanOneMaxRankValue_DomainExceptionInvalidMaxRank()
        {
            Action action = () => new Spell(1, "The Darkin Blade", 
                "Aatrox slams his greatsword down, dealing physical damage. He can swing three times, each with a different area of effect.",
                0);
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid max rank!");
        }

        [Fact]
        public void CreateSpell_WithMoreThanSixMaxRankValue_DomainExceptionInvalidMaxRank()
        {
            Action action = () => new Spell(1, "The Darkin Blade", 
                "Aatrox slams his greatsword down, dealing physical damage. He can swing three times, each with a different area of effect.",
                7);
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid max rank!");
        }
    }
}