using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyShop.Web.Models
{
	public class OrderHeader
	{
        public int Id { get; set; }
        public string? MoreToUserId { get; set; }
        [ValidateNever]
        public MoreToUser? MoreToUser { get; set; }
        /*public int ShopingCardId { get; set; }
        [ValidateNever]
        public ShopingCard ShopingCard  { get; set; }*/ //remove migraion تنساش
        public DateTime? ShippingDate{ get; set; }
        public decimal? TotalPrice { get; set; } = 0;
        public string? OrderStatus{ get; set; }
        public string? PaymentStatus{ get; set; }
        public DateTime? PaymentDate{ get; set; }
        public DateTime OrderDate{ get; set; }
        public string? TrackingNumber{ get; set; }
        public string? Carrier{ get; set; }
        public string? SessionId{ get; set; }
        public string? PaymentId{ get; set; }
        public string Name { get; set; }
        public string City { get; set; }
		[EmailAddress]
		public string? Email { get; set; }
        [MinLength(11),MaxLength(11)]
        //[Phone]
		public string phone { get; set; }
		public string Adress { get; set; }
		public string? Country { get; set; }

	}
}
