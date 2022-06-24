using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Yummy.ViewModels.Menu
{
    public class MenuVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Ingredients { get; set; }
        [Required,NotMapped]
        public IFormFile Image { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
