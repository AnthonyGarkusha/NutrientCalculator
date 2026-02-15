namespace NutrientCalculator.Models;

public class RationMealEntity
{
    public Guid RationId { get; set; }
    public RationEntity Ration { get; set; } = null!;
    public Guid MealId { get; set; }
    public MealEntity Meal { get; set; } = null!;
    public decimal Amount { get; set; }
}
