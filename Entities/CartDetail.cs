namespace JPFigure.Entities
{
	public class CartDetail
	{
		public int Id { get; set; }
		public int CartId { get; set; }
		public int FigureId { get; set; }
		public int Quantity { get; set; }

		public Figure Figure { get; set; } = null!;
		public Cart Cart { get; set; } = null!;
	}
}
