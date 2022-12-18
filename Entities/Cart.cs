﻿namespace JPFigure.Entities
{
	public class Cart
	{
		public int Id { get; set; }
		public int UserId { get; set; }

		public User User { get; set; } = null!;
		public List<CartDetail> CartDetails { get; set; } = null!;
	}
}
