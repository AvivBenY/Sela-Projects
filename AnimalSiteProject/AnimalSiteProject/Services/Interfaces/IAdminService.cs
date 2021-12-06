using AnimalSiteProject.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalSiteProject.Services.Interfaces
{
    //IAdminService Interface for the Admin methods
    #region Interface
    public interface IAdminService
    {
        public IEnumerable<Animal> GetAllAnimals();
        public void Create(Animal animal, IFormFile picture, string rootPath);
        public Animal Get(int id);
        public void Update(Animal animal);
        public void Delete(int id);         
    }
    #endregion
}
