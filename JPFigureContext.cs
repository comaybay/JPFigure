using JPFigure.Entities;
using JPFigure.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace JPFigure
{
	public class JPFigureContext : DbContext
	{
		public DbSet<Figure> Figures { get; set; }
		public DbSet<Character> Characters { get; set; }
		public DbSet<Series> Series { get; set; }
		public DbSet<Manufacture> Manufactures { get; set; }

		static JPFigureContext()
			=> NpgsqlConnection.GlobalTypeMapper.MapEnum<FigureScale>()
												.MapEnum<FigureType>();

		// để trống để tránh bị lỗi
		public JPFigureContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
			=> modelBuilder.HasPostgresEnum<FigureScale>()
						   .HasPostgresEnum<FigureType>();
	}
}
