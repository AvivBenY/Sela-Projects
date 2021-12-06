using AnimalSiteProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalSiteProject.Services
{
    //AnimalService implementation for the Interface
    #region Animal Service
    public class AnimalService : IAnimalService
    {
        //Db Access
        readonly AnimalDbContext _animalDb;
        //Const
        public AnimalService(AnimalDbContext animalDb)
        {
            this._animalDb = animalDb;
        }

        //GetPopoularPets - return the 2 pets with the most comments.
        public IEnumerable<Animal> GetPopularPets()
        {
            return _animalDb.Animals
                .OrderByDescending(animal => animal.Comments.Count)
                .Take(2)
                .ToList();
        }

        //GetAnimal - Return the requested animal by its id.
        public Animal GetAnimal(int animalId)
        {
            return _animalDb.Animals.Find(animalId);
        }
        //SearchAnimalByName - return the requested animal by its name (used in the search-bar).
        public Animal SearchAnimalByName(string keyword)
        {
            return _animalDb.Animals.FirstOrDefault(a => a.AnimalName.ToLower().Equals(keyword));         
        }

        //GetPetsForCategoryId - return IEnumerable of animals of the requested category by category id.
        public IEnumerable<Animal> GetPetsForCategoryId(int id)
        {
           return _animalDb.Animals.Where(a => a.CategoryId.Equals(id)).ToList();
        }
    }
    #endregion
}