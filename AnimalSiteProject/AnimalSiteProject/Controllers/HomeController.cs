using AnimalSiteProject.Models;
using AnimalSiteProject.Services;
using AnimalSiteProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalSiteProject.Controllers
{
    public class HomeController : Controller
    {
        //Services & tools we use in order to approach the db to activate methods + const
        #region Services + Const
        readonly IAnimalService _animalService;
        readonly ICatetgoryService _catetgoryService;
        readonly ICommentService _commentService;

        //Constructor
        public HomeController(IAnimalService animalService, ICatetgoryService catetgoryService, ICommentService commentService)
        {
            _animalService = animalService;
            _catetgoryService = catetgoryService;
            _commentService = commentService;
        }
        #endregion

        #region Pages

        //Index (Home Page) - Shows 2 pets with the most comments.
        public IActionResult Index()
        {
            IEnumerable<Animal> animalShow = _animalService.GetPopularPets();
            return View(animalShow);
        }

        //CatalogPage - choose category of animals.
        public IActionResult Catalog()
        {
            IEnumerable<Category> showCategories = _catetgoryService.GetCategories();
            return View(showCategories);
        }

        //ShowCategory - Show chosen category
        public IActionResult ShowCategory(int id)
        {            
            Category category = _catetgoryService.GetCategory(id);
            return View(category);
        }

        //AnimalProfile - show all info about a specific animal
        public IActionResult AnimalProfile(int id)
        {
            Animal chosenOne = _animalService.GetAnimal(id);
            return View(chosenOne);
        }

        //FindByName - connected to the "search" in the website
        //Show's animal profile by its name using the SearchViewModel
        [HttpPost]
        public IActionResult FindByName(SearchViewModel vm)
        {
            var animal = _animalService.SearchAnimalByName(vm.Keyword);
            if (animal is null)
            {
                return View("AnimalNotFound");
            }
            return RedirectToAction("AnimalProfile", new { id = animal.AnimalId });
        }
        
        //Back - Return to the Reffering View.
        public IActionResult Back()
        {
            return Redirect(Request.Headers["Referer"].ToString());
        }

        //AddComment(POST) - Let the user Add Comments Check if the comment is valid.
        //if not return to the reffering view.
        [HttpPost]
        public IActionResult AddComment(Comment comment)
        {
            if (ModelState.IsValid)
            {
                _commentService.Add(comment);
            }
             return Redirect(Request.Headers["Referer"].ToString());
        }        

        #endregion       
    }
}