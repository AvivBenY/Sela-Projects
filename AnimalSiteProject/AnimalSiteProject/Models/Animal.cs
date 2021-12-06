using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalSiteProject.Models
{
    //Define the animal model
    public class Animal
    {
        //Animal Model
        #region Animal
        public int AnimalId { get; set; }
        
        [Required(ErrorMessage = "Must Fill")]
        [MaxLength(15, ErrorMessage ="Invalid Length")]        
        [DataType(DataType.Text, ErrorMessage ="numbers are not allowed in animal name")]
        [RegularExpression("[a-zA-Z]+", ErrorMessage="Only letters allowed")]
        public string AnimalName { get; set; }

        [Range(0,500)]
        public int Age { get; set; }
        public string PictureName { get; set; }

        [MaxLength(100, ErrorMessage = "Invalid Length")]
        public string Description { get; set; }
        
        
        [Required(ErrorMessage = "Must Fill")]
        public int CategoryId { get; set; }        
        public virtual Category AnimalCategory { get; set; }
        public virtual List<Comment> Comments { get; set; }
        #endregion
    }
}
