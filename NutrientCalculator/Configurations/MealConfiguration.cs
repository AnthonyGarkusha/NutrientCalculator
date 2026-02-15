using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutrientCalculator.Models;

namespace NutrientCalculator.Configurations;

public class MealConfiguration: IEntityTypeConfiguration<MealEntity>
{
    void IEntityTypeConfiguration<MealEntity>.Configure(EntityTypeBuilder<MealEntity> builder)
    {
        builder.HasKey(m => m.Id);
        builder.HasMany(m=> m.MealProducts)
               .WithOne(mp => mp.Meal)
               .OnDelete(DeleteBehavior.Cascade); 
        builder.HasMany(m => m.RationMeals)
               .WithOne(rm => rm.Meal)
               .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(m => m.User)
               .WithMany(u => u.Meals)
               .HasForeignKey(m => m.UserId);
    }
}
