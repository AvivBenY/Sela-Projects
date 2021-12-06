using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalSiteProject.Models
{
    //Db context aaproach to the Db 
    public class AnimalDbContext : DbContext
    {
        //Define the Db tables
        #region Dbcontext
        public AnimalDbContext(DbContextOptions<AnimalDbContext> options) : base(options) { }

        public virtual DbSet<Animal> Animals { get; set; }        
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        #endregion
        //Insert data to the Db tables
        #region OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Dogs" },
                new Category { CategoryId = 2, CategoryName = "Cats" },
                new Category { CategoryId = 3, CategoryName = "Camels" }
                );
            modelBuilder.Entity<Animal>().HasData(
                new Animal{AnimalId = 1, AnimalName = "Russle", Age = 6, PictureName = "Russle.jpeg", Description = "Old fart living the life", CategoryId = 1 },
                new Animal{AnimalId = 2, AnimalName = "Jacky", Age = 1, PictureName = "Jacky.jpeg", Description = "Young Loving nad Horrible Creature", CategoryId = 1 },
                new Animal{AnimalId = 3, AnimalName = "Cat", Age = 666, PictureName = "Satan.jpeg", Description = "Legendery Creature of HELL, pet him and leave.", CategoryId = 2 },                
                new Animal{AnimalId = 5, AnimalName = "Camel", Age = 5, PictureName = "Camel.jpg", Description = "Big Camel.", CategoryId = 3 }               
                );
            
            modelBuilder.Entity<Comment>().HasData(
                new Comment { CommentId = 1, AnimalId = 1, CommentText = "Great Loving Old Dog" },
                new Comment { CommentId = 2, AnimalId = 1, CommentText = "Smells Bad" },                
                new Comment { CommentId = 4, AnimalId = 2, CommentText = "Daddy's Princes" },                
                new Comment { CommentId = 6, AnimalId = 5, CommentText = "Hardcore Camel" }
                );
        }
        #endregion
    }
}