using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Champs.Application.DTOs
{
    public class SpellDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Invalid name. Name is required!")]
        [MinLength(3)]
        [MaxLength(60)]
        [DisplayName("Name")]
        public string Name { get; private set; }

        [Required(ErrorMessage = "Invalid description. Description is required!")]
        [MinLength(10)]
        [MaxLength(255)]
        [DisplayName("Description")]
        public string Description { get; private set; }

        [Required(ErrorMessage = "Invalid max rank. Max rank is required!")]
        [Range(1, 6)]
        [DisplayName("Max Rank")]
        public int MaxRank { get; private set; }

        [DisplayName("Champions")]
        public int ChampionId { get; set; }
        public ChampionDTO Champion { get; set; }
    }
}