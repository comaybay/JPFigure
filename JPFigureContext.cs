using Microsoft.EntityFrameworkCore;

namespace JPFigure
{
	public class JPFigureContext : DbContext
	{
		private readonly IConfiguration config;

		protected JPFigureContext(IConfiguration config)
		{
			Console.Write(config);
			this.config = config;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
			=> optionsBuilder.UseNpgsql(config.GetConnectionString("JPFigurines"));
	}
}
