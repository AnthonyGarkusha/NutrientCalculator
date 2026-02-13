using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutrientCalculator.Models;

namespace NutrientCalculator.Configurations;

public class ProductConfiguration: IEntityTypeConfiguration<ProductEntity>
{
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        builder.HasKey(p => p.Id);
        builder
            .HasMany(p => p.ProductNutrients)
            .WithOne(pn => pn.Product)
            .HasForeignKey(pn => pn.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
    }

}
