using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeeAPP.Models
{
    public class Recipes
    {
        [Key]
        public int RecipeID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }


    }
}
