using System.ComponentModel.DataAnnotations;

namespace NutrientCalculator.Models
{
    public class CreateUserViewModel
    {
        [Required]
        public string UserName { get; set; } = null!;

        [EmailAddress]
        public string? Email { get; set; }
    }
}
