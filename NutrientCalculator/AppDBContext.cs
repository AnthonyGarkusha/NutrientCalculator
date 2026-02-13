using Microsoft.EntityFrameworkCore;
using NutrientCalculator.Configurations;
using NutrientCalculator.Models;

namespace NutrientCalculator;

public class AppDBContext(DbContextOptions<AppDBContext> options)
    : DbContext(options)
{
   
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<NutrientEntity> Nutrients { get; set; }
    public DbSet<ProductNutrientEntity> ProductNutrients { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new NutrientConfiguration());
        modelBuilder.ApplyConfiguration(new ProductNutrientConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}