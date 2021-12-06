using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalSiteProject.Models
{
    //CommentViewModel used to attach the comment and the Animal of it.
    #region CommentsViewModel
    public class CommentsViewModel
    {
        public Comment Comment { get; set; }
        public Animal Animal { get; set; }
        
        //Const
        public CommentsViewModel(Animal animal)
        {
            Animal = animal;
            Comment = new Comment { AnimalId = Animal.AnimalId };
        }
    }
    #endregion
}
