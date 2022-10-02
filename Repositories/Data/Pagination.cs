using JPFigure.Models;

namespace JPFigure.Repositories.Data
{
	public class Pagination<T>
	{
		public int PageNumber { get; set; }
		public IEnumerable<T> Items { get; set; } = null!;
		public int NumberOfPages { get; set; }
	}
}
