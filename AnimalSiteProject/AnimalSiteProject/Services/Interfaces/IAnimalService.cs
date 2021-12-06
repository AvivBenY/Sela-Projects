using AnimalSiteProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalSiteProject.Services
{
    //IAnimalService Interface for the User methods
    #region Interface
    public interface IAnimalService
    {
        IEnumerable<Animal> GetPopularPets();
        Animal GetAnimal(int animalId);
        IEnumerable<Animal> GetPetsForCategoryId(int id);
        public Animal SearchAnimalByName(string keyword);
    }
    #endregion
}