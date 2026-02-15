namespace NutrientCalculator.Models;

public class RationProductEntity
{
    public Guid RationId { get; set; }
    public RationEntity Ration { get; set; } = null!;
    public Guid ProductId { get; set; }
    public ProductEntity Product { get; set; } = null!;
    public decimal Amount { get; set; }
}
