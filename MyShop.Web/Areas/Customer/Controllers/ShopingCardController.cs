using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyShop.Web.Classes;
using MyShop.Web.Models;
using MyShop.Web.Repository;
using MyShop.Web.ViewModels;

using Stripe.Checkout;
using System.Data;
using System.Security.Claims;
using static System.Net.Mime.MediaTypeNames;

namespace MyShop.Web.Areas.Customer.Controllers
{
	[Area("Customer")]
    [Authorize]  // خاص بالكستومر وكمان لو دوست من غير متلوجن هيبعتك للوجن
    public class ShopingCardController : Controller
    {
        private readonly IRepo<ShopingCard> Shrepo;
        private readonly IRepo<Product> Prepo;
        private readonly IRepo<OrderHeader> Ohrepo;
        private readonly IRepo<MoreToUser> Mrepo;
        private readonly IRepo<OrderDetails> ODrepo;
        private readonly OrederHeader_ShopingCardVM orederHeader_ShopingCardVM;
        private readonly OrderHeader_OrderDetailsVM orderHeader_OrderDetailsVM;
        private readonly OrderHeader orderHeader ;
        private readonly OrderDetails orderDetails;

        public ShopingCardController(OrderHeader_OrderDetailsVM _orderHeader_OrderDetailsVM,OrderDetails _orderDetails,IRepo<OrderDetails> _ODrepo,IRepo<MoreToUser> _Mrepo,IRepo<ShopingCard> _shrepo, IRepo<Product> _Prepo, IRepo<OrderHeader> _Ohrepo, OrderHeader _orderHeader, OrederHeader_ShopingCardVM _orederHeader_ShopingCardVM)
        {
            Shrepo = _shrepo;
            Prepo=_Prepo;
            Ohrepo = _Ohrepo;
            orderHeader = _orderHeader;
            orederHeader_ShopingCardVM = _orederHeader_ShopingCardVM;
            Mrepo = _Mrepo;
            ODrepo = _ODrepo;
            orderDetails = _orderDetails;
            orderHeader_OrderDetailsVM = _orderHeader_OrderDetailsVM;
		}

        public IActionResult Index()
        {
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
			string UserId = claim.Value;
            IEnumerable<ShopingCard> shopingCard =  Shrepo.FindAllInclude(sh => sh.MoreToUserId == UserId, new[] { "product" });
            if (shopingCard.IsNullOrEmpty()) ViewBag.empty = "Empty";
			return View(shopingCard);
        }
        public IActionResult Plus(int CardId)
        {
            ShopingCard shopingCard =  Shrepo.getById(CardId);
            shopingCard.Counter += 1;
             Shrepo.Update(shopingCard);
            return RedirectToAction("Index");
        }
        public IActionResult Minus(int CardId)
        {

			ShopingCard shopingCardConter =  Shrepo.getById(CardId);
            
			if (shopingCardConter.Counter <= 1)
            {
				Shrepo.Delete(shopingCardConter);
			}
			else
            {
				shopingCardConter.Counter -= 1;
				 Shrepo.Update(shopingCardConter);
			}
            
	
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int CardId)
        {
			ShopingCard shopingCard =  Shrepo.getById(CardId);
			Shrepo.Delete(shopingCard);
			return RedirectToAction("Index");
		}
       /* public IActionResult NumOfCard()
        {
			IEnumerable<ShopingCard> shopingCard = Shrepo.getAll();
            int numOfCart = 0;
            foreach (var item in shopingCard)
            {
                numOfCart += item.Counter;

			}
            //ViewBag["num"]= numOfCart;
			return View("Customer", numOfCart);
        }*/

        [HttpGet]
        public IActionResult ProceedToBuy()
        {
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
			string UserId = claim.Value;
            /*IEnumerable<ShopingCard> shopingCard =  Shrepo.FindAllInclude(sh => sh.MoreToUserId == UserId, new[] { "MoreToUser" });
            shopingCard =  Shrepo.FindAllInclude(sh => sh.MoreToUserId == UserId, new[] { "product" });*/

            orederHeader_ShopingCardVM.ShopingCard =  Shrepo.FindAllInclude(sh => sh.MoreToUserId == UserId, new[] { "product"});


            if(ModelState.IsValid) orederHeader_ShopingCardVM.OrderHeader.MoreToUser =  Mrepo.FindInclude(m => m.Id == claim.Value);

			orederHeader_ShopingCardVM.OrderHeader.MoreToUserId = orederHeader_ShopingCardVM.OrderHeader.MoreToUser.Id;
			orederHeader_ShopingCardVM.OrderHeader.Name = orederHeader_ShopingCardVM.OrderHeader.MoreToUser.Name;
            orederHeader_ShopingCardVM.OrderHeader.Email = orederHeader_ShopingCardVM.OrderHeader.MoreToUser.Email;

			return View(orederHeader_ShopingCardVM);
        }
        [HttpPost]
        public IActionResult ProceedToBuy(OrederHeader_ShopingCardVM orederHeader_ShopingCardVM)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            string UserId = claim.Value;
            orederHeader_ShopingCardVM.ShopingCard =  Shrepo.FindAllInclude(sh => sh.MoreToUserId == UserId, new[] { "MoreToUser" });
			orederHeader_ShopingCardVM.ShopingCard =  Shrepo.FindAllInclude(sh => sh.MoreToUserId == UserId, new[] { "product" });

