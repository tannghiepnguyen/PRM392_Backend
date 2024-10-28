using System;

namespace PRM392_Backend.Domain.Models
{
	public class Payment
	{
		public Guid ID { get; set; }
		public Guid OrderID { get; set; }
		public decimal Amount { get; set; }
		public DateTime PaymentDate { get; set; }
		public string PaymentStatus { get; set; }
	}
}
