using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalSiteProject.Models
{
    //Define the Comment model
    #region Comment
    public class Comment
    {
        public int CommentId { get; set; }
        public int AnimalId { get; set; }
        public virtual Animal Animal { get; set; }

        [Required(ErrorMessage = "Must Fill")]
        [MaxLength(100, ErrorMessage = "Invalid Length")]        
        public string CommentText { get; set; }
    }
    #endregion
}