			orederHeader_ShopingCardVM.OrderHeader.OrderStatus = SD.Pending;
			orederHeader_ShopingCardVM.OrderHeader.PaymentStatus = SD.Pending;
			orederHeader_ShopingCardVM.OrderHeader.OrderDate = DateTime.Now;
			orederHeader_ShopingCardVM.OrderHeader.PaymentStatus = SD.Pending;
			orederHeader_ShopingCardVM.OrderHeader.MoreToUserId = UserId;

			foreach (var item in orederHeader_ShopingCardVM.ShopingCard)
            {
				orederHeader_ShopingCardVM.OrderHeader.TotalPrice += (item.Counter*item.product.Price);
            }

            orederHeader_ShopingCardVM.OrderHeader.PaymentDate = DateTime.Now;
            orederHeader_ShopingCardVM.OrderHeader.ShippingDate = DateTime.Now;
			orederHeader_ShopingCardVM.OrderHeader.OrderStatus = SD.Pending;

			if (ModelState.IsValid) orederHeader_ShopingCardVM.OrderHeader.MoreToUser =  Mrepo.FindInclude(m => m.Id == claim.Value);

			var domain = "https://localhost:44352/";
            var Options = new SessionCreateOptions
            {
                LineItems = new List<SessionLineItemOptions>(),
                Mode = "payment",
                SuccessUrl = domain+$"Customer/ShopingCard/OrderConfirmation?id={orederHeader_ShopingCardVM.OrderHeader.Id}",
                CancelUrl = domain+ $"Customer/ShopingCard/Index",
			};
            foreach (var item in orederHeader_ShopingCardVM.ShopingCard)
            {
                //orderDetails.Product = item.product;
                var sessionlineitemoption = new SessionLineItemOptions()
                {
                  
                    PriceData = new SessionLineItemPriceDataOptions()
                    {
                        UnitAmount = ((long)item.product.Price)*100,
                        Currency = "EGP",
                       
                        ProductData = new SessionLineItemPriceDataProductDataOptions()
                        {
                            Name = item.product.Name,
							
						},
                    },
                    Quantity = item.Counter
                };
                Options.LineItems.Add(sessionlineitemoption);
            }
            var service = new SessionService();
            Session session = service.Create(Options);
            orederHeader_ShopingCardVM.OrderHeader.SessionId = session.Id;
          
            

			if (ModelState.IsValid)  Ohrepo.Create(orederHeader_ShopingCardVM.OrderHeader);
			foreach (var item in orederHeader_ShopingCardVM.ShopingCard)
			{
                OrderDetails NeworderDetails = new OrderDetails()
                {
                    OrderHeaderId = orederHeader_ShopingCardVM.OrderHeader.Id,
				    ProductId = item.ProductId,
				    Price = item.product.Price,
				    Count = item.Counter

                };
                
                //orderDetails.Product = item.product;
                ODrepo.Create(NeworderDetails);
			}

			Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);
        }
        public IActionResult OrderConfirmation(int id)
        {
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
			string UserId = claim.Value;

			OrderHeader orderHeader =  Ohrepo.FindIncludeLast(m=>m.MoreToUserId==UserId);
			var service = new SessionService();
            Session session = service.Get(orderHeader.SessionId);

            IEnumerable<ShopingCard> shopingCards =  Shrepo.FindAllInclude(sh => sh.MoreToUserId == UserId);
            if (session.PaymentStatus.ToLower() == "paid")
            {
				orederHeader_ShopingCardVM.OrderHeader.PaymentId = session.PaymentIntentId; 
				orderHeader.OrderStatus = SD.Approved;
                Ohrepo.Update(orderHeader);
                Shrepo.DeleteAll(shopingCards); //  المنتجات اللي اشتراها
			}
             
            return View(orderHeader.Id);
		}

	}
}
