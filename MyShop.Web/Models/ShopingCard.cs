using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyShop.Web.Models
{
    public class ShopingCard
    {
        public int Id { get; set; }
        [Range(1, 50, ErrorMessage = "You must enter value between 1 to 50")]
        public int Counter { get; set; }
        //[ForeignKey("product")]

        public int ProductId { get; set; }
        [ValidateNever]

        public Product product { get; set; }
        //[ForeignKey("MoreToUser")]
        public string ?MoreToUserId { get; set; } 
        [ValidateNever]
        public MoreToUser MoreToUser { get; set; } 

    }
}
