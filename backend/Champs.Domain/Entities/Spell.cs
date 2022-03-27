using Champs.Domain.Validation;

namespace Champs.Domain.Entities
{
    public sealed class Spell : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int MaxRank { get; private set; }
        public int ChampionId { get; private set; }

        public Champion Champion { get; set; }

        public Spell(string name, string description, int maxRank)
        {
            ValidateDomain(name, description, maxRank);
        }

        public Spell(int id, string name, string description, int maxRank)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id value!");
            Id = id;

            ValidateDomain(name, description, maxRank);
        }

        public void Update(string name, string description, int maxRank, int championId)
        {
            ValidateDomain(name, description, maxRank);
            ChampionId = championId;
        }

        private void ValidateDomain(string name, string description, int maxRank)
        {
            DomainExceptionValidation.When(
                string.IsNullOrWhiteSpace(name),
                "Invalid name. Name is required!");

            DomainExceptionValidation.When(
                name?.Length < 3,
                "Invalid name. Minimum 3 characters!");

            DomainExceptionValidation.When(
                name?.Length > 60,
                "Invalid name. Maximum 60 characters!");

            DomainExceptionValidation.When(
                string.IsNullOrWhiteSpace(description),
                "Invalid description. Description is required!");

            DomainExceptionValidation.When(
                description?.Length < 10,
                "Invalid description. Minimum 10 characters!");

            DomainExceptionValidation.When(
                description?.Length > 255,
                "Invalid description. Maximum 255 characters!");

            DomainExceptionValidation.When(
                maxRank < 1,
                "Invalid max rank!");

            DomainExceptionValidation.When(
                maxRank > 6,
                "Invalid max rank!");

            Name = name;
            Description = description;
            MaxRank = maxRank;
        }
    }
}