using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Champs.Application.DTOs
{
    public class StatDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Invalid base health. Base health is required!")]
        [Column(TypeName = "decimal(5,2)")]
        [DisplayName("Base Health")]
        public decimal BaseHealthPool { get; set; }

        [Required(ErrorMessage = "Invalid health per level. Health per level is required!")]
        [Column(TypeName = "decimal(5,2)")]
        [DisplayName("Health Per Level")]
        public decimal HealthPoolPerLevel { get; set; }

        [Required(ErrorMessage = "Invalid health regen. Health regen is required!")]
        [Column(TypeName = "decimal(5,2)")]
        [DisplayName("Health Regen")]
        public decimal HealthPoolRegen { get; set; }

        [Required(ErrorMessage = "Invalid health regen per level. Health regen per level is required!")]
        [Column(TypeName = "decimal(5,2)")]
        [DisplayName("Health Regen Per Level")]
        public decimal HealthPoolRegenPerLevel { get; set; }
    }
}