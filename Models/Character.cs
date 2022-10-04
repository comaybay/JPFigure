using JPFigure.Entities;

namespace JPFigure.Models
{
	public class Character
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;

		public Series Series { get; set; } = null!;
	}
}
