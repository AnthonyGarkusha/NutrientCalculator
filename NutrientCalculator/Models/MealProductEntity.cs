namespace NutrientCalculator.Models;

public class MealProductEntity
{
    public Guid MealId { get; set; }
    public MealEntity Meal { get; set; } = null!;
    public Guid ProductId { get; set; }
    public ProductEntity Product { get; set; } = null!;
    public decimal Amount { get; set; }
}
