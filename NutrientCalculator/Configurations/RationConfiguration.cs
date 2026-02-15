using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutrientCalculator.Models;

namespace NutrientCalculator.Configurations;

public class RationConfiguration: IEntityTypeConfiguration<RationEntity>
{
    void IEntityTypeConfiguration<RationEntity>.Configure(EntityTypeBuilder<RationEntity> builder)
    {
        builder.HasKey(r => r.Id);
        builder.HasMany(r => r.RationMeals)
               .WithOne(rm => rm.Ration)
               .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(r => r.RationProducts)
               .WithOne(rp => rp.Ration)
               .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(r => r.User)
               .WithMany(u => u.Rations)
               .HasForeignKey(r => r.UserId);
    }
}
