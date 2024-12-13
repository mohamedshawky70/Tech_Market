using MyShop.Web.Models;

namespace MyShop.Web.ViewModels
{
	public class OrderHeader_OrderDetailsVM
	{
		public OrderHeader OrderHeader{ get; set; }
		public IEnumerable<OrderDetails>? OrderDetails { get; set; }
	}
}
