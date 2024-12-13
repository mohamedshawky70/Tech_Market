using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyShop.Web.Models
{
    public class Product
    {
        public int Id{ get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        public string Description { get; set; }
        [ValidateNever]
        public string Img { get; set; } 
        public decimal Price { get; set; } 
        public int CategoryId { get; set; } 
        [ValidateNever]
        public Category Category { get; set; }
    }
}
