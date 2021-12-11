using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RecipeeAPP.Models;

using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeeAPP.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RecipeeAPP.Models.Recipe> Recipes { get; set; }
        public DbSet<RecipeeAPP.Models.User> Users { get; set; }
        public virtual DbSet<RecipeeAPP.Models.Ingredient> Ingredients { get; set; }
    }
}
