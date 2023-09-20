using System;
using System.Collections.Generic;

namespace MealPlanning_CSharp.Models;

public partial class Recipe
{
    public int RecipeId { get; set; }

    public string? Url { get; set; }

    public TimeSpan? PreparationTime { get; set; }

    public long Id { get; set; }
}
