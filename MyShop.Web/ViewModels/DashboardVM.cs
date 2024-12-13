using MyShop.Web.Models;

namespace MyShop.Web.ViewModels
{
	public class DashboardVM
	{
		public IEnumerable<MoreToUser> MoreToUser{ get; set; }
		public IEnumerable<Product> Product{ get; set; }
		public IEnumerable<OrderHeader> OrderHeader{ get; set; }
	}
}
