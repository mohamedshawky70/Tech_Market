using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyShop.Web.Classes;
using MyShop.Web.Models;
using MyShop.Web.Repository;
using NToastNotify;
using NToastNotify.Helpers;

namespace MyShop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Authorize(Roles = SD.AdminRole)] // بتاخد const variable
	public class ProductController : Controller
    {
        private readonly IRepo<Product> Prepo;
        private readonly IRepo<Category> Crepo;
        private readonly IToastNotification toastNotification;
        private readonly IWebHostEnvironment webHostEnvironment;
        public ProductController(IRepo<Product> _Prepo, IRepo<Category> _Crepo, IToastNotification _toastNotification, IWebHostEnvironment _webHostEnvironment)
        {
            Prepo = _Prepo;
            Crepo = _Crepo;
            toastNotification = _toastNotification;
            webHostEnvironment = _webHostEnvironment; 
        }
        public  IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public  IActionResult GetData()
        {
            IQueryable<Product> products =  Prepo.getAll();
            products=products.Include(p => p.Category);//ده معناه لو حذفت الكاتيجوي مش هيجيب البرودكتس بتوعه يعني هيتحذفوا في صفحة الإندكس 
            return Json(new { data = products });
        }
        [HttpGet]
        public  IActionResult Create()
        {
            IQueryable<Category>categories =  Crepo.getAll();
            ViewBag.allCategories = categories;
            return View();
        }
        [HttpPost]
        public  IActionResult Create(Product product,IFormFile Image)
        {
            string RootPath = webHostEnvironment.WebRootPath;//علشان اقر اوصل لل دب دب رووت علشان اوصل للباث بتاع الصورة
            if (Image != null)
            {
                string ImgPath = Path.Combine(RootPath, @"Images\Product");//  الباث كله بدون اسم الصورة-----> wwwroot\Images\Product\
                using (var filestream = new FileStream(Path.Combine(ImgPath, Image.FileName),FileMode.Create))
                {
                    Image.CopyTo(filestream);//احفظلي الصورة في الباث ده باسمها
                }
                product.Img = Image.FileName;// لازم تاخد قيمه في الداتابيز فهنديها اسمها الفايل نيم الاسم بالاكستنشن
            }
            if (ModelState.IsValid)
            {
                 Prepo.Create(product);
                toastNotification.AddSuccessToastMessage($"{product.Name} Product has been added successfully");
                return RedirectToAction("Index");
            }
            IQueryable<Category> categories =  Crepo.getAll();
            ViewBag.allCategories = categories;
            return View(product);
        }
        [HttpGet]
        public  IActionResult Update(int Id)
        {
            Product product =  Prepo.getById(Id);
            IQueryable<Category> categories =  Crepo.getAll();
            ViewBag.allCategories = categories;
            return View("Create", product);
        }
        [HttpPost]
        public  IActionResult Update(Product product, IFormFile? Image) //Image نفس اسم ال name بتاع الانبوت بتاع الامج
        {
            string RootPath = webHostEnvironment.WebRootPath;
            string ImgPath=string.Empty;
            if (Image != null)//لو مش هتعدل علي الصورة فهي بنل فبالفعل محفوظة
            {
                 ImgPath = Path.Combine(RootPath, @"Images\Product");
                using (var filestream = new FileStream(Path.Combine(ImgPath, Image.FileName), FileMode.Create))
                {
                    Image.CopyTo(filestream);
                }
                product.Img = Image.FileName;
            }
            
                    //!حذف الصورة القديمة
         
            if (ModelState.IsValid)
            {
                
                 Prepo.Update(product);
                toastNotification.AddAlertToastMessage($"{product.Name} Product has been edited successfully");
                return RedirectToAction("Index");
                //return Json(new { data=product });

            }
            IQueryable<Category> categories =  Crepo.getAll();
            ViewBag.allCategories = categories;
            return View("Create", product);
        }
        [HttpDelete]
        public  IActionResult Delete(int Id)
        {
            Product product =  Prepo.getById(Id);
           // toastNotification.AddErrorToastMessage($"{product.Name} Product has been deleted successfully");
            Prepo.Delete(product);
            return Json(new { success = true });  //return as json to ajax
        }
    }
}
