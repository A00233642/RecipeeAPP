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

        public string ImageUrl { get; set; }

        public string Utensils { get; set; }

      //  public IEnumerable<String> Tags { get; set; }

        public DateTime Updated { get; set; } = DateTime.Now;


        [System.Text.Json.Serialization.JsonIgnore]

        public virtual IEnumerable<Ingredient> Ingredients  { get; set; }
    }
}
