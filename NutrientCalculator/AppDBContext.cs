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
    public DbSet<MealEntity> Meals { get; set; }
    public DbSet<MealProductEntity> MealProducts { get; set; }
    public DbSet<RationEntity> Rations { get; set; }
    public DbSet<RationProductEntity> RationProducts { get; set; }
    public DbSet<RationMealEntity> RationMeals { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new NutrientConfiguration());
        modelBuilder.ApplyConfiguration(new ProductNutrientConfiguration());

        modelBuilder.ApplyConfiguration(new MealConfiguration());
        modelBuilder.ApplyConfiguration(new MealProductConfiguration());

        modelBuilder.ApplyConfiguration(new RationConfiguration());
        modelBuilder.ApplyConfiguration(new RationProductConfiguration());
        modelBuilder.ApplyConfiguration(new RationMealConfiguration());

        modelBuilder.ApplyConfiguration(new UserConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}