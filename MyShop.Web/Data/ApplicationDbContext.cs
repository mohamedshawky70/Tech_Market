using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyShop.Web.Models;

namespace MyShop.Web.Data
{
    public class ApplicationDbContext:IdentityDbContext<MoreToUser> //inhert from DbContext ,<..> علشان افهمه اني التعديل في الداتابيز هيتم في الجدول الاصلي مش جدول المور
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<MoreToUser> moreToUsers{ get; set; }
        public DbSet<Category>categories{ get; set; }
         public DbSet<Product> products{ get; set; }
         public DbSet<ShopingCard> shopingCards{ get; set; }
         public DbSet<OrderHeader> orderHeaders{ get; set; }
         public DbSet<OrderDetails> OrderDetails { get; set; }

    }
}
