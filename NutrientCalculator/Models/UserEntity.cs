namespace NutrientCalculator.Models;

public class UserEntity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Email { get; set; }
    public string? PasswordHash { get; set; }
    public ICollection<MealEntity> Meals { get; set; } = [];
    public ICollection<RationEntity> Rations { get; set; } = [];
}
