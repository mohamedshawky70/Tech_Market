using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyShop.Web.Classes;
using MyShop.Web.Models;
using MyShop.Web.Repository;
using NToastNotify;

namespace MyShop.Web.Areas.Amin.Controllers
{
    [Area("Admin")]
	[Authorize(Roles = SD.AdminRole)] // بتاخد const variable

	public class CategoryController : Controller
    {
        private readonly IRepo<Category> Crepo;
        private readonly IToastNotification toastNotification;
        public CategoryController(IRepo<Category> _Crepo, IToastNotification _toastNotification)
        {
            Crepo = _Crepo;
            toastNotification = _toastNotification;
        }
        public  IActionResult Index()
        {
            IQueryable<Category> categories =  Crepo.getAll();
            return View(categories);
        }
        [HttpGet]
        public  IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public  IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                Crepo.Create(category);
                toastNotification.AddSuccessToastMessage($"{category.Name} Category has been added successfully");
                return RedirectToAction("Index");
            }
            return View(category);
        }
        [HttpGet]
        public  IActionResult Update(int Id)
        {
            Category category =  Crepo.getById(Id);
            return View("Create", category);

        }
        [HttpPost]
        public  IActionResult Update(Category category)
        {
            if (ModelState.IsValid)
            {
                 Crepo.Update(category);
                toastNotification.AddAlertToastMessage($"{category.Name} Category has been Updated successfully");
                return RedirectToAction("Index");
            }
            return View("Create", category);
        }
        [HttpGet]
        public  IActionResult Delete(int Id)
        {
            Category category =  Crepo.getById(Id);
            Crepo.Delete(category);
            toastNotification.AddErrorToastMessage($"{category.Name} Category has been added successfully");
            return RedirectToAction("Index");

        }

    }
}
