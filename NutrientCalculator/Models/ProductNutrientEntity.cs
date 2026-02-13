namespace NutrientCalculator.Models;

public class ProductNutrientEntity
{
    // Составной ключ: ProductId + NutrientId (укажем в конфигурации)
    public Guid ProductId { get; set; }
    public ProductEntity? Product { get; set; }

    public Guid NutrientId { get; set; }
    public NutrientEntity? Nutrient { get; set; }

    // Значение количества нутриента в продукте
    public double Amount { get; set; }
}
