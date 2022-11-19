using JPFigure.Repositories.Data;
using Microsoft.EntityFrameworkCore;

namespace JPFigure.Repositories
{
	public class PaginationHelper
	{
		public static async Task<Pagination<T>> Create<T>(int limit, int page, Func<IQueryable<object>> getItems)
		{
			return new Pagination<T>()
			{
				Items = await getItems().Skip((page - 1) * limit)
									  .Take(limit)
									  .Select(e => Map.To<T>(e))
									  .ToListAsync(),
				PageNumber = page,
				NumberOfPages = (int)Math.Ceiling(getItems().Count() / (double)limit)
			};
		}
	}
}
