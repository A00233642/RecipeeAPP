using Microsoft.EntityFrameworkCore;
using System;
using RecipeeAPP.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeeAPP.Data
{
    public class RecipeContext :DbContext
    {
        public RecipeContext(DbContextOptions<RecipeContext> options)
    : base(options)
        {
        }

        public virtual DbSet<Recipe> Recipes { get; set; }
        public DbSet<User> Users { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
    }
}
