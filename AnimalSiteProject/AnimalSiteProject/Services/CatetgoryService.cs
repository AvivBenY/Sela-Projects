using AnimalSiteProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalSiteProject.Services
{
    //CategoryService implementation for the Interface
    #region Category Service
    public class CatetgoryService : ICatetgoryService
    {
        //Db access
        readonly AnimalDbContext _animalDb;

        //Const
        public CatetgoryService(AnimalDbContext animalDb)
        {
            _animalDb = animalDb;
        }

        //GetCategories - return IEnumerable of all the categories
        public IEnumerable<Category> GetCategories()
        {
            return _animalDb.Categories.ToList();
        }

        //GetCategory - return the requested category by its id
        public Category GetCategory(int id)
        {
            return _animalDb.Categories
                .Where(c => c.CategoryId.Equals(id))
                .Include(c => c.Animals)
                .FirstOrDefault();
        }
    }
    #endregion
}