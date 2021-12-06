using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalSiteProject.Models
{
    //Define the Category model
    public class Category
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Must Fill")]
        [MaxLength(20, ErrorMessage = "Invalid Length")]
        [DataType(DataType.Text, ErrorMessage = "numbers are not allowed in Category")]
        [RegularExpression("[a-zA-Z]+", ErrorMessage = "Only letters allowed")]
        public string CategoryName { get; set; }
        public virtual List<Animal> Animals { get; set; }
    }
}
