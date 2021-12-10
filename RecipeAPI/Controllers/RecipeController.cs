﻿using Microsoft.AspNetCore.Http;
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

        //Get: api/Recipe
       // [HttpPost]
       

        private bool RecipeExists(int id)
        {
            return _context.Recipe.Any(a => a.RecipeID == id);
        }
    }
}
