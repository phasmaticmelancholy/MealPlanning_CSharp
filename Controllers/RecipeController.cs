using MealPlanning_CSharp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Encodings.Web;
using System.Collections;

namespace MealPlanning_CSharp.Controllers;

public class RecipeController : Controller
{
    private readonly MealplanningContext _context;
    
    public RecipeController(MealplanningContext context)
    {
        _context = context;
    }

    // GET: /Recipes/
    public IActionResult Index()
    {
        return View(_context.Recipes.ToList());
    }
    

    public string Welcome(string name, int numTimes = 2)
    {
        return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");
    }
}
