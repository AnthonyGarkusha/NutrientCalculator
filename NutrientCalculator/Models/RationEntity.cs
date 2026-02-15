namespace NutrientCalculator.Models;

public class RationEntity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public Guid UserId { get; set; }
    public UserEntity User { get; set; } = null!;
    public ICollection<RationMealEntity> RationMeals { get; set; } = [];
    public ICollection<RationProductEntity> RationProducts { get; set; } = [];

}
