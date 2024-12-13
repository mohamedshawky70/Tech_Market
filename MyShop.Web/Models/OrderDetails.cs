﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MyShop.Web.Models
{
	public class OrderDetails
	{
        public int Id{ get; set; }
        public int Count{ get; set; }
        public decimal Price{ get; set; }
        public int OrderHeaderId { get; set; }
		[ValidateNever]
		public OrderHeader OrderHeader{ get; set; }
		public int ProductId{ get; set; }
		[ValidateNever]
		public Product Product{ get; set; }
	}
}
