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

        public DbSet<RecipeeAPP.Models.Recipe> Recipe { get; set; }
        public DbSet<RecipeeAPP.Models.User> User { get; set; }
        public DbSet<RecipeeAPP.Models.Ingredient> Ingredient { get; set; }
    }
}
