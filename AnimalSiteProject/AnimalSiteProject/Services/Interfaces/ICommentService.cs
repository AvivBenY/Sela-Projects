using AnimalSiteProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalSiteProject.Services.Interfaces
{
    //ICommentService Interface for the Comments methods
    #region Interface
    public interface ICommentService
    {
        public Comment Add(Comment comment);
        public void Delete(int id);
        public Comment Get(int id);
        public void Update(Comment comment);
        public IEnumerable<Comment> GetCommentsForAnimal(int id);        
    }
    #endregion
}
