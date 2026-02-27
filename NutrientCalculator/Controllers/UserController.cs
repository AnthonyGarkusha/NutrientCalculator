using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NutrientCalculator.Models;


namespace NutrientCalculator.Controllers;

public class UserController(AppDBContext context): Controller
{
    private readonly AppDBContext _context = context;

    // GET
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateUserViewModel model)
    {
        if(!ModelState.IsValid)
            return View(model);

        var user = new UserEntity
        {
            Name = model.UserName,
            Email = model.Email
        };
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Index()
    {
        var users = await _context.Users.ToListAsync();
        return View(users);
    }


    public IActionResult Details(Guid Id)
    {
        var user =  _context.Users
            .Include(u => u.Meals)
            .Include(u => u.Rations)
            .FirstOrDefault(u => u.Id == Id);
        if(user == null)
        {
            return NotFound();
        }
        return View(user);
    }
}