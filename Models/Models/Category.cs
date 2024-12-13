using System.ComponentModel.DataAnnotations;

namespace MyShop.Web.Models
{
    public class Category
    {
        public int Id{ get; set; }
        [MaxLength(100)]
        public string Name{ get; set; }
        public string Description{ get; set; }
        public DateTime createdTime { get; set; } = DateTime.Now;
    }
}
