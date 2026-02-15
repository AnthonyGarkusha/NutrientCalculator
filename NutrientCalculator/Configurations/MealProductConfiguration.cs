using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutrientCalculator.Models;

namespace NutrientCalculator.Configurations;

public class MealProductConfiguration: IEntityTypeConfiguration<MealProductEntity>
{
    void IEntityTypeConfiguration<MealProductEntity>.Configure(EntityTypeBuilder<MealProductEntity> builder)
    {
        builder.HasKey(mp => new { mp.MealId, mp.ProductId });
        builder.HasOne(mp => mp.Meal)
               .WithMany(m => m.MealProducts);
        builder.HasOne(mp => mp.Product)
               .WithMany(p => p.MealProducts)
               .OnDelete(DeleteBehavior.Restrict);
        builder.Property(mp => mp.Amount)
               .HasPrecision(10, 4);
    }
}
