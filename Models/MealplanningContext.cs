using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MealPlanning_CSharp.Models;

public partial class MealplanningContext : DbContext
{
    public MealplanningContext()
    {
    }

    public MealplanningContext(DbContextOptions<MealplanningContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ingredient> Ingredients { get; set; }

    public virtual DbSet<Recipe> Recipes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.HasKey(e => e.IngredientId).HasName("ingredient_pkey");

            entity.ToTable("ingredient");

            entity.HasIndex(e => new { e.Name, e.Status }, "ingredient_name_status_key").IsUnique();

            entity.Property(e => e.IngredientId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ingredient_id");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasColumnName("status");
        });

        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.HasKey(e => e.RecipeId).HasName("recipe_pkey");

            entity.ToTable("recipe");

            entity.Property(e => e.RecipeId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("recipe_id");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.PreparationTime).HasColumnName("preparation_time");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .HasColumnName("url");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
