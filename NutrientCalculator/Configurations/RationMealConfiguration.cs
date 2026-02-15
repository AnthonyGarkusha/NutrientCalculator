using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutrientCalculator.Models;

namespace NutrientCalculator.Configurations;

public class RationMealConfiguration: IEntityTypeConfiguration<RationMealEntity>
{
    void IEntityTypeConfiguration<RationMealEntity>.Configure(EntityTypeBuilder<RationMealEntity> builder)
    {
        builder.HasKey(rm => new { rm.RationId, rm.MealId });
        builder.HasOne(rm => rm.Ration)
               .WithMany(r => r.RationMeals)
               .OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(rm => rm.Meal)
               .WithMany(m => m.RationMeals);
        builder.Property(rm => rm.Amount)
               .HasPrecision(10, 4);
    }
}
