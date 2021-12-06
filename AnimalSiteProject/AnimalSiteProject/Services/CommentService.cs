using AnimalSiteProject.Models;
using AnimalSiteProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalSiteProject.Services
{
    //CommentService implementation for the Interface
    #region Comment Service
    public class CommentService : ICommentService
    {
        //Db Access
        readonly AnimalDbContext _animalDb;
        
        //Const
        public CommentService(AnimalDbContext animalDb)
        {
            _animalDb = animalDb;
        }
        #region CRUD
        public Comment Add(Comment comment)
        {
            var newComment = _animalDb.Comments.Add(comment).Entity;
            _animalDb.SaveChanges();
            return newComment;
        }

        public void Delete(int id)
        {
            var c = _animalDb.Comments.Find(id);
            _animalDb.Comments.Remove(c);
            _animalDb.SaveChanges();
        }

        public Comment Get(int id)
        {
            return _animalDb.Comments.Find(id);
        }

        public void Update(Comment comment)
        {
            _animalDb.Comments.Update(comment);
        }

        #endregion

        //GetCommentsForAnimal - return IEnumerable of comments for requested animal by id
        public IEnumerable<Comment> GetCommentsForAnimal(int id)
        {
            var animal = _animalDb.Animals.Find(id);
            return animal.Comments;
        }        
    }
#endregion
}
