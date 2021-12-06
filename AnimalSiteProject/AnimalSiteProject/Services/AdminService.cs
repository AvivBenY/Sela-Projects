using AnimalSiteProject.Models;
using AnimalSiteProject.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalSiteProject.Services
{
    //AdminService implementation for the Interface
    #region Admin Service
    public class AdminService : IAdminService
    {
        //Db Access
        readonly AnimalDbContext _animalDb;
        
        //Const
        public AdminService(AnimalDbContext animalDb)
        {
            _animalDb = animalDb;
        }

        //GetAllAnimals - Get IEnumerable of all the animals
        public IEnumerable<Animal> GetAllAnimals()
        {
            return _animalDb.Animals.ToList();
        }

        //Create - Create new animal in the Db
        public void Create(Animal animal, IFormFile picture, string rootPath)
        {
            animal.PictureName = UploadFile(picture, rootPath);
            _animalDb.Animals.Add(animal);
            _animalDb.SaveChanges();
        }

        //Delete - Delete animal from the Db using id
        public void Delete(int id)
        {
            var animal = _animalDb.Animals.Find(id);
            _animalDb.Remove(animal);
            _animalDb.SaveChanges();
        }

        //Get - Get the requested animal using id
        public Animal Get(int id)
        {
            return _animalDb.Animals.Find(id);
        }

        //Update - updates the selected animal
        public void Update(Animal animal)
        {
            _animalDb.Animals.Update(animal);
            _animalDb.SaveChanges();
        }

        //UploadFile - Upload the image for the animal
        string UploadFile(IFormFile file, string rootPath)
        {
            string fileName = null;
            if (file != null && file.Length > 0)
            {
                string uploadDir = Path.Combine(rootPath, "Pictures");
                fileName = Guid.NewGuid().ToString() + "-" + file.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using (var filestream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(filestream);
                }
            }
            return fileName;
        }
    }
    #endregion
}
