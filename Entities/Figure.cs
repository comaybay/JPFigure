using JPFigure.Entities.Enums;
using Microsoft.Extensions.Hosting;
using NpgsqlTypes;
using static System.Formats.Asn1.AsnWriter;

namespace JPFigure.Entities
{
	public class Figure
	{
		public int Id { get; set; }

		/// <summary>
		/// Số lượng figure còn trong kho
		/// </summary>
		public int StockCount { get; set; }

		public FigureType Type { get; set; }

		/// <summary>
		/// Tên sản phẩm
		/// </summary>
		public string ProductName { get; set; } = null!;
		
		public int CharacterId { get; set; }
		public int ManufactureId { get; set; }
		public int Height { get; set; }
		public DateOnly ReleaseDate { get; set; }
		public int Price { get; set; }
		public string[] Images { get; set; } = null!;
		public FigureScale Scale { get; set; }
		public GundamType GundamType { get; set; }

		public NpgsqlTsVector SearchVector { get; set; } = null!;

		public Character Character { get; set; } = null!;
		public Manufacture Manufacture { get; set; } = null!;

	}
}
