namespace NutrientCalculator.Models;

public class MealEntity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public ICollection<MealProductEntity> MealProducts { get; set; } = [];
    public Guid UserId { get; set; }
    public UserEntity? User { get; set; }
    public ICollection<RationMealEntity>? RationMeals { get; set; }
}
