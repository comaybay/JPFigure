using JPFigure.Entities;

namespace JPFigure.Models;

public class Figure
{
	public int Id { get; set; }

	/// <summary>
	/// Số lượng figure còn trong kho
	/// </summary>
	public int StockCount { get; set; }

	/// <summary>
	/// Tên sản phẩm
	/// </summary>
	public string ProductName { get; set; } = null!;

	public int Height { get; set; }
	public DateOnly ReleaseDate { get; set; }
	public int Price { get; set; }
	public string[] Images { get; set; } = null!;
	public Character Character { get; set; } = null!;
	public Manufacture Manufacture { get; set; } = null!;
}
