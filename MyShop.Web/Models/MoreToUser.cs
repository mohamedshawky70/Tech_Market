using Microsoft.AspNetCore.Identity;
using System.ComponentModel;

namespace MyShop.Web.Models
{
    public class MoreToUser : IdentityUser //اللي مسئول عن الجدول اللي موجود في الداتابيز بتاع الريجستر
    {
        public string Name { get; set; }
    }
}
