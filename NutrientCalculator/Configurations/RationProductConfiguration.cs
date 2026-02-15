using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutrientCalculator.Models;

namespace NutrientCalculator.Configurations;

public class RationProductConfiguration: IEntityTypeConfiguration<RationProductEntity>
{
    void IEntityTypeConfiguration<RationProductEntity>.Configure(EntityTypeBuilder<RationProductEntity> builder)
    {
        builder.HasKey(rp => new { rp.RationId, rp.ProductId });
        builder.HasOne(rp => rp.Ration)
               .WithMany(r => r.RationProducts);
        builder.HasOne(rp => rp.Product)
               .WithMany(p => p.RationProducts);
        builder.Property(rm => rm.Amount)
               .HasPrecision(10, 4);
    }
}
