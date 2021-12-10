using Microsoft.EntityFrameworkCore;
using RecipeeAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeeAPP.Data
{
    public class RecipeContext : DbContext
    {

        public RecipeContext (DbContextOptions<RecipeContext> options)
            : base(options)
        {

        }

        public DbSet<RecipeeAPP.Models.Recipe> Recipe { get; set; }

    }
}
