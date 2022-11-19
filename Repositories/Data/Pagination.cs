using JPFigure.Models;

namespace JPFigure.Repositories.Data
{
	public class Pagination<T>
	{
		/// <summary>
		/// Trang hiện tại
		/// </summary>
		public int PageNumber { get; set; }

		/// <summary>
		/// Danh sách các kết quả của trang hiện tại
		/// </summary>
		public IList<T> Items { get; set; } = null!;

		/// <summary>
		/// Tổng số lượng trang chứa kết quả
		/// </summary>
		public int NumberOfPages { get; set; }
	}
}
