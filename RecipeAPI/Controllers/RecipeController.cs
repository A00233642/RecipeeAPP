using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeeAPP.Data;
using RecipeeAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RecipeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {


        private readonly RecipeContext _context;

        public RecipeController(RecipeContext context)
        {
            _context = context;
        }

        //Get: Recipe
        [HttpGet]

        public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipe()
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return await _context.Recipe.ToListAsync();
        }

        //Get: api/Recipe
        [HttpGet("{title}")]

        public async Task<ActionResult<List<Recipe>>> GetRecipe(String title)
        {
            var recipe = _context.Recipe.Where(t => t.Title == title).ToList();

            if (recipe == null)
            {
                return NotFound();
            }

            return recipe;
        }

        //Get: api/Recipe
        [HttpGet("{id}")]
        public async Task<ActionResult> PutRecipe(int id, Recipe recipe)
        {
            if (id != recipe.RecipeID)
            {
                return BadRequest();
            }

            _context.Entry(recipe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeExists(id))
                {
                    return NotFound();
                }

                else
                {
                    throw;
                }

            }
            return NoContent();
        }

        //Post: api/Recipe
        //Post: api/Recipe
        [HttpPost]
        public async Task<ActionResult<Recipe>> PostRecipes(Recipe recipe)
        {
            _context.Recipe.Add(recipe);
            await _context.SaveChangesAsync();
            Response.Headers.Add("Access-Control-Allow-Origin", "https://localhost:44311/");
            return CreatedAtAction("GetRecipe", new { id = recipe.RecipeID }, recipe);

        }

        [HttpGet("{AddRecipe}")]
        public async Task<ActionResult> AddRecipe(String Title, string Description, string url)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            var Recipes = new Recipe();
            Recipes.Title = Title;

            Recipes.Description = Description;
            Recipes.ImageUrl = url;

            _context.Recipe.Add(Recipes);
            await _context.SaveChangesAsync();



            return CreatedAtAction("GetRecipes", new { id = 0 }, Recipes);
        }


        private bool RecipeExists(int id)
        {
            return _context.Recipe.Any(a => a.RecipeID == id);
        }

    }

}
