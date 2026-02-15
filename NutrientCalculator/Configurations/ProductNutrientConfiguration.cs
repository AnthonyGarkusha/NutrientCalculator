using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutrientCalculator.Models;

namespace NutrientCalculator.Configurations;

public class ProductNutrientConfiguration: IEntityTypeConfiguration<ProductNutrientEntity>
{
    public void Configure(EntityTypeBuilder<ProductNutrientEntity> builder)
    {
        builder.HasKey(pn => new { pn.ProductId, pn.NutrientId });
        builder.Property(pn => pn.Amount)
               .IsRequired();
        builder.HasOne(pn => pn.Product)
               .WithMany(pn => pn.ProductNutrients);
        builder.HasOne(pn => pn.Nutrient)
               .WithMany(pn => pn.ProductNutrients);
        builder.Property(pn=> pn.Amount)
               .HasPrecision(10, 4);
    }
}
