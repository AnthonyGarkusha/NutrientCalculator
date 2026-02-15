using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutrientCalculator.Models;

namespace NutrientCalculator.Configurations;

public class NutrientConfiguration: IEntityTypeConfiguration<NutrientEntity>
{
    public void Configure(EntityTypeBuilder<NutrientEntity> builder)
    {
        builder.HasKey(n => n.Id);
        builder
            .HasMany(n => n.ProductNutrients)
            .WithOne(pn => pn.Nutrient)
            .OnDelete(DeleteBehavior.Cascade);
        builder.Property(n => n.Norma)
               .HasPrecision(10, 4);
    }
}
