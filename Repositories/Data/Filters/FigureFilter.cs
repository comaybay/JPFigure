namespace JPFigure.Repositories.Data.Filters
{
	public class FigureFilter
	{
		public int ManufactureId { get; set; }
		public (int from, int to) PriceRange { get; set; }
	}
}
