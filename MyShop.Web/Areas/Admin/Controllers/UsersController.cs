using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyShop.Web.Classes;
using MyShop.Web.Models;
using MyShop.Web.Repository;
using System.Security.Claims;

namespace MyShop.Web.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Authorize(Roles = SD.AdminRole)] // بتاخد const variable
    public class UsersController : Controller
    {
        private readonly IRepo<MoreToUser> Mrepo;
        public UsersController(IRepo<MoreToUser> _Mrepo)
        {
            Mrepo = _Mrepo;
        }
        //[HttpGet]
        public  IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier); //محتاج افهمه
            string UserId = claim.Value;
            IQueryable<MoreToUser> moreToUsers =  Mrepo.getAll();
            return View(moreToUsers.Where(m => m.Id != UserId)); // كده لو دخلت كأدمت (اللي عامل لوجن دلوقتي) مش هيجيبك مع اليوزرز

        }
        [HttpGet]
        /*public  IActionResult> GetData()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier); //محتاج افهمه
            string UserId = claim.Value;
            IQueryable<MoreToUser> moreToUsers =  Mrepo.getAll();
            return Json(new { data = moreToUsers.Where(m => m.Id != UserId)  });
            //return View(moreToUsers.Where(m => m.Id != UserId)); // كده لو دخلت كأدمت (اللي عامل لوجن دلوقتي) مش هيجيبك مع اليوزرز
        }*/
        public  IActionResult LockUnLock(string id)
        {
            MoreToUser user =  Mrepo.FindInclude(u=>u.Id==id);
            //int idd = int.Parse(id);
            //MoreToUser user =  Mrepo.getById(idd);
            if (user.LockoutEnd == null || DateTimeOffset.Now > user.LockoutEnd) // لو كان مفتوح
            { 
                user.LockoutEnd = DateTimeOffset.Now.AddYears(1);// اقفله
            }
            else
            {
                user.LockoutEnd = DateTimeOffset.Now;
            }
             Mrepo.Update(user); //to saveChanges
            return RedirectToAction("Index");
      
        }
    }
}
