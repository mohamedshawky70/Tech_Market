using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using MyShop.Web.Migrations;
using MyShop.Web.Models;
using System.ComponentModel.DataAnnotations;

namespace MyShop.Web.ViewModels
{
    public class OrederHeader_ShopingCardVM
    {

        public OrderHeader? OrderHeader { get; set; } = new OrderHeader();
		public IEnumerable<ShopingCard> ?ShopingCard { get; set; }

    }
}
