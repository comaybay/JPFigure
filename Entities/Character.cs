namespace JPFigure.Entities
{
	public class Character
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public int SeriesId { get; set; }

		public Series Series { get; set; } = null!;
	}
}
