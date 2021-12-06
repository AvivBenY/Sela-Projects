using AnimalSiteProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalSiteProject.Services
{
    //ICategoryService Interface for the Category methods
    #region Interface
    public interface ICatetgoryService
    {
        Category GetCategory(int id);
        IEnumerable<Category> GetCategories();
    }
    #endregion
}
