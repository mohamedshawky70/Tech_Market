using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyShop.Web.Models;
using MyShop.Web.Repository;
using System.Security.Claims;
using X.PagedList;


namespace MyShop.Web.Areas.Customer.Controllers
{
     [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IRepo<Product> Prepo;
        private readonly IRepo<ShopingCard> Shrepo;
        private readonly ShopingCard shopingCard ;
        public HomeController(IRepo<Product> _Prepo, ShopingCard _shopingCard, IRepo<ShopingCard> _Shrepo)
        {
            Prepo = _Prepo;
            shopingCard = _shopingCard;
            Shrepo = _Shrepo;
        }

        public  IActionResult Index(int?page)
        {
			var pageNumber = page ?? 1; //default is first bage if no page
			IEnumerable<Product> products = Prepo.getAll().ToPagedList(pageNumber,8);
            return View(products);
        }
        //[HttpGet]
        public  IActionResult Details(int ProductId)
        {
            Product product =  Prepo.FindInclude(p => p.Id == ProductId, new[] { "Category" });
            shopingCard.ProductId = ProductId;
            shopingCard.product = product;
            shopingCard.Counter = 1;
            return View(shopingCard);
        }
        [HttpPost]
       // [ValidateAntiForgeryToken]
        [Authorize]
        public  IActionResult Details(ShopingCard shopingCard)
            {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            shopingCard.MoreToUserId = claim.Value;
            ShopingCard OldUserId =  Shrepo.FindInclude(sh => sh.MoreToUserId == shopingCard.MoreToUserId && sh.ProductId== shopingCard.ProductId);
            if (OldUserId != null)
            {
                OldUserId.Counter += shopingCard.Counter; //نفس اليوزر ونفس المنتج يبقي هيغير الكونتر بتاع المنتج ومش هضيف نفس المنتج بكونتر تاني
                 Shrepo.Update(OldUserId);

            }
            else
            {
                 Shrepo.Create(shopingCard);
            }
            return RedirectToAction("Index");
        }
    }
}

            /*//MoreToUser moreToUser =  Shrepo.getById(int.Parse(shopingCard.MoreToUserId));
            //shopingCard.ProductId = shopingCard.product.Id;
             Product product =  Prepo.getById(shopingCard.ProductId);
            shopingCard.product = product;*/