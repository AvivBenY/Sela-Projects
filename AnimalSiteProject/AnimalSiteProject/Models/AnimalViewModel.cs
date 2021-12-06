using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalSiteProject.Models
{
    //AnimalViewModel used to attach the animal and the image of it
    #region AnimalViewModel
    public class AnimalViewModel
    {
        public IFormFile PictureName { get; set; }
        public Animal Animal { get; set; }
    }
    #endregion
}
