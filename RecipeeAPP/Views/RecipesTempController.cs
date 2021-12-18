 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Korzh.EasyQuery.Linq;
using RecipeeAPP.Data;
using RecipeeAPP.Models;

namespace RecipeeAPP.Views
{
    public class RecipesTempController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecipesTempController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RecipesTemp
        public async Task<IActionResult> Index()
        {
            return View(await _context.Recipes.ToListAsync());
        }

        [HttpGet]

        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["GetRecipeDetails"] = searchString;

            var empquery = from x in _context.Recipes select x;

            if (!String.IsNullOrEmpty(searchString))
            {
                empquery = empquery.Where(x => x.Title.Contains(searchString) || x.Description.Contains(searchString) || x.Utensils.Contains(searchString) || x.ImageUrl.Contains(searchString));

            }

            return View(await empquery.AsNoTracking().ToListAsync());
            //      var recipe = from m in _context.Recipes
            ////                 select m;

            ////  if (!String.IsNullOrEmpty(searchString))
            //   {
            //       recipe = recipe.Where(s => s.Title!.Contains(searchString));
            ////  }

            //   return View(await recipe.ToListAsync());
        }

        // GET: RecipesTemp/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes
                .FirstOrDefaultAsync(m => m.RecipeID == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }



        // GET: RecipesTemp/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RecipesTemp/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecipeID,Title,Description,ImageUrl,Utensils,Updated")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recipe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recipe);
        }

        // GET: RecipesTemp/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return View(recipe);
        }

        // POST: RecipesTemp/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecipeID,Title,Description,ImageUrl,Utensils,Updated")] Recipe recipe)
        {
            if (id != recipe.RecipeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeExists(recipe.RecipeID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(recipe);
        }

        // GET: RecipesTemp/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes
                .FirstOrDefaultAsync(m => m.RecipeID == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // POST: RecipesTemp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipeExists(int id)
        {
            return _context.Recipes.Any(e => e.RecipeID == id);
        }

        
    }
}
