using System;

namespace Champs.Domain.Entities
{
    public abstract class Entity
    {
        public int Id { get; protected set; }

        public DateTime CreatedAt { get; protected set; }
        public DateTime? ModifiedAt { get; protected set; }
    }
}