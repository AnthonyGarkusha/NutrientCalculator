using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NutrientCalculator.Models;


namespace NutrientCalculator.Controllers;

public class ProductController(AppDBContext context): Controller
{
    private readonly AppDBContext _context = context;

    public IActionResult Index()
    {
        var products = _context.Products.ToList();
        return View(products);
    }

    public IActionResult Details(Guid id)
    {
        var product = _context.Products
            .Include(p => p.ProductNutrients)
            .ThenInclude(pn => pn.Nutrient)
            .FirstOrDefault(p => p.Id == id);
        if(product == null)
        {
            return NotFound();
        }
        return View(product);
    }

}