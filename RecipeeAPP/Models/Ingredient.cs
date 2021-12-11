using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeeAPP.Models
{
    public class Ingredient
    {
        [Key]
        public int id { get; set; }

        public string IngredientName { get; set; }

        public string IngredientPrice { get; set; }

        public int IngredientQuantity { get; set; }


        public virtual Recipe Recipe { get; set; }

    }
}
