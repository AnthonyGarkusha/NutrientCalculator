using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NutrientCalculator;
using NutrientCalculator.Models;

namespace NutrientCalculator.Controllers;

public class MealController(AppDBContext context): Controller
{
    private readonly AppDBContext _context = context;

    public IActionResult Index()
    {
        var meals = _context.Meals.ToList();
        return View(meals);
    }
    public IActionResult Create(Guid Id)
    {
        ModelState.Clear();
        return View(new MealDto { UserId = Id });
    }

    public IActionResult Details(Guid Id)
    {
        MealDto meal = new (
            _context.Meals
            .Include(m => m.MealProducts)
            .ThenInclude(mp => mp.Product)
            .FirstOrDefault(m => m.Id == Id));
        if(meal == null)
            return NotFound();
        return View(meal);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(Guid Id)
    {
        var meal = _context.Meals.Find(Id);
        if(meal == null)
            return NotFound();

        _context.MealProducts.RemoveRange(meal.MealProducts);
        _context.Meals.Remove(meal);
        _context.SaveChanges();
        return RedirectToAction("Details", "User", new { id = meal.UserId });
    }

    [HttpPost]
    public async Task<IActionResult> Save(MealDto model)
    {
        MealEntity NewMeal;

        if(model.Id == null)
        {
            NewMeal = new MealEntity
            {
                Name = model.Name,
                UserId = model.UserId
            };

            foreach(var p in model.Products)
            {
                if(p.ProductId == Guid.Empty)
                    continue;
                NewMeal.MealProducts.Add(new MealProductEntity
                {
                    MealId = NewMeal.Id,
                    ProductId = p.ProductId,
                    Amount = p.Amount
                });
            }

            _context.Meals.Add(NewMeal);
        }
        else
        {
            NewMeal = await _context.Meals
                .Include(m => m.MealProducts)
                .FirstOrDefaultAsync(m => m.Id == model.Id) ?? throw new Exception("Meal not found");
            NewMeal.Name = model.Name;
            // Remove old products
            var ProductsToRemove = NewMeal.MealProducts
                .Where(mp => !model.Products.Any(p => p.ProductId == mp.ProductId))
                .ToList();

            _context.MealProducts.RemoveRange(ProductsToRemove);

            // Add new products
            var ProductsToAdd = model.Products
                .Where(p => !NewMeal.MealProducts.Any(mp => mp.ProductId == p.ProductId))
                .ToList();
            foreach(var p in ProductsToAdd)
            {
                if(p.ProductId == Guid.Empty)
                    continue;
                NewMeal.MealProducts.Add(new MealProductEntity
                {
                    MealId = NewMeal.Id,
                    ProductId = p.ProductId,
                    Amount = p.Amount
                });
            }

            // Edit products
            var ProductsToUpdate = model.Products
                .Where(p => NewMeal.MealProducts.Any(mp => mp.ProductId == p.ProductId))
                .ToList();
            foreach(var p in ProductsToUpdate)
            {
                if(p.ProductId == Guid.Empty)
                    continue;
                NewMeal.MealProducts.First(mp => mp.ProductId == p.ProductId).Amount = p.Amount;
            }

            _context.Meals.Update(NewMeal);
        }

        await _context.SaveChangesAsync();

        return RedirectToAction("Details", new { id = NewMeal.Id });
    }
}
public class MealDto
{
    public Guid? Id { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; } = "";
    public List<MealProductDto> Products { get; set; } = new();

    //Base constructor for creating a new NewMeal
    public MealDto() { }

    public MealDto(MealEntity meal)
    {
        Id = meal.Id;
        UserId = meal.UserId;
        Name = meal.Name;
        Products = meal.MealProducts.Select(mp => new MealProductDto
        {
            ProductId = mp.ProductId,
            Name = mp.Product.Name,
            State = mp.Product.State,
            Amount = mp.Amount
        }).ToList();
    }

    public MealEntity ToMealEntity() => new MealEntity
    {
        UserId = UserId,
        Name = Name,
        MealProducts = Products.Select(p => new MealProductEntity
        {
            ProductId = p.ProductId,
            Amount = p.Amount
        }).ToList()
    };
}

public class MealProductDto
{
    public Guid ProductId { get; set; }
    public string Name { get; set; } = "";
    public string State { get; set; } = "";
    public decimal Amount { get; set; }
}