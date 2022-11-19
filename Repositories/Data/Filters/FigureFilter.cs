namespace JPFigure.Repositories.Data.Filters
{
	public class FigureFilter
	{
		public int? ManufactureId { get; set; }
		public (int? from, int? to) PriceRange { get; set; }
		
		/// <summary>
		/// Sắp xếp mới nhất, cho = false nếu muốn xem cũ nhất
		/// </summary>
		public bool OrderNewest { get; set; } = true;
	}
}
