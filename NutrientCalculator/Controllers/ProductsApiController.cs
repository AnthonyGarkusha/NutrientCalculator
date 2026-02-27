using Microsoft.AspNetCore.Mvc;

namespace NutrientCalculator.Controllers;

[Route("api/products")]
[ApiController]
public class ProductsApiController(AppDBContext context): ControllerBase
{
    private readonly AppDBContext _context = context;

    [HttpGet("search")]
    public IActionResult Search(string query)
    {
        var products = _context.Products
            .Where(p => p.Name.Contains(query))
            .Select(p => new
            {
                p.Id,
                p.Name,
                p.State,
                Calories = p.ProductNutrients
                    .Where(n => n.Nutrient.Name == "Энергия")
                    .Select(n => n.Amount)
                    .FirstOrDefault()
            })
            .Take(10)
            .ToList();
        return Ok(products);
    }

    [HttpGet("mealProducts")]
    public IActionResult GetMealProducts(Guid mealId)
    {
        var mealProducts = _context.MealProducts
            .Where(mp => mp.MealId == mealId)
            .Select(mp => new
            {
                ProductName = mp.Product.Name,
                ProductState = mp.Product.State,
                Amount = mp.Amount,
                Calories = mp.Product.ProductNutrients
                    .Where(n => n.Nutrient.Name == "Энергия")
                    .Select(n => n.Amount)
                    .FirstOrDefault()
            })
            .ToList();
        return Ok(mealProducts);
    }

}

