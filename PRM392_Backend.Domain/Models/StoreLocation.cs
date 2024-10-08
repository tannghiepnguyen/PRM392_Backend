﻿namespace PRM392_Backend.Domain.Models
{
	public class StoreLocation : ISoftDelete
	{
		public Guid ID { get; set; }
		public string Address { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public ICollection<Order> Orders { get; set; }
		public bool IsActive { get; set; }
	}
}
