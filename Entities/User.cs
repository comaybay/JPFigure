namespace JPFigure.Entities
{
	public class User
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string Email { get; set; } = null!;
		public string Role { get; set; } = null!;
		public string Password { get; set; } = null!;
		public DateOnly? DateOfBirth { get; set; }
		public bool? IsFemale { get; set; }

		public List<Order> Orders { get; set; } = null!;
		public Cart Cart { get; set; } = null!;
	}
}
