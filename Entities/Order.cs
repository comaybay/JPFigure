namespace JPFigure.Entities
{
	public class Order
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public DateTime Date { get; set; } = DateTime.Now;

		public User User { get; set; } = null!;
		public List<OrderDetail> OrderDetails { get; set; } = null!;

	}
}	
