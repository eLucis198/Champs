using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Champs.Application.DTOs
{
    public class ChampionDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Invalid name. Name is required!")]
        [MinLength(3)]
        [MaxLength(20)]
        [DisplayName("Name")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Invalid title. Title is required!")]
        [MinLength(10)]
        [MaxLength(60)]
        [DisplayName("Title")]
        public string Title { get; set; }
    }
}