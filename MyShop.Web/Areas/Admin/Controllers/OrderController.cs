using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyShop.Web.Classes;
using MyShop.Web.Models;
using MyShop.Web.Repository;
using MyShop.Web.ViewModels;
using NToastNotify;
using System.Security.Claims;
using System.Security.Cryptography;

namespace MyShop.Web.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = SD.AdminRole)] // بتاخد const variable
	public class OrderController : Controller
	{
		private readonly IRepo<OrderHeader> OHrepo;
		private readonly IRepo<OrderDetails> ODrepo;
		private readonly IToastNotification toastNotification;
		private readonly OrderHeader_OrderDetailsVM orderHeader_OrderDetailsVM;
		
		public OrderController(IToastNotification _toastNotification,IRepo<OrderHeader> _OHrepo, IRepo<OrderDetails> _ODrepo, OrderHeader_OrderDetailsVM _orderHeader_OrderDetailsVM)
		{
			OHrepo = _OHrepo;
			ODrepo = _ODrepo;
			orderHeader_OrderDetailsVM = _orderHeader_OrderDetailsVM;
			toastNotification = _toastNotification;
		
		}

		public IActionResult Index()
		{
			/*var claimsIdentity = (ClaimsIdentity)User.Identity;
			var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier); //محتاج افهمه
			string UserId = claim.Value;

			IQueryable<Order> moreToUsers = Mrepo.getAll();
			return View(moreToUsers.Where(m => m.Id != UserId));*/
			return View();
		}
		[HttpGet]
		public  IActionResult GetData()
		{
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
			string UserId = claim.Value;
			
			IEnumerable<OrderHeader> orderHeaders =  OHrepo.FindAllInclude(o=>o.MoreToUserId!=UserId);	//كل الأوردرز بتاعة اليوزر ماعدا اللي داخل دلوقتي اللي هوه الأدمن		
			return Json(new { data = orderHeaders });
		}
		public  IActionResult Details(int id)
		{
			orderHeader_OrderDetailsVM.OrderHeader =  OHrepo.FindInclude(o => o.Id == id, new[] { "MoreToUser" });
			orderHeader_OrderDetailsVM.OrderDetails =  ODrepo.FindAllInclude(d => d.OrderHeaderId == id, new[] { "Product" });
			return View(orderHeader_OrderDetailsVM);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult UpdateDetails(int HID,OrderHeader_OrderDetailsVM NeworderHeader_OrderDetailsVM)
		{
			OrderHeader orderHeader = OHrepo.getById(HID);
			orderHeader.Name = NeworderHeader_OrderDetailsVM.OrderHeader.Name;
			orderHeader.Adress = NeworderHeader_OrderDetailsVM.OrderHeader.Adress;
			orderHeader.City = NeworderHeader_OrderDetailsVM.OrderHeader.City;
			orderHeader.phone = NeworderHeader_OrderDetailsVM.OrderHeader.phone;
			if (NeworderHeader_OrderDetailsVM.OrderHeader.Carrier != null)
			{
				orderHeader.Carrier = NeworderHeader_OrderDetailsVM.OrderHeader.Carrier;
			}
			if (NeworderHeader_OrderDetailsVM.OrderHeader.TrackingNumber != null)
			{
				orderHeader.TrackingNumber = NeworderHeader_OrderDetailsVM.OrderHeader.TrackingNumber;
			}
			if (ModelState.IsValid) OHrepo.Update(orderHeader);
			toastNotification.AddSuccessToastMessage($"{orderHeader.Name} Order has been Updated successfully");
			return RedirectToAction("Details", new {id=HID});//نفس اسم الباراميتر بتاع الديتيلز(id)
			
		}
		public IActionResult Proccess(int PID)
		{
			OrderHeader orderHeader = OHrepo.getById(PID);
			orderHeader.OrderStatus = SD.Proccessing;
			OHrepo.Update(orderHeader);
			toastNotification.AddSuccessToastMessage($"Order status has been Proccessed successfully");
			return RedirectToAction("Details", new { id = PID });
		}
		public IActionResult Shipping(int SHID)
		{
			OrderHeader orderHeader = OHrepo.getById(SHID);
			orderHeader.OrderStatus = SD.Shipping;
			OHrepo.Update(orderHeader);
			toastNotification.AddSuccessToastMessage($"Order status has been shipped successfully");
			return RedirectToAction("Details", new { id = SHID });
		}
		public IActionResult Cancel(int DID)
		{
			OrderHeader orderHeader = OHrepo.getById(DID);
			orderHeader.OrderStatus = SD.Canseled;
			OHrepo.Update(orderHeader);
			toastNotification.AddSuccessToastMessage($"Order status has been canceled successfully");
			return RedirectToAction("Details", new { id = DID });
		}
	}
}
