using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeeAPP.Models
{
    public class Recipe
    {
        [Key]
        public int RecipeID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Ingredient { get; set; }

        public string Utensils { get; set; }

        public IEnumerable<String> Tags { get; set; }

        public DateTime Updated { get; set; }


    }
}
