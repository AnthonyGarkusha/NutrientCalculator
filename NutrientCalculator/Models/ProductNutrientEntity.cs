namespace NutrientCalculator.Models;

public class ProductNutrientEntity
{
    public Guid ProductId { get; set; }
    public ProductEntity? Product { get; set; }

    public Guid NutrientId { get; set; }
    public NutrientEntity? Nutrient { get; set; }

    // Значение количества нутриента в продукте
    public decimal Amount { get; set; }
}
