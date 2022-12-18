namespace JPFigure.Entities
{
	public class OrderDetail
	{
		public int Id { get; set; }
		public int OrderId { get; set; }
		public int FigureId { get; set; }
		public int Quantity { get; set; }

		public Figure Figure { get; set; } = null!;
		public Order Order { get; set; } = null!;
	}
}
