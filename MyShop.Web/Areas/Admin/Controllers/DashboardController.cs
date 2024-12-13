using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyShop.Web.Classes;
using MyShop.Web.Models;
using MyShop.Web.Repository;
using MyShop.Web.ViewModels;
using NToastNotify;
using System.Security.Claims;

namespace MyShop.Web.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = SD.AdminRole)] // بتاخد const variable
	public class DashboardController : Controller
	{
		
		private readonly IRepo<OrderHeader> OHrepo;
		private readonly IRepo<MoreToUser> Mrepo;
		private readonly IRepo<Product> Prepo;
		private readonly DashboardVM DashboardVM;
		public DashboardController(DashboardVM _DashboardVM, IRepo<OrderHeader> _OHrepo, IRepo<MoreToUser> _Mrepo, IRepo<Product> _Prepo)
		{
			OHrepo = _OHrepo;
			Mrepo = _Mrepo;
			Prepo = _Prepo;
			DashboardVM = _DashboardVM;
		}
		public IActionResult Index()
		{
			ViewBag.Orders = OHrepo.getAll().Count();
			ViewBag.ApprovedOrders = OHrepo.getAll().Count(o=>o.OrderStatus==SD.Approved);
			ViewBag.Users = Mrepo.getAll().Count();
			ViewBag.Products = Prepo.getAll().Count();

			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
			string UserId = claim.Value;

			IEnumerable<OrderHeader> orderHeaders = OHrepo.FindAllInclude(o => o.MoreToUserId != UserId);   //كل الأوردرز بتاعة اليوزر ماعدا اللي داخل دلوقتي اللي هوه الأدمن		
			return View(orderHeaders);
		}
	}
}
