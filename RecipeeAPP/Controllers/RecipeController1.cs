using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using RecipeeAPP.Models;
using System.Linq;
using System.Threading.Tasks;
using RecipeeAPP.Data;
using Microsoft.EntityFrameworkCore;

namespace RecipeeAPP.Controllers
{
    public class RecipeController1 : Controller
    {
        


        // GET: Recipes/Create
        public IActionResult Create()
        {
            return View();
        }

    }
}
