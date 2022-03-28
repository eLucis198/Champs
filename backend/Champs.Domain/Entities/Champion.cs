using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Champs.Domain.Validation;

namespace Champs.Domain.Entities
{
    public sealed class Champion : Entity
    {
        public string Name { get; private set; }
        public string Title { get; private set; }

        [NotMapped]
        public Stat Stat { get; set; }
        [NotMapped]
        public ICollection<Spell> Spells { get; set; }

        public Champion()
        { }

        public Champion(string name, string title)
        {
            ValidateDomain(name, title);
        }

        public Champion(int id, string name, string title)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id value!");
            Id = id;

            ValidateDomain(name, title);
        }

        public void Update(string name, string title)
        {
            ValidateDomain(name, title);
        }

        private void ValidateDomain(string name, string title)
        {
            DomainExceptionValidation.When(
                string.IsNullOrWhiteSpace(name),
                "Invalid name. Name is required!");

            DomainExceptionValidation.When(
                name?.Length < 3,
                "Invalid name. Minimum 3 characters!");

            DomainExceptionValidation.When(
                name?.Length > 20,
                "Invalid name. Maximum 20 characters!");

            DomainExceptionValidation.When(
                string.IsNullOrWhiteSpace(title),
                "Invalid title. Title is required!");

            DomainExceptionValidation.When(
                title?.Length < 10,
                "Invalid title. Minimum 10 characters!");

            DomainExceptionValidation.When(
                title?.Length > 60,
                "Invalid title. Maximum 60 characters!");

            Name = name;
            Title = title;
        }
    }
}