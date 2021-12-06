using AnimalSiteProject.Models;
using AnimalSiteProject.Services;
using AnimalSiteProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace AnimalSiteProject.Controllers
{
    public class AdminController : Controller
    {
        //Services & tools we use in order to approach the db to activate methods + const
        #region Services + Const

        readonly IAdminService _adminService;
        readonly ICatetgoryService _categoriesService;
        readonly IWebHostEnvironment _webHostEnviroment;        
        readonly List<SelectListItem> _categoriesSelect;

        //Constructor
        public AdminController(IAdminService adminService, ICatetgoryService categoriesService,
            IWebHostEnvironment webHostEnviroment)
        {
            _adminService = adminService;
            _categoriesService = categoriesService;
            _webHostEnviroment = webHostEnviroment;
            
            _categoriesSelect = _categoriesService.GetCategories()
                .Select(c => new SelectListItem
                (c.CategoryName, c.CategoryId.ToString()))
                .ToList();
        }
        #endregion

        //Admin actions.
        #region Actions

        //Admin first page, shows all animals.
        public IActionResult AdminActions()
        {
            IEnumerable<Animal> animalShow = _adminService.GetAllAnimals();
            return View(animalShow);
        }
        
        public IActionResult AllPetsDisplay()
        {
            var allAnimals = _adminService.GetAllAnimals();
            return View(allAnimals)
;        }

        //Edit pet page - use id inorder to get to the requested animal and edit it.
        public IActionResult EditPet(int id)
        {
            var animal = _adminService.Get(id);
            ViewBag.Categories = _categoriesSelect;
            return View(animal);
        }
               
        //Edit Pet(POST) - validates that the pet edited in a valid way.
        [HttpPost]
        public IActionResult EditPet(Animal animal)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Categories = _categoriesSelect;
                _adminService.Update(animal);
                return RedirectToAction("AdminActions");
            }
            else
            {
            return View();
            }
        }

        //Delete pet from Db
        public IActionResult Delete(int id)
        {
            _adminService.Delete(id);
            return Redirect(Request.Headers["Referer"].ToString());
        }

        //Add pet to the Db (use category list for the drop down button)
        public IActionResult AddPet()
        {
            ViewBag.Categories = _categoriesSelect;
            return View();
        }                

        //Add pet(POST) - validates that the added pet is valid & add image.
        [HttpPost]
        public IActionResult AddPet(AnimalViewModel ivm)
        {
            if (ModelState.IsValid)
            {
                _adminService.Create(ivm.Animal, ivm.PictureName, _webHostEnviroment.WebRootPath);
                return RedirectToAction("AdminActions");
            }
            else
            {
                ViewBag.Categories = _categoriesSelect;
                return View();
            }
        }
        
        //AddImage - works with "AddPet"
        public IActionResult AddImage()
        {
            return View();
        }
        #endregion
    }
}
